// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModellingThingReferenceResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Resolver class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    #pragma warning disable S1128
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
    #pragma warning restore S1128

    /// <summary>
    /// The purpose of the <see cref="ModellingThingReferenceResolver"/> is to deserialize a JSON object to a <see cref="ModellingThingReference"/>
    /// </summary>
    public static class ModellingThingReferenceResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ModellingThingReference"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ModellingThingReference"/> to instantiate</returns>
        public static CDP4Common.DTO.ModellingThingReference FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var modellingThingReference = new CDP4Common.DTO.ModellingThingReference(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                modellingThingReference.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                modellingThingReference.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                modellingThingReference.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["referencedRevisionNumber"].IsNullOrEmpty())
            {
                modellingThingReference.ReferencedRevisionNumber = jObject["referencedRevisionNumber"].ToObject<int>();
            }

            if (!jObject["referencedThing"].IsNullOrEmpty())
            {
                modellingThingReference.ReferencedThing = jObject["referencedThing"].ToObject<Guid>();
            }

            return modellingThingReference;
        }
    }
}
