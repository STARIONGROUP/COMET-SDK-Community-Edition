// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AutomaticTokenRefreshService.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Dal;

    using CDP4DalCommon.Authentication;

    using CDP4ServicesDal.ExternalAuthenticationProviderService;

    using NLog;
    using NLog.Fluent;

    using Polly;
    using Polly.Retry;

    /// <summary>
    /// The <see cref="IAutomaticTokenRefreshService" /> provides automatic refresh of <see cref="AuthenticationTokens" />
    /// capabilities
    /// </summary>
    public class AutomaticTokenRefreshService : IAutomaticTokenRefreshService
    {
        /// <summary>
        /// Gets the <see cref="IOpenIdConnectService" /> used to interact with the external authentication provider
        /// </summary>
        private readonly IOpenIdConnectService openIdConnectService;

        /// <summary>
        /// Gets the <see cref="CancellationTokenSource" /> used to cancel delaying Task
        /// </summary>
        private CancellationTokenSource cancellationTokenSource;

        /// <summary>
        /// Gets an optional client secret value
        /// </summary>
        private string externalProviderClientSecret;

        /// <summary>
        /// Gets the last <see cref="AuthenticationSchemeResponse" /> that provides information in case of an External Authentication provier
        /// </summary>
        private AuthenticationSchemeResponse lastAuthenticationSchemeResponse;

        /// <summary>
        /// Gets the tied <see cref="ISession" />
        /// </summary>
        private ISession relatedSession;

        /// <summary>
        /// Gets the <see cref="AsyncRetryPolicy"/> that provides resilience to this service
        /// </summary>
        private readonly AsyncRetryPolicy retryPolicy;
        
        /// <summary>
        /// The NLog Logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>Initializes a new instance of the <see cref="AutomaticTokenRefreshService" /> class.</summary>
        /// <param name="openIdConnectService">The <see cref="IOpenIdConnectService" /> used to interact with the external authentication provider</param>
        public AutomaticTokenRefreshService(IOpenIdConnectService openIdConnectService)
        {
            this.openIdConnectService = openIdConnectService;
            
            this.retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, timeSpan, retryCount, _) =>
                    {
                        Logger.Warn($"Retry {retryCount} after {timeSpan.TotalSeconds}s due to: {exception.Message}");
                    });
        }

        /// <summary>
        /// The <see cref="Func{TValue}"/> that provides notification that tokens has been refreshed
        /// </summary>
        public event Func<Task> TokenRefreshed;

        /// <summary>
        /// Starts the service to wait before refreshing the token automatically
        /// </summary>
        /// <returns>An awaitable <see cref="Task" /></returns>
        /// <exception cref="InvalidOperationException">If the service has already been started</exception>
        public async Task StartAsync()
        {
            if (this.relatedSession == null)
            {
                throw new InvalidOperationException("This service must be initialize first");
            }

            if (this.cancellationTokenSource != null)
            {
                throw new InvalidOperationException("This service has already been started.");
            }
            
            if (this.relatedSession.Dal is not CdpServicesDal || (this.relatedSession.Credentials.AuthenticationScheme != AuthenticationSchemeKind.LocalJwtBearer 
                                                                  && this.relatedSession.Credentials.AuthenticationScheme != AuthenticationSchemeKind.ExternalJwtBearer))
            {
                return;
            }

            this.cancellationTokenSource = new CancellationTokenSource();

            while (!this.cancellationTokenSource.IsCancellationRequested)
            {
                var expiresTimes = this.ExtractDelayBeforeExpireTimeFromToken();

                if (expiresTimes <= 0)
                {
                    break;
                }

                if (string.IsNullOrEmpty(this.relatedSession.Credentials.Tokens.RefreshToken))
                {
                    break;
                }

                var shouldRefreshIn = (int)Math.Round(expiresTimes * 4 / 5f);

                try
                {
                    await Task.Delay(shouldRefreshIn * 1000, this.cancellationTokenSource.Token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }

                await this.retryPolicy.ExecuteAsync(this.RefreshAuthenticationTokenAsync);
                
                await this.relatedSession.RefreshAuthenticationInformation();

                if (this.TokenRefreshed != null)
                {
                    await this.TokenRefreshed.Invoke();
                }
            }
            
            this.Dispose();
        }

        /// <summary>
        /// Initialize this service properties
        /// </summary>
        /// <param name="session">The <see cref="ISession" /> that should refresh token</param>
        /// <param name="authenticationSchemeResponse">The <see cref="AuthenticationSchemeResponse" /> that would provides information in case of an External authentication provider</param>
        /// <param name="clientSecret">An optional client secret</param>
        /// <exception cref="InvalidOperationException">If the service has already been initialized</exception>
        public void Initialize(ISession session, AuthenticationSchemeResponse authenticationSchemeResponse, string clientSecret = null)
        {
            if (this.cancellationTokenSource != null)
            {
                throw new InvalidOperationException("This service is currently running.");
            }

            this.relatedSession = session;
            this.lastAuthenticationSchemeResponse = authenticationSchemeResponse;
            this.externalProviderClientSecret = clientSecret;
        }

        /// <summary>
        /// Refreshes the authentication token based on a refresh token
        /// </summary>
        /// <exception cref="InvalidOperationException">If the service has not been initialized</exception>
        public async Task RefreshAuthenticationTokenAsync()
        {
            if (this.relatedSession == null)
            {
                throw new InvalidOperationException("This service is not initialized.");
            }

            if (this.relatedSession.Credentials.Tokens == null)
            {
                throw new InvalidOperationException("Related credentials does not contains any tokens.");
            }

            if (this.relatedSession.Credentials.AuthenticationScheme == AuthenticationSchemeKind.LocalJwtBearer)
            {
                await this.relatedSession.RequestAuthenticationTokenBasedOnRefreshToken();
            }
            else
            {
                var authenticationToken = await this.openIdConnectService.RequestAuthenticationToken(this.relatedSession.Credentials.Tokens.RefreshToken, this.lastAuthenticationSchemeResponse,
                    clientSecret: this.externalProviderClientSecret);

                this.relatedSession.Credentials.ProvideUserToken(authenticationToken, AuthenticationSchemeKind.ExternalJwtBearer);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.cancellationTokenSource?.Cancel();
            this.cancellationTokenSource?.Dispose();
            this.cancellationTokenSource = null;
        }

        /// <summary>
        /// Extract the expire time from the JWT token and calculates the delay before it expires
        /// </summary>
        /// <returns>The delay before time expiration</returns>
        private int ExtractDelayBeforeExpireTimeFromToken()
        {
            var token = new JwtSecurityTokenHandler().ReadJwtToken(this.relatedSession.Credentials.Tokens.AccessToken);
            return (token.ValidTo - DateTime.UtcNow).Seconds;
        }
    }
}
