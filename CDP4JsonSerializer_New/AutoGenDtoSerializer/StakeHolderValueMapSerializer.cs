// --------------------------------------------------------------------------------------------------------------------
// <copyright file "StakeHolderValueMapSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="StakeHolderValueMapSerializer"/> class is to provide a <see cref="StakeHolderValueMap"/> specific serializer
    /// </summary>
    public class StakeHolderValueMapSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {            
            { "alias", alias => JsonValue.Create(alias) },
            { "category", category => JsonValue.Create(category) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "definition", definition => JsonValue.Create(definition) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "goal", goal => JsonValue.Create(goal) },
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            { "iid", iid => JsonValue.Create(iid) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "requirement", requirement => JsonValue.Create(requirement) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "settings", settings => JsonValue.Create(settings) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "stakeholderValue", stakeholderValue => JsonValue.Create(stakeholderValue) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "valueGroup", valueGroup => JsonValue.Create(valueGroup) },
        };

        /// <summary>
        /// Serialize the <see cref="StakeHolderValueMap"/>
        /// </summary>
        /// <param name="stakeHolderValueMap">The <see cref="StakeHolderValueMap"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(StakeHolderValueMap stakeHolderValueMap)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](stakeHolderValueMap.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](stakeHolderValueMap.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), stakeHolderValueMap.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](stakeHolderValueMap.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](stakeHolderValueMap.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](stakeHolderValueMap.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("goal", this.PropertySerializerMap["goal"](stakeHolderValueMap.Goal.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](stakeHolderValueMap.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](stakeHolderValueMap.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](stakeHolderValueMap.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](stakeHolderValueMap.Name));
            jsonObject.Add("requirement", this.PropertySerializerMap["requirement"](stakeHolderValueMap.Requirement.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](stakeHolderValueMap.RevisionNumber));
            jsonObject.Add("settings", this.PropertySerializerMap["settings"](stakeHolderValueMap.Settings));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](stakeHolderValueMap.ShortName));
            jsonObject.Add("stakeholderValue", this.PropertySerializerMap["stakeholderValue"](stakeHolderValueMap.StakeholderValue.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](stakeHolderValueMap.ThingPreference));
            jsonObject.Add("valueGroup", this.PropertySerializerMap["valueGroup"](stakeHolderValueMap.ValueGroup.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="StakeHolderValueMap"/> class.
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

            var stakeHolderValueMap = thing as StakeHolderValueMap;
            if (stakeHolderValueMap == null)
            {
                throw new InvalidOperationException("The thing is not a StakeHolderValueMap.");
            }

            return this.Serialize(stakeHolderValueMap);
        }
    }
}
