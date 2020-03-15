// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Requirement.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
    using System;

    /// <summary>
    /// The extended class for <see cref="Requirement"/>
    /// </summary>
    public partial class Requirement
    {
        /// <summary>
        /// Gets the shortname path of the current <see cref="Requirement"/> delimited
        /// by the <paramref name="delimeter"/> character. The shortname path is computed along 
        /// the virtual containment of the "container" groups
        /// </summary>
        /// <param name="delimeter">
        /// The delimeter that is used to separate the parts of the path
        /// </param>
        /// <returns>
        /// A string that concatenates the shortnames of all the <see cref="RequirementsContainer"/> of the
        /// current <see cref="RequirementsContainer"/>
        /// </returns>
        public string GroupPath(char delimeter = '.')
        {
            if (this.Container == null)
            {
                throw new InvalidOperationException("The GroupPath can only be computed when the container property is not null");
            }

            if (this.Group == null)
            {
                var requirementsSpecification = (RequirementsSpecification)this.Container;
                return $"{requirementsSpecification.ShortName}{delimeter}{this.ShortName}";
            }

            var groupPath = this.Group.Path(delimeter);
            return $"{groupPath}{delimeter}{this.ShortName}";
        }
    }
}
