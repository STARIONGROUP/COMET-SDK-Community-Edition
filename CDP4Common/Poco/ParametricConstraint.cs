// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametricConstraint.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParametricConstraint"/>
    /// </summary>
    public partial class ParametricConstraint
    {
        /// <summary>
        /// Returns the derived <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as Requirement;
            if (container == null)
            {
                throw new NullReferenceException("The container of ParametricConstraint is null");
            }

            return container.Owner;
        }
    }
}