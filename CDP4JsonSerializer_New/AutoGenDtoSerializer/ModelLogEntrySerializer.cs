// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ModelLogEntrySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ModelLogEntrySerializer"/> class is to provide a <see cref="ModelLogEntry"/> specific serializer
    /// </summary>
    public class ModelLogEntrySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {            
            { "affectedDomainIid", affectedDomainIid => JsonValue.Create(affectedDomainIid) },
            { "affectedItemIid", affectedItemIid => JsonValue.Create(affectedItemIid) },
            { "author", author => JsonValue.Create(author) },
            { "category", category => JsonValue.Create(category) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "content", content => JsonValue.Create(content) },
            { "createdOn", createdOn => JsonValue.Create(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "iid", iid => JsonValue.Create(iid) },
            { "languageCode", languageCode => JsonValue.Create(languageCode) },
            { "level", level => JsonValue.Create(level.ToString()) },
            { "logEntryChangelogItem", logEntryChangelogItem => JsonValue.Create(logEntryChangelogItem) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ModelLogEntry"/>
        /// </summary>
        /// <param name="modelLogEntry">The <see cref="ModelLogEntry"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ModelLogEntry modelLogEntry)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("affectedDomainIid", this.PropertySerializerMap["affectedDomainIid"](modelLogEntry.AffectedDomainIid.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("affectedItemIid", this.PropertySerializerMap["affectedItemIid"](modelLogEntry.AffectedItemIid.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("author", this.PropertySerializerMap["author"](modelLogEntry.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](modelLogEntry.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), modelLogEntry.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](modelLogEntry.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](modelLogEntry.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](modelLogEntry.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](modelLogEntry.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](modelLogEntry.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](modelLogEntry.LanguageCode));
            jsonObject.Add("level", this.PropertySerializerMap["level"](Enum.GetName(typeof(CDP4Common.CommonData.LogLevelKind), modelLogEntry.Level)));
            jsonObject.Add("logEntryChangelogItem", this.PropertySerializerMap["logEntryChangelogItem"](modelLogEntry.LogEntryChangelogItem.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](modelLogEntry.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](modelLogEntry.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](modelLogEntry.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ModelLogEntry"/> class.
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

            var modelLogEntry = thing as ModelLogEntry;
            if (modelLogEntry == null)
            {
                throw new InvalidOperationException("The thing is not a ModelLogEntry.");
            }

            return this.Serialize(modelLogEntry);
        }
    }
}
