// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionService.cs" company="Starion Group S.A.">
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
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Extensions;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;
    using CDP4Dal.Utilities;

    using CDP4DalCommon.Authentication;

    using CDP4ServicesDal;

    using CDP4Web.Enumerations;
    using CDP4Web.Extensions;

    using FluentResults;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Service that provides utilities to work with <see cref="ISession" />
    /// </summary>
    public class SessionService : ISessionService
    {
        /// <summary>
        /// Gets the <see cref="ILogger{TCategoryName}" />
        /// </summary>
        private readonly ILogger<SessionService> logger;

        /// <summary>
        /// The INJECTED <see cref="ICDPMessageBus"/>
        /// </summary>
        private readonly ICDPMessageBus messageBus;

        /// <summary>
        /// Initialize a new instance of <see cref="SessionService" />
        /// </summary>
        /// <param name="logger">The <see cref="ILogger{TCategoryName}" /></param>
        /// <param name="messageBus">The <see cref="ICDPMessageBus"/></param>
        public SessionService(ILogger<SessionService> logger, ICDPMessageBus messageBus)
        {
            this.logger = logger;
            this.messageBus = messageBus;
        }

        /// <summary>
        /// Gets or sets the current session
        /// </summary>
        public ISession Session { get; internal set; }

        /// <summary>
        /// Asserts that the current <see cref="ISession" /> is open
        /// </summary>
        public bool IsSessionOpen => this.GetSiteDirectory() != null;

        /// <summary>
        /// Gets all <see cref="Iteration" /> that are opened
        /// </summary>
        public IReadOnlyCollection<Iteration> OpenedIterations => this.QueryOpenIterations();

        /// <summary>
        /// Gets all <see cref="EngineeringModel" /> that are opened
        /// </summary>
        public IReadOnlyCollection<EngineeringModel> OpenedEngineeringModels => this.QueryOpenEngineeringModels();

        /// <summary>
        /// Opens a <see cref="ISession" /> with the provided informations
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials" /> to use for authentication</param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        public async Task<Result> OpenSession(Credentials credentials)
        {
            Guard.ThrowIfNullOrEmpty(credentials.UserName, nameof(credentials.UserName));
            Guard.ThrowIfNullOrEmpty(credentials.Password, nameof(credentials.Password));

            var result = Result.Ok();

            if (this.IsSessionOpen)
            {
                await this.CloseSession();
            }

            this.logger.LogInformation("Opening a session against {url}", credentials.Uri);
            var stopWatch = Stopwatch.StartNew();

            try
            {
                this.Session = new Session(new CdpServicesDal(), credentials, this.messageBus);
                await this.Session.Open();
                this.logger.LogInformation("CDP4Comet Session opened against {url} in {time} [ms]", credentials.Uri, stopWatch.ElapsedMilliseconds);
            }
            catch (DalReadException dalException)
            {
                this.logger.LogError("Authentication failure against {url}, reason: {exception}", credentials.Uri, dalException.Message);
                result.Reasons.Add(new Error($"Failed to authenticate against {credentials.Uri}").AddReasonIdentifier(HttpStatusCode.Unauthorized));
            }
            catch (HttpRequestException httpException)
            {
                this.logger.LogError("Failed to reach {url}, reason: {exception}", credentials.Uri, httpException.Message);
                result.Reasons.Add(new Error($"Failed to reach {credentials.Uri}").AddReasonIdentifier(HttpStatusCode.ServiceUnavailable));
            }

            stopWatch.Stop();
            return result;
        }

        /// <summary>
        /// Opens a <see cref="ISession" /> with the provided informations
        /// </summary>
        /// <param name="username">The username to use for authentication</param>
        /// <param name="password">The password to use for authentication</param>
        /// <param name="url">The url of the target <see cref="ISession" /> </param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        public Task<Result> OpenSession(string username, string password, string url)
        {
            Guard.ThrowIfNullOrEmpty(username, nameof(username));
            Guard.ThrowIfNullOrEmpty(password, nameof(password));
            Guard.ThrowIfNullOrEmpty(url, nameof(url));

            return this.OpenSession(new Credentials(username, password, new Uri(url)));
        }

        /// <summary>
        /// Initializes a new session and requests available <see cref="AuthenticationSchemeKind"/> supported by the server.
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials"/> that provides URL and proxy settings required to initializes </param>
        /// <returns>A <see cref="Task{TResult}"/> that contains the <see cref="Result{TValue}"/> of the operation, with the retrieved
        /// <see cref="AuthenticationSchemeResponse"/></returns>
        public async Task<Result<AuthenticationSchemeResponse>> InitializeSessionAndRequestServerSupportedAuthenticationScheme(Credentials credentials)
        {
            if (this.IsSessionOpen)
            {
                await this.CloseSession();
            }

            this.logger.LogInformation("Requesting supported AuthenticationScheme by server at {Url}", credentials.Uri);

            try
            {
                this.Session = new Session(new CdpServicesDal(), credentials, this.messageBus);
                var returnedResponse = await this.Session.QueryAvailableAuthenticationScheme();
                return Result.Ok(returnedResponse);
            }
            catch (HttpRequestException httpException)
            {
                this.logger.LogError("Failed to reach {Url}, reason: {Exception}", credentials.Uri, httpException.Message);
                return Result.Fail(new Error($"Failed to reach {credentials.Uri}").AddReasonIdentifier(HttpStatusCode.ServiceUnavailable));
            }
        }

        /// <summary>
        /// Provides authentication information for the <see cref="ISession"/> that we wants to open and open it, if authorized
        /// </summary>
        /// <param name="selectedAuthenticationScheme">The <see cref="AuthenticationSchemeKind"/> that has been selected</param>
        /// <param name="authenticationInformation">The <see cref="AuthenticationInformation"/> to use for authentication</param>
        /// <returns>A <see cref="Task{TResult}"/> that contains operation result</returns>
        /// <exception cref="InvalidOperationException">If a <see cref="ISession"/> is alreadu open</exception>
        public async Task<Result> AuthenticateAndOpenSession(AuthenticationSchemeKind selectedAuthenticationScheme, AuthenticationInformation authenticationInformation)
        {
            Guard.ThrowIfNull(this.Session, nameof(this.Session));

            if (this.IsSessionOpen)
            {
                throw new InvalidOperationException("Session is already open.");
            }

            var result = Result.Ok();

            this.logger.LogInformation("Authentication against CDP4 Server at {Url}", this.Session.DataSourceUri);
            var stopWatch = Stopwatch.StartNew();

            try
            {
                await this.Session.AuthenticateAndOpen(selectedAuthenticationScheme, authenticationInformation);
            }
            catch (DalReadException dalException)
            {
                this.logger.LogError("Authentication failure against {Url}, reason: {Exception}", this.Session.DataSourceUri, dalException.Message);
                result.Reasons.Add(new Error($"Failed to authenticate against {this.Session.DataSourceUri}").AddReasonIdentifier(HttpStatusCode.Unauthorized));
            }
            catch (HttpRequestException httpException)
            {
                this.logger.LogError("Failed to reach {Url}, reason: {Exception}", this.Session.DataSourceUri, httpException.Message);
                result.Reasons.Add(new Error($"Failed to reach {this.Session.DataSourceUri}").AddReasonIdentifier(HttpStatusCode.ServiceUnavailable));
            }
            
            stopWatch.Stop();
            return result;
        }

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
        public Task<Result<Iteration>> OpenActiveIteration(EngineeringModelSetup engineeringModelSetup, DomainOfExpertise domain)
        {
            Guard.ThrowIfNull(engineeringModelSetup, nameof(engineeringModelSetup));
            Guard.ThrowIfNull(domain, nameof(domain));

            return this.OpenIteration(engineeringModelSetup.IterationSetup.SingleOrDefault(x => x.FrozenOn == null), domain);
        }

        /// <summary>
        /// Closes an <see cref="Iteration" />
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration" /> that needs to be closed</param>
        /// <returns>A <see cref="Task" /></returns>
        public async Task CloseIteration(Iteration iteration)
        {
            Guard.ThrowIfNull(iteration, nameof(iteration));

            if (!this.IsSessionOpen)
            {
                this.logger.LogError("Trying to close an Iteration while the Session is not open");
                throw new InvalidOperationException("Cannot close an Iterion while the Session is not open");
            }

            this.logger.LogInformation("Closing iteration with id {iterationId}", iteration.Iid);
            await this.Session.CloseIterationSetup(iteration.IterationSetup);
            this.messageBus.SendMessage(SessionServiceEvent.IterationClosed, this.Session);
            this.logger.LogInformation("Iteration {iterationId} closed", iteration.Iid);
        }

        /// <summary>
        /// Closes all open <see cref="Iteration" />s
        /// </summary>
        /// <returns>A <see cref="Task" /></returns>
        public async Task CloseIterations()
        {
            foreach (var iteration in this.Session.OpenIterations.Select(x => x.Key))
            {
                await this.CloseIteration(iteration);
            }
        }

        /// <summary>
        /// Gets all <see cref="EngineeringModelSetup" /> where the current logged <see cref="Person" /> is a
        /// <see cref="Participant" />
        /// </summary>
        /// <returns>A collection of accessible <see cref="EngineeringModelSetup" /></returns>
        public IEnumerable<EngineeringModelSetup> GetParticipantModels()
        {
            return !this.IsSessionOpen ? Enumerable.Empty<EngineeringModelSetup>() : this.GetSiteDirectory().Model.Where(x => x.Participant.Exists(p => p.Person.Iid == this.Session.ActivePerson.Iid));
        }

        /// <summary>
        /// Gets all available <see cref="DomainOfExpertise" /> for a specific <see cref="EngineeringModelSetup" />
        /// </summary>
        /// <param name="engineeringModelSetup">The <see cref="EngineeringModelSetup" /></param>
        /// <returns>A collection of available <see cref="DomainOfExpertise" /></returns>
        public IEnumerable<DomainOfExpertise> GetAvailableDomains(EngineeringModelSetup engineeringModelSetup)
        {
            Guard.ThrowIfNull(engineeringModelSetup, nameof(engineeringModelSetup));
            var participant = engineeringModelSetup.Participant.Find(x => x.Person.Iid == this.Session.ActivePerson.Iid);
            return participant == null ? Enumerable.Empty<DomainOfExpertise>() : participant.Domain;
        }

        /// <summary>
        /// Retrieves the <see cref="SiteDirectory" /> that is loaded in the <see cref="ISession" />
        /// </summary>
        /// <returns>The <see cref="SiteDirectory" /></returns>
        public SiteDirectory GetSiteDirectory()
        {
            return this.Session?.RetrieveSiteDirectory();
        }

        /// <summary>
        /// Refreshes the current <see cref="ISession" />
        /// </summary>
        /// <returns>A <see cref="Task" /></returns>
        public async Task RefreshSession()
        {
            if (!this.IsSessionOpen)
            {
                return;
            }

            var stopWatch = Stopwatch.StartNew();
            this.messageBus.SendMessage(SessionServiceEvent.SessionRefreshing, this.Session);

            await this.Session.Refresh();
            stopWatch.Stop();

            this.messageBus.SendMessage(SessionServiceEvent.SessionRefreshed, this.Session);
            this.logger.LogInformation("Session refreshed in {time} [ms]", stopWatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Reloads the current <see cref="ISession" />
        /// </summary>
        /// <returns>A <see cref="Task" /></returns>
        public async Task ReloadSession()
        {
            if (!this.IsSessionOpen)
            {
                return;
            }

            var stopWatch = Stopwatch.StartNew();
            this.messageBus.SendMessage(SessionServiceEvent.SessionReloading, this.Session);

            await this.Session.Reload();
            stopWatch.Stop();

            this.messageBus.SendMessage(SessionServiceEvent.SessionReloaded, this.Session);
            this.logger.LogInformation("Session reloaed in {time} [ms]", stopWatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Open an <see cref="Iteration" /> based on the <see cref="IterationSetup" />
        /// </summary>
        /// <param name="iterationSetup">The <see cref="IterationSetup" /> to use to open the <see cref="Iteration" /></param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /> to use to open the <see cref="Iteration" /></param>
        /// <returns>
        /// A <see cref="Task{T}" /> with the <see cref="Result{T}" /> that contains the opened <see cref="Iteration" />
        /// </returns>
        public async Task<Result<Iteration>> OpenIteration(IterationSetup iterationSetup, DomainOfExpertise domain)
        {
            Guard.ThrowIfNull(iterationSetup, nameof(iterationSetup));
            Guard.ThrowIfNull(domain, nameof(domain));

            if (!this.IsSessionOpen)
            {
                this.logger.LogError("Trying to open an Iteration while the Session is not open");
                throw new InvalidOperationException("Cannot open an Iterion while the Session is not open");
            }

            this.logger.LogInformation("Iteration {iterationId} will be opened with Domain {domainName}", iterationSetup.IterationIid, domain.Name);
            var engineeringModelSetup = (EngineeringModelSetup)iterationSetup.Container;

            var engineeringModel = new EngineeringModel
            {
                Iid = engineeringModelSetup.EngineeringModelIid
            };

            var iteration = new Iteration
            {
                Iid = iterationSetup.IterationIid
            };

            engineeringModel.Iteration.Add(iteration);

            try
            {
                await this.Session.Read(iteration, domain);

                var openedIteration = this.Session.OpenIterations.Select(x => x.Key).FirstOrDefault(x => x.Iid == iterationSetup.IterationIid);

                if (openedIteration == null)
                {
                    this.logger.LogError("Failed to open the Iteration {iterationId} with the domain {domainName}", iterationSetup.IterationIid, domain.Name);
                    return Result.Fail(new Error($"Iteration with the id {iterationSetup.IterationIid} could not be open").AddReasonIdentifier(HttpStatusCode.InternalServerError));
                }

                this.logger.LogInformation("Iteration {iterationId} successfully opened", openedIteration.Iid);
                this.messageBus.SendMessage(SessionServiceEvent.IterationOpened, this.Session);
                return Result.Ok(openedIteration);
            }
            catch (InvalidOperationException invalidOperation)
            {
                this.logger.LogError(invalidOperation.Message);
                return Result.Fail(new ExceptionalError($"Failed to open the Iteration {iterationSetup.IterationIid}", invalidOperation).AddReasonIdentifier(HttpStatusCode.BadRequest));
            }
            catch (DalReadException dalReadException)
            {
                this.logger.LogError(dalReadException.Message);
                return Result.Fail(new ExceptionalError($"Failed to read the Iteration {iterationSetup.IterationIid}", dalReadException).AddReasonIdentifier(HttpStatusCode.BadRequest));
            }
        }

        /// <summary>
        /// Creates or updates <see cref="Thing" />s
        /// </summary>
        /// <param name="topContainer">The <see cref="Thing" /> top container to use for the transaction</param>
        /// <param name="toUpdateOrCreate">A <see cref="IReadOnlyCollection{T}" /> of <see cref="Thing" /> to create or update</param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        /// <remarks>The <paramref name="topContainer" /> have to be a cloned <see cref="Thing" /></remarks>
        public Task<Result> CreateOrUpdateThings(Thing topContainer, IReadOnlyCollection<Thing> toUpdateOrCreate)
        {
            Guard.ThrowIfNotValidForTransaction(topContainer);
            Guard.ThrowIfNullOrEmpty(toUpdateOrCreate, nameof(toUpdateOrCreate));

            if (!this.IsSessionOpen)
            {
                this.logger.LogError("Trying to Create or update Thing(s) while the Session is not open");
                throw new InvalidOperationException("Cannot Create or update Thing(s) while the Session is not open");
            }

            var context = TransactionContextResolver.ResolveContext(topContainer);
            var transaction = new ThingTransaction(context);

            foreach (var thing in toUpdateOrCreate)
            {
                transaction.CreateOrUpdate(thing);
            }

            var operationContainer = transaction.FinalizeTransaction();
            return this.WriteTransaction(operationContainer);
        }

        /// <summary>
        /// Deletes <see cref="Thing" />s
        /// </summary>
        /// <param name="topContainer">The <see cref="Thing" /> top container to use for the transaction</param>
        /// <param name="toDelete">A <see cref="IReadOnlyCollection{T}" /> of <see cref="Thing" /> to create or update</param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        /// <remarks>The <paramref name="topContainer" /> have to be a cloned <see cref="Thing" /></remarks>
        public Task<Result> DeleteThings(Thing topContainer, IReadOnlyCollection<Thing> toDelete)
        {
            Guard.ThrowIfNotValidForTransaction(topContainer);
            Guard.ThrowIfNullOrEmpty(toDelete, nameof(toDelete));

            if (!this.IsSessionOpen)
            {
                this.logger.LogError("Trying to delete Thing(s) while the Session is not open");
                throw new InvalidOperationException("Cannot delete Thing(s) while the Session is not open");
            }

            var context = TransactionContextResolver.ResolveContext(topContainer);
            var transaction = new ThingTransaction(context);

            foreach (var thing in toDelete)
            {
                Guard.ThrowIfNotAClone(thing);
                transaction.Delete(thing);
            }

            var operationContainer = transaction.FinalizeTransaction();
            return this.WriteTransaction(operationContainer);
        }

        /// <summary>
        /// Gets the <see cref="Participant" /> inside an <see cref="Iteration" />
        /// </summary>
        public Participant GetParticipant(Iteration iteration)
        {
            Guard.ThrowIfNull(iteration, nameof(iteration));

            if (!this.IsSessionOpen)
            {
                return null;
            }

            return this.GetSiteDirectory().Model.Find(m => m.IterationSetup.Contains(iteration.IterationSetup))?
                .Participant.Find(p => p.Person.Iid == this.Session.ActivePerson.Iid);
        }

        /// <summary>
        /// Gets the <see cref="DomainOfExpertise" /> for an <see cref="Iteration" />
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration" /></param>
        /// <returns>The <see cref="DomainOfExpertise" /></returns>
        /// <exception cref="Iteration">If the <see cref="ArgumentException" /> is not opened</exception>
        public DomainOfExpertise GetDomainOfExpertise(Iteration iteration)
        {
            Guard.ThrowIfNull(iteration, nameof(iteration));

            if (!this.IsSessionOpen)
            {
                this.logger.LogError("Tried to get DomainOfExpertise while the session is not opened");
                throw new InvalidOperationException("The session should be opened first.");
            }

            if (!this.Session.OpenIterations.TryGetValue(iteration, out var participantInformation))
            {
                this.logger.LogError("Tried to get DomainOfExpertise while the iteration is not opened");
                throw new ArgumentException("The requested iteration is not opened");
            }

            return participantInformation.Item1;
        }

        /// <summary>
        /// Switches the current domain for an opened iteration
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration" /></param>
        /// <param name="domainOfExpertise">The domain</param>
        public void SwitchDomain(Iteration iteration, DomainOfExpertise domainOfExpertise)
        {
            Guard.ThrowIfNull(iteration, nameof(iteration));
            Guard.ThrowIfNull(domainOfExpertise, nameof(domainOfExpertise));

            if (!this.IsSessionOpen)
            {
                this.logger.LogError("Tried to switch DomainOfExpertise while the session is not opened");
                throw new InvalidOperationException("The session should be opened first.");
            }

            this.Session.SwitchDomain(iteration.Iid, domainOfExpertise);
        }

        /// <summary>
        /// Closes the current <see cref="ISession" />
        /// </summary>
        /// <returns>A <see cref="Task" /></returns>
        public async Task CloseSession()
        {
            this.logger.LogInformation("Closing the current session");
            await this.Session.Close();
            this.logger.LogInformation("Session closed");
        }

        /// <summary>
        /// Writes an <see cref="OperationContainer" /> to the <see cref="ISession" />
        /// </summary>
        /// <param name="operationContainer">The <see cref="OperationContainer" /> to write</param>
        /// <returns>A <see cref="Task{T}" /> with the <see cref="Result" /> of the operation</returns>
        public async Task<Result> WriteTransaction(OperationContainer operationContainer)
        {
            Guard.ThrowIfNull(operationContainer, nameof(operationContainer));

            if (!this.IsSessionOpen)
            {
                this.logger.LogError("Trying to write a transaction while the Session is not open");
                throw new InvalidOperationException("Cannot write a transaction while the Session is not open");
            }

            var stopWatch = Stopwatch.StartNew();

            try
            {
                await this.Session.Write(operationContainer);
                this.logger.LogInformation("Transaction done in {swElapsedMilliseconds} [ms]", stopWatch.ElapsedMilliseconds);
                return Result.Ok();
            }
            catch (InvalidOperationException ex)
            {
                this.logger.LogError("Transaction failed: {exception}", ex.Message);
                return Result.Fail(new ExceptionalError("Transaction failed", ex).AddReasonIdentifier(HttpStatusCode.Unauthorized));
            }
            catch (DalWriteException ex)
            {
                this.logger.LogError("Transaction failed: {exception}", ex.Message);
                return Result.Fail(new ExceptionalError("Transaction failed", ex).AddReasonIdentifier(HttpStatusCode.BadRequest));
            }
            finally
            {
                stopWatch.Stop();
            }
        }

        /// <summary>
        /// Queries all open <see cref="EngineeringModel" />
        /// </summary>
        /// <returns>A collection of <see cref="EngineeringModel" /></returns>
        private IReadOnlyCollection<EngineeringModel> QueryOpenEngineeringModels()
        {
            return this.OpenedIterations.Select(x => (EngineeringModel)x.Container)
                .DistinctBy(x => x.Iid).ToList();
        }

        /// <summary>
        /// Queries all open <see cref="Iteration" />
        /// </summary>
        /// <returns>A collection of <see cref="Iteration" /></returns>
        private IReadOnlyCollection<Iteration> QueryOpenIterations()
        {
            return (!this.IsSessionOpen ? Enumerable.Empty<Iteration>() : this.Session.OpenIterations.Select(x => x.Key)).ToList();
        }
    }
}
