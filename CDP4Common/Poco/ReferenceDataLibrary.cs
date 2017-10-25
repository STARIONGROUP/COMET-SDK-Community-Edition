// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibrary.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;

    public abstract partial class ReferenceDataLibrary
    {
        /// <summary>
        /// Gets the chain of required Rdl for this <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>An iterator of the chain of required Rdl</returns>
        public IEnumerable<ReferenceDataLibrary> GetRequiredRdls()
        {
            var requiredRdl = this.RequiredRdl;
            while (requiredRdl != null)
            {
                yield return requiredRdl;
                requiredRdl = requiredRdl.RequiredRdl;
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains 
        /// the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var requiredRdls = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);
                requiredRdls.UnionWith(this.GetRequiredRdls());
                return requiredRdls;
            }
        }

        /// <summary>
        /// Gets the aggragation of all required <see cref="ReferenceDataLibrary"/> besides the current one
        /// </summary>
        public IEnumerable<ReferenceDataLibrary> AggregatedReferenceDataLibrary
        {
            get
            {
                yield return this;
                foreach (var rdl in this.GetRequiredRdls())
                {
                    yield return rdl;
                }
            }
        }
    }
}