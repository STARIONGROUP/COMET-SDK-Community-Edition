// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingToReferenceScaleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="MappingToReferenceScaleResolver"/> is to deserialize a JSON object to a <see cref="MappingToReferenceScale"/>
    /// </summary>
    public static class MappingToReferenceScaleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="MappingToReferenceScale"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="MappingToReferenceScale"/> to instantiate</returns>
        public static CDP4Common.DTO.MappingToReferenceScale FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var mappingToReferenceScale = new CDP4Common.DTO.MappingToReferenceScale(iid, revisionNumber);

            if (!jObject["dependentScaleValue"].IsNullOrEmpty())
            {
                mappingToReferenceScale.DependentScaleValue = jObject["dependentScaleValue"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                mappingToReferenceScale.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                mappingToReferenceScale.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                mappingToReferenceScale.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["referenceScaleValue"].IsNullOrEmpty())
            {
                mappingToReferenceScale.ReferenceScaleValue = jObject["referenceScaleValue"].ToObject<Guid>();
            }

            return mappingToReferenceScale;
        }
    }
}
