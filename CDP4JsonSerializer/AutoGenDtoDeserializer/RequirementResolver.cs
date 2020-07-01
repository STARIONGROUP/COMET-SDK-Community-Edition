// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequirementResolver"/> is to deserialize a JSON object to a <see cref="Requirement"/>
    /// </summary>
    public static class RequirementResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Requirement"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Requirement"/> to instantiate</returns>
        public static CDP4Common.DTO.Requirement FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var requirement = new CDP4Common.DTO.Requirement(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                requirement.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                requirement.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                requirement.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                requirement.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                requirement.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["group"].IsNullOrEmpty())
            {
                requirement.Group = jObject["group"].ToObject<Guid?>();
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                requirement.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                requirement.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                requirement.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                requirement.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                requirement.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameterValue"].IsNullOrEmpty())
            {
                requirement.ParameterValue.AddRange(jObject["parameterValue"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["parametricConstraint"].IsNullOrEmpty())
            {
                requirement.ParametricConstraint.AddRange(jObject["parametricConstraint"].ToOrderedItemCollection());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                requirement.ShortName = jObject["shortName"].ToObject<string>();
            }

            return requirement;
        }
    }
}
