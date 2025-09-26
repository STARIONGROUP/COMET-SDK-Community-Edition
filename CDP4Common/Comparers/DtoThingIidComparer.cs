// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoThingIidComparer.cs" company="Starion Group S.A.">
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
    using CDP4Common.DTO;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation of customized equality comparison for collections for <see cref="Thing"/>.
    /// </summary>
    public class DtoThingIidComparer : IEqualityComparer<Thing>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="t1">the first <see cref="Thing"/> to compare.</param>
        /// <param name="t2">the second <see cref="Thing"/> to compare.</param>
        /// <returns>
        /// True if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(Thing t1, Thing t2)
        {
            if (t2 == null && t1 == null)
                return true;
            else if (t1 == null || t2 == null)
                return false;
            else if (t1.Iid.Equals(t2.Iid))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> for which a hash code is to be returned.</param>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        public int GetHashCode(Thing thing)
        {
            return thing.Iid.GetHashCode();
        }
    }
}