// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelLogEntryResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ModelLogEntryResolver"/> is to deserialize a JSON object to a <see cref="ModelLogEntry"/>
    /// </summary>
    public static class ModelLogEntryResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ModelLogEntry"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ModelLogEntry"/> to instantiate</returns>
        public static CDP4Common.DTO.ModelLogEntry FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var modelLogEntry = new CDP4Common.DTO.ModelLogEntry(iid, revisionNumber);

            if (!jObject["affectedItemIid"].IsNullOrEmpty())
            {
                modelLogEntry.AffectedItemIid.AddRange(jObject["affectedItemIid"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["author"].IsNullOrEmpty())
            {
                modelLogEntry.Author = jObject["author"].ToObject<Guid?>();
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                modelLogEntry.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                modelLogEntry.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                modelLogEntry.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                modelLogEntry.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                modelLogEntry.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                modelLogEntry.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["level"].IsNullOrEmpty())
            {
                modelLogEntry.Level = jObject["level"].ToObject<LogLevelKind>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                modelLogEntry.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            return modelLogEntry;
        }
    }
}
