// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeasurementScale.cs" company="RHEA system S.A.">
//   Copyright (c) 2017-2017 RHEA system S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.Helpers;

    /// <summary>
    /// Extended part for the auto-generated <see cref="MeasurementScale"/>
    /// </summary>
    public partial class MeasurementScale
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> that contains 
        /// the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                return this.ComputeRequiredRdls();
            }
        }
    }
}