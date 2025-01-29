// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AvailableAuthenticationScheme.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// Provides information about available Authentication scheme supported by the CDP4 Comet data source
    /// </summary>
    public class AuthenticationSchemeResponse
    {
        /// <summary>
        /// Gets or set a <see cref="List{T}" /> of available <see cref="AuthenticationSchemeKind"/>
        /// </summary>
        public List<AuthenticationSchemeKind> Schemes { get; set; } = [];

        /// <summary>
        /// Gets or sets a potentiel URL that should be used as redirection to access login interface
        /// </summary>
        public string RedirectUrl { get; set; }
    }
}
