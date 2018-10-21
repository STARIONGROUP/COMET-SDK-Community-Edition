// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Credentials.cs" company="RHEA System S.A.">
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

namespace CDP4Dal.DAL
{
    using System;

    /// <summary>
    /// The purpose of the <see cref="Credentials"/> class is to store the username, password and <see cref="Uri"/>
    /// of a data-store that an implementation of <see cref="Dal"/> will connect to.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Backing field of the <see cref="Password"/> property where the password is stored
        /// </summary>
        private readonly string password;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class. 
        /// </summary>
        /// <param name="username">
        /// The username that is used to connect to a data-store
        /// </param>
        /// <param name="password">
        /// the password that is sued to connect to a data-store
        /// </param>
        /// <param name="uri">
        /// the <see cref="Uri"/> of the data-store
        /// </param>
        public Credentials(string username, string password, Uri uri, ProxySettings proxySettings = null)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username", "The username may not be empty or null");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password", "The password may not be empty or null");
            }

            if (uri == null)
            {
                throw new ArgumentNullException("uri", "The uri may not be null");
            }

            this.UserName = username;
            this.password = password;
            this.Uri = uri;
            this.ProxySettings = proxySettings;
        }

        /// <summary>
        /// Gets the username that is used to connect to a data-store
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the password that is used to connect to a data-store
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the data-store 
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the settings used to connect to a Proxy server
        /// </summary>
        /// <remarks>
        /// The <see cref="ProxySettings"/> may be null, no proxy will be used in this case.
        /// </remarks>
        public ProxySettings ProxySettings { get; private set; }
    }
}