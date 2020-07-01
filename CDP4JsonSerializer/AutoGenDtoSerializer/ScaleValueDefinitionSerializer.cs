// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ScaleValueDefinitionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ScaleValueDefinitionSerializer"/> class is to provide a <see cref="ScaleValueDefinition"/> specific serializer
    /// </summary>
    public class ScaleValueDefinitionSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "value", value => new JValue(value) },
        };

        /// <summary>
        /// Serialize the <see cref="ScaleValueDefinition"/>
        /// </summary>
        /// <param name="scaleValueDefinition">The <see cref="ScaleValueDefinition"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ScaleValueDefinition scaleValueDefinition)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](scaleValueDefinition.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), scaleValueDefinition.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](scaleValueDefinition.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](scaleValueDefinition.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](scaleValueDefinition.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](scaleValueDefinition.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](scaleValueDefinition.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](scaleValueDefinition.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](scaleValueDefinition.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](scaleValueDefinition.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](scaleValueDefinition.ShortName));
            jsonObject.Add("value", this.PropertySerializerMap["value"](scaleValueDefinition.Value));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ScaleValueDefinition"/> class.
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

            var scaleValueDefinition = thing as ScaleValueDefinition;
            if (scaleValueDefinition == null)
            {
                throw new InvalidOperationException("The thing is not a ScaleValueDefinition.");
            }

            return this.Serialize(scaleValueDefinition);
        }
    }
}
