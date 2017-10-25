// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleVerification.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="RuleVerification"/>
    /// </summary>
    public abstract partial class RuleVerification
    {
        /// <summary>
        /// Returns the <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as RuleVerificationList;
            if (container == null)
            {
                throw new NullReferenceException("Container of ActualFiniteState is null");
            }

            return container.Owner;
        }
    }
}