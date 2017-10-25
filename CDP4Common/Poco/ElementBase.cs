// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementBase.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ElementBase"/>
    /// </summary>
    public abstract partial class ElementBase : IPublishable
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="ElementBase"/> can be published.
        /// </summary>
        public abstract bool CanBePublished { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ElementBase"/> will be published in the next <see cref="Publication"/>.
        /// </summary>
        public abstract bool ToBePublished { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains the 
        /// required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var requiredRdl = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);
                foreach (var category in this.Category)
                {
                    requiredRdl.UnionWith(category.RequiredRdls);
                }

                return requiredRdl;
            }
        }
    }
}
