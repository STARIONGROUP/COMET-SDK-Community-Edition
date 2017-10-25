// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterValueSetResolver"/> is to deserialize a JSON object to a <see cref="ParameterValueSet"/>
    /// </summary>
    public static class ParameterValueSetResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterValueSet"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterValueSet"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterValueSet FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterValueSet = new CDP4Common.DTO.ParameterValueSet(iid, revisionNumber);

            if (!jObject["actualOption"].IsNullOrEmpty())
            {
                parameterValueSet.ActualOption = jObject["actualOption"].ToObject<Guid?>();
            }

            if (!jObject["actualState"].IsNullOrEmpty())
            {
                parameterValueSet.ActualState = jObject["actualState"].ToObject<Guid?>();
            }

            if (!jObject["computed"].IsNullOrEmpty())
            {
                parameterValueSet.Computed = SerializerHelper.ToValueArray<string>(jObject["computed"].ToString());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterValueSet.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterValueSet.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["formula"].IsNullOrEmpty())
            {
                parameterValueSet.Formula = SerializerHelper.ToValueArray<string>(jObject["formula"].ToString());
            }

            if (!jObject["manual"].IsNullOrEmpty())
            {
                parameterValueSet.Manual = SerializerHelper.ToValueArray<string>(jObject["manual"].ToString());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterValueSet.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["published"].IsNullOrEmpty())
            {
                parameterValueSet.Published = SerializerHelper.ToValueArray<string>(jObject["published"].ToString());
            }

            if (!jObject["reference"].IsNullOrEmpty())
            {
                parameterValueSet.Reference = SerializerHelper.ToValueArray<string>(jObject["reference"].ToString());
            }

            if (!jObject["valueSwitch"].IsNullOrEmpty())
            {
                parameterValueSet.ValueSwitch = jObject["valueSwitch"].ToObject<ParameterSwitchKind>();
            }

            return parameterValueSet;
        }
    }
}
