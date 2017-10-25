// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PointResolver"/> is to deserialize a JSON object to a <see cref="Point"/>
    /// </summary>
    public static class PointResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Point"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Point"/> to instantiate</returns>
        public static CDP4Common.DTO.Point FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var point = new CDP4Common.DTO.Point(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                point.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                point.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                point.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                point.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["x"].IsNullOrEmpty())
            {
                point.X = jObject["x"].ToObject<float>();
            }

            if (!jObject["y"].IsNullOrEmpty())
            {
                point.Y = jObject["y"].ToObject<float>();
            }

            return point;
        }
    }
}
