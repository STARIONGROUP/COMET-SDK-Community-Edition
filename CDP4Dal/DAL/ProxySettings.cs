// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProxySettings.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Dal.DAL
{
    using System;
    using CDP4Dal.Composition;

    /// <summary>
    /// The purpose of the <see cref="ProxySettings"/> is to encapsulate the proxy server settings used
    /// when connecting to a <see cref="DalType.Web"/> data-source
    /// </summary>
    public class ProxySettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxySettings"/> class.
        /// </summary>
        /// <param name="address">
        /// The address of the Web-Proxy server.
        /// </param>
        /// <param name="userName">the UserName used to authenticate on the Web-Proxy server.</param>
        /// <param name="password">the password used to authenticate on the Web-Proxy server.</param>
        /// <remarks>
        /// if the <see cref="UserName"/> is null, then no authentication will be used on the Web-Proxy server.
        /// </remarks>
        public ProxySettings(Uri address, string userName = null, string password = null)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address), "The Web-Proxy address may not be null");
            }

            this.Address = address;
            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the Web-Proxy server
        /// </summary>
        public Uri Address { get; private set; }

        /// <summary>
        /// Gets the UserName used to authenticate when connection to the Web-Proxy server
        /// </summary>
        /// <remarks>
        /// This may be null if no Web-Proxy server authentication is required
        /// </remarks>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the Password used to authenticate when connection to the Web-Proxy server
        /// </summary>
        /// <remarks>
        /// This may be null if no Web-Proxy server authentication is required
        /// </remarks>
        public string Password { get; private set; }
    }
}