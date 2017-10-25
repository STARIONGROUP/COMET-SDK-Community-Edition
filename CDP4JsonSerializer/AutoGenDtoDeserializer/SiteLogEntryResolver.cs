// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteLogEntryResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteLogEntryResolver"/> is to deserialize a JSON object to a <see cref="SiteLogEntry"/>
    /// </summary>
    public static class SiteLogEntryResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SiteLogEntry"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SiteLogEntry"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteLogEntry FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var siteLogEntry = new CDP4Common.DTO.SiteLogEntry(iid, revisionNumber);

            if (!jObject["affectedItemIid"].IsNullOrEmpty())
            {
                siteLogEntry.AffectedItemIid.AddRange(jObject["affectedItemIid"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["author"].IsNullOrEmpty())
            {
                siteLogEntry.Author = jObject["author"].ToObject<Guid?>();
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                siteLogEntry.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                siteLogEntry.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                siteLogEntry.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                siteLogEntry.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                siteLogEntry.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                siteLogEntry.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["level"].IsNullOrEmpty())
            {
                siteLogEntry.Level = jObject["level"].ToObject<LogLevelKind>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                siteLogEntry.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            return siteLogEntry;
        }
    }
}
