// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKindFactorResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="QuantityKindFactorResolver"/> is to deserialize a JSON object to a <see cref="QuantityKindFactor"/>
    /// </summary>
    public static class QuantityKindFactorResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="QuantityKindFactor"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="QuantityKindFactor"/> to instantiate</returns>
        public static CDP4Common.DTO.QuantityKindFactor FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var quantityKindFactor = new CDP4Common.DTO.QuantityKindFactor(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                quantityKindFactor.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                quantityKindFactor.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["exponent"].IsNullOrEmpty())
            {
                quantityKindFactor.Exponent = jObject["exponent"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                quantityKindFactor.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["quantityKind"].IsNullOrEmpty())
            {
                quantityKindFactor.QuantityKind = jObject["quantityKind"].ToObject<Guid>();
            }

            return quantityKindFactor;
        }
    }
}
