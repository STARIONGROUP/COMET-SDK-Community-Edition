// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleViolation.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;
    using CommonData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="RuleViolation"/>
    /// </summary>
    public partial class RuleViolation
    {
        /// <summary>
        /// The collection of <see cref="ClassKind"/> that violates a Rule
        /// </summary>
        public readonly HashSet<ClassKind> RuleViolatedClassKind = new HashSet<ClassKind>();
    }
}