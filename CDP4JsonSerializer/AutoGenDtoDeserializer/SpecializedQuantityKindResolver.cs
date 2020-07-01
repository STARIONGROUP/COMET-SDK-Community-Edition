// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecializedQuantityKindResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SpecializedQuantityKindResolver"/> is to deserialize a JSON object to a <see cref="SpecializedQuantityKind"/>
    /// </summary>
    public static class SpecializedQuantityKindResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SpecializedQuantityKind"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SpecializedQuantityKind"/> to instantiate</returns>
        public static CDP4Common.DTO.SpecializedQuantityKind FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var specializedQuantityKind = new CDP4Common.DTO.SpecializedQuantityKind(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                specializedQuantityKind.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                specializedQuantityKind.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["defaultScale"].IsNullOrEmpty())
            {
                specializedQuantityKind.DefaultScale = jObject["defaultScale"].ToObject<Guid>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                specializedQuantityKind.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                specializedQuantityKind.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                specializedQuantityKind.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["general"].IsNullOrEmpty())
            {
                specializedQuantityKind.General = jObject["general"].ToObject<Guid>();
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                specializedQuantityKind.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                specializedQuantityKind.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                specializedQuantityKind.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                specializedQuantityKind.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["possibleScale"].IsNullOrEmpty())
            {
                specializedQuantityKind.PossibleScale.AddRange(jObject["possibleScale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["quantityDimensionSymbol"].IsNullOrEmpty())
            {
                specializedQuantityKind.QuantityDimensionSymbol = jObject["quantityDimensionSymbol"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                specializedQuantityKind.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["symbol"].IsNullOrEmpty())
            {
                specializedQuantityKind.Symbol = jObject["symbol"].ToObject<string>();
            }

            return specializedQuantityKind;
        }
    }
}
