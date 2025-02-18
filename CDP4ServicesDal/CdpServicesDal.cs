// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpServicesDal.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal
{
#if NETFRAMEWORK
    using System.ComponentModel.Composition;
#endif

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.Extensions;

    using CDP4DalCommon.Tasks;

    using CDP4Dal;
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;
    using CDP4Dal.DAL.ECSS1025AnnexC;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Authentication;

    using CDP4JsonSerializer;

    using CDP4MessagePackSerializer;

    using CDP4ServicesDal.Extensions;

    using Newtonsoft.Json;

    using NLog;

    using EngineeringModelSetup = CDP4Common.SiteDirectoryData.EngineeringModelSetup;
    using Thing = CDP4Common.DTO.Thing;
    using UriExtensions = CDP4Dal.UriExtensions;

    /// <summary>
    /// The purpose of the <see cref="CdpServicesDal"/> is to provide the Data Access Layer for CDP4 ECSS-E-TM-10-25
    /// Annex C, REST API
    /// </summary>
    [DalExport("COMET/CDP4 Services", "A COMET, or CDP4 Services Data Access Layer", "1.3.0", DalType.Web)]
#if NETFRAMEWORK
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
    public class CdpServicesDal : Dal
    {
        /// <summary>
        /// Gets the API route for the <see cref="CometTask" />
        /// </summary>
        public const string CometTaskRoute = "/tasks";

        /// <summary>
        /// The NLog Logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The <see cref="HttpClient"/> that is reused for each HTTP request by the current <see cref="Dal"/>.
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CdpServicesDal"/> class.
        /// </summary>
        public CdpServicesDal()
        {
            this.Cdp4JsonSerializer = new Cdp4JsonSerializer(this.MetaDataProvider, this.DalVersion);
            this.MessagePackSerializer = new MessagePackSerializer();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CdpServicesDal"/> class.
        /// </summary>
        /// <param name="httpClient">
        /// The (injected) <see cref="HttpClient"/>
        /// </param>
        public CdpServicesDal(HttpClient httpClient) : this()
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            this.httpClient = httpClient;
        }

        /// <summary>
        /// Gets the <see cref="Cdp4JsonSerializer"/>
        /// </summary>
        public Cdp4JsonSerializer Cdp4JsonSerializer { get; private set; }

        /// <summary>
        /// Gets the <see cref="MessagePackSerializer"/>
        /// </summary>
        public MessagePackSerializer MessagePackSerializer { get; private set; }

        /// <summary>
        /// Gets the value indicating whether this <see cref="IDal"/> is read only.
        /// </summary>
        public override bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">
        /// The files that are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override async Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            if (this.Credentials is not { IsFullyInitialized: true })
            {
                throw new InvalidOperationException("The CDP4 DAL is not open.");
            }

            if (operationContainer == null)
            {
                throw new ArgumentNullException(nameof(operationContainer), $"The {nameof(operationContainer)} may not be null");
            }

            if (!operationContainer.Operations.Any())
            {
                Logger.Debug("The operationContainer is empty, no round trip to the datasource is made");
                return Enumerable.Empty<Thing>();
            }

            var watch = Stopwatch.StartNew();

            var result = new List<Thing>();

            if (files != null && files.Any())
            {
                this.OperationContainerFileVerification(operationContainer, files);
            }

            var attribute = new QueryAttributes
            {
                RevisionNumber = operationContainer.TopContainerRevisionNumber
            };

            var postToken = operationContainer.Token;
            var resourcePath = $"{operationContainer.Context}{attribute}";

            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", postToken, resourcePath);
            Logger.Debug("CDP4 Services POST: {0} - {1}", postToken, uriBuilder);

            var requestContent = this.CreateHttpContent(postToken, operationContainer, files);

            var requestsw = Stopwatch.StartNew();

            using (var httpResponseMessage = await this.httpClient.PostAsync(resourcePath, requestContent))
            {
                Logger.Info("CDP4 Services responded in {0} [ms] to POST {1}", requestsw.ElapsedMilliseconds, postToken);
                requestsw.Stop();

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    await this.ProcessWriteException(httpResponseMessage);
                }

                this.ProcessHeaders(httpResponseMessage);

                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var deserializationWatch = Stopwatch.StartNew();

                    switch (this.QueryContentTypeKind(httpResponseMessage))
                    {
                        case ContentTypeKind.JSON:
                            Logger.Info("Deserializing JSON response");
                            result.AddRange(this.Cdp4JsonSerializer.Deserialize(resultStream));
                            Logger.Info("JSON Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                        case ContentTypeKind.MESSAGEPACK:
                            Logger.Info("Deserializing MESSAGEPACK response");
                            var cts = new CancellationTokenSource();
                            var things = await this.MessagePackSerializer.DeserializeAsync(resultStream, cts.Token);
                            result.AddRange(things);
                            Logger.Info("MESSAGEPACK Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                    }

                    deserializationWatch.Stop();

                    if (this.TryExtractIterationIdfromUri(httpResponseMessage.RequestMessage.RequestUri, out var iterationId))
                    {
                        this.SetIterationContainer(result, iterationId);
                    }
                }
            }

            watch.Stop();
            Logger.Info("Write Operation completed in {0} [ms]", watch.ElapsedMilliseconds);

            return result;
        }

        /// <summary>
        /// Handles the situation where a Write failed
        /// </summary>
        /// <param name="httpResponseMessage">The <see cref="HttpResponseMessage"/></param>
        /// <exception cref="DalWriteException">Always throws a <see cref="DalWriteException"/></exception>
        /// <returns>An awaitable <see cref="Task"/></returns>
        private async Task ProcessWriteException(HttpResponseMessage httpResponseMessage)
        {
            var errorResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var msg = $"The CDP4 Services replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}: {errorResponse}";

            if (httpResponseMessage.Headers.Contains(Headers.CDPErrorTag))
            {
                var cdpErrorTag = httpResponseMessage.Headers.GetValues(Headers.CDPErrorTag).FirstOrDefault() ?? string.Empty;

                if (cdpErrorTag != null)
                {
                    Logger.Error($"{Headers.CDPErrorTag} {cdpErrorTag} - {msg}");
                    throw new DalWriteException(msg) { CDPErrorTag = cdpErrorTag };
                }
            }

            Logger.Error(msg);
            throw new DalWriteException(msg);
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously for a possible long running task.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="waitTime">The maximum time that we allow the server before responding. If the write operation takes more time
        /// than the provided <paramref name="waitTime"/>, a <see cref="CometTask"/></param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        /// <exception cref="InvalidOperationException">If the CDP4 DAL is not open</exception>
        /// <exception cref="ArgumentNullException">If the provided <paramref name="operationContainer"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the provided <paramref name="waitTime"/> is lower than 1</exception>
        public override async Task<LongRunningTaskResult> Write(OperationContainer operationContainer, int waitTime, IEnumerable<string> files = null)
        {
            if (this.Credentials is not { IsFullyInitialized: true })
            {
                throw new InvalidOperationException("The CDP4 DAL is not open.");
            }

            VerifyOperationContainerNotNull(operationContainer);
            VerifyWaitTimeNotLowerThanOne(waitTime);

            var watch = Stopwatch.StartNew();

            LongRunningTaskResult result = default;

            if (files != null && files.Any())
            {
                this.OperationContainerFileVerification(operationContainer, files);
            }

            var attribute = new QueryAttributes
            {
                RevisionNumber = operationContainer.TopContainerRevisionNumber,
                WaitTime = waitTime
            };

            var postToken = operationContainer.Token;
            var resourcePath = $"{operationContainer.Context}{attribute}";

            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", postToken, resourcePath);
            Logger.Debug("CDP4 Services POST: {0} - {1}", postToken, uriBuilder);

            var requestContent = this.CreateHttpContent(postToken, operationContainer, files);

            var requestsw = Stopwatch.StartNew();

            using (var httpResponseMessage = await this.httpClient.PostAsync(resourcePath, requestContent))
            {
                Logger.Info("CDP4 Services responded in {0} [ms] to POST {1}", requestsw.ElapsedMilliseconds, postToken);
                requestsw.Stop();

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    await this.ProcessWriteException(httpResponseMessage);
                }

                this.ProcessHeaders(httpResponseMessage);

                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var deserializationWatch = Stopwatch.StartNew();
                    var contentTypeKind = this.QueryContentTypeKind(httpResponseMessage);

                    switch (contentTypeKind)
                    {
                        case ContentTypeKind.JSON:
                            Logger.Info("Deserializing JSON response");
                            result = this.ExtractResultFromStream(resultStream);
                            Logger.Info("JSON Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                        case ContentTypeKind.MESSAGEPACK:
                            throw new NotSupportedException("Long running task not supported with MESSAGEPACK");
                        default:
                            throw new InvalidOperationException($"ContentTypeKind {contentTypeKind} not supported");
                    }

                    deserializationWatch.Stop();

                    if (!result.IsWaitTimeReached && this.TryExtractIterationIdfromUri(httpResponseMessage.RequestMessage.RequestUri, out var iterationId))
                    {
                        this.SetIterationContainer(result.Things, iterationId);
                    }
                }
            }

            watch.Stop();
            Logger.Info("Write Operation completed in {0} [ms]", watch.ElapsedMilliseconds);

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
        /// Reads the data related to the provided <see cref="CDP4Common.EngineeringModelData.Iteration"/> from the data-source
        /// </summary>
        /// <param name="iteration">
        /// An instance of <see cref="CDP4Common.EngineeringModelData.Iteration"/> that needs to be read from the data-source
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
        /// <exception cref="InvalidOperationException">
        /// Thrown when the <see cref="Session"/> property has not been set
        /// </exception>
        public override async Task<IEnumerable<Thing>> Read(CDP4Common.DTO.Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            if (this.Session == null)
            {
                throw new InvalidOperationException("The Session may not be null and must be set prior to reading an Iteration");
            }

            // Get the RequiredRdl to load
            var siteDirectory = this.Session.Assembler.RetrieveSiteDirectory();
            var iterationSetup = siteDirectory.Model.SelectMany(mod => mod.IterationSetup).SingleOrDefault(it => it.IterationIid == iteration.Iid);

            if (iterationSetup == null)
            {
                throw new InvalidOperationException("The Iteration to open does not have any associated IterationSetup.");
            }

            var modelSetup = (EngineeringModelSetup)iterationSetup.Container;
            var modelReferenceDataLibrary = modelSetup.RequiredRdl.SingleOrDefault();

            if (modelReferenceDataLibrary == null)
            {
                throw new InvalidOperationException("The model to open does not have a Required Reference-Data-Library.");
            }

            var modelReferenceDataLibraryDto = modelReferenceDataLibrary.ToDto();

            var result = new List<Thing>();
            var referenceData = await this.Read(modelReferenceDataLibraryDto, cancellationToken);
            result.AddRange(referenceData);
            var engineeringModelData = await this.Read((Thing)iteration, cancellationToken);
            result.AddRange(engineeringModelData);
            return result;
        }

        /// <summary>
        /// Reads the <see cref="EngineeringModel"/> instances from the data-source
        /// </summary>
        /// <param name="engineeringModels">
        /// The <see cref="EngineeringModel"/>s that needs to be read from the data-source, in case the list is empty
        /// all the <see cref="EngineeringModel"/>s will be read
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A list of <see cref="EngineeringModel"/>s
        /// </returns>
        /// <remarks>
        /// Only those <see cref="EngineeringModel"/>s are retunred that the <see cref="Person"/> is a <see cref="Participant"/> in
        /// </remarks>
        public override async Task<IEnumerable<EngineeringModel>> Read(IEnumerable<CDP4Common.DTO.EngineeringModel> engineeringModels, CancellationToken cancellationToken)
        {
            if (this.Session == null)
            {
                throw new InvalidOperationException("The Session may not be null and must be set prior to reading the EngineeringModels");
            }

            if (this.Credentials is not { IsFullyInitialized: true })
            {
                throw new InvalidOperationException("The CDP4-COMET DAL is not open.");
            }

            if (engineeringModels == null)
            {
                throw new ArgumentNullException(nameof(engineeringModels), $"The {nameof(engineeringModels)} may not be null");
            }

            var resourcePath = !engineeringModels.Any() ? "EngineeringModel/*" : $"EngineeringModel/{engineeringModels.Select(x => x.Iid).ToList().ToShortGuidArray()}";

            var readToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();
            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", readToken, resourcePath);
            Logger.Debug("CDP4Services GET {0}: {1}", readToken, uriBuilder);

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourcePath);
            requestMessage.Headers.Add(Headers.CDPToken, readToken);

            var requestsw = Stopwatch.StartNew();

            using (var httpResponseMessage = await this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                Logger.Info("CDP4 Services responded in {0} [ms] to GET {1}", requestsw.ElapsedMilliseconds, readToken);
                requestsw.Stop();

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var msg = $"The data-source replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}";
                    Logger.Error(msg);
                    throw new DalReadException(msg);
                }

                this.ProcessHeaders(httpResponseMessage);

                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var deserializationWatch = Stopwatch.StartNew();

                    IEnumerable<Thing> returned = new List<Thing>();

                    switch (this.QueryContentTypeKind(httpResponseMessage))
                    {
                        case ContentTypeKind.JSON:
                            Logger.Info("Deserializing JSON response");
                            returned = this.Cdp4JsonSerializer.Deserialize(resultStream);
                            Logger.Info("JSON Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                        case ContentTypeKind.MESSAGEPACK:
                            Logger.Info("Deserializing MESSAGEPACK response");
                            returned = await this.MessagePackSerializer.DeserializeAsync(resultStream, cancellationToken);
                            Logger.Info("MESSAGEPACK Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                    }

                    deserializationWatch.Stop();

                    return returned.OfType<EngineeringModel>();
                }
            }
        }

        /// <summary>
        /// Reads a physical file from a DataStore
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> that has a </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <returns>an await-able <see cref="Task"/> that returns a <see cref="byte"/> array.</returns>
        public override async Task<byte[]> ReadFile(Thing thing, CancellationToken cancellationToken)
        {
            if (this.Credentials is not { IsFullyInitialized: true })
            {
                throw new InvalidOperationException("The CDP4 DAL is not open.");
            }

            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var watch = Stopwatch.StartNew();

            var thingRoute = this.CleanUriFinalSlash(thing.Route);

            var resourcePath = $"{thingRoute}?includeFileData=true";

            var readToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();
            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", readToken, resourcePath);
            Logger.Debug("CDP4Services GET {0}: {1}", readToken, uriBuilder);

            var requestsw = Stopwatch.StartNew();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourcePath);
            requestMessage.Headers.Add(Headers.CDPToken, readToken);

            using (var httpResponseMessage = await this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                Logger.Info("CDP4 Services responded in {0} [ms] to GET {1}", requestsw.ElapsedMilliseconds, readToken);
                requestsw.Stop();

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var msg = $"The data-source replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}";
                    Logger.Error(msg);
                    throw new DalReadException(msg);
                }

                this.ProcessHeaders(httpResponseMessage, true);

                cancellationToken.ThrowIfCancellationRequested();

                var multipartContent = await httpResponseMessage.Content.ReadAsMultipartAsync(cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                var returned = await multipartContent.Contents[1].ReadAsByteArrayAsync();

                cancellationToken.ThrowIfCancellationRequested();

                watch.Stop();
                Logger.Info("JSON Deserializer completed in {0} [ms]", watch.ElapsedMilliseconds);

                return returned;
            }
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
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be passed along with the request
        /// </param>
        /// <returns>
        /// a list of <see cref="Thing"/> that are contained by the provided <see cref="Thing"/> including the <see cref="Thing"/> itself
        /// </returns>
        public override async Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            if (this.Credentials is not { IsFullyInitialized: true })
            {
                throw new InvalidOperationException("The CDP4 DAL is not open.");
            }

            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            if (attributes == null)
            {
                var includeReferenData = thing is ReferenceDataLibrary;

                attributes = GetIUriQueryAttribute(includeReferenData);
            }

            var thingRoute = this.CleanUriFinalSlash(thing.Route);

            var resourcePath = $"{thingRoute}{attributes?.ToString()}";

            var readToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();
            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", readToken, resourcePath);
            Logger.Debug("CDP4Services GET {0}: {1}", readToken, uriBuilder);

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourcePath);
            requestMessage.Headers.Add(Headers.CDPToken, readToken);

            var requestsw = Stopwatch.StartNew();

            using (var httpResponseMessage = await this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                Logger.Info("CDP4 Services responded in {0} [ms] to GET {1}", requestsw.ElapsedMilliseconds, readToken);
                requestsw.Stop();

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var msg = $"The data-source replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}";
                    Logger.Error(msg);
                    throw new DalReadException(msg);
                }

                this.ProcessHeaders(httpResponseMessage);

                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var deserializationWatch = Stopwatch.StartNew();

                    IEnumerable<Thing> returned = new List<Thing>();

                    switch (this.QueryContentTypeKind(httpResponseMessage))
                    {
                        case ContentTypeKind.JSON:
                            Logger.Info("Deserializing JSON response");
                            returned = this.Cdp4JsonSerializer.Deserialize(resultStream);
                            Logger.Info("JSON Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                        case ContentTypeKind.MESSAGEPACK:
                            Logger.Info("Deserializing MESSAGEPACK response");
                            returned = await this.MessagePackSerializer.DeserializeAsync(resultStream, cancellationToken);
                            Logger.Info("MESSAGEPACK Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                    }

                    deserializationWatch.Stop();

                    if (this.TryExtractIterationIdfromUri(httpResponseMessage.RequestMessage.RequestUri, out var iterationId))
                    {
                        this.SetIterationContainer(returned, iterationId);
                    }

                    return returned;
                }
            }
        }

        /// <summary>
        /// Reads the <see cref="CometTask" /> identified by the provided <see cref="Guid" />
        /// </summary>
        /// <param name="id">The <see cref="CometTask" /> identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>The read <see cref="CometTask" /></returns>
        public override async Task<CometTask> ReadCometTask(Guid id, CancellationToken cancellationToken)
        {
            var resourcePath = $"{CometTaskRoute}/{id}";

            var readToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();
            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", readToken, resourcePath);
            Logger.Debug("CDP4Services GET {0}: {1}", readToken, uriBuilder);

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourcePath);
            requestMessage.Headers.Add(Headers.CDPToken, readToken);

            var requestsw = Stopwatch.StartNew();

            using (var httpResponseMessage = await this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                Logger.Info("CDP4 Services responded in {0} [ms] to GET {1}", requestsw.ElapsedMilliseconds, readToken);
                requestsw.Stop();

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var msg = $"The data-source replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}";
                    Logger.Error(msg);
                    throw new DalReadException(msg);
                }

                this.ProcessHeaders(httpResponseMessage);

                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var deserializationWatch = Stopwatch.StartNew();

                    CometTask returned;
                    var contentTypeKind = this.QueryContentTypeKind(httpResponseMessage);

                    switch (contentTypeKind)
                    {
                        case ContentTypeKind.JSON:
                            Logger.Info("Deserializing JSON response");
                            returned = this.Cdp4JsonSerializer.Deserialize<CometTask>(resultStream);
                            Logger.Info("JSON Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                        case ContentTypeKind.MESSAGEPACK:
                            throw new NotSupportedException("Read CometTask by id not supported with MESSAGEPACK");
                        default:
                            throw new InvalidOperationException($"ContentTypeKind {contentTypeKind} not supported");
                    }

                    deserializationWatch.Stop();

                    return returned;
                }
            }
        }

        /// <summary>
        /// Reads all <see cref="CometTask" /> available for the current logged <see cref="CDP4Common.DTO.Person" />
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>All available <see cref="CometTask" /></returns>
        public override async Task<IEnumerable<CometTask>> ReadCometTasks(CancellationToken cancellationToken)
        {
            var resourcePath = CometTaskRoute;

            var readToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();
            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", readToken, resourcePath);
            Logger.Debug("CDP4Services GET {0}: {1}", readToken, uriBuilder);

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourcePath);
            requestMessage.Headers.Add(Headers.CDPToken, readToken);

            var requestsw = Stopwatch.StartNew();

            using (var httpResponseMessage = await this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken))
            {
                Logger.Info("CDP4 Services responded in {0} [ms] to GET {1}", requestsw.ElapsedMilliseconds, readToken);
                requestsw.Stop();

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var msg = $"The data-source replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}";
                    Logger.Error(msg);
                    throw new DalReadException(msg);
                }

                this.ProcessHeaders(httpResponseMessage);

                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var deserializationWatch = Stopwatch.StartNew();

                    IEnumerable<CometTask> returned;
                    var contentTypeKind = this.QueryContentTypeKind(httpResponseMessage);

                    switch (contentTypeKind)
                    {
                        case ContentTypeKind.JSON:
                            Logger.Info("Deserializing JSON response");
                            returned = this.Cdp4JsonSerializer.Deserialize<IEnumerable<CometTask>>(resultStream);
                            Logger.Info("JSON Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                        case ContentTypeKind.MESSAGEPACK:
                            throw new NotSupportedException("Read all CometTask not supported with MESSAGEPACK");
                        default:
                            throw new InvalidOperationException($"ContentTypeKind {contentTypeKind} not supported");
                    }

                    deserializationWatch.Stop();

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Opens a connection to a data source <see cref="Uri"/> specified by the provided <see cref="Credentials"/>
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Dal.Credentials"/> that are used to connect to the data source such as username, password and <see cref="Uri"/>
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> that the services return when connecting to the <see cref="CDP4Common.SiteDirectoryData.SiteDirectory"/>.
        /// </returns>
        public override async Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials), $"The {nameof(credentials)} may not be null");
            }

            if (credentials.Uri == null)
            {
                throw new ArgumentNullException(nameof(credentials.Uri), $"The Credentials URI may not be null");
            }

            if (!credentials.IsFullyInitialized)
            {
                throw new ArgumentException("The Credentials is not be fully initialized");
            }

            UriExtensions.AssertUriIsHttpOrHttpsSchema(credentials.Uri);

            var queryAttributes = new QueryAttributes
            {
                Extent = ExtentQueryAttribute.deep,
                IncludeReferenceData = false
            };

            var resourcePath = $"SiteDirectory{queryAttributes}";

            var openToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();

            this.httpClient = this.CreateHttpClient(credentials, this.httpClient);
            this.ApplyAuthenticationCredentials(credentials);
        
            var watch = Stopwatch.StartNew();

            var uriBuilder = this.GetUriBuilder(credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", openToken, resourcePath);
            Logger.Debug("CDP4Services Open {0}: {1}", openToken, uriBuilder);

            var requestsw = Stopwatch.StartNew();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourcePath);
            requestMessage.Headers.Add(Headers.CDPToken, openToken);

            using (var httpResponseMessage = await this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken))
            {
                Logger.Info("CDP4 Services responded in {0} [ms] to Open {1}", requestsw.ElapsedMilliseconds, openToken);
                requestsw.Stop();

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                {
                    var msg = $"The data-source replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}";
                    Logger.Error(msg);
                    throw new DalReadException(msg);
                }

                watch.Stop();
                Logger.Info("CDP4Services Open {0}: {1} completed in {2} [ms]", openToken, uriBuilder, watch.ElapsedMilliseconds);

                this.ProcessHeaders(httpResponseMessage);

                using (var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync())
                {
                    var deserializationWatch = Stopwatch.StartNew();

                    IEnumerable<Thing> returned = new List<Thing>();

                    switch (this.QueryContentTypeKind(httpResponseMessage))
                    {
                        case ContentTypeKind.JSON:
                            Logger.Info("Deserializing JSON response");
                            returned = this.Cdp4JsonSerializer.Deserialize(resultStream);
                            Logger.Info("JSON Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                        case ContentTypeKind.MESSAGEPACK:
                            Logger.Info("Deserializing MESSAGEPACK response");
                            returned = await this.MessagePackSerializer.DeserializeAsync(resultStream, cancellationToken);
                            Logger.Info("MESSAGEPACK Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                            break;
                    }

                    deserializationWatch.Stop();

                    if (string.IsNullOrEmpty(credentials.UserName))
                    {
                        credentials.UserName = await this.QueryAuthenticatedUserName(cancellationToken);
                    }

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
        /// Applies Authentication information based on the <see cref="Credentials" /> 
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials"/></param>
        public override void ApplyAuthenticationCredentials(Credentials credentials)
        {
            if (this.httpClient == null)
            {
                throw new InvalidOperationException("Connection to datasource not established");
            }

            if (credentials is not { IsFullyInitialized: true })
            {
                throw new InvalidOperationException("Credentials not fully initialized");
            }
            
            this.httpClient.SetAuthorizationHeader(credentials);
        }

        /// <summary>
        /// Initializes this <see cref="CdpServicesDal" /> with created <see cref="Credentials" />. 
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials"/></param>
        /// <remarks>To be used in case of multiple-step authentication, requires to be able to support multiple Authentication scheme</remarks>
        public override void InitializeDalCredentials(Credentials credentials)
        {
            base.InitializeDalCredentials(credentials);

            try
            {
                credentials.Uri.AssertUriIsHttpOrHttpsSchema();
            }
            catch (ArgumentException)
            {
                this.Credentials = null;
                throw;
            }
        }

        /// <summary>
        /// Provides login capabitilities against data-source, based on provided <paramref name="userName"/> and <paramref name="password"/>. 
        /// </summary>
        /// <param name="userName">The username that should be used for authentication</param>
        /// <param name="password">The password that should be used for authentication</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <remarks>This method should be used when the CDP4-COMET WebServices provides LocalJwtBearer authentication flow</remarks>
        public override async Task Login(string userName, string password, CancellationToken cancellationToken)
        {
            if (this.Credentials == null || this.Credentials.Uri == null)
            {
                throw new InvalidOperationException("The Credentials may not be null, this service should have been initialized before");
            }

            var temporaryClient = this.CreateHttpClient(this.Credentials, null);

            var resourcePath = "login";
            var watch = Stopwatch.StartNew();
            var loginToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();

            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", loginToken, resourcePath);
            Logger.Debug("CDP4Services Open {0}: {1}", loginToken, uriBuilder);

            var requestsw = Stopwatch.StartNew();

            var loginUser = new LoginUser()
            {
                Password = password,
                UserName = userName
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, resourcePath);
            requestMessage.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(loginUser), System.Text.Encoding.UTF8, "application/json");
            requestMessage.Headers.Add(Headers.CDPToken, loginToken);
            using var httpResponseMessage = await temporaryClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken);

            Logger.Info("CDP4 Services responded in {0} [ms] to Login {1}", requestsw.ElapsedMilliseconds, loginToken);
            requestsw.Stop();

            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                var msg = $"The data-source replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}";
                Logger.Error(msg);
                throw new DalReadException(msg);
            }

            watch.Stop();
            Logger.Info("CDP4Services Login {0}: {1} completed in {2} [ms]", loginToken, uriBuilder, watch.ElapsedMilliseconds);

            using var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var deserializationWatch = Stopwatch.StartNew();
            string returnedToken = null;

            switch (this.QueryContentTypeKind(httpResponseMessage))
            {
                case ContentTypeKind.JSON:
                    Logger.Info("Deserializing JSON response");
                    returnedToken = await System.Text.Json.JsonSerializer.DeserializeAsync<string>(resultStream, cancellationToken: cancellationToken);
                    Logger.Info("JSON Deserializer completed in {0} [ms]", deserializationWatch.ElapsedMilliseconds);
                    break;
                case ContentTypeKind.MESSAGEPACK:
                    throw new InvalidOperationException("No support of JWT token via MessagePack available");
            }

            deserializationWatch.Stop();
            this.Credentials.ProvideUserCredentials(userName, password, AuthenticationSchemeKind.LocalJwtBearer);
            this.Credentials.ProvideUserToken(returnedToken, AuthenticationSchemeKind.LocalJwtBearer);
        }

        /// <summary>
        /// Cherry pick <see cref="Thing"/>s contained into an <see cref="Iteration"/> that match provided <see cref="Category"/> and <see cref="ClassKind"/>
        /// filter
        /// </summary>
        /// <param name="engineeringModelId">The <see cref="Guid"/> of the <see cref="EngineeringModel"/></param>
        /// <param name="iterationId">The <see cref="Guid"/> of the <see cref="Iteration"/></param>
        /// <param name="classKinds">A collection of <see cref="ClassKind"/></param>
        /// <param name="categoriesId">A collection of <see cref="Category"/> <see cref="Guid"/>s</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{T}" /> of type <see cref="IEnumerable{T}"/> of read <see cref="Thing" /></returns>
        public override async Task<IEnumerable<Thing>> CherryPick(Guid engineeringModelId, Guid iterationId, IEnumerable<ClassKind> classKinds,
            IEnumerable<Guid> categoriesId, CancellationToken cancellationToken)
        {
            var attributes = new QueryAttributes()
            {
                CategoriesData = categoriesId,
                ClassKinds = classKinds,
                CherryPick = true
            };

            Thing iteration = new Iteration() { Iid = iterationId };
            iteration.AddContainer(ClassKind.EngineeringModel, engineeringModelId);
            return await this.Read(iteration, cancellationToken, attributes);
        }

        /// <summary>
        /// Create a new <see cref="HttpClient"/>
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> used to set the connection and authentication settings as well as the proxy server settings
        /// </param>
        /// <param name="injectedClient">
        /// The injected <see cref="HttpClient"/> that will be used to created the returned <see cref="HttpClient"/>
        /// </param>
        /// <returns>
        /// An instance of <see cref="HttpClient"/> with the DefaultRequestHeaders set
        /// </returns>
        private HttpClient CreateHttpClient(Credentials credentials, HttpClient injectedClient)
        {
            if (injectedClient != null && credentials.FullTrust)
            {
                throw new ArgumentException("When the fullTrust is true and an injectedClient clients is used this is not supported. The trus all SSL settings need to be configured on the injected HttpClient");
            }

            HttpClient result;

            if (credentials.ProxySettings != null && injectedClient != null)
            {
                throw new ArgumentException($"The {nameof(credentials)} and {nameof(injectedClient)} are both not null, this is not allowed");
            }

            if (credentials.ProxySettings == null)
            {
                Logger.Debug("creating HttpClient without proxy");

                if (injectedClient == null)
                {
                    if (credentials.FullTrust)
                    {
                        var httpClientHandler = new HttpClientHandler();
                        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                        result = new HttpClient(httpClientHandler);
                    }
                    else
                    {
                        result = new HttpClient();
                    }
                }
                else
                {
                    result = injectedClient;
                }
            }
            else
            {
                Logger.Debug("creating HttpClient with proxy: {0}", credentials.ProxySettings.Address);

                var proxy = new WebProxy(credentials.ProxySettings.Address);

                if (!string.IsNullOrEmpty(credentials.ProxySettings.UserName))
                {
                    var proxyCredential = new NetworkCredential(credentials.ProxySettings.UserName, credentials.ProxySettings.Password);
                    proxy.Credentials = proxyCredential;
                }

                var httpClientHandler = new HttpClientHandler()
                {
                    Proxy = proxy,
                    UseProxy = true
                };

                if (credentials.FullTrust)
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                }

                result = new HttpClient(httpClientHandler);
            }

            result.BaseAddress = credentials.Uri;
            result.DefaultRequestHeaders.Accept.Clear();
            result.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            result.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/msgpack"));
            result.DefaultRequestHeaders.Add(Headers.AcceptCdpVersion, Headers.AcceptCdpVersionValue);
            result.DefaultRequestHeaders.Add("User-Agent", "CDP4 (ECSS-E-TM-10-25 Annex C.2) CDPServicesDal");

            return result;
        }

        /// <summary>
        /// Creates <see cref="HttpContent"/> that is added to a POST request
        /// </summary>
        /// <param name="token">
        /// The POST token that is used to track the POST request in a logger
        /// </param>
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
        private HttpContent CreateHttpContent(string token, OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            var stream = new MemoryStream();
            this.ConstructPostRequestBodyStream(token, operationContainer, stream);
            var jsonContent = new StreamContent(stream);
            jsonContent.Headers.Add(Headers.ContentType, "application/json");
            jsonContent.Headers.Add(Headers.CDPToken, token);

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
                    var fileName = Path.GetFileName(file);

                    using (var filestream = System.IO.File.OpenRead(file))
                    {
                        var contentStream = new MemoryStream();
                        filestream.CopyTo(contentStream);
                        contentStream.Position = 0;

                        var fileContent = new StreamContent(contentStream);
                        fileContent.Headers.Add("Content-Type", "application/octet-stream");
                        fileContent.Headers.Add("Content-Disposition", $"attachment; filename=\"{fileName}\"");
                        multipartContent.Add(fileContent);
                    }
                }

                return multipartContent;
            }
        }

        /// <summary>
        /// Constructs the JSON stream containing the full POST body of the given <see cref="OperationContainer"/>
        /// </summary>
        /// <param name="token">
        /// The POST token that is used to track the POST request in a logger
        /// </param>
        /// <param name="operationContainer">
        /// The <see cref="OperationContainer"/> that is serialized to a JSON stream
        /// </param>
        /// <param name="outputStream">
        /// The stream to which is written
        /// </param>
        internal void ConstructPostRequestBodyStream(string token, OperationContainer operationContainer, Stream outputStream)
        {
            var postOperation = new CdpPostOperation(this.MetaDataProvider, this.Session);

            // add the simple operations to the WSP container
            foreach (var operation in operationContainer.Operations)
            {
                postOperation.ConstructFromOperation(operation);
            }

            this.Cdp4JsonSerializer.SerializeToStream(postOperation, outputStream);
            outputStream.Position = 0;

            if (Logger.IsTraceEnabled)
            {
                using (var memoryStream = new MemoryStream())
                {
                    outputStream.CopyTo(memoryStream);
                    memoryStream.Position = 0;

                    using (var streamReader = new StreamReader(memoryStream))
                    {
                        var postBody = streamReader.ReadToEnd();
                        Logger.Trace("POST JSON BODY {0} /r/n {1}", token, postBody);
                    }
                }

                outputStream.Position = 0;
            }
        }

        /// <summary>
        /// process the response to verify that the required headers are available
        /// </summary>
        /// <param name="httpResponseMessage">
        /// The <see cref="HttpResponseMessage"/> that is to be verified
        /// </param>
        /// <param name="allowMultiPart">Optional <see cref="bool"/> indicating if multipart/mixed content is allowed in the contentheader</param>
        private void ProcessHeaders(HttpResponseMessage httpResponseMessage, bool allowMultiPart = false)
        {
            var responseHeaders = httpResponseMessage.Headers;

            var cdpServerHeader = responseHeaders.SingleOrDefault(h => h.Key.ToLower(CultureInfo.InvariantCulture) == Headers.CDPServer.ToLower(CultureInfo.InvariantCulture));

            if (cdpServerHeader.Value == null)
            {
                throw new HeaderException($"Header {Headers.CDPServer} not found");
            }

            var cdpCommonHeader = responseHeaders.SingleOrDefault(h => h.Key.ToLower(CultureInfo.InvariantCulture) == Headers.CDPCommon.ToLower(CultureInfo.InvariantCulture));

            if (cdpCommonHeader.Value == null)
            {
                throw new HeaderException($"Header {Headers.CDPCommon} not found");
            }

            var contentHeaders = httpResponseMessage.Content.Headers;

            var mediaTypeHeader = contentHeaders.SingleOrDefault(h => h.Key.ToLower(CultureInfo.InvariantCulture) == Headers.ContentType.ToLower(CultureInfo.InvariantCulture));

            if (mediaTypeHeader.Value == null)
            {
                throw new HeaderException($"Header {Headers.ContentType} not found");
            }

            var headerString = Convert.ToString(mediaTypeHeader.Value.FirstOrDefault()).ToLower(CultureInfo.InvariantCulture);

            if (!this.IsCDP4ContentType(headerString, allowMultiPart))
            {
                throw new HeaderException($"Header Media-Type has incompatible value: {mediaTypeHeader.Value} ");
            }
        }

        /// <summary>
        /// Checks message content header for CDP4 tags an compatiple content-types
        /// </summary>
        /// <param name="headerString">The header <see cref="string"/></param>
        /// <param name="allowMultiPart">Indication if multipart Content-Type is allowed</param>
        /// <returns>true if a CDP4 content type is found, otherwise false</returns>
        private bool IsCDP4ContentType(string headerString, bool allowMultiPart)
        {
            var headerArray = headerString
                .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToArray();

            if (!headerArray.Contains("ecss-e-tm-10-25") || !headerArray.Contains("version=1.0.0"))
            {
                return false;
            }

            if (headerArray.Contains("application/json"))
            {
                return true;
            }

            if (headerArray.Contains("application/msgpack"))
            {
                return true;
            }

            if (!allowMultiPart || !headerArray.Contains("multipart/mixed"))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Queries the Content-Type from the <see cref="HttpResponseMessage"/>
        /// </summary>
        /// <param name="httpResponseMessage">
        /// The subject <see cref="HttpResponseMessage"/>
        /// </param>
        /// <returns>
        /// returns a <see cref="ContentTypeKind"/> 
        /// </returns>
        /// <exception cref="HeaderException">
        /// thrown when the Content-Type is not supported
        /// </exception>
        private ContentTypeKind QueryContentTypeKind(HttpResponseMessage httpResponseMessage)
        {
            var contentHeaders = httpResponseMessage.Content.Headers;

            var mediaTypeHeader = contentHeaders.SingleOrDefault(h => h.Key.ToLower(CultureInfo.InvariantCulture) == Headers.ContentType.ToLower(CultureInfo.InvariantCulture));

            if (mediaTypeHeader.Value == null)
            {
                throw new HeaderException($"Header {Headers.ContentType} not found");
            }

            var headerString = Convert.ToString(mediaTypeHeader.Value.FirstOrDefault()).ToLower(CultureInfo.InvariantCulture);

            var headerArray = headerString
                .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim()).ToArray();

            if (headerArray.Contains("application/json"))
            {
                return ContentTypeKind.JSON;
            }

            if (headerArray.Contains("application/msgpack"))
            {
                return ContentTypeKind.MESSAGEPACK;
            }

            throw new HeaderException($"Header Media-Type has incompatible value: {mediaTypeHeader.Value} ");
        }

        /// <summary>
        /// Close the <see cref="CdpServicesDal"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// If the Data Access Layer is already closed 
        /// </exception>
        /// <remarks>
        /// Disposes of the underlying <see cref="HttpClient"/>
        /// </remarks>
        public override void Close()
        {
            if (this.Credentials == null)
            {
                throw new InvalidOperationException("An already closed Data Access Layer may not be closed again.");
            }

            if (this.httpClient != null)
            {
                this.httpClient.Dispose();
                this.httpClient = null;
            }

            this.CloseSession();
        }

        /// <summary>
        /// Assertion that the provided string is a valid <see cref="Uri"/> to connect to
        /// a data-source with the current implementation of the <see cref="IDal"/>.
        /// </summary>
        /// <param name="uri">
        /// a string representing a <see cref="Uri"/>.
        /// </param>
        /// <returns>
        /// true when valid, false when invalid.
        /// </returns>
        /// <remarks>
        /// Only HTTP and HTTPS are valid.
        /// </remarks>
        public override bool IsValidUri(string uri)
        {
            try
            {
                var validUriAssertion = new Uri(uri);
                validUriAssertion.AssertUriIsHttpOrHttpsSchema();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Requests to retrieve all available <see cref="AuthenticationSchemeKind" /> available on the datasource
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>An awaitable <see cref="Task{TResult}"/> that contains the value of the queried <see cref="AuthenticationSchemeResponse" /></returns>
        public override async Task<AuthenticationSchemeResponse> RequestAvailableAuthenticationScheme(CancellationToken cancellationToken)
        {
            if (this.Credentials == null || this.Credentials.Uri == null)
            {
                throw new InvalidOperationException("The CDP4 DAL URI not specified.");
            }

            var temporaryHttpClient = this.CreateHttpClient(this.Credentials, null);
            var watch = Stopwatch.StartNew();

            var resourcePath = "auth/schemes";

            var readToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();
            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", readToken, resourcePath);
            Logger.Debug("CDP4Services GET {0}: {1}", readToken, uriBuilder);

            var requestsw = Stopwatch.StartNew();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourcePath);
            requestMessage.Headers.Add(Headers.CDPToken, readToken);

            using var httpResponseMessage = await temporaryHttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            Logger.Info("CDP4 Services responded in {0} [ms] to GET {1}", requestsw.ElapsedMilliseconds, readToken);
            requestsw.Stop();

            if (httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                Logger.Warn("The data-source does not support multiple authentication schemes, Basic Authentication returned");

                return new AuthenticationSchemeResponse()
                {
                    Schemes = [AuthenticationSchemeKind.Basic]
                };
            }

            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                var message = $"The data-source replied error status code for {resourcePath}: {httpResponseMessage.StatusCode}";
                Logger.Error(message);
                throw new DalReadException(message);
            }

            cancellationToken.ThrowIfCancellationRequested();
            var response = this.Cdp4JsonSerializer.Deserialize<AuthenticationSchemeResponse>(await httpResponseMessage.Content.ReadAsStreamAsync());

            watch.Stop();
            Logger.Info("JSON Deserializer completed in {0} [ms]", watch.ElapsedMilliseconds);
            return response;
        }
        
        /// <summary>
        /// Queries the shortname of the authenticated User
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{TResult}"/> that contains the retrieved user shortname</returns>
        public override async Task<string> QueryAuthenticatedUserName(CancellationToken cancellationToken)
        {
            if (this.Credentials is not { IsFullyInitialized: true })
            {
                throw new InvalidOperationException("Credentials are not fully initiliazed");
            }
            
            var resourcePath = "username";
            var watch = Stopwatch.StartNew();
            var loginToken = CDP4Common.Helpers.TokenGenerator.GenerateRandomToken();

            var uriBuilder = this.GetUriBuilder(this.Credentials.Uri, ref resourcePath);

            Logger.Debug("Resource Path {0}: {1}", loginToken, resourcePath);
            Logger.Debug("CDP4Services UserName {0}: {1}", loginToken, uriBuilder);

            var requestsw = Stopwatch.StartNew();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, resourcePath);
            requestMessage.Headers.Add(Headers.CDPToken, loginToken);
            using var httpResponseMessage = await this.httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken: cancellationToken);

            Logger.Info("CDP4 Services responded in {0} [ms] to Login {1}", requestsw.ElapsedMilliseconds, loginToken);
            requestsw.Stop();

            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
            {
                var msg = $"The data-source replied with code {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}";
                Logger.Error(msg);
                throw new DalReadException(msg);
            }

            watch.Stop();
            Logger.Info("CDP4Services UserName {0}: {1} completed in {2} [ms]", loginToken, uriBuilder, watch.ElapsedMilliseconds);

            using var resultStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var deserializationWatch = Stopwatch.StartNew();
            deserializationWatch.Stop();

            switch (this.QueryContentTypeKind(httpResponseMessage))
            {
                case ContentTypeKind.JSON:
                    Logger.Info("Deserializing JSON response");
                    return await System.Text.Json.JsonSerializer.DeserializeAsync<string>(resultStream, cancellationToken: cancellationToken);
                case ContentTypeKind.MESSAGEPACK:
                    throw new InvalidOperationException("No support of UserName via MessagePack available");
            }

            return null;
        }

        /// <summary>
        /// gets the <see cref="QueryAttributes"/> associated to the <see cref="CdpServicesDal"/>
        /// </summary>
        /// <param name="includeReferenceData">
        /// Assertion to include reference data or not
        /// </param>
        /// <returns>
        /// the <see cref="QueryAttributes"/>
        /// </returns>
        private static IQueryAttributes GetIUriQueryAttribute(bool includeReferenceData = false)
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
        /// Extracts the <see cref="LongRunningTaskResult"/> from the JSON payload contained in a <see cref="Stream" />
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> that contains the JSON payload</param>
        /// <returns>The extracted <see cref="LongRunningTaskResult"/></returns>
        private LongRunningTaskResult ExtractResultFromStream(Stream stream)
        {
            using (var reader = new StreamReader(stream))
            {
                var firstChar = (char)reader.Peek();
                stream.Position = 0;

                return firstChar == '['
                    ? new LongRunningTaskResult(this.Cdp4JsonSerializer.Deserialize(stream))
                    : new LongRunningTaskResult(this.Cdp4JsonSerializer.Deserialize<CometTask>(stream));
            }
        }

        /// <summary>
        /// Verifies that the provided <paramref name="waitTime" /> is not lower than 1
        /// </summary>
        /// <param name="waitTime">The wait time value to verify</param>
        /// <exception cref="ArgumentOutOfRangeException">If the <paramref name="waitTime" /> is lower than 1</exception>
        private static void VerifyWaitTimeNotLowerThanOne(int waitTime)
        {
            if (waitTime < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(waitTime), $"The {nameof(waitTime)} may not be lower than 1");
            }
        }

        /// <summary>
        /// Verifies that the provided <paramref name="operationContainer" /> is not null
        /// </summary>
        /// <param name="operationContainer">The <see cref="OperationContainer" /> to verify</param>
        /// <exception cref="ArgumentNullException">If the provided <paramref name="operationContainer" /> is null</exception>
        private static void VerifyOperationContainerNotNull(OperationContainer operationContainer)
        {
            if (operationContainer == null)
            {
                throw new ArgumentNullException(nameof(operationContainer), $"The {nameof(operationContainer)} may not be null");
            }
        }
    }
}
    