// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterSubscriptionValueSetSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterSubscriptionValueSetSerializer"/> class is to provide a <see cref="ParameterSubscriptionValueSet"/> specific serializer
    /// </summary>
    public class ParameterSubscriptionValueSetSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "iid", iid => JsonValue.Create(iid) },
            { "manual", manual => JsonValue.Create(((ValueArray<string>)manual).ToJsonString()) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "subscribedValueSet", subscribedValueSet => JsonValue.Create(subscribedValueSet) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "valueSwitch", valueSwitch => JsonValue.Create(valueSwitch.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterSubscriptionValueSet"/>
        /// </summary>
        /// <param name="parameterSubscriptionValueSet">The <see cref="ParameterSubscriptionValueSet"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ParameterSubscriptionValueSet parameterSubscriptionValueSet)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterSubscriptionValueSet.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterSubscriptionValueSet.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterSubscriptionValueSet.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterSubscriptionValueSet.Iid));
            jsonObject.Add("manual", this.PropertySerializerMap["manual"](parameterSubscriptionValueSet.Manual));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterSubscriptionValueSet.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterSubscriptionValueSet.RevisionNumber));
            jsonObject.Add("subscribedValueSet", this.PropertySerializerMap["subscribedValueSet"](parameterSubscriptionValueSet.SubscribedValueSet));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](parameterSubscriptionValueSet.ThingPreference));
            jsonObject.Add("valueSwitch", this.PropertySerializerMap["valueSwitch"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.ParameterSwitchKind), parameterSubscriptionValueSet.ValueSwitch)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterSubscriptionValueSet"/> class.
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

            var parameterSubscriptionValueSet = thing as ParameterSubscriptionValueSet;
            if (parameterSubscriptionValueSet == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterSubscriptionValueSet.");
            }

            return this.Serialize(parameterSubscriptionValueSet);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
