// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParticipantPermissionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParticipantPermissionSerializer"/> class is to provide a <see cref="ParticipantPermission"/> specific serializer
    /// </summary>
    public class ParticipantPermissionSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            
            
            
            
            { "accessRight", accessRight => JsonValue.Create(accessRight.ToString()) },
            
            
            
            
            
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            
            
            
            
            
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            
            
            
            
            
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            
            
            
            
            
            { "iid", iid => JsonValue.Create(iid) },
            
            
            
            
            
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            
            
            
            
            
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            
            
            
            
            
            { "objectClass", objectClass => JsonValue.Create(objectClass.ToString()) },
            
            
            
            
            
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            
            
            
            
            
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            
            
        };

        /// <summary>
        /// Serialize the <see cref="ParticipantPermission"/>
        /// </summary>
        /// <param name="participantPermission">The <see cref="ParticipantPermission"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ParticipantPermission participantPermission)
        {
            var jsonObject = new JsonObject
            {
                {"accessRight", this.PropertySerializerMap["accessRight"](Enum.GetName(typeof(CDP4Common.CommonData.ParticipantAccessRightKind), participantPermission.AccessRight))},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), participantPermission.ClassKind))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](participantPermission.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](participantPermission.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](participantPermission.Iid)},
                {"isDeprecated", this.PropertySerializerMap["isDeprecated"](participantPermission.IsDeprecated)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](participantPermission.ModifiedOn)},
                {"objectClass", this.PropertySerializerMap["objectClass"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), participantPermission.ObjectClass))},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](participantPermission.RevisionNumber)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](participantPermission.ThingPreference)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParticipantPermission"/> class.
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

            if (thing is not ParticipantPermission participantPermission)
            {
                throw new InvalidOperationException("The thing is not a ParticipantPermission.");
            }

            return this.Serialize(participantPermission);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
