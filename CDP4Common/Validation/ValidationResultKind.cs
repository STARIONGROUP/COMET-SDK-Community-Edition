// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationResultKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Validation
{
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Enumeration datatype that defines the overall result of processing the Parameter sheet
    /// </summary>
    public enum ValidationResultKind
    {
        /// <summary>
        /// The validation result is inconclusive
        /// </summary>        
        InConclusive = 0,

        /// <summary>
        /// The value is valid
        /// </summary>
        Valid = 1,

        /// <summary>
        /// The value is valid, but outside of the permissible values
        /// </summary>
        /// <remarks>
        /// This is only relevant for <see cref="QuantityKind"/>s where the <see cref="MeasurementScale"/> minimumPermissibleValue and maximumPermissibleValue are set.
        /// </remarks>
        OutOfBounds = 2,

        /// <summary>
        /// The value is invalid
        /// </summary>
        Invalid = 3
    }
}
