// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="StakeHolderValueMapResolver"/> is to deserialize a JSON object to a <see cref="StakeHolderValueMap"/>
    /// </summary>
    public static class StakeHolderValueMapResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="StakeHolderValueMap"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="StakeHolderValueMap"/> to instantiate</returns>
        public static CDP4Common.DTO.StakeHolderValueMap FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var stakeHolderValueMap = new CDP4Common.DTO.StakeHolderValueMap(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["goal"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Goal.AddRange(jObject["goal"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                stakeHolderValueMap.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["requirement"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Requirement.AddRange(jObject["requirement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["settings"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Settings.AddRange(jObject["settings"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["stakeholderValue"].IsNullOrEmpty())
            {
                stakeHolderValueMap.StakeholderValue.AddRange(jObject["stakeholderValue"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["valueGroup"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ValueGroup.AddRange(jObject["valueGroup"].ToObject<IEnumerable<Guid>>());
            }

            return stakeHolderValueMap;
        }
    }
}
