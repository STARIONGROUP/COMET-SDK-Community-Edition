// ------------------------------------------------------------------------------------------------
// <copyright file="IHaveRequirementStateOfCompliance.cs" company="RHEA System S.A.">
//   Copyright (c) 2015-2019 RHEA System S.A.
// </copyright>
// -----------------------------------------------------------------------------------------------

namespace CDP4Requirements
{
    /// <summary>
    /// Specification of the <see cref="IHaveRequirementStateOfCompliance"/> interface.
    /// </summary>
    public interface IHaveRequirementStateOfCompliance
    {
        /// <summary>
        /// The current <see cref="CDP4Requirements.RequirementStateOfCompliance"/>>
        /// </summary>
        RequirementStateOfCompliance RequirementStateOfCompliance { get; }
    }
}
