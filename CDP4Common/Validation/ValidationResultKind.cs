// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationResultKind.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Validation
{
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Enumeration datatype that defines the overall result of processing the Parameter sheet
    /// </summary>
    public enum ValidationResultKind
    {
        /// <summary>
        /// The validation result is inconclusive
        /// </summary>        
        InConclusive = 0,

        /// <summary>
        /// The value is valid
        /// </summary>
        Valid = 1,

        /// <summary>
        /// The value is valid, but outside of the permissible values
        /// </summary>
        /// <remarks>
        /// This is only relevant for <see cref="QuantityKind"/>s where the <see cref="MeasurementScale"/> minimumPermissibleValue and maximumPermissibleValue are set.
        /// </remarks>
        OutOfBounds = 2,

        /// <summary>
        /// The value is invalid
        /// </summary>
        Invalid = 3
    }
}