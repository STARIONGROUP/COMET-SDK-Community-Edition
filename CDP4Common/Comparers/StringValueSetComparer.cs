// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringValueSetComparer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4Common.Comparers
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.Types;

    /// <summary>
    /// Default comparer to be used when comparing <see cref="ValueArray{String}"/>s of the string type.
    /// </summary>
    public class StringValueSetComparer : IComparer<ValueArray<string>>
    {
        /// <summary>Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.</summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.
        ///  Value
        ///  Meaning
        ///  Less than zero
        /// <paramref name="x" /> is less than <paramref name="y" />.
        ///  Zero
        /// <paramref name="x" /> equals <paramref name="y" />.
        ///  Greater than zero
        /// <paramref name="x" /> is greater than <paramref name="y" />.</returns>
        public int Compare(ValueArray<string> x, ValueArray<string> y) => 
            string.Compare(x?.ToString(), y?.ToString(), StringComparison.Ordinal);
    }
}