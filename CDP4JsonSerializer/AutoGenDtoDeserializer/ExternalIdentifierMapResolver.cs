// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalIdentifierMapResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ExternalIdentifierMapResolver"/> is to deserialize a JSON object to a <see cref="ExternalIdentifierMap"/>
    /// </summary>
    public static class ExternalIdentifierMapResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ExternalIdentifierMap"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ExternalIdentifierMap"/> to instantiate</returns>
        public static CDP4Common.DTO.ExternalIdentifierMap FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var externalIdentifierMap = new CDP4Common.DTO.ExternalIdentifierMap(iid, revisionNumber);

            if (!jObject["correspondence"].IsNullOrEmpty())
            {
                externalIdentifierMap.Correspondence.AddRange(jObject["correspondence"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                externalIdentifierMap.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                externalIdentifierMap.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["externalFormat"].IsNullOrEmpty())
            {
                externalIdentifierMap.ExternalFormat = jObject["externalFormat"].ToObject<Guid?>();
            }

            if (!jObject["externalModelName"].IsNullOrEmpty())
            {
                externalIdentifierMap.ExternalModelName = jObject["externalModelName"].ToObject<string>();
            }

            if (!jObject["externalToolName"].IsNullOrEmpty())
            {
                externalIdentifierMap.ExternalToolName = jObject["externalToolName"].ToObject<string>();
            }

            if (!jObject["externalToolVersion"].IsNullOrEmpty())
            {
                externalIdentifierMap.ExternalToolVersion = jObject["externalToolVersion"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                externalIdentifierMap.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                externalIdentifierMap.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                externalIdentifierMap.Owner = jObject["owner"].ToObject<Guid>();
            }

            return externalIdentifierMap;
        }
    }
}
