// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleViolationResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RuleViolationResolver"/> is to deserialize a JSON object to a <see cref="RuleViolation"/>
    /// </summary>
    public static class RuleViolationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="RuleViolation"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="RuleViolation"/> to instantiate</returns>
        public static CDP4Common.DTO.RuleViolation FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var ruleViolation = new CDP4Common.DTO.RuleViolation(iid, revisionNumber);

            if (!jObject["description"].IsNullOrEmpty())
            {
                ruleViolation.Description = jObject["description"].ToObject<string>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                ruleViolation.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                ruleViolation.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                ruleViolation.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["violatingThing"].IsNullOrEmpty())
            {
                ruleViolation.ViolatingThing.AddRange(jObject["violatingThing"].ToObject<IEnumerable<Guid>>());
            }

            return ruleViolation;
        }
    }
}
