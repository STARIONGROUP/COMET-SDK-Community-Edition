// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISession.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal.Operations;
    using CDP4Dal.DAL;
    using CDP4Dal.Events;

    using CDP4DalCommon.Tasks;

    using Permission;

    /// <summary>
    /// The <see cref="ISession"/> interface encapsulates an <see cref="IDal"/> and
    /// the associated <see cref="Assembler"/>
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// Executes just before data from an <see cref="OperationContainer"/> is written to the datastore.
        /// </summary>
        event EventHandler<BeforeWriteEventArgs> BeforeWrite;

        /// <summary>
        /// Gets the <see cref="Credentials"/> that are use to connect to the data source
        /// </summary>
        Credentials Credentials { get;  }

        /// <summary>
        /// Gets all the <see cref="Participant"/>s that the active person is linked with.
        /// </summary>
        IEnumerable<Participant> ActivePersonParticipants { get; }

        /// <summary>
        /// Gets the <see cref="IDal"/> that the current <see cref="Session"/> communicates with
        /// </summary>
        IDal Dal { get; }

        /// <summary>
        /// Gets the version of the data-model that is supported by the connected <see cref="Dal"/>
        /// </summary>
        Version DalVersion { get; }

        /// <summary>
        /// Asserts whether the <see cref="Version"/> is supported by the connected <see cref="Dal"/>
        /// </summary>
        /// <param name="version">
        /// The <see cref="Version"/> that is checked
        /// </param>
        /// <returns>
        /// true if the version is supported, false if not
        /// </returns>
        bool IsVersionSupported(Version version);

        /// <summary>
        /// Gets the <see cref="CDP4Dal.Assembler"/> associated with the current <see cref="Session"/> containing the Cache
        /// </summary>
        Assembler Assembler { get; }

        /// <summary>
        /// Gets the active <see cref="Person"/> in this <see cref="ISession"/>
        /// </summary>
        Person ActivePerson { get; }

        /// <summary>
        /// Gets the <see cref="IPermissionService"/> that handles access permissions for this Session.
        /// </summary>
        IPermissionService PermissionService { get; }

        /// <summary>
        /// Gets the uri of the connected data-source
        /// </summary>
        string DataSourceUri { get; }

        /// <summary>
        /// Gets the name of the session which is the concatentation of the data-source uri and the active person
        /// </summary>
        string Name { get;  }

        /// <summary>
        /// Gets the list of <see cref="ReferenceDataLibrary"/> that are currently open in the running application.
        /// </summary>
        IEnumerable<ReferenceDataLibrary> OpenReferenceDataLibraries { get; }

        /// <summary>
        /// Gets the list of <see cref="Iteration"/>s that are currently open with the active <see cref="DomainOfExpertise"/> and <see cref="Participant"/>
        /// </summary>
        IReadOnlyDictionary<Iteration, Tuple<DomainOfExpertise,Participant> > OpenIterations { get; }

        /// <summary>
        /// Gets the <see cref="ICDPMessageBus"/> that handles messaging for this session
        /// </summary>
        ICDPMessageBus CDPMessageBus { get; }

        /// <summary>
        /// Gets the <see cref="IReadOnlyDictionary{TKey,TValue}"/> of available <see cref="CometTask" />
        /// </summary>
        IReadOnlyDictionary<Guid, CometTask> CometTasks { get; }

        /// <summary>
        /// Retrieves the <see cref="SiteDirectory"/> in the context of the current session
        /// </summary>
        /// <returns>
        /// The instance <see cref="SiteDirectory"/> that is loaded in the <see cref="ISession"/>
        /// </returns>
        SiteDirectory RetrieveSiteDirectory();

        /// <summary>
        /// Queries the selected <see cref="DomainOfExpertise"/> from the session for provided current <see cref="Iteration"/>
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> for which the selected <see cref="DomainOfExpertise"/> is queried.
        /// </param>
        /// <returns>
        /// A <see cref="DomainOfExpertise"/> if has been selected for the <see cref="Iteration"/>, null otherwise.
        /// </returns>
        DomainOfExpertise QuerySelectedDomainOfExpertise(Iteration iteration);

        /// <summary>
        /// Queries the <see cref="Participant"/>'s <see cref="DomainOfExpertise"/>'s from the session for the provided <see cref="Iteration"/>
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/></param>
        /// <returns>
        /// The <see cref="DomainOfExpertise"/>s for the <see cref="Participant"/> that belongs to the <see cref="Iteration"/> for this <see cref="Session"/>.
        /// </returns>
        IEnumerable<DomainOfExpertise> QueryDomainOfExpertise(Iteration iteration);

        /// <summary>
        /// Switches the current domain for an iteration
        /// </summary>
        /// <param name="iterationId">The iteration identifier</param>
        /// <param name="domain">The domain</param>
        void SwitchDomain(Guid iterationId, DomainOfExpertise domain);

        /// <summary>
        /// Convenience function to get the required reference data library chain for the passed in engineeringModel.
        /// </summary>
        /// <param name="engineeringModel">
        /// The engineering model.
        /// </param>
        /// <returns>
        /// Chain of required reference data libraries for this <see cref="EngineeringModel"/>.
        /// </returns>
        IEnumerable<ReferenceDataLibrary> GetEngineeringModelRdlChain(EngineeringModel engineeringModel);

        /// <summary>
        /// Convenience function to get the required reference data library chain for the passed in engineeringModelSetup.
        /// </summary>
        /// <param name="engineeringModelSetup">
        /// The engineering model setup.
        /// </param>
        /// <returns>
        /// Chain of required reference data libraries for this <see cref="EngineeringModelSetup"/>.
        /// </returns>
        IEnumerable<ReferenceDataLibrary> GetEngineeringModelSetupRdlChain(EngineeringModelSetup engineeringModelSetup);

        /// <summary>
        /// Open the underlying <see cref="IDal"/> and update the Cache with the retrieved objects.
        /// </summary>
        /// <param name="activeMessageBus">Specify if the <see cref="ICDPMessageBus"/> is used or not to notify listeners</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        /// <remarks>
        /// The <see cref="ICDPMessageBus"/> is used to send messages to notify listeners of <see cref="Thing"/>s that
        /// have been added to the cache.
        /// </remarks>
        Task Open(bool activeMessageBus = true);

        /// <summary>
        /// Read an <see cref="Iteration"/> from the underlying <see cref="IDal"/> and
        /// set the active <see cref="DomainOfExpertise"/> for the <see cref="Iteration"/>.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to read</param>
        /// <param name="domain">The active <see cref="DomainOfExpertise"/> for the <see cref="Iteration"/></param>
        /// <param name="activeMessageBus">Specify if the <see cref="ICDPMessageBus"/> is used or not to notify listeners</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        /// <remarks>
        /// The Cache is updated with the returned objects and the <see cref="ICDPMessageBus"/>
        /// is used to send messages to notify listeners of updates to the Cache
        /// </remarks>
        Task Read(Iteration iteration, DomainOfExpertise domain, bool activeMessageBus = true);

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
        Task Read(ReferenceDataLibrary rdl);

        /// <summary>
        /// Read a <see cref="Thing"/> in the associated <see cref="IDal"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        Task Read(Thing thing);

        /// <summary>
        /// Read a <see cref="Thing"/> in the associated <see cref="IDal"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read</param>
        /// <param name="queryAttributes">The <see cref="IQueryAttributes"/> that define query attributes</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        Task Read(Thing thing, IQueryAttributes queryAttributes);

        /// <summary>
        /// Read a list of <see cref="Thing"/>s in the associated <see cref="IDal"/>
        /// </summary>
        /// <param name="things">The <see cref="IEnumerable{Thing}"/> that contains the <see cref="Thing"/>s to read</param>
        /// <param name="queryAttributes">The <see cref="IQueryAttributes"/> to be used to read data</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        Task Read(IEnumerable<Thing> things, IQueryAttributes queryAttributes);

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
        Task Read(IEnumerable<Guid> engineeringModels);
        
        /// <summary>
        /// Reads a <see cref="CometTask" /> identified by the provided <see cref="Guid" />
        /// </summary>
        /// <param name="id">The <see cref="Guid"/> identifier for the <see cref="CometTask" /></param>
        /// <exception cref="InvalidOperationException">If the <see cref="Session.ActivePerson"/> is null, meaning that the session is not opened</exception>
        Task ReadCometTask(Guid id);

        /// <summary>
        /// Reads all <see cref="CometTask" /> available for the current logged <see cref="Person" />
        /// </summary>
        /// <exception cref="InvalidOperationException">If the <see cref="Session.ActivePerson"/> is null, meaning that the session is not opened</exception>
        Task ReadCometTasks();

        /// <summary>
        /// Reads a physical file from a DataStore
        /// </summary>
        /// <param name="localFile">Download a localfile</param>
        /// <returns>an await-able <see cref="Task"/> that returns a <see cref="byte"/> array.</returns>
        Task<byte[]> ReadFile<T>(T localFile) where T : Thing, ILocalFile;

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">List of file paths for files to be send to the datastore</param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        Task Write(OperationContainer operationContainer, IEnumerable<string> files);

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        Task Write(OperationContainer operationContainer);

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
        /// An await-able <see cref="Task" />
        /// </returns>
        Task Write(OperationContainer operationContainer, int waitTime, IEnumerable<string> files = null);

        /// <summary>
        /// Refreshes all the <see cref="TopContainer"/>s in the cache
        /// </summary>
        /// /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        Task Refresh();

        /// <summary>
        /// Reloads all the <see cref="TopContainer"/>s the in cache
        /// </summary>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        Task Reload();

        /// <summary>
        /// Close the underlying <see cref="IDal"/> and clears the encapsulated <see cref="Assembler"/>
        /// </summary>
        Task Close();

        /// <summary>
        /// Can a Cancel action be executed?
        /// </summary>
        /// <returns>True is Cancel is allowed, otherwise false.</returns>
        bool CanCancel();

        /// <summary>
        /// Cancel any Read or Open operation.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Close a <see cref="SiteReferenceDataLibrary"/> and all <see cref="SiteDirectory"/> that depends on it
        /// </summary>
        /// <param name="sRdl">The <see cref="SiteReferenceDataLibrary"/> to close</param>
        /// <returns>The async <see cref="Task"/></returns>
        Task CloseRdl(SiteReferenceDataLibrary sRdl);

        /// <summary>
        /// Close a <see cref="IterationSetup"/> and its <see cref="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="iterationSetup">
        /// The iteration setup.
        /// </param>
        Task CloseIterationSetup(IterationSetup iterationSetup);

        /// <summary>
        /// Close a <see cref="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="modelRdl">
        /// The model RDL.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task CloseModelRdl(ModelReferenceDataLibrary modelRdl);

        /// <summary>
        /// Cherry Pick a subset of an <see cref="Iteration" /> based on <see cref="ClassKind"/> and <see cref="Category"/> filters
        /// </summary>
        /// <param name="engineeringModelId">The <see cref="Guid"/> of the <see cref="EngineeringModel"/> that contains the <see cref="Iteration"/></param>
        /// <param name="iterationId">The <see cref="Guid"/> of the <see cref="Iteration"/></param>
        /// <param name="classKinds">A collection of <see cref="ClassKind"/> that <see cref="Thing"/> to retrieve should belongs to</param>
        /// <param name="categoriesId">A collection of <see cref="Guid"/> of <see cref="Category"/> that <see cref="Thing"/> to retrieve should be categorized by</param>
        /// <returns>A <see cref="Task{T}"/> with retrieved <see cref="CDP4Common.DTO.Thing"/>s</returns>
        Task<IEnumerable<CDP4Common.DTO.Thing>> CherryPick(Guid engineeringModelId, Guid iterationId, IEnumerable<ClassKind> classKinds, IEnumerable<Guid> categoriesId);
    }
}
