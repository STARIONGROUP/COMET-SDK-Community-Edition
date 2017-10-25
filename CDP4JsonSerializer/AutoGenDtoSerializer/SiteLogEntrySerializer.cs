// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteLogEntrySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteLogEntrySerializer"/> class is to provide a <see cref="SiteLogEntry"/> specific serializer
    /// </summary>
    public class SiteLogEntrySerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "affectedItemIid", affectedItemIid => new JArray(affectedItemIid) },
            { "author", author => new JValue(author) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "level", level => new JValue(level.ToString()) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="SiteLogEntry"/>
        /// </summary>
        /// <param name="siteLogEntry">The <see cref="SiteLogEntry"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SiteLogEntry siteLogEntry)
        {
            var jsonObject = new JObject();
            jsonObject.Add("affectedItemIid", this.PropertySerializerMap["affectedItemIid"](siteLogEntry.AffectedItemIid));
            jsonObject.Add("author", this.PropertySerializerMap["author"](siteLogEntry.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](siteLogEntry.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteLogEntry.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](siteLogEntry.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](siteLogEntry.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteLogEntry.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteLogEntry.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteLogEntry.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](siteLogEntry.LanguageCode));
            jsonObject.Add("level", this.PropertySerializerMap["level"](Enum.GetName(typeof(CDP4Common.CommonData.LogLevelKind), siteLogEntry.Level)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteLogEntry.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteLogEntry.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteLogEntry"/> class.
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

            var siteLogEntry = thing as SiteLogEntry;
            if (siteLogEntry == null)
            {
                throw new InvalidOperationException("The thing is not a SiteLogEntry.");
            }

            return this.Serialize(siteLogEntry);
        }
    }
}
