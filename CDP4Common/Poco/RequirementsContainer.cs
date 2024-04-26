// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
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
    /// The extended class for <see cref="RequirementsContainer"/>
    /// </summary>
    public abstract partial class RequirementsContainer
    {
        /// <summary>
        /// Returns all the <see cref="RequirementsGroup"/> that are contained
        /// by the current <see cref="RequirementsContainer"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{RequirementsGroup}"/>
        /// </returns>
        public IEnumerable<RequirementsGroup> GetAllContainedGroups()
        {
            foreach (var group in this.Group)
            {
                var containedGroups = group.GetAllContainedGroups();
                foreach (var requirementsGroup in containedGroups)
                {
                    yield return requirementsGroup;
                }

                yield return group;
            }
        }

        /// <summary>
        /// Gets the shortname path of the current <see cref="RequirementsGroup"/> delimited
        /// by the <paramref name="delimeter"/> character
        /// </summary>
        /// <param name="delimeter">
        /// The delimeter that is used to separate the parts of the path
        /// </param>
        /// <returns>
        /// A string that concatenates the shortnames of all the <see cref="RequirementsContainer"/> of the
        /// current <see cref="RequirementsContainer"/>
        /// </returns>
        public string Path(char delimeter = '.')
        {
            var container = this.Container as RequirementsContainer;
            
            if (container != null)
            {
                return $"{container.Path(delimeter)}{delimeter}{this.ShortName}";
            }

            return this.ShortName;
        }
    }
}