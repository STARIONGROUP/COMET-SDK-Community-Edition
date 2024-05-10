// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PossibleFiniteState.cs" company="Starion Group S.A.">
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
    using System;

    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="PossibleFiniteState"/>
    /// </summary>
    public partial class PossibleFiniteState
    {
        /// <summary>
        /// Returns the derived <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as PossibleFiniteStateList;
            if (container == null)
            {
                throw new ContainmentException("The container of PossibleFiniteState is null");
            }

            return container.Owner;
        }

        /// <summary>
        /// Gets a value indicating whether this is the default <see cref="PossibleFiniteState"/> of a <see cref="PossibleFiniteStateList"/>
        /// </summary>
        public bool IsDefault
        {
            get
            {
                var possibleFiniteStateList = this.Container as PossibleFiniteStateList;
                if (possibleFiniteStateList == null)
                {
                    throw new InvalidOperationException("The Container of this PossibleFiniteState is not a PossibleFiniteStateList.");
                }

                return possibleFiniteStateList.DefaultState == this;
            }
        }
    }
}