// --------------------------------------------------------------------------------------------------------------------
// <copyright file "CyclicRatioScaleSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
//
//    This file is part of CDP4-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
    /// The purpose of the <see cref="CyclicRatioScaleSerializer"/> class is to provide a <see cref="CyclicRatioScale"/> specific serializer
    /// </summary>
    public class CyclicRatioScaleSerializer : BaseThingSerializer, IThingSerializer
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
            { "modulus", modulus => new JValue(modulus) },
            { "name", name => new JValue(name) },
            { "negativeValueConnotation", negativeValueConnotation => new JValue(negativeValueConnotation) },
            { "numberSet", numberSet => new JValue(numberSet.ToString()) },
            { "positiveValueConnotation", positiveValueConnotation => new JValue(positiveValueConnotation) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "unit", unit => new JValue(unit) },
            { "valueDefinition", valueDefinition => new JArray(valueDefinition) },
        };

        /// <summary>
        /// Serialize the <see cref="CyclicRatioScale"/>
        /// </summary>
        /// <param name="cyclicRatioScale">The <see cref="CyclicRatioScale"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(CyclicRatioScale cyclicRatioScale)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](cyclicRatioScale.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), cyclicRatioScale.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](cyclicRatioScale.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](cyclicRatioScale.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](cyclicRatioScale.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](cyclicRatioScale.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](cyclicRatioScale.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](cyclicRatioScale.IsDeprecated));
            jsonObject.Add("isMaximumInclusive", this.PropertySerializerMap["isMaximumInclusive"](cyclicRatioScale.IsMaximumInclusive));
            jsonObject.Add("isMinimumInclusive", this.PropertySerializerMap["isMinimumInclusive"](cyclicRatioScale.IsMinimumInclusive));
            jsonObject.Add("mappingToReferenceScale", this.PropertySerializerMap["mappingToReferenceScale"](cyclicRatioScale.MappingToReferenceScale.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("maximumPermissibleValue", this.PropertySerializerMap["maximumPermissibleValue"](cyclicRatioScale.MaximumPermissibleValue));
            jsonObject.Add("minimumPermissibleValue", this.PropertySerializerMap["minimumPermissibleValue"](cyclicRatioScale.MinimumPermissibleValue));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](cyclicRatioScale.ModifiedOn));
            jsonObject.Add("modulus", this.PropertySerializerMap["modulus"](cyclicRatioScale.Modulus));
            jsonObject.Add("name", this.PropertySerializerMap["name"](cyclicRatioScale.Name));
            jsonObject.Add("negativeValueConnotation", this.PropertySerializerMap["negativeValueConnotation"](cyclicRatioScale.NegativeValueConnotation));
            jsonObject.Add("numberSet", this.PropertySerializerMap["numberSet"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), cyclicRatioScale.NumberSet)));
            jsonObject.Add("positiveValueConnotation", this.PropertySerializerMap["positiveValueConnotation"](cyclicRatioScale.PositiveValueConnotation));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](cyclicRatioScale.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](cyclicRatioScale.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](cyclicRatioScale.ThingPreference));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](cyclicRatioScale.Unit));
            jsonObject.Add("valueDefinition", this.PropertySerializerMap["valueDefinition"](cyclicRatioScale.ValueDefinition.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="CyclicRatioScale"/> class.
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
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
            }

            var cyclicRatioScale = thing as CyclicRatioScale;
            if (cyclicRatioScale == null)
            {
                throw new InvalidOperationException("The thing is not a CyclicRatioScale.");
            }

            return this.Serialize(cyclicRatioScale);
        }
    }
}
