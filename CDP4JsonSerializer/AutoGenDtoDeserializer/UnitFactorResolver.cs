// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitFactorResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="UnitFactorResolver"/> is to deserialize a JSON object to a <see cref="UnitFactor"/>
    /// </summary>
    public static class UnitFactorResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="UnitFactor"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="UnitFactor"/> to instantiate</returns>
        public static CDP4Common.DTO.UnitFactor FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var unitFactor = new CDP4Common.DTO.UnitFactor(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                unitFactor.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                unitFactor.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["exponent"].IsNullOrEmpty())
            {
                unitFactor.Exponent = jObject["exponent"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                unitFactor.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["unit"].IsNullOrEmpty())
            {
                unitFactor.Unit = jObject["unit"].ToObject<Guid>();
            }

            return unitFactor;
        }
    }
}
