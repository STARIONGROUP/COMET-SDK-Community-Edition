// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissibleAnnotationProvider.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is the auto-generated PermissibleAnnotationProvider. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using CDP4Common.CommonData;

    /// <summary>
    /// A utility class that supplies the ClassKind that support specific Annotation concept
    /// </summary>
    public class PermissibleAnnotationProvider : IPermissibleAnnotationProvider
    {
        /// <summary>
        /// The array of ClassKind that support ReviewItemDiscrepancy
        /// </summary>
        private readonly ClassKind[] reviewItemDiscrepancyApplicableClassKind = new []
        {
            ClassKind.ActualFiniteState,
            ClassKind.ActualFiniteStateList,
            ClassKind.BinaryRelationship,
            ClassKind.ElementDefinition,
            ClassKind.ElementUsage,
            ClassKind.MultiRelationship,
            ClassKind.Option,
            ClassKind.Parameter,
            ClassKind.ParameterOverride,
            ClassKind.ParameterOverrideValueSet,
            ClassKind.ParameterValueSet,
            ClassKind.PossibleFiniteState,
            ClassKind.PossibleFiniteStateList,
            ClassKind.Requirement,
            ClassKind.RequirementsGroup,
            ClassKind.RequirementsSpecification,
        };

        /// <summary>
        /// The array of ClassKind that support RequestForWaiver
        /// </summary>
        private readonly ClassKind[] requestForWaiverApplicableClassKind = new []
        {
            ClassKind.ActualFiniteState,
            ClassKind.ActualFiniteStateList,
            ClassKind.BinaryRelationship,
            ClassKind.ElementDefinition,
            ClassKind.ElementUsage,
            ClassKind.MultiRelationship,
            ClassKind.Option,
            ClassKind.Parameter,
            ClassKind.ParameterOverride,
            ClassKind.ParameterOverrideValueSet,
            ClassKind.ParameterValueSet,
            ClassKind.PossibleFiniteState,
            ClassKind.PossibleFiniteStateList,
            ClassKind.Requirement,
            ClassKind.RequirementsGroup,
            ClassKind.RequirementsSpecification,
        };

        /// <summary>
        /// The array of ClassKind that support RequestForDeviation
        /// </summary>
        private readonly ClassKind[] requestForDeviationApplicableClassKind = new []
        {
            ClassKind.ActualFiniteState,
            ClassKind.ActualFiniteStateList,
            ClassKind.BinaryRelationship,
            ClassKind.ElementDefinition,
            ClassKind.ElementUsage,
            ClassKind.MultiRelationship,
            ClassKind.Option,
            ClassKind.Parameter,
            ClassKind.ParameterOverride,
            ClassKind.ParameterOverrideValueSet,
            ClassKind.ParameterValueSet,
            ClassKind.PossibleFiniteState,
            ClassKind.PossibleFiniteStateList,
            ClassKind.Requirement,
            ClassKind.RequirementsGroup,
            ClassKind.RequirementsSpecification,
        };

        /// <summary>
        /// The array of ClassKind that support ChangeRequest
        /// </summary>
        private readonly ClassKind[] changeRequestApplicableClassKind = new []
        {
            ClassKind.ActualFiniteState,
            ClassKind.ActualFiniteStateList,
            ClassKind.BinaryRelationship,
            ClassKind.ElementDefinition,
            ClassKind.ElementUsage,
            ClassKind.MultiRelationship,
            ClassKind.Option,
            ClassKind.Parameter,
            ClassKind.ParameterOverride,
            ClassKind.ParameterOverrideValueSet,
            ClassKind.ParameterValueSet,
            ClassKind.PossibleFiniteState,
            ClassKind.PossibleFiniteStateList,
            ClassKind.Requirement,
            ClassKind.RequirementsGroup,
            ClassKind.RequirementsSpecification,
        };

        /// <summary>
        /// Gets the array of ClassKind that support ReviewItemDiscrepancy
        /// </summary>
        public ClassKind[] ReviewItemDiscrepancyApplicableClassKind
        {
            get { return this.reviewItemDiscrepancyApplicableClassKind; }
        }

        /// <summary>
        /// Gets the array of ClassKind that support RequestForWaiver
        /// </summary>
        public ClassKind[] RequestForWaiverApplicableClassKind
        {
            get { return this.requestForWaiverApplicableClassKind; }
        }

        /// <summary>
        /// Gets the array of ClassKind that support RequestForDeviation
        /// </summary>
        public ClassKind[] RequestForDeviationApplicableClassKind
        {
            get { return this.requestForDeviationApplicableClassKind; }
        }

        /// <summary>
        /// Gets the array of ClassKind that support ChangeRequest
        /// </summary>
        public ClassKind[] ChangeRequestApplicableClassKind
        {
            get { return this.changeRequestApplicableClassKind; }
        }
    }
}
