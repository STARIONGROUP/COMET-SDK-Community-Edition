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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

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

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="PersonResolver"/> is to deserialize a JSON object to a <see cref="Person"/>
    /// </summary>
    public static class PersonResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="Person"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="Person"/> to instantiate</returns>
        public static CDP4Common.DTO.Person FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            var person = new CDP4Common.DTO.Person(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("defaultDomain"u8, out var defaultDomainProperty))
            {
                if(defaultDomainProperty.ValueKind == JsonValueKind.Null)
                {
                    person.DefaultDomain = null;
                }
                else
                {
                    person.DefaultDomain = defaultDomainProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("defaultEmailAddress"u8, out var defaultEmailAddressProperty))
            {
                if(defaultEmailAddressProperty.ValueKind == JsonValueKind.Null)
                {
                    person.DefaultEmailAddress = null;
                }
                else
                {
                    person.DefaultEmailAddress = defaultEmailAddressProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("defaultTelephoneNumber"u8, out var defaultTelephoneNumberProperty))
            {
                if(defaultTelephoneNumberProperty.ValueKind == JsonValueKind.Null)
                {
                    person.DefaultTelephoneNumber = null;
                }
                else
                {
                    person.DefaultTelephoneNumber = defaultTelephoneNumberProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("emailAddress"u8, out var emailAddressProperty))
            {
                foreach(var element in emailAddressProperty.EnumerateArray())
                {
                    person.EmailAddress.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    person.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    person.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("givenName"u8, out var givenNameProperty))
            {
                if(givenNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale givenName property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.GivenName = givenNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("isActive"u8, out var isActiveProperty))
            {
                if(isActiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isActive property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.IsActive = isActiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isDeprecated property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("organization"u8, out var organizationProperty))
            {
                if(organizationProperty.ValueKind == JsonValueKind.Null)
                {
                    person.Organization = null;
                }
                else
                {
                    person.Organization = organizationProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("organizationalUnit"u8, out var organizationalUnitProperty))
            {
                if(organizationalUnitProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale organizationalUnit property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.OrganizationalUnit = organizationalUnitProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("password"u8, out var passwordProperty))
            {
                if(passwordProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale password property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.Password = passwordProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("role"u8, out var roleProperty))
            {
                if(roleProperty.ValueKind == JsonValueKind.Null)
                {
                    person.Role = null;
                }
                else
                {
                    person.Role = roleProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("surname"u8, out var surnameProperty))
            {
                if(surnameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale surname property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.Surname = surnameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("telephoneNumber"u8, out var telephoneNumberProperty))
            {
                foreach(var element in telephoneNumberProperty.EnumerateArray())
                {
                    person.TelephoneNumber.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the person {id} is null", person.Iid);
                }
                else
                {
                    person.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("userPreference"u8, out var userPreferenceProperty))
            {
                foreach(var element in userPreferenceProperty.EnumerateArray())
                {
                    person.UserPreference.Add(element.GetGuid());
                }
            }
            return person;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
