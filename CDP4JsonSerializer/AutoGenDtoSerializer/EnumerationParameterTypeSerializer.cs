// --------------------------------------------------------------------------------------------------------------------
// <copyright file "EnumerationParameterTypeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EnumerationParameterTypeSerializer"/> class is to provide a <see cref="EnumerationParameterType"/> specific serializer
    /// </summary>
    public class EnumerationParameterTypeSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "allowMultiSelect", allowMultiSelect => new JValue(allowMultiSelect) },
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
            { "symbol", symbol => new JValue(symbol) },
            { "valueDefinition", valueDefinition => new JArray(((IEnumerable)valueDefinition).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
        };

        /// <summary>
        /// Serialize the <see cref="EnumerationParameterType"/>
        /// </summary>
        /// <param name="enumerationParameterType">The <see cref="EnumerationParameterType"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(EnumerationParameterType enumerationParameterType)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](enumerationParameterType.Alias));
            jsonObject.Add("allowMultiSelect", this.PropertySerializerMap["allowMultiSelect"](enumerationParameterType.AllowMultiSelect));
            jsonObject.Add("category", this.PropertySerializerMap["category"](enumerationParameterType.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), enumerationParameterType.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](enumerationParameterType.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](enumerationParameterType.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](enumerationParameterType.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](enumerationParameterType.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](enumerationParameterType.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](enumerationParameterType.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](enumerationParameterType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](enumerationParameterType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](enumerationParameterType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](enumerationParameterType.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](enumerationParameterType.Symbol));
            jsonObject.Add("valueDefinition", this.PropertySerializerMap["valueDefinition"](enumerationParameterType.ValueDefinition));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="EnumerationParameterType"/> class.
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

            var enumerationParameterType = thing as EnumerationParameterType;
            if (enumerationParameterType == null)
            {
                throw new InvalidOperationException("The thing is not a EnumerationParameterType.");
            }

            return this.Serialize(enumerationParameterType);
        }
    }
}
