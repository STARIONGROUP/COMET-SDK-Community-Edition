// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetComparer.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Comparers
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// A comparer class for <see cref="ParameterValueSet"/> where the order of a <see cref="ParameterValueSet"/>
    /// is determined by the referenced option and actual finite state and their order
    /// </summary>
    public class ParameterValueSetComparer : IComparer<ParameterValueSet>
    {
        /// <summary>
        /// Compares two <see cref="ParameterValueSet"/>s
        /// </summary>
        /// <param name="x">the first instance of <see cref="ParameterValueSet"/> to compare.</param>
        /// <param name="y">the second instance of <see cref="ParameterValueSet"/> to compare.</param>
        /// <returns>
        /// Less than zero : x is less than y.
        /// Zero: x equals y.
        /// Greater than zero: x is greater than y.
        /// </returns>
        public int Compare(ParameterValueSet x, ParameterValueSet y)
        {
            var optionCompare = CompareOptions(x.ActualOption, y.ActualOption);
            if (optionCompare == 0)
            {
                var actualStateCompare = CompareActualState(x.ActualState, y.ActualState);
                return actualStateCompare;
            }

            return optionCompare;
        }

        /// <summary>
        /// Compare the two instances of <see cref="ActualFiniteState "/>
        /// </summary>
        /// <param name="x">
        /// the first instance of <see cref="ActualFiniteState"/> to compare.
        /// </param>
        /// <param name="y">
        /// the second instance of <see cref="ActualFiniteState"/> to compare.
        /// </param>
        /// <returns>
        /// Less than zero : x is less than y.
        /// Zero: x equals y.
        /// Greater than zero: x is greater than y.
        /// </returns>
        /// <remarks>
        /// the order is determined by the ordering in the container collection
        /// </remarks>
        private static int CompareActualState(ActualFiniteState x, ActualFiniteState y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null && y != null)
            {
                return 1;
            }

            if (x != null && y == null)
            {
                return -1;
            }

            var actualFiniteStateListX = (ActualFiniteStateList)x.Container;
            var actualFiniteStateListY = (ActualFiniteStateList)y.Container;

            if (actualFiniteStateListX != actualFiniteStateListY)
            {
                throw new InvalidOperationException("The ActualFiniteStates are not contained by the same ActualFiniteStateList and cannot be compared");
            }

            var indexX = actualFiniteStateListX.ActualState.IndexOf(x);
            var indexY = actualFiniteStateListY.ActualState.IndexOf(y);

            if (indexX < indexY)
            {
                return -1;
            }

            if (indexX == indexY)
            {
                return 0;
            }

            if (indexX > indexY)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Compares two <see cref="Option"/>s
        /// </summary>
        /// <param name="x">the first instance of <see cref="Option"/> to compare.</param>
        /// <param name="y">the second instance of <see cref="Option"/> to compare.</param>
        /// <returns>
        /// Less than zero : x is less than y.
        /// Zero: x equals y.
        /// Greater than zero: x is greater than y.
        /// </returns>
        /// <remarks>
        /// the order is determined by the ordering in the container collection
        /// </remarks>
        private static int CompareOptions(Option x, Option y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null && y != null)
            {
                return 1;
            }

            if (x != null && y == null)
            {
                return -1;
            }

            var iterationX = (Iteration)x.Container;
            var iterationY = (Iteration)y.Container;

            if (iterationX != iterationY)
            {
                throw new InvalidOperationException("The Options are not contained by the same Iteration and cannot be compared");
            }

            var indexX = iterationX.Option.IndexOf(x);
            var indexY = iterationY.Option.IndexOf(y);

            if (indexX < indexY)
            {
                return -1;
            }

            if (indexX == indexY)
            {
                return 0;
            }

            if (indexX > indexY)
            {
                return 1;
            }

            return 0;
        }
    }
}