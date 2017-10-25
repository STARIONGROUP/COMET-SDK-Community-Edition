// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapSettingsResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="StakeHolderValueMapSettingsResolver"/> is to deserialize a JSON object to a <see cref="StakeHolderValueMapSettings"/>
    /// </summary>
    public static class StakeHolderValueMapSettingsResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="StakeHolderValueMapSettings"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="StakeHolderValueMapSettings"/> to instantiate</returns>
        public static CDP4Common.DTO.StakeHolderValueMapSettings FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var stakeHolderValueMapSettings = new CDP4Common.DTO.StakeHolderValueMapSettings(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                stakeHolderValueMapSettings.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                stakeHolderValueMapSettings.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["goalToValueGroupRelationship"].IsNullOrEmpty())
            {
                stakeHolderValueMapSettings.GoalToValueGroupRelationship = jObject["goalToValueGroupRelationship"].ToObject<Guid?>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                stakeHolderValueMapSettings.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["stakeholderValueToRequirementRelationship"].IsNullOrEmpty())
            {
                stakeHolderValueMapSettings.StakeholderValueToRequirementRelationship = jObject["stakeholderValueToRequirementRelationship"].ToObject<Guid?>();
            }

            if (!jObject["valueGroupToStakeholderValueRelationship"].IsNullOrEmpty())
            {
                stakeHolderValueMapSettings.ValueGroupToStakeholderValueRelationship = jObject["valueGroupToStakeholderValueRelationship"].ToObject<Guid?>();
            }

            return stakeHolderValueMapSettings;
        }
    }
}
