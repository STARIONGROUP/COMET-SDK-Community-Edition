// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="PersonResolver"/> is to deserialize a JSON object to a <see cref="Person"/>
    /// </summary>
    public static class PersonResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Person"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Person"/> to instantiate</returns>
        public static CDP4Common.DTO.Person FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var person = new CDP4Common.DTO.Person(iid, revisionNumber);

            if (!jObject["defaultDomain"].IsNullOrEmpty())
            {
                person.DefaultDomain = jObject["defaultDomain"].ToObject<Guid?>();
            }

            if (!jObject["defaultEmailAddress"].IsNullOrEmpty())
            {
                person.DefaultEmailAddress = jObject["defaultEmailAddress"].ToObject<Guid?>();
            }

            if (!jObject["defaultTelephoneNumber"].IsNullOrEmpty())
            {
                person.DefaultTelephoneNumber = jObject["defaultTelephoneNumber"].ToObject<Guid?>();
            }

            if (!jObject["emailAddress"].IsNullOrEmpty())
            {
                person.EmailAddress.AddRange(jObject["emailAddress"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                person.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                person.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["givenName"].IsNullOrEmpty())
            {
                person.GivenName = jObject["givenName"].ToObject<string>();
            }

            if (!jObject["isActive"].IsNullOrEmpty())
            {
                person.IsActive = jObject["isActive"].ToObject<bool>();
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                person.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                person.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["organization"].IsNullOrEmpty())
            {
                person.Organization = jObject["organization"].ToObject<Guid?>();
            }

            if (!jObject["organizationalUnit"].IsNullOrEmpty())
            {
                person.OrganizationalUnit = jObject["organizationalUnit"].ToObject<string>();
            }

            if (!jObject["password"].IsNullOrEmpty())
            {
                person.Password = jObject["password"].ToObject<string>();
            }

            if (!jObject["role"].IsNullOrEmpty())
            {
                person.Role = jObject["role"].ToObject<Guid?>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                person.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["surname"].IsNullOrEmpty())
            {
                person.Surname = jObject["surname"].ToObject<string>();
            }

            if (!jObject["telephoneNumber"].IsNullOrEmpty())
            {
                person.TelephoneNumber.AddRange(jObject["telephoneNumber"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                person.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["userPreference"].IsNullOrEmpty())
            {
                person.UserPreference.AddRange(jObject["userPreference"].ToObject<IEnumerable<Guid>>());
            }

            return person;
        }
    }
}
