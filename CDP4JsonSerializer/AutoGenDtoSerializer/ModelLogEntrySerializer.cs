// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ModelLogEntrySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ModelLogEntrySerializer"/> class is to provide a <see cref="ModelLogEntry"/> specific serializer
    /// </summary>
    public class ModelLogEntrySerializer : IThingSerializer
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
        /// Serialize the <see cref="ModelLogEntry"/>
        /// </summary>
        /// <param name="modelLogEntry">The <see cref="ModelLogEntry"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ModelLogEntry modelLogEntry)
        {
            var jsonObject = new JObject();
            jsonObject.Add("affectedItemIid", this.PropertySerializerMap["affectedItemIid"](modelLogEntry.AffectedItemIid));
            jsonObject.Add("author", this.PropertySerializerMap["author"](modelLogEntry.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](modelLogEntry.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), modelLogEntry.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](modelLogEntry.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](modelLogEntry.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](modelLogEntry.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](modelLogEntry.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](modelLogEntry.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](modelLogEntry.LanguageCode));
            jsonObject.Add("level", this.PropertySerializerMap["level"](Enum.GetName(typeof(CDP4Common.CommonData.LogLevelKind), modelLogEntry.Level)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](modelLogEntry.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](modelLogEntry.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ModelLogEntry"/> class.
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

            var modelLogEntry = thing as ModelLogEntry;
            if (modelLogEntry == null)
            {
                throw new InvalidOperationException("The thing is not a ModelLogEntry.");
            }

            return this.Serialize(modelLogEntry);
        }
    }
}
