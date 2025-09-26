// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteState.cs" company="Starion Group S.A.">
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

namespace CDP4Common.EngineeringModelData
{
    using System.Linq;

    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ActualFiniteState"/>
    /// </summary>
    public partial class ActualFiniteState
    {
        /// <summary>
        /// Gets the user-friendly name
        /// </summary>
        public override string UserFriendlyName
        {
            get { return this.Name; }
        }

        /// <summary>
        /// Gets the user-friendly short name
        /// </summary>
        public override string UserFriendlyShortName
        {
            get { return this.ShortName; }
        }

        /// <summary>
        /// Returns the <see cref="Name"/> value
        /// </summary>
        /// <returns>The <see cref="Name"/> value</returns>
        protected string GetDerivedName()
        {
            var container = this.Container as ActualFiniteStateList;
            if (container == null)
            {
                throw new ContainmentException("Container of ActualFiniteState is null");
            }

            // Get the names of the possible states in the same order as the possible state lists of the container actualfinitestatelist
            var possibleFiniteStateListIids = container.PossibleFiniteStateList.Select(x => x.Iid).ToList();
            var sortedNames = new string[possibleFiniteStateListIids.Count];

            foreach (var possibleFiniteState in this.PossibleState)
            {
                var index = possibleFiniteStateListIids.IndexOf(possibleFiniteState.Container.Iid);
                if (index >= 0)
                {
                    sortedNames[index] = possibleFiniteState.Name;
                }
            }

            var name = string.Join(" → ", sortedNames);
            return name;
        }

        /// <summary>
        /// Returns the <see cref="ShortName"/> value
        /// </summary>
        /// <returns>The <see cref="ShortName"/> value</returns>
        protected string GetDerivedShortName()
        {
            var container = this.Container as ActualFiniteStateList;
            if (container == null)
            {
                throw new ContainmentException("Container of ActualFiniteState is null");
            }

            // Get the short names of the possible states in the same order as the possible state lists of the container actualfinitestatelist
            var possibleFiniteStateListIids = container.PossibleFiniteStateList.Select(x => x.Iid).ToList();
            var sortedNames = new string[possibleFiniteStateListIids.Count];

            foreach (var possibleFiniteState in this.PossibleState)
            {
                var index = possibleFiniteStateListIids.IndexOf(possibleFiniteState.Container.Iid);
                if (index >= 0)
                {
                    sortedNames[index] = possibleFiniteState.ShortName;
                }
            }

            var name = string.Join(".", sortedNames);
            return name;
        }

        /// <summary>
        /// Returns the <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as ActualFiniteStateList;
            if (container == null)
            {
                throw new ContainmentException("Container of ActualFiniteState is null");
            }

            return container.Owner;
        }

        /// <summary>
        /// Gets a value indicating whether this is the default <see cref="ActualFiniteState"/> of a <see cref="ActualFiniteStateList"/>
        /// </summary>
        /// <remarks>
        /// The default <see cref="ActualFiniteState"/> is defined as the one which <see cref="PossibleFiniteState"/> are all the default value of their respective <see cref="PossibleFiniteStateList"/>
        /// </remarks>
        public bool IsDefault
        {
            get { return this.PossibleState.All(x => x.IsDefault); }
        }
    }
}