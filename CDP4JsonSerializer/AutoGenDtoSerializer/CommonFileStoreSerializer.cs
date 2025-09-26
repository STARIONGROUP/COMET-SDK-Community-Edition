// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFileStoreSerializer.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="CommonFileStoreSerializer"/> class is to provide a <see cref="CommonFileStore"/> specific serializer
    /// </summary>
    public class CommonFileStoreSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "file", file => new JArray(file) },
            { "folder", folder => new JArray(folder) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="CommonFileStore"/>
        /// </summary>
        /// <param name="commonFileStore">The <see cref="CommonFileStore"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(CommonFileStore commonFileStore)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), commonFileStore.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](commonFileStore.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](commonFileStore.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](commonFileStore.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("file", this.PropertySerializerMap["file"](commonFileStore.File.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("folder", this.PropertySerializerMap["folder"](commonFileStore.Folder.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](commonFileStore.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](commonFileStore.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](commonFileStore.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](commonFileStore.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](commonFileStore.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](commonFileStore.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="CommonFileStore"/> class.
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

            var commonFileStore = thing as CommonFileStore;
            if (commonFileStore == null)
            {
                throw new InvalidOperationException("The thing is not a CommonFileStore.");
            }

            return this.Serialize(commonFileStore);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
