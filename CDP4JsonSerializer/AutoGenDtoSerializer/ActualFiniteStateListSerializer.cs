// -------------------------------------------------------------------------------------------------------------------------------// <copyright file="ActualFiniteStateListSerializer.cs" company="Starion Group S.A.">
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
    using ActualFiniteStateList = CDP4Common.DTO.ActualFiniteStateList;

    /// <summary>
    /// The purpose of the <see cref="ActualFiniteStateListSerializer"/> class is to provide a <see cref="ActualFiniteStateList"/> specific serializer
    /// </summary>
    public class ActualFiniteStateListSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="ActualFiniteStateList" />.
        /// An error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version minimalAllowedDataModelVersion = Version.Parse("1.0.0");

        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="ActualFiniteStateList" />.
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
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ActualFiniteStateList" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not ActualFiniteStateList actualFiniteStateList)
            {
                throw new ArgumentException("The thing shall be a ActualFiniteStateList", nameof(thing));
            }

            if (requestedDataModelVersion < minimalAllowedDataModelVersion)
            {
                throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported for serialization of ActualFiniteStateList.");
            }

            if (requestedDataModelVersion < thingMinimalAllowedDataModelVersion)
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of ActualFiniteStateList since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Trace, "Serializing ActualFiniteStateList for Version 1.0.0");
                    writer.WriteStartArray("actualState"u8);

                    foreach(var actualStateItem in actualFiniteStateList.ActualState.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(actualStateItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(actualFiniteStateList.ClassKind.ToString());
                    writer.WriteStartArray("excludeOption"u8);

                    foreach(var excludeOptionItem in actualFiniteStateList.ExcludeOption.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludeOptionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(actualFiniteStateList.Iid);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(actualFiniteStateList.Owner);
                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    foreach(var possibleFiniteStateListItem in actualFiniteStateList.PossibleFiniteStateList.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(possibleFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(actualFiniteStateList.RevisionNumber);
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Trace, "Serializing ActualFiniteStateList for Version 1.1.0");
                    writer.WriteStartArray("actualState"u8);

                    foreach(var actualStateItem in actualFiniteStateList.ActualState.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(actualStateItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(actualFiniteStateList.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in actualFiniteStateList.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in actualFiniteStateList.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludeOption"u8);

                    foreach(var excludeOptionItem in actualFiniteStateList.ExcludeOption.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludeOptionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(actualFiniteStateList.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(actualFiniteStateList.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(actualFiniteStateList.Owner);
                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    foreach(var possibleFiniteStateListItem in actualFiniteStateList.PossibleFiniteStateList.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(possibleFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(actualFiniteStateList.RevisionNumber);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing ActualFiniteStateList for Version 1.2.0");
                    writer.WriteStartArray("actualState"u8);

                    foreach(var actualStateItem in actualFiniteStateList.ActualState.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(actualStateItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(actualFiniteStateList.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in actualFiniteStateList.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in actualFiniteStateList.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludeOption"u8);

                    foreach(var excludeOptionItem in actualFiniteStateList.ExcludeOption.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludeOptionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(actualFiniteStateList.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(actualFiniteStateList.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(actualFiniteStateList.Owner);
                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    foreach(var possibleFiniteStateListItem in actualFiniteStateList.PossibleFiniteStateList.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(possibleFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(actualFiniteStateList.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(actualFiniteStateList.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing ActualFiniteStateList for Version 1.3.0");
                    writer.WriteStartArray("actualState"u8);

                    foreach(var actualStateItem in actualFiniteStateList.ActualState.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(actualStateItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(actualFiniteStateList.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in actualFiniteStateList.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in actualFiniteStateList.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludeOption"u8);

                    foreach(var excludeOptionItem in actualFiniteStateList.ExcludeOption.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludeOptionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(actualFiniteStateList.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(actualFiniteStateList.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(actualFiniteStateList.Owner);
                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    foreach(var possibleFiniteStateListItem in actualFiniteStateList.PossibleFiniteStateList.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(possibleFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(actualFiniteStateList.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(actualFiniteStateList.ThingPreference);
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
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ActualFiniteStateList" /></exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer)
        {
            if (thing is not ActualFiniteStateList actualFiniteStateList)
            {
                throw new ArgumentException("The thing shall be a ActualFiniteStateList", nameof(thing));
            }

            writer.WriteStartObject();

                writer.WriteStartArray("actualState"u8);

                foreach(var actualStateItem in actualFiniteStateList.ActualState.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(actualStateItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("classKind"u8);
                writer.WriteStringValue(actualFiniteStateList.ClassKind.ToString());

                writer.WriteStartArray("excludedDomain"u8);

                foreach(var excludedDomainItem in actualFiniteStateList.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedDomainItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedPerson"u8);

                foreach(var excludedPersonItem in actualFiniteStateList.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedPersonItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludeOption"u8);

                foreach(var excludeOptionItem in actualFiniteStateList.ExcludeOption.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludeOptionItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("iid"u8);
                writer.WriteStringValue(actualFiniteStateList.Iid);
                writer.WritePropertyName("modifiedOn"u8);
                writer.WriteStringValue(actualFiniteStateList.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                writer.WritePropertyName("owner"u8);
                writer.WriteStringValue(actualFiniteStateList.Owner);

                writer.WriteStartArray("possibleFiniteStateList"u8);

                foreach(var possibleFiniteStateListItem in actualFiniteStateList.PossibleFiniteStateList.OrderBy(x => x, this.OrderedItemComparer))
                {
                    writer.WriteOrderedItem(possibleFiniteStateListItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("revisionNumber"u8);
                writer.WriteNumberValue(actualFiniteStateList.RevisionNumber);
                writer.WritePropertyName("thingPreference"u8);
                writer.WriteStringValue(actualFiniteStateList.ThingPreference);

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="ActualFiniteStateList"/> property into a <see cref="Utf8JsonWriter" />
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
        /// Serialize a value for a <see cref="ActualFiniteStateList"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer)
        {
            switch(propertyName.ToLower())
            {
                case "actualstate":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListActualState && objectListActualState.Any())
                    {
                        writer.WriteStartArray("actualState"u8);

                        foreach(var actualStateItem in objectListActualState.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(actualStateItem);
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
                case "excludeoption":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListExcludeOption && objectListExcludeOption.Any())
                    {
                        writer.WriteStartArray("excludeOption"u8);

                        foreach(var excludeOptionItem in objectListExcludeOption.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludeOptionItem);
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
                case "owner":
                    writer.WritePropertyName("owner"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "possiblefinitestatelist":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListPossibleFiniteStateList && objectListPossibleFiniteStateList.Any())
                    {
                        writer.WriteStartArray("possibleFiniteStateList"u8);

                        foreach(var possibleFiniteStateListItem in objectListPossibleFiniteStateList.OfType<OrderedItem>().OrderBy(x => x, this.OrderedItemComparer))
                        {
                            writer.WriteOrderedItem(possibleFiniteStateListItem);
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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the ActualFiniteStateList");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "actualState", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "classKind", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludeOption", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "owner", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "possibleFiniteStateList", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
