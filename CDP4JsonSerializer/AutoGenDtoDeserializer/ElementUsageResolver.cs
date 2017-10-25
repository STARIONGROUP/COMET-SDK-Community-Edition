// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsageResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ElementUsageResolver"/> is to deserialize a JSON object to a <see cref="ElementUsage"/>
    /// </summary>
    public static class ElementUsageResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ElementUsage"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ElementUsage"/> to instantiate</returns>
        public static CDP4Common.DTO.ElementUsage FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var elementUsage = new CDP4Common.DTO.ElementUsage(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                elementUsage.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                elementUsage.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                elementUsage.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["elementDefinition"].IsNullOrEmpty())
            {
                elementUsage.ElementDefinition = jObject["elementDefinition"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                elementUsage.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                elementUsage.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludeOption"].IsNullOrEmpty())
            {
                elementUsage.ExcludeOption.AddRange(jObject["excludeOption"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                elementUsage.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["interfaceEnd"].IsNullOrEmpty())
            {
                elementUsage.InterfaceEnd = jObject["interfaceEnd"].ToObject<InterfaceEndKind>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                elementUsage.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                elementUsage.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                elementUsage.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameterOverride"].IsNullOrEmpty())
            {
                elementUsage.ParameterOverride.AddRange(jObject["parameterOverride"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                elementUsage.ShortName = jObject["shortName"].ToObject<string>();
            }

            return elementUsage;
        }
    }
}
