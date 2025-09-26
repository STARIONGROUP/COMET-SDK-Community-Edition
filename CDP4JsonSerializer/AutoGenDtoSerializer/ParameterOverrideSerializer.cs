// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideSerializer.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ParameterOverrideSerializer"/> class is to provide a <see cref="ParameterOverride"/> specific serializer
    /// </summary>
    public class ParameterOverrideSerializer : BaseThingSerializer, IThingSerializer
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
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => new JValue(owner) },
            { "parameter", parameter => new JValue(parameter) },
            { "parameterSubscription", parameterSubscription => new JArray(parameterSubscription) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "valueSet", valueSet => new JArray(valueSet) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterOverride"/>
        /// </summary>
        /// <param name="parameterOverride">The <see cref="ParameterOverride"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterOverride parameterOverride)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterOverride.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterOverride.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterOverride.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterOverride.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterOverride.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](parameterOverride.Owner));
            jsonObject.Add("parameter", this.PropertySerializerMap["parameter"](parameterOverride.Parameter));
            jsonObject.Add("parameterSubscription", this.PropertySerializerMap["parameterSubscription"](parameterOverride.ParameterSubscription.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterOverride.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](parameterOverride.ThingPreference));
            jsonObject.Add("valueSet", this.PropertySerializerMap["valueSet"](parameterOverride.ValueSet.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterOverride"/> class.
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

            var parameterOverride = thing as ParameterOverride;
            if (parameterOverride == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterOverride.");
            }

            return this.Serialize(parameterOverride);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
