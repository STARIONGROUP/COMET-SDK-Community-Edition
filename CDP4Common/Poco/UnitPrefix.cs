// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitPrefix.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.Helpers;

    /// <summary>
    /// Extended part for the auto-generated <see cref="UnitPrefix"/>
    /// </summary>
    public partial class UnitPrefix
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