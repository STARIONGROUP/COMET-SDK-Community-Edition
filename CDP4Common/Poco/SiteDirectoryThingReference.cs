﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryThingReference.cs" company="Starion Group S.A.">
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

namespace CDP4Common.ReportingData
{
    using CommonData;

    /// <summary>
    /// A thing that references another Thing through its unique identifier and potentially its iteration container's one
    /// </summary>
    public partial class SiteDirectoryThingReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDirectoryThingReference"/> class
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> that this instance references</param>
        /// <remarks>
        /// This is used in the context of a "Create" operation when a new <see cref="ThingReference"/>
        /// </remarks>
        public SiteDirectoryThingReference(Thing thing) : base(thing)
        {
        }
    }
}