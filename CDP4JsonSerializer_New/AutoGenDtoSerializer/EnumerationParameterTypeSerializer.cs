// --------------------------------------------------------------------------------------------------------------------
// <copyright file "EnumerationParameterTypeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EnumerationParameterTypeSerializer"/> class is to provide a <see cref="EnumerationParameterType"/> specific serializer
    /// </summary>
    public class EnumerationParameterTypeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {            
            { "alias", alias => JsonValue.Create(alias) },
            { "allowMultiSelect", allowMultiSelect => JsonValue.Create(allowMultiSelect) },
            { "category", category => JsonValue.Create(category) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "definition", definition => JsonValue.Create(definition) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            { "iid", iid => JsonValue.Create(iid) },
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "symbol", symbol => JsonValue.Create(symbol) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "valueDefinition", valueDefinition => JsonValue.Create(((IEnumerable)valueDefinition).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
        };

        /// <summary>
        /// Serialize the <see cref="EnumerationParameterType"/>
        /// </summary>
        /// <param name="enumerationParameterType">The <see cref="EnumerationParameterType"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(EnumerationParameterType enumerationParameterType)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](enumerationParameterType.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("allowMultiSelect", this.PropertySerializerMap["allowMultiSelect"](enumerationParameterType.AllowMultiSelect));
            jsonObject.Add("category", this.PropertySerializerMap["category"](enumerationParameterType.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), enumerationParameterType.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](enumerationParameterType.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](enumerationParameterType.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](enumerationParameterType.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](enumerationParameterType.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](enumerationParameterType.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](enumerationParameterType.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](enumerationParameterType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](enumerationParameterType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](enumerationParameterType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](enumerationParameterType.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](enumerationParameterType.Symbol));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](enumerationParameterType.ThingPreference));
            jsonObject.Add("valueDefinition", this.PropertySerializerMap["valueDefinition"](enumerationParameterType.ValueDefinition.OrderBy(x => x, this.orderedItemComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="EnumerationParameterType"/> class.
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

            var enumerationParameterType = thing as EnumerationParameterType;
            if (enumerationParameterType == null)
            {
                throw new InvalidOperationException("The thing is not a EnumerationParameterType.");
            }

            return this.Serialize(enumerationParameterType);
        }
    }
}
