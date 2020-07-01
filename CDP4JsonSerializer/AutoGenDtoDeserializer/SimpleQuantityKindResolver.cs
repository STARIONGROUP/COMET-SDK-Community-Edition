// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleQuantityKindResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SimpleQuantityKindResolver"/> is to deserialize a JSON object to a <see cref="SimpleQuantityKind"/>
    /// </summary>
    public static class SimpleQuantityKindResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SimpleQuantityKind"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SimpleQuantityKind"/> to instantiate</returns>
        public static CDP4Common.DTO.SimpleQuantityKind FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var simpleQuantityKind = new CDP4Common.DTO.SimpleQuantityKind(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                simpleQuantityKind.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                simpleQuantityKind.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["defaultScale"].IsNullOrEmpty())
            {
                simpleQuantityKind.DefaultScale = jObject["defaultScale"].ToObject<Guid>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                simpleQuantityKind.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                simpleQuantityKind.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                simpleQuantityKind.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                simpleQuantityKind.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                simpleQuantityKind.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                simpleQuantityKind.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                simpleQuantityKind.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["possibleScale"].IsNullOrEmpty())
            {
                simpleQuantityKind.PossibleScale.AddRange(jObject["possibleScale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["quantityDimensionSymbol"].IsNullOrEmpty())
            {
                simpleQuantityKind.QuantityDimensionSymbol = jObject["quantityDimensionSymbol"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                simpleQuantityKind.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["symbol"].IsNullOrEmpty())
            {
                simpleQuantityKind.Symbol = jObject["symbol"].ToObject<string>();
            }

            return simpleQuantityKind;
        }
    }
}
