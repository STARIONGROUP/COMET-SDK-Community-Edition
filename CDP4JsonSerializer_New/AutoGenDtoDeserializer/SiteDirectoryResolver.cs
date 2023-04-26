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
    /// The purpose of the <see cref="SiteDirectoryResolver"/> is to deserialize a JSON object to a <see cref="SiteDirectory"/>
    /// </summary>
    public static class SiteDirectoryResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="SiteDirectory"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="SiteDirectory"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteDirectory FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            var siteDirectory = new CDP4Common.DTO.SiteDirectory(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("annotation"u8, out var annotationProperty))
            {
                foreach(var element in annotationProperty.EnumerateArray())
                {
                    siteDirectory.Annotation.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale createdOn property of the siteDirectory {id} is null", siteDirectory.Iid);
                }
                else
                {
                    siteDirectory.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("defaultParticipantRole"u8, out var defaultParticipantRoleProperty))
            {
                if(defaultParticipantRoleProperty.ValueKind == JsonValueKind.Null)
                {
                    siteDirectory.DefaultParticipantRole = null;
                }
                else
                {
                    siteDirectory.DefaultParticipantRole = defaultParticipantRoleProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("defaultPersonRole"u8, out var defaultPersonRoleProperty))
            {
                if(defaultPersonRoleProperty.ValueKind == JsonValueKind.Null)
                {
                    siteDirectory.DefaultPersonRole = null;
                }
                else
                {
                    siteDirectory.DefaultPersonRole = defaultPersonRoleProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("domain"u8, out var domainProperty))
            {
                foreach(var element in domainProperty.EnumerateArray())
                {
                    siteDirectory.Domain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("domainGroup"u8, out var domainGroupProperty))
            {
                foreach(var element in domainGroupProperty.EnumerateArray())
                {
                    siteDirectory.DomainGroup.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    siteDirectory.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    siteDirectory.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("lastModifiedOn"u8, out var lastModifiedOnProperty))
            {
                if(lastModifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale lastModifiedOn property of the siteDirectory {id} is null", siteDirectory.Iid);
                }
                else
                {
                    siteDirectory.LastModifiedOn = lastModifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("logEntry"u8, out var logEntryProperty))
            {
                foreach(var element in logEntryProperty.EnumerateArray())
                {
                    siteDirectory.LogEntry.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("model"u8, out var modelProperty))
            {
                foreach(var element in modelProperty.EnumerateArray())
                {
                    siteDirectory.Model.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the siteDirectory {id} is null", siteDirectory.Iid);
                }
                else
                {
                    siteDirectory.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the siteDirectory {id} is null", siteDirectory.Iid);
                }
                else
                {
                    siteDirectory.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("naturalLanguage"u8, out var naturalLanguageProperty))
            {
                foreach(var element in naturalLanguageProperty.EnumerateArray())
                {
                    siteDirectory.NaturalLanguage.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("organization"u8, out var organizationProperty))
            {
                foreach(var element in organizationProperty.EnumerateArray())
                {
                    siteDirectory.Organization.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("participantRole"u8, out var participantRoleProperty))
            {
                foreach(var element in participantRoleProperty.EnumerateArray())
                {
                    siteDirectory.ParticipantRole.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("person"u8, out var personProperty))
            {
                foreach(var element in personProperty.EnumerateArray())
                {
                    siteDirectory.Person.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("personRole"u8, out var personRoleProperty))
            {
                foreach(var element in personRoleProperty.EnumerateArray())
                {
                    siteDirectory.PersonRole.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the siteDirectory {id} is null", siteDirectory.Iid);
                }
                else
                {
                    siteDirectory.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("siteReferenceDataLibrary"u8, out var siteReferenceDataLibraryProperty))
            {
                foreach(var element in siteReferenceDataLibraryProperty.EnumerateArray())
                {
                    siteDirectory.SiteReferenceDataLibrary.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the siteDirectory {id} is null", siteDirectory.Iid);
                }
                else
                {
                    siteDirectory.ThingPreference = thingPreferenceProperty.GetString();
                }
            }
            return siteDirectory;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
