// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsGroup.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;

    /// <summary>
    /// Extended part for the auto-generated <see cref="RequirementsGroup"/>
    /// </summary>
    public partial class RequirementsGroup
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{RequirementsGroup}"/> with all the <see cref="RequirementsGroup"/> contained by 
        /// this <see cref="RequirementsGroup"/> and its children <see cref="RequirementsGroup"/>s
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{RequirementsGroup}"/> that is "contained" by the current <see cref="RequirementsGroup"/>
        /// </returns>
        public IEnumerable<RequirementsGroup> ContainedGroup()
        {
            var groups = new List<RequirementsGroup>();
            foreach (var group in this.Group)
            {
                groups.Add(group);
                groups.AddRange(group.ContainedGroup());
            }

            return groups;
        }
    }
}