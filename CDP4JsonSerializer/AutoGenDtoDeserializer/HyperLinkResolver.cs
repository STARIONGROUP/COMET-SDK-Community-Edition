// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HyperLinkResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="HyperLinkResolver"/> is to deserialize a JSON object to a <see cref="HyperLink"/>
    /// </summary>
    public static class HyperLinkResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="HyperLink"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="HyperLink"/> to instantiate</returns>
        public static CDP4Common.DTO.HyperLink FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var hyperLink = new CDP4Common.DTO.HyperLink(iid, revisionNumber);

            if (!jObject["content"].IsNullOrEmpty())
            {
                hyperLink.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                hyperLink.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                hyperLink.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                hyperLink.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                hyperLink.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["uri"].IsNullOrEmpty())
            {
                hyperLink.Uri = jObject["uri"].ToObject<string>();
            }

            return hyperLink;
        }
    }
}
