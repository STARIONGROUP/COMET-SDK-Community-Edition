// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryDataDiscussionItemResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryDataDiscussionItemResolver"/> is to deserialize a JSON object to a <see cref="SiteDirectoryDataDiscussionItem"/>
    /// </summary>
    public static class SiteDirectoryDataDiscussionItemResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SiteDirectoryDataDiscussionItem"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SiteDirectoryDataDiscussionItem"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteDirectoryDataDiscussionItem FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var siteDirectoryDataDiscussionItem = new CDP4Common.DTO.SiteDirectoryDataDiscussionItem(iid, revisionNumber);

            if (!jObject["author"].IsNullOrEmpty())
            {
                siteDirectoryDataDiscussionItem.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                siteDirectoryDataDiscussionItem.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                siteDirectoryDataDiscussionItem.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                siteDirectoryDataDiscussionItem.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                siteDirectoryDataDiscussionItem.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                siteDirectoryDataDiscussionItem.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                siteDirectoryDataDiscussionItem.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["replyTo"].IsNullOrEmpty())
            {
                siteDirectoryDataDiscussionItem.ReplyTo = jObject["replyTo"].ToObject<Guid?>();
            }

            return siteDirectoryDataDiscussionItem;
        }
    }
}
