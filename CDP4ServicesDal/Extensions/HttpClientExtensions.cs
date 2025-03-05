// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpClientExtensions.cs" company="Starion Group S.A.">
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

namespace CDP4ServicesDal.Extensions
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    using CDP4Dal.DAL;

    using CDP4DalCommon.Authentication;

    /// <summary>
    /// Extension class for <see cref="HttpClient"/>
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Set value of the Authorization Header based on a provided <see cref="AuthenticationSchemeKind"/>
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/></param>
        /// <param name="scheme">The <see cref="AuthenticationSchemeKind"/></param>
        /// <param name="authorizationHeaderValue">The authorization value</param>
        public static void SetAuthorizationHeader(this HttpClient client, AuthenticationSchemeKind scheme, string authorizationHeaderValue)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme.ToString(), authorizationHeaderValue);
        }
        
        /// <summary>
        /// Set value of the Authorization Header based on a provided <see cref="Credentials"/>
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/></param>
        /// <param name="credentials">The <see cref="Credentials"/></param>
        public static void SetAuthorizationHeader(this HttpClient client, Credentials credentials)
        {
            switch (credentials.AuthenticationScheme)
            {
                case AuthenticationSchemeKind.Basic:
                    client.SetAuthorizationHeader(credentials.AuthenticationScheme!.Value, Convert.ToBase64String(Encoding.UTF8.GetBytes($"{credentials.UserName}:{credentials.Password}")));
                    break;
                case AuthenticationSchemeKind.ExternalJwtBearer:
                case AuthenticationSchemeKind.LocalJwtBearer:
                    client.SetAuthorizationHeader(credentials.AuthenticationScheme!.Value, credentials.Tokens.AccessToken);
                    break;
            }
        }
    }
}
