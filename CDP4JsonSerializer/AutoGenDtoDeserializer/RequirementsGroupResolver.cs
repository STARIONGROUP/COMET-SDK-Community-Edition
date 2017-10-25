// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsGroupResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequirementsGroupResolver"/> is to deserialize a JSON object to a <see cref="RequirementsGroup"/>
    /// </summary>
    public static class RequirementsGroupResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="RequirementsGroup"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="RequirementsGroup"/> to instantiate</returns>
        public static CDP4Common.DTO.RequirementsGroup FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var requirementsGroup = new CDP4Common.DTO.RequirementsGroup(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                requirementsGroup.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                requirementsGroup.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                requirementsGroup.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                requirementsGroup.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                requirementsGroup.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["group"].IsNullOrEmpty())
            {
                requirementsGroup.Group.AddRange(jObject["group"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                requirementsGroup.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                requirementsGroup.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                requirementsGroup.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                requirementsGroup.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameterValue"].IsNullOrEmpty())
            {
                requirementsGroup.ParameterValue.AddRange(jObject["parameterValue"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                requirementsGroup.ShortName = jObject["shortName"].ToObject<string>();
            }

            return requirementsGroup;
        }
    }
}
