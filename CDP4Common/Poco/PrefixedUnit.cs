// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrefixedUnit.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    /// <summary>
    /// Extended part for the auto-generated <see cref="PrefixedUnit"/>
    /// </summary>
    public partial class PrefixedUnit
    {
        /// <summary>
        /// Returns the derived <see cref="ConversionFactor"/> value
        /// </summary>
        /// <returns>The <see cref="ConversionFactor"/> value</returns>
        protected string GetDerivedConversionFactor()
        {
            return this.Prefix == null ? string.Empty : this.Prefix.ConversionFactor;
        }

        /// <summary>
        /// Returns the derived <see cref="Name"/> value
        /// </summary>
        /// <returns>The <see cref="Name"/> value</returns>
        protected string GetDerivedName()
        {
            if (this.Prefix != null && this.ReferenceUnit != null)
            {
                return this.Prefix.Name + this.ReferenceUnit.Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns the derived <see cref="ShortName"/> value
        /// </summary>
        /// <returns>The <see cref="ShortName"/> value</returns>
        protected string GetDerivedShortName()
        {
            if (this.Prefix != null && this.ReferenceUnit != null)
            {
                return this.Prefix.ShortName + this.ReferenceUnit.ShortName;
            }

            return string.Empty;
        }
    }
}