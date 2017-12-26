// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFileDal.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonFileDal
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CDP4Common.CommonData;
    using CDP4Dal.Operations;
    using CDP4Dal;
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;
    using CDP4JsonFileDal.Json;
    using CDP4JsonSerializer;
    using Ionic.Zip;
    using NLog;

    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// Provides the Data Access Layer for file based import/export
    /// </summary>
    [DalExport("JSON File Based", "A file based JSON Data Access Layer", "1.1.0", DalType.File)]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class JsonFileDal : Dal
    {
        /// <summary>
        /// The site RDL zip location.
        /// </summary>
        private const string SiteRdlZipLocation = "SiteReferenceDataLibraries";

        /// <summary>
        /// The model RDL zip location.
        /// </summary>
        private const string ModelRdlZipLocation = "ModelReferenceDataLibraries";

        /// <summary>
        /// The engineering model zip location.
        /// </summary>
        private const string EngineeringModelZipLocation = "EngineeringModels";

        /// <summary>
        /// The iteration zip location.
        /// </summary>
        private const string IterationZipLocation = "Iterations";

        /// <summary>
        /// The FileRevisions zip location.
        /// </summary>
        private const string FileRevisionZipLocation = "FileRevisions";

        /// <summary>
        /// A remark to be included in the exchange header file.
        /// </summary>
        private const string ExchangeHeaderRemark = "This is an ECSS-E-TM-10-25 exchange file";

        /// <summary>
        /// The copyright text to be included in the exchange header file.
        /// </summary>
        private const string ExchangeHeaderCopyright = "Copyright 2016 © RHEA.";

        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonFileDal"/> class
        /// </summary>
        public JsonFileDal()
        {
            this.Serializer = new Cdp4JsonSerializer(this.MetaDataProvider, this.DalVersion);
        }

        /// <summary>
        /// Gets the <see cref="Cdp4JsonSerializer"/>
        /// </summary>
        public Cdp4JsonSerializer Serializer { get; private set; }

        /// <summary>
        /// Gets the value indicating whether this <see cref="IDal"/> is read only
        /// </summary>
        public override bool IsReadOnly
        {
            get { return true; }
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from all the <see cref="OperationContainer"/>s asynchronously.
        /// </summary>
        /// <param name="operationContainers">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainers, IEnumerable<string> files = null)
        {
            this.ValidateOperationContainers(operationContainers);

            CDP4Common.SiteDirectoryData.SiteDirectory siteDirectory = null;
            var iterations = new HashSet<CDP4Common.EngineeringModelData.Iteration>();
            var siteReferenceDataLibraries = new HashSet<CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary>();
            var modelReferenceDataLibraries = new HashSet<CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary>();
            var domainsOfExpertises = new HashSet<CDP4Common.SiteDirectoryData.DomainOfExpertise>();
            var persons = new HashSet<CDP4Common.SiteDirectoryData.Person>();
            var engineeringModelSetups = new HashSet<CDP4Common.SiteDirectoryData.EngineeringModelSetup>();
            var iterationSetups = new HashSet<CDP4Common.SiteDirectoryData.IterationSetup>();

            foreach (var operationContainer in operationContainers)
            {
                var operation = operationContainer.Operations.First(x => x.ModifiedThing is CDP4Common.DTO.Iteration);
                var iterationDto = (CDP4Common.DTO.Iteration)operation.ModifiedThing;
                var iterationPoco = (CDP4Common.EngineeringModelData.Iteration)iterationDto.QuerySourceThing();

                JsonFileDalUtils.AddIteration(iterationPoco, ref iterations);

                var iterationSetup = iterationPoco.IterationSetup;
                JsonFileDalUtils.AddIterationSetup(iterationSetup, ref iterationSetups);

                var iterationRequiredRls = iterationPoco.RequiredRdls;
                JsonFileDalUtils.AddReferenceDataLibraries(iterationRequiredRls, ref siteReferenceDataLibraries, ref modelReferenceDataLibraries);

                var engineeringModelSetup = (CDP4Common.SiteDirectoryData.EngineeringModelSetup)iterationSetup.Container;
                JsonFileDalUtils.AddEngineeringModelSetup(engineeringModelSetup, ref engineeringModelSetups);

                if (siteDirectory == null)
                {
                    siteDirectory = (CDP4Common.SiteDirectoryData.SiteDirectory)engineeringModelSetup.Container;
                }

                // add the domains-of-expertise that are to be included in the File
                JsonFileDalUtils.AddDomainsOfExpertise(engineeringModelSetup, ref domainsOfExpertises);

                // add the Persons that are to be included in the File
                JsonFileDalUtils.AddPersons(engineeringModelSetup, ref persons);
            }

            var path = this.Session.Credentials.Uri.LocalPath;

            var prunedSiteDirectoryDtos = JsonFileDalUtils.CreateSiteDirectoryAndPrunedContainedThingDtos(
                siteDirectory,
                siteReferenceDataLibraries,
                domainsOfExpertises,
                persons,
                engineeringModelSetups,
                iterationSetups);

            var activePerson = JsonFileDalUtils.QueryActivePerson(this.Session.Credentials.UserName, siteDirectory);

            var exchangeFileHeader = JsonFileDalUtils.CreateExchangeFileHeader(activePerson);

            try
            {
                using (var zipFile = new ZipFile())
                {
                    zipFile.Password = this.Session.Credentials.Password;

                    this.WriteHeaderToZipFile(exchangeFileHeader, zipFile, path);

                    this.WriteSiteDirectoryToZipFile(prunedSiteDirectoryDtos, zipFile, path);

                    this.WriteSiteReferenceDataLibraryToZipFile(siteReferenceDataLibraries, zipFile, path);

                    this.WriteModelReferenceDataLibraryToZipFile(modelReferenceDataLibraries, zipFile, path);

                    this.WriteIterationsToZipFile(iterations, zipFile, path);
                }

                Logger.Info("Successfully exported the open session {1} to {0}.", path, this.Session.Credentials.Uri);
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to export the open session to {0}. Error: {1}", path, ex.Message);
            }

            return Task.FromResult(Enumerable.Empty<Thing>());
        }

        public override Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Reads the data related to the provided <see cref="CDP4Common.DTO.Thing"/> from the data-source
        /// </summary>
        /// <typeparam name="T">
        /// an type of <see cref="CDP4Common.DTO.Thing"/>
        /// </typeparam>
        /// <param name="thing">
        /// An instance of <see cref="CDP4Common.DTO.Thing"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be passed along with the uri
        /// </param>
        /// <returns>
        /// a list of <see cref="CDP4Common.DTO.Thing"/> that are contained by the provided <see cref="CDP4Common.DTO.Thing"/> including the <see cref="CDP4Common.DTO.Thing"/> itself
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Throws a <see cref="NotSupportedException"/> if the supplied T thing is not an <see cref="CDP4Common.DTO.Iteration"/>.
        /// </exception>
        public override async Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            // only read Iterations in a file Dal
            if (!(thing is CDP4Common.DTO.Iteration))
            {
                throw new NotSupportedException("The JSONFileDal only supports Read on Iteration instances.");
            }

            // make sure the uri is not null
            Utils.AssertArgumentNotNull(this.Credentials.Uri);

            // make sure that the uri is of the correct format
            Utils.AssertUriIsFileSchema(this.Credentials.Uri);

            var filePath = this.Credentials.Uri.LocalPath;

            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException($"The specified filepath does not exist or you do not have access to it: {filePath}");
            }

            try
            {
                // re-read the to extract the reference data libraries that have not yet been fully dereferenced
                // and that are part of the required RDL's
                var siteDirectoryData = this.ReadSiteDirectoryJson(filePath, this.Credentials);

                // read file, SiteDirectory first.
                using (var zip = ZipFile.Read(filePath))
                {
                    // get all relevant info from the selected iteration
                    var siteDir = this.Session.RetrieveSiteDirectory();
                    var iteration = thing as CDP4Common.DTO.Iteration;
                    var engineeringModelSetup =
                        siteDir.Model.SingleOrDefault(x => x.IterationSetup.Any(y => y.IterationIid == iteration.Iid));

                    if (engineeringModelSetup == null)
                    {
                        throw new ArgumentException("Could not locate the engineeringModel setup information");
                    }

                    // read engineeringmodel
                    var engineeringModelFilePath = $"{engineeringModelSetup.EngineeringModelIid}.json";
                    var engineeringModelZipEntry =
                        zip.Entries.SingleOrDefault(x => x.FileName.EndsWith(engineeringModelFilePath));
                    var returned = this.ReadInfoFromArchiveEntry(engineeringModelZipEntry, this.Credentials.Password);

                    var iterationFilePath = $"{iteration.Iid}.json";
                    var iterationZipEntry = zip.Entries.SingleOrDefault(x => x.FileName.EndsWith(iterationFilePath));
                    returned.AddRange(
                        await
                        this.ReadIterationArchiveEntry(iterationZipEntry, this.Credentials.Password, cancellationToken));

                    // use the loaded sitedirectory information to determine the required model reference data library
                    var modelRdl = engineeringModelSetup.RequiredRdl.Single();

                    // add the modelRdlDto to the returned collection to make sure it's content gets dereferenced
                    if (returned.All(x => x.Iid != modelRdl.Iid))
                    {
                        var modelRdlDto = siteDirectoryData.Single(x => x.Iid == modelRdl.Iid);
                        returned.Add(modelRdlDto);
                    }

                    // based on engineering model setup load rdl chain
                    var modelRdlFilePath = $"{modelRdl.Iid}.json";
                    var modelRdlZipEntry = zip.Entries.SingleOrDefault(x => x.FileName.EndsWith(modelRdlFilePath));
                    var modelRdlItems = this.ReadInfoFromArchiveEntry(modelRdlZipEntry, this.Credentials.ArchivePassword);
                    returned.AddRange(modelRdlItems);

                    // load the reference data libraries as per the containment chain
                    var requiredRdl = modelRdl.RequiredRdl;
                    while (requiredRdl != null)
                    {
                        // add the rdlDto to the returned collection to make sure it's content gets dereferenced
                        var requiredRdlDto = siteDirectoryData.Single(x => x.Iid == requiredRdl.Iid);
                        returned.Add(requiredRdlDto);

                        var siteRdlFilePath = $"{requiredRdl.Iid}.json";
                        var siteRdlZipEntry = zip.Entries.SingleOrDefault(x => x.FileName.EndsWith(siteRdlFilePath));
                        var siteRdlItems = this.ReadInfoFromArchiveEntry(siteRdlZipEntry,this.Credentials.ArchivePassword);
                        returned.AddRange(siteRdlItems);

                        // set the requiredRdl for the next iteration
                        requiredRdl = requiredRdl.RequiredRdl;
                    }

                    return returned;
                }
            }
            catch (Exception ex)
            {
                var msg = $"Failed to load file. Error: {ex.Message}";
                Logger.Error(msg);

                if (this.Credentials != null)
                {
                    this.Close();
                }

                throw new FileLoadException(msg);
            }
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
        /// A list of <see cref="Thing"/> that are contained by the provided <see cref="EngineeringModel"/> including the Reference-Data.
        /// All the <see cref="Thing"/>s that have been updated since the last read will be returned.
        /// </returns>
        public override async Task<IEnumerable<Thing>> Read(CDP4Common.DTO.Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            return await this.Read((Thing)iteration, cancellationToken, attributes);
        }

        /// <summary>
        /// Creates the specified <see cref="CDP4Common.DTO.Thing"/> on a data source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="CDP4Common.DTO.Thing"/> that is to be created
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="CDP4Common.DTO.Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="CDP4Common.DTO.Thing"/> that have been updated since the last Read has been performed. This includes the thing that was created.
        /// </returns>
        public override IEnumerable<Thing> Create<T>(T thing)
        {
            throw new NotSupportedException("The Create operation is not supported by the file datasource.");
        }

        /// <summary>
        /// Performs an update to the <see cref="CDP4Common.DTO.Thing"/> on the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="CDP4Common.DTO.Thing"/> that is to be updated
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="CDP4Common.DTO.Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="CDP4Common.DTO.Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public override IEnumerable<Thing> Update<T>(T thing)
        {
            throw new NotSupportedException("The Update operation is not supported by the file datasource.");
        }

        /// <summary>
        /// Deletes the specified <see cref="CDP4Common.DTO.Thing"/> from the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="CDP4Common.DTO.Thing"/> that is to be deleted
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="CDP4Common.DTO.Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="CDP4Common.DTO.Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public override IEnumerable<Thing> Delete<T>(T thing)
        {
            throw new NotSupportedException("The Delete operation is not supported by the file datasource.");
        }

        /// <summary>
        /// Opens a connection to a data source <see cref="Uri"/>
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> that are used to connect to the data source such as username, password and <see cref="Uri"/>
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> of returned <see cref="CDP4Common.DTO.Thing"/> DTOs.
        /// </returns>
        public override async Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken)
        {
            // make sure the uri is not null
            Utils.AssertArgumentNotNull(credentials.Uri);

            // make sure that the uri is of the correct format
            Utils.AssertUriIsFileSchema(credentials.Uri);

            var filePath = credentials.Uri.LocalPath;

            if (!System.IO.File.Exists(filePath))
            {
                throw new FileLoadException($"The specified filepath does not exist or you do not have access to it: {filePath}");
            }

            try
            {
                var returned = this.ReadSiteDirectoryJson(filePath, credentials).ToList();
                
                var log = $"The Sitedirectory contains {returned.Count()} Things";
                Logger.Debug(log);
                
                // check for credentials in the returned DTO's to see if the current Person is authorised to look into this SiteDirectory
                var person = returned.SingleOrDefault(p =>
                        p.ClassKind == ClassKind.Person &&
                        ((CDP4Common.DTO.Person) p).ShortName == credentials.UserName) as
                    CDP4Common.DTO.Person;

                if (person == null)
                {
                    var msg = $"{credentials.UserName} is unauthorized";
                    Logger.Error(msg);

                    throw new UnauthorizedAccessException(msg);
                }

                // set the credentials
                this.Credentials = credentials;

                return returned;
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Error(ex);
                this.CloseSession();
                throw;
            }
            catch (Exception ex)
            {
                this.CloseSession();

                var msg = $"Failed to load file. Error: {ex.Message}";
                Logger.Error(msg);
                
                throw new FileLoadException(msg, ex);
            }
        }
        
        /// <summary>
        /// Closes the connection to an active File source
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
            return System.IO.File.Exists(uri);
        }

        /// <summary>
        /// Retrieve the associated Cache from the operation original Thing instance.
        /// </summary>
        /// <param name="operation">
        /// A operation instance holding the export information.
        /// </param>
        /// <returns>
        /// The associated cache of the Thing in the operation.
        /// </returns>
        internal static ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CDP4Common.CommonData.Thing>> GetAssociatedCache(
            Operation operation)
        {
            var sourceThing = operation.OriginalThing.QuerySourceThing();

            if (sourceThing == null)
            {
                throw new ArgumentException("The supplied OriginalThing DTO must be created from a POCO instance.");
            }

            // set the associated cache for this export request (is always one)
            var associatedCache = sourceThing.Cache;
            return associatedCache;
        }

        /// <summary>
        /// Determine the non exportable site directory items.
        /// Only data referenced by the exported iteration(s) is to be included in the site directory export.
        /// </summary>
        /// <param name="referencedSiteDirectory">
        /// The referenced site directory.
        /// </param>
        /// <param name="referencedSiteRdls">
        /// The referenced site reference data libraries.
        /// </param>
        /// <param name="referencedIterationSetups">
        /// The referenced Iteration Setups.
        /// </param>
        /// <returns>
        /// The list of <see cref="CDP4Common.CommonData.Thing"/> instances that are not to be included in the export.
        /// </returns>
        internal static List<CDP4Common.CommonData.Thing> DetermineNonExportableItems(
            CDP4Common.SiteDirectoryData.SiteDirectory referencedSiteDirectory,
            List<CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary> referencedSiteRdls,
            List<CDP4Common.SiteDirectoryData.IterationSetup> referencedIterationSetups)
        {
            var referencedEngineeringModelSetups =
                referencedIterationSetups.Select(x => (CDP4Common.SiteDirectoryData.EngineeringModelSetup)x.Container)
                    .ToList();

            // determine the non exportable site reference data libraries
            var notExportableSiteRdls =
                referencedSiteDirectory.SiteReferenceDataLibrary.Except(referencedSiteRdls).ToList();

            // determine the non exportable engineering model setups in the context of the referenced engineering model setups
            var notExportableEngineeringModelSetups =
                referencedSiteDirectory.Model.Except(referencedEngineeringModelSetups).ToList();

            // determine the non exportable iteration setups in the context of the referenced engineering model setups
            var notExportableIterationSetup =
                referencedSiteDirectory.Model.SelectMany(model => model.IterationSetup)
                    .Distinct()
                    .Except(referencedIterationSetups)
                    .Distinct();

            // determine the non active domains in the context of the referenced engineering model setups
            var notExportableDomains =
                referencedSiteDirectory.Domain.Except(
                    referencedEngineeringModelSetups.SelectMany(model => model.ActiveDomain).Distinct());

            var notExportableItems = new List<CDP4Common.CommonData.Thing>(notExportableEngineeringModelSetups);
            notExportableItems.AddRange(notExportableIterationSetup);
            notExportableItems.AddRange(notExportableDomains);
            notExportableItems.AddRange(notExportableSiteRdls);
            return notExportableItems;
        }

        /// <summary>
        /// Write the header file to the zip export archive.
        /// </summary>
        /// <param name="exportPerson">
        /// The person that initiated the export.
        /// </param>
        /// <param name="exchangeFileHeader">
        /// The exchange File Header.
        /// </param>
        /// <param name="zip">
        /// The zip archive instance to add the information to.
        /// </param>
        /// <param name="path">
        /// The save path of the zip file.
        /// </param>
        internal void WriteHeaderFile(
            CDP4Common.SiteDirectoryData.Person exportPerson,
            ExchangeFileHeader exchangeFileHeader,
            ZipFile zip,
            string path)
        {
            if (exportPerson == null)
            {
                throw new ArgumentNullException("exportPerson", "A person entity is required when performing an export.");
            }

            if (exchangeFileHeader == null)
            {
                throw new ArgumentNullException("exchangeFileHeader", "The exchange file header has to be supplied.");
            }

            if (zip == null)
            {
                throw new ArgumentNullException("zip", "A zip file instance must be supplied.");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path", "A valid file path has to be supplied.");
            }

            var creatorPerson = new ExchangeFileInitiator
            {
                Iid = exportPerson.Iid,
                GivenName = exportPerson.GivenName,
                Surname = exportPerson.Surname,
                Email = exportPerson.DefaultEmailAddress != null  ? exportPerson.DefaultEmailAddress.Value : null
            };

            var organization = exportPerson.Organization != null
                                   ? new OrganizationInfo
                                   {
                                       Iid = exportPerson.Organization.Iid,
                                       Name = exportPerson.Organization.Name,
                                       Site = null,
                                       Unit =
                                                 !string.IsNullOrEmpty(exportPerson.OrganizationalUnit)
                                                     ? exportPerson.OrganizationalUnit
                                                     : null
                                   }
                                   : null;

            exchangeFileHeader.CreatorOrganization = organization;
            exchangeFileHeader.CreatorPerson = creatorPerson;

            using (var headerFileMemStream = new MemoryStream())
            {
                this.Serializer.SerializeToStream(exchangeFileHeader, headerFileMemStream);

                var headerFilename = "Header.json";

                var me = zip.AddEntry(headerFilename, headerFileMemStream);
                me.Comment = $"The {headerFilename} for this file based source";

                zip.Save(path);
            }
        }

        /// <summary>
        /// Export the site directory information to zip archive.
        /// </summary>
        /// <param name="siteDirectoryItems">
        /// The site Directory Items.
        /// </param>
        /// <param name="referencedSiteRdls">
        /// The referenced site reference data libraries.
        /// </param>
        /// <param name="referencedEngineeringModelSetups">
        /// The referenced Engineering Model Setups.
        /// </param>
        /// <param name="referencedIterationSetups">
        /// The referenced iteration setups.
        /// </param>
        /// <param name="zip">
        /// The zip archive instance to add the information to.
        /// </param>
        /// <param name="path">
        /// The save path of the zip file.
        /// </param>
        internal void WriteSiteDirectoryFile(List<CDP4Common.CommonData.Thing> siteDirectoryItems, List<CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary> referencedSiteRdls, List<CDP4Common.SiteDirectoryData.EngineeringModelSetup> referencedEngineeringModelSetups, List<CDP4Common.SiteDirectoryData.IterationSetup> referencedIterationSetups, ZipFile zip, string path)
        {
            if (!siteDirectoryItems.Any())
            {
                throw new ArgumentException(
                    "The site directory item collection must not be empty.",
                    "siteDirectoryItems");
            }

            if (!referencedSiteRdls.Any())
            {
                throw new ArgumentException(
                    "The site reference data library collection must not be empty.",
                    "referencedSiteRdls");
            }

            if (!referencedEngineeringModelSetups.Any())
            {
                throw new ArgumentException(
                    "The engineering model setup collection must not be empty.",
                    "referencedEngineeringModelSetups");
            }

            if (!referencedIterationSetups.Any())
            {
                throw new ArgumentException(
                    "The iteration setup collection must not be empty.",
                    "referencedIterationSetups");
            }

            if (zip == null)
            {
                throw new ArgumentNullException("zip", "A zip file instance must be supplied.");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path", "A valid file path has to be supplied.");
            }

            // get dtos
            var siteDirectoryDtoItems = siteDirectoryItems.Select(x => x.ToDto()).ToList();
            var referencedEngineeringModelSetupList = referencedEngineeringModelSetups.ToList();
            var referencedIterationSetupList = referencedIterationSetups.ToList();

            // prepare reference properties to reflect package contents
            var siteDirDto = (CDP4Common.DTO.SiteDirectory)siteDirectoryDtoItems.Single(dto => dto.ClassKind == ClassKind.SiteDirectory);

            // prune the contained engineeringmodels
            siteDirDto.Model = referencedEngineeringModelSetupList.Select(model => model.Iid).ToList();

            // prune the contained domains to active domains only
            siteDirDto.Domain =
                referencedEngineeringModelSetupList.SelectMany(model => model.ActiveDomain.Select(x => x.Iid))
                    .Distinct()
                    .ToList();

            // prune the contained site reference data libraries
            siteDirDto.SiteReferenceDataLibrary = referencedSiteRdls.Select(rdl => rdl.Iid).ToList();

            foreach (
                var model in
                    siteDirectoryDtoItems.Where(dto => dto.ClassKind == ClassKind.EngineeringModelSetup)
                        .Cast<CDP4Common.DTO.EngineeringModelSetup>())
            {
                // prune the contained iteration setups
                model.IterationSetup = referencedIterationSetupList.Where(x => x.Container.Iid == model.Iid).Select(x => x.Iid).ToList();
            }

            using (var memoryStream = new MemoryStream())
            {
                this.Serializer.SerializeToStream(siteDirectoryDtoItems, memoryStream);
                memoryStream.Position = 0;

                // serialize the SiteDirectory to a memory stream
                var e = zip.AddEntry("SiteDirectory.json", memoryStream);
                e.Comment = "The SiteDirectory for this file based source";

                zip.Save(path);
            }
        }

        /// <summary>
        /// Export the referenced site reference data library information to zip archive.
        /// </summary>
        /// <param name="siteReferenceDataLibraryItems">
        /// The site Reference Data Library Items.
        /// </param>
        /// <param name="zip">
        /// The zip archive instance to add the information to.
        /// </param>
        /// <param name="path">
        /// The save path of the zip file.
        /// </param>
        internal void WriteSiteReferenceDataLibraryFiles(
            List<List<CDP4Common.CommonData.Thing>> siteReferenceDataLibraryItems,
            ZipFile zip,
            string path)
        {
            if (!siteReferenceDataLibraryItems.Any() && siteReferenceDataLibraryItems.All(x => x.Any()))
            {
                throw new ArgumentException("The site reference data library item collection must not be empty.", "siteReferenceDataLibraryItems");
            }

            if (zip == null)
            {
                throw new ArgumentNullException("zip", "A zip file instance must be supplied.");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path", "A valid file path has to be supplied.");
            }

            foreach (var siteRdlDefinition in siteReferenceDataLibraryItems)
            {
                // make sure that the site reference data library dto itself is not written out, is already contained in the SiteDirectory.json output
                var siteRdlMDtoDefinition =
                    siteRdlDefinition.Where(x => x.ClassKind != ClassKind.SiteReferenceDataLibrary)
                        .Select(x => x.ToDto())
                        .ToList();

                // first item represents the site refence data library
                var siteRdl = siteRdlDefinition.First();

                using (var modelMemStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(siteRdlMDtoDefinition, modelMemStream);
                    modelMemStream.Position = 0;

                    var modelFilename = $"{SiteRdlZipLocation}\\{siteRdl.Iid}.json";

                    var me = zip.AddEntry(modelFilename, modelMemStream);
                    me.Comment = $"The {modelFilename} for this file based source";

                    zip.Save(path);
                }
            }
        }

        /// <summary>
        /// Export the referenced model reference data library information to zip archive.
        /// </summary>
        /// <param name="modelReferenceDataLibraryItems">
        /// The model Reference Data Library Items.
        /// </param>
        /// <param name="zip">
        /// The zip archive instance to add the information to.
        /// </param>
        /// <param name="path">
        /// The save path of the zip file.
        /// </param>
        internal void WriteModelReferenceDataLibraryFiles(
            List<List<CDP4Common.CommonData.Thing>> modelReferenceDataLibraryItems,
            ZipFile zip,
            string path)
        {
            if (!modelReferenceDataLibraryItems.Any() && modelReferenceDataLibraryItems.All(x => x.Any()))
            {
                throw new ArgumentException("The model reference data library item collection must not be empty.", "modelReferenceDataLibraryItems");
            }

            if (zip == null)
            {
                throw new ArgumentNullException("zip", "A zip file instance must be supplied.");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path", "A valid file path has to be supplied.");
            }

            foreach (var modelRdlDefinition in modelReferenceDataLibraryItems)
            {
                // make sure that the model reference data library dto itself is not written out, is already contained in the SiteDirectory.json output
                var modelRdlMDtoDefinition =
                    modelRdlDefinition.Where(x => x.ClassKind != ClassKind.ModelReferenceDataLibrary)
                        .Select(x => x.ToDto())
                        .ToList();

                // first item represents the model refence data library
                var modelRdl = modelRdlDefinition.First();

                using (var modelMemStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(modelRdlMDtoDefinition, modelMemStream);
                    modelMemStream.Position = 0;

                    var modelFilename = $"{ModelRdlZipLocation}\\{modelRdl.Iid}.json";

                    var me = zip.AddEntry(modelFilename, modelMemStream);
                    me.Comment = $"The {modelFilename} for this file based source";

                    zip.Save(path);
                }
            }
        }

        /// <summary>
        /// Export the engineering model to zip archive.
        /// </summary>
        /// <param name="engineeringModelItems">
        /// The referenced exported engineering model items.
        /// </param>
        /// <param name="iterationItems">
        /// The exported iteration items.
        /// </param>
        /// <param name="zip">
        /// The zip archive instance to add the information to.
        /// </param>
        /// <param name="path">
        /// The save path of the zip file.
        /// </param>
        internal void WriteEngineeringModelFiles(List<List<CDP4Common.CommonData.Thing>> engineeringModelItems, List<List<CDP4Common.CommonData.Thing>> iterationItems, ZipFile zip, string path)
        {
            if (!engineeringModelItems.Any() && engineeringModelItems.All(x => x.Any()))
            {
                throw new ArgumentException(                    "The engineeringmodel item collection must not be empty.", "engineeringModelItems");
            }

            if (!iterationItems.Any() && iterationItems.All(x => x.Any()))
            {
                throw new ArgumentException("The iteration item collection must not be empty.", "iterationItems");
            }

            if (zip == null)
            {
                throw new ArgumentNullException("zip", "A zip file instance must be supplied.");
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path", "A valid file path has to be supplied.");
            }

            foreach (var modelDefinition in engineeringModelItems)
            {
                var modelDtoDefinition = modelDefinition.Select(x => x.ToDto()).ToList();

                // first item represents the engineeringmodel
                var engineeringModel = modelDefinition.First();

                using (var modelMemStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(modelDtoDefinition, modelMemStream);
                    modelMemStream.Position = 0;

                    var modelFilename = $"{EngineeringModelZipLocation}\\{engineeringModel.Iid}\\{engineeringModel.Iid}.json";

                    var me = zip.AddEntry(modelFilename, modelMemStream);
                    me.Comment = $"The {modelFilename} for this file based source";

                    // Create a directory for the FileRevisions
                    var fileRevisionDirectoryPath = $"{EngineeringModelZipLocation}\\{engineeringModel.Iid}\\{FileRevisionZipLocation}";
                    zip.AddDirectoryByName(fileRevisionDirectoryPath);

                    zip.Save(path);
                }

                // write out iteration files per containing engineeringmodel
                foreach (var iterationDefinition in iterationItems.Where(x => x.First().Container == engineeringModel))
                {
                    var iterationDtoDefinition = iterationDefinition.Select(x => x.ToDto()).ToList();

                    // first item represents the iteration
                    var iteration = iterationDefinition.First();

                    using (var iterationMemStream = new MemoryStream())
                    {
                        this.Serializer.SerializeToStream(iterationDtoDefinition, iterationMemStream);
                        iterationMemStream.Position = 0;

                        var iterationFilename = $"{EngineeringModelZipLocation}\\{engineeringModel.Iid}\\{IterationZipLocation}\\{iteration.Iid}.json";

                        var me = zip.AddEntry(iterationFilename, iterationMemStream);
                        me.Comment = $"The {iterationFilename} for this file based source";

                        zip.Save(path);
                    }
                }
            }
        }

        /// <summary>
        /// Validates that the correctness of the <see cref="operationContainers"/>
        /// </summary>
        /// <param name="operationContainers">
        /// The <see cref="IEnumerable{OperationContainer}"/> to validate
        /// </param>
        private void ValidateOperationContainers(IEnumerable<OperationContainer> operationContainers)
        {
            if (operationContainers == null)
            {
                throw new ArgumentNullException("operationContainers", "The operationContainer may not be null");
            }

            if (!operationContainers.Any())
            {
                throw new ArgumentException("The operationContainers may not be empty", "operationContainer");
            }

            if (operationContainers.Any(operationContainer => !operationContainer.Operations.Any()))
            {
                throw new ArgumentException("None of the OperationContainers contain Operations", "operationContainers");
            }

            foreach (var operationContainer in operationContainers)
            {
                if (operationContainer.Operations.Any(operation => operation.ModifiedThing.GetType() != typeof(CDP4Common.DTO.Iteration)))
                {
                    throw new ArgumentException($"Only instances of Things of type {typeof(CDP4Common.DTO.Iteration).Name} are eligible for export", "operationContainer");
                }
            }
        }

        /// <summary>
        /// Write the header file to the zip export archive.
        /// </summary>
        /// <param name="echExchangeFileHeader">
        /// The <see cref="ExchangeFileHeader"/> that is to be written to the <see cref="zipFile"/>
        /// </param>
        /// <param name="zipFile">
        /// The zip archive instance to add the information to.
        /// </param>
        /// <param name="filePath">
        /// The path of the file.
        /// </param>
        private void WriteHeaderToZipFile(ExchangeFileHeader echExchangeFileHeader, ZipFile zipFile, string filePath)
        {
            using (var memoryStream = new MemoryStream())
            {
                this.Serializer.SerializeToStream(echExchangeFileHeader, memoryStream);

                using (var outputStream = new MemoryStream(memoryStream.ToArray()))
                {
                    var zipEntry = zipFile.AddEntry("Header.json", outputStream);
                    zipEntry.Comment = "The Header for this file based source";
                    zipFile.Save(filePath);
                }
            }
        }

        /// <summary>
        /// Writes the pruned <see cref="CDP4Common.SiteDirectoryData.SiteDirectory"/> to the <see cref="ZipFile"/>
        /// </summary>
        /// <param name="prunedSiteDirectoryContents">
        /// The <see cref="CDP4Common.SiteDirectoryData.SiteDirectory"/> that has been pruned of all unnecessary data
        /// </param>
        /// <param name="zipFile">
        /// The target <see cref="ZipFile"/>
        /// </param>
        /// <param name="filePath">
        /// The file Path.
        /// </param>
        private void WriteSiteDirectoryToZipFile(IEnumerable<CDP4Common.DTO.Thing> prunedSiteDirectoryContents, ZipFile zipFile, string filePath)
        {
            using (var memoryStream = new MemoryStream())
            {
                this.Serializer.SerializeToStream(prunedSiteDirectoryContents, memoryStream);
                using (var outputStream = new MemoryStream(memoryStream.ToArray()))
                {
                    var zipEntry = zipFile.AddEntry("SiteDirectory.json", outputStream);
                    zipEntry.Comment = "The SiteDirectory for this file based source";
                    zipFile.Save(filePath);
                }
            }
        }

        /// <summary>
        /// Writes the <see cref="CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary"/> to the <see cref="ZipFile"/>
        /// </summary>
        /// <param name="siteReferenceDataLibraries">
        /// The <see cref="CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary"/> that are to be written to the <see cref="ZipFile"/>
        /// </param>
        /// <param name="zipFile">
        /// The target <see cref="ZipFile"/> that the <see cref="siteReferenceDataLibraries"/> are written to.
        /// </param>
        /// <param name="filePath">
        /// The file of the target <see cref="ZipFile"/>
        /// </param>
        private void WriteSiteReferenceDataLibraryToZipFile(IEnumerable<CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary> siteReferenceDataLibraries, ZipFile zipFile, string filePath)
        {
            foreach (var siteReferenceDataLibrary in siteReferenceDataLibraries)
            {
                var containmentPocos = siteReferenceDataLibrary.QueryContainedThingsDeep().ToList();
                if (containmentPocos.Contains(siteReferenceDataLibrary))
                {
                    containmentPocos.Remove(siteReferenceDataLibrary);
                }

                var dtos = containmentPocos.Select(poco => poco.ToDto());

                using (var memoryStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(dtos, memoryStream);

                    using (var outputStream = new MemoryStream(memoryStream.ToArray()))
                    {
                        var siteReferenceDataLibraryFilename = $"{SiteRdlZipLocation}\\{siteReferenceDataLibrary.Iid}.json";
                        var zipEntry = zipFile.AddEntry(siteReferenceDataLibraryFilename, outputStream);
                        zipEntry.Comment = $"The {siteReferenceDataLibrary.ShortName} SiteReferenceDataLibrary";
                        zipFile.Save(filePath);
                    }
                }
            }
        }

        /// <summary>
        /// Writes the <see cref="CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary"/> to the <see cref="ZipFile"/>
        /// </summary>
        /// <param name="modelReferenceDataLibraries">
        /// The <see cref="CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary"/> that are to be written to the <see cref="ZipFile"/>
        /// </param>
        /// <param name="zipFile">
        /// The target <see cref="ZipFile"/> that the <see cref="modelReferenceDataLibraries"/> are written to.
        /// </param>
        /// <param name="filePath">
        /// The file of the target <see cref="ZipFile"/>
        /// </param>
        private void WriteModelReferenceDataLibraryToZipFile(IEnumerable<CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary> modelReferenceDataLibraries, ZipFile zipFile, string filePath)
        {
            foreach (var modelReferenceDataLibrary in modelReferenceDataLibraries)
            {
                var containmentPocos = modelReferenceDataLibrary.QueryContainedThingsDeep().ToList();
                if (containmentPocos.Contains(modelReferenceDataLibrary))
                {
                    containmentPocos.Remove(modelReferenceDataLibrary);
                }

                var dtos = containmentPocos.Select(poco => poco.ToDto());

                using (var memoryStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(dtos, memoryStream);
                    using (var outputStream = new MemoryStream(memoryStream.ToArray()))
                    {
                        var modelReferenceDataLibraryFilename = $"{ModelRdlZipLocation}\\{modelReferenceDataLibrary.Iid}.json";
                        var zipEntry = zipFile.AddEntry(modelReferenceDataLibraryFilename, outputStream);
                        zipEntry.Comment = $"The {modelReferenceDataLibrary.ShortName} ModelReferenceDataLibrary";
                        zipFile.Save(filePath);
                    }
                }
            }
        }

        /// <summary>
        /// Writes the <see cref="CDP4Common.EngineeringModelData.Iteration"/> to the <see cref="ZipFile"/>
        /// </summary>
        /// <param name="iterations">
        /// The <see cref="CDP4Common.EngineeringModelData.Iteration"/> that are to be written to the <see cref="ZipFile"/>
        /// </param>
        /// <param name="zipFile">
        /// The target <see cref="ZipFile"/> that the <see cref="iterations"/> are written to.
        /// </param>
        /// <param name="filePath">
        /// The file of the target <see cref="ZipFile"/>
        /// </param>
        private void WriteIterationsToZipFile(IEnumerable<CDP4Common.EngineeringModelData.Iteration> iterations, ZipFile zipFile, string filePath)
        {
            var engineeringModels = new List<CDP4Common.EngineeringModelData.EngineeringModel>();

            foreach (var iteration in iterations)
            {
                var engineeringModel = (CDP4Common.EngineeringModelData.EngineeringModel)iteration.Container;
                var engineeringModelDto = engineeringModel.ToDto();

                if (!engineeringModels.Contains(engineeringModel))
                {
                    using (var engineeringModelMemoryStream = new MemoryStream())
                    {
                        this.Serializer.SerializeToStream(new[] { engineeringModelDto }, engineeringModelMemoryStream);

                        using (var outputStream = new MemoryStream(engineeringModelMemoryStream.ToArray()))
                        {
                            var engineeringModelFilename = $@"{EngineeringModelZipLocation}\{engineeringModelDto.Iid}\{engineeringModelDto.Iid}.json";
                            var engineeringModelZipEntry = zipFile.AddEntry(engineeringModelFilename, outputStream);
                            engineeringModelZipEntry.Comment = $"The {engineeringModel.EngineeringModelSetup.ShortName} EngineeringModel";
                            zipFile.Save(filePath);
                        }
                    }

                    engineeringModels.Add(engineeringModel);
                }

                var containmentPocos = iteration.QueryContainedThingsDeep();
                var dtos = containmentPocos.Select(poco => poco.ToDto());

                using (var iterationMemoryStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(dtos, iterationMemoryStream);

                    using (var outputStream = new MemoryStream(iterationMemoryStream.ToArray()))
                    {
                        var iterationFilename = $@"{EngineeringModelZipLocation}\{engineeringModelDto.Iid}\{IterationZipLocation}\{iteration.Iid}.json";
                        var iterationZipEntry = zipFile.AddEntry(iterationFilename, outputStream);
                        iterationZipEntry.Comment = $"The {iteration.IterationSetup.IsDeleted} Iteration";
                        zipFile.Save(filePath);
                    }
                }
            }
        }

        private IEnumerable<Thing> ReadSiteDirectoryJson(string filePath, Credentials credentials)
        {
            using (var zip = ZipFile.Read(filePath))
            {
                // read SiteDirectory
                var siteDirectoryFilePath = "SiteDirectory.json";
                var siteDirectoryZipEntry = zip.Entries.SingleOrDefault(x => x.FileName.EndsWith(siteDirectoryFilePath));
                var returned = this.ReadInfoFromArchiveEntry(siteDirectoryZipEntry, credentials.ArchivePassword);

                return returned;
            }
        }

        /// <summary>
        /// Read an iteration file from the specified archive entry.
        /// </summary>
        /// <param name="zipEntry">
        /// The zip entry pointing to the iteration file in the archive.
        /// </param>
        /// <param name="archivePassword">
        /// The password of the archive.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token used to cancel the async read.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task<List<Thing>> ReadIterationArchiveEntry(ZipEntry zipEntry, string archivePassword, CancellationToken cancellationToken)
        {
            var returned = this.ReadInfoFromArchiveEntry(zipEntry, archivePassword);

            // set the iteration id for returned objects
            var iterationId = returned.First().Iid;
            this.SetIterationContainer(returned, iterationId);

            return returned;
        }

        /// <summary>
        /// Read info from a specified archive entry.
        /// </summary>
        /// <param name="zipEntry">
        /// The zip entry.
        /// </param>
        /// <param name="archivePassword">
        /// The password of the archive.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// throws exception if the file failed to open
        /// </exception>
        private List<Thing> ReadInfoFromArchiveEntry(ZipEntry zipEntry, string archivePassword)
        {
            if (zipEntry == null)
            {
                throw new ArgumentNullException("zipEntry", "Supplied archive entry is invalid.");
            }

            var watch = Stopwatch.StartNew();

            var stream = new MemoryStream();

            try
            {
                zipEntry.Password = archivePassword;
                zipEntry.Extract(stream);
            }
            catch (Exception ex)
            {
                var msg = $"{"Failed to open file. Error"}: {ex.Message}";
                Logger.Error(msg);

                throw new FileLoadException(msg);
            }
            
            watch.Stop();
            Logger.Info("ZipEntry {0} retrieved {1} ", zipEntry.FileName, watch.Elapsed);

            watch = Stopwatch.StartNew();
            
            stream.Position = 0;
            var returned = this.Serializer.Deserialize(stream).ToList();
            
            stream.Dispose();
            watch.Stop();
            Logger.Info("JSON Deserializer of {0} completed in {1} ", zipEntry.FileName, watch.Elapsed);
            return returned;
        }
    }
}