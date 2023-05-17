// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteLogEntrySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteLogEntrySerializer"/> class is to provide a <see cref="SiteLogEntry"/> specific serializer
    /// </summary>
    public class SiteLogEntrySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
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
        /// Serialize the <see cref="SiteLogEntry"/>
        /// </summary>
        /// <param name="siteLogEntry">The <see cref="SiteLogEntry"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(SiteLogEntry siteLogEntry)
        {
            var jsonObject = new JsonObject
            {
                {"affectedDomainIid", this.PropertySerializerMap["affectedDomainIid"](siteLogEntry.AffectedDomainIid.OrderBy(x => x, this.guidComparer))},
                {"affectedItemIid", this.PropertySerializerMap["affectedItemIid"](siteLogEntry.AffectedItemIid.OrderBy(x => x, this.guidComparer))},
                {"author", this.PropertySerializerMap["author"](siteLogEntry.Author)},
                {"category", this.PropertySerializerMap["category"](siteLogEntry.Category.OrderBy(x => x, this.guidComparer))},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteLogEntry.ClassKind))},
                {"content", this.PropertySerializerMap["content"](siteLogEntry.Content)},
                {"createdOn", this.PropertySerializerMap["createdOn"](siteLogEntry.CreatedOn)},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](siteLogEntry.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](siteLogEntry.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](siteLogEntry.Iid)},
                {"languageCode", this.PropertySerializerMap["languageCode"](siteLogEntry.LanguageCode)},
                {"level", this.PropertySerializerMap["level"](Enum.GetName(typeof(CDP4Common.CommonData.LogLevelKind), siteLogEntry.Level))},
                {"logEntryChangelogItem", this.PropertySerializerMap["logEntryChangelogItem"](siteLogEntry.LogEntryChangelogItem.OrderBy(x => x, this.guidComparer))},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](siteLogEntry.ModifiedOn)},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](siteLogEntry.RevisionNumber)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](siteLogEntry.ThingPreference)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteLogEntry"/> class.
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

            if (thing is not SiteLogEntry siteLogEntry)
            {
                throw new InvalidOperationException("The thing is not a SiteLogEntry.");
            }

            return this.Serialize(siteLogEntry);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
