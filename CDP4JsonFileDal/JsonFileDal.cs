// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFileDal.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4JsonFileDal
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.Extensions;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal;
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Operations;
    using CDP4DalCommon.Protocol.Tasks;

    using CDP4DalJsonSerializer;

    using CDP4JsonFileDal.Json;

    using Ionic.Zip;

    using NLog;

    using Person = CDP4Common.SiteDirectoryData.Person;
    using SiteDirectory = CDP4Common.SiteDirectoryData.SiteDirectory;
    using Thing = CDP4Common.DTO.Thing;
#if NETFRAMEWORK
    using System.ComponentModel.Composition;
#endif

    /// <summary>
    /// Provides the Data Access Layer for file based import/export
    /// </summary>
    [DalExport("JSON File Based", "A file based JSON Data Access Layer", "1.3.0", DalType.File)]
#if NETFRAMEWORK
    [PartCreationPolicy(CreationPolicy.NonShared)]
#endif
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
        /// The application-dependent (extensions) files zip location.
        /// </summary>
        private const string ExtensionsZipLocation = "Extensions";

        /// <summary>
        /// The iteration zip location.
        /// </summary>
        private const string IterationZipLocation = "Iterations";

        /// <summary>
        /// The <see cref="GuidComparer"/> that is used to sort <see cref="List{Guid}"/> for
        /// stable serialization
        /// </summary>
        private readonly GuidComparer guidComparer = new GuidComparer();

        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The <see cref="CDP4Common.Extensions.ThingConverterExtensions"/> used to determine whether a class is to be serialized or not
        /// </summary>
        private readonly ThingConverterExtensions thingConverterExtensions = new ThingConverterExtensions();

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonFileDal"/> class
        /// </summary>
        public JsonFileDal()
        {
            this.Serializer = new Cdp4DalJsonSerializer(this.MetaDataProvider, this.DalVersion, false);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonFileDal"/> class
        /// </summary>
        /// <param name="dalVersion">CDP4 model version <see cref="Version" /></param>
        public JsonFileDal(Version dalVersion)
        {
            if (dalVersion > this.DalVersion)
            {
                throw new DalVersionException($"Model version {dalVersion} is not supported.");
            }

            if (dalVersion != null)
            {
                this.DalVersion = dalVersion;
            }

            this.Serializer = new Cdp4DalJsonSerializer(this.MetaDataProvider, this.DalVersion, false);
        }

        /// <summary>
        /// Allow the API user to update the copyright information with custom data
        /// </summary>
        /// <param name="person">The <see cref="CDP4Common.SiteDirectoryData.Person"/> that is used to create the <see cref="ExchangeFileHeader"/></param>
        /// <param name="headerCopyright">Header copyright text</param>
        /// <param name="headerRemark">Header remark text</param>
        public void UpdateExchangeFileHeader(Person person, string headerCopyright = null, string headerRemark = null)
        {
            var exchangeFileHeader = JsonFileDalUtils.CreateExchangeFileHeader(person);
            exchangeFileHeader.Remark = headerRemark ?? exchangeFileHeader.Remark;
            exchangeFileHeader.Copyright = headerCopyright ?? exchangeFileHeader.Copyright;

            this.FileHeader = exchangeFileHeader;
        }

        /// <summary>
        /// Gets the <see cref="Cdp4DalJsonSerializer"/>
        /// </summary>
        public Cdp4DalJsonSerializer Serializer { get; private set; }

        /// <summary>
        /// Gets the value indicating whether this <see cref="IDal"/> is read only
        /// </summary>
        public override bool IsReadOnly => true;

        /// <summary>
        /// Gets the <see cref="ExchangeFileHeader"/>
        /// </summary>
        public ExchangeFileHeader FileHeader { get; private set; }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from all the <see cref="OperationContainer"/>s asynchronously.
        /// </summary>
        /// <param name="operationContainers">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="extensionFiles">
        /// The path to the files that need to be uploaded. If <paramref name="extensionFiles"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="CDP4Common.DTO.Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainers, IEnumerable<string> extensionFiles = null)
        {
            this.ValidateOperationContainers(operationContainers);

            SiteDirectory siteDirectory = null;
            var iterations = new HashSet<Iteration>();
            var siteReferenceDataLibraries = new HashSet<SiteReferenceDataLibrary>();
            var modelReferenceDataLibraries = new HashSet<ModelReferenceDataLibrary>();
            var domainOfExpertises = new HashSet<DomainOfExpertise>();
            var persons = new HashSet<Person>();
            var personRoles = new HashSet<PersonRole>();
            var participantRoles = new HashSet<ParticipantRole>();
            var participants = new HashSet<Participant>();
            var organizations = new HashSet<Organization>();
            var engineeringModelSetups = new HashSet<EngineeringModelSetup>();
            var iterationSetups = new HashSet<IterationSetup>();

            foreach (var operationContainer in operationContainers)
            {
                var operation = operationContainer.Operations.First(x => x.ModifiedThing is CDP4Common.DTO.Iteration);
                var iterationDto = (CDP4Common.DTO.Iteration)operation.ModifiedThing;
                var iterationPoco = (Iteration)iterationDto.QuerySourceThing();

                JsonFileDalUtils.AddIteration(iterationPoco, ref iterations);

                var iterationSetup = iterationPoco.IterationSetup;
                JsonFileDalUtils.AddIterationSetup(iterationSetup, ref iterationSetups);

                var iterationRequiredRls = iterationPoco.RequiredRdls;
                JsonFileDalUtils.AddReferenceDataLibraries(iterationRequiredRls, ref siteReferenceDataLibraries, ref modelReferenceDataLibraries);

                var engineeringModelSetup = (EngineeringModelSetup)iterationSetup.Container;
                JsonFileDalUtils.AddEngineeringModelSetup(engineeringModelSetup, ref engineeringModelSetups);

                if (siteDirectory == null)
                {
                    siteDirectory = (SiteDirectory)engineeringModelSetup.Container;
                }

                // add the domains-of-expertise that are to be included in the File
                JsonFileDalUtils.AddDomainsOfExpertise(engineeringModelSetup, ref domainOfExpertises);

                // add the Persons that are to be included in the File
                JsonFileDalUtils.AddPersons(engineeringModelSetup, ref persons, ref personRoles, ref participantRoles, ref organizations, ref participants);

                // add organizations that are referrenced by ReferencedSource
                JsonFileDalUtils.AddOrganizations(iterationRequiredRls, ref organizations);
            }

            var path = this.Session.Credentials.Uri.LocalPath;

            var prunedSiteDirectoryDtos = JsonFileDalUtils.CreateSiteDirectoryAndPrunedContainedThingDtos(
                    siteDirectory,
                    siteReferenceDataLibraries,
                    domainOfExpertises,
                    persons,
                    personRoles,
                    participantRoles,
                    organizations,
                    engineeringModelSetups,
                    iterationSetups)
                .ToList();

            //Get all SRDL and contained DTO's
            var siteReferenceDataLibraryData = this.GetSiteReferenceDataLibraryDtos(siteReferenceDataLibraries);

            //Get all MRDL and contained DTO's
            var modelReferenceDataLibraryData = this.GetModelReferenceDataLibraryDtos(modelReferenceDataLibraries);

            //Get all Iteration and contained DTO's
            var iterationData = this.GetIterationDtos(iterations);

            //Create one big list of all DTO's that are involved in this export
            var allDtos = prunedSiteDirectoryDtos
                .Union(siteReferenceDataLibraryData.SelectMany(x => x.Value))
                .Union(modelReferenceDataLibraryData.SelectMany(x => x.Value))
                .Union(iterationData.SelectMany(x => x.Value))
                .ToList();

            //Remove non-supported version things. Like Classes and instances of reference types (for example SampledFunctionParameterType)
            allDtos = this.RemoveNonSupportedVersionThings(allDtos).ToList();

            // Remove all Unlinked mandatory data. This is kind of a recursive method that checks for objects that should be removed because of unfound references. 
            // As long as objects are being removed we need to check the whole list of all DTO's if that leads to other removals.
            allDtos = this.RemoveUnlinkedMandatoryReferences(allDtos).ToList();

            // Remove all unlinked references from DTO's. This does not lead to DTO's being removed from the export.
            // Only references are checked.
            this.TryRemoveUnlinkedReferences(allDtos);

            // Check if prunedSiteDirectory objects are still present in allDtos, otherwise remove then
            prunedSiteDirectoryDtos = prunedSiteDirectoryDtos.Intersect(allDtos).ToList();

            // Check if siteReferenceDataLibraryData objects are still present in allDtos, otherwise remove then
            foreach (var key in siteReferenceDataLibraryData.Keys.ToList())
            {
                var value = siteReferenceDataLibraryData[key];
                siteReferenceDataLibraryData.Remove(key);
                siteReferenceDataLibraryData.Add(key, value.Intersect(allDtos));
            }

            // Check if modelReferenceDataLibraryData objects are still present in allDtos, otherwise remove then
            foreach (var key in modelReferenceDataLibraryData.Keys.ToList())
            {
                var value = modelReferenceDataLibraryData[key];
                modelReferenceDataLibraryData.Remove(key);
                modelReferenceDataLibraryData.Add(key, value.Intersect(allDtos));
            }

            // Check if iterationData objects are still present in allDtos, otherwise remove then
            foreach (var key in iterationData.Keys.ToList())
            {
                var value = iterationData[key];
                iterationData.Remove(key);
                iterationData.Add(key, value.Intersect(allDtos));
            }

            var activePerson = JsonFileDalUtils.QueryActivePerson(this.Session.Credentials.UserName, siteDirectory);

            var exchangeFileHeader = this.FileHeader as ExchangeFileHeader ?? JsonFileDalUtils.CreateExchangeFileHeader(activePerson);

            try
            {
                using (var zipFile = new ZipFile())
                {
                    zipFile.Password = this.Session.Credentials.Password;

                    this.WriteHeaderToZipFile(exchangeFileHeader, zipFile, path);

                    this.WriteSiteDirectoryToZipFile(prunedSiteDirectoryDtos, zipFile, path);

                    this.WriteSiteReferenceDataLibraryToZipFile(siteReferenceDataLibraryData, zipFile, path);

                    this.WriteModelReferenceDataLibraryToZipFile(modelReferenceDataLibraryData, zipFile, path);

                    this.WriteIterationsToZipFile(iterationData, zipFile, path);

                    //ToDo: GH283: Remove extensionsFiles that are referenced by removed instances
                    this.WriteExtensionFilesToZipFile(extensionFiles, zipFile, path);
                }

                Logger.Info("Successfully exported the open session {1} to {0}.", path, this.Session.Credentials.Uri);
            }
            catch (Exception ex)
            {
                Logger.Error("Failed to export the open session to {0}. Error: {1}", path, ex.Message);
                throw new ModelErrorException($"Failed to export the open session to {path}. Error: {ex.Message}");
            }

            return Task.FromResult(Enumerable.Empty<Thing>());
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
        public override Task<LongRunningTaskResult> Write(OperationContainer operationContainer, int waitTime, IEnumerable<string> files = null)
        {
            throw new NotSupportedException("Long Running Task not supported");
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            throw new NotSupportedException("Writing OperationContainer to the data-source is not supported");
        }

        /// <summary>
        /// Find not supported things by model version
        /// </summary>
        /// <param name="allDtos">A list of <see cref="Thing"/>s where to find incompatible objects in</param>
        /// <returns>A collection of not supported things based on their model version</returns>
        private IEnumerable<Thing> RemoveNonSupportedVersionThings(IEnumerable<Thing> allDtos)
        {
            var filterOutObjects = new List<Thing>();
            var dtosToCheck = allDtos.ToList();

            foreach (var thing in dtosToCheck)
            {
                var typeName = thing.ClassKind.ToString();
                var classVersion = new Version(this.MetaDataProvider.GetClassVersion(typeName));

                if (classVersion > this.DalVersion)
                {
                    filterOutObjects.Add(thing);
                }

                if (!this.thingConverterExtensions.AssertSerialization(thing, this.MetaDataProvider, this.DalVersion))
                {
                    filterOutObjects.Add(thing);
                }
            }

            return dtosToCheck.Except(filterOutObjects);
        }

        /// <summary>
        /// Find not supported things by model version
        /// </summary>
        /// <param name="allDtos">A list of <see cref="Thing"/>s where to find incompatible objects in</param>
        /// <returns>A collection of not supported things based on their model version</returns>
        private IEnumerable<Thing> RemoveUnlinkedMandatoryReferences(IEnumerable<Thing> allDtos)
        {
            var dtosToCheck = allDtos.ToList();
            var iidsToCheck = new HashSet<Guid>(allDtos.Select(x => x.Iid));

            var allThingsToRemove = new List<Thing>();

            while (true)
            {
                var newThingsToRemove = new HashSet<Guid>();

                foreach (var thing in dtosToCheck.ToList())
                {
                    if (thing.HasMandatoryReferenceNotIn(iidsToCheck))
                    {
                        allThingsToRemove.Add(thing);
                        newThingsToRemove.Add(thing.Iid);
                    }
                }

                if (newThingsToRemove.Any())
                {
                    dtosToCheck = dtosToCheck.Where(x => !newThingsToRemove.Contains(x.Iid)).ToList();
                    iidsToCheck.RemoveWhere(x => newThingsToRemove.Contains(x));
                }
                else
                {
                    break;
                }
            }

            return dtosToCheck.Except(allThingsToRemove);
        }

        /// <summary>
        /// Tries to remove reference properties for all DTO's involved in the Annex.C3 export.
        /// </summary>
        /// <param name="allDtos">A collection of <see cref="Thing"/>s that are involved in the Annex.C3 export.</param>
        /// <exception cref="ModelErrorException">If a property cannot be removed because that would lead to model errors, this exception is thrown</exception>
        private void TryRemoveUnlinkedReferences(IEnumerable<CDP4Common.DTO.Thing> allDtos)
        {
            var dtos = allDtos.ToList();
            var dtoIids = dtos.Select(x => x.Iid).ToList();

            foreach (var dto in dtos.ToList())
            {
                if (!dto.TryRemoveReferencesNotIn(dtoIids, out var errors))
                {
                    throw new ModelErrorException($"Removing unlinked references from {dto.ClassKind} was not successfull.\nErrors detected:\n {string.Join("\n", errors)}");
                }
            }
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
            // only read Iterations,  domains or site reference data libraries in a file Dal
            if (!(thing is CDP4Common.DTO.Iteration) && !(thing is CDP4Common.DTO.SiteReferenceDataLibrary) && !(thing is CDP4Common.DTO.DomainOfExpertise))
            {
                throw new NotSupportedException("The JSONFileDal only supports Read on Iteration, SiteReferenceDataLibrary and DomainOfExpertise instances.");
            }

            if (this.Credentials.Uri == null)
            {
                throw new ArgumentNullException(nameof(this.Credentials.Uri), $"The Credentials URI may not be null");
            }

            // make sure that the uri is of the correct format
            UriExtensions.AssertUriIsFileSchema(this.Credentials.Uri);

            var filePath = this.Credentials.Uri.LocalPath;

            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException($"The specified filepath does not exist or you do not have access to it: {filePath}");
            }

            try
            {
                // re-read the to extract the reference data libraries that have not yet been fully dereferenced
                // and that are part of the required RDL's
                var siteDirectoryData = this.ReadSiteDirectoryJson(filePath, this.Credentials).ToList();

                // read file, SiteDirectory first.
                using (var zip = ZipFile.Read(filePath))
                {
                    // get all relevant info from the selected iteration
                    var siteDir = this.Session.RetrieveSiteDirectory();

                    var returned = new List<Thing>();

                    switch (thing.ClassKind)
                    {
                        case ClassKind.Iteration:
                            returned = this.RetrieveIterationThings(thing as CDP4Common.DTO.Iteration, siteDirectoryData, zip, siteDir);
                            break;
                        case ClassKind.SiteReferenceDataLibrary:
                            returned = this.RetrieveSRDLThings(thing as CDP4Common.DTO.SiteReferenceDataLibrary, siteDirectoryData, zip, siteDir);
                            break;
                        case ClassKind.DomainOfExpertise:
                            returned = this.RetrieveDomainOfExpertiseThings(thing as CDP4Common.DTO.DomainOfExpertise, siteDirectoryData);
                            break;
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
        public override async Task<IEnumerable<Thing>> Read(CDP4Common.DTO.Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            return await this.Read((Thing)iteration, cancellationToken, attributes);
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
        public override Task<IEnumerable<CDP4Common.DTO.EngineeringModel>> Read(IEnumerable<CDP4Common.DTO.EngineeringModel> engineeringModels, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("The Read EngineeringModel operation is not supported");
        }

        /// <summary>
        /// Reads the <see cref="CometTask" /> identified by the provided <see cref="Guid" />
        /// </summary>
        /// <param name="id">The <see cref="CometTask" /> identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>The read <see cref="CometTask" /></returns>
        public override Task<CometTask> ReadCometTask(Guid id, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("Read CometTask by id not supported");
        }

        /// <summary>
        /// Reads all <see cref="CometTask" /> available for the current logged <see cref="CDP4Common.DTO.Person" />
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>All available <see cref="CometTask" /></returns>
        public override Task<IEnumerable<CometTask>> ReadCometTasks(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("Read all available CometTask not supported");
        }

        /// <summary>
        /// Retrieves all data necessary for the transfer of a DomainOfExpertise
        /// </summary>
        /// <param name="domain">The <see cref="CDP4Common.SiteDirectoryData.DomainOfExpertise"/></param>
        /// <param name="siteDirectoryData">All SiteDirectory DTOs</param>
        /// <returns>List of things contained by the particular srdl</returns>
        private List<Thing> RetrieveDomainOfExpertiseThings(CDP4Common.DTO.DomainOfExpertise domain, List<Thing> siteDirectoryData)
        {
            var returned = new List<Thing>();

            // wipe categories to avoide potential RDL irresolvable loop
            domain.Category.Clear();

            returned.Add(domain);

            foreach (var refThing in domain.Alias.ToList())
            {
                var thingDto = siteDirectoryData.FirstOrDefault(s => s.Iid.Equals(refThing)) as CDP4Common.DTO.Alias;

                if (thingDto != null)
                {
                    thingDto.ExcludedPerson.Clear();
                    thingDto.ExcludedDomain.Clear();
                    returned.Add(thingDto);
                }
                else
                {
                    domain.Alias.Remove(refThing);
                }
            }

            foreach (var refThing in domain.HyperLink.ToList())
            {
                var thingDto = siteDirectoryData.FirstOrDefault(s => s.Iid.Equals(refThing)) as CDP4Common.DTO.HyperLink;

                if (thingDto != null)
                {
                    thingDto.ExcludedPerson.Clear();
                    thingDto.ExcludedDomain.Clear();
                    returned.Add(thingDto);
                }
                else
                {
                    domain.HyperLink.Remove(refThing);
                }
            }

            domain.ExcludedPerson.Clear();
            domain.ExcludedDomain.Clear();

            foreach (var refThing in domain.Definition.ToList())
            {
                var thingDto = siteDirectoryData.FirstOrDefault(s => s.Iid.Equals(refThing)) as CDP4Common.DTO.Definition;

                if (thingDto != null)
                {
                    thingDto.ExcludedDomain.Clear();
                    thingDto.ExcludedPerson.Clear();

                    // remove citation due to possible irresolvable loop of references
                    thingDto.Citation.Clear();

                    returned.Add(thingDto);
                }
                else
                {
                    domain.ExcludedPerson.Remove(refThing);
                }
            }

            return returned;
        }

        /// <summary>
        /// Retrieves all data necessary for the transfer of a SRDL
        /// </summary>
        /// <param name="siteRdl">The <see cref="CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary"/></param>
        /// <param name="siteDirectoryData">All SiteDirectory DTOs</param>
        /// <param name="zip">The zip file</param>
        /// <param name="siteDir">The <see cref="SiteDirectory"/> object</param>
        /// <returns>List of things contained by the particular srdl</returns>
        private List<Thing> RetrieveSRDLThings(CDP4Common.DTO.SiteReferenceDataLibrary siteRdl, List<Thing> siteDirectoryData, ZipFile zip, SiteDirectory siteDir)
        {
            var returned = new List<Thing>();

            var srdl = siteDir.SiteReferenceDataLibrary.FirstOrDefault(s => s.Iid.Equals(siteRdl.Iid));

            // load the reference data libraries as per the containment chain
            var requiredRdl = srdl;

            while (requiredRdl != null)
            {
                // add the rdlDto to the returned collection to make sure it's content gets dereferenced
                var requiredRdlDto = siteDirectoryData.Single(x => x.Iid == requiredRdl.Iid);
                returned.Add(requiredRdlDto);

                var siteRdlFilePath = $"{requiredRdl.Iid}.json";
                var siteRdlZipEntry = zip.Entries.SingleOrDefault(x => x.FileName.EndsWith(siteRdlFilePath));
                var siteRdlItems = this.ReadInfoFromArchiveEntry(siteRdlZipEntry, this.Credentials.Password);
                returned.AddRange(siteRdlItems);

                // set the requiredRdl for the next iteration
                requiredRdl = requiredRdl.RequiredRdl;
            }

            return returned;
        }

        /// <summary>
        /// Retrieves all data necessary for the transfer of an iteration
        /// </summary>
        /// <param name="iteration">The <see cref="CDP4Common.EngineeringModelData.Iteration"/></param>
        /// <param name="siteDirectoryData">All SiteDirectory DTOs</param>
        /// <param name="zip">The zip file</param>
        /// <param name="siteDir">The <see cref="SiteDirectory"/> object</param>
        /// <returns>List of things relevant for a particular iteration</returns>
        private List<Thing> RetrieveIterationThings(CDP4Common.DTO.Iteration iteration, List<Thing> siteDirectoryData, ZipFile zip, SiteDirectory siteDir)
        {
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
            returned.AddRange(this.ReadIterationArchiveEntry(iterationZipEntry, this.Credentials.Password));

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
            var modelRdlItems = this.ReadInfoFromArchiveEntry(modelRdlZipEntry, this.Credentials.Password);
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
                var siteRdlItems = this.ReadInfoFromArchiveEntry(siteRdlZipEntry, this.Credentials.Password);
                returned.AddRange(siteRdlItems);

                // set the requiredRdl for the next iteration
                requiredRdl = requiredRdl.RequiredRdl;
            }

            return returned;
        }

        /// <summary>
        /// Reads a physical file from a DataStore
        /// </summary>
        /// <param name="thing">Download a localfile</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <returns>an await-able <see cref="Task"/> that returns a <see cref="byte"/> array.</returns>
        public override Task<byte[]> ReadFile(Thing thing, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("The ReadFile operation is not supported by the file datasource.");
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
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials.Uri", $"The Credentials URI may not be null");
            }

            // make sure that the uri is of the correct format
            UriExtensions.AssertUriIsFileSchema(credentials.Uri);

            var filePath = credentials.Uri.LocalPath;

            if (!System.IO.File.Exists(filePath))
            {
                throw new FileLoadException($"The specified filepath does not exist or you do not have access to it: {filePath}");
            }

            try
            {
                var returned = this.ReadSiteDirectoryJson(filePath, credentials).ToList();

                Logger.Debug("The SiteDirectory contains {0} Things", returned.Count);

                // check for credentials in the returned DTO's to see if the current Person is authorised to look into this SiteDirectory
                var person = returned.SingleOrDefault(p =>
                        p.ClassKind == ClassKind.Person &&
                        ((CDP4Common.DTO.Person)p).ShortName == credentials.UserName) as
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
        /// Cherry pick <see cref="Thing"/>s contained into an <see cref="CDP4Common.DTO.Iteration"/> that match provided <see cref="CDP4Common.DTO.Category"/> and <see cref="ClassKind"/>
        /// filter
        /// </summary>
        /// <param name="engineeringModelId">The <see cref="Guid"/> of the <see cref="CDP4Common.DTO.EngineeringModel"/></param>
        /// <param name="iterationId">The <see cref="Guid"/> of the <see cref="CDP4Common.DTO.Iteration"/></param>
        /// <param name="classKinds">A collection of <see cref="ClassKind"/></param>
        /// <param name="categoriesId">A collection of <see cref="CDP4Common.DTO.Category"/> <see cref="Guid"/>s</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{T}" /> of type <see cref="IEnumerable{T}"/> of read <see cref="Thing" /></returns>
        public override Task<IEnumerable<Thing>> CherryPick(Guid engineeringModelId, Guid iterationId, IEnumerable<ClassKind> classKinds, IEnumerable<Guid> categoriesId, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("CherryPick is not supported");
        }

        /// <summary>
        /// Validates that the correctness of the <paramref name="operationContainers"/>
        /// </summary>
        /// <param name="operationContainers">
        /// The <see cref="IEnumerable{OperationContainer}"/> to validate
        /// </param>
        private void ValidateOperationContainers(IEnumerable<OperationContainer> operationContainers)
        {
            if (operationContainers == null)
            {
                throw new ArgumentNullException(nameof(operationContainers), "The operationContainer may not be null");
            }

            if (!operationContainers.Any())
            {
                throw new ArgumentException("The operationContainers may not be empty", nameof(operationContainers));
            }

            if (operationContainers.Any(operationContainer => !operationContainer.Operations.Any()))
            {
                throw new ArgumentException("None of the OperationContainers contain Operations", nameof(operationContainers));
            }

            foreach (var operationContainer in operationContainers)
            {
                if (operationContainer.Operations.Any(operation => operation.ModifiedThing.GetType() != typeof(CDP4Common.DTO.Iteration)))
                {
                    throw new ArgumentException($"Only instances of Things of type {typeof(CDP4Common.DTO.Iteration).Name} are eligible for export", nameof(operationContainers));
                }
            }
        }

        /// <summary>
        /// Write the header file to the zip export archive.
        /// </summary>
        /// <param name="echExchangeFileHeader">
        /// The <see cref="ExchangeFileHeader"/> that is to be written to the <paramref name="zipFile"/>
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
        private void WriteSiteDirectoryToZipFile(IEnumerable<Thing> prunedSiteDirectoryContents, ZipFile zipFile, string filePath)
        {
            using (var memoryStream = new MemoryStream())
            {
                var orderedContents = prunedSiteDirectoryContents.OrderBy(x => x.Iid, this.guidComparer);

                this.Serializer.SerializeToStream(orderedContents, memoryStream);

                using (var outputStream = new MemoryStream(memoryStream.ToArray()))
                {
                    var zipEntry = zipFile.AddEntry("SiteDirectory.json", outputStream);
                    zipEntry.Comment = "The SiteDirectory for this file based source";
                    zipFile.Save(filePath);
                }
            }
        }

        /// <summary>
        /// Retrieves all the <see cref="CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary"/> DTO's
        /// </summary>
        /// <param name="siteReferenceDataLibraries">
        /// The <see cref="CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary"/>s
        private Dictionary<SiteReferenceDataLibrary, IEnumerable<Thing>> GetSiteReferenceDataLibraryDtos(IEnumerable<SiteReferenceDataLibrary> siteReferenceDataLibraries)
        {
            var result = new Dictionary<SiteReferenceDataLibrary, IEnumerable<Thing>>();

            foreach (var siteReferenceDataLibrary in siteReferenceDataLibraries)
            {
                var containmentPocos = siteReferenceDataLibrary.QueryContainedThingsDeep().ToList();

                if (containmentPocos.Contains(siteReferenceDataLibrary))
                {
                    containmentPocos.Remove(siteReferenceDataLibrary);
                }

                var dtos =
                    containmentPocos
                        .Select(poco => poco.ToDto())
                        .OrderBy(x => x.Iid, this.guidComparer)
                        .ToList();

                result.Add(siteReferenceDataLibrary, dtos);
            }

            return result;
        }

        /// <summary>
        /// Writes <see cref="CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary"/>s to the <see cref="ZipFile"/>
        /// </summary>
        /// <param name="siteReferenceDataLibraries">
        /// The <see cref="Dictionary{SiteReferenceDataLibrary, Dtos}"/> that contains the <see cref="CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary"/>s and related Dtos that are to be written to the <see cref="ZipFile"/>
        /// </param>
        /// <param name="zipFile">
        /// The target <see cref="ZipFile"/> that the <paramref name="siteReferenceDataLibraries"/> are written to.
        /// </param>
        /// <param name="filePath">
        /// The file of the target <see cref="ZipFile"/>
        /// </param>
        private void WriteSiteReferenceDataLibraryToZipFile(Dictionary<SiteReferenceDataLibrary, IEnumerable<Thing>> siteReferenceDataLibraries, ZipFile zipFile, string filePath)
        {
            foreach (var siteReferenceDataLibrary in siteReferenceDataLibraries)
            {
                using (var memoryStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(siteReferenceDataLibrary.Value, memoryStream);

                    using (var outputStream = new MemoryStream(memoryStream.ToArray()))
                    {
                        var siteReferenceDataLibraryFilename = $"{SiteRdlZipLocation}\\{siteReferenceDataLibrary.Key.Iid}.json";
                        var zipEntry = zipFile.AddEntry(siteReferenceDataLibraryFilename, outputStream);
                        zipEntry.Comment = $"The {siteReferenceDataLibrary.Key.ShortName} SiteReferenceDataLibrary";
                        zipFile.Save(filePath);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary"/>s DTO's
        /// </summary>
        /// <param name="modelReferenceDataLibraries">
        /// The <see cref="CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary"/>s
        /// </param>
        private Dictionary<ModelReferenceDataLibrary, IEnumerable<Thing>> GetModelReferenceDataLibraryDtos(IEnumerable<ModelReferenceDataLibrary> modelReferenceDataLibraries)
        {
            var result = new Dictionary<ModelReferenceDataLibrary, IEnumerable<Thing>>();

            foreach (var modelReferenceDataLibrary in modelReferenceDataLibraries)
            {
                var containmentPocos = modelReferenceDataLibrary.QueryContainedThingsDeep().ToList();

                if (containmentPocos.Contains(modelReferenceDataLibrary))
                {
                    containmentPocos.Remove(modelReferenceDataLibrary);
                }

                var dtos =
                    containmentPocos
                        .Select(poco => poco.ToDto())
                        .OrderBy(x => x.Iid, this.guidComparer)
                        .ToList();

                result.Add(modelReferenceDataLibrary, dtos);
            }

            return result;
        }

        /// <summary>
        /// Writes the <see cref="CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary"/> to the <see cref="ZipFile"/>
        /// </summary>
        /// <param name="modelReferenceDataLibraries">
        /// The <see cref="Dictionary{ModelReferenceDataLibrary, Dtos}"/> that contains the <see cref="CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary"/>s and related Dtos that are to be written to the <see cref="ZipFile"/>
        /// </param>
        /// <param name="zipFile">
        /// The target <see cref="ZipFile"/> that the <paramref name="modelReferenceDataLibraries"/> are written to.
        /// </param>
        /// <param name="filePath">
        /// The file of the target <see cref="ZipFile"/>
        /// </param>
        private void WriteModelReferenceDataLibraryToZipFile(Dictionary<ModelReferenceDataLibrary, IEnumerable<Thing>> modelReferenceDataLibraries, ZipFile zipFile, string filePath)
        {
            foreach (var modelReferenceDataLibrary in modelReferenceDataLibraries)
            {
                using (var memoryStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(modelReferenceDataLibrary.Value, memoryStream);

                    using (var outputStream = new MemoryStream(memoryStream.ToArray()))
                    {
                        var modelReferenceDataLibraryFilename = $"{ModelRdlZipLocation}\\{modelReferenceDataLibrary.Key.Iid}.json";
                        var zipEntry = zipFile.AddEntry(modelReferenceDataLibraryFilename, outputStream);
                        zipEntry.Comment = $"The {modelReferenceDataLibrary.Key.ShortName} ModelReferenceDataLibrary";
                        zipFile.Save(filePath);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the <see cref="CDP4Common.EngineeringModelData.Iteration"/> and related DTO's.
        /// </summary>
        /// <param name="iterations">
        /// The <see cref="CDP4Common.EngineeringModelData.Iteration"/>s
        /// </param>
        private Dictionary<Iteration, IEnumerable<Thing>> GetIterationDtos(IEnumerable<Iteration> iterations)
        {
            var result = new Dictionary<Iteration, IEnumerable<Thing>>();

            foreach (var iteration in iterations)
            {
                var containmentPocos = iteration.QueryContainedThingsDeep();

                var dtos =
                    containmentPocos
                        .Select(poco => poco.ToDto())
                        .OrderBy(x => x.Iid, this.guidComparer)
                        .ToList();

                result.Add(iteration, dtos);
            }

            return result;
        }

        /// <summary>
        /// Writes the <see cref="CDP4Common.EngineeringModelData.Iteration"/> to the <see cref="ZipFile"/>
        /// </summary>
        /// <param name="iterations">
        /// The <see cref="Dictionary{Iteration, Dtos}"/> that contains the <see cref="CDP4Common.EngineeringModelData.Iteration"/>s and related Dtos that are to be written to the <see cref="ZipFile"/>
        /// The <see cref="CDP4Common.EngineeringModelData.Iteration"/> that are to be written to the <see cref="ZipFile"/>
        /// </param>
        /// <param name="zipFile">
        /// The target <see cref="ZipFile"/> that the <paramref name="iterations"/> are written to.
        /// </param>
        /// <param name="filePath">
        /// The file of the target <see cref="ZipFile"/>
        /// </param>
        private void WriteIterationsToZipFile(Dictionary<Iteration, IEnumerable<Thing>> iterations, ZipFile zipFile, string filePath)
        {
            var engineeringModels = new List<EngineeringModel>();

            foreach (var iteration in iterations)
            {
                var engineeringModel = (EngineeringModel)iteration.Key.Container;
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

                using (var iterationMemoryStream = new MemoryStream())
                {
                    this.Serializer.SerializeToStream(iteration.Value, iterationMemoryStream);

                    using (var outputStream = new MemoryStream(iterationMemoryStream.ToArray()))
                    {
                        var iterationFilename = $@"{EngineeringModelZipLocation}\{engineeringModelDto.Iid}\{IterationZipLocation}\{iteration.Key.Iid}.json";
                        var iterationZipEntry = zipFile.AddEntry(iterationFilename, outputStream);
                        iterationZipEntry.Comment = $"The {iteration.Key.IterationSetup.IsDeleted} Iteration";
                        zipFile.Save(filePath);
                    }
                }
            }
        }

        /// <summary>
        ///  Writes the application dependend files inside specific folder to the <see cref="ZipFile"/>
        /// </summary>
        /// <param name="extraFilesPath">The files list that will be written</param>
        /// <param name="zipFile">The target <see cref="ZipFile"/></param>
        /// <param name="filePath">The file path of the target <see cref="ZipFile"/></param>
        private void WriteExtensionFilesToZipFile(IEnumerable<string> extraFilesPath, ZipFile zipFile, string filePath)
        {
            if (extraFilesPath is null)
            {
                return;
            }

            foreach (var extraFile in extraFilesPath)
            {
                var zipEntry = zipFile.AddFile(extraFile, ExtensionsZipLocation);
                zipEntry.Comment = $"The {extraFile} file";
            }

            zipFile.Save(filePath);
        }

        /// <summary>
        /// Reads SiteDirectory data from the archive
        /// </summary>
        /// <param name="filePath">
        /// the file path to the archive
        /// </param>
        /// <param name="credentials">
        /// the <see cref="Credentials"/> used to read the archive
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{Thing}"/> containing <see cref="CDP4Common.SiteDirectoryData.SiteDirectory"/> data
        /// </returns>
        private IEnumerable<Thing> ReadSiteDirectoryJson(string filePath, Credentials credentials)
        {
            using (var zip = ZipFile.Read(filePath))
            {
                // read SiteDirectory
                var siteDirectoryFilePath = "SiteDirectory.json";
                var siteDirectoryZipEntry = zip.Entries.SingleOrDefault(x => x.FileName.EndsWith(siteDirectoryFilePath));
                var returned = this.ReadInfoFromArchiveEntry(siteDirectoryZipEntry, credentials.Password);

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
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private List<Thing> ReadIterationArchiveEntry(ZipEntry zipEntry, string archivePassword)
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
        /// <returns>
        /// A <see cref="List{Thing}"/>
        /// </returns>
        /// <exception cref="Exception">
        /// throws exception if the file failed to open
        /// </exception>
        private List<Thing> ReadInfoFromArchiveEntry(ZipEntry zipEntry, string archivePassword)
        {
            if (zipEntry == null)
            {
                throw new ArgumentNullException(nameof(zipEntry), "Supplied archive entry is invalid.");
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
            Logger.Info("ZipEntry {0} retrieved in {1} [ms]", zipEntry.FileName, watch.ElapsedMilliseconds);

            watch = Stopwatch.StartNew();

            stream.Position = 0;
            var returned = this.Serializer.Deserialize(stream).ToList();

            stream.Dispose();
            watch.Stop();
            Logger.Info("JSON Deserializer of {0} completed in {1} [ms]", zipEntry.FileName, watch.ElapsedMilliseconds);
            return returned;
        }
    }
}
