// --------------------------------------------------------------------------------------------------------------------
// <copyright file "EngineeringModelDataNoteSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelDataNoteSerializer"/> class is to provide a <see cref="EngineeringModelDataNote"/> specific serializer
    /// </summary>
    public class EngineeringModelDataNoteSerializer : IThingSerializer
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
            { "discussion", discussion => new JArray(discussion) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "primaryAnnotatedThing", primaryAnnotatedThing => new JValue(primaryAnnotatedThing) },
            { "relatedThing", relatedThing => new JArray(relatedThing) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="EngineeringModelDataNote"/>
        /// </summary>
        /// <param name="engineeringModelDataNote">The <see cref="EngineeringModelDataNote"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(EngineeringModelDataNote engineeringModelDataNote)
        {
            var jsonObject = new JObject();
            jsonObject.Add("author", this.PropertySerializerMap["author"](engineeringModelDataNote.Author));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), engineeringModelDataNote.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](engineeringModelDataNote.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](engineeringModelDataNote.CreatedOn));
            jsonObject.Add("discussion", this.PropertySerializerMap["discussion"](engineeringModelDataNote.Discussion));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](engineeringModelDataNote.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](engineeringModelDataNote.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](engineeringModelDataNote.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](engineeringModelDataNote.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](engineeringModelDataNote.ModifiedOn));
            jsonObject.Add("primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](engineeringModelDataNote.PrimaryAnnotatedThing));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](engineeringModelDataNote.RelatedThing));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](engineeringModelDataNote.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="EngineeringModelDataNote"/> class.
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

            var engineeringModelDataNote = thing as EngineeringModelDataNote;
            if (engineeringModelDataNote == null)
            {
                throw new InvalidOperationException("The thing is not a EngineeringModelDataNote.");
            }

            return this.Serialize(engineeringModelDataNote);
        }
    }
}
