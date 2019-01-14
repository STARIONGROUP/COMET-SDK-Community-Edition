#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateComparer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// The <see cref="IComparer{T}"/> used to sort <see cref="ActualFiniteState"/> from its Name
    /// </summary>
    public class ActualFiniteStateComparer : IComparer<ActualFiniteState>
    {
        /// <summary>
        /// Compares two <see cref="ActualFiniteState"/> and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first <see cref="ActualFiniteState"/></param>
        /// <param name="y">The second <see cref="ActualFiniteState"/></param>
        /// <returns>
        /// Less than zero : x is less than y. 
        /// Zero: x equals y. 
        /// Greater than zero: x is greater than y.
        /// </returns>
        public int Compare(ActualFiniteState x, ActualFiniteState y)
        {
            var xContainer = x.Container as ActualFiniteStateList;
            var yContainer = y.Container as ActualFiniteStateList;

            if (xContainer == null || yContainer == null || xContainer.Iid != yContainer.Iid)
            {
                throw new InvalidOperationException("Cannot compare 2 ActualFiniteState in different Lists or one of the container is null.");
            }

            if (x.Iid == y.Iid)
            {
                return 0;
            }

            var xKey = this.GetComputedSortKey(x, xContainer);
            var yKey = this.GetComputedSortKey(y, yContainer);

            return xKey - yKey;
        }

        /// <summary>
        /// Compute the sort key of a <see cref="ActualFiniteState"/> based on the <see cref="ActualFiniteState.PossibleState"/> property
        /// </summary>
        /// <param name="actualState">The <see cref="ActualFiniteState"/></param>
        /// <param name="actualList">The <see cref="ActualFiniteStateList"/> container</param>
        /// <returns>The sort-key</returns>
        private int GetComputedSortKey(ActualFiniteState actualState, ActualFiniteStateList actualList)
        {
            // The OCDT WSP may return a broken model where the actualState.PossibleState is empty.
            if (actualState.PossibleState.Count == 0)
            {
                return Int32.MaxValue;
            }

            var possibleFiniteStateListsSize = actualList.PossibleFiniteStateList.SortedItems.Values.Select(x => x.PossibleState.Count).ToList();
            var orderKey = 0;
            foreach (var possibleState in actualState.PossibleState)
            {
                var power = 1;
                var containerPossibleFiniteStateList = (PossibleFiniteStateList)possibleState.Container;
                var position = containerPossibleFiniteStateList.PossibleState.IndexOf(possibleState);

                for (var i = actualList.PossibleFiniteStateList.IndexOf(containerPossibleFiniteStateList) + 1; i < possibleFiniteStateListsSize.Count; i++)
                {
                    power = power * possibleFiniteStateListsSize[i];
                }

                orderKey += power * position;
            }

            return orderKey;
        }
    }
}