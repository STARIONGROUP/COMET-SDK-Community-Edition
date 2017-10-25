// --------------------------------------------------------------------------------------------------------------------
// <copyright file "OrdinalScaleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="OrdinalScaleSerializer"/> class is to provide a <see cref="OrdinalScale"/> specific serializer
    /// </summary>
    public class OrdinalScaleSerializer : IThingSerializer
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
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "isMaximumInclusive", isMaximumInclusive => new JValue(isMaximumInclusive) },
            { "isMinimumInclusive", isMinimumInclusive => new JValue(isMinimumInclusive) },
            { "mappingToReferenceScale", mappingToReferenceScale => new JArray(mappingToReferenceScale) },
            { "maximumPermissibleValue", maximumPermissibleValue => new JValue(maximumPermissibleValue) },
            { "minimumPermissibleValue", minimumPermissibleValue => new JValue(minimumPermissibleValue) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "negativeValueConnotation", negativeValueConnotation => new JValue(negativeValueConnotation) },
            { "numberSet", numberSet => new JValue(numberSet.ToString()) },
            { "positiveValueConnotation", positiveValueConnotation => new JValue(positiveValueConnotation) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "unit", unit => new JValue(unit) },
            { "useShortNameValues", useShortNameValues => new JValue(useShortNameValues) },
            { "valueDefinition", valueDefinition => new JArray(valueDefinition) },
        };

        /// <summary>
        /// Serialize the <see cref="OrdinalScale"/>
        /// </summary>
        /// <param name="ordinalScale">The <see cref="OrdinalScale"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(OrdinalScale ordinalScale)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](ordinalScale.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), ordinalScale.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](ordinalScale.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](ordinalScale.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](ordinalScale.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](ordinalScale.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](ordinalScale.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](ordinalScale.IsDeprecated));
            jsonObject.Add("isMaximumInclusive", this.PropertySerializerMap["isMaximumInclusive"](ordinalScale.IsMaximumInclusive));
            jsonObject.Add("isMinimumInclusive", this.PropertySerializerMap["isMinimumInclusive"](ordinalScale.IsMinimumInclusive));
            jsonObject.Add("mappingToReferenceScale", this.PropertySerializerMap["mappingToReferenceScale"](ordinalScale.MappingToReferenceScale));
            jsonObject.Add("maximumPermissibleValue", this.PropertySerializerMap["maximumPermissibleValue"](ordinalScale.MaximumPermissibleValue));
            jsonObject.Add("minimumPermissibleValue", this.PropertySerializerMap["minimumPermissibleValue"](ordinalScale.MinimumPermissibleValue));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](ordinalScale.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](ordinalScale.Name));
            jsonObject.Add("negativeValueConnotation", this.PropertySerializerMap["negativeValueConnotation"](ordinalScale.NegativeValueConnotation));
            jsonObject.Add("numberSet", this.PropertySerializerMap["numberSet"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), ordinalScale.NumberSet)));
            jsonObject.Add("positiveValueConnotation", this.PropertySerializerMap["positiveValueConnotation"](ordinalScale.PositiveValueConnotation));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](ordinalScale.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](ordinalScale.ShortName));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](ordinalScale.Unit));
            jsonObject.Add("useShortNameValues", this.PropertySerializerMap["useShortNameValues"](ordinalScale.UseShortNameValues));
            jsonObject.Add("valueDefinition", this.PropertySerializerMap["valueDefinition"](ordinalScale.ValueDefinition));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="OrdinalScale"/> class.
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

            var ordinalScale = thing as OrdinalScale;
            if (ordinalScale == null)
            {
                throw new InvalidOperationException("The thing is not a OrdinalScale.");
            }

            return this.Serialize(ordinalScale);
        }
    }
}
