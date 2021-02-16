// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Session.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4Dal.DAL;
    using CDP4Dal.Events;
    using CDP4Dal.Operations;
    using CDP4Dal.Permission;

    using NLog;

    /// <summary>
    /// The <see cref="Session"/> class encapsulates the <see cref="DAL.Credentials"/>, <see cref="IDal"/> and <see cref="CDP4Dal.Assembler"/>
    /// that constitute a user session with a data-source
    /// </summary>
    public class Session : ISession
    {
        /// <summary>
        /// Executes just before data from an <see cref="OperationContainer"/> is written to the datastore.
        /// </summary>
        public event EventHandler<BeforeWriteEventArgs> BeforeWrite;

        /// <summary>
        /// The NLog logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The cancellation token source dictionary.
        /// </summary>
        private ConcurrentDictionary<Guid, CancellationTokenSource> cancellationTokenSourceDictionary;

        /// <summary>
        /// Backing field for <see cref="OpenReferenceDataLibraries"/>
        /// </summary>
        private readonly List<ReferenceDataLibrary> openReferenceDataLibraries;

        /// <summary>
        /// Contains the open <see cref="Iteration"/> along with the active <see cref="DomainOfExpertise"/> and <see cref="Participant"/>
        /// </summary>
        private readonly Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> openIterations;

        /// <summary>
        /// Initializes a new instance of the <see cref="Session"/> class.
        /// </summary>
        /// <param name="dal">
        /// the associated <see cref="IDal"/> that is used to communicate with the data-source
        /// </param>
        /// <param name="credentials">
        /// the <see cref="DAL.Credentials"/> associated to the <see cref="IDal"/>
        /// </param>
        public Session(IDal dal, Credentials credentials)
        {
            this.Credentials = credentials;
            this.Dal = dal;
            this.Dal.Session = this;
            this.Assembler = new Assembler(credentials.Uri);
            this.PermissionService = new PermissionService(this);
            this.openReferenceDataLibraries = new List<ReferenceDataLibrary>();
            this.openIterations = new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>>();
            this.cancellationTokenSourceDictionary = new ConcurrentDictionary<Guid, CancellationTokenSource>();
        }

        /// <summary>
        /// Gets the <see cref="Credentials"/> that are use to connect to the data source
        /// </summary>
        public Credentials Credentials { get; private set; }

        /// <summary>
        /// Gets the <see cref="IPermissionService"/> that handles access permissions for this <see cref="ISession"/>.
        /// </summary>
        public IPermissionService PermissionService { get; private set; }

        /// <summary>
        /// Gets the <see cref="IDal"/> that the current <see cref="Session"/> communicates with
        /// </summary>
        public IDal Dal { get; private set; }

        /// <summary>
        /// Gets the version of the data-model that is supported by the associated <see cref="Dal"/>
        /// </summary>
        public Version DalVersion => this.Dal.DalVersion;

        /// <summary>
        /// Asserts whether the <see cref="Version"/> is supported by the connected <see cref="ISession.Dal"/>
        /// </summary>
        /// <param name="version">
        /// The <see cref="Version"/> that is checked
        /// </param>
        /// <returns>
        /// true if the version is supported, false if not
        /// </returns>
        /// <remarks>
        /// A <see cref="Version"/> is supported when it is lower or equal than the <see cref="Version"/> of the connected <see cref="ISession.Dal"/>
        /// </remarks>
        public bool IsVersionSupported(Version version)
        {
            var comparison = version.CompareTo(this.DalVersion);
            return comparison <= 0;
        }

        /// <summary>
        /// Gets the active <see cref="Person"/> in this <see cref="Session"/>
        /// </summary>
        public Person ActivePerson { get; private set; }

        /// <summary>
        /// Retrieves the <see cref="Participant"/>s from the <see cref="Iteration"/>s that are currently open
        /// and that the current active <see cref="Person"/> is associated to.
        /// </summary>
        public IEnumerable<Participant> ActivePersonParticipants
        {
            get
            {
                foreach (var openIteration in this.openIterations)
                {
                    yield return openIteration.Value.Item2;
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="CDP4Dal.Assembler"/> associated with the current <see cref="Session"/> containing the Cache
        /// </summary>
        public Assembler Assembler { get; private set; }

        /// <summary>
        /// Gets the uri of the connected data-source
        /// </summary>
        public string DataSourceUri
        {
            get
            {
                if (this.Credentials != null)
                {
                    return this.Credentials.Uri.ToString();
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the name of the session which is the concatentation of the data-source uri and the active person
        /// </summary>
        public string Name
        {
            get
            {
                var personName = this.ActivePerson != null ? this.ActivePerson.Name : string.Empty;
                return $"{this.DataSourceUri} - {personName}";
            }
        }

        /// <summary>
        /// Gets the list of <see cref="ReferenceDataLibrary"/> that are currently open in the running application.
        /// </summary>
        public IEnumerable<ReferenceDataLibrary> OpenReferenceDataLibraries => this.openReferenceDataLibraries;

        /// <summary>
        /// Gets the list of <see cref="Iteration"/>s that are currently open with the active <see cref="DomainOfExpertise"/> and <see cref="Participant"/>
        /// </summary>
        public IReadOnlyDictionary<Iteration, Tuple<DomainOfExpertise, Participant>> OpenIterations => this.openIterations;

        /// <summary>
        /// Retrieves the <see cref="SiteDirectory"/> in the context of the current session
        /// </summary>
        /// <returns>
        /// The instance <see cref="SiteDirectory"/> that is loaded in the <see cref="Session"/>
        /// </returns>
        public SiteDirectory RetrieveSiteDirectory()
        {
            return this.Assembler.RetrieveSiteDirectory();
        }

        /// <summary>
        /// Queries the selected <see cref="DomainOfExpertise"/> from the session for provided current <see cref="Iteration"/>
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> for which the selected <see cref="DomainOfExpertise"/> is queried.
        /// </param>
        /// <returns>
        /// A <see cref="DomainOfExpertise"/> if has been selected for the <see cref="Iteration"/>, null otherwise.
        /// </returns>
        public DomainOfExpertise QuerySelectedDomainOfExpertise(Iteration iteration)
        {
            var iterationDomainPair = this.OpenIterations.SingleOrDefault(x => x.Key.Iid == iteration.Iid);

            if (iterationDomainPair.Equals(default(KeyValuePair<Iteration, Tuple<DomainOfExpertise, Participant>>)))
            {
                return null;
            }

            return iterationDomainPair.Value == null || iterationDomainPair.Value.Item1 == null ? null : iterationDomainPair.Value.Item1;
        }

        /// <summary>
        /// Queries the <see cref="Participant"/>'s <see cref="DomainOfExpertise"/>'s from the session for the provided <see cref="Iteration"/>
        /// </summary>
        /// <returns>
        /// <param name="iteration">The <see cref="Iteration"/></param>
        /// The <see cref="DomainOfExpertise"/>s for the <see cref="Participant"/> that belongs to the <see cref="Iteration"/> for this <see cref="Session"/>.
        /// </returns>
        public IEnumerable<DomainOfExpertise> QueryDomainOfExpertise(Iteration iteration)
        {
            var iterationDomainPair = this.OpenIterations.SingleOrDefault(x => x.Key.Iid == iteration.Iid);
            var domainOfExpertise = new List<DomainOfExpertise>();

            if (iterationDomainPair.Value?.Item2 != null)
            {
                domainOfExpertise.AddRange(iterationDomainPair.Value.Item2.Domain);
            }

            return domainOfExpertise;
        }

        /// <summary>
        /// Convenience function to get the required reference data library chain for the passed in engineeringModel.
        /// </summary>
        /// <param name="engineeringModel">
        /// The engineering model.
        /// </param>
        /// <returns>
        /// Chain of required reference data libraries for this <see cref="EngineeringModel"/>.
        /// </returns>
        public IEnumerable<ReferenceDataLibrary> GetEngineeringModelRdlChain(EngineeringModel engineeringModel)
        {
            return this.GetEngineeringModelSetupRdlChain(engineeringModel.EngineeringModelSetup);
        }

        /// <summary>
        /// Convenience function to get the required reference data library chain for the passed in engineeringModel.
        /// </summary>
        /// <param name="engineeringModelSetup">
        /// The engineering model setup.
        /// </param>
        /// <returns>
        /// Chain of required reference data libraries for this <see cref="EngineeringModelSetup"/>.
        /// </returns>
        public IEnumerable<ReferenceDataLibrary> GetEngineeringModelSetupRdlChain(EngineeringModelSetup engineeringModelSetup)
        {
            var requiredRdl = engineeringModelSetup.RequiredRdl.SingleOrDefault();
            yield return requiredRdl;

            if (requiredRdl == null)
            {
                yield break;
            }

            foreach (var chainedRdl in requiredRdl.GetRequiredRdls())
            {
                yield return chainedRdl;
            }
        }

        /// <summary>
        /// Open the underlying <see cref="IDal"/> and update the Cache with the retrieved objects.
        /// </summary>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        /// <remarks>
        /// The <see cref="CDPMessageBus"/> is used to send messages to notify listeners of <see cref="Thing"/>s that
        /// have been added to the cache.
        /// </remarks>
        public async Task Open()
        {
            var sw = new Stopwatch();
            sw.Start();
            logger.Info("Open request {0}", this.DataSourceUri);

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            IReadOnlyList<CDP4Common.DTO.Thing> dtoThings;

            try
            {
                dtoThings = (await this.Dal.Open(this.Credentials, cancellationTokenSource.Token)).ToList();
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }
            catch (OperationCanceledException)
            {
                logger.Info("Open request cancelled {0}", this.DataSourceUri);
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
                return;
            }

            if (!dtoThings.Any())
            {
                logger.Warn("no data returned upon Open on {0}", this.DataSourceUri);
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await this.Assembler.Synchronize(dtoThings);

            this.ActivePerson = this.Assembler.Cache.Select(x => x.Value)
                .Select(lazy => lazy.Value)
                .OfType<Person>()
                .SingleOrDefault(pers => pers.ShortName == this.Credentials.UserName);

            if (this.ActivePerson == null)
            {
                // clear cache
                await this.Assembler.Clear();

                throw new IncompleteModelException("The Person object that matches the user specified in the Credentials could not be found");
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));

            logger.Info("Synchronization with the {0} server done in {1} [ms]", this.DataSourceUri, sw.ElapsedMilliseconds);

            var sessionChange = new SessionEvent(this, SessionStatus.Open);
            CDPMessageBus.Current.SendMessage(sessionChange);

            logger.Info("Session {0} opened successfully in {1} [ms]", this.DataSourceUri, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Switches the current domain for an iteration
        /// </summary>
        /// <param name="iterationId">The iteration identifier</param>
        /// <param name="domain">The domain</param>
        public void SwitchDomain(Guid iterationId, DomainOfExpertise domain)
        {
            var iterationPair = this.openIterations.SingleOrDefault(x => x.Key.Iid == iterationId);

            if (iterationPair.Key != null && iterationPair.Value.Item1 != domain)
            {
                var selectedParticipation = new Tuple<DomainOfExpertise, Participant>(domain, iterationPair.Value.Item2);
                this.openIterations.Remove(iterationPair.Key);
                this.openIterations.Add(iterationPair.Key, selectedParticipation);
                CDPMessageBus.Current.SendMessage(new DomainChangedEvent(iterationPair.Key, domain));
            }
        }

        /// <summary>
        /// Read an <see cref="Iteration"/> from the underlying <see cref="IDal"/> and set the active <see cref="DomainOfExpertise"/> for the <see cref="Iteration"/>.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to read</param>
        /// <param name="domain">The active <see cref="DomainOfExpertise"/> for the <see cref="Iteration"/></param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        /// <remarks>
        /// The Cache is updated with the returned objects and the <see cref="CDPMessageBus"/> is used to send messages to notify listeners of updates to the Cache
        /// </remarks>
        public async Task Read(Iteration iteration, DomainOfExpertise domain)
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException("The Iteration cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            // check if iteration is already open
            // if so check that the domain is not different
            var iterationDomainPair = this.openIterations.SingleOrDefault(x => x.Key.Iid == iteration.Iid);

            if (!iterationDomainPair.Equals(default(KeyValuePair<Iteration, Tuple<DomainOfExpertise, Participant>>)))
            {
                if (iterationDomainPair.Value.Item1 != domain)
                {
                    throw new InvalidOperationException("The iteration is already open with another domain.");
                }
            }

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            IEnumerable<CDP4Common.DTO.Thing> dtoThings;

            try
            {
                var iterationDto = (CDP4Common.DTO.Iteration) iteration.ToDto();
                this.Dal.Session = this;
                dtoThings = await this.Dal.Read(iterationDto, cancellationTokenSource.Token, null);
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read {0} {1} cancelled", iteration.ClassKind, iteration.Iid);
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
                return;
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }

            // proceed if no problem
            var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();

            if (!enumerable.Any())
            {
                logger.Warn("no data returned upon Read on {0}", this.DataSourceUri);
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await this.Assembler.Synchronize(enumerable);

            this.AddIterationToOpenList(iteration.Iid, domain);

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            logger.Info("Synchronization with the {0} server done", this.DataSourceUri);
        }

        /// <summary>
        /// Read a <see cref="ReferenceDataLibrary"/> from the underlying <see cref="IDal"/>
        /// </summary>
        /// <param name="rdl">The <see cref="ReferenceDataLibrary"/> to read</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        /// <remarks>
        /// The Cache is updated with the returned objects and the <see cref="CDPMessageBus"/> is used to send messages to notify listeners of updates to the Cache
        /// </remarks>
        public async Task Read(ReferenceDataLibrary rdl)
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException("The ReferenceDataLibrary cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            await this.Read((Thing) rdl);
            this.AddRdlToOpenList(rdl);
        }

        /// <summary>
        /// Read a <see cref="Thing"/> in the associated <see cref="IDal"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        public async Task Read(Thing thing)
        {
            await this.Read(thing, null);
        }

        /// <summary>
        /// Read a <see cref="Thing"/> in the associated <see cref="IDal"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read</param>
        /// <param name="queryAttributes">The <see cref="IQueryAttributes"/> to be used to read data</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        public async Task Read(Thing thing, IQueryAttributes queryAttributes)
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException($"The {thing.ClassKind} cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            logger.Info("Session.Read {0} {1}", thing.ClassKind, thing.Iid);
            var dto = thing.ToDto();

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            IEnumerable<CDP4Common.DTO.Thing> dtoThings;

            try
            {
                dtoThings = await this.Dal.Read(dto, cancellationTokenSource.Token, queryAttributes);
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read {0} {1} cancelled", thing.ClassKind, thing.Iid);
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out _);
                return;
            }

            // proceed if no problem
            var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();

            await this.AfterReadOrWriteOrUpdate(enumerable);
        }

        /// <summary>
        /// Read a list of <see cref="Thing"/>s in the associated <see cref="IDal"/>
        /// </summary>
        /// <param name="things">The <see cref="IEnumerable{Thing}"/> that contains the <see cref="Thing"/> to read</param>
        /// <param name="queryAttributes">The <see cref="IQueryAttributes"/> to be used to read data</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        public async Task Read(IEnumerable<Thing> things, IQueryAttributes queryAttributes)
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException($"The data cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            var thingList = things.ToList();

            if (!thingList.Any())
            {
                throw new ArgumentException($"The requested list of things is null or empty.");
            }

            logger.Info("Session.Read {0} things", thingList.Count());

            var foundThings = new List<CDP4Common.DTO.Thing>();

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            try
            {
                // Max 10 async calls at a time, otherwise we could create a sort of a DDOS attack to the DAL/webservice
                var loopCount = 10;

                while (thingList.Any())
                {
                    var tasks = new List<Task<IEnumerable<CDP4Common.DTO.Thing>>>();

                    foreach (var thing in thingList.Take(loopCount))
                    {
                        tasks.Add(this.Dal.Read(thing.ToDto(), cancellationTokenSource.Token, queryAttributes));
                    }

                    var newThings = (await Task.WhenAll(tasks.ToArray())).SelectMany(x => x).ToList();

                    foundThings.AddRange(newThings);

                    thingList = thingList.Skip(loopCount).ToList();
                }

                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read cancelled");
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
                return;
            }

            await this.AfterReadOrWriteOrUpdate(foundThings);
        }

        /// <summary>
        /// Reads a physical file from a DataStore
        /// </summary>
        /// <param name="localFile">Download a localfile</param>
        /// <returns>an await-able <see cref="Task"/> that returns a <see cref="byte"/> array.</returns>
        public async Task<byte[]> ReadFile<T>(T localFile) where T : Thing, ILocalFile
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException($"The {localFile.ClassKind} cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            logger.Info("Session.ReadFile {0} {1}", localFile.ClassKind, localFile.Iid);
            var dto = localFile.ToDto();

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            byte[] fileContent;

            try
            {
                fileContent = await this.Dal.ReadFile(dto, cancellationTokenSource.Token);
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.ReadFile {0} {1} cancelled", localFile.ClassKind, localFile.Iid);
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out _);
                return null;
            }

            return fileContent;
        }

        /// <summary>
        /// Default actions to perform after a read or write action
        /// </summary>
        /// <param name="things"> A list of <see cref="CDP4Common.DTO.Thing"/>s to perform AfterReadOrWriteOrUpdate actions to</param>
        /// <param name="caller">The name of the method calling this method</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        private async Task AfterReadOrWriteOrUpdate(IList<CDP4Common.DTO.Thing> things, [CallerMemberName] string caller = null)
        {
            // proceed if no problem
            if (!things.Any())
            {
                logger.Warn("no data returned upon Read on {0}", this.DataSourceUri);
            }

            var sw = new Stopwatch();
            logger.Info($"Synchronization of DTOs for {caller} from/to server {0} started", this.DataSourceUri);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await this.Assembler.Synchronize(things);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            logger.Info($"Synchronization of DTOs for {caller} from/to server {0} done in {1} [ms]", this.DataSourceUri, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">List of file paths for files to be sent to the datastore</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        public async Task Write(OperationContainer operationContainer, IEnumerable<string> files)
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException($"The Write operation cannot be performed when the ActivePerson is null; The Open method must be called prior to performing a Write.");
            }

            var filesList = files?.ToList();

            if (filesList != null && filesList.Any())
            {
                foreach (var file in filesList)
                {
                    if (!System.IO.File.Exists(file))
                    {
                        throw new FileNotFoundException($"File {file} was not found.");
                    }
                }
            }

            var eventArgs = new BeforeWriteEventArgs(operationContainer, filesList);
            this.BeforeWrite?.Invoke(this, eventArgs);

            if (eventArgs.Cancelled)
            {
                throw new OperationCanceledException($"The Write operation was canceled.");
            }

            this.Dal.Session = this;
            var dtoThings = await this.Dal.Write(operationContainer, filesList);

            var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();

            await this.AfterReadOrWriteOrUpdate(enumerable);
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        public async Task Write(OperationContainer operationContainer)
        {
            await this.Write(operationContainer, null);
        }

        /// <summary>
        /// Refreshes all the <see cref="TopContainer"/>s in the cache
        /// </summary>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        public async Task Refresh()
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException($"The Refresh operation cannot be performed when the ActivePerson is null; The Open method must be called prior to performing a Write.");
            }

            foreach (var topContainer in this.GetSiteDirectoryAndActiveIterations())
            {
                await this.Update(topContainer);
            }
        }

        /// <summary>
        /// Reloads all the <see cref="TopContainer"/>s the in cache
        /// </summary>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        public async Task Reload()
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException($"The Reload operation cannot be performed when the ActivePerson is null; The Open method must be called prior to performing a Write.");
            }

            foreach (var topContainer in this.GetSiteDirectoryAndActiveIterations())
            {
                await this.Update(topContainer, false);
            }
        }

        /// <summary>
        /// Can a Cancel action be executed?
        /// </summary>
        /// <param name="cancellationTokenSource">
        /// Cancellation token source that will be cancelled <see cref="CancellationTokenSource"/>
        /// </param>
        /// <returns>
        /// True if Cancel is allowed, otherwise false.
        /// </returns>
        private static bool CanCancel(CancellationTokenSource cancellationTokenSource)
        {
            if (cancellationTokenSource == null)
            {
                return false;
            }

            return cancellationTokenSource.Token.CanBeCanceled && !cancellationTokenSource.IsCancellationRequested;
        }

        /// <summary>
        /// Can a Cancel action be executed?
        /// </summary>
        /// <returns>
        /// True if Cancel is allowed for at least on token, otherwise false.
        /// </returns>
        public bool CanCancel()
        {
            foreach (var cancellationTokenSourceKey in this.cancellationTokenSourceDictionary.Keys)
            {
                this.cancellationTokenSourceDictionary.TryGetValue(cancellationTokenSourceKey, out var cancellationTokenSource);

                if (!CanCancel(cancellationTokenSource))
                {
                    continue;
                }

                cancellationTokenSource?.Cancel();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Cancel any Read or Open operation.
        /// </summary>
        public void Cancel()
        {
            foreach (var cancellationTokenSourceKey in this.cancellationTokenSourceDictionary.Keys)
            {
                if (CanCancel(this.cancellationTokenSourceDictionary[cancellationTokenSourceKey]))
                {
                    this.cancellationTokenSourceDictionary[cancellationTokenSourceKey].Cancel();
                }
            }
        }

        /// <summary>
        /// Close the underlying <see cref="IDal"/> and clears the encapsulated <see cref="Assembler"/>
        /// </summary>
        public async Task Close()
        {
            this.Dal.Close();
            await this.Assembler.Clear();

            var sessionChange = new SessionEvent(this, SessionStatus.Closed);
            CDPMessageBus.Current.SendMessage(sessionChange);

            logger.Info("Session {0} closed successfully", this.DataSourceUri);
            this.openReferenceDataLibraries.Clear();

            this.ActivePerson = null;
        }

        /// <summary>
        /// Close a <see cref="SiteReferenceDataLibrary"/> and all <see cref="SiteDirectory"/> that depends on it
        /// </summary>
        /// <param name="sRdl">The <see cref="SiteReferenceDataLibrary"/> to close</param>
        /// <returns>The async <see cref="Task"/></returns>
        public async Task CloseRdl(SiteReferenceDataLibrary sRdl)
        {
            // add a delay for the loading panel to appear
            await Task.Delay(10);

            if (!this.openReferenceDataLibraries.Contains(sRdl))
            {
                return;
            }

            // Cannot close a SiteRdl that is required by a ModelRdl
            var mRdls = this.openReferenceDataLibraries.OfType<ModelReferenceDataLibrary>().ToList();

            if (mRdls.Any(modelReferenceDataLibrary => modelReferenceDataLibrary.GetRequiredRdls().Contains(sRdl)))
            {
                return;
            }

            // close all SiteRdl that Requires this SiteRdl
            var sRdls = this.openReferenceDataLibraries.OfType<SiteReferenceDataLibrary>().ToList();
            var sRdlsToClose = sRdls.Where(rdl => rdl.GetRequiredRdls().Contains(sRdl)).ToList();
            sRdlsToClose.Add(sRdl);

            // close from bottom to top
            var orderedRdlsToClose = sRdlsToClose.OrderByDescending(x => x.GetRequiredRdls().Count());

            var tasks = new List<Task>();

            foreach (var siteReferenceDataLibrary in orderedRdlsToClose)
            {
                tasks.Add(this.Assembler.CloseRdl(siteReferenceDataLibrary));
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await Task.WhenAll(tasks);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));

            foreach (var siteReferenceDataLibrary in orderedRdlsToClose)
            {
                this.openReferenceDataLibraries.Remove(siteReferenceDataLibrary);
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.RdlClosed));
        }

        /// <summary>
        /// Read the new content of the <see cref="IDal"/>
        /// </summary>
        /// <param name="thing">
        /// The instance of <see cref="Thing"/> that is to be updated
        /// </param>
        /// <param name="isRefresh">is True if the RevisionNumber is taken into account in the update</param>
        /// <returns>
        /// a <see cref="Task"/> that can be used with await
        /// </returns>
        private async Task Update(Thing thing, bool isRefresh = true)
        {
            var revisionNumber = isRefresh ? thing.RevisionNumber : 0;

            var queryAttribute = new DalQueryAttributes { RevisionNumber = revisionNumber };

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);
            IEnumerable<CDP4Common.DTO.Thing> dtoThings;

            try
            {
                dtoThings = await this.Dal.Read(thing.ToDto(), cancellationTokenSource.Token, queryAttribute);
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }
            catch (OperationCanceledException)
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out _);
                return;
            }

            var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();

            await this.AfterReadOrWriteOrUpdate(enumerable);
        }

        /// <summary>
        /// Close a <see cref="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="modelRdl">
        /// The model RDL.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task CloseModelRdl(ModelReferenceDataLibrary modelRdl)
        {
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await this.Assembler.CloseRdl(modelRdl);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            this.openReferenceDataLibraries.Remove(modelRdl);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.RdlClosed));
        }

        /// <summary>
        /// Close a <see cref="Iteration"/> and its <see cref="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="iterationSetup">
        /// The iteration setup.
        /// </param>
        public async Task CloseIterationSetup(IterationSetup iterationSetup)
        {
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));

            await this.Assembler.CloseIterationSetup(iterationSetup);

            var iterationToRemove = this.openIterations.Select(x => x.Key).SingleOrDefault(x => x.Iid == iterationSetup.IterationIid);

            if (iterationToRemove != null)
            {
                this.openIterations.Remove(iterationToRemove);
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
        }

        /// <summary>
        /// Gets the <see cref="SiteDirectory"/> and all active <see cref="Iteration"/>s from the Assembler's cache for this <see cref="Session"/>
        /// </summary>
        /// <returns>the <see cref="List{T}"/> of the collected <see cref="SiteDirectory"/> and all <see cref="Iteration"/>s from the Assembler's cache for this <see cref="Session"/></returns>
        private IEnumerable<Thing> GetSiteDirectoryAndActiveIterations()
        {
            return this.Assembler.Cache
                .Select(x => x.Value.Value)
                .Where(x =>
                    x is SiteDirectory
                    || x is Iteration && ((Iteration) x).IterationSetup.FrozenOn == null && this.OpenIterations.ContainsKey((Iteration) x)
                )
                .ToList();
        }

        /// <summary>
        /// Add RDL to the openReferenceDataLibraries list.
        /// </summary>
        /// <param name="thing">
        /// The RDL thing to add.
        /// </param>
        private void AddRdlToOpenList(Thing thing)
        {
            Lazy<Thing> lazyThing;
            this.Assembler.Cache.TryGetValue(new CacheKey(thing.Iid, null), out lazyThing);

            if (lazyThing == null)
            {
                return;
            }

            var rdl = lazyThing.Value as ReferenceDataLibrary;

            if (rdl == null)
            {
                return;
            }

            if (this.openReferenceDataLibraries.Contains(rdl))
            {
                return;
            }

            this.openReferenceDataLibraries.Add(rdl);
            this.openReferenceDataLibraries.AddRange(rdl.GetRequiredRdls().Except(this.openReferenceDataLibraries));

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.RdlOpened));
        }

        /// <summary>
        /// Add an open <see cref="Iteration"/> along its active <see cref="DomainOfExpertise"/>
        /// </summary>
        /// <param name="iterationId">The <see cref="Guid"/> of the open <see cref="Iteration"/></param>
        /// <param name="activeDomain">The active <see cref="DomainOfExpertise"/> in this <see cref="Session"/></param>
        private void AddIterationToOpenList(Guid iterationId, DomainOfExpertise activeDomain)
        {
            Lazy<Thing> lazyIteraion;
            this.Assembler.Cache.TryGetValue(new CacheKey(iterationId, null), out lazyIteraion);

            if (lazyIteraion == null)
            {
                return;
            }

            var iteration = lazyIteraion.Value as Iteration;

            if (iteration == null)
            {
                logger.Warn("The iteration {iterationId} is not present in the Cache and is therefore not added to the OpenIterations", iterationId);
                return;
            }

            if (this.openIterations.ContainsKey(iteration))
            {
                return;
            }

            var activeParticipant = ((EngineeringModel) iteration.Container).EngineeringModelSetup.Participant.SingleOrDefault(p => p.Person == this.ActivePerson);

            if (activeParticipant == null)
            {
                throw new InvalidOperationException("The iteration does not have an active associated participant.");
            }

            this.openIterations.Add(iteration, new Tuple<DomainOfExpertise, Participant>(activeDomain, activeParticipant));

            var modelRdl = ((EngineeringModel) iteration.Container).EngineeringModelSetup.RequiredRdl.Single();
            this.AddRdlToOpenList(modelRdl);
        }
    }
}
