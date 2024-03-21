// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelLogEntrySerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NLog;

    using Thing = CDP4Common.DTO.Thing;
    using ModelLogEntry = CDP4Common.DTO.ModelLogEntry;

    /// <summary>
    /// The purpose of the <see cref="ModelLogEntrySerializer"/> class is to provide a <see cref="ModelLogEntry"/> specific serializer
    /// </summary>
    public class ModelLogEntrySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="ModelLogEntry"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            var requestedVersion = requestedDataModelVersion.ToString(3);

            switch(propertyName.ToLower())
            {
                case "actor":
                    var allowedVersionsForActor = new List<string>
                    {
                        "1.3.0",
                    };

                    if(!allowedVersionsForActor.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("actor"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "affecteddomainiid":
                    var allowedVersionsForAffectedDomainIid = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForAffectedDomainIid.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("affectedDomainIid"u8);

                    if(value is IEnumerable<object> objectListAffectedDomainIid)
                    {
                        foreach(var affectedDomainIidItem in objectListAffectedDomainIid)
                        {
                            writer.WriteStringValue((Guid)affectedDomainIidItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "affecteditemiid":
                    var allowedVersionsForAffectedItemIid = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForAffectedItemIid.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("affectedItemIid"u8);

                    if(value is IEnumerable<object> objectListAffectedItemIid)
                    {
                        foreach(var affectedItemIidItem in objectListAffectedItemIid)
                        {
                            writer.WriteStringValue((Guid)affectedItemIidItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "author":
                    var allowedVersionsForAuthor = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForAuthor.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("author"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "category":
                    var allowedVersionsForCategory = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForCategory.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("category"u8);

                    if(value is IEnumerable<object> objectListCategory)
                    {
                        foreach(var categoryItem in objectListCategory.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(categoryItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "classkind":
                    var allowedVersionsForClassKind = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForClassKind.Contains(requestedVersion))
                    {
                        return;
                    }

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
                case "content":
                    var allowedVersionsForContent = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForContent.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("content"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "createdon":
                    var allowedVersionsForCreatedOn = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForCreatedOn.Contains(requestedVersion))
                    {
                        return;
                    }

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
                case "excludeddomain":
                    var allowedVersionsForExcludedDomain = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExcludedDomain.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("excludedDomain"u8);

                    if(value is IEnumerable<object> objectListExcludedDomain)
                    {
                        foreach(var excludedDomainItem in objectListExcludedDomain.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedDomainItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "excludedperson":
                    var allowedVersionsForExcludedPerson = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExcludedPerson.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("excludedPerson"u8);

                    if(value is IEnumerable<object> objectListExcludedPerson)
                    {
                        foreach(var excludedPersonItem in objectListExcludedPerson.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedPersonItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "iid":
                    var allowedVersionsForIid = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForIid.Contains(requestedVersion))
                    {
                        return;
                    }

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
                case "languagecode":
                    var allowedVersionsForLanguageCode = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForLanguageCode.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("languageCode"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "level":
                    var allowedVersionsForLevel = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForLevel.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("level"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((LogLevelKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "logentrychangelogitem":
                    var allowedVersionsForLogEntryChangelogItem = new List<string>
                    {
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForLogEntryChangelogItem.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("logEntryChangelogItem"u8);

                    if(value is IEnumerable<object> objectListLogEntryChangelogItem)
                    {
                        foreach(var logEntryChangelogItemItem in objectListLogEntryChangelogItem.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(logEntryChangelogItemItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "modifiedon":
                    var allowedVersionsForModifiedOn = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForModifiedOn.Contains(requestedVersion))
                    {
                        return;
                    }

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
                case "revisionnumber":
                    var allowedVersionsForRevisionNumber = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForRevisionNumber.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    var allowedVersionsForThingPreference = new List<string>
                    {
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForThingPreference.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the ModelLogEntry");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ModelLogEntry" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not ModelLogEntry modelLogEntry)
            {
                throw new ArgumentException("The thing shall be a ModelLogEntry", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of ModelLogEntry since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Debug, "Serializing ModelLogEntry for Version 1.0.0");
                    writer.WriteStartArray("affectedDomainIid"u8);

                    foreach(var affectedDomainIidItem in modelLogEntry.AffectedDomainIid)
                    {
                        writer.WriteStringValue(affectedDomainIidItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("affectedItemIid"u8);

                    foreach(var affectedItemIidItem in modelLogEntry.AffectedItemIid)
                    {
                        writer.WriteStringValue(affectedItemIidItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("author"u8);

                    if(modelLogEntry.Author.HasValue)
                    {
                        writer.WriteStringValue(modelLogEntry.Author.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in modelLogEntry.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(modelLogEntry.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(modelLogEntry.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(modelLogEntry.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(modelLogEntry.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(modelLogEntry.LanguageCode);
                    writer.WritePropertyName("level"u8);
                    writer.WriteStringValue(modelLogEntry.Level.ToString());
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(modelLogEntry.RevisionNumber);
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing ModelLogEntry for Version 1.1.0");
                    writer.WriteStartArray("affectedDomainIid"u8);

                    foreach(var affectedDomainIidItem in modelLogEntry.AffectedDomainIid)
                    {
                        writer.WriteStringValue(affectedDomainIidItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("affectedItemIid"u8);

                    foreach(var affectedItemIidItem in modelLogEntry.AffectedItemIid)
                    {
                        writer.WriteStringValue(affectedItemIidItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("author"u8);

                    if(modelLogEntry.Author.HasValue)
                    {
                        writer.WriteStringValue(modelLogEntry.Author.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in modelLogEntry.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(modelLogEntry.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(modelLogEntry.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(modelLogEntry.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in modelLogEntry.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in modelLogEntry.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(modelLogEntry.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(modelLogEntry.LanguageCode);
                    writer.WritePropertyName("level"u8);
                    writer.WriteStringValue(modelLogEntry.Level.ToString());
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(modelLogEntry.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(modelLogEntry.RevisionNumber);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing ModelLogEntry for Version 1.2.0");
                    writer.WriteStartArray("affectedDomainIid"u8);

                    foreach(var affectedDomainIidItem in modelLogEntry.AffectedDomainIid)
                    {
                        writer.WriteStringValue(affectedDomainIidItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("affectedItemIid"u8);

                    foreach(var affectedItemIidItem in modelLogEntry.AffectedItemIid)
                    {
                        writer.WriteStringValue(affectedItemIidItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("author"u8);

                    if(modelLogEntry.Author.HasValue)
                    {
                        writer.WriteStringValue(modelLogEntry.Author.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in modelLogEntry.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(modelLogEntry.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(modelLogEntry.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(modelLogEntry.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in modelLogEntry.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in modelLogEntry.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(modelLogEntry.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(modelLogEntry.LanguageCode);
                    writer.WritePropertyName("level"u8);
                    writer.WriteStringValue(modelLogEntry.Level.ToString());
                    writer.WriteStartArray("logEntryChangelogItem"u8);

                    foreach(var logEntryChangelogItemItem in modelLogEntry.LogEntryChangelogItem.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(logEntryChangelogItemItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(modelLogEntry.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(modelLogEntry.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(modelLogEntry.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing ModelLogEntry for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(modelLogEntry.Actor.HasValue)
                    {
                        writer.WriteStringValue(modelLogEntry.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("affectedDomainIid"u8);

                    foreach(var affectedDomainIidItem in modelLogEntry.AffectedDomainIid)
                    {
                        writer.WriteStringValue(affectedDomainIidItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("affectedItemIid"u8);

                    foreach(var affectedItemIidItem in modelLogEntry.AffectedItemIid)
                    {
                        writer.WriteStringValue(affectedItemIidItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("author"u8);

                    if(modelLogEntry.Author.HasValue)
                    {
                        writer.WriteStringValue(modelLogEntry.Author.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in modelLogEntry.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(modelLogEntry.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(modelLogEntry.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(modelLogEntry.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in modelLogEntry.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in modelLogEntry.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(modelLogEntry.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(modelLogEntry.LanguageCode);
                    writer.WritePropertyName("level"u8);
                    writer.WriteStringValue(modelLogEntry.Level.ToString());
                    writer.WriteStartArray("logEntryChangelogItem"u8);

                    foreach(var logEntryChangelogItemItem in modelLogEntry.LogEntryChangelogItem.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(logEntryChangelogItemItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(modelLogEntry.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(modelLogEntry.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(modelLogEntry.ThingPreference);
                    break;
                default:
                    throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported");
            }

            writer.WriteEndObject();
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
