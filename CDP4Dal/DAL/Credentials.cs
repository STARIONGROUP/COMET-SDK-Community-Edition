// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Credentials.cs" company="Starion Group S.A.">
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

    using CDP4DalCommon.Authentication;

    /// <summary>
    /// The purpose of the <see cref="Credentials"/> class is to store the username, password and <see cref="Uri"/>
    /// of a data-store that an implementation of <see cref="Dal"/> will connect to.
    /// </summary>
    public class Credentials
    {
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
        /// <param name="fullTrust">
        /// A value indicating whether the connection shall be fully trusted or not (in case of HttpClient connections
        /// this includes trusing self signed SSL certificates)
        /// </param>
        /// <param name="proxySettings">
        /// The <see cref="ProxySettings"/> used to encapsulate proxy server settings
        /// </param>
        public Credentials(string username, string password, Uri uri, bool fullTrust = false, ProxySettings proxySettings = null) : this(uri, fullTrust, proxySettings)
        {
            this.ProvideUserCredentials(username, password, AuthenticationSchemeKind.Basic);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class
        /// </summary>
        /// <param name="uri">The <see cref="Uri"/> of the data-store</param>
        /// <param name="fullTrust">A value indicating whether the connection shall be fully trusted or not (in case of HttpClient connections
        /// this includes trusing self signed SSL certificates)</param>
        /// <param name="proxySettings">The <see cref="ProxySettings"/> used to encapsulate proxy server settings</param>
        public Credentials(Uri uri, bool fullTrust = false, ProxySettings proxySettings = null)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri), "The uri may not be null");
            }

            this.Uri = uri;
            this.FullTrust = fullTrust;
            this.ProxySettings = proxySettings;
        }

        /// <summary>
        /// Provides user credentials. This should be used while using internal authentication scheme (<see cref="AuthenticationSchemeKind.Basic"/> or
        /// <see cref="AuthenticationSchemeKind.LocalJwtBearer"/>
        /// </summary>
        /// <param name="username">
        /// The username that is used to connect to a data-store
        /// </param>
        /// <param name="password">
        /// the password that is sued to connect to a data-store
        /// </param>
        /// <param name="authenticationSchemeKind">The <see cref="AuthenticationSchemeKind"/> that is used to connect to a data-store</param>
        /// <exception cref="ArgumentNullException">If the username or the password are null or empty</exception>
        /// <exception cref="ArgumentException">If the <paramref name="authenticationSchemeKind"/> is not <see cref="AuthenticationSchemeKind.Basic"/> or
        /// <see cref="AuthenticationSchemeKind.LocalJwtBearer"/></exception>
        public void ProvideUserCredentials(string username, string password, AuthenticationSchemeKind authenticationSchemeKind)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username), "The username may not be empty or null");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password), "The password may not be empty or null");
            }

            if (authenticationSchemeKind != AuthenticationSchemeKind.Basic && authenticationSchemeKind != AuthenticationSchemeKind.LocalJwtBearer)
            {
                throw new ArgumentException("The authentication scheme must be Basic or LocalJwtBearer", nameof(authenticationSchemeKind));
            }

            this.UserName = username;
            this.Password = password;
            this.AuthenticationScheme = authenticationSchemeKind;
        }

        /// <summary>
        /// Provides User token, generated from the internal or from an external authentication provider
        /// </summary>
        /// <param name="authenticationToken">The generated token</param>
        /// <param name="authenticationSchemeKind">The <see cref="AuthenticationSchemeKind"/> that is used to connect to a data-store</param>
        /// <exception cref="ArgumentNullException">If the provided token is null or empty</exception>
        /// <exception cref="ArgumentException">If the <paramref name="authenticationSchemeKind"/> is not <see cref="AuthenticationSchemeKind.ExternalJwtBearer"/> or
        /// <see cref="AuthenticationSchemeKind.LocalJwtBearer"/></exception>
        public void ProvideUserToken(AuthenticationToken authenticationToken, AuthenticationSchemeKind authenticationSchemeKind)
        {
            if (authenticationToken == null)
            {
                throw new ArgumentNullException(nameof(authenticationToken), "The authentication token may not be null");
            }

            if (string.IsNullOrEmpty(authenticationToken.AccessToken))
            {
                throw new ArgumentException("The access-token may not be empty or null", nameof(authenticationToken));
            }

            if (authenticationSchemeKind != AuthenticationSchemeKind.LocalJwtBearer && authenticationSchemeKind != AuthenticationSchemeKind.ExternalJwtBearer)
            {
                throw new ArgumentException("The authentication scheme must be either LocalJwtBearer or ExternalJwtBearer", nameof(authenticationSchemeKind));
            }

            this.Token = authenticationToken;
            this.AuthenticationScheme = authenticationSchemeKind;
        }

        /// <summary>
        /// Gets the access token
        /// </summary>
        public AuthenticationToken Token { get; private set; }

        /// <summary>
        /// Gets the username that is used to connect to a data-store
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets the password that is used to connect to a data-store
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the data-store 
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the connection shall be fully trusted or not (in case of HttpClient connections
        /// this includes trusing self signed SSL certificates).
        /// </summary>
        public bool FullTrust { get; private set; }

        /// <summary>
        /// Gets the settings used to connect to a Proxy server
        /// </summary>
        /// <remarks>
        /// The <see cref="ProxySettings"/> may be null, no proxy will be used in this case.
        /// </remarks>
        public ProxySettings ProxySettings { get; private set; }

        /// <summary>
        /// Gets the <see cref="AuthenticationSchemeKind"/> that should be used to authenticate against the datasource
        /// </summary>
        public AuthenticationSchemeKind? AuthenticationScheme { get; private set; }

        /// <summary>
        /// Provides an asserts to assess that all informations are ready to be provided  
        /// </summary>
        public bool IsFullyInitialized => this.ComputeIsFullyInitialized();

        /// <summary>
        /// Compute the <see cref="IsFullyInitialized"/> property
        /// </summary>
        /// <returns>The asserts computated</returns>
        private bool ComputeIsFullyInitialized()
        {
            if (this.Uri == null || this.AuthenticationScheme == null)
            {
                return false;
            }

            if (this.AuthenticationScheme == AuthenticationSchemeKind.Basic)
            {
                return !string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password);
            }

            return !string.IsNullOrEmpty(this.Token.AccessToken);
        }
    }
}