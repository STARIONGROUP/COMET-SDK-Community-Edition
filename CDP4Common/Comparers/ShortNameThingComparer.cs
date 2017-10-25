// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortNameThingComparer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Comparers
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;

    public class ShortNameThingComparer : IComparer<IShortNamedThing>
    {
        /// <summary>Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.</summary>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.</returns>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        public int Compare(IShortNamedThing x, IShortNamedThing y)
        {
            return System.String.Compare(x.ShortName, y.ShortName, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
