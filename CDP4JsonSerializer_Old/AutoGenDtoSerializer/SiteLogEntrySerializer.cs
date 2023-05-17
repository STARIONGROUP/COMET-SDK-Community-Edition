// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteLogEntrySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteLogEntrySerializer"/> class is to provide a <see cref="SiteLogEntry"/> specific serializer
    /// </summary>
    public class SiteLogEntrySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "affectedDomainIid", affectedDomainIid => new JArray(affectedDomainIid) },
            { "affectedItemIid", affectedItemIid => new JArray(affectedItemIid) },
            { "author", author => new JValue(author) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "level", level => new JValue(level.ToString()) },
            { "logEntryChangelogItem", logEntryChangelogItem => new JArray(logEntryChangelogItem) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="SiteLogEntry"/>
        /// </summary>
        /// <param name="siteLogEntry">The <see cref="SiteLogEntry"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SiteLogEntry siteLogEntry)
        {
            var jsonObject = new JObject();
            jsonObject.Add("affectedDomainIid", this.PropertySerializerMap["affectedDomainIid"](siteLogEntry.AffectedDomainIid.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("affectedItemIid", this.PropertySerializerMap["affectedItemIid"](siteLogEntry.AffectedItemIid.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("author", this.PropertySerializerMap["author"](siteLogEntry.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](siteLogEntry.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteLogEntry.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](siteLogEntry.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](siteLogEntry.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteLogEntry.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteLogEntry.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteLogEntry.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](siteLogEntry.LanguageCode));
            jsonObject.Add("level", this.PropertySerializerMap["level"](Enum.GetName(typeof(CDP4Common.CommonData.LogLevelKind), siteLogEntry.Level)));
            jsonObject.Add("logEntryChangelogItem", this.PropertySerializerMap["logEntryChangelogItem"](siteLogEntry.LogEntryChangelogItem.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteLogEntry.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteLogEntry.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](siteLogEntry.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteLogEntry"/> class.
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

            var siteLogEntry = thing as SiteLogEntry;
            if (siteLogEntry == null)
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
