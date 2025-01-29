// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Session.cs" company="Starion Group S.A.">
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
    using CDP4Common.ExceptionHandlerService;
    using CDP4Common.Exceptions;
    using CDP4Common.Extensions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4Dal.DAL;
    using CDP4Dal.Events;
    using CDP4Dal.Operations;
    using CDP4Dal.Permission;

    using CDP4DalCommon.Authentication;
    using CDP4DalCommon.Tasks;

    using NLog;

    /// <summary>
    /// The <see cref="Session"/> class encapsulates the <see cref="DAL.Credentials"/>, <see cref="IDal"/> and <see cref="CDP4Dal.Assembler"/>
    /// that constitute a user session with a data-source
    /// </summary>
    public class Session : ISession
    {
        /// <summary>
        /// The <see cref="IExceptionHandlerService"/>
        /// </summary>
        public IExceptionHandlerService ExceptionHandlerService { get; private set; }

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
        private readonly ConcurrentDictionary<Guid, CancellationTokenSource> cancellationTokenSourceDictionary;

        /// <summary>
        /// Backing field for <see cref="OpenReferenceDataLibraries"/>
        /// </summary>
        private readonly List<ReferenceDataLibrary> openReferenceDataLibraries;

        /// <summary>
        /// Contains the open <see cref="Iteration"/> along with the active <see cref="DomainOfExpertise"/> and <see cref="Participant"/>
        /// </summary>
        private readonly Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> openIterations;

        /// <summary>
        /// Contains all <see cref="CometTask" /> created or read during the session
        /// </summary>
        private readonly Dictionary<Guid, CometTask> cometTasks = new Dictionary<Guid, CometTask>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Session"/> class.
        /// </summary>
        /// <param name="dal">
        /// the associated <see cref="IDal"/> that is used to communicate with the data-source
        /// </param>
        /// <param name="credentials">
        /// the <see cref="DAL.Credentials"/> associated to the <see cref="IDal"/>
        /// </param>
        /// <param name="messageBus">
        /// The instance of <see cref="ICDPMessageBus"/>
        /// </param>
        /// <param name="exceptionHandlerService">The instance of <see cref="IExceptionHandlerService"/></param>
        public Session(IDal dal, Credentials credentials, ICDPMessageBus messageBus, IExceptionHandlerService exceptionHandlerService) : this(dal, credentials, messageBus)
        {
            this.ExceptionHandlerService = exceptionHandlerService;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Session"/> class.
        /// </summary>
        /// <param name="dal">
        /// the associated <see cref="IDal"/> that is used to communicate with the data-source
        /// </param>
        /// <param name="credentials">
        /// the <see cref="DAL.Credentials"/> associated to the <see cref="IDal"/>
        /// </param>
        /// <param name="messageBus">
        /// The instance of <see cref="ICDPMessageBus"/>
        /// </param>
        public Session(IDal dal, Credentials credentials, ICDPMessageBus messageBus)
        {
            this.CDPMessageBus = messageBus;
            this.Credentials = credentials;
            this.Dal = dal;
            this.Dal.Session = this;
            this.Assembler = new Assembler(credentials.Uri, messageBus);
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
        /// Gets the <see cref="IReadOnlyDictionary{TKey,TValue}"/> of available <see cref="CometTask" />
        /// </summary>
        public IReadOnlyDictionary<Guid, CometTask> CometTasks => this.cometTasks;

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
        /// Gets the <see cref="ICDPMessageBus"/> that handles messaging for this session
        /// </summary>
        public ICDPMessageBus CDPMessageBus { get; }

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
        /// <param name="activeMessageBus">Specify if the <see cref="ICDPMessageBus"/> is used or not to notify listeners</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        /// <remarks>
        /// The Cache is updated with the returned objects and the <see cref="ICDPMessageBus"/>
        /// is used or not to send messages to notify listeners of updates to the Cache
        /// </remarks>
        public async Task Open(bool activeMessageBus = true)
        {
            var sw = new Stopwatch();
            sw.Start();
            logger.Info("Open request {0}", this.DataSourceUri);
            this.cometTasks.Clear();

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            IReadOnlyList<CDP4Common.DTO.Thing> dtoThings;

            try
            {
                dtoThings = (await this.Dal.Open(this.Credentials, cancellationTokenSource.Token)).ToList();
            }
            catch (OperationCanceledException)
            {
                logger.Info("Open request cancelled {0}", this.DataSourceUri);
                return;
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }

            if (!dtoThings.Any())
            {
                logger.Warn("no data returned upon Open on {0}", this.DataSourceUri);
            }

            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));

            await this.Assembler.Synchronize(dtoThings, activeMessageBus);

            this.ActivePerson = this.Assembler.Cache.Select(x => x.Value)
                .Select(lazy => lazy.Value)
                .OfType<Person>()
                .SingleOrDefault(pers => pers.ShortName == this.Credentials.UserName);

            if (this.ActivePerson == null)
            {
                // clear cache
                await this.Assembler.Clear();

                this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));

                throw new IncompleteModelException("The Person object that matches the user specified in the Credentials could not be found");
            }
            else
            {
                this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            }

            logger.Info("Synchronization with the {0} server done in {1} [ms]", this.DataSourceUri, sw.ElapsedMilliseconds);

            var sessionChange = new SessionEvent(this, SessionStatus.Open);
            this.CDPMessageBus.SendMessage(sessionChange);

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
                this.CDPMessageBus.SendMessage(new DomainChangedEvent(iterationPair.Key, domain));
            }
        }

        /// <summary>
        /// Read an <see cref="Iteration"/> from the underlying <see cref="IDal"/> and set the active <see cref="DomainOfExpertise"/> for the <see cref="Iteration"/>.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to read</param>
        /// <param name="domain">The active <see cref="DomainOfExpertise"/> for the <see cref="Iteration"/></param>
        /// <param name="activeMessageBus">Specify if the <see cref="ICDPMessageBus"/> is used or not to notify listeners</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        /// <remarks>
        /// The Cache is updated with the returned objects and the <see cref="ICDPMessageBus"/>
        /// is used or not to send messages to notify listeners of updates to the Cache
        /// </remarks>
        public async Task Read(Iteration iteration, DomainOfExpertise domain, bool activeMessageBus = true)
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
                var iterationDto = (CDP4Common.DTO.Iteration)iteration.ToDto();
                this.Dal.Session = this;
                dtoThings = await this.Dal.Read(iterationDto, cancellationTokenSource.Token);
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read {0} {1} cancelled", iteration.ClassKind, iteration.Iid);
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

            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));

            try
            {
                await this.Assembler.Synchronize(enumerable, activeMessageBus);

                this.AddIterationToOpenList(iteration.Iid, domain);
            }
            finally
            {
                this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            }

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
        /// The Cache is updated with the returned objects and the <see cref="ICDPMessageBus"/> is used to send messages to notify listeners of updates to the Cache
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
        /// Reads the <see cref="EngineeringModel"/> instances from the data-source
        /// </summary>
        /// <param name="engineeringModels">
        /// The unique identifiers of the <see cref="EngineeringModel"/>s that needs to be read from the data-source, in case the list is empty
        /// all the <see cref="EngineeringModel"/>s will be read
        /// </param>
        /// <returns>
        /// A list of <see cref="EngineeringModel"/>s
        /// </returns>
        /// <remarks>
        /// Only those <see cref="EngineeringModel"/>s are retunred that the <see cref="Person"/> is a <see cref="Participant"/> in
        /// </remarks>
        public async Task Read(IEnumerable<Guid> engineeringModels)
        {
            if (engineeringModels == null)
            {
                throw new ArgumentNullException(nameof(engineeringModels), $"The {nameof(engineeringModels)} may not be null");
            }

            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException($"The EngineeringModel cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            logger.Info("Session.Read {EngineeringModel} {0}", !engineeringModels.Any() ? "*" : $"EngineeringModel/{engineeringModels.ToShortGuidArray()}");
            
            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            IEnumerable<CDP4Common.DTO.Thing> dtoThings;

            try
            {
                var dtos = engineeringModels.Select(iid => new CDP4Common.DTO.EngineeringModel { Iid = iid }).ToList();

                dtoThings = await this.Dal.Read(dtos, cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read EngineeringModel {0} cancelled", !engineeringModels.Any() ? "*" : $"EngineeringModel/{engineeringModels.Select(x => x).ToList().ToShortGuidArray()}");
                return;
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }

            // proceed if no problem
            var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();

            await this.AfterReadOrWriteOrUpdate(enumerable);
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
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read {0} {1} cancelled", thing.ClassKind, thing.Iid);
                return;
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
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
                throw new InvalidOperationException("The data cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            var thingList = things.ToList();

            if (!thingList.Any())
            {
                throw new ArgumentException("The requested list of things is null or empty.");
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
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read cancelled");
                return;
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }

            await this.AfterReadOrWriteOrUpdate(foundThings);
        }

        /// <summary>
        /// Reads a <see cref="CometTask" /> identified by the provided <see cref="Guid" />
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> identifier for the <see cref="CometTask" /></param>
        /// <returns>An await-able <see cref="Task"/> with the read <see cref="CometTask"/></returns>
        /// <exception cref="InvalidOperationException">If the <see cref="ActivePerson"/> is null, meaning that the session is not opened</exception>
        public async Task<CometTask> ReadCometTask(Guid id)
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException("The CometTask cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);
            CometTask cometTask = default;

            try
            {
                this.Dal.Session = this;
                cometTask = await this.Dal.ReadCometTask(id, cancellationTokenSource.Token);
                this.cometTasks[cometTask.Id] = cometTask;
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read for CometTask {0} cancelled", id);
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out _);
            }

            return cometTask;
        }

        /// <summary>
        /// Reads all <see cref="CometTask" /> available for the current logged <see cref="Person" />
        /// </summary>
        /// <returns>An await-able <see cref="Task"/> with the <see cref="IReadOnlyCollection{T}"/> of read <see cref="CometTask"/></returns>
        /// <exception cref="InvalidOperationException">If the <see cref="ActivePerson"/> is null, meaning that the session is not opened</exception>
        public async Task<IReadOnlyCollection<CometTask>> ReadCometTasks()
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException("CometTasks cannot be read when the ActivePerson is null; The Open method must be called prior to any of the Read methods");
            }

            // Create the token source
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);
            var readCometTasks = new List<CometTask>();

            try
            {
                this.Dal.Session = this;
                readCometTasks.AddRange(await this.Dal.ReadCometTasks(cancellationTokenSource.Token));

                foreach (var cometTask in readCometTasks)
                {
                    this.cometTasks[cometTask.Id] = cometTask;
                }

                cancellationTokenSource.Token.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read for all CometTask cancelled");
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out _);
            }

            return readCometTasks;
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
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.ReadFile {0} {1} cancelled", localFile.ClassKind, localFile.Iid);
                return null;
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }

            return fileContent;
        }

        /// <summary>
        /// Retrieves all supported <see cref="AuthenticationSchemeKind" /> by the CDP4-COMET datasource
        /// </summary>
        /// <returns>An awaitable <see cref="Task{TResult}"/> that contains the value of the queried <see cref="AuthenticationSchemeResponse" /></returns>
        public async Task<AuthenticationSchemeResponse> QueryAvailableAuthenticationScheme()
        {
            logger.Info("Request Authentication Scheme for {0}", this.DataSourceUri);
            
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            var supportedScheme = new AuthenticationSchemeResponse();
            this.Dal.Session = this;
            
            try
            {
                this.Dal.InitializeDalCredentials(this.Credentials);
                supportedScheme = await this.Dal.RequestAvailableAuthenticationScheme(cancellationTokenSource.Token);
            } 
            catch (OperationCanceledException)
            {
                logger.Info("Request Authentication Scheme for {0} cancelled", this.DataSourceUri);
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }
            
            return supportedScheme;
        }

        /// <summary>
        /// Authenticate against the data-source and open the session
        /// </summary>
        /// <param name="authenticationSchemeKind">The <see cref="AuthenticationSchemeKind"/> that is used to authenticate</param>
        /// <param name="authenticationInformation">The <see cref="AuthenticationInformation"/> that contains user's authentication information</param>
        /// <param name="activeMessageBus">Specify if the <see cref="ICDPMessageBus"/> is used or not to notify listeners</param>
        public async Task AuthenticateAndOpen(AuthenticationSchemeKind authenticationSchemeKind, AuthenticationInformation authenticationInformation, bool activeMessageBus = true)
        {
            switch (authenticationSchemeKind)
            {
                case AuthenticationSchemeKind.Basic:
                    this.Credentials.ProvideUserCredentials(authenticationInformation.UserName, authenticationInformation.Password, authenticationSchemeKind);
                    break;
                case AuthenticationSchemeKind.LocalJwtBearer:
                    await this.Login(authenticationInformation.UserName, authenticationInformation.Password);
                    break;
                case AuthenticationSchemeKind.ExternalJwtBearer:
                    this.Credentials.ProvideUserToken(authenticationInformation.Token, authenticationSchemeKind);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(authenticationSchemeKind), authenticationSchemeKind, "Unknowned value");
            }

            await this.Open(activeMessageBus);
        }

        /// <summary>
        /// Refreshes and apply authentication information based on the <see cref="Credentials"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">If all required <see cref="Credentials"/> informations are not provided</exception>
        public async Task RefreshAuthenticationInformation()
        {
            if (this.Credentials.IsFullyInitiliazed)
            {
                throw new InvalidOperationException("Cannot refresh authentication information when credentials are fully initiliazed");
            }

            if (this.Credentials.AuthenticationScheme == AuthenticationSchemeKind.LocalJwtBearer)
            {
                await this.Login(this.Credentials.UserName, this.Credentials.Password);
            }

            this.Dal.ApplyAuthenticationCredentials(this.Credentials);
        }

        /// <summary>
        /// Provides login capabitilities against data-source, based on provided <paramref name="userName"/> and <paramref name="password"/>. 
        /// </summary>
        /// <param name="userName">The username that should be used for authentication</param>
        /// <param name="password">The password that should be used for authentication</param>
        /// <remarks>This method should be used when using a CDP4-COMET WebServices and that it provides LocalJwtBearer authentication flow</remarks>
        private async Task Login(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName),"UserName must be set");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password),"Password must be set");
            }
            
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);
            
            this.Dal.Session = this;
            
            try
            {
                await this.Dal.Login(userName, password, cancellationTokenSource.Token);
            } 
            catch (OperationCanceledException)
            {
                logger.Info("Login request for {0} cancelled", this.DataSourceUri);
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }
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
            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));

            try
            {
                await this.Assembler.Synchronize(things);
            }
            finally
            {
                this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            }

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
            var filesList = this.BeforeDalWriteAndProcessFiles(operationContainer, files);

            try
            {
                var dtoThings = await this.Dal.Write(operationContainer, filesList);

                var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();

                await this.AfterReadOrWriteOrUpdate(enumerable);
            }
            catch (Exception ex)
            {
                if (!this.ExceptionHandlerService?.HandleException(ex, this, operationContainer, files) ?? true)
                {
                    throw;
                }
            }
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
        public Task Write(OperationContainer operationContainer)
        {
            return this.Write(operationContainer, null);
        }

        /// <summary>
        /// Write all the <see cref="Operation" />s from an <see cref="OperationContainer" /> asynchronously for a possible long running task.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer" /> to write
        /// </param>
        /// <param name="waitTime">The maximum time that we allow the server before responding. If the write operation takes more time
        /// than the provided <paramref name="waitTime" />, a <see cref="CometTask" /></param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files" /> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// An await-able <see cref="Task" /> with nullable <see cref="CometTask" />. If the write operation took less time
        /// than the provided <paramref name="waitTime"/>, null is returned.
        /// If the write operation takes longer than the provided <paramref name="waitTime" />, the associated <see cref="CometTask" />
        /// is returned.
        /// </returns>
        public async Task<CometTask?> Write(OperationContainer operationContainer, int waitTime, IEnumerable<string> files = null)
        {
            var filesList = this.BeforeDalWriteAndProcessFiles(operationContainer, files);

            try
            {
                var longRunningTaskResult = await this.Dal.Write(operationContainer, waitTime, filesList);

                if (longRunningTaskResult.IsWaitTimeReached)
                {
                    this.cometTasks[longRunningTaskResult.Task.Id] = longRunningTaskResult.Task;
                    return longRunningTaskResult.Task;
                }

                var things = longRunningTaskResult.Things as IList<CDP4Common.DTO.Thing> ?? longRunningTaskResult.Things.ToList();
                await this.AfterReadOrWriteOrUpdate(things);
            }
            catch (Exception ex)
            {
                if (!this.ExceptionHandlerService?.HandleException(ex, this, operationContainer, files) ?? true)
                {
                    throw;
                }
            }

            return null;
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
                throw new InvalidOperationException("The Refresh operation cannot be performed when the ActivePerson is null; The Open method must be called prior to performing a Write.");
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
                throw new InvalidOperationException("The Reload operation cannot be performed when the ActivePerson is null; The Open method must be called prior to performing a Write.");
            }

            foreach (var topContainer in this.GetSiteDirectoryAndActiveIterations())
            {
                await this.Update(topContainer, false);
            }
        }

        /// <summary>
        /// Asserts whether a cancel action can be executed
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
        /// True if Cancel is allowed for at least one token, otherwise false.
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

                return true;
            }

            return false;
        }

        /// <summary>
        /// Cancel all running Read, Open and Write operations that are currently running
        /// </summary>
        public void Cancel()
        {
            foreach (var cancellationTokenSourceKey in this.cancellationTokenSourceDictionary.Keys)
            {
                if (this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenSourceKey, out var cancellationTokenSource))
                {
                    if (CanCancel(cancellationTokenSource))
                    {
                        cancellationTokenSource?.Cancel();
                    }
                }
            }
        }

        /// <summary>
        /// Close the underlying <see cref="IDal"/> and clears the encapsulated <see cref="Assembler"/>
        /// </summary>
        public async Task Close()
        {
            this.cometTasks.Clear();
            this.Dal.Close();
            await this.Assembler.Clear();

            var sessionChange = new SessionEvent(this, SessionStatus.Closed);
            this.CDPMessageBus.SendMessage(sessionChange);

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

            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));

            try
            {
                await Task.WhenAll(tasks);
            }
            finally
            {
                this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            }

            foreach (var siteReferenceDataLibrary in orderedRdlsToClose)
            {
                this.openReferenceDataLibraries.Remove(siteReferenceDataLibrary);
            }

            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.RdlClosed));
        }

        /// <summary>
        /// Update <see cref="Thing"/> in the associated <see cref="IDal"/>
        /// </summary>
        /// <remarks>
        /// A Write Operation can be cancelled which will result in the Session will no longer waiting for the result.
        /// The operations are already dispatched to the E-TM-10-25 data source and will continue to run and complete there.
        /// </remarks>
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
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Update {0} {1} cancelled", thing.ClassKind, thing.Iid);
                return;
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
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
            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));

            try
            {
                await this.Assembler.CloseRdl(modelRdl);
            }
            finally
            {
                this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            }

            this.openReferenceDataLibraries.Remove(modelRdl);
            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.RdlClosed));
        }

        /// <summary>
        /// Close a <see cref="Iteration"/> and its <see cref="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="iterationSetup">
        /// The iteration setup.
        /// </param>
        public async Task CloseIterationSetup(IterationSetup iterationSetup)
        {
            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));

            try
            {
                await this.Assembler.CloseIterationSetup(iterationSetup);

                var iterationToRemove = this.openIterations.Select(x => x.Key).SingleOrDefault(x => x.Iid == iterationSetup.IterationIid);

                if (iterationToRemove != null)
                {
                    this.openIterations.Remove(iterationToRemove);
                }
            }
            finally
            {
                this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            }
        }

        /// <summary>
        /// Cherry Pick a subset of an <see cref="Iteration" /> based on <see cref="ClassKind"/> and <see cref="Category"/> filters
        /// </summary>
        /// <param name="engineeringModelId">The <see cref="Guid"/> of the <see cref="EngineeringModel"/> that contains the <see cref="Iteration"/></param>
        /// <param name="iterationId">The <see cref="Guid"/> of the <see cref="Iteration"/></param>
        /// <param name="classKinds">A collection of <see cref="ClassKind"/> that <see cref="Thing"/> to retrieve should belongs to</param>
        /// <param name="categoriesId">A collection of <see cref="Guid"/> of <see cref="Category"/> that <see cref="Thing"/> to retrieve should be categorized by</param>
        /// <returns>A <see cref="Task{T}"/> with retrieved <see cref="CDP4Common.DTO.Thing"/>s</returns>
        public async Task<IEnumerable<CDP4Common.DTO.Thing>> CherryPick(Guid engineeringModelId, Guid iterationId, IEnumerable<ClassKind> classKinds, IEnumerable<Guid> categoriesId)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationTokenKey = Guid.NewGuid();
            this.cancellationTokenSourceDictionary.TryAdd(cancellationTokenKey, cancellationTokenSource);

            IEnumerable<CDP4Common.DTO.Thing> cherryPickedThings;

            try
            {
                cherryPickedThings = await this.Dal.CherryPick(engineeringModelId, iterationId, classKinds, categoriesId, cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                logger.Info("CherryPick {0} cancelled", iterationId);
                return Enumerable.Empty<CDP4Common.DTO.Thing>();
            }
            finally
            {
                this.cancellationTokenSourceDictionary.TryRemove(cancellationTokenKey, out cancellationTokenSource);
            }

            return cherryPickedThings;
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

            this.CDPMessageBus.SendMessage(new SessionEvent(this, SessionStatus.RdlOpened));
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

        /// <summary>
        /// Verifies that a write operation can be performed an process the provided <paramref name="files"/>
        /// </summary>
        /// <param name="operationContainer"></param>
        /// <param name="files">List of file paths for files to be sent to the datastore</param>
        /// <returns>The provided <paramref name="files"/> if not null, an empty collection either</returns>
        /// <exception cref="InvalidOperationException">If the <see cref="ActivePerson"/> is null, meaning that the session is not opened</exception>
        /// <exception cref="FileNotFoundException">If one of the provided filepath inside the <paramref name="files"/> does not exists</exception>
        /// <exception cref="OperationCanceledException">If the write operation has been canceled</exception>
        private IEnumerable<string> BeforeDalWriteAndProcessFiles(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            if (this.ActivePerson == null)
            {
                throw new InvalidOperationException("The Write operation cannot be performed when the ActivePerson is null; The Open method must be called prior to performing a Write.");
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
                throw new OperationCanceledException("The Write operation was canceled.");
            }

            this.Dal.Session = this;
            return filesList;
        }
    }
}
