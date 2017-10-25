// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdCorrespondenceResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IdCorrespondenceResolver"/> is to deserialize a JSON object to a <see cref="IdCorrespondence"/>
    /// </summary>
    public static class IdCorrespondenceResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="IdCorrespondence"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="IdCorrespondence"/> to instantiate</returns>
        public static CDP4Common.DTO.IdCorrespondence FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var idCorrespondence = new CDP4Common.DTO.IdCorrespondence(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                idCorrespondence.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                idCorrespondence.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["externalId"].IsNullOrEmpty())
            {
                idCorrespondence.ExternalId = jObject["externalId"].ToObject<string>();
            }

            if (!jObject["internalThing"].IsNullOrEmpty())
            {
                idCorrespondence.InternalThing = jObject["internalThing"].ToObject<Guid>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                idCorrespondence.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            return idCorrespondence;
        }
    }
}
