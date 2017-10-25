// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationshipRuleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="MultiRelationshipRuleResolver"/> is to deserialize a JSON object to a <see cref="MultiRelationshipRule"/>
    /// </summary>
    public static class MultiRelationshipRuleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="MultiRelationshipRule"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="MultiRelationshipRule"/> to instantiate</returns>
        public static CDP4Common.DTO.MultiRelationshipRule FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var multiRelationshipRule = new CDP4Common.DTO.MultiRelationshipRule(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                multiRelationshipRule.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                multiRelationshipRule.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                multiRelationshipRule.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                multiRelationshipRule.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                multiRelationshipRule.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                multiRelationshipRule.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["maxRelated"].IsNullOrEmpty())
            {
                multiRelationshipRule.MaxRelated = jObject["maxRelated"].ToObject<int>();
            }

            if (!jObject["minRelated"].IsNullOrEmpty())
            {
                multiRelationshipRule.MinRelated = jObject["minRelated"].ToObject<int>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                multiRelationshipRule.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                multiRelationshipRule.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["relatedCategory"].IsNullOrEmpty())
            {
                multiRelationshipRule.RelatedCategory.AddRange(jObject["relatedCategory"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["relationshipCategory"].IsNullOrEmpty())
            {
                multiRelationshipRule.RelationshipCategory = jObject["relationshipCategory"].ToObject<Guid>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                multiRelationshipRule.ShortName = jObject["shortName"].ToObject<string>();
            }

            return multiRelationshipRule;
        }
    }
}
