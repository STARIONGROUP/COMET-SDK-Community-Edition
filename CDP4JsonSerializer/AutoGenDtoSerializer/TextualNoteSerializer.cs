// --------------------------------------------------------------------------------------------------------------------
// <copyright file "TextualNoteSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="TextualNoteSerializer"/> class is to provide a <see cref="TextualNote"/> specific serializer
    /// </summary>
    public class TextualNoteSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="TextualNote"/>
        /// </summary>
        /// <param name="textualNote">The <see cref="TextualNote"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(TextualNote textualNote)
        {
            var jsonObject = new JObject();
            jsonObject.Add("category", this.PropertySerializerMap["category"](textualNote.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), textualNote.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](textualNote.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](textualNote.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](textualNote.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](textualNote.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](textualNote.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](textualNote.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](textualNote.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](textualNote.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](textualNote.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](textualNote.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](textualNote.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="TextualNote"/> class.
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

            var textualNote = thing as TextualNote;
            if (textualNote == null)
            {
                throw new InvalidOperationException("The thing is not a TextualNote.");
            }

            return this.Serialize(textualNote);
        }
    }
}
