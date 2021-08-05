// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SampledFunctionParameterTypeSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
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
    /// The purpose of the <see cref="SampledFunctionParameterTypeSerializer"/> class is to provide a <see cref="SampledFunctionParameterType"/> specific serializer
    /// </summary>
    public class SampledFunctionParameterTypeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "degreeOfInterpolation", degreeOfInterpolation => new JValue(degreeOfInterpolation) },
            { "dependentParameterType", dependentParameterType => new JArray(((IEnumerable)dependentParameterType).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "independentParameterType", independentParameterType => new JArray(((IEnumerable)independentParameterType).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "interpolationPeriod", interpolationPeriod => new JValue(((ValueArray<string>)interpolationPeriod).ToJsonString()) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "symbol", symbol => new JValue(symbol) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="SampledFunctionParameterType"/>
        /// </summary>
        /// <param name="sampledFunctionParameterType">The <see cref="SampledFunctionParameterType"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SampledFunctionParameterType sampledFunctionParameterType)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](sampledFunctionParameterType.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](sampledFunctionParameterType.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), sampledFunctionParameterType.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](sampledFunctionParameterType.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("degreeOfInterpolation", this.PropertySerializerMap["degreeOfInterpolation"](sampledFunctionParameterType.DegreeOfInterpolation));
            jsonObject.Add("dependentParameterType", this.PropertySerializerMap["dependentParameterType"](sampledFunctionParameterType.DependentParameterType.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](sampledFunctionParameterType.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](sampledFunctionParameterType.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](sampledFunctionParameterType.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](sampledFunctionParameterType.Iid));
            jsonObject.Add("independentParameterType", this.PropertySerializerMap["independentParameterType"](sampledFunctionParameterType.IndependentParameterType.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("interpolationPeriod", this.PropertySerializerMap["interpolationPeriod"](sampledFunctionParameterType.InterpolationPeriod));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](sampledFunctionParameterType.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](sampledFunctionParameterType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](sampledFunctionParameterType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](sampledFunctionParameterType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](sampledFunctionParameterType.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](sampledFunctionParameterType.Symbol));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](sampledFunctionParameterType.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SampledFunctionParameterType"/> class.
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

            var sampledFunctionParameterType = thing as SampledFunctionParameterType;
            if (sampledFunctionParameterType == null)
            {
                throw new InvalidOperationException("The thing is not a SampledFunctionParameterType.");
            }

            return this.Serialize(sampledFunctionParameterType);
        }
    }
}
