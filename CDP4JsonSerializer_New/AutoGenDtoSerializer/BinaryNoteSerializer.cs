// --------------------------------------------------------------------------------------------------------------------
// <copyright file "BinaryNoteSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BinaryNoteSerializer"/> class is to provide a <see cref="BinaryNote"/> specific serializer
    /// </summary>
    public class BinaryNoteSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "caption", caption => JsonValue.Create(caption) },
            { "category", category => JsonValue.Create(category) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "createdOn", createdOn => JsonValue.Create(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "fileType", fileType => JsonValue.Create(fileType) },
            { "iid", iid => JsonValue.Create(iid) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "owner", owner => JsonValue.Create(owner) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="BinaryNote"/>
        /// </summary>
        /// <param name="binaryNote">The <see cref="BinaryNote"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(BinaryNote binaryNote)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("caption", this.PropertySerializerMap["caption"](binaryNote.Caption));
            jsonObject.Add("category", this.PropertySerializerMap["category"](binaryNote.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), binaryNote.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](binaryNote.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](binaryNote.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](binaryNote.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("fileType", this.PropertySerializerMap["fileType"](binaryNote.FileType));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](binaryNote.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](binaryNote.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](binaryNote.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](binaryNote.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](binaryNote.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](binaryNote.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](binaryNote.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="BinaryNote"/> class.
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

            var binaryNote = thing as BinaryNote;
            if (binaryNote == null)
            {
                throw new InvalidOperationException("The thing is not a BinaryNote.");
            }

            return this.Serialize(binaryNote);
        }
    }
}
