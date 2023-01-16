// --------------------------------------------------------------------------------------------------------------------
// <copyright file "NestedElementSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NestedElementSerializer"/> class is to provide a <see cref="NestedElement"/> specific serializer
    /// </summary>
    public class NestedElementSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {            
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "elementUsage", elementUsage => JsonValue.Create(((IEnumerable)elementUsage).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "iid", iid => JsonValue.Create(iid) },
            { "isVolatile", isVolatile => JsonValue.Create(isVolatile) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "nestedParameter", nestedParameter => JsonValue.Create(nestedParameter) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "rootElement", rootElement => JsonValue.Create(rootElement) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="NestedElement"/>
        /// </summary>
        /// <param name="nestedElement">The <see cref="NestedElement"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(NestedElement nestedElement)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), nestedElement.ClassKind)));
            jsonObject.Add("elementUsage", this.PropertySerializerMap["elementUsage"](nestedElement.ElementUsage.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](nestedElement.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](nestedElement.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](nestedElement.Iid));
            jsonObject.Add("isVolatile", this.PropertySerializerMap["isVolatile"](nestedElement.IsVolatile));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](nestedElement.ModifiedOn));
            jsonObject.Add("nestedParameter", this.PropertySerializerMap["nestedParameter"](nestedElement.NestedParameter.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](nestedElement.RevisionNumber));
            jsonObject.Add("rootElement", this.PropertySerializerMap["rootElement"](nestedElement.RootElement));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](nestedElement.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="NestedElement"/> class.
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

            var nestedElement = thing as NestedElement;
            if (nestedElement == null)
            {
                throw new InvalidOperationException("The thing is not a NestedElement.");
            }

            return this.Serialize(nestedElement);
        }
    }
}
