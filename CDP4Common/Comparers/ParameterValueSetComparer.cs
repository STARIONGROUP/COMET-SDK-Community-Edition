// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetComparer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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