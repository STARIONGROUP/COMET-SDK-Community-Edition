// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainerParameterValueResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequirementsContainerParameterValueResolver"/> is to deserialize a JSON object to a <see cref="RequirementsContainerParameterValue"/>
    /// </summary>
    public static class RequirementsContainerParameterValueResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="RequirementsContainerParameterValue"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="RequirementsContainerParameterValue"/> to instantiate</returns>
        public static CDP4Common.DTO.RequirementsContainerParameterValue FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var requirementsContainerParameterValue = new CDP4Common.DTO.RequirementsContainerParameterValue(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                requirementsContainerParameterValue.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                requirementsContainerParameterValue.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                requirementsContainerParameterValue.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                requirementsContainerParameterValue.ParameterType = jObject["parameterType"].ToObject<Guid>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                requirementsContainerParameterValue.Scale = jObject["scale"].ToObject<Guid?>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                requirementsContainerParameterValue.Value = SerializerHelper.ToValueArray<string>(jObject["value"].ToString());
            }

            return requirementsContainerParameterValue;
        }
    }
}
