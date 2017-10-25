// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompoundParameterTypeResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CompoundParameterTypeResolver"/> is to deserialize a JSON object to a <see cref="CompoundParameterType"/>
    /// </summary>
    public static class CompoundParameterTypeResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="CompoundParameterType"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="CompoundParameterType"/> to instantiate</returns>
        public static CDP4Common.DTO.CompoundParameterType FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var compoundParameterType = new CDP4Common.DTO.CompoundParameterType(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                compoundParameterType.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                compoundParameterType.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["component"].IsNullOrEmpty())
            {
                compoundParameterType.Component.AddRange(jObject["component"].ToOrderedItemCollection());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                compoundParameterType.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                compoundParameterType.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                compoundParameterType.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                compoundParameterType.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                compoundParameterType.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["isFinalized"].IsNullOrEmpty())
            {
                compoundParameterType.IsFinalized = jObject["isFinalized"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                compoundParameterType.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                compoundParameterType.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                compoundParameterType.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["symbol"].IsNullOrEmpty())
            {
                compoundParameterType.Symbol = jObject["symbol"].ToObject<string>();
            }

            return compoundParameterType;
        }
    }
}
