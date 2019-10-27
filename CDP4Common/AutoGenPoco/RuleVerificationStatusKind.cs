// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleVerificationStatusKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Enumeration. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// enumeration datatype that represents the possible values for the status of the executed verification of a rule
    /// </summary>
    public enum RuleVerificationStatusKind
    {
        /// <summary>
        /// verification has not been executed yet
        /// </summary>
        NONE,

        /// <summary>
        /// verification passed successfully, the rule is satisfied
        /// </summary>
        PASSED,

        /// <summary>
        /// verification failed, the rule is violated
        /// </summary>
        FAILED,

        /// <summary>
        /// verification was executed, but no verdict could be produced
        /// </summary>
        INCONCLUSIVE,
    }
}
