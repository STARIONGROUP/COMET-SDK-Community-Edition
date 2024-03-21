// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypeComponentSerializer.cs" company="RHEA System S.A.">
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
    using ParameterTypeComponent = CDP4Common.DTO.ParameterTypeComponent;

    /// <summary>
    /// The purpose of the <see cref="ParameterTypeComponentSerializer"/> class is to provide a <see cref="ParameterTypeComponent"/> specific serializer
    /// </summary>
    public class ParameterTypeComponentSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="ParameterTypeComponent"/> property into a <see cref="Utf8JsonWriter" />
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
                case "parametertype":
                    var allowedVersionsForParameterType = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForParameterType.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("parameterType"u8);
                    
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
                case "scale":
                    var allowedVersionsForScale = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForScale.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("scale"u8);
                    
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
                    var allowedVersionsForShortName = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForShortName.Contains(requestedVersion))
                    {
                        return;
                    }

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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the ParameterTypeComponent");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ParameterTypeComponent" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not ParameterTypeComponent parameterTypeComponent)
            {
                throw new ArgumentException("The thing shall be a ParameterTypeComponent", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of ParameterTypeComponent since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Debug, "Serializing ParameterTypeComponent for Version 1.0.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameterTypeComponent.ClassKind.ToString());
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameterTypeComponent.Iid);
                    writer.WritePropertyName("parameterType"u8);
                    writer.WriteStringValue(parameterTypeComponent.ParameterType);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameterTypeComponent.RevisionNumber);
                    writer.WritePropertyName("scale"u8);

                    if(parameterTypeComponent.Scale.HasValue)
                    {
                        writer.WriteStringValue(parameterTypeComponent.Scale.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(parameterTypeComponent.ShortName);
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing ParameterTypeComponent for Version 1.1.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameterTypeComponent.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameterTypeComponent.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameterTypeComponent.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameterTypeComponent.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameterTypeComponent.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("parameterType"u8);
                    writer.WriteStringValue(parameterTypeComponent.ParameterType);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameterTypeComponent.RevisionNumber);
                    writer.WritePropertyName("scale"u8);

                    if(parameterTypeComponent.Scale.HasValue)
                    {
                        writer.WriteStringValue(parameterTypeComponent.Scale.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(parameterTypeComponent.ShortName);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing ParameterTypeComponent for Version 1.2.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameterTypeComponent.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameterTypeComponent.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameterTypeComponent.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameterTypeComponent.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameterTypeComponent.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("parameterType"u8);
                    writer.WriteStringValue(parameterTypeComponent.ParameterType);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameterTypeComponent.RevisionNumber);
                    writer.WritePropertyName("scale"u8);

                    if(parameterTypeComponent.Scale.HasValue)
                    {
                        writer.WriteStringValue(parameterTypeComponent.Scale.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(parameterTypeComponent.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(parameterTypeComponent.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing ParameterTypeComponent for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(parameterTypeComponent.Actor.HasValue)
                    {
                        writer.WriteStringValue(parameterTypeComponent.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameterTypeComponent.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameterTypeComponent.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameterTypeComponent.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameterTypeComponent.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameterTypeComponent.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("parameterType"u8);
                    writer.WriteStringValue(parameterTypeComponent.ParameterType);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameterTypeComponent.RevisionNumber);
                    writer.WritePropertyName("scale"u8);

                    if(parameterTypeComponent.Scale.HasValue)
                    {
                        writer.WriteStringValue(parameterTypeComponent.Scale.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(parameterTypeComponent.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(parameterTypeComponent.ThingPreference);
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
