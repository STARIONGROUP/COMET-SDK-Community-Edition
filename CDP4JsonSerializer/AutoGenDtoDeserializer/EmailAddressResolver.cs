// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddressResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
    /// The purpose of the <see cref="EmailAddressResolver"/> is to deserialize a JSON object to a <see cref="EmailAddress"/>
    /// </summary>
    public static class EmailAddressResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="EmailAddress"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="EmailAddress"/> to instantiate</returns>
        public static CDP4Common.DTO.EmailAddress FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var emailAddress = new CDP4Common.DTO.EmailAddress(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                emailAddress.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                emailAddress.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                emailAddress.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                emailAddress.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                emailAddress.Value = jObject["value"].ToObject<string>();
            }

            if (!jObject["vcardType"].IsNullOrEmpty())
            {
                emailAddress.VcardType = jObject["vcardType"].ToObject<VcardEmailAddressKind>();
            }

            return emailAddress;
        }
    }
}
