// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryResolver"/> is to deserialize a JSON object to a <see cref="SiteDirectory"/>
    /// </summary>
    public static class SiteDirectoryResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="SiteDirectory"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="SiteDirectory"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteDirectory FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var siteDirectory = new CDP4Common.DTO.SiteDirectory(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("annotation", out var annotationProperty))
            {
                siteDirectory.Annotation.AddRange(annotationProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("createdOn", out var createdOnProperty))
            {
                siteDirectory.CreatedOn = createdOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("defaultParticipantRole", out var defaultParticipantRoleProperty))
            {
                siteDirectory.DefaultParticipantRole = defaultParticipantRoleProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("defaultPersonRole", out var defaultPersonRoleProperty))
            {
                siteDirectory.DefaultPersonRole = defaultPersonRoleProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("domain", out var domainProperty))
            {
                siteDirectory.Domain.AddRange(domainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("domainGroup", out var domainGroupProperty))
            {
                siteDirectory.DomainGroup.AddRange(domainGroupProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                siteDirectory.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                siteDirectory.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("lastModifiedOn", out var lastModifiedOnProperty))
            {
                siteDirectory.LastModifiedOn = lastModifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("logEntry", out var logEntryProperty))
            {
                siteDirectory.LogEntry.AddRange(logEntryProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("model", out var modelProperty))
            {
                siteDirectory.Model.AddRange(modelProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                siteDirectory.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                siteDirectory.Name = nameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("naturalLanguage", out var naturalLanguageProperty))
            {
                siteDirectory.NaturalLanguage.AddRange(naturalLanguageProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("organization", out var organizationProperty))
            {
                siteDirectory.Organization.AddRange(organizationProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("participantRole", out var participantRoleProperty))
            {
                siteDirectory.ParticipantRole.AddRange(participantRoleProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("person", out var personProperty))
            {
                siteDirectory.Person.AddRange(personProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("personRole", out var personRoleProperty))
            {
                siteDirectory.PersonRole.AddRange(personRoleProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                siteDirectory.ShortName = shortNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("siteReferenceDataLibrary", out var siteReferenceDataLibraryProperty))
            {
                siteDirectory.SiteReferenceDataLibrary.AddRange(siteReferenceDataLibraryProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                siteDirectory.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            return siteDirectory;
        }
    }
}
