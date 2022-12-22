// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Jaime Bernar
//
//    This file is part of CDP4-SDK Community Edition
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

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4JsonSerializer_SystemTextJson.EnumDeserializers;
    
    /// <summary>
    /// The purpose of the <see cref="PersonResolver"/> is to deserialize a JSON object to a <see cref="Person"/>
    /// </summary>
    public static class PersonResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="Person"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="Person"/> to instantiate</returns>
        public static CDP4Common.DTO.Person FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var person = new CDP4Common.DTO.Person(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("defaultDomain", out var defaultDomainProperty))
            {
                person.DefaultDomain = defaultDomainProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("defaultEmailAddress", out var defaultEmailAddressProperty))
            {
                person.DefaultEmailAddress = defaultEmailAddressProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("defaultTelephoneNumber", out var defaultTelephoneNumberProperty))
            {
                person.DefaultTelephoneNumber = defaultTelephoneNumberProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("emailAddress", out var emailAddressProperty))
            {
                person.EmailAddress.AddRange(emailAddressProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                person.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                person.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("givenName", out var givenNameProperty))
            {
                person.GivenName = givenNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("isActive", out var isActiveProperty))
            {
                person.IsActive = isActiveProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                person.IsDeprecated = isDeprecatedProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                person.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("organization", out var organizationProperty))
            {
                person.Organization = organizationProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("organizationalUnit", out var organizationalUnitProperty))
            {
                person.OrganizationalUnit = organizationalUnitProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("password", out var passwordProperty))
            {
                person.Password = passwordProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("role", out var roleProperty))
            {
                person.Role = roleProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                person.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("surname", out var surnameProperty))
            {
                person.Surname = surnameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("telephoneNumber", out var telephoneNumberProperty))
            {
                person.TelephoneNumber.AddRange(telephoneNumberProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                person.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("userPreference", out var userPreferenceProperty))
            {
                person.UserPreference.AddRange(userPreferenceProperty.Deserialize<IEnumerable<Guid>>());
            }

            return person;
        }
    }
}
