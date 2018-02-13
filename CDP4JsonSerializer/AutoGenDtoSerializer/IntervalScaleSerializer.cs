#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntervalScaleSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
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
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

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
    /// The purpose of the <see cref="IntervalScaleSerializer"/> class is to provide a <see cref="IntervalScale"/> specific serializer
    /// </summary>
    public class IntervalScaleSerializer : IThingSerializer
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
        /// Serialize the <see cref="IntervalScale"/>
        /// </summary>
        /// <param name="intervalScale">The <see cref="IntervalScale"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(IntervalScale intervalScale)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](intervalScale.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), intervalScale.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](intervalScale.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](intervalScale.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](intervalScale.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](intervalScale.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](intervalScale.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](intervalScale.IsDeprecated));
            jsonObject.Add("isMaximumInclusive", this.PropertySerializerMap["isMaximumInclusive"](intervalScale.IsMaximumInclusive));
            jsonObject.Add("isMinimumInclusive", this.PropertySerializerMap["isMinimumInclusive"](intervalScale.IsMinimumInclusive));
            jsonObject.Add("mappingToReferenceScale", this.PropertySerializerMap["mappingToReferenceScale"](intervalScale.MappingToReferenceScale));
            jsonObject.Add("maximumPermissibleValue", this.PropertySerializerMap["maximumPermissibleValue"](intervalScale.MaximumPermissibleValue));
            jsonObject.Add("minimumPermissibleValue", this.PropertySerializerMap["minimumPermissibleValue"](intervalScale.MinimumPermissibleValue));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](intervalScale.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](intervalScale.Name));
            jsonObject.Add("negativeValueConnotation", this.PropertySerializerMap["negativeValueConnotation"](intervalScale.NegativeValueConnotation));
            jsonObject.Add("numberSet", this.PropertySerializerMap["numberSet"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.NumberSetKind), intervalScale.NumberSet)));
            jsonObject.Add("positiveValueConnotation", this.PropertySerializerMap["positiveValueConnotation"](intervalScale.PositiveValueConnotation));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](intervalScale.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](intervalScale.ShortName));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](intervalScale.Unit));
            jsonObject.Add("valueDefinition", this.PropertySerializerMap["valueDefinition"](intervalScale.ValueDefinition));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="IntervalScale"/> class.
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

            var intervalScale = thing as IntervalScale;
            if (intervalScale == null)
            {
                throw new InvalidOperationException("The thing is not a IntervalScale.");
            }

            return this.Serialize(intervalScale);
        }
    }
}
