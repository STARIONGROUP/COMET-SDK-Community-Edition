// ------------------------------------------------------------------------------------------------
// <copyright file="RequirementStateOfComplianceExtensions.cs" company="RHEA System S.A.">
//   Copyright (c) 2015-2019 RHEA System S.A.
// </copyright>
// -----------------------------------------------------------------------------------------------

namespace CDP4RequirementsVerification.Extensions
{
    using System.Linq;

    /// <summary>
    /// Extension methods for the <see cref="RequirementStateOfCompliance"/> Enum
    /// </summary>
    public static class RequirementStateOfComplianceExtensions
    {
        /// <summary>
        /// Checks if the value of <see cref="RequirementStateOfCompliance"/> states that calculations are finished
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if value indicates that calculations are finished</returns>
        public static bool IsCalculated(this RequirementStateOfCompliance value) => 
            new[] { RequirementStateOfCompliance.Failed, RequirementStateOfCompliance.Pass, RequirementStateOfCompliance.Inconclusive }.Contains(value);
    }
}
