// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSetSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
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
    /// The purpose of the <see cref="ParameterSubscriptionValueSetSerializer"/> class is to provide a <see cref="ParameterSubscriptionValueSet"/> specific serializer
    /// </summary>
    public class ParameterSubscriptionValueSetSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "manual", manual => new JValue(((ValueArray<string>)manual).ToJsonString()) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "subscribedValueSet", subscribedValueSet => new JValue(subscribedValueSet) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "valueSwitch", valueSwitch => new JValue(valueSwitch.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterSubscriptionValueSet"/>
        /// </summary>
        /// <param name="parameterSubscriptionValueSet">The <see cref="ParameterSubscriptionValueSet"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterSubscriptionValueSet parameterSubscriptionValueSet)
        {
            var jsonObject = new JObject();
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
