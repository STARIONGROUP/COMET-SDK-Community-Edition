// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrefixedUnitResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PrefixedUnitResolver"/> is to deserialize a JSON object to a <see cref="PrefixedUnit"/>
    /// </summary>
    public static class PrefixedUnitResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="PrefixedUnit"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="PrefixedUnit"/> to instantiate</returns>
        public static CDP4Common.DTO.PrefixedUnit FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var prefixedUnit = new CDP4Common.DTO.PrefixedUnit(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                prefixedUnit.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                prefixedUnit.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                prefixedUnit.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                prefixedUnit.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                prefixedUnit.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                prefixedUnit.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                prefixedUnit.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["prefix"].IsNullOrEmpty())
            {
                prefixedUnit.Prefix = jObject["prefix"].ToObject<Guid>();
            }

            if (!jObject["referenceUnit"].IsNullOrEmpty())
            {
                prefixedUnit.ReferenceUnit = jObject["referenceUnit"].ToObject<Guid>();
            }

            return prefixedUnit;
        }
    }
}
