// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterSubscriptionResolver"/> is to deserialize a JSON object to a <see cref="ParameterSubscription"/>
    /// </summary>
    public static class ParameterSubscriptionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterSubscription"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterSubscription"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterSubscription FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterSubscription = new CDP4Common.DTO.ParameterSubscription(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterSubscription.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterSubscription.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterSubscription.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                parameterSubscription.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["valueSet"].IsNullOrEmpty())
            {
                parameterSubscription.ValueSet.AddRange(jObject["valueSet"].ToObject<IEnumerable<Guid>>());
            }

            return parameterSubscription;
        }
    }
}
