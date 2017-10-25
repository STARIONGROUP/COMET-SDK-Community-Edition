// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Citation.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.CommonData
{
    using System.Collections.Generic;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="Citation"/>
    /// </summary>
    public partial class Citation
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> that contains 
        /// the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var requiredRdls = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);
                requiredRdls.UnionWith(this.Source.RequiredRdls);
                return requiredRdls;
            }
        }
    }
}