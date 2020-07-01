// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoundsResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BoundsResolver"/> is to deserialize a JSON object to a <see cref="Bounds"/>
    /// </summary>
    public static class BoundsResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Bounds"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Bounds"/> to instantiate</returns>
        public static CDP4Common.DTO.Bounds FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var bounds = new CDP4Common.DTO.Bounds(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                bounds.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                bounds.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["height"].IsNullOrEmpty())
            {
                bounds.Height = jObject["height"].ToObject<float>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                bounds.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                bounds.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["width"].IsNullOrEmpty())
            {
                bounds.Width = jObject["width"].ToObject<float>();
            }

            if (!jObject["x"].IsNullOrEmpty())
            {
                bounds.X = jObject["x"].ToObject<float>();
            }

            if (!jObject["y"].IsNullOrEmpty())
            {
                bounds.Y = jObject["y"].ToObject<float>();
            }

            return bounds;
        }
    }
}
