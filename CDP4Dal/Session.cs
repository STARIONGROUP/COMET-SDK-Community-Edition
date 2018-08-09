// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Session.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Dal.Operations;
    using CDP4Common.SiteDirectoryData;

    using DAL;
    using Events;
    using NLog;
    using Permission;

    /// <summary>
    /// The <see cref="Session"/> class encapsulates the <see cref="DAL.Credentials"/>, <see cref="IDal"/> and <see cref="CDP4Dal.Assembler"/>
    /// that constitute a user session with a data-source
    /// </summary>
    public class Session : ISession
    {
        #region Fields
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Backing field for <see cref="ActivePerson"/>
        /// </summary>
        private Person activePerson;

        /// <summary>
        /// The cancelation token source.
        /// </summary>
        private CancellationTokenSource cancelationTokenSource;

        /// <summary>
        /// Backing field for <see cref="OpenReferenceDataLibraries"/>
        /// </summary>
        private readonly List<ReferenceDataLibrary> openReferenceDataLibraries;

        /// <summary>
        /// Contains the open <see cref="Iteration"/> along with the active <see cref="DomainOfExpertise"/> and <see cref="Participant"/>
        /// </summary>
        private readonly Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> openIterations;
        #endregion

        #region Constructor
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
        }
        #endregion

        #region Properties
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
        public Version DalVersion
        {
            get { return this.Dal.DalVersion; }
        }

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
        public Person ActivePerson
        {
            get
            {
                if (this.activePerson != null)
                {
                    return this.activePerson;
                }

                this.activePerson = this.Assembler.Cache.Select(x => x.Value)
                    .Select(lazy => lazy.Value)
                    .OfType<Person>()
                    .SingleOrDefault(pers => pers.ShortName == this.Credentials.UserName);

                return this.activePerson;
            }
        }

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
                return string.Format("{0} - {1}", this.DataSourceUri, personName);
            }
        }

        /// <summary>
        /// Gets the list of <see cref="ReferenceDataLibrary"/> that are currently open in the running application.
        /// </summary>
        public IEnumerable<ReferenceDataLibrary> OpenReferenceDataLibraries
        {
            get { return this.openReferenceDataLibraries; }
        }

        /// <summary>
        /// Gets the list of <see cref="Iteration"/>s that are currently open with the active <see cref="DomainOfExpertise"/> and <see cref="Participant"/>
        /// </summary>
        public IReadOnlyDictionary<Iteration, Tuple<DomainOfExpertise, Participant>> OpenIterations
        {
            get { return this.openIterations; }
        }
        #endregion

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

            return (iterationDomainPair.Value == null || iterationDomainPair.Value.Item1 == null) ? null : iterationDomainPair.Value.Item1;
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
            this.cancelationTokenSource = new CancellationTokenSource();
            IReadOnlyList<CDP4Common.DTO.Thing> dtoThings;
            try
            {
                dtoThings = (await this.Dal.Open(this.Credentials, this.cancelationTokenSource.Token)).ToList();
            }
            catch (OperationCanceledException)
            {
                logger.Info("Open request cancelled {0}", this.DataSourceUri);
                this.cancelationTokenSource = null;
                return;
            }

            if (!dtoThings.Any())
            {
                logger.Warn("no data returned upon Open on {0}", this.DataSourceUri);
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await this.Assembler.Synchronize(dtoThings);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));

            logger.Info("Synchronization with the {0} server done in {1} [ms]", this.DataSourceUri, sw.ElapsedMilliseconds);
            
            var sessionChange = new SessionEvent(this, SessionStatus.Open);
            CDPMessageBus.Current.SendMessage(sessionChange);

            logger.Info("Session {0} opened successfully in {1} [ms]", this.DataSourceUri, sw.ElapsedMilliseconds);
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
            // check if iteration is already open
            // if so check that the domain is not different
            var iterationDomainPair = this.openIterations.SingleOrDefault(x => x.Key.Iid == iteration.Iid);
            if (!iterationDomainPair.Equals(default(KeyValuePair<Iteration, Tuple<DomainOfExpertise,Participant>>)))
            {
                if (iterationDomainPair.Value.Item1 != domain)
                {
                    throw new InvalidOperationException("The iteration is already open with another domain.");
                }
            }

            // Create the token source
            this.cancelationTokenSource = new CancellationTokenSource();
            IEnumerable<CDP4Common.DTO.Thing> dtoThings;
            try
            {
                var iterationDto = (CDP4Common.DTO.Iteration)iteration.ToDto();
                this.Dal.Session = this;
                dtoThings = await this.Dal.Read(iterationDto, this.cancelationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read {0} {1} cancelled", iteration.ClassKind, iteration.Iid);
                this.cancelationTokenSource = null;
                return;
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
            await this.Read((Thing)rdl);
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
            logger.Info("Session.Read {0} {1}", thing.ClassKind, thing.Iid);
            var dto = thing.ToDto();

            // Create the token source
            this.cancelationTokenSource = new CancellationTokenSource();
            IEnumerable<CDP4Common.DTO.Thing> dtoThings;
            try
            {
                dtoThings = await this.Dal.Read(dto, this.cancelationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                logger.Info("Session.Read {0} {1} cancelled", thing.ClassKind, thing.Iid);
                this.cancelationTokenSource = null;
                return;
            }

            // proceed if no problem
            var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();
            if (!enumerable.Any())
            {
                logger.Warn("no data returned upon Read on {0}", this.DataSourceUri);
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await this.Assembler.Synchronize(enumerable);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
            logger.Info("Synchronization with the {0} server done", this.DataSourceUri);
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
            this.Dal.Session = this;
            var dtoThings = await this.Dal.Write(operationContainer);

            var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();
            if (!enumerable.Any())
            {
                logger.Warn("no data returned upon Write on {0}", this.DataSourceUri);
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await this.Assembler.Synchronize(enumerable);
            logger.Info("Write To the {0} server done", this.DataSourceUri);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
        }

        /// <summary>
        /// Refreshes all the <see cref="TopContainer"/>s in the cache
        /// </summary>
        /// /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        public async Task Refresh()
        {
            foreach (var topContainer in this.GetSiteDirectoryAndIterations())
            {
                await this.Update(topContainer.Value);
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
            foreach (var topContainer in this.GetSiteDirectoryAndIterations())
            {
                await this.Update(topContainer.Value, false);
            }
        }

        /// <summary>
        /// Cancel any Read or Open operation.
        /// </summary>
        public void Cancel()
        {
            if (this.cancelationTokenSource != null)
            {
                this.cancelationTokenSource.Cancel();
            }
        }

        /// <summary>
        /// Close the underlying <see cref="IDal"/>
        /// </summary>
        public void Close()
        {
            // TODO: when the session object implements auto refresh, the Close method shall stop the auto refresh as well
            this.Dal.Close();
            this.Assembler.Clear();

            var sessionChange = new SessionEvent(this, SessionStatus.Closed);
            CDPMessageBus.Current.SendMessage(sessionChange);

            logger.Info("Session {0} closed successfully", this.DataSourceUri);
            this.openReferenceDataLibraries.Clear();
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
            this.cancelationTokenSource = new CancellationTokenSource();
            IEnumerable<CDP4Common.DTO.Thing> dtoThings;
            try
            {
                dtoThings = await this.Dal.Read(thing.ToDto(), this.cancelationTokenSource.Token, queryAttribute);
            }
            catch (OperationCanceledException)
            {
                this.cancelationTokenSource = null;
                return;
            }

            var enumerable = dtoThings as IList<CDP4Common.DTO.Thing> ?? dtoThings.ToList();
            if (!enumerable.Any())
            {
                logger.Warn("no data returned upon Read on {0}", this.DataSourceUri);
            }

            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.BeginUpdate));
            await this.Assembler.Synchronize(enumerable);
            logger.Info("Synchronization with the {0} server done", this.DataSourceUri);
            CDPMessageBus.Current.SendMessage(new SessionEvent(this, SessionStatus.EndUpdate));
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
        /// Gets the <see cref="SiteDirectory"/> and all <see cref="Iteration"/>s from the Assembler's cache for this <see cref="Session"/>
        /// </summary>
        /// <returns>the <see cref="List{T}"/> of the collected <see cref="SiteDirectory"/> and all <see cref="Iteration"/>s from the Assembler's cache for this <see cref="Session"/></returns>
        private IEnumerable<Lazy<Thing>> GetSiteDirectoryAndIterations()
        {
            return this.Assembler.Cache.Select(x => x.Value).Where(x => x.Value is SiteDirectory || x.Value is Iteration).ToList();
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
            this.Assembler.Cache.TryGetValue(new Tuple<Guid, Guid?>(thing.Iid, null), out lazyThing);
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
            this.Assembler.Cache.TryGetValue(new Tuple<Guid, Guid?>(iterationId, null), out lazyIteraion);
            if (lazyIteraion == null)
            {
                return;
            }

            var iteration = lazyIteraion.Value as Iteration;
            if (iteration == null)
            {
                return;
            }

            if (this.openIterations.ContainsKey(iteration))
            {
                return;
            }

            var activeParticipant = ((EngineeringModel)iteration.Container).EngineeringModelSetup.Participant.Where(p => p.Person == this.ActivePerson).SingleOrDefault();

            if (activeParticipant == null)
            {
                throw new InvalidOperationException("The iteration does not have an active participant associated.");
            }

            this.openIterations.Add(iteration, new Tuple<DomainOfExpertise, Participant>(activeDomain, activeParticipant));

            var modelRdl = ((EngineeringModel)iteration.Container).EngineeringModelSetup.RequiredRdl.Single();
            this.AddRdlToOpenList(modelRdl);
        }
    }
}