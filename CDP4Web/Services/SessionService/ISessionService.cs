// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionService.cs" company="Starion Group S.A.">
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

namespace CDP4Web.Services.SessionService
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Authentication;

    using FluentResults;

    /// <summary>
    /// Service that provides utilities to work with <see cref="ISession" />
    /// </summary>
    public interface ISessionService
    {
        /// <summary>
        /// Gets or sets the current session
        /// </summary>
        ISession Session { get; }

        /// <summary>
        /// Asserts that the current <see cref="ISession" /> is open
        /// </summary>
        bool IsSessionOpen { get; }

        /// <summary>
        /// Gets all <see cref="Iteration" /> that are opened
        /// </summary>
        IReadOnlyCollection<Iteration> OpenedIterations { get; }

        /// <summary>
        /// Gets all <see cref="EngineeringModel" /> that are opened
        /// </summary>
        IReadOnlyCollection<EngineeringModel> OpenedEngineeringModels { get; }

        /// <summary>
        /// Closes an <see cref="Iteration" />
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration" /> that needs to be closed</param>
        /// <returns>A <see cref="Task" /></returns>
        Task CloseIteration(Iteration iteration);

        /// <summary>
        /// Closes all open <see cref="Iteration" />s
        /// </summary>
        /// <returns>A <see cref="Task" /></returns>
        Task CloseIterations();

        /// <summary>
        /// Closes the current <see cref="ISession" />
        /// </summary>
        /// <returns>A <see cref="Task" /></returns>
        Task CloseSession();

        /// <summary>
        /// Creates or updates <see cref="Thing" />s
        /// </summary>
        /// <param name="topContainer">The <see cref="Thing" /> top container to use for the transaction</param>
        /// <param name="toUpdateOrCreate">A <see cref="IReadOnlyCollection{T}" /> of <see cref="Thing" /> to create or update</param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        /// <remarks>The <paramref name="topContainer" /> have to be a cloned <see cref="Thing" /></remarks>
        Task<Result> CreateOrUpdateThings(Thing topContainer, IReadOnlyCollection<Thing> toUpdateOrCreate);

        /// <summary>
        /// Deletes <see cref="Thing" />s
        /// </summary>
        /// <param name="topContainer">The <see cref="Thing" /> top container to use for the transaction</param>
        /// <param name="toDelete">A <see cref="IReadOnlyCollection{T}" /> of <see cref="Thing" /> to create or update</param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        /// <remarks>The <paramref name="topContainer" /> have to be a cloned <see cref="Thing" /></remarks>
        Task<Result> DeleteThings(Thing topContainer, IReadOnlyCollection<Thing> toDelete);

        /// <summary>
        /// Gets all available <see cref="DomainOfExpertise" /> for a specific <see cref="EngineeringModelSetup" />
        /// </summary>
        /// <param name="engineeringModelSetup">The <see cref="EngineeringModelSetup" /></param>
        /// <returns>A collection of available <see cref="DomainOfExpertise" /></returns>
        IEnumerable<DomainOfExpertise> GetAvailableDomains(EngineeringModelSetup engineeringModelSetup);

        /// <summary>
        /// Gets the <see cref="DomainOfExpertise" /> for an <see cref="Iteration" />
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration" /></param>
        /// <returns>The <see cref="DomainOfExpertise" /></returns>
        /// <exception cref="Iteration">If the <see cref="ArgumentException" /> is not opened</exception>
        DomainOfExpertise GetDomainOfExpertise(Iteration iteration);

        /// <summary>
        /// Gets the <see cref="Participant" /> inside an <see cref="Iteration" />
        /// </summary>
        Participant GetParticipant(Iteration iteration);

        /// <summary>
        /// Gets all <see cref="EngineeringModelSetup" /> where the current logged <see cref="Person" /> is a
        /// <see cref="Participant" />
        /// </summary>
        /// <returns>A collection of accessible <see cref="EngineeringModelSetup" /></returns>
        IEnumerable<EngineeringModelSetup> GetParticipantModels();

        /// <summary>
        /// Retrieves the <see cref="SiteDirectory" /> that is loaded in the <see cref="ISession" />
        /// </summary>
        /// <returns>The <see cref="SiteDirectory" /></returns>
        SiteDirectory GetSiteDirectory();

        /// <summary>
        /// Open the currently active <see cref="Iteration" /> linked to an <see cref="EngineeringModelSetup" />
        /// </summary>
        /// <param name="engineeringModelSetup">
        /// The <see cref="EngineeringModelSetup" /> to use to open the active
        /// <see cref="Iteration" />
        /// </param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /> to use to open the <see cref="Iteration" /></param>
        /// <returns>
        /// A <see cref="Task{T}" /> with the <see cref="Result{T}" /> that contains the opened <see cref="Iteration" />
        /// </returns>
        Task<Result<Iteration>> OpenActiveIteration(EngineeringModelSetup engineeringModelSetup, DomainOfExpertise domain);

        /// <summary>
        /// Open an <see cref="Iteration" /> based on the <see cref="IterationSetup" />
        /// </summary>
        /// <param name="iterationSetup">The <see cref="IterationSetup" /> to use to open the <see cref="Iteration" /></param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /> to use to open the <see cref="Iteration" /></param>
        /// <returns>
        /// A <see cref="Task{T}" /> with the <see cref="Result{T}" /> that contains the opened <see cref="Iteration" />
        /// </returns>
        Task<Result<Iteration>> OpenIteration(IterationSetup iterationSetup, DomainOfExpertise domain);

        /// <summary>
        /// Opens a <see cref="ISession" /> with the provided informations
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials" /> to use for authentication</param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        Task<Result> OpenSession(Credentials credentials);

        /// <summary>
        /// Opens a <see cref="ISession" /> with the provided informations
        /// </summary>
        /// <param name="username">The username to use for authentication</param>
        /// <param name="password">The password to use for authentication</param>
        /// <param name="url">The url of the target <see cref="ISession" /> </param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        Task<Result> OpenSession(string username, string password, string url);

        /// <summary>
        /// Refreshes the current <see cref="ISession" />
        /// </summary>
        /// <returns>A <see cref="Task" /></returns>
        Task RefreshSession();

        /// <summary>
        /// Reloads the current <see cref="ISession" />
        /// </summary>
        /// <returns>A <see cref="Task" /></returns>
        Task ReloadSession();

        /// <summary>
        /// Writes an <see cref="OperationContainer" /> to the <see cref="ISession" />
        /// </summary>
        /// <param name="operationContainer">The <see cref="OperationContainer" /> to write</param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        Task<Result> WriteTransaction(OperationContainer operationContainer);

        /// <summary>
        /// Switches the current domain for an opened iteration
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration" /></param>
        /// <param name="domainOfExpertise">The domain</param>
        void SwitchDomain(Iteration iteration, DomainOfExpertise domainOfExpertise);

        /// <summary>
        /// Initializes a new session and requests available <see cref="AuthenticationSchemeKind"/> supported by the server.
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials"/> that provides URL and proxy settings required to initializes </param>
        /// <returns>A <see cref="Task{TResult}"/> that contains the <see cref="Result{TValue}"/> of the operation, with the retrieved
        /// <see cref="AuthenticationSchemeResponse"/></returns>
        Task<Result<AuthenticationSchemeResponse>> InitializeSessionAndRequestServerSupportedAuthenticationScheme(Credentials credentials);

        /// <summary>
        /// Provides authentication information for the <see cref="ISession"/> that we wants to open and open it, if authorized
        /// </summary>
        /// <param name="selectedAuthenticationScheme">The <see cref="AuthenticationSchemeKind"/> that has been selected</param>
        /// <param name="authenticationInformation">The <see cref="AuthenticationInformation"/> to use for authentication</param>
        /// <returns>A <see cref="Task{TResult}"/> that contains operation result</returns>
        /// <exception cref="InvalidOperationException">If a <see cref="ISession"/> is alreadu open</exception>
        Task<Result> AuthenticateAndOpenSession(AuthenticationSchemeKind selectedAuthenticationScheme, AuthenticationInformation authenticationInformation);
    }
}
