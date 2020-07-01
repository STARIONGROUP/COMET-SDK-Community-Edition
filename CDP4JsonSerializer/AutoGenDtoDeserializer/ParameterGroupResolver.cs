// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterGroupResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterGroupResolver"/> is to deserialize a JSON object to a <see cref="ParameterGroup"/>
    /// </summary>
    public static class ParameterGroupResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterGroup"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterGroup"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterGroup FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterGroup = new CDP4Common.DTO.ParameterGroup(iid, revisionNumber);

            if (!jObject["containingGroup"].IsNullOrEmpty())
            {
                parameterGroup.ContainingGroup = jObject["containingGroup"].ToObject<Guid?>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterGroup.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterGroup.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterGroup.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                parameterGroup.Name = jObject["name"].ToObject<string>();
            }

            return parameterGroup;
        }
    }
}
