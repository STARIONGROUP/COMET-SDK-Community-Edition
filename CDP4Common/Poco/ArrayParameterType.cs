// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayParameterType.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Linq;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ArrayParameterType"/>
    /// </summary>
    public partial class ArrayParameterType
    {
        /// <summary>
        /// Returns the derived <see cref="HasSingleComponentType"/> value
        /// </summary>
        /// <returns>The <see cref="HasSingleComponentType"/> value</returns>
        protected bool GetDerivedHasSingleComponentType()
        {
            return this.Component.Select(component => component.ParameterType).Distinct().Count() == 1;
        }

        /// <summary>
        /// Returns the derived <see cref="Rank"/> value
        /// </summary>
        /// <returns>The <see cref="Rank"/> value</returns>
        protected int GetDerivedRank()
        {
            return this.Dimension.Count;
        }
    }
}