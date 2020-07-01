// --------------------------------------------------------------------------------------------------------------------
// <copyright file "FileTypeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FileTypeSerializer"/> class is to provide a <see cref="FileType"/> specific serializer
    /// </summary>
    public class FileTypeSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "extension", extension => new JValue(extension) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="FileType"/>
        /// </summary>
        /// <param name="fileType">The <see cref="FileType"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(FileType fileType)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](fileType.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](fileType.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), fileType.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](fileType.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](fileType.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](fileType.ExcludedPerson));
            jsonObject.Add("extension", this.PropertySerializerMap["extension"](fileType.Extension));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](fileType.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](fileType.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](fileType.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](fileType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](fileType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](fileType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](fileType.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="FileType"/> class.
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

            var fileType = thing as FileType;
            if (fileType == null)
            {
                throw new InvalidOperationException("The thing is not a FileType.");
            }

            return this.Serialize(fileType);
        }
    }
}
