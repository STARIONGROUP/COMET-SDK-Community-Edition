// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBaseExtensions.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Extensions
{
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Types;

    using ParameterValueSetBase = CDP4Common.DTO.ParameterValueSetBase;

    /// <summary>
    /// Extension class for the <see cref="ParameterValueSetBase" /> class
    /// </summary>
    public static class ParameterValueSetBaseExtensions
    {
        /// <summary>
        /// Queries all <see cref="ValueArray{T}" /> of an <see cref="ParameterValueSetBase" />, with the respecting name of the
        /// <see cref="ValueArray{T}" /> kind
        /// </summary>
        /// <param name="valueSet">
        /// The <see cref="ParameterValueSetBase" /> used to retrieve all <see cref="ValueArray{T}" />
        /// </param>
        /// <returns>
        /// A <see cref="IEnumerable{T}" /> of combinaison of <see cref="ValueArray{T}" /> and the
        /// <see cref="ValueArray{T}" /> kind
        /// </returns>
        public static IEnumerable<(ValueArray<string> valueArray, ParameterSwitchKind switchKind)> QueryAllValueArrays(this ParameterValueSetBase valueSet)
        {
            yield return (valueSet.Manual, ParameterSwitchKind.MANUAL);
            yield return (valueSet.Reference, ParameterSwitchKind.REFERENCE);
            yield return (valueSet.Computed, ParameterSwitchKind.COMPUTED);
        }
    }
}
