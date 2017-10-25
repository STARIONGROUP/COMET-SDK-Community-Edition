// --------------------------------------------------------------------------------------------------------------------
// <copyright file "GlossarySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="GlossarySerializer"/> class is to provide a <see cref="Glossary"/> specific serializer
    /// </summary>
    public class GlossarySerializer : IThingSerializer
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
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "term", term => new JArray(term) },
        };

        /// <summary>
        /// Serialize the <see cref="Glossary"/>
        /// </summary>
        /// <param name="glossary">The <see cref="Glossary"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Glossary glossary)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](glossary.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](glossary.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), glossary.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](glossary.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](glossary.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](glossary.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](glossary.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](glossary.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](glossary.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](glossary.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](glossary.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](glossary.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](glossary.ShortName));
            jsonObject.Add("term", this.PropertySerializerMap["term"](glossary.Term));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Glossary"/> class.
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

            var glossary = thing as Glossary;
            if (glossary == null)
            {
                throw new InvalidOperationException("The thing is not a Glossary.");
            }

            return this.Serialize(glossary);
        }
    }
}
