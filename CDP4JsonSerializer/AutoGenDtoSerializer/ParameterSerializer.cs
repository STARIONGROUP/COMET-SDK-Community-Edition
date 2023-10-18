// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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
    /// The purpose of the <see cref="ParameterSerializer"/> class is to provide a <see cref="Parameter"/> specific serializer
    /// </summary>
    public class ParameterSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "allowDifferentOwnerOfOverride", allowDifferentOwnerOfOverride => new JValue(allowDifferentOwnerOfOverride) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "expectsOverride", expectsOverride => new JValue(expectsOverride) },
            { "group", group => new JValue(group) },
            { "iid", iid => new JValue(iid) },
            { "isOptionDependent", isOptionDependent => new JValue(isOptionDependent) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => new JValue(owner) },
            { "parameterSubscription", parameterSubscription => new JArray(parameterSubscription) },
            { "parameterType", parameterType => new JValue(parameterType) },
            { "requestedBy", requestedBy => new JValue(requestedBy) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "scale", scale => new JValue(scale) },
            { "stateDependence", stateDependence => new JValue(stateDependence) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "valueSet", valueSet => new JArray(valueSet) },
        };

        /// <summary>
        /// Serialize the <see cref="Parameter"/>
        /// </summary>
        /// <param name="parameter">The <see cref="Parameter"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Parameter parameter)
        {
            var jsonObject = new JObject();
            jsonObject.Add("allowDifferentOwnerOfOverride", this.PropertySerializerMap["allowDifferentOwnerOfOverride"](parameter.AllowDifferentOwnerOfOverride));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameter.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameter.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameter.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("expectsOverride", this.PropertySerializerMap["expectsOverride"](parameter.ExpectsOverride));
            jsonObject.Add("group", this.PropertySerializerMap["group"](parameter.Group));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameter.Iid));
            jsonObject.Add("isOptionDependent", this.PropertySerializerMap["isOptionDependent"](parameter.IsOptionDependent));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameter.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](parameter.Owner));
            jsonObject.Add("parameterSubscription", this.PropertySerializerMap["parameterSubscription"](parameter.ParameterSubscription.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](parameter.ParameterType));
            jsonObject.Add("requestedBy", this.PropertySerializerMap["requestedBy"](parameter.RequestedBy));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameter.RevisionNumber));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](parameter.Scale));
            jsonObject.Add("stateDependence", this.PropertySerializerMap["stateDependence"](parameter.StateDependence));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](parameter.ThingPreference));
            jsonObject.Add("valueSet", this.PropertySerializerMap["valueSet"](parameter.ValueSet.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Parameter"/> class.
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

            var parameter = thing as Parameter;
            if (parameter == null)
            {
                throw new InvalidOperationException("The thing is not a Parameter.");
            }

            return this.Serialize(parameter);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
