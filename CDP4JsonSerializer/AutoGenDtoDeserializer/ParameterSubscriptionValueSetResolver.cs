// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSetResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterSubscriptionValueSetResolver"/> is to deserialize a JSON object to a <see cref="ParameterSubscriptionValueSet"/>
    /// </summary>
    public static class ParameterSubscriptionValueSetResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterSubscriptionValueSet"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterSubscriptionValueSet"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterSubscriptionValueSet FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterSubscriptionValueSet = new CDP4Common.DTO.ParameterSubscriptionValueSet(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["manual"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.Manual = SerializerHelper.ToValueArray<string>(jObject["manual"].ToString());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["subscribedValueSet"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.SubscribedValueSet = jObject["subscribedValueSet"].ToObject<Guid>();
            }

            if (!jObject["valueSwitch"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.ValueSwitch = jObject["valueSwitch"].ToObject<ParameterSwitchKind>();
            }

            return parameterSubscriptionValueSet;
        }
    }
}
