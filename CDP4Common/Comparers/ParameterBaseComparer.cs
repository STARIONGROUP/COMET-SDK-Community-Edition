// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBaseComparer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Comparers
{
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The <see cref="IComparer{T}"/> used to sort <see cref="ParameterBase"/> from the Name of its <see cref="ParameterType"/>
    /// </summary>
    public class ParameterBaseComparer : IComparer<ParameterBase>
    {
        /// <summary>
        /// Compares two <see cref="ParameterBase"/> and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first <see cref="ParameterBase"/></param>
        /// <param name="y">The second <see cref="ParameterBase"/></param>
        /// <returns>
        /// Less than zero : x is less than y. 
        /// Zero: x equals y. 
        /// Greater than zero: x is greater than y.
        /// </returns>
        public int Compare(ParameterBase x, ParameterBase y)
        {
            return System.String.Compare(x.ParameterType.Name, y.ParameterType.Name, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}