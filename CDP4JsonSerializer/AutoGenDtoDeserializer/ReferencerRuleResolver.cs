// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferencerRuleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ReferencerRuleResolver"/> is to deserialize a JSON object to a <see cref="ReferencerRule"/>
    /// </summary>
    public static class ReferencerRuleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ReferencerRule"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ReferencerRule"/> to instantiate</returns>
        public static CDP4Common.DTO.ReferencerRule FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var referencerRule = new CDP4Common.DTO.ReferencerRule(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                referencerRule.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                referencerRule.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                referencerRule.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                referencerRule.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                referencerRule.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                referencerRule.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["maxReferenced"].IsNullOrEmpty())
            {
                referencerRule.MaxReferenced = jObject["maxReferenced"].ToObject<int>();
            }

            if (!jObject["minReferenced"].IsNullOrEmpty())
            {
                referencerRule.MinReferenced = jObject["minReferenced"].ToObject<int>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                referencerRule.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                referencerRule.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["referencedCategory"].IsNullOrEmpty())
            {
                referencerRule.ReferencedCategory.AddRange(jObject["referencedCategory"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["referencingCategory"].IsNullOrEmpty())
            {
                referencerRule.ReferencingCategory = jObject["referencingCategory"].ToObject<Guid>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                referencerRule.ShortName = jObject["shortName"].ToObject<string>();
            }

            return referencerRule;
        }
    }
}
