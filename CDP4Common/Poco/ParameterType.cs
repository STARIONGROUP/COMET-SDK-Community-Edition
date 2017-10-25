// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterType.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-207 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.Helpers;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterType"/>
    /// </summary>
    public abstract partial class ParameterType
    {
        /// <summary>
        /// Returns the derived <see cref="NumberOfValues"/> value
        /// </summary>
        /// <returns>The <see cref="NumberOfValues"/> value</returns>
        protected virtual int GetDerivedNumberOfValues()
        {
            return 1;
        }

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