// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISession.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Operations;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal.DAL;
    using Permission;
    using System;

    /// <summary>
    /// The <see cref="ISession"/> interface encapsulates an <see cref="IDal"/> and 
    /// the associated <see cref="Assembler"/>
    /// </summary>
    public interface ISession
    {
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
        /// Retrieves the <see cref="SiteDirectory"/> in the context of the current session
        /// </summary>
        /// <returns>
        /// The instance <see cref="SiteDirectory"/> that is loaded in the <see cref="ISession"/>
        /// </returns>
        SiteDirectory RetrieveSiteDirectory();

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
        /// Open the underlying <see cref="IDal"/>
        /// </summary>
        /// <returns>
        /// an await-able <see cref="Task"/>
        /// </returns>
        Task Open();

        /// <summary>
        /// Read an <see cref="Iteration"/> in the associated <see cref="IDal"/> along the active <see cref="DomainOfExpertise"/> for it
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to read</param>
        /// <param name="domain">The active <see cref="DomainOfExpertise"/> for the <see cref="Iteration"/></param>
        /// <returns>a <see cref="Task"/> that can be used with await</returns>
        Task Read(Iteration iteration, DomainOfExpertise domain);

        /// <summary>
        /// Read <see cref="ReferenceDataLibrary"/> in the associated <see cref="IDal"/>
        /// </summary>
        /// <param name="rdl">The <see cref="ReferenceDataLibrary"/> to read</param>
        /// <returns>a <see cref="Task"/> that can be used with await</returns>
        Task Read(ReferenceDataLibrary rdl);

        /// <summary>
        /// Read a <see cref="Thing"/> in the associated <see cref="IDal"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read</param>
        /// <returns>
        /// a <see cref="Task"/> that can be used with await
        /// </returns>
        Task Read(Thing thing);

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <returns>
        /// a <see cref="Task"/> that can be used with await
        /// </returns>
        Task Write(OperationContainer operationContainer);

        /// <summary>
        /// Refreshes all the <see cref="TopContainer"/>s in the cache
        /// </summary>
        /// /// <returns>
        /// a <see cref="Task"/> that can be used with await
        /// </returns>
        Task Refresh();

        /// <summary>
        /// Reloads all the <see cref="TopContainer"/>s the in cache
        /// </summary>
        /// <returns>
        /// a <see cref="Task"/> that can be used with await
        /// </returns>
        Task Reload();

        /// <summary>
        /// Close the underlying <see cref="IDal"/>
        /// </summary>
        void Close();

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
    }
}
