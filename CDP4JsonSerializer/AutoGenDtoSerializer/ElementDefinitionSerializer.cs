// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ElementDefinitionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ElementDefinitionSerializer"/> class is to provide a <see cref="ElementDefinition"/> specific serializer
    /// </summary>
    public class ElementDefinitionSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "containedElement", containedElement => new JArray(containedElement) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "parameter", parameter => new JArray(parameter) },
            { "parameterGroup", parameterGroup => new JArray(parameterGroup) },
            { "referencedElement", referencedElement => new JArray(referencedElement) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="ElementDefinition"/>
        /// </summary>
        /// <param name="elementDefinition">The <see cref="ElementDefinition"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ElementDefinition elementDefinition)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](elementDefinition.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](elementDefinition.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), elementDefinition.ClassKind)));
            jsonObject.Add("containedElement", this.PropertySerializerMap["containedElement"](elementDefinition.ContainedElement));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](elementDefinition.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](elementDefinition.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](elementDefinition.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](elementDefinition.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](elementDefinition.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](elementDefinition.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](elementDefinition.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](elementDefinition.Owner));
            jsonObject.Add("parameter", this.PropertySerializerMap["parameter"](elementDefinition.Parameter));
            jsonObject.Add("parameterGroup", this.PropertySerializerMap["parameterGroup"](elementDefinition.ParameterGroup));
            jsonObject.Add("referencedElement", this.PropertySerializerMap["referencedElement"](elementDefinition.ReferencedElement));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](elementDefinition.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](elementDefinition.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ElementDefinition"/> class.
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

            var elementDefinition = thing as ElementDefinition;
            if (elementDefinition == null)
            {
                throw new InvalidOperationException("The thing is not a ElementDefinition.");
            }

            return this.Serialize(elementDefinition);
        }
    }
}
