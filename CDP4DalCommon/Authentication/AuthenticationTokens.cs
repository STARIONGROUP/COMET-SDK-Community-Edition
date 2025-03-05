// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationTokens.cs" company="Starion Group S.A.">
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

namespace CDP4DalCommon.Authentication
{
    /// <summary>
    /// The <see cref="AuthenticationTokens" /> provides data structure for generated token, used for authentication
    /// </summary>
    public class AuthenticationTokens
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationTokens" /> structure.
        /// </summary>
        /// <param name="accessToken">The generated access token</param>
        /// <param name="refreshToken">The generated refresh token</param>
        public AuthenticationTokens(string accessToken, string refreshToken)
        {
            this.AccessToken = accessToken;
            this.RefreshToken = refreshToken;
        }

        /// <summary>
        /// Gets the generated access token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets the generated refresh token
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
