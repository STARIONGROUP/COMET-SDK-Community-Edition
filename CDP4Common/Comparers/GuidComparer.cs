// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuidComparer.cs" company="Starion Group S.A.">
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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// an IComparer to compare <see cref="Guid"/>s
    /// </summary>
    public class GuidComparer : IComparer<Guid>
    {
        /// <summary>
        /// Compares this instance to a specified object or Guid and returns an indication of their relative values
        /// </summary>
        /// <param name="x">the first <see cref="Guid"/> to compare</param>
        /// <param name="y">the second <see cref="Guid"/> to compare</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and value.
        /// </returns>
        public int Compare(Guid x, Guid y)
        {
            return x.CompareTo(y);
        }
    }
}