// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderedItemComparer.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Comparers
{
    using System.Collections.Generic;
    using CDP4Common.Types;

    /// <summary>
    /// an IComparer to compare <see cref="OrderedItem"/>s
    /// </summary>
    public class OrderedItemComparer : IComparer<OrderedItem>
    {
        /// <summary>
        /// Compares two instances of <see cref="OrderedItem"/> based on the value of their respective keys (K).
        /// </summary>
        /// <param name="x">the first <see cref="OrderedItem"/> to compare</param>
        /// <param name="y">the second <see cref="OrderedItem"/> to compare</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value.
        /// </returns>
        public int Compare(OrderedItem x, OrderedItem y)
        {
            return x.K.CompareTo(y.K);
        }
    }
}