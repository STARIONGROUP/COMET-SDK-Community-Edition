// -------------------------------------------------------------------------------------------------------------------------------// <copyright file="SiteDirectorySerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
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
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NLog;

    using Thing = CDP4Common.DTO.Thing;
    using SiteDirectory = CDP4Common.DTO.SiteDirectory;

    /// <summary>
    /// The purpose of the <see cref="SiteDirectorySerializer"/> class is to provide a <see cref="SiteDirectory"/> specific serializer
    /// </summary>
    public class SiteDirectorySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="SiteDirectory" />.
        /// An error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version minimalAllowedDataModelVersion = Version.Parse("1.0.0");

        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="SiteDirectory" />.
        /// When a Requested Data Model version for Serialization is lower than this, the object will not be Serialized, just ignored.
        /// NO error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version thingMinimalAllowedDataModelVersion = Version.Parse("1.0.0");

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="SiteDirectory" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not SiteDirectory siteDirectory)
            {
                throw new ArgumentException("The thing shall be a SiteDirectory", nameof(thing));
            }

            if (requestedDataModelVersion < minimalAllowedDataModelVersion)
            {
                throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported for serialization of SiteDirectory.");
            }

            if (requestedDataModelVersion < thingMinimalAllowedDataModelVersion)
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of SiteDirectory since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Trace, "Serializing SiteDirectory for Version 1.0.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(siteDirectory.ClassKind.ToString());
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(siteDirectory.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("defaultParticipantRole"u8);

                    if (siteDirectory.DefaultParticipantRole.HasValue)
                    {
                        writer.WriteStringValue(siteDirectory.DefaultParticipantRole.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultPersonRole"u8);

                    if (siteDirectory.DefaultPersonRole.HasValue)
                    {
                        writer.WriteStringValue(siteDirectory.DefaultPersonRole.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("domain"u8);

                    foreach(var domainItem in siteDirectory.Domain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("domainGroup"u8);

                    foreach(var domainGroupItem in siteDirectory.DomainGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(siteDirectory.Iid);
                    writer.WritePropertyName("lastModifiedOn"u8);
                    writer.WriteStringValue(siteDirectory.LastModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("logEntry"u8);

                    foreach(var logEntryItem in siteDirectory.LogEntry.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(logEntryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("model"u8);

                    foreach(var modelItem in siteDirectory.Model.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(modelItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(siteDirectory.Name);
                    writer.WriteStartArray("naturalLanguage"u8);

                    foreach(var naturalLanguageItem in siteDirectory.NaturalLanguage.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(naturalLanguageItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("organization"u8);

                    foreach(var organizationItem in siteDirectory.Organization.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(organizationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("participantRole"u8);

                    foreach(var participantRoleItem in siteDirectory.ParticipantRole.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(participantRoleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("person"u8);

                    foreach(var personItem in siteDirectory.Person.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(personItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("personRole"u8);

                    foreach(var personRoleItem in siteDirectory.PersonRole.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(personRoleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(siteDirectory.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(siteDirectory.ShortName);
                    writer.WriteStartArray("siteReferenceDataLibrary"u8);

                    foreach(var siteReferenceDataLibraryItem in siteDirectory.SiteReferenceDataLibrary.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(siteReferenceDataLibraryItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Trace, "Serializing SiteDirectory for Version 1.1.0");
                    writer.WriteStartArray("annotation"u8);

                    foreach(var annotationItem in siteDirectory.Annotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(annotationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(siteDirectory.ClassKind.ToString());
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(siteDirectory.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("defaultParticipantRole"u8);

                    if (siteDirectory.DefaultParticipantRole.HasValue)
                    {
                        writer.WriteStringValue(siteDirectory.DefaultParticipantRole.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultPersonRole"u8);

                    if (siteDirectory.DefaultPersonRole.HasValue)
                    {
                        writer.WriteStringValue(siteDirectory.DefaultPersonRole.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("domain"u8);

                    foreach(var domainItem in siteDirectory.Domain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("domainGroup"u8);

                    foreach(var domainGroupItem in siteDirectory.DomainGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in siteDirectory.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in siteDirectory.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(siteDirectory.Iid);
                    writer.WritePropertyName("lastModifiedOn"u8);
                    writer.WriteStringValue(siteDirectory.LastModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("logEntry"u8);

                    foreach(var logEntryItem in siteDirectory.LogEntry.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(logEntryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("model"u8);

                    foreach(var modelItem in siteDirectory.Model.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(modelItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(siteDirectory.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(siteDirectory.Name);
                    writer.WriteStartArray("naturalLanguage"u8);

                    foreach(var naturalLanguageItem in siteDirectory.NaturalLanguage.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(naturalLanguageItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("organization"u8);

                    foreach(var organizationItem in siteDirectory.Organization.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(organizationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("participantRole"u8);

                    foreach(var participantRoleItem in siteDirectory.ParticipantRole.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(participantRoleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("person"u8);

                    foreach(var personItem in siteDirectory.Person.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(personItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("personRole"u8);

                    foreach(var personRoleItem in siteDirectory.PersonRole.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(personRoleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(siteDirectory.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(siteDirectory.ShortName);
                    writer.WriteStartArray("siteReferenceDataLibrary"u8);

                    foreach(var siteReferenceDataLibraryItem in siteDirectory.SiteReferenceDataLibrary.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(siteReferenceDataLibraryItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing SiteDirectory for Version 1.2.0");
                    writer.WriteStartArray("annotation"u8);

                    foreach(var annotationItem in siteDirectory.Annotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(annotationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(siteDirectory.ClassKind.ToString());
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(siteDirectory.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("defaultParticipantRole"u8);

                    if (siteDirectory.DefaultParticipantRole.HasValue)
                    {
                        writer.WriteStringValue(siteDirectory.DefaultParticipantRole.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultPersonRole"u8);

                    if (siteDirectory.DefaultPersonRole.HasValue)
                    {
                        writer.WriteStringValue(siteDirectory.DefaultPersonRole.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("domain"u8);

                    foreach(var domainItem in siteDirectory.Domain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("domainGroup"u8);

                    foreach(var domainGroupItem in siteDirectory.DomainGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in siteDirectory.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in siteDirectory.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(siteDirectory.Iid);
                    writer.WritePropertyName("lastModifiedOn"u8);
                    writer.WriteStringValue(siteDirectory.LastModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("logEntry"u8);

                    foreach(var logEntryItem in siteDirectory.LogEntry.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(logEntryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("model"u8);

                    foreach(var modelItem in siteDirectory.Model.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(modelItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(siteDirectory.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(siteDirectory.Name);
                    writer.WriteStartArray("naturalLanguage"u8);

                    foreach(var naturalLanguageItem in siteDirectory.NaturalLanguage.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(naturalLanguageItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("organization"u8);

                    foreach(var organizationItem in siteDirectory.Organization.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(organizationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("participantRole"u8);

                    foreach(var participantRoleItem in siteDirectory.ParticipantRole.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(participantRoleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("person"u8);

                    foreach(var personItem in siteDirectory.Person.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(personItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("personRole"u8);

                    foreach(var personRoleItem in siteDirectory.PersonRole.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(personRoleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(siteDirectory.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(siteDirectory.ShortName);
                    writer.WriteStartArray("siteReferenceDataLibrary"u8);

                    foreach(var siteReferenceDataLibraryItem in siteDirectory.SiteReferenceDataLibrary.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(siteReferenceDataLibraryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(siteDirectory.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing SiteDirectory for Version 1.3.0");
                    writer.WriteStartArray("annotation"u8);

                    foreach(var annotationItem in siteDirectory.Annotation.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(annotationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(siteDirectory.ClassKind.ToString());
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(siteDirectory.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("defaultParticipantRole"u8);

                    if (siteDirectory.DefaultParticipantRole.HasValue)
                    {
                        writer.WriteStringValue(siteDirectory.DefaultParticipantRole.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultPersonRole"u8);

                    if (siteDirectory.DefaultPersonRole.HasValue)
                    {
                        writer.WriteStringValue(siteDirectory.DefaultPersonRole.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("domain"u8);

                    foreach(var domainItem in siteDirectory.Domain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("domainGroup"u8);

                    foreach(var domainGroupItem in siteDirectory.DomainGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in siteDirectory.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in siteDirectory.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(siteDirectory.Iid);
                    writer.WritePropertyName("lastModifiedOn"u8);
                    writer.WriteStringValue(siteDirectory.LastModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("logEntry"u8);

                    foreach(var logEntryItem in siteDirectory.LogEntry.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(logEntryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("model"u8);

                    foreach(var modelItem in siteDirectory.Model.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(modelItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(siteDirectory.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(siteDirectory.Name);
                    writer.WriteStartArray("naturalLanguage"u8);

                    foreach(var naturalLanguageItem in siteDirectory.NaturalLanguage.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(naturalLanguageItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("organization"u8);

                    foreach(var organizationItem in siteDirectory.Organization.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(organizationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("participantRole"u8);

                    foreach(var participantRoleItem in siteDirectory.ParticipantRole.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(participantRoleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("person"u8);

                    foreach(var personItem in siteDirectory.Person.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(personItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("personRole"u8);

                    foreach(var personRoleItem in siteDirectory.PersonRole.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(personRoleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(siteDirectory.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(siteDirectory.ShortName);
                    writer.WriteStartArray("siteReferenceDataLibrary"u8);

                    foreach(var siteReferenceDataLibraryItem in siteDirectory.SiteReferenceDataLibrary.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(siteReferenceDataLibraryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(siteDirectory.ThingPreference);
                    break;
                default:
                    throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported");
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="SiteDirectory" /></exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer)
        {
            if (thing is not SiteDirectory siteDirectory)
            {
                throw new ArgumentException("The thing shall be a SiteDirectory", nameof(thing));
            }

            writer.WriteStartObject();

                writer.WriteStartArray("annotation"u8);

                foreach(var annotationItem in siteDirectory.Annotation.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(annotationItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("classKind"u8);
                writer.WriteStringValue(siteDirectory.ClassKind.ToString());
                writer.WritePropertyName("createdOn"u8);
                writer.WriteStringValue(siteDirectory.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                writer.WritePropertyName("defaultParticipantRole"u8);

                if (siteDirectory.DefaultParticipantRole.HasValue)
                {
                    writer.WriteStringValue(siteDirectory.DefaultParticipantRole.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WritePropertyName("defaultPersonRole"u8);

                if (siteDirectory.DefaultPersonRole.HasValue)
                {
                    writer.WriteStringValue(siteDirectory.DefaultPersonRole.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WriteStartArray("domain"u8);

                foreach(var domainItem in siteDirectory.Domain.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(domainItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("domainGroup"u8);

                foreach(var domainGroupItem in siteDirectory.DomainGroup.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(domainGroupItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedDomain"u8);

                foreach(var excludedDomainItem in siteDirectory.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedDomainItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedPerson"u8);

                foreach(var excludedPersonItem in siteDirectory.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedPersonItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("iid"u8);
                writer.WriteStringValue(siteDirectory.Iid);
                writer.WritePropertyName("lastModifiedOn"u8);
                writer.WriteStringValue(siteDirectory.LastModifiedOn.ToString(SerializerHelper.DateTimeFormat));

                writer.WriteStartArray("logEntry"u8);

                foreach(var logEntryItem in siteDirectory.LogEntry.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(logEntryItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("model"u8);

                foreach(var modelItem in siteDirectory.Model.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(modelItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("modifiedOn"u8);
                writer.WriteStringValue(siteDirectory.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(siteDirectory.Name);

                writer.WriteStartArray("naturalLanguage"u8);

                foreach(var naturalLanguageItem in siteDirectory.NaturalLanguage.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(naturalLanguageItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("organization"u8);

                foreach(var organizationItem in siteDirectory.Organization.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(organizationItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("participantRole"u8);

                foreach(var participantRoleItem in siteDirectory.ParticipantRole.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(participantRoleItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("person"u8);

                foreach(var personItem in siteDirectory.Person.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(personItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("personRole"u8);

                foreach(var personRoleItem in siteDirectory.PersonRole.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(personRoleItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("revisionNumber"u8);
                writer.WriteNumberValue(siteDirectory.RevisionNumber);
                writer.WritePropertyName("shortName"u8);
                writer.WriteStringValue(siteDirectory.ShortName);

                writer.WriteStartArray("siteReferenceDataLibrary"u8);

                foreach(var siteReferenceDataLibraryItem in siteDirectory.SiteReferenceDataLibrary.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(siteReferenceDataLibraryItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("thingPreference"u8);
                writer.WriteStringValue(siteDirectory.ThingPreference);

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="SiteDirectory"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            var requestedVersion = requestedDataModelVersion.ToString(3);

            if(!AllowedVersionsPerProperty[propertyName].Contains(requestedVersion))
            {
                return;
            }

            this.SerializeProperty(propertyName, value, writer);
        }

        /// <summary>
        /// Serialize a value for a <see cref="SiteDirectory"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer)
        {
            switch(propertyName.ToLower())
            {
                case "annotation":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListAnnotation && objectListAnnotation.Any())
                    {
                        writer.WriteStartArray("annotation"u8);

                        foreach(var annotationItem in objectListAnnotation.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(annotationItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "classkind":
                    writer.WritePropertyName("classKind"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((ClassKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "createdon":
                    writer.WritePropertyName("createdOn"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((DateTime)value).ToString(SerializerHelper.DateTimeFormat));
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "defaultparticipantrole":
                    writer.WritePropertyName("defaultParticipantRole"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "defaultpersonrole":
                    writer.WritePropertyName("defaultPersonRole"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "domain":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListDomain && objectListDomain.Any())
                    {
                        writer.WriteStartArray("domain"u8);

                        foreach(var domainItem in objectListDomain.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(domainItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "domaingroup":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListDomainGroup && objectListDomainGroup.Any())
                    {
                        writer.WriteStartArray("domainGroup"u8);

                        foreach(var domainGroupItem in objectListDomainGroup.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(domainGroupItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "excludeddomain":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListExcludedDomain && objectListExcludedDomain.Any())
                    {
                        writer.WriteStartArray("excludedDomain"u8);

                        foreach(var excludedDomainItem in objectListExcludedDomain.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedDomainItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "excludedperson":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListExcludedPerson && objectListExcludedPerson.Any())
                    {
                        writer.WriteStartArray("excludedPerson"u8);

                        foreach(var excludedPersonItem in objectListExcludedPerson.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedPersonItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "iid":
                    writer.WritePropertyName("iid"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "lastmodifiedon":
                    writer.WritePropertyName("lastModifiedOn"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((DateTime)value).ToString(SerializerHelper.DateTimeFormat));
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "logentry":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListLogEntry && objectListLogEntry.Any())
                    {
                        writer.WriteStartArray("logEntry"u8);

                        foreach(var logEntryItem in objectListLogEntry.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(logEntryItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "model":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListModel && objectListModel.Any())
                    {
                        writer.WriteStartArray("model"u8);

                        foreach(var modelItem in objectListModel.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(modelItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "modifiedon":
                    writer.WritePropertyName("modifiedOn"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((DateTime)value).ToString(SerializerHelper.DateTimeFormat));
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "name":
                    writer.WritePropertyName("name"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "naturallanguage":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListNaturalLanguage && objectListNaturalLanguage.Any())
                    {
                        writer.WriteStartArray("naturalLanguage"u8);

                        foreach(var naturalLanguageItem in objectListNaturalLanguage.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(naturalLanguageItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "organization":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListOrganization && objectListOrganization.Any())
                    {
                        writer.WriteStartArray("organization"u8);

                        foreach(var organizationItem in objectListOrganization.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(organizationItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "participantrole":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListParticipantRole && objectListParticipantRole.Any())
                    {
                        writer.WriteStartArray("participantRole"u8);

                        foreach(var participantRoleItem in objectListParticipantRole.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(participantRoleItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "person":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListPerson && objectListPerson.Any())
                    {
                        writer.WriteStartArray("person"u8);

                        foreach(var personItem in objectListPerson.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(personItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "personrole":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListPersonRole && objectListPersonRole.Any())
                    {
                        writer.WriteStartArray("personRole"u8);

                        foreach(var personRoleItem in objectListPersonRole.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(personRoleItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "revisionnumber":
                    writer.WritePropertyName("revisionNumber"u8);
                    
                    if(value != null)
                    {
                        writer.WriteNumberValue((int)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "shortname":
                    writer.WritePropertyName("shortName"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "sitereferencedatalibrary":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListSiteReferenceDataLibrary && objectListSiteReferenceDataLibrary.Any())
                    {
                        writer.WriteStartArray("siteReferenceDataLibrary"u8);

                        foreach(var siteReferenceDataLibraryItem in objectListSiteReferenceDataLibrary.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(siteReferenceDataLibraryItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "thingpreference":
                    writer.WritePropertyName("thingPreference"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the SiteDirectory");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "annotation", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "classKind", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "createdOn", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "defaultParticipantRole", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "defaultPersonRole", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "domain", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "domainGroup", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "lastModifiedOn", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "logEntry", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "model", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "name", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "naturalLanguage", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "organization", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "participantRole", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "person", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "personRole", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "shortName", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "siteReferenceDataLibrary", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
