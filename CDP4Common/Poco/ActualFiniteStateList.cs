// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateList.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System.Linq;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ActualFiniteStateList"/>
    /// </summary>
    public partial class ActualFiniteStateList
    {
        /// <summary>
        /// Gets the user-friendly name
        /// </summary>
        public override string UserFriendlyName
        {
            get { return this.Name; }
        }

        /// <summary>
        /// Gets the user-friendly short name
        /// </summary>
        public override string UserFriendlyShortName
        {
            get { return this.ShortName; }
        }

        /// <summary>
        /// Returns the derived <see cref="Name"/> value
        /// </summary>
        /// <returns>The <see cref="Name"/> value</returns>
        protected string GetDerivedName()
        {
            return string.Join(" → ", this.PossibleFiniteStateList.Select(x => x.Name));
        }

        /// <summary>
        /// Returns the derived <see cref="ShortName"/> value
        /// </summary>
        /// <returns>The <see cref="ShortName"/> value</returns>
        protected string GetDerivedShortName()
        {
            return string.Join(".", this.PossibleFiniteStateList.Select(x => x.ShortName));
        }
    }
}