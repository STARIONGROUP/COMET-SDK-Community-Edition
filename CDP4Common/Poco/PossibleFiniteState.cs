// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PossibleFiniteState.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="PossibleFiniteState"/>
    /// </summary>
    public partial class PossibleFiniteState
    {
        /// <summary>
        /// Returns the derived <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as PossibleFiniteStateList;
            if (container == null)
            {
                throw new NullReferenceException("The container of PossibleFiniteState is null");
            }

            return container.Owner;
        }

        /// <summary>
        /// Gets a value indicating whether this is the default <see cref="PossibleFiniteState"/> of a <see cref="PossibleFiniteStateList"/>
        /// </summary>
        public bool IsDefault
        {
            get
            {
                var possibleFiniteStateList = this.Container as PossibleFiniteStateList;
                if (possibleFiniteStateList == null)
                {
                    throw new InvalidOperationException("The Container of this PossibleFiniteState is not a PossibleFiniteStateList.");
                }

                return possibleFiniteStateList.DefaultState == this;
            }
        }
    }
}