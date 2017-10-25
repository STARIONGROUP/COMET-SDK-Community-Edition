// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceSourceResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ReferenceSourceResolver"/> is to deserialize a JSON object to a <see cref="ReferenceSource"/>
    /// </summary>
    public static class ReferenceSourceResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ReferenceSource"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ReferenceSource"/> to instantiate</returns>
        public static CDP4Common.DTO.ReferenceSource FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var referenceSource = new CDP4Common.DTO.ReferenceSource(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                referenceSource.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["author"].IsNullOrEmpty())
            {
                referenceSource.Author = jObject["author"].ToObject<string>();
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                referenceSource.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                referenceSource.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                referenceSource.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                referenceSource.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                referenceSource.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                referenceSource.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["language"].IsNullOrEmpty())
            {
                referenceSource.Language = jObject["language"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                referenceSource.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                referenceSource.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["publicationYear"].IsNullOrEmpty())
            {
                referenceSource.PublicationYear = jObject["publicationYear"].ToObject<int?>();
            }

            if (!jObject["publishedIn"].IsNullOrEmpty())
            {
                referenceSource.PublishedIn = jObject["publishedIn"].ToObject<Guid?>();
            }

            if (!jObject["publisher"].IsNullOrEmpty())
            {
                referenceSource.Publisher = jObject["publisher"].ToObject<Guid?>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                referenceSource.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["versionDate"].IsNullOrEmpty())
            {
                referenceSource.VersionDate = jObject["versionDate"].ToObject<DateTime?>();
            }

            if (!jObject["versionIdentifier"].IsNullOrEmpty())
            {
                referenceSource.VersionIdentifier = jObject["versionIdentifier"].ToObject<string>();
            }

            return referenceSource;
        }
    }
}
