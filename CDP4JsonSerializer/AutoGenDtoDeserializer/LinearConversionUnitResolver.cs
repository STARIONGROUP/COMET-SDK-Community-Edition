// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearConversionUnitResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="LinearConversionUnitResolver"/> is to deserialize a JSON object to a <see cref="LinearConversionUnit"/>
    /// </summary>
    public static class LinearConversionUnitResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="LinearConversionUnit"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="LinearConversionUnit"/> to instantiate</returns>
        public static CDP4Common.DTO.LinearConversionUnit FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var linearConversionUnit = new CDP4Common.DTO.LinearConversionUnit(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                linearConversionUnit.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["conversionFactor"].IsNullOrEmpty())
            {
                linearConversionUnit.ConversionFactor = jObject["conversionFactor"].ToObject<string>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                linearConversionUnit.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                linearConversionUnit.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                linearConversionUnit.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                linearConversionUnit.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                linearConversionUnit.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                linearConversionUnit.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                linearConversionUnit.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["referenceUnit"].IsNullOrEmpty())
            {
                linearConversionUnit.ReferenceUnit = jObject["referenceUnit"].ToObject<Guid>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                linearConversionUnit.ShortName = jObject["shortName"].ToObject<string>();
            }

            return linearConversionUnit;
        }
    }
}
