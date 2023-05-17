// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ExternalIdentifierMapSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ExternalIdentifierMapSerializer"/> class is to provide a <see cref="ExternalIdentifierMap"/> specific serializer
    /// </summary>
    public class ExternalIdentifierMapSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "correspondence", correspondence => new JArray(correspondence) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "externalFormat", externalFormat => new JValue(externalFormat) },
            { "externalModelName", externalModelName => new JValue(externalModelName) },
            { "externalToolName", externalToolName => new JValue(externalToolName) },
            { "externalToolVersion", externalToolVersion => new JValue(externalToolVersion) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ExternalIdentifierMap"/>
        /// </summary>
        /// <param name="externalIdentifierMap">The <see cref="ExternalIdentifierMap"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ExternalIdentifierMap externalIdentifierMap)
        {
            var jsonObject = new JObject();
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
