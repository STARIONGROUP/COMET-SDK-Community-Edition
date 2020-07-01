// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SpecializedQuantityKindSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SpecializedQuantityKindSerializer"/> class is to provide a <see cref="SpecializedQuantityKind"/> specific serializer
    /// </summary>
    public class SpecializedQuantityKindSerializer : IThingSerializer
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
            { "general", general => new JValue(general) },
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
        /// Serialize the <see cref="SpecializedQuantityKind"/>
        /// </summary>
        /// <param name="specializedQuantityKind">The <see cref="SpecializedQuantityKind"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SpecializedQuantityKind specializedQuantityKind)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](specializedQuantityKind.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](specializedQuantityKind.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), specializedQuantityKind.ClassKind)));
            jsonObject.Add("defaultScale", this.PropertySerializerMap["defaultScale"](specializedQuantityKind.DefaultScale));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](specializedQuantityKind.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](specializedQuantityKind.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](specializedQuantityKind.ExcludedPerson));
            jsonObject.Add("general", this.PropertySerializerMap["general"](specializedQuantityKind.General));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](specializedQuantityKind.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](specializedQuantityKind.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](specializedQuantityKind.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](specializedQuantityKind.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](specializedQuantityKind.Name));
            jsonObject.Add("possibleScale", this.PropertySerializerMap["possibleScale"](specializedQuantityKind.PossibleScale));
            jsonObject.Add("quantityDimensionSymbol", this.PropertySerializerMap["quantityDimensionSymbol"](specializedQuantityKind.QuantityDimensionSymbol));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](specializedQuantityKind.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](specializedQuantityKind.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](specializedQuantityKind.Symbol));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SpecializedQuantityKind"/> class.
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

            var specializedQuantityKind = thing as SpecializedQuantityKind;
            if (specializedQuantityKind == null)
            {
                throw new InvalidOperationException("The thing is not a SpecializedQuantityKind.");
            }

            return this.Serialize(specializedQuantityKind);
        }
    }
}
