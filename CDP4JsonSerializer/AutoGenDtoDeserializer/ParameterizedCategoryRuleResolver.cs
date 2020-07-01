// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizedCategoryRuleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterizedCategoryRuleResolver"/> is to deserialize a JSON object to a <see cref="ParameterizedCategoryRule"/>
    /// </summary>
    public static class ParameterizedCategoryRuleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterizedCategoryRule"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterizedCategoryRule"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterizedCategoryRule FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterizedCategoryRule = new CDP4Common.DTO.ParameterizedCategoryRule(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.Category = jObject["category"].ToObject<Guid>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.ParameterType.AddRange(jObject["parameterType"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                parameterizedCategoryRule.ShortName = jObject["shortName"].ToObject<string>();
            }

            return parameterizedCategoryRule;
        }
    }
}
