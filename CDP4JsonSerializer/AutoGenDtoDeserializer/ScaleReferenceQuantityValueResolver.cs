// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaleReferenceQuantityValueResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ScaleReferenceQuantityValueResolver"/> is to deserialize a JSON object to a <see cref="ScaleReferenceQuantityValue"/>
    /// </summary>
    public static class ScaleReferenceQuantityValueResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ScaleReferenceQuantityValue"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ScaleReferenceQuantityValue"/> to instantiate</returns>
        public static CDP4Common.DTO.ScaleReferenceQuantityValue FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var scaleReferenceQuantityValue = new CDP4Common.DTO.ScaleReferenceQuantityValue(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                scaleReferenceQuantityValue.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                scaleReferenceQuantityValue.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                scaleReferenceQuantityValue.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                scaleReferenceQuantityValue.Scale = jObject["scale"].ToObject<Guid>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                scaleReferenceQuantityValue.Value = jObject["value"].ToObject<string>();
            }

            return scaleReferenceQuantityValue;
        }
    }
}
