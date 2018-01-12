// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WspDal.cs" company="RHEA System S.A.">
//   Copyright (c) 2015 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4WspDal
{
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
    using System.ComponentModel.Composition;
#endif

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;    
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using CDP4Common.DTO;
    using CDP4Dal;
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;
    using CDP4Dal.DAL.ECSS1025AnnexC;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;
    using CDP4JsonSerializer;
    using NLog;
    using Operations;

    using EngineeringModelSetup = CDP4Common.SiteDirectoryData.EngineeringModelSetup;
    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// Provides the Data Access Layer for OCDT's WSP 
    /// </summary>
    [DalExport("OCDT WSP", "An OCDT WSP Data Access Layer", "1.0.0", DalType.Web)]
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47  
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class WspDal : Dal
    {
        /// <summary>
        /// The NLog Logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The <see cref="HttpClient"/> that is reused for each HTTP request by the current <see cref="Dal"/>.
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="WspDal"/> class.
        /// </summary>
        /// <exception cref="ActivationException">
        /// Thrown when the <see cref="IRestClientFactory"/> cannot be resolved
        /// </exception>
        public WspDal()
        {
            this.Serializer = new Cdp4JsonSerializer(this.MetaDataProvider, this.DalVersion);
            this.httpClient = new HttpClient();
        }

        /// <summary>
        /// Gets or sets the <see cref="Cdp4JsonSerializer"/>
        /// </summary>
        public Cdp4JsonSerializer Serializer { get; private set; }

        /// <summary>
        /// Gets the value indicating whether this <see cref="IDal"/> is read only
        /// </summary>
        public override bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/>.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <returns>
        /// A list of <see cref="CDP4Common.DTO.Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override async Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            Utils.AssertNotNull(operationContainer);

            var watch = Stopwatch.StartNew();

            var hasCopyValuesOperations = operationContainer.Operations.Any(op => CDP4Dal.Utils.IsCopyKeepOriginalValuesOperation(op.OperationKind));

            var modifier = new WspOperationModifier(this.Session);
            var copyHandler = new WspCopyOperationHandler(this.Session);

            copyHandler.ModifiedCopyOperation(operationContainer);
            modifier.ModifyOperationContainer(operationContainer);

            var invalidOperationKind = operationContainer.Operations.Any(operation => operation.OperationKind == OperationKind.Move || CDP4Dal.Utils.IsCopyOperation(operation.OperationKind));
            if (invalidOperationKind)
            {
                throw new InvalidOperationKindException("The WSP DAL does not support Copy or Move operations");
            }

            if (this.Credentials == null || this.Credentials.Uri == null)
            {
                throw new InvalidOperationException("The WSPDal is not open.");
            }
            
            var result = new List<Thing>();

            var requestBody = this.ConstructPostRequestBody(operationContainer);

            if (files != null && files.Any())
            {
                this.OperationContainerFileVerification(operationContainer, files);
            }

            if (requestBody == null)
            {
                throw new InvalidOperationException(string.Format("Attempt to serialize the operation container failed."));
            }

            var attribute = new QueryAttributes
            {
                RevisionNumber = operationContainer.TopContainerRevisionNumber
            };

            var postToken = this.RandomWebRequestToken();
            var resourcePath = $"{operationContainer.Context}{attribute}";
            var uriBuilder = new UriBuilder(this.Credentials.Uri) { Path = resourcePath };
            Logger.Debug("WSP POST: {0}", uriBuilder);
            
            Logger.Trace("POST JSON BODY {0} /r/n {1}", postToken, requestBody);

            Console.WriteLine(requestBody);

            var requestContent = this.CreateHttpContent(operationContainer, files);

            using (var httpResponseMessage = await this.httpClient.PostAsync(resourcePath, requestContent))
            {
                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var errorResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    var msg = $"The ECSS-E-TM-10-25A Annex C Services replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}: {errorResponse}";
                    Logger.Error(msg);
                    throw new DalWriteException(msg);
                }
                
                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    result.AddRange(this.Serializer.Deserialize(resultStream));

                    Guid iterationId;
                    if (this.TryExtractIterationIdfromUri(httpResponseMessage.RequestMessage.RequestUri, out iterationId))
                    {
                        this.SetIterationContainer(result, iterationId);
                    }

                    watch.Stop();
                    Logger.Info("JSON Deserializer completed in {0} ", watch.Elapsed);
                }
            }
            
            // Update value-sets
            if (hasCopyValuesOperations)
            {
                var valueSetCopyHandler = new WspValueSetOperationCreator(this.Session);
                var valueSetOperationContainer = valueSetCopyHandler.CreateValueSetsUpdateOperations(operationContainer.Context, result, copyHandler.CopyThingMap);
                var valueSetResult = await this.Write(valueSetOperationContainer);

                // merge dtos
                foreach (var valueSetDto in valueSetResult)
                {
                    var index = result.FindIndex(x => x.Iid == valueSetDto.Iid);
                    if (index >= 0)
                    {
                        result[index] = valueSetDto;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from all the <see cref="OperationContainer"/>s.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided list of <see cref="OperationContainer"/>s to write
        /// </param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainer, IEnumerable<string> files = null)
        {
            throw new NotSupportedException("Writing multiple OperationContainers to the data-source is not supported");
        }
        
        /// <summary>
        /// Reads the data related to the provided <see cref="Iteration"/> from the data-source
        /// </summary>
        /// <param name="iteration">
        /// An instance of <see cref="Iteration"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be used with the request
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/> that are contained by the provided <see cref="CDP4Common.EngineeringModelData.EngineeringModel"/> including the Reference-Data.
        /// All the <see cref="Thing"/>s that have been updated since the last read will be returned.
        /// </returns>
        public override async Task<IEnumerable<Thing>> Read(CDP4Common.DTO.Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            // Get the RequiredRdl to load
            var siteDirectory = this.Session.Assembler.RetrieveSiteDirectory();
            var iterationSetup = siteDirectory.Model.SelectMany(mod => mod.IterationSetup).SingleOrDefault(it => it.IterationIid == iteration.Iid);
            if (iterationSetup == null)
            {
                throw new InvalidOperationException("The Iteration to open does not have any associated IterationSetup.");
            }

            var modelSetup = (EngineeringModelSetup)iterationSetup.Container;
            var mrdl = modelSetup.RequiredRdl.SingleOrDefault();

            if (mrdl == null)
            {
                throw new InvalidOperationException("The model to open does not have a Required Reference-Data-Library.");
            }

            var mrdlDto = mrdl.ToDto();

            var tasks = new List<Task<IEnumerable<Thing>>>();
            tasks.Add(this.Read(mrdlDto, cancellationToken));
            tasks.Add(this.Read((Thing)iteration, cancellationToken));

            var returned = await Task.WhenAll(tasks);
            var returnedDto = returned.SelectMany(x => x.ToList()).ToList();

            return returnedDto;
        }

        /// <summary>
        /// Reads the data related to the provided <see cref="Thing"/> from the data-source
        /// </summary>
        /// <typeparam name="T">
        /// an type of <see cref="Thing"/>
        /// </typeparam>
        /// <param name="thing">
        /// An instance of <see cref="Thing"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The token.
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be passed along with the uri
        /// </param>
        /// <returns>
        /// a list of <see cref="Thing"/> that are contained by the provided <see cref="Thing"/> including the <see cref="Thing"/> itself
        /// </returns>
        public override async Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            if (this.Credentials == null || this.Credentials.Uri == null)
            {
                throw new InvalidOperationException("The WSPDal is not open.");
            }
            
            Utils.AssertNotNull(thing);

            var watch = Stopwatch.StartNew();

            var thingRoute = this.CleanUriFinalSlash(thing.Route);

            if (attributes == null)
            {
                var inlcudeReferenData = thing is ReferenceDataLibrary;

                attributes = this.GetIUriQueryAttribute(inlcudeReferenData);
            }

            var resourcePath = string.Format("{0}{1}", thingRoute, attributes.ToString());

            var readToken = this.RandomWebRequestToken();
            var uri = new UriBuilder(this.Credentials.Uri) { Path = resourcePath };
            Logger.Debug("WSP GET {0}: {1}", readToken, uri);

            using (var httpResponseMessage = await this.httpClient.GetAsync(resourcePath, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var msg = string.Format("The data-source replied with code {0}: {1}", httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);
                    Logger.Error(msg);
                    throw new DalReadException(msg);
                }
                
                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var returned = this.Serializer.Deserialize(resultStream);

                    Guid iterationId;
                    if (this.TryExtractIterationIdfromUri(httpResponseMessage.RequestMessage.RequestUri, out iterationId))
                    {
                        this.SetIterationContainer(returned, iterationId);
                    }

                    watch.Stop();
                    Logger.Info("JSON Deserializer completed in {0} ", watch.Elapsed);

                    return returned;
                }
            }
        }

        /// <summary>
        /// Creates the specified <see cref="Thing"/> on a data source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be created
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed. This includes the thing that was created.
        /// </returns>
        public override IEnumerable<Thing> Create<T>(T thing)
        {
            throw new NotSupportedException("The Create operation is not supported by the WSP.");
        }

        /// <summary>
        /// Performs an update to the <see cref="Thing"/> on the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be updated
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public override IEnumerable<Thing> Update<T>(T thing)
        {
            throw new NotSupportedException("The Update operation is not supported by the WSP.");
        }

        /// <summary>
        /// Deletes the specified <see cref="Thing"/> from the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be deleted
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public override IEnumerable<Thing> Delete<T>(T thing)
        {
            throw new NotSupportedException("The Delete operation is not supported by the WSP.");
        }

        /// <summary>
        /// Opens a connection to a data source <see cref="Uri"/>
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> that are used to connect to the data source such as username, password and <see cref="Uri"/>
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> of returned <see cref="Thing"/> DTOs.
        /// </returns>
        public override async Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken)
        {
            Utils.AssertNotNull(credentials);

            Utils.AssertNotNull(credentials.Uri);
            
            Utils.AssertUriIsHttpOrHttpsSchema(credentials.Uri);

            var queryAttributes = new QueryAttributes
            {
                Extent = ExtentQueryAttribute.deep,
                IncludeReferenceData = false
            };

            var resourcePath = string.Format("SiteDirectory{0}", queryAttributes);

            this.httpClient.BaseAddress = credentials.Uri;
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", credentials.UserName, credentials.Password))));

            var watch = Stopwatch.StartNew();
            var openToken = this.RandomWebRequestToken();
            var uriBuilder = new UriBuilder(credentials.Uri) { Path = resourcePath };
            Logger.Debug("WSP Open {0}: {1}", openToken, uriBuilder);

            using (var httpResponseMessage = await this.httpClient.GetAsync(resourcePath, HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken))
            {
                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var msg = string.Format("The data-source replied with code {0}: {1}", httpResponseMessage.StatusCode, httpResponseMessage.ReasonPhrase);
                    Logger.Error(msg);
                    throw new DalReadException(msg);
                }

                watch.Stop();
                Logger.Info("WSP DAL Open {0} completed in {1} ", openToken, watch.Elapsed);
                
                watch = Stopwatch.StartNew();

                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var returned = this.Serializer.Deserialize(resultStream);

                    watch.Stop();
                    Logger.Info("JSON Deserializer completed in {0} ", watch.Elapsed);

                    var returnedPerson = returned.OfType<CDP4Common.DTO.Person>().SingleOrDefault(x => x.ShortName == credentials.UserName);
                    if (returnedPerson == null)
                    {
                        throw new InvalidOperationException("User not found.");
                    }

                    this.Credentials = credentials;

                    return returned;
                }
            }
        }

        /// <summary>
        /// Creates <see cref="HttpContent"/> that is added to a POST request
        /// </summary>
        /// <param name="operationContainer">
        /// The <see cref="OperationContainer"/> that contains the <see cref="Operation"/>s that are part of 
        /// the transaction that is sent to the DAL
        /// </param>
        /// <param name="files">
        /// A list of file-paths that is used to construct the <see cref="MultipartFormDataContent"/>
        /// </param>
        /// <returns>
        /// An instance of <see cref="StringContent"/> or <see cref="MultipartFormDataContent"/>
        /// </returns>
        private HttpContent CreateHttpContent(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            var requestBody = this.ConstructPostRequestBody(operationContainer);
            var jsonContent = new StringContent(requestBody);
            jsonContent.Headers.Clear();
            jsonContent.Headers.Add("content-type", "application/json");

            if (files == null)
            {
                return jsonContent;
            }
            else
            {
                var multipartContent = new MultipartFormDataContent();
                multipartContent.Add(jsonContent);

                foreach (var file in files)
                {
                    var byteArray = System.IO.File.ReadAllBytes(file);
                    var fileContent = new ByteArrayContent(byteArray);
                    multipartContent.Add(fileContent);
                }

                return multipartContent;
            }
        }
        
        /// <summary>
        /// Closes the connection to an active WSP
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If the Data Access Layer is already closed 
        /// </exception>
        public override void Close()
        {
            if (this.Credentials == null)
            {
                throw new InvalidOperationException("An already closed Data Access Layer may not be closed again.");
            }
            
            this.CloseSession();
        }

        /// <summary>
        /// Assertion that the provided string is a valid <see cref="Uri"/> to connect to
        /// a data-source with the current implementation of the <see cref="IDal"/>
        /// </summary>
        /// <param name="uri">
        /// a string representing a <see cref="Uri"/>
        /// </param>
        /// <returns>
        /// true when valid, false when invalid
        /// </returns>
        public override bool IsValidUri(string uri)
        {
            try
            {
                var validUriAssertion = new Uri(uri);
                if (!(validUriAssertion.Scheme == Uri.UriSchemeHttp || validUriAssertion.Scheme == Uri.UriSchemeHttps))
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Constructs the JSON string containing the full POST body of the given <see cref="OperationContainer"/>
        /// </summary>
        /// /// <param name="operationContainer">
        /// The <see cref="OperationContainer"/>
        /// </param>
        /// <returns>The complete JSON string POST request body ready for the WSP</returns>
        public string ConstructPostRequestBody(OperationContainer operationContainer)
        {
            var postOperation = new WspPostOperation(this.MetaDataProvider);

            // add the simple operations to the WSP container
            foreach (var operation in operationContainer.Operations)
            {
                postOperation.ConstructFromOperation(operation);
            }

            string postBody;
            using (var stream = new MemoryStream())
            {
                this.Serializer.SerializeToStream(postOperation, stream);
                stream.Position = 0;

                var streamReader = new StreamReader(stream);
                postBody = streamReader.ReadToEnd();
            }

            return postBody;
        }

        /// <summary>
        /// gets the <see cref="QueryAttributes"/> associated to the <see cref="WspDal"/>
        /// </summary>
        /// <param name="includeReferenceData">
        /// Assertion to include reference data or not
        /// </param>
        /// <returns>
        /// the <see cref="QueryAttributes"/>
        /// </returns>
        private IQueryAttributes GetIUriQueryAttribute(bool includeReferenceData = false)
        {
            return includeReferenceData
                ? new QueryAttributes
                {
                    Extent = ExtentQueryAttribute.deep,
                    IncludeAllContainers = true,
                    IncludeReferenceData = true
                }
                : new QueryAttributes
                {
                    Extent = ExtentQueryAttribute.deep,
                    IncludeAllContainers = true
                };
        }

        /// <summary>
        /// Get a random string that is used to tag a POST so that for debugging purposes it is easy to find the POST and result of a POST
        /// </summary>
        /// <returns>
        /// a random string of 5 characters
        /// </returns>
        private string RandomWebRequestToken()
        {
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                // Buffer storage.
                byte[] data = new byte[4];
                cryptoServiceProvider.GetBytes(data);
                var result = BitConverter.ToString(data).Replace("-", "");
                return result;
            }
        }
    }
}
