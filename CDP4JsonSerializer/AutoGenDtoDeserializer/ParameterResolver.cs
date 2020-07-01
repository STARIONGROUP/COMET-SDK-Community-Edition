// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterResolver"/> is to deserialize a JSON object to a <see cref="Parameter"/>
    /// </summary>
    public static class ParameterResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Parameter"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Parameter"/> to instantiate</returns>
        public static CDP4Common.DTO.Parameter FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameter = new CDP4Common.DTO.Parameter(iid, revisionNumber);

            if (!jObject["allowDifferentOwnerOfOverride"].IsNullOrEmpty())
            {
                parameter.AllowDifferentOwnerOfOverride = jObject["allowDifferentOwnerOfOverride"].ToObject<bool>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameter.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameter.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["expectsOverride"].IsNullOrEmpty())
            {
                parameter.ExpectsOverride = jObject["expectsOverride"].ToObject<bool>();
            }

            if (!jObject["group"].IsNullOrEmpty())
            {
                parameter.Group = jObject["group"].ToObject<Guid?>();
            }

            if (!jObject["isOptionDependent"].IsNullOrEmpty())
            {
                parameter.IsOptionDependent = jObject["isOptionDependent"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameter.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                parameter.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameterSubscription"].IsNullOrEmpty())
            {
                parameter.ParameterSubscription.AddRange(jObject["parameterSubscription"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                parameter.ParameterType = jObject["parameterType"].ToObject<Guid>();
            }

            if (!jObject["requestedBy"].IsNullOrEmpty())
            {
                parameter.RequestedBy = jObject["requestedBy"].ToObject<Guid?>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                parameter.Scale = jObject["scale"].ToObject<Guid?>();
            }

            if (!jObject["stateDependence"].IsNullOrEmpty())
            {
                parameter.StateDependence = jObject["stateDependence"].ToObject<Guid?>();
            }

            if (!jObject["valueSet"].IsNullOrEmpty())
            {
                parameter.ValueSet.AddRange(jObject["valueSet"].ToObject<IEnumerable<Guid>>());
            }

            return parameter;
        }
    }
}
