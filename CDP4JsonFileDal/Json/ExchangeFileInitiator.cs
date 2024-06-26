﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExchangeFileInitiator.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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

namespace CDP4JsonFileDal.Json
{
    using System;

    /// <summary>
    /// The initiator (person) of an exchange file export.
    /// This is included in the <see cref="ExchangeFileHeader"/>
    /// </summary>
    public class ExchangeFileInitiator
    {
        /// <summary>
        /// Gets or sets an optional unique identifier of the person who initiated the export.
        /// </summary>
        public Guid? Iid { get; set; }

        /// <summary>
        /// Gets or sets the given name of the person who initiated the export.
        /// </summary>
        public string GivenName { get; set; }
        
        /// <summary>
        /// Gets or sets the surname of the person who initiated the export.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the optional email address of the person who initiated the export.
        /// </summary>
        public string Email { get; set; }
    }
}
