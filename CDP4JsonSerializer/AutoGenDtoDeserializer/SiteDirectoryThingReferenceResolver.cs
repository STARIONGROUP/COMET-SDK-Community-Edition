// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryThingReferenceResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Resolver class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="SiteDirectoryThingReferenceResolver"/> is to deserialize a JSON object to a <see cref="SiteDirectoryThingReference"/>
    /// </summary>
    public static class SiteDirectoryThingReferenceResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SiteDirectoryThingReference"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SiteDirectoryThingReference"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteDirectoryThingReference FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var siteDirectoryThingReference = new CDP4Common.DTO.SiteDirectoryThingReference(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                siteDirectoryThingReference.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                siteDirectoryThingReference.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                siteDirectoryThingReference.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["referencedRevisionNumber"].IsNullOrEmpty())
            {
                siteDirectoryThingReference.ReferencedRevisionNumber = jObject["referencedRevisionNumber"].ToObject<int>();
            }

            if (!jObject["referencedThing"].IsNullOrEmpty())
            {
                siteDirectoryThingReference.ReferencedThing = jObject["referencedThing"].ToObject<Guid>();
            }

            return siteDirectoryThingReference;
        }
    }
}
