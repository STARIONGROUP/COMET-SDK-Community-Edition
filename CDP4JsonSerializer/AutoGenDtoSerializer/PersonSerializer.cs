// -------------------------------------------------------------------------------------------------------------------------------// <copyright file="PersonSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using Person = CDP4Common.DTO.Person;

    /// <summary>
    /// The purpose of the <see cref="PersonSerializer"/> class is to provide a <see cref="Person"/> specific serializer
    /// </summary>
    public class PersonSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="Person" />.
        /// An error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version minimalAllowedDataModelVersion = Version.Parse("1.0.0");

        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="Person" />.
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
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="Person" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not Person person)
            {
                throw new ArgumentException("The thing shall be a Person", nameof(thing));
            }

            if (requestedDataModelVersion < minimalAllowedDataModelVersion)
            {
                throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported for serialization of Person.");
            }

            if (requestedDataModelVersion < thingMinimalAllowedDataModelVersion)
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of Person since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Trace, "Serializing Person for Version 1.0.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(person.ClassKind.ToString());
                    writer.WritePropertyName("defaultDomain"u8);

                    if (person.DefaultDomain.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultDomain.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultEmailAddress"u8);

                    if (person.DefaultEmailAddress.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultEmailAddress.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultTelephoneNumber"u8);

                    if (person.DefaultTelephoneNumber.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultTelephoneNumber.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("emailAddress"u8);

                    foreach(var emailAddressItem in person.EmailAddress.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(emailAddressItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("givenName"u8);
                    writer.WriteStringValue(person.GivenName);
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(person.Iid);
                    writer.WritePropertyName("isActive"u8);
                    writer.WriteBooleanValue(person.IsActive);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(person.IsDeprecated);
                    writer.WritePropertyName("organization"u8);

                    if (person.Organization.HasValue)
                    {
                        writer.WriteStringValue(person.Organization.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("organizationalUnit"u8);
                    writer.WriteStringValue(person.OrganizationalUnit);
                    writer.WritePropertyName("password"u8);
                    writer.WriteStringValue(person.Password);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(person.RevisionNumber);
                    writer.WritePropertyName("role"u8);

                    if (person.Role.HasValue)
                    {
                        writer.WriteStringValue(person.Role.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(person.ShortName);
                    writer.WritePropertyName("surname"u8);
                    writer.WriteStringValue(person.Surname);
                    writer.WriteStartArray("telephoneNumber"u8);

                    foreach(var telephoneNumberItem in person.TelephoneNumber.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(telephoneNumberItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("userPreference"u8);

                    foreach(var userPreferenceItem in person.UserPreference.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(userPreferenceItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Trace, "Serializing Person for Version 1.1.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(person.ClassKind.ToString());
                    writer.WritePropertyName("defaultDomain"u8);

                    if (person.DefaultDomain.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultDomain.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultEmailAddress"u8);

                    if (person.DefaultEmailAddress.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultEmailAddress.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultTelephoneNumber"u8);

                    if (person.DefaultTelephoneNumber.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultTelephoneNumber.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("emailAddress"u8);

                    foreach(var emailAddressItem in person.EmailAddress.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(emailAddressItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in person.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in person.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("givenName"u8);
                    writer.WriteStringValue(person.GivenName);
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(person.Iid);
                    writer.WritePropertyName("isActive"u8);
                    writer.WriteBooleanValue(person.IsActive);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(person.IsDeprecated);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(person.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("organization"u8);

                    if (person.Organization.HasValue)
                    {
                        writer.WriteStringValue(person.Organization.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("organizationalUnit"u8);
                    writer.WriteStringValue(person.OrganizationalUnit);
                    writer.WritePropertyName("password"u8);
                    writer.WriteStringValue(person.Password);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(person.RevisionNumber);
                    writer.WritePropertyName("role"u8);

                    if (person.Role.HasValue)
                    {
                        writer.WriteStringValue(person.Role.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(person.ShortName);
                    writer.WritePropertyName("surname"u8);
                    writer.WriteStringValue(person.Surname);
                    writer.WriteStartArray("telephoneNumber"u8);

                    foreach(var telephoneNumberItem in person.TelephoneNumber.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(telephoneNumberItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("userPreference"u8);

                    foreach(var userPreferenceItem in person.UserPreference.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(userPreferenceItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing Person for Version 1.2.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(person.ClassKind.ToString());
                    writer.WritePropertyName("defaultDomain"u8);

                    if (person.DefaultDomain.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultDomain.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultEmailAddress"u8);

                    if (person.DefaultEmailAddress.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultEmailAddress.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultTelephoneNumber"u8);

                    if (person.DefaultTelephoneNumber.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultTelephoneNumber.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("emailAddress"u8);

                    foreach(var emailAddressItem in person.EmailAddress.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(emailAddressItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in person.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in person.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("givenName"u8);
                    writer.WriteStringValue(person.GivenName);
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(person.Iid);
                    writer.WritePropertyName("isActive"u8);
                    writer.WriteBooleanValue(person.IsActive);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(person.IsDeprecated);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(person.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("organization"u8);

                    if (person.Organization.HasValue)
                    {
                        writer.WriteStringValue(person.Organization.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("organizationalUnit"u8);
                    writer.WriteStringValue(person.OrganizationalUnit);
                    writer.WritePropertyName("password"u8);
                    writer.WriteStringValue(person.Password);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(person.RevisionNumber);
                    writer.WritePropertyName("role"u8);

                    if (person.Role.HasValue)
                    {
                        writer.WriteStringValue(person.Role.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(person.ShortName);
                    writer.WritePropertyName("surname"u8);
                    writer.WriteStringValue(person.Surname);
                    writer.WriteStartArray("telephoneNumber"u8);

                    foreach(var telephoneNumberItem in person.TelephoneNumber.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(telephoneNumberItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(person.ThingPreference);
                    writer.WriteStartArray("userPreference"u8);

                    foreach(var userPreferenceItem in person.UserPreference.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(userPreferenceItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing Person for Version 1.3.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(person.ClassKind.ToString());
                    writer.WritePropertyName("defaultDomain"u8);

                    if (person.DefaultDomain.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultDomain.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultEmailAddress"u8);

                    if (person.DefaultEmailAddress.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultEmailAddress.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("defaultTelephoneNumber"u8);

                    if (person.DefaultTelephoneNumber.HasValue)
                    {
                        writer.WriteStringValue(person.DefaultTelephoneNumber.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("emailAddress"u8);

                    foreach(var emailAddressItem in person.EmailAddress.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(emailAddressItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in person.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in person.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("givenName"u8);
                    writer.WriteStringValue(person.GivenName);
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(person.Iid);
                    writer.WritePropertyName("isActive"u8);
                    writer.WriteBooleanValue(person.IsActive);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(person.IsDeprecated);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(person.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("organization"u8);

                    if (person.Organization.HasValue)
                    {
                        writer.WriteStringValue(person.Organization.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("organizationalUnit"u8);
                    writer.WriteStringValue(person.OrganizationalUnit);
                    writer.WritePropertyName("password"u8);
                    writer.WriteStringValue(person.Password);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(person.RevisionNumber);
                    writer.WritePropertyName("role"u8);

                    if (person.Role.HasValue)
                    {
                        writer.WriteStringValue(person.Role.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(person.ShortName);
                    writer.WritePropertyName("surname"u8);
                    writer.WriteStringValue(person.Surname);
                    writer.WriteStartArray("telephoneNumber"u8);

                    foreach(var telephoneNumberItem in person.TelephoneNumber.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(telephoneNumberItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(person.ThingPreference);
                    writer.WriteStartArray("userPreference"u8);

                    foreach(var userPreferenceItem in person.UserPreference.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(userPreferenceItem);
                    }

                    writer.WriteEndArray();
                    
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
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="Person" /></exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer)
        {
            if (thing is not Person person)
            {
                throw new ArgumentException("The thing shall be a Person", nameof(thing));
            }

            writer.WriteStartObject();

                writer.WritePropertyName("classKind"u8);
                writer.WriteStringValue(person.ClassKind.ToString());
                writer.WritePropertyName("defaultDomain"u8);

                if (person.DefaultDomain.HasValue)
                {
                    writer.WriteStringValue(person.DefaultDomain.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WritePropertyName("defaultEmailAddress"u8);

                if (person.DefaultEmailAddress.HasValue)
                {
                    writer.WriteStringValue(person.DefaultEmailAddress.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WritePropertyName("defaultTelephoneNumber"u8);

                if (person.DefaultTelephoneNumber.HasValue)
                {
                    writer.WriteStringValue(person.DefaultTelephoneNumber.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WriteStartArray("emailAddress"u8);

                foreach(var emailAddressItem in person.EmailAddress.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(emailAddressItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedDomain"u8);

                foreach(var excludedDomainItem in person.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedDomainItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedPerson"u8);

                foreach(var excludedPersonItem in person.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedPersonItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("givenName"u8);
                writer.WriteStringValue(person.GivenName);
                writer.WritePropertyName("iid"u8);
                writer.WriteStringValue(person.Iid);
                writer.WritePropertyName("isActive"u8);
                writer.WriteBooleanValue(person.IsActive);
                writer.WritePropertyName("isDeprecated"u8);
                writer.WriteBooleanValue(person.IsDeprecated);
                writer.WritePropertyName("modifiedOn"u8);
                writer.WriteStringValue(person.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                writer.WritePropertyName("organization"u8);

                if (person.Organization.HasValue)
                {
                    writer.WriteStringValue(person.Organization.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WritePropertyName("organizationalUnit"u8);
                writer.WriteStringValue(person.OrganizationalUnit);
                writer.WritePropertyName("password"u8);
                writer.WriteStringValue(person.Password);
                writer.WritePropertyName("revisionNumber"u8);
                writer.WriteNumberValue(person.RevisionNumber);
                writer.WritePropertyName("role"u8);

                if (person.Role.HasValue)
                {
                    writer.WriteStringValue(person.Role.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WritePropertyName("shortName"u8);
                writer.WriteStringValue(person.ShortName);
                writer.WritePropertyName("surname"u8);
                writer.WriteStringValue(person.Surname);

                writer.WriteStartArray("telephoneNumber"u8);

                foreach(var telephoneNumberItem in person.TelephoneNumber.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(telephoneNumberItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("thingPreference"u8);
                writer.WriteStringValue(person.ThingPreference);

                writer.WriteStartArray("userPreference"u8);

                foreach(var userPreferenceItem in person.UserPreference.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(userPreferenceItem);
                }

                writer.WriteEndArray();
                

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="Person"/> property into a <see cref="Utf8JsonWriter" />
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
        /// Serialize a value for a <see cref="Person"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer)
        {
            switch(propertyName.ToLower())
            {
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
                case "defaultdomain":
                    writer.WritePropertyName("defaultDomain"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "defaultemailaddress":
                    writer.WritePropertyName("defaultEmailAddress"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "defaulttelephonenumber":
                    writer.WritePropertyName("defaultTelephoneNumber"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "emailaddress":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListEmailAddress && objectListEmailAddress.Any())
                    {
                        writer.WriteStartArray("emailAddress"u8);

                        foreach(var emailAddressItem in objectListEmailAddress.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(emailAddressItem);
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
                case "givenname":
                    writer.WritePropertyName("givenName"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
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
                case "isactive":
                    writer.WritePropertyName("isActive"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "isdeprecated":
                    writer.WritePropertyName("isDeprecated"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
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
                case "organization":
                    writer.WritePropertyName("organization"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "organizationalunit":
                    writer.WritePropertyName("organizationalUnit"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "password":
                    writer.WritePropertyName("password"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
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
                case "role":
                    writer.WritePropertyName("role"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
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
                case "surname":
                    writer.WritePropertyName("surname"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "telephonenumber":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListTelephoneNumber && objectListTelephoneNumber.Any())
                    {
                        writer.WriteStartArray("telephoneNumber"u8);

                        foreach(var telephoneNumberItem in objectListTelephoneNumber.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(telephoneNumberItem);
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
                case "userpreference":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListUserPreference && objectListUserPreference.Any())
                    {
                        writer.WriteStartArray("userPreference"u8);

                        foreach(var userPreferenceItem in objectListUserPreference.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(userPreferenceItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the Person");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "classKind", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "defaultDomain", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "defaultEmailAddress", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "defaultTelephoneNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "emailAddress", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "givenName", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "isActive", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "isDeprecated", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "organization", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "organizationalUnit", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "password", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "role", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "shortName", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "surname", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "telephoneNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
            { "userPreference", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
