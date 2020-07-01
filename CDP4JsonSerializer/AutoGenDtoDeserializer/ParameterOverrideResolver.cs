// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterOverrideResolver"/> is to deserialize a JSON object to a <see cref="ParameterOverride"/>
    /// </summary>
    public static class ParameterOverrideResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterOverride"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterOverride"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterOverride FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterOverride = new CDP4Common.DTO.ParameterOverride(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterOverride.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterOverride.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterOverride.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                parameterOverride.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameter"].IsNullOrEmpty())
            {
                parameterOverride.Parameter = jObject["parameter"].ToObject<Guid>();
            }

            if (!jObject["parameterSubscription"].IsNullOrEmpty())
            {
                parameterOverride.ParameterSubscription.AddRange(jObject["parameterSubscription"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["valueSet"].IsNullOrEmpty())
            {
                parameterOverride.ValueSet.AddRange(jObject["valueSet"].ToObject<IEnumerable<Guid>>());
            }

            return parameterOverride;
        }
    }
}
