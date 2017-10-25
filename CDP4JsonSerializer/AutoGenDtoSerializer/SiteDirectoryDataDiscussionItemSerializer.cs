// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteDirectoryDataDiscussionItemSerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Serializer class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.DTO;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;
    
    /// <summary>
    /// The purpose of the <see cref="SiteDirectoryDataDiscussionItemSerializer"/> class is to provide a <see cref="SiteDirectoryDataDiscussionItem"/> specific serializer
    /// </summary>
    public class SiteDirectoryDataDiscussionItemSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "author", author => new JValue(author) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "replyTo", replyTo => new JValue(replyTo) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="SiteDirectoryDataDiscussionItem"/>
        /// </summary>
        /// <param name="siteDirectoryDataDiscussionItem">The <see cref="SiteDirectoryDataDiscussionItem"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SiteDirectoryDataDiscussionItem siteDirectoryDataDiscussionItem)
        {
            var jsonObject = new JObject();
            jsonObject.Add("author", this.PropertySerializerMap["author"](siteDirectoryDataDiscussionItem.Author));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteDirectoryDataDiscussionItem.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](siteDirectoryDataDiscussionItem.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](siteDirectoryDataDiscussionItem.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteDirectoryDataDiscussionItem.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteDirectoryDataDiscussionItem.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteDirectoryDataDiscussionItem.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](siteDirectoryDataDiscussionItem.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteDirectoryDataDiscussionItem.ModifiedOn));
            jsonObject.Add("replyTo", this.PropertySerializerMap["replyTo"](siteDirectoryDataDiscussionItem.ReplyTo));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteDirectoryDataDiscussionItem.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteDirectoryDataDiscussionItem"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JToken>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        public JObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            var siteDirectoryDataDiscussionItem = thing as SiteDirectoryDataDiscussionItem;
            if (siteDirectoryDataDiscussionItem == null)
            {
                throw new InvalidOperationException("The thing is not a SiteDirectoryDataDiscussionItem.");
            }

            return this.Serialize(siteDirectoryDataDiscussionItem);
        }
    }
}
