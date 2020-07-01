// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataDiscussionItemResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelDataDiscussionItemResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModelDataDiscussionItem"/>
    /// </summary>
    public static class EngineeringModelDataDiscussionItemResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="EngineeringModelDataDiscussionItem"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModelDataDiscussionItem"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModelDataDiscussionItem FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var engineeringModelDataDiscussionItem = new CDP4Common.DTO.EngineeringModelDataDiscussionItem(iid, revisionNumber);

            if (!jObject["author"].IsNullOrEmpty())
            {
                engineeringModelDataDiscussionItem.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                engineeringModelDataDiscussionItem.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                engineeringModelDataDiscussionItem.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                engineeringModelDataDiscussionItem.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                engineeringModelDataDiscussionItem.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                engineeringModelDataDiscussionItem.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                engineeringModelDataDiscussionItem.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["replyTo"].IsNullOrEmpty())
            {
                engineeringModelDataDiscussionItem.ReplyTo = jObject["replyTo"].ToObject<Guid?>();
            }

            return engineeringModelDataDiscussionItem;
        }
    }
}
