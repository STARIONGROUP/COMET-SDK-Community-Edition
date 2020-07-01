// --------------------------------------------------------------------------------------------------------------------
// <copyright file "NaturalLanguageSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NaturalLanguageSerializer"/> class is to provide a <see cref="NaturalLanguage"/> specific serializer
    /// </summary>
    public class NaturalLanguageSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "nativeName", nativeName => new JValue(nativeName) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="NaturalLanguage"/>
        /// </summary>
        /// <param name="naturalLanguage">The <see cref="NaturalLanguage"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(NaturalLanguage naturalLanguage)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), naturalLanguage.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](naturalLanguage.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](naturalLanguage.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](naturalLanguage.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](naturalLanguage.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](naturalLanguage.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](naturalLanguage.Name));
            jsonObject.Add("nativeName", this.PropertySerializerMap["nativeName"](naturalLanguage.NativeName));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](naturalLanguage.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="NaturalLanguage"/> class.
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

            var naturalLanguage = thing as NaturalLanguage;
            if (naturalLanguage == null)
            {
                throw new InvalidOperationException("The thing is not a NaturalLanguage.");
            }

            return this.Serialize(naturalLanguage);
        }
    }
}
