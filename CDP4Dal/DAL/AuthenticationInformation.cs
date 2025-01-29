// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationInformation.cs" company="Starion Group S.A.">
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

namespace CDP4Dal.DAL
{
    /// <summary>
    /// The <see cref="AuthenticationInformation"/> provides information that should be used to authenticate against a data-source
    /// </summary>
    public struct AuthenticationInformation
    {
        /// <summary>
        /// Gets the username that should be used for authentication
        /// </summary>
        public string UserName { get; }
        
        /// <summary>
        /// Gets the password that should be used for authentication
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Gets the token that should be used for authentication
        /// </summary>
        public string Token { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationInformation"></see> class.
        /// </summary>
        /// <param name="userName">The provided username</param>
        /// <param name="password">The provided password</param>
        public AuthenticationInformation(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationInformation"></see> class.
        /// </summary>
        /// <param name="token">The provided token</param>
        public AuthenticationInformation(string token)
        {
            this.Token = token;
        }
    }
}
