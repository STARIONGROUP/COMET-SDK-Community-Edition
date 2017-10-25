// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypeComponentResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterTypeComponentResolver"/> is to deserialize a JSON object to a <see cref="ParameterTypeComponent"/>
    /// </summary>
    public static class ParameterTypeComponentResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterTypeComponent"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterTypeComponent"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterTypeComponent FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterTypeComponent = new CDP4Common.DTO.ParameterTypeComponent(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterTypeComponent.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterTypeComponent.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterTypeComponent.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                parameterTypeComponent.ParameterType = jObject["parameterType"].ToObject<Guid>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                parameterTypeComponent.Scale = jObject["scale"].ToObject<Guid?>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                parameterTypeComponent.ShortName = jObject["shortName"].ToObject<string>();
            }

            return parameterTypeComponent;
        }
    }
}
