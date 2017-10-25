// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecompositionRuleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DecompositionRuleResolver"/> is to deserialize a JSON object to a <see cref="DecompositionRule"/>
    /// </summary>
    public static class DecompositionRuleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="DecompositionRule"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="DecompositionRule"/> to instantiate</returns>
        public static CDP4Common.DTO.DecompositionRule FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var decompositionRule = new CDP4Common.DTO.DecompositionRule(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                decompositionRule.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["containedCategory"].IsNullOrEmpty())
            {
                decompositionRule.ContainedCategory.AddRange(jObject["containedCategory"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["containingCategory"].IsNullOrEmpty())
            {
                decompositionRule.ContainingCategory = jObject["containingCategory"].ToObject<Guid>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                decompositionRule.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                decompositionRule.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                decompositionRule.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                decompositionRule.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                decompositionRule.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["maxContained"].IsNullOrEmpty())
            {
                decompositionRule.MaxContained = jObject["maxContained"].ToObject<int?>();
            }

            if (!jObject["minContained"].IsNullOrEmpty())
            {
                decompositionRule.MinContained = jObject["minContained"].ToObject<int>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                decompositionRule.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                decompositionRule.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                decompositionRule.ShortName = jObject["shortName"].ToObject<string>();
            }

            return decompositionRule;
        }
    }
}
