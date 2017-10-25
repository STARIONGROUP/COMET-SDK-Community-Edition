// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferencerRule.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// representation of a validation rule for ElementDefinitions and the <i>referencedElement</i> NestedElements
    /// </summary>
    public partial class ReferencerRule : IRuleVerification
    {
        /// <summary>
        /// Verify an <see cref="Iteration"/> with respect to the <see cref="ReferencerRule"/> 
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> that is to be verified.
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{RuleViolation}"/>, this may be empty of no <see cref="RuleViolation"/>s have been found.
        /// </returns>
        public IEnumerable<RuleViolation> Verify(Iteration iteration)
        {
            throw new NotSupportedException("The Verify method of the ReferencerRule is currently not supported.");
        }
    }
}
