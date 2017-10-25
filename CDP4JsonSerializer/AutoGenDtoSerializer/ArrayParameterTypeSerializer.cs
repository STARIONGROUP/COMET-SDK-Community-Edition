// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ArrayParameterTypeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ArrayParameterTypeSerializer"/> class is to provide a <see cref="ArrayParameterType"/> specific serializer
    /// </summary>
    public class ArrayParameterTypeSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "component", component => new JArray(((IEnumerable)component).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "definition", definition => new JArray(definition) },
            { "dimension", dimension => new JArray(((IEnumerable)dimension).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "isFinalized", isFinalized => new JValue(isFinalized) },
            { "isTensor", isTensor => new JValue(isTensor) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "symbol", symbol => new JValue(symbol) },
        };

        /// <summary>
        /// Serialize the <see cref="ArrayParameterType"/>
        /// </summary>
        /// <param name="arrayParameterType">The <see cref="ArrayParameterType"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ArrayParameterType arrayParameterType)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](arrayParameterType.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](arrayParameterType.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), arrayParameterType.ClassKind)));
            jsonObject.Add("component", this.PropertySerializerMap["component"](arrayParameterType.Component));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](arrayParameterType.Definition));
            jsonObject.Add("dimension", this.PropertySerializerMap["dimension"](arrayParameterType.Dimension));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](arrayParameterType.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](arrayParameterType.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](arrayParameterType.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](arrayParameterType.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](arrayParameterType.IsDeprecated));
            jsonObject.Add("isFinalized", this.PropertySerializerMap["isFinalized"](arrayParameterType.IsFinalized));
            jsonObject.Add("isTensor", this.PropertySerializerMap["isTensor"](arrayParameterType.IsTensor));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](arrayParameterType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](arrayParameterType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](arrayParameterType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](arrayParameterType.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](arrayParameterType.Symbol));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ArrayParameterType"/> class.
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

            var arrayParameterType = thing as ArrayParameterType;
            if (arrayParameterType == null)
            {
                throw new InvalidOperationException("The thing is not a ArrayParameterType.");
            }

            return this.Serialize(arrayParameterType);
        }
    }
}
