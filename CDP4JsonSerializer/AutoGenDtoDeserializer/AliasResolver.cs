// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AliasResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="AliasResolver"/> is to deserialize a JSON object to a <see cref="Alias"/>
    /// </summary>
    public static class AliasResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Alias"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Alias"/> to instantiate</returns>
        public static CDP4Common.DTO.Alias FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var alias = new CDP4Common.DTO.Alias(iid, revisionNumber);

            if (!jObject["content"].IsNullOrEmpty())
            {
                alias.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                alias.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                alias.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isSynonym"].IsNullOrEmpty())
            {
                alias.IsSynonym = jObject["isSynonym"].ToObject<bool>();
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                alias.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                alias.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            return alias;
        }
    }
}
