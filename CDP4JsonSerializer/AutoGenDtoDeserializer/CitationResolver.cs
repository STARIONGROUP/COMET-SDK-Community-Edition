// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CitationResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CitationResolver"/> is to deserialize a JSON object to a <see cref="Citation"/>
    /// </summary>
    public static class CitationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Citation"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Citation"/> to instantiate</returns>
        public static CDP4Common.DTO.Citation FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var citation = new CDP4Common.DTO.Citation(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                citation.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                citation.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isAdaptation"].IsNullOrEmpty())
            {
                citation.IsAdaptation = jObject["isAdaptation"].ToObject<bool>();
            }

            if (!jObject["location"].IsNullOrEmpty())
            {
                citation.Location = jObject["location"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                citation.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["remark"].IsNullOrEmpty())
            {
                citation.Remark = jObject["remark"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                citation.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["source"].IsNullOrEmpty())
            {
                citation.Source = jObject["source"].ToObject<Guid>();
            }

            return citation;
        }
    }
}
