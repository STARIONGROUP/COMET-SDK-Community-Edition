// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSetResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterOverrideValueSetResolver"/> is to deserialize a JSON object to a <see cref="ParameterOverrideValueSet"/>
    /// </summary>
    public static class ParameterOverrideValueSetResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterOverrideValueSet"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterOverrideValueSet"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterOverrideValueSet FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterOverrideValueSet = new CDP4Common.DTO.ParameterOverrideValueSet(iid, revisionNumber);

            if (!jObject["computed"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.Computed = SerializerHelper.ToValueArray<string>(jObject["computed"].ToString());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["formula"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.Formula = SerializerHelper.ToValueArray<string>(jObject["formula"].ToString());
            }

            if (!jObject["manual"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.Manual = SerializerHelper.ToValueArray<string>(jObject["manual"].ToString());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["parameterValueSet"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.ParameterValueSet = jObject["parameterValueSet"].ToObject<Guid>();
            }

            if (!jObject["published"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.Published = SerializerHelper.ToValueArray<string>(jObject["published"].ToString());
            }

            if (!jObject["reference"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.Reference = SerializerHelper.ToValueArray<string>(jObject["reference"].ToString());
            }

            if (!jObject["valueSwitch"].IsNullOrEmpty())
            {
                parameterOverrideValueSet.ValueSwitch = jObject["valueSwitch"].ToObject<ParameterSwitchKind>();
            }

            return parameterOverrideValueSet;
        }
    }
}
