// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPermissibleAnnotationProvider.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using CDP4Common.CommonData;

    /// <summary>
    /// The permissible annotation provider interface.
    /// </summary>
    public interface IPermissibleAnnotationProvider
    {
        /// <summary>
        /// Gets the array of ClassKind that support ReviewItemDiscrepancy
        /// </summary>
        ClassKind[] ReviewItemDiscrepancyApplicableClassKind { get; }

        /// <summary>
        /// Gets the array of ClassKind that support RequestForWaiver
        /// </summary>
        ClassKind[] RequestForWaiverApplicableClassKind { get; }

        /// <summary>
        /// Gets the array of ClassKind that support RequestForDeviation
        /// </summary>
        ClassKind[] RequestForDeviationApplicableClassKind { get; }

        /// <summary>
        /// Gets the array of ClassKind that support ChangeRequest
        /// </summary>
        ClassKind[] ChangeRequestApplicableClassKind { get; }
    }
}
