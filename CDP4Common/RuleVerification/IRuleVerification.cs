// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRuleVerification.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;
    
    /// <summary>
    /// Specification of the <see cref="Rule"/> verification interface.
    /// </summary>
    public interface IRuleVerification
    {
        /// <summary>
        /// Verify an <see cref="Iteration"/> with respect to a <see cref="Rule"/> 
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> that is to be verified.
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{RuleViolation}"/>, this may be empty of no <see cref="RuleViolation"/>s have been found.
        /// </returns>
        IEnumerable<RuleViolation> Verify(Iteration iteration);
    }
}
