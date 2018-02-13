#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBaseComparer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4Common.Comparers
{
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The <see cref="IComparer{T}"/> used to sort <see cref="ParameterBase"/> from the Name of its <see cref="ParameterType"/>
    /// </summary>
    public class ParameterBaseComparer : IComparer<ParameterBase>
    {
        /// <summary>
        /// Compares two <see cref="ParameterBase"/> and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first <see cref="ParameterBase"/></param>
        /// <param name="y">The second <see cref="ParameterBase"/></param>
        /// <returns>
        /// Less than zero : x is less than y. 
        /// Zero: x equals y. 
        /// Greater than zero: x is greater than y.
        /// </returns>
        public int Compare(ParameterBase x, ParameterBase y)
        {
            return System.String.Compare(x.ParameterType.Name, y.ParameterType.Name, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}