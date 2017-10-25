// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RatioScaleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RatioScaleResolver"/> is to deserialize a JSON object to a <see cref="RatioScale"/>
    /// </summary>
    public static class RatioScaleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="RatioScale"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="RatioScale"/> to instantiate</returns>
        public static CDP4Common.DTO.RatioScale FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var ratioScale = new CDP4Common.DTO.RatioScale(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                ratioScale.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                ratioScale.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                ratioScale.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                ratioScale.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                ratioScale.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                ratioScale.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["isMaximumInclusive"].IsNullOrEmpty())
            {
                ratioScale.IsMaximumInclusive = jObject["isMaximumInclusive"].ToObject<bool>();
            }

            if (!jObject["isMinimumInclusive"].IsNullOrEmpty())
            {
                ratioScale.IsMinimumInclusive = jObject["isMinimumInclusive"].ToObject<bool>();
            }

            if (!jObject["mappingToReferenceScale"].IsNullOrEmpty())
            {
                ratioScale.MappingToReferenceScale.AddRange(jObject["mappingToReferenceScale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["maximumPermissibleValue"].IsNullOrEmpty())
            {
                ratioScale.MaximumPermissibleValue = jObject["maximumPermissibleValue"].ToObject<string>();
            }

            if (!jObject["minimumPermissibleValue"].IsNullOrEmpty())
            {
                ratioScale.MinimumPermissibleValue = jObject["minimumPermissibleValue"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                ratioScale.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                ratioScale.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["negativeValueConnotation"].IsNullOrEmpty())
            {
                ratioScale.NegativeValueConnotation = jObject["negativeValueConnotation"].ToObject<string>();
            }

            if (!jObject["numberSet"].IsNullOrEmpty())
            {
                ratioScale.NumberSet = jObject["numberSet"].ToObject<NumberSetKind>();
            }

            if (!jObject["positiveValueConnotation"].IsNullOrEmpty())
            {
                ratioScale.PositiveValueConnotation = jObject["positiveValueConnotation"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                ratioScale.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["unit"].IsNullOrEmpty())
            {
                ratioScale.Unit = jObject["unit"].ToObject<Guid>();
            }

            if (!jObject["valueDefinition"].IsNullOrEmpty())
            {
                ratioScale.ValueDefinition.AddRange(jObject["valueDefinition"].ToObject<IEnumerable<Guid>>());
            }

            return ratioScale;
        }
    }
}
