// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.Types;

    /// <summary>
    /// Extended part for the auto-generated <see cref="QuantityKind"/>
    /// </summary>
    public abstract partial class QuantityKind
    {
        /// <summary>
        /// Returns the derived <see cref="AllPossibleScale"/> value
        /// </summary>
        /// <returns>The <see cref="AllPossibleScale"/> value</returns>
        protected List<MeasurementScale> GetDerivedAllPossibleScale()
        {
            var allPossibleScale = new List<MeasurementScale>(this.PossibleScale);

            var specializedQuantityKind = this as SpecializedQuantityKind;
            while (specializedQuantityKind != null)
            {
                var generalQuantityKind = specializedQuantityKind.General;
                allPossibleScale = allPossibleScale.Union(generalQuantityKind.PossibleScale).ToList();
                specializedQuantityKind = generalQuantityKind as SpecializedQuantityKind;
            }

            return allPossibleScale;
        }

        /// <summary>
        /// Returns the derived <see cref="QuantityDimensionExponent"/> value
        /// </summary>
        /// <returns>The <see cref="QuantityDimensionExponent"/> value</returns>
        protected OrderedItemList<string> GetDerivedQuantityDimensionExponent()
        {
            throw new NotSupportedException("The QuantityDimensionExponent computation is not supported ny the CDP");
        }

        /// <summary>
        /// Returns the derived <see cref="QuantityDimensionExpression"/> value
        /// </summary>
        /// <returns>The <see cref="QuantityDimensionExpression"/> value</returns>
        protected string GetDerivedQuantityDimensionExpression()
        {
            throw new NotSupportedException("The QuantityDimensionExpression computation is not supported ny the CDP");
        }
    }
}