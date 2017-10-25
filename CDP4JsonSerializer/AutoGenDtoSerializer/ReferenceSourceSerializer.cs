// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ReferenceSourceSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ReferenceSourceSerializer"/> class is to provide a <see cref="ReferenceSource"/> specific serializer
    /// </summary>
    public class ReferenceSourceSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "author", author => new JValue(author) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "language", language => new JValue(language) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "publicationYear", publicationYear => new JValue(publicationYear) },
            { "publishedIn", publishedIn => new JValue(publishedIn) },
            { "publisher", publisher => new JValue(publisher) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "versionDate", versionDate => new JValue(versionDate != null ? ((DateTime)versionDate).ToString("yyyy-MM-ddTHH:mm:ss.fffZ") : null) },
            { "versionIdentifier", versionIdentifier => new JValue(versionIdentifier) },
        };

        /// <summary>
        /// Serialize the <see cref="ReferenceSource"/>
        /// </summary>
        /// <param name="referenceSource">The <see cref="ReferenceSource"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ReferenceSource referenceSource)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](referenceSource.Alias));
            jsonObject.Add("author", this.PropertySerializerMap["author"](referenceSource.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](referenceSource.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), referenceSource.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](referenceSource.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](referenceSource.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](referenceSource.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](referenceSource.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](referenceSource.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](referenceSource.IsDeprecated));
            jsonObject.Add("language", this.PropertySerializerMap["language"](referenceSource.Language));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](referenceSource.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](referenceSource.Name));
            jsonObject.Add("publicationYear", this.PropertySerializerMap["publicationYear"](referenceSource.PublicationYear));
            jsonObject.Add("publishedIn", this.PropertySerializerMap["publishedIn"](referenceSource.PublishedIn));
            jsonObject.Add("publisher", this.PropertySerializerMap["publisher"](referenceSource.Publisher));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](referenceSource.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](referenceSource.ShortName));
            jsonObject.Add("versionDate", this.PropertySerializerMap["versionDate"](referenceSource.VersionDate));
            jsonObject.Add("versionIdentifier", this.PropertySerializerMap["versionIdentifier"](referenceSource.VersionIdentifier));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ReferenceSource"/> class.
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

            var referenceSource = thing as ReferenceSource;
            if (referenceSource == null)
            {
                throw new InvalidOperationException("The thing is not a ReferenceSource.");
            }

            return this.Serialize(referenceSource);
        }
    }
}
