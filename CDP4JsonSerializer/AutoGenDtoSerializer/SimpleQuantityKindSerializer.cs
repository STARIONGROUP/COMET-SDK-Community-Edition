// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SimpleQuantityKindSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SimpleQuantityKindSerializer"/> class is to provide a <see cref="SimpleQuantityKind"/> specific serializer
    /// </summary>
    public class SimpleQuantityKindSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "defaultScale", defaultScale => new JValue(defaultScale) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "possibleScale", possibleScale => new JArray(possibleScale) },
            { "quantityDimensionSymbol", quantityDimensionSymbol => new JValue(quantityDimensionSymbol) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "symbol", symbol => new JValue(symbol) },
        };

        /// <summary>
        /// Serialize the <see cref="SimpleQuantityKind"/>
        /// </summary>
        /// <param name="simpleQuantityKind">The <see cref="SimpleQuantityKind"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SimpleQuantityKind simpleQuantityKind)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](simpleQuantityKind.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](simpleQuantityKind.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), simpleQuantityKind.ClassKind)));
            jsonObject.Add("defaultScale", this.PropertySerializerMap["defaultScale"](simpleQuantityKind.DefaultScale));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](simpleQuantityKind.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](simpleQuantityKind.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](simpleQuantityKind.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](simpleQuantityKind.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](simpleQuantityKind.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](simpleQuantityKind.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](simpleQuantityKind.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](simpleQuantityKind.Name));
            jsonObject.Add("possibleScale", this.PropertySerializerMap["possibleScale"](simpleQuantityKind.PossibleScale));
            jsonObject.Add("quantityDimensionSymbol", this.PropertySerializerMap["quantityDimensionSymbol"](simpleQuantityKind.QuantityDimensionSymbol));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](simpleQuantityKind.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](simpleQuantityKind.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](simpleQuantityKind.Symbol));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SimpleQuantityKind"/> class.
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

            var simpleQuantityKind = thing as SimpleQuantityKind;
            if (simpleQuantityKind == null)
            {
                throw new InvalidOperationException("The thing is not a SimpleQuantityKind.");
            }

            return this.Serialize(simpleQuantityKind);
        }
    }
}
