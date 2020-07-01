// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RatioScaleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RatioScaleSerializer"/> class is to provide a <see cref="RatioScale"/> specific serializer
    /// </summary>
    public class RatioScaleSerializer : IThingSerializer
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
            { "valueDefinition", valueDefinition => new JArray(valueDefinition) },
        };

        /// <summary>
        /// Serialize the <see cref="RatioScale"/>
        /// </summary>
        /// <param name="ratioScale">The <see cref="RatioScale"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RatioScale ratioScale)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](ratioScale.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), ratioScale.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](ratioScale.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](ratioScale.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](ratioScale.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](ratioScale.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](ratioScale.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](ratioScale.IsDeprecated));
            jsonObject.Add("isMaximumInclusive", this.PropertySerializerMap["isMaximumInclusive"](ratioScale.IsMaximumInclusive));
            jsonObject.Add("isMinimumInclusive", this.PropertySerializerMap["isMinimumInclusive"](ratioScale.IsMinimumInclusive));
            jsonObject.Add("mappingToReferenceScale", this.PropertySerializerMap["mappingToReferenceScale"](ratioScale.MappingToReferenceScale));
            jsonObject.Add("maximumPermissibleValue", this.PropertySerializerMap["maximumPermissibleValue"](ratioScale.MaximumPermissibleValue));
            jsonObject.Add("minimumPermissibleValue", this.PropertySerializerMap["minimumPermissibleValue"](ratioScale.MinimumPermissibleValue));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](ratioScale.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](ratioScale.Name));
            jsonObject.Add("negativeValueConnotation", this.PropertySerializerMap["negativeValueConnotation"](ratioScale.NegativeValueConnotation));
            jsonObject.Add("numberSet", this.PropertySerializerMap["numberSet"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), ratioScale.NumberSet)));
            jsonObject.Add("positiveValueConnotation", this.PropertySerializerMap["positiveValueConnotation"](ratioScale.PositiveValueConnotation));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](ratioScale.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](ratioScale.ShortName));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](ratioScale.Unit));
            jsonObject.Add("valueDefinition", this.PropertySerializerMap["valueDefinition"](ratioScale.ValueDefinition));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RatioScale"/> class.
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

            var ratioScale = thing as RatioScale;
            if (ratioScale == null)
            {
                throw new InvalidOperationException("The thing is not a RatioScale.");
            }

            return this.Serialize(ratioScale);
        }
    }
}
