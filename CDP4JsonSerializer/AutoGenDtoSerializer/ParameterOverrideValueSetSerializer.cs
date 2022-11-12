// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterOverrideValueSetSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterOverrideValueSetSerializer"/> class is to provide a <see cref="ParameterOverrideValueSet"/> specific serializer
    /// </summary>
    public class ParameterOverrideValueSetSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "computed", computed => new JValue(((ValueArray<string>)computed).ToJsonString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "formula", formula => new JValue(((ValueArray<string>)formula).ToJsonString()) },
            { "iid", iid => new JValue(iid) },
            { "manual", manual => new JValue(((ValueArray<string>)manual).ToJsonString()) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "parameterValueSet", parameterValueSet => new JValue(parameterValueSet) },
            { "published", published => new JValue(((ValueArray<string>)published).ToJsonString()) },
            { "reference", reference => new JValue(((ValueArray<string>)reference).ToJsonString()) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "valueSwitch", valueSwitch => new JValue(valueSwitch.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterOverrideValueSet"/>
        /// </summary>
        /// <param name="parameterOverrideValueSet">The <see cref="ParameterOverrideValueSet"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterOverrideValueSet parameterOverrideValueSet)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterOverrideValueSet.ClassKind)));
            jsonObject.Add("computed", this.PropertySerializerMap["computed"](parameterOverrideValueSet.Computed));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterOverrideValueSet.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterOverrideValueSet.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("formula", this.PropertySerializerMap["formula"](parameterOverrideValueSet.Formula));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterOverrideValueSet.Iid));
            jsonObject.Add("manual", this.PropertySerializerMap["manual"](parameterOverrideValueSet.Manual));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterOverrideValueSet.ModifiedOn));
            jsonObject.Add("parameterValueSet", this.PropertySerializerMap["parameterValueSet"](parameterOverrideValueSet.ParameterValueSet));
            jsonObject.Add("published", this.PropertySerializerMap["published"](parameterOverrideValueSet.Published));
            jsonObject.Add("reference", this.PropertySerializerMap["reference"](parameterOverrideValueSet.Reference));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterOverrideValueSet.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](parameterOverrideValueSet.ThingPreference));
            jsonObject.Add("valueSwitch", this.PropertySerializerMap["valueSwitch"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.ParameterSwitchKind), parameterOverrideValueSet.ValueSwitch)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterOverrideValueSet"/> class.
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

            var parameterOverrideValueSet = thing as ParameterOverrideValueSet;
            if (parameterOverrideValueSet == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterOverrideValueSet.");
            }

            return this.Serialize(parameterOverrideValueSet);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
