// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose of the <see cref="RequiredReferenceDataLibraryAbacus"/> is to compute the
    /// chain of Required <see cref="ReferenceDataLibrary"/>s
    /// </summary>
    internal static class RequiredReferenceDataLibraryAbacus
    {
        /// <summary>
        /// Computes the <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains 
        /// the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        /// <returns>
        /// an <see cref="IEnumerable{ReferenceDataLibrary}"/> of hte required <see cref="ReferenceDataLibrary"/>s for the current <see cref="Thing"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when this method is invoked on a class that is not directly contained by a <see cref="ReferenceDataLibrary"/>
        /// </exception>
        internal static IEnumerable<ReferenceDataLibrary> ComputeRequiredRdls(this Thing thing)
        {
            var rdl = thing.Container as ReferenceDataLibrary;
            if (rdl == null)
            {
                throw new InvalidOperationException("The ComputeRequiredRdls method may only be invoked on classes that are directly contained by a ReferenceDataLibrary");
            }

            var requiredRdls = new HashSet<ReferenceDataLibrary>();
            requiredRdls.Add(rdl);
            requiredRdls.UnionWith(rdl.GetRequiredRdls());
            return requiredRdls;
        }
    }
}
