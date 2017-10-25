// --------------------------------------------------------------------------------------------------------------------
// <copyright file "HyperLinkSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="HyperLinkSerializer"/> class is to provide a <see cref="HyperLink"/> specific serializer
    /// </summary>
    public class HyperLinkSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "uri", uri => new JValue(uri) },
        };

        /// <summary>
        /// Serialize the <see cref="HyperLink"/>
        /// </summary>
        /// <param name="hyperLink">The <see cref="HyperLink"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(HyperLink hyperLink)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), hyperLink.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](hyperLink.Content));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](hyperLink.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](hyperLink.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](hyperLink.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](hyperLink.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](hyperLink.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](hyperLink.RevisionNumber));
            jsonObject.Add("uri", this.PropertySerializerMap["uri"](hyperLink.Uri));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="HyperLink"/> class.
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

            var hyperLink = thing as HyperLink;
            if (hyperLink == null)
            {
                throw new InvalidOperationException("The thing is not a HyperLink.");
            }

            return this.Serialize(hyperLink);
        }
    }
}
