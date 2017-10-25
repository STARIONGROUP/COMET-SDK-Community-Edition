// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleParameterValueResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SimpleParameterValueResolver"/> is to deserialize a JSON object to a <see cref="SimpleParameterValue"/>
    /// </summary>
    public static class SimpleParameterValueResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SimpleParameterValue"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SimpleParameterValue"/> to instantiate</returns>
        public static CDP4Common.DTO.SimpleParameterValue FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var simpleParameterValue = new CDP4Common.DTO.SimpleParameterValue(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                simpleParameterValue.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                simpleParameterValue.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                simpleParameterValue.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                simpleParameterValue.ParameterType = jObject["parameterType"].ToObject<Guid>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                simpleParameterValue.Scale = jObject["scale"].ToObject<Guid?>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                simpleParameterValue.Value = SerializerHelper.ToValueArray<string>(jObject["value"].ToString());
            }

            return simpleParameterValue;
        }
    }
}
