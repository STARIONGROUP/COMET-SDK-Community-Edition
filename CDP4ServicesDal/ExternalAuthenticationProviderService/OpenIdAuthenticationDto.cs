// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenIdAuthenticationDto.cs" company="Starion Group S.A.">
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

namespace CDP4ServicesDal.ExternalAuthenticationProviderService
{
    using CDP4DalCommon.Authentication;

    /// <summary>
    /// The <see cref="OpenIdAuthenticationDto" /> provides data model structure for response of a successfull openid authentication result
    /// </summary>
    public class OpenIdAuthenticationDto : AuthenticationTokens
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenIdAuthenticationDto" /> structure.
        /// </summary>
        /// <param name="accessToken">The generated access token</param>
        /// <param name="refreshToken">The generated refresh token</param>
        /// <param name="expiresIn">The expires time of the access token, in seconds</param>
        /// <param name="refreshExpiresIn">The expires time of the refresh token, in seconds</param>
        public OpenIdAuthenticationDto(string accessToken, string refreshToken, int expiresIn, int refreshExpiresIn) : base(accessToken, refreshToken)
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
            this.ExpiresIn = expiresIn;
            this.RefreshExpiresIn = refreshExpiresIn;
        }

        /// <summary>
        /// The expires time of the <see cref="AuthenticationTokens.AccessToken" />, in seconds
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// The expires time of the <see cref="AuthenticationTokens.RefreshToken" />, in seconds
        /// </summary>
        public int RefreshExpiresIn { get; set; }
    }
}
