// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteState.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Hand-coded part for the auto-generated <see cref="Iteration"/> class.
    /// </summary>
    public partial class Iteration
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> that contains the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Iteration"/> 
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var engineeringModelSetup = (EngineeringModelSetup)this.IterationSetup.Container;
                var requiredModelReferenceDataLibrary = engineeringModelSetup.RequiredRdl.Single();
                var requiredRdls = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);                
                requiredRdls.Add(requiredModelReferenceDataLibrary);
                requiredRdls.UnionWith(requiredModelReferenceDataLibrary.GetRequiredRdls());
                return requiredRdls;
            }
        }
    }
}
