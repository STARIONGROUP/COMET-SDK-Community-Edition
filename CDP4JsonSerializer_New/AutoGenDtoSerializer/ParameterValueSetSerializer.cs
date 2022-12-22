// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterValueSetSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterValueSetSerializer"/> class is to provide a <see cref="ParameterValueSet"/> specific serializer
    /// </summary>
    public class ParameterValueSetSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "actualOption", actualOption => JsonValue.Create(actualOption) },
            { "actualState", actualState => JsonValue.Create(actualState) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "computed", computed => JsonValue.Create(((ValueArray<string>)computed).ToJsonString()) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "formula", formula => JsonValue.Create(((ValueArray<string>)formula).ToJsonString()) },
            { "iid", iid => JsonValue.Create(iid) },
            { "manual", manual => JsonValue.Create(((ValueArray<string>)manual).ToJsonString()) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "published", published => JsonValue.Create(((ValueArray<string>)published).ToJsonString()) },
            { "reference", reference => JsonValue.Create(((ValueArray<string>)reference).ToJsonString()) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "valueSwitch", valueSwitch => JsonValue.Create(valueSwitch.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterValueSet"/>
        /// </summary>
        /// <param name="parameterValueSet">The <see cref="ParameterValueSet"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ParameterValueSet parameterValueSet)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("actualOption", this.PropertySerializerMap["actualOption"](parameterValueSet.ActualOption));
            jsonObject.Add("actualState", this.PropertySerializerMap["actualState"](parameterValueSet.ActualState));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterValueSet.ClassKind)));
            jsonObject.Add("computed", this.PropertySerializerMap["computed"](parameterValueSet.Computed));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterValueSet.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterValueSet.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("formula", this.PropertySerializerMap["formula"](parameterValueSet.Formula));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterValueSet.Iid));
            jsonObject.Add("manual", this.PropertySerializerMap["manual"](parameterValueSet.Manual));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterValueSet.ModifiedOn));
            jsonObject.Add("published", this.PropertySerializerMap["published"](parameterValueSet.Published));
            jsonObject.Add("reference", this.PropertySerializerMap["reference"](parameterValueSet.Reference));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterValueSet.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](parameterValueSet.ThingPreference));
            jsonObject.Add("valueSwitch", this.PropertySerializerMap["valueSwitch"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.ParameterSwitchKind), parameterValueSet.ValueSwitch)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterValueSet"/> class.
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

            var parameterValueSet = thing as ParameterValueSet;
            if (parameterValueSet == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterValueSet.");
            }

            return this.Serialize(parameterValueSet);
        }
    }
}
