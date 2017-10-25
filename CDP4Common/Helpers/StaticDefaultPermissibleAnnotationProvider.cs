// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticDefaultPermissibleAnnotationProvider.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using CommonData;

    /// <summary>
    /// A static utility class that supplies the ClassKind that support specific Annotation concept
    /// </summary>
    public static class StaticDefaultPermissibleAnnotationProvider
    {
        /// <summary>
        /// The <see cref="PermissibleAnnotationProvider"/>
        /// </summary>
        private static PermissibleAnnotationProvider provider = new PermissibleAnnotationProvider();

        /// <summary>
        /// Gets the array of ClassKind that support ReviewItemDiscrepancy
        /// </summary>
        public static ClassKind[] ReviewItemDiscrepancyApplicableClassKind
        {
            get { return provider.ReviewItemDiscrepancyApplicableClassKind; }
        }

        /// <summary>
        /// Gets the array of ClassKind that support RequestForWaiver
        /// </summary>
        public static ClassKind[] RequestForWaiverApplicableClassKind
        {
            get { return provider.RequestForWaiverApplicableClassKind; }
        }

        /// <summary>
        /// Gets the array of ClassKind that support RequestForDeviation
        /// </summary>
        public static ClassKind[] RequestForDeviationApplicableClassKind
        {
            get { return provider.RequestForDeviationApplicableClassKind; }
        }

        /// <summary>
        /// Gets the array of ClassKind that support ChangeRequest
        /// </summary>
        public static ClassKind[] ChangeRequestApplicableClassKind
        {
            get { return provider.ChangeRequestApplicableClassKind; }
        }
    }
}
