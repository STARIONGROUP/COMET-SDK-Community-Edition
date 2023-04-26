// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ActualFiniteStateListSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActualFiniteStateListSerializer"/> class is to provide a <see cref="ActualFiniteStateList"/> specific serializer
    /// </summary>
    public class ActualFiniteStateListSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "actualState", actualState => JsonValue.Create(actualState) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "excludeOption", excludeOption => JsonValue.Create(excludeOption) },
            { "iid", iid => JsonValue.Create(iid) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => JsonValue.Create(owner) },
            { "possibleFiniteStateList", possibleFiniteStateList => JsonValue.Create(((IEnumerable)possibleFiniteStateList).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ActualFiniteStateList"/>
        /// </summary>
        /// <param name="actualFiniteStateList">The <see cref="ActualFiniteStateList"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ActualFiniteStateList actualFiniteStateList)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("actualState", this.PropertySerializerMap["actualState"](actualFiniteStateList.ActualState.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), actualFiniteStateList.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](actualFiniteStateList.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](actualFiniteStateList.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludeOption", this.PropertySerializerMap["excludeOption"](actualFiniteStateList.ExcludeOption.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](actualFiniteStateList.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](actualFiniteStateList.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](actualFiniteStateList.Owner));
            jsonObject.Add("possibleFiniteStateList", this.PropertySerializerMap["possibleFiniteStateList"](actualFiniteStateList.PossibleFiniteStateList.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](actualFiniteStateList.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](actualFiniteStateList.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ActualFiniteStateList"/> class.
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

            var actualFiniteStateList = thing as ActualFiniteStateList;
            if (actualFiniteStateList == null)
            {
                throw new InvalidOperationException("The thing is not a ActualFiniteStateList.");
            }

            return this.Serialize(actualFiniteStateList);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
