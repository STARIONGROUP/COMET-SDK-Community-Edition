// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ExternalIdentifierMapSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ExternalIdentifierMapSerializer"/> class is to provide a <see cref="ExternalIdentifierMap"/> specific serializer
    /// </summary>
    public class ExternalIdentifierMapSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "correspondence", correspondence => new JArray(correspondence) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "externalFormat", externalFormat => new JValue(externalFormat) },
            { "externalModelName", externalModelName => new JValue(externalModelName) },
            { "externalToolName", externalToolName => new JValue(externalToolName) },
            { "externalToolVersion", externalToolVersion => new JValue(externalToolVersion) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="ExternalIdentifierMap"/>
        /// </summary>
        /// <param name="externalIdentifierMap">The <see cref="ExternalIdentifierMap"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ExternalIdentifierMap externalIdentifierMap)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), externalIdentifierMap.ClassKind)));
            jsonObject.Add("correspondence", this.PropertySerializerMap["correspondence"](externalIdentifierMap.Correspondence));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](externalIdentifierMap.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](externalIdentifierMap.ExcludedPerson));
            jsonObject.Add("externalFormat", this.PropertySerializerMap["externalFormat"](externalIdentifierMap.ExternalFormat));
            jsonObject.Add("externalModelName", this.PropertySerializerMap["externalModelName"](externalIdentifierMap.ExternalModelName));
            jsonObject.Add("externalToolName", this.PropertySerializerMap["externalToolName"](externalIdentifierMap.ExternalToolName));
            jsonObject.Add("externalToolVersion", this.PropertySerializerMap["externalToolVersion"](externalIdentifierMap.ExternalToolVersion));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](externalIdentifierMap.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](externalIdentifierMap.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](externalIdentifierMap.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](externalIdentifierMap.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](externalIdentifierMap.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ExternalIdentifierMap"/> class.
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

            var externalIdentifierMap = thing as ExternalIdentifierMap;
            if (externalIdentifierMap == null)
            {
                throw new InvalidOperationException("The thing is not a ExternalIdentifierMap.");
            }

            return this.Serialize(externalIdentifierMap);
        }
    }
}
