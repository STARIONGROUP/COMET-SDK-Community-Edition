// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuiltInRuleVerificationResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BuiltInRuleVerificationResolver"/> is to deserialize a JSON object to a <see cref="BuiltInRuleVerification"/>
    /// </summary>
    public static class BuiltInRuleVerificationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="BuiltInRuleVerification"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="BuiltInRuleVerification"/> to instantiate</returns>
        public static CDP4Common.DTO.BuiltInRuleVerification FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var builtInRuleVerification = new CDP4Common.DTO.BuiltInRuleVerification(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                builtInRuleVerification.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                builtInRuleVerification.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["executedOn"].IsNullOrEmpty())
            {
                builtInRuleVerification.ExecutedOn = jObject["executedOn"].ToObject<DateTime?>();
            }

            if (!jObject["isActive"].IsNullOrEmpty())
            {
                builtInRuleVerification.IsActive = jObject["isActive"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                builtInRuleVerification.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                builtInRuleVerification.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["status"].IsNullOrEmpty())
            {
                builtInRuleVerification.Status = jObject["status"].ToObject<RuleVerificationStatusKind>();
            }

            if (!jObject["violation"].IsNullOrEmpty())
            {
                builtInRuleVerification.Violation.AddRange(jObject["violation"].ToObject<IEnumerable<Guid>>());
            }

            return builtInRuleVerification;
        }
    }
}
