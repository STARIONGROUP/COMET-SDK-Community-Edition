// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleVerificationListResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RuleVerificationListResolver"/> is to deserialize a JSON object to a <see cref="RuleVerificationList"/>
    /// </summary>
    public static class RuleVerificationListResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="RuleVerificationList"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="RuleVerificationList"/> to instantiate</returns>
        public static CDP4Common.DTO.RuleVerificationList FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var ruleVerificationList = new CDP4Common.DTO.RuleVerificationList(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                ruleVerificationList.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                ruleVerificationList.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                ruleVerificationList.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                ruleVerificationList.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                ruleVerificationList.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                ruleVerificationList.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                ruleVerificationList.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                ruleVerificationList.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["ruleVerification"].IsNullOrEmpty())
            {
                ruleVerificationList.RuleVerification.AddRange(jObject["ruleVerification"].ToOrderedItemCollection());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                ruleVerificationList.ShortName = jObject["shortName"].ToObject<string>();
            }

            return ruleVerificationList;
        }
    }
}
