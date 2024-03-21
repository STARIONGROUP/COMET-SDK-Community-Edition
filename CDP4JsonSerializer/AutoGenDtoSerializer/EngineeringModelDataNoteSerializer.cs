// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataNoteSerializer.cs" company="RHEA System S.A.">
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
    using EngineeringModelDataNote = CDP4Common.DTO.EngineeringModelDataNote;

    /// <summary>
    /// The purpose of the <see cref="EngineeringModelDataNoteSerializer"/> class is to provide a <see cref="EngineeringModelDataNote"/> specific serializer
    /// </summary>
    public class EngineeringModelDataNoteSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="EngineeringModelDataNote"/> property into a <see cref="Utf8JsonWriter" />
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
                case "author":
                    var allowedVersionsForAuthor = new List<string>
                    {
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
                case "classkind":
                    var allowedVersionsForClassKind = new List<string>
                    {
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
                case "discussion":
                    var allowedVersionsForDiscussion = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForDiscussion.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("discussion"u8);

                    if(value is IEnumerable<object> objectListDiscussion)
                    {
                        foreach(var discussionItem in objectListDiscussion.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(discussionItem);
                        }
                    }
                    
                    writer.WriteEndArray();
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
                case "primaryannotatedthing":
                    var allowedVersionsForPrimaryAnnotatedThing = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForPrimaryAnnotatedThing.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("primaryAnnotatedThing"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "relatedthing":
                    var allowedVersionsForRelatedThing = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForRelatedThing.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    if(value is IEnumerable<object> objectListRelatedThing)
                    {
                        foreach(var relatedThingItem in objectListRelatedThing.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(relatedThingItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "revisionnumber":
                    var allowedVersionsForRevisionNumber = new List<string>
                    {
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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the EngineeringModelDataNote");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="EngineeringModelDataNote" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not EngineeringModelDataNote engineeringModelDataNote)
            {
                throw new ArgumentException("The thing shall be a EngineeringModelDataNote", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.1.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of EngineeringModelDataNote since Version is below 1.1.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing EngineeringModelDataNote for Version 1.1.0");
                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Author);
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(engineeringModelDataNote.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(engineeringModelDataNote.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in engineeringModelDataNote.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in engineeringModelDataNote.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in engineeringModelDataNote.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(engineeringModelDataNote.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(engineeringModelDataNote.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if(engineeringModelDataNote.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelDataNote.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in engineeringModelDataNote.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(engineeringModelDataNote.RevisionNumber);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing EngineeringModelDataNote for Version 1.2.0");
                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Author);
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(engineeringModelDataNote.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(engineeringModelDataNote.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in engineeringModelDataNote.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in engineeringModelDataNote.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in engineeringModelDataNote.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(engineeringModelDataNote.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(engineeringModelDataNote.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if(engineeringModelDataNote.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelDataNote.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in engineeringModelDataNote.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(engineeringModelDataNote.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(engineeringModelDataNote.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing EngineeringModelDataNote for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(engineeringModelDataNote.Actor.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelDataNote.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("author"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Author);
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(engineeringModelDataNote.ClassKind.ToString());
                    writer.WritePropertyName("content"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Content);
                    writer.WritePropertyName("createdOn"u8);
                    writer.WriteStringValue(engineeringModelDataNote.CreatedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("discussion"u8);

                    foreach(var discussionItem in engineeringModelDataNote.Discussion.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(discussionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in engineeringModelDataNote.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in engineeringModelDataNote.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(engineeringModelDataNote.Iid);
                    writer.WritePropertyName("languageCode"u8);
                    writer.WriteStringValue(engineeringModelDataNote.LanguageCode);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(engineeringModelDataNote.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("primaryAnnotatedThing"u8);

                    if(engineeringModelDataNote.PrimaryAnnotatedThing.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelDataNote.PrimaryAnnotatedThing.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("relatedThing"u8);

                    foreach(var relatedThingItem in engineeringModelDataNote.RelatedThing.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relatedThingItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(engineeringModelDataNote.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(engineeringModelDataNote.ThingPreference);
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
