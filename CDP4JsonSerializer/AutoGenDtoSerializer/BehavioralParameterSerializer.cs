// --------------------------------------------------------------------------------------------------------------------
// <copyright file "BehavioralParameterSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BehavioralParameterSerializer"/> class is to provide a <see cref="BehavioralParameter"/> specific serializer
    /// </summary>
    public class BehavioralParameterSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "behavioralParameterKind", behavioralParameterKind => new JValue(behavioralParameterKind.ToString()) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "parameter", parameter => new JValue(parameter) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "variableName", variableName => new JValue(variableName) },
        };

        /// <summary>
        /// Serialize the <see cref="BehavioralParameter"/>
        /// </summary>
        /// <param name="behavioralParameter">The <see cref="BehavioralParameter"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(BehavioralParameter behavioralParameter)
        {
            var jsonObject = new JObject();
            jsonObject.Add("behavioralParameterKind", this.PropertySerializerMap["behavioralParameterKind"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.BehavioralParameterKind), behavioralParameter.BehavioralParameterKind)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), behavioralParameter.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](behavioralParameter.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](behavioralParameter.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](behavioralParameter.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](behavioralParameter.ModifiedOn));
            jsonObject.Add("parameter", this.PropertySerializerMap["parameter"](behavioralParameter.Parameter));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](behavioralParameter.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](behavioralParameter.ThingPreference));
            jsonObject.Add("variableName", this.PropertySerializerMap["variableName"](behavioralParameter.VariableName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="BehavioralParameter"/> class.
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

            var behavioralParameter = thing as BehavioralParameter;
            if (behavioralParameter == null)
            {
                throw new InvalidOperationException("The thing is not a BehavioralParameter.");
            }

            return this.Serialize(behavioralParameter);
        }
    }
}