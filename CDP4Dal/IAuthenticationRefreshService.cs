// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IAutomaticTokenRefreshService.cs" company="Starion Group S.A.">
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

namespace CDP4Dal
{
    using System;
    using System.Threading.Tasks;

    using CDP4DalCommon.Authentication;

    /// <summary>
    /// The <see cref="IAuthenticationRefreshService" /> provides authentication information refresh
    /// capabilities
    /// </summary>
    public interface IAuthenticationRefreshService: IDisposable
    {
        /// <summary>
        /// Starts the service to wait before refreshing authentication information automatically
        /// </summary>
        /// <returns>An awaitable <see cref="Task" /></returns>
        Task StartAsync();

        /// <summary>
        /// Initialize this service properties
        /// </summary>
        /// <param name="session">The <see cref="ISession" /> that should refresh token</param>
        /// <param name="authenticationSchemeResponse">The <see cref="AuthenticationSchemeResponse" /> that would provides information in case of an External authentication provider</param>
        /// <param name="clientSecret">An optional client secret</param>
        /// <exception cref="InvalidOperationException">If the service has already been initialized</exception>
        void Initialize(ISession session, AuthenticationSchemeResponse authenticationSchemeResponse, string clientSecret = null);

        /// <summary>
        /// Refreshes the authentication information
        /// </summary>
        /// <exception cref="InvalidOperationException">If the service has not been initialized</exception>
        Task RefreshAuthenticationInformationAsync();

        /// <summary>
        /// The <see cref="Func{TValue}"/> that provides notification that authentication information has been refreshed
        /// </summary>
        event Func<Task> AuthenticationRefreshed;
    }
}
