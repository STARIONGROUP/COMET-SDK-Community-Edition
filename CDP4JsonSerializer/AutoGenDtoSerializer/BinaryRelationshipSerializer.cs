// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipSerializer.cs" company="RHEA System S.A.">
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
    using BinaryRelationship = CDP4Common.DTO.BinaryRelationship;

    /// <summary>
    /// The purpose of the <see cref="BinaryRelationshipSerializer"/> class is to provide a <see cref="BinaryRelationship"/> specific serializer
    /// </summary>
    public class BinaryRelationshipSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="BinaryRelationship"/> property into a <see cref="Utf8JsonWriter" />
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
                case "parametervalue":
                    var allowedVersionsForParameterValue = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForParameterValue.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("parameterValue"u8);

                    if(value is IEnumerable<object> objectListParameterValue)
                    {
                        foreach(var parameterValueItem in objectListParameterValue.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(parameterValueItem);
                        }
                    }
                    
                    writer.WriteEndArray();
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
                case "source":
                    var allowedVersionsForSource = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForSource.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("source"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "target":
                    var allowedVersionsForTarget = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForTarget.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("target"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the BinaryRelationship");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="BinaryRelationship" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not BinaryRelationship binaryRelationship)
            {
                throw new ArgumentException("The thing shall be a BinaryRelationship", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of BinaryRelationship since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Debug, "Serializing BinaryRelationship for Version 1.0.0");
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in binaryRelationship.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(binaryRelationship.ClassKind.ToString());
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(binaryRelationship.Iid);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(binaryRelationship.Owner);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(binaryRelationship.RevisionNumber);
                    writer.WritePropertyName("source"u8);
                    writer.WriteStringValue(binaryRelationship.Source);
                    writer.WritePropertyName("target"u8);
                    writer.WriteStringValue(binaryRelationship.Target);
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing BinaryRelationship for Version 1.1.0");
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in binaryRelationship.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(binaryRelationship.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in binaryRelationship.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in binaryRelationship.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(binaryRelationship.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(binaryRelationship.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(binaryRelationship.Owner);
                    writer.WriteStartArray("parameterValue"u8);

                    foreach(var parameterValueItem in binaryRelationship.ParameterValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterValueItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(binaryRelationship.RevisionNumber);
                    writer.WritePropertyName("source"u8);
                    writer.WriteStringValue(binaryRelationship.Source);
                    writer.WritePropertyName("target"u8);
                    writer.WriteStringValue(binaryRelationship.Target);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing BinaryRelationship for Version 1.2.0");
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in binaryRelationship.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(binaryRelationship.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in binaryRelationship.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in binaryRelationship.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(binaryRelationship.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(binaryRelationship.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(binaryRelationship.Name);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(binaryRelationship.Owner);
                    writer.WriteStartArray("parameterValue"u8);

                    foreach(var parameterValueItem in binaryRelationship.ParameterValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterValueItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(binaryRelationship.RevisionNumber);
                    writer.WritePropertyName("source"u8);
                    writer.WriteStringValue(binaryRelationship.Source);
                    writer.WritePropertyName("target"u8);
                    writer.WriteStringValue(binaryRelationship.Target);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(binaryRelationship.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing BinaryRelationship for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(binaryRelationship.Actor.HasValue)
                    {
                        writer.WriteStringValue(binaryRelationship.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in binaryRelationship.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(binaryRelationship.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in binaryRelationship.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in binaryRelationship.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(binaryRelationship.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(binaryRelationship.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(binaryRelationship.Name);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(binaryRelationship.Owner);
                    writer.WriteStartArray("parameterValue"u8);

                    foreach(var parameterValueItem in binaryRelationship.ParameterValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterValueItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(binaryRelationship.RevisionNumber);
                    writer.WritePropertyName("source"u8);
                    writer.WriteStringValue(binaryRelationship.Source);
                    writer.WritePropertyName("target"u8);
                    writer.WriteStringValue(binaryRelationship.Target);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(binaryRelationship.ThingPreference);
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
