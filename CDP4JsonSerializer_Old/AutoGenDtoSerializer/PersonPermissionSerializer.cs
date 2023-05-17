// --------------------------------------------------------------------------------------------------------------------
// <copyright file "PersonPermissionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PersonPermissionSerializer"/> class is to provide a <see cref="PersonPermission"/> specific serializer
    /// </summary>
    public class PersonPermissionSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "accessRight", accessRight => new JValue(accessRight.ToString()) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "objectClass", objectClass => new JValue(objectClass.ToString()) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="PersonPermission"/>
        /// </summary>
        /// <param name="personPermission">The <see cref="PersonPermission"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(PersonPermission personPermission)
        {
            var jsonObject = new JObject();
            jsonObject.Add("accessRight", this.PropertySerializerMap["accessRight"](Enum.GetName(typeof(CDP4Common.CommonData.PersonAccessRightKind), personPermission.AccessRight)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), personPermission.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](personPermission.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](personPermission.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](personPermission.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](personPermission.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](personPermission.ModifiedOn));
            jsonObject.Add("objectClass", this.PropertySerializerMap["objectClass"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), personPermission.ObjectClass)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](personPermission.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](personPermission.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="PersonPermission"/> class.
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

            var personPermission = thing as PersonPermission;
            if (personPermission == null)
            {
                throw new InvalidOperationException("The thing is not a PersonPermission.");
            }

            return this.Serialize(personPermission);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
