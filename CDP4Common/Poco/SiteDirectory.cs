// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectory.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using CDP4Common.SiteDirectoryData;
    
    /// <summary>
    /// Extended part for the auto-generated <see cref="SiteDirectory"/>
    /// </summary>
    public partial class SiteDirectory
    {
        /// <summary>
        /// Gets the available <see cref="ReferenceDataLibrary"/> that are contained by the current <see cref="SiteDirectory"/> either
        /// directly as <see cref="SiteReferenceDataLibrary"/> or as <see cref="ModelReferenceDataLibrary"/> through the
        /// <see cref="EngineeringModelSetup"/> the <see cref="SiteDirectory"/> contains.
        /// </summary>
        /// <returns>
        /// an <see cref="IEnumerable{ReferenceDataLibrary}"/>
        /// </returns>
        public IEnumerable<ReferenceDataLibrary> AvailableReferenceDataLibraries()
        {
            foreach (var siteReferenceDataLibrary in this.SiteReferenceDataLibrary)
            {
                yield return siteReferenceDataLibrary;
            }

            foreach (var engineeringModelSetup in this.Model)
            {
                var rdl = engineeringModelSetup.RequiredRdl.SingleOrDefault();
                if (rdl != null)
                {
                    yield return rdl;
                }
            }
        }
    }
}
