// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionComparer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Comparers
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// A comparer class for <see cref="Option"/> where the order of a <see cref="Option"/>
    /// is determined by Order of the <see cref="Option"/>s in the contained <see cref="Iteration"/>
    /// </summary>
    public class OptionComparer : IComparer<Option>
    {
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
        public int Compare(Option x, Option y)
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

