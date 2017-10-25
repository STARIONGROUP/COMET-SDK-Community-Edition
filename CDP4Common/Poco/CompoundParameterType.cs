// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompoundParameterType.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Linq;

    /// <summary>
    /// Extended part for the auto-generated <see cref="CompoundParameterType"/>
    /// </summary>
    public partial class CompoundParameterType
    {
        /// <summary>
        /// Gets the number of values for this <see cref="CompoundParameterType"/>
        /// </summary>
        /// <returns>The Number of Values of this <see cref="CompoundParameterType"/></returns>
        protected override int GetDerivedNumberOfValues()
        {
            return this.Component.Sum(component => component.ParameterType.NumberOfValues);
        }
    }
}