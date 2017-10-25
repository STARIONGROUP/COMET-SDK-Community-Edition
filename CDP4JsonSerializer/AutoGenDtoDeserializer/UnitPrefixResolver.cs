// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitPrefixResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="UnitPrefixResolver"/> is to deserialize a JSON object to a <see cref="UnitPrefix"/>
    /// </summary>
    public static class UnitPrefixResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="UnitPrefix"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="UnitPrefix"/> to instantiate</returns>
        public static CDP4Common.DTO.UnitPrefix FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var unitPrefix = new CDP4Common.DTO.UnitPrefix(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                unitPrefix.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["conversionFactor"].IsNullOrEmpty())
            {
                unitPrefix.ConversionFactor = jObject["conversionFactor"].ToObject<string>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                unitPrefix.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                unitPrefix.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                unitPrefix.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                unitPrefix.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                unitPrefix.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                unitPrefix.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                unitPrefix.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                unitPrefix.ShortName = jObject["shortName"].ToObject<string>();
            }

            return unitPrefix;
        }
    }
}
