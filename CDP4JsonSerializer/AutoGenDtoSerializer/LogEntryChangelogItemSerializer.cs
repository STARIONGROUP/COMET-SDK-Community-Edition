// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEntryChangelogItemSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    /// The purpose of the <see cref="LogEntryChangelogItemSerializer"/> class is to provide a <see cref="LogEntryChangelogItem"/> specific serializer
    /// </summary>
    public class LogEntryChangelogItemSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "affectedItemIid", affectedItemIid => new JValue(affectedItemIid) },
            { "affectedReferenceIid", affectedReferenceIid => new JArray(affectedReferenceIid) },
            { "changeDescription", changeDescription => new JValue(changeDescription) },
            { "changelogKind", changelogKind => new JValue(changelogKind.ToString()) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="LogEntryChangelogItem"/>
        /// </summary>
        /// <param name="logEntryChangelogItem">The <see cref="LogEntryChangelogItem"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(LogEntryChangelogItem logEntryChangelogItem)
        {
            var jsonObject = new JObject();
            jsonObject.Add("affectedItemIid", this.PropertySerializerMap["affectedItemIid"](logEntryChangelogItem.AffectedItemIid));
            jsonObject.Add("affectedReferenceIid", this.PropertySerializerMap["affectedReferenceIid"](logEntryChangelogItem.AffectedReferenceIid.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("changeDescription", this.PropertySerializerMap["changeDescription"](logEntryChangelogItem.ChangeDescription));
            jsonObject.Add("changelogKind", this.PropertySerializerMap["changelogKind"](Enum.GetName(typeof(CDP4Common.CommonData.LogEntryChangelogItemKind), logEntryChangelogItem.ChangelogKind)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), logEntryChangelogItem.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](logEntryChangelogItem.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](logEntryChangelogItem.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](logEntryChangelogItem.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](logEntryChangelogItem.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](logEntryChangelogItem.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](logEntryChangelogItem.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="LogEntryChangelogItem"/> class.
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

            var logEntryChangelogItem = thing as LogEntryChangelogItem;
            if (logEntryChangelogItem == null)
            {
                throw new InvalidOperationException("The thing is not a LogEntryChangelogItem.");
            }

            return this.Serialize(logEntryChangelogItem);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
