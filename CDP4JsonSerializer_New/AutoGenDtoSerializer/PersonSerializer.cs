// --------------------------------------------------------------------------------------------------------------------
// <copyright file "PersonSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PersonSerializer"/> class is to provide a <see cref="Person"/> specific serializer
    /// </summary>
    public class PersonSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "defaultDomain", defaultDomain => JsonValue.Create(defaultDomain) },
            { "defaultEmailAddress", defaultEmailAddress => JsonValue.Create(defaultEmailAddress) },
            { "defaultTelephoneNumber", defaultTelephoneNumber => JsonValue.Create(defaultTelephoneNumber) },
            { "emailAddress", emailAddress => JsonValue.Create(emailAddress) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "givenName", givenName => JsonValue.Create(givenName) },
            { "iid", iid => JsonValue.Create(iid) },
            { "isActive", isActive => JsonValue.Create(isActive) },
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "organization", organization => JsonValue.Create(organization) },
            { "organizationalUnit", organizationalUnit => JsonValue.Create(organizationalUnit) },
            { "password", password => JsonValue.Create(password) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "role", role => JsonValue.Create(role) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "surname", surname => JsonValue.Create(surname) },
            { "telephoneNumber", telephoneNumber => JsonValue.Create(telephoneNumber) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "userPreference", userPreference => JsonValue.Create(userPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="Person"/>
        /// </summary>
        /// <param name="person">The <see cref="Person"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(Person person)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), person.ClassKind)));
            jsonObject.Add("defaultDomain", this.PropertySerializerMap["defaultDomain"](person.DefaultDomain));
            jsonObject.Add("defaultEmailAddress", this.PropertySerializerMap["defaultEmailAddress"](person.DefaultEmailAddress));
            jsonObject.Add("defaultTelephoneNumber", this.PropertySerializerMap["defaultTelephoneNumber"](person.DefaultTelephoneNumber));
            jsonObject.Add("emailAddress", this.PropertySerializerMap["emailAddress"](person.EmailAddress.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](person.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](person.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("givenName", this.PropertySerializerMap["givenName"](person.GivenName));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](person.Iid));
            jsonObject.Add("isActive", this.PropertySerializerMap["isActive"](person.IsActive));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](person.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](person.ModifiedOn));
            jsonObject.Add("organization", this.PropertySerializerMap["organization"](person.Organization));
            jsonObject.Add("organizationalUnit", this.PropertySerializerMap["organizationalUnit"](person.OrganizationalUnit));
            jsonObject.Add("password", this.PropertySerializerMap["password"](person.Password));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](person.RevisionNumber));
            jsonObject.Add("role", this.PropertySerializerMap["role"](person.Role));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](person.ShortName));
            jsonObject.Add("surname", this.PropertySerializerMap["surname"](person.Surname));
            jsonObject.Add("telephoneNumber", this.PropertySerializerMap["telephoneNumber"](person.TelephoneNumber.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](person.ThingPreference));
            jsonObject.Add("userPreference", this.PropertySerializerMap["userPreference"](person.UserPreference.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Person"/> class.
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

            var person = thing as Person;
            if (person == null)
            {
                throw new InvalidOperationException("The thing is not a Person.");
            }

            return this.Serialize(person);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
