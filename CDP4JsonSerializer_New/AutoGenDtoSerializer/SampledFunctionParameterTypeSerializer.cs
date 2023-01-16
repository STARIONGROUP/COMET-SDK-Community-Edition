// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SampledFunctionParameterTypeSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski, Jaime Bernar
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Nodes;

    using CDP4Common.DTO;
    using CDP4Common.Types;
    
    /// <summary>
    /// The purpose of the <see cref="SampledFunctionParameterTypeSerializer"/> class is to provide a <see cref="SampledFunctionParameterType"/> specific serializer
    /// </summary>
    public class SampledFunctionParameterTypeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {            
            { "alias", alias => JsonValue.Create(alias) },
            { "category", category => JsonValue.Create(category) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "definition", definition => JsonValue.Create(definition) },
            { "degreeOfInterpolation", degreeOfInterpolation => JsonValue.Create(degreeOfInterpolation) },
            { "dependentParameterType", dependentParameterType => JsonValue.Create(((IEnumerable)dependentParameterType).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            { "iid", iid => JsonValue.Create(iid) },
            { "independentParameterType", independentParameterType => JsonValue.Create(((IEnumerable)independentParameterType).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "interpolationPeriod", interpolationPeriod => JsonValue.Create(((ValueArray<string>)interpolationPeriod).ToJsonString()) },
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "symbol", symbol => JsonValue.Create(symbol) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="SampledFunctionParameterType"/>
        /// </summary>
        /// <param name="sampledFunctionParameterType">The <see cref="SampledFunctionParameterType"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(SampledFunctionParameterType sampledFunctionParameterType)
        {
            var jsonObject = new JsonObject();
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
        public IReadOnlyDictionary<string, Func<object, JsonValue>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        public JsonObject Serialize(Thing thing)
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
