// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinedThingComparer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Comparers
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;

    /// <summary>
    /// The <see cref="IComparer{T}"/> used to sort <see cref="DefinedThing"/> from the Name of its <see cref="DefinedThing"/>
    /// </summary>
    public class DefinedThingComparer : IComparer<DefinedThing>
    {
        /// <summary>
        /// Compares two <see cref="DefinedThing"/> and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first <see cref="DefinedThing"/></param>
        /// <param name="y">The second <see cref="DefinedThing"/></param>
        /// <returns>
        /// Less than zero : x is less than y. 
        /// Zero: x equals y. 
        /// Greater than zero: x is greater than y.
        /// </returns>
        public int Compare(DefinedThing x, DefinedThing y)
        {
            return System.String.Compare(x.Name, y.Name, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}