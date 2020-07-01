// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedQuantityKindResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DerivedQuantityKindResolver"/> is to deserialize a JSON object to a <see cref="DerivedQuantityKind"/>
    /// </summary>
    public static class DerivedQuantityKindResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="DerivedQuantityKind"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="DerivedQuantityKind"/> to instantiate</returns>
        public static CDP4Common.DTO.DerivedQuantityKind FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var derivedQuantityKind = new CDP4Common.DTO.DerivedQuantityKind(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                derivedQuantityKind.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                derivedQuantityKind.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["defaultScale"].IsNullOrEmpty())
            {
                derivedQuantityKind.DefaultScale = jObject["defaultScale"].ToObject<Guid>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                derivedQuantityKind.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                derivedQuantityKind.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                derivedQuantityKind.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                derivedQuantityKind.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                derivedQuantityKind.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                derivedQuantityKind.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                derivedQuantityKind.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["possibleScale"].IsNullOrEmpty())
            {
                derivedQuantityKind.PossibleScale.AddRange(jObject["possibleScale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["quantityDimensionSymbol"].IsNullOrEmpty())
            {
                derivedQuantityKind.QuantityDimensionSymbol = jObject["quantityDimensionSymbol"].ToObject<string>();
            }

            if (!jObject["quantityKindFactor"].IsNullOrEmpty())
            {
                derivedQuantityKind.QuantityKindFactor.AddRange(jObject["quantityKindFactor"].ToOrderedItemCollection());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                derivedQuantityKind.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["symbol"].IsNullOrEmpty())
            {
                derivedQuantityKind.Symbol = jObject["symbol"].ToObject<string>();
            }

            return derivedQuantityKind;
        }
    }
}
