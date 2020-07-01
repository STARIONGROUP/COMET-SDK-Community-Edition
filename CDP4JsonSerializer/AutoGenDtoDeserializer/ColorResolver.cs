// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ColorResolver"/> is to deserialize a JSON object to a <see cref="Color"/>
    /// </summary>
    public static class ColorResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Color"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Color"/> to instantiate</returns>
        public static CDP4Common.DTO.Color FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var color = new CDP4Common.DTO.Color(iid, revisionNumber);

            if (!jObject["blue"].IsNullOrEmpty())
            {
                color.Blue = jObject["blue"].ToObject<int>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                color.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                color.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["green"].IsNullOrEmpty())
            {
                color.Green = jObject["green"].ToObject<int>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                color.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                color.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["red"].IsNullOrEmpty())
            {
                color.Red = jObject["red"].ToObject<int>();
            }

            return color;
        }
    }
}
