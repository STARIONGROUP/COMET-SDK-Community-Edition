// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalIdentifierMapSerializer.cs" company="RHEA System S.A.">
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
    using ExternalIdentifierMap = CDP4Common.DTO.ExternalIdentifierMap;

    /// <summary>
    /// The purpose of the <see cref="ExternalIdentifierMapSerializer"/> class is to provide a <see cref="ExternalIdentifierMap"/> specific serializer
    /// </summary>
    public class ExternalIdentifierMapSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="ExternalIdentifierMap"/> property into a <see cref="Utf8JsonWriter" />
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
                case "correspondence":
                    var allowedVersionsForCorrespondence = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForCorrespondence.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("correspondence"u8);

                    if(value is IEnumerable<object> objectListCorrespondence)
                    {
                        foreach(var correspondenceItem in objectListCorrespondence.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(correspondenceItem);
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
                case "externalformat":
                    var allowedVersionsForExternalFormat = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExternalFormat.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("externalFormat"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "externalmodelname":
                    var allowedVersionsForExternalModelName = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExternalModelName.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("externalModelName"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "externaltoolname":
                    var allowedVersionsForExternalToolName = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExternalToolName.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("externalToolName"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "externaltoolversion":
                    var allowedVersionsForExternalToolVersion = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExternalToolVersion.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("externalToolVersion"u8);
                    
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
                case "name":
                    var allowedVersionsForName = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForName.Contains(requestedVersion))
                    {
                        return;
                    }

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
                case "owner":
                    var allowedVersionsForOwner = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForOwner.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the ExternalIdentifierMap");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ExternalIdentifierMap" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not ExternalIdentifierMap externalIdentifierMap)
            {
                throw new ArgumentException("The thing shall be a ExternalIdentifierMap", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of ExternalIdentifierMap since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Debug, "Serializing ExternalIdentifierMap for Version 1.0.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(externalIdentifierMap.ClassKind.ToString());
                    writer.WriteStartArray("correspondence"u8);

                    foreach(var correspondenceItem in externalIdentifierMap.Correspondence.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(correspondenceItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("externalFormat"u8);

                    if(externalIdentifierMap.ExternalFormat.HasValue)
                    {
                        writer.WriteStringValue(externalIdentifierMap.ExternalFormat.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("externalModelName"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalModelName);
                    writer.WritePropertyName("externalToolName"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalToolName);
                    writer.WritePropertyName("externalToolVersion"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalToolVersion);
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(externalIdentifierMap.Iid);
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(externalIdentifierMap.Name);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(externalIdentifierMap.Owner);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(externalIdentifierMap.RevisionNumber);
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing ExternalIdentifierMap for Version 1.1.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(externalIdentifierMap.ClassKind.ToString());
                    writer.WriteStartArray("correspondence"u8);

                    foreach(var correspondenceItem in externalIdentifierMap.Correspondence.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(correspondenceItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in externalIdentifierMap.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in externalIdentifierMap.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("externalFormat"u8);

                    if(externalIdentifierMap.ExternalFormat.HasValue)
                    {
                        writer.WriteStringValue(externalIdentifierMap.ExternalFormat.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("externalModelName"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalModelName);
                    writer.WritePropertyName("externalToolName"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalToolName);
                    writer.WritePropertyName("externalToolVersion"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalToolVersion);
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(externalIdentifierMap.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(externalIdentifierMap.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(externalIdentifierMap.Name);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(externalIdentifierMap.Owner);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(externalIdentifierMap.RevisionNumber);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing ExternalIdentifierMap for Version 1.2.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(externalIdentifierMap.ClassKind.ToString());
                    writer.WriteStartArray("correspondence"u8);

                    foreach(var correspondenceItem in externalIdentifierMap.Correspondence.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(correspondenceItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in externalIdentifierMap.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in externalIdentifierMap.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("externalFormat"u8);

                    if(externalIdentifierMap.ExternalFormat.HasValue)
                    {
                        writer.WriteStringValue(externalIdentifierMap.ExternalFormat.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("externalModelName"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalModelName);
                    writer.WritePropertyName("externalToolName"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalToolName);
                    writer.WritePropertyName("externalToolVersion"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalToolVersion);
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(externalIdentifierMap.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(externalIdentifierMap.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(externalIdentifierMap.Name);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(externalIdentifierMap.Owner);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(externalIdentifierMap.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(externalIdentifierMap.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing ExternalIdentifierMap for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(externalIdentifierMap.Actor.HasValue)
                    {
                        writer.WriteStringValue(externalIdentifierMap.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(externalIdentifierMap.ClassKind.ToString());
                    writer.WriteStartArray("correspondence"u8);

                    foreach(var correspondenceItem in externalIdentifierMap.Correspondence.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(correspondenceItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in externalIdentifierMap.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in externalIdentifierMap.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("externalFormat"u8);

                    if(externalIdentifierMap.ExternalFormat.HasValue)
                    {
                        writer.WriteStringValue(externalIdentifierMap.ExternalFormat.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("externalModelName"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalModelName);
                    writer.WritePropertyName("externalToolName"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalToolName);
                    writer.WritePropertyName("externalToolVersion"u8);
                    writer.WriteStringValue(externalIdentifierMap.ExternalToolVersion);
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(externalIdentifierMap.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(externalIdentifierMap.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(externalIdentifierMap.Name);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(externalIdentifierMap.Owner);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(externalIdentifierMap.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(externalIdentifierMap.ThingPreference);
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
