// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
    /// The purpose of the <see cref="PersonSerializer"/> class is to provide a <see cref="Person"/> specific serializer
    /// </summary>
    public class PersonSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "defaultDomain", defaultDomain => new JValue(defaultDomain) },
            { "defaultEmailAddress", defaultEmailAddress => new JValue(defaultEmailAddress) },
            { "defaultTelephoneNumber", defaultTelephoneNumber => new JValue(defaultTelephoneNumber) },
            { "emailAddress", emailAddress => new JArray(emailAddress) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "givenName", givenName => new JValue(givenName) },
            { "iid", iid => new JValue(iid) },
            { "isActive", isActive => new JValue(isActive) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "organization", organization => new JValue(organization) },
            { "organizationalUnit", organizationalUnit => new JValue(organizationalUnit) },
            { "password", password => new JValue(password) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "role", role => new JValue(role) },
            { "shortName", shortName => new JValue(shortName) },
            { "surname", surname => new JValue(surname) },
            { "telephoneNumber", telephoneNumber => new JArray(telephoneNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "userPreference", userPreference => new JArray(userPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="Person"/>
        /// </summary>
        /// <param name="person">The <see cref="Person"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Person person)
        {
            var jsonObject = new JObject();
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
