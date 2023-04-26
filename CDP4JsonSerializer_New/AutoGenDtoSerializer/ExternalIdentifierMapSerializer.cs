// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ExternalIdentifierMapSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ExternalIdentifierMapSerializer"/> class is to provide a <see cref="ExternalIdentifierMap"/> specific serializer
    /// </summary>
    public class ExternalIdentifierMapSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "correspondence", correspondence => JsonValue.Create(correspondence) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "externalFormat", externalFormat => JsonValue.Create(externalFormat) },
            { "externalModelName", externalModelName => JsonValue.Create(externalModelName) },
            { "externalToolName", externalToolName => JsonValue.Create(externalToolName) },
            { "externalToolVersion", externalToolVersion => JsonValue.Create(externalToolVersion) },
            { "iid", iid => JsonValue.Create(iid) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "owner", owner => JsonValue.Create(owner) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ExternalIdentifierMap"/>
        /// </summary>
        /// <param name="externalIdentifierMap">The <see cref="ExternalIdentifierMap"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ExternalIdentifierMap externalIdentifierMap)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), externalIdentifierMap.ClassKind)));
            jsonObject.Add("correspondence", this.PropertySerializerMap["correspondence"](externalIdentifierMap.Correspondence.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](externalIdentifierMap.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](externalIdentifierMap.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("externalFormat", this.PropertySerializerMap["externalFormat"](externalIdentifierMap.ExternalFormat));
            jsonObject.Add("externalModelName", this.PropertySerializerMap["externalModelName"](externalIdentifierMap.ExternalModelName));
            jsonObject.Add("externalToolName", this.PropertySerializerMap["externalToolName"](externalIdentifierMap.ExternalToolName));
            jsonObject.Add("externalToolVersion", this.PropertySerializerMap["externalToolVersion"](externalIdentifierMap.ExternalToolVersion));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](externalIdentifierMap.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](externalIdentifierMap.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](externalIdentifierMap.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](externalIdentifierMap.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](externalIdentifierMap.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](externalIdentifierMap.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ExternalIdentifierMap"/> class.
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

            var externalIdentifierMap = thing as ExternalIdentifierMap;
            if (externalIdentifierMap == null)
            {
                throw new InvalidOperationException("The thing is not a ExternalIdentifierMap.");
            }

            return this.Serialize(externalIdentifierMap);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
