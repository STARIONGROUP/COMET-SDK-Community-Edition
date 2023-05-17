// --------------------------------------------------------------------------------------------------------------------
// <copyright file "StakeHolderValueMapSettingsSerializer.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Nodes;

    using CDP4Common.DTO;
    using CDP4Common.Types;
    
    /// <summary>
    /// The purpose of the <see cref="StakeHolderValueMapSettingsSerializer"/> class is to provide a <see cref="StakeHolderValueMapSettings"/> specific serializer
    /// </summary>
    public class StakeHolderValueMapSettingsSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "goalToValueGroupRelationship", goalToValueGroupRelationship => JsonValue.Create(goalToValueGroupRelationship) },
            { "iid", iid => JsonValue.Create(iid) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "stakeholderValueToRequirementRelationship", stakeholderValueToRequirementRelationship => JsonValue.Create(stakeholderValueToRequirementRelationship) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "valueGroupToStakeholderValueRelationship", valueGroupToStakeholderValueRelationship => JsonValue.Create(valueGroupToStakeholderValueRelationship) },
        };

        /// <summary>
        /// Serialize the <see cref="StakeHolderValueMapSettings"/>
        /// </summary>
        /// <param name="stakeHolderValueMapSettings">The <see cref="StakeHolderValueMapSettings"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(StakeHolderValueMapSettings stakeHolderValueMapSettings)
        {
            var jsonObject = new JsonObject
            {
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), stakeHolderValueMapSettings.ClassKind))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](stakeHolderValueMapSettings.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](stakeHolderValueMapSettings.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"goalToValueGroupRelationship", this.PropertySerializerMap["goalToValueGroupRelationship"](stakeHolderValueMapSettings.GoalToValueGroupRelationship)},
                {"iid", this.PropertySerializerMap["iid"](stakeHolderValueMapSettings.Iid)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](stakeHolderValueMapSettings.ModifiedOn)},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](stakeHolderValueMapSettings.RevisionNumber)},
                {"stakeholderValueToRequirementRelationship", this.PropertySerializerMap["stakeholderValueToRequirementRelationship"](stakeHolderValueMapSettings.StakeholderValueToRequirementRelationship)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](stakeHolderValueMapSettings.ThingPreference)},
                {"valueGroupToStakeholderValueRelationship", this.PropertySerializerMap["valueGroupToStakeholderValueRelationship"](stakeHolderValueMapSettings.ValueGroupToStakeholderValueRelationship)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="StakeHolderValueMapSettings"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JsonValue>> PropertySerializerMap => this.propertySerializerMap;

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

            if (thing is not StakeHolderValueMapSettings stakeHolderValueMapSettings)
            {
                throw new InvalidOperationException("The thing is not a StakeHolderValueMapSettings.");
            }

            return this.Serialize(stakeHolderValueMapSettings);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
