// --------------------------------------------------------------------------------------------------------------------
// <copyright file "NestedParameterSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NestedParameterSerializer"/> class is to provide a <see cref="NestedParameter"/> specific serializer
    /// </summary>
    public class NestedParameterSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {            
            { "actualState", actualState => JsonValue.Create(actualState) },
            { "actualValue", actualValue => JsonValue.Create(actualValue) },
            { "associatedParameter", associatedParameter => JsonValue.Create(associatedParameter) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "formula", formula => JsonValue.Create(formula) },
            { "iid", iid => JsonValue.Create(iid) },
            { "isVolatile", isVolatile => JsonValue.Create(isVolatile) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => JsonValue.Create(owner) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="NestedParameter"/>
        /// </summary>
        /// <param name="nestedParameter">The <see cref="NestedParameter"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(NestedParameter nestedParameter)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("actualState", this.PropertySerializerMap["actualState"](nestedParameter.ActualState));
            jsonObject.Add("actualValue", this.PropertySerializerMap["actualValue"](nestedParameter.ActualValue));
            jsonObject.Add("associatedParameter", this.PropertySerializerMap["associatedParameter"](nestedParameter.AssociatedParameter));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), nestedParameter.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](nestedParameter.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](nestedParameter.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("formula", this.PropertySerializerMap["formula"](nestedParameter.Formula));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](nestedParameter.Iid));
            jsonObject.Add("isVolatile", this.PropertySerializerMap["isVolatile"](nestedParameter.IsVolatile));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](nestedParameter.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](nestedParameter.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](nestedParameter.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](nestedParameter.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="NestedParameter"/> class.
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

            var nestedParameter = thing as NestedParameter;
            if (nestedParameter == null)
            {
                throw new InvalidOperationException("The thing is not a NestedParameter.");
            }

            return this.Serialize(nestedParameter);
        }
    }
}
