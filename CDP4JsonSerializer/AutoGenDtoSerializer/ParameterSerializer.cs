// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSerializer.cs" company="RHEA System S.A.">
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
    using Parameter = CDP4Common.DTO.Parameter;

    /// <summary>
    /// The purpose of the <see cref="ParameterSerializer"/> class is to provide a <see cref="Parameter"/> specific serializer
    /// </summary>
    public class ParameterSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="Parameter"/> property into a <see cref="Utf8JsonWriter" />
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
                case "allowdifferentownerofoverride":
                    var allowedVersionsForAllowDifferentOwnerOfOverride = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForAllowDifferentOwnerOfOverride.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("allowDifferentOwnerOfOverride"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
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
                case "expectsoverride":
                    var allowedVersionsForExpectsOverride = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExpectsOverride.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("expectsOverride"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "group":
                    var allowedVersionsForGroup = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForGroup.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("group"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
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
                case "isoptiondependent":
                    var allowedVersionsForIsOptionDependent = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForIsOptionDependent.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("isOptionDependent"u8);
                    
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
                case "parametersubscription":
                    var allowedVersionsForParameterSubscription = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForParameterSubscription.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("parameterSubscription"u8);

                    if(value is IEnumerable<object> objectListParameterSubscription)
                    {
                        foreach(var parameterSubscriptionItem in objectListParameterSubscription.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(parameterSubscriptionItem);
                        }
                    }
                    
                    writer.WriteEndArray();
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
                case "requestedby":
                    var allowedVersionsForRequestedBy = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForRequestedBy.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("requestedBy"u8);
                    
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
                case "statedependence":
                    var allowedVersionsForStateDependence = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForStateDependence.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("stateDependence"u8);
                    
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
                case "valueset":
                    var allowedVersionsForValueSet = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForValueSet.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("valueSet"u8);

                    if(value is IEnumerable<object> objectListValueSet)
                    {
                        foreach(var valueSetItem in objectListValueSet.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(valueSetItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the Parameter");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="Parameter" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not Parameter parameter)
            {
                throw new ArgumentException("The thing shall be a Parameter", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of Parameter since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Debug, "Serializing Parameter for Version 1.0.0");
                    writer.WritePropertyName("allowDifferentOwnerOfOverride"u8);
                    writer.WriteBooleanValue(parameter.AllowDifferentOwnerOfOverride);
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameter.ClassKind.ToString());
                    writer.WritePropertyName("expectsOverride"u8);
                    writer.WriteBooleanValue(parameter.ExpectsOverride);
                    writer.WritePropertyName("group"u8);

                    if(parameter.Group.HasValue)
                    {
                        writer.WriteStringValue(parameter.Group.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameter.Iid);
                    writer.WritePropertyName("isOptionDependent"u8);
                    writer.WriteBooleanValue(parameter.IsOptionDependent);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(parameter.Owner);
                    writer.WriteStartArray("parameterSubscription"u8);

                    foreach(var parameterSubscriptionItem in parameter.ParameterSubscription.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterSubscriptionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("parameterType"u8);
                    writer.WriteStringValue(parameter.ParameterType);
                    writer.WritePropertyName("requestedBy"u8);

                    if(parameter.RequestedBy.HasValue)
                    {
                        writer.WriteStringValue(parameter.RequestedBy.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameter.RevisionNumber);
                    writer.WritePropertyName("scale"u8);

                    if(parameter.Scale.HasValue)
                    {
                        writer.WriteStringValue(parameter.Scale.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("stateDependence"u8);

                    if(parameter.StateDependence.HasValue)
                    {
                        writer.WriteStringValue(parameter.StateDependence.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("valueSet"u8);

                    foreach(var valueSetItem in parameter.ValueSet.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueSetItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing Parameter for Version 1.1.0");
                    writer.WritePropertyName("allowDifferentOwnerOfOverride"u8);
                    writer.WriteBooleanValue(parameter.AllowDifferentOwnerOfOverride);
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameter.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameter.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameter.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("expectsOverride"u8);
                    writer.WriteBooleanValue(parameter.ExpectsOverride);
                    writer.WritePropertyName("group"u8);

                    if(parameter.Group.HasValue)
                    {
                        writer.WriteStringValue(parameter.Group.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameter.Iid);
                    writer.WritePropertyName("isOptionDependent"u8);
                    writer.WriteBooleanValue(parameter.IsOptionDependent);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameter.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(parameter.Owner);
                    writer.WriteStartArray("parameterSubscription"u8);

                    foreach(var parameterSubscriptionItem in parameter.ParameterSubscription.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterSubscriptionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("parameterType"u8);
                    writer.WriteStringValue(parameter.ParameterType);
                    writer.WritePropertyName("requestedBy"u8);

                    if(parameter.RequestedBy.HasValue)
                    {
                        writer.WriteStringValue(parameter.RequestedBy.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameter.RevisionNumber);
                    writer.WritePropertyName("scale"u8);

                    if(parameter.Scale.HasValue)
                    {
                        writer.WriteStringValue(parameter.Scale.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("stateDependence"u8);

                    if(parameter.StateDependence.HasValue)
                    {
                        writer.WriteStringValue(parameter.StateDependence.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("valueSet"u8);

                    foreach(var valueSetItem in parameter.ValueSet.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueSetItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing Parameter for Version 1.2.0");
                    writer.WritePropertyName("allowDifferentOwnerOfOverride"u8);
                    writer.WriteBooleanValue(parameter.AllowDifferentOwnerOfOverride);
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameter.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameter.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameter.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("expectsOverride"u8);
                    writer.WriteBooleanValue(parameter.ExpectsOverride);
                    writer.WritePropertyName("group"u8);

                    if(parameter.Group.HasValue)
                    {
                        writer.WriteStringValue(parameter.Group.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameter.Iid);
                    writer.WritePropertyName("isOptionDependent"u8);
                    writer.WriteBooleanValue(parameter.IsOptionDependent);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameter.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(parameter.Owner);
                    writer.WriteStartArray("parameterSubscription"u8);

                    foreach(var parameterSubscriptionItem in parameter.ParameterSubscription.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterSubscriptionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("parameterType"u8);
                    writer.WriteStringValue(parameter.ParameterType);
                    writer.WritePropertyName("requestedBy"u8);

                    if(parameter.RequestedBy.HasValue)
                    {
                        writer.WriteStringValue(parameter.RequestedBy.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameter.RevisionNumber);
                    writer.WritePropertyName("scale"u8);

                    if(parameter.Scale.HasValue)
                    {
                        writer.WriteStringValue(parameter.Scale.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("stateDependence"u8);

                    if(parameter.StateDependence.HasValue)
                    {
                        writer.WriteStringValue(parameter.StateDependence.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(parameter.ThingPreference);
                    writer.WriteStartArray("valueSet"u8);

                    foreach(var valueSetItem in parameter.ValueSet.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueSetItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing Parameter for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(parameter.Actor.HasValue)
                    {
                        writer.WriteStringValue(parameter.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("allowDifferentOwnerOfOverride"u8);
                    writer.WriteBooleanValue(parameter.AllowDifferentOwnerOfOverride);
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameter.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameter.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameter.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("expectsOverride"u8);
                    writer.WriteBooleanValue(parameter.ExpectsOverride);
                    writer.WritePropertyName("group"u8);

                    if(parameter.Group.HasValue)
                    {
                        writer.WriteStringValue(parameter.Group.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameter.Iid);
                    writer.WritePropertyName("isOptionDependent"u8);
                    writer.WriteBooleanValue(parameter.IsOptionDependent);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameter.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(parameter.Owner);
                    writer.WriteStartArray("parameterSubscription"u8);

                    foreach(var parameterSubscriptionItem in parameter.ParameterSubscription.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterSubscriptionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("parameterType"u8);
                    writer.WriteStringValue(parameter.ParameterType);
                    writer.WritePropertyName("requestedBy"u8);

                    if(parameter.RequestedBy.HasValue)
                    {
                        writer.WriteStringValue(parameter.RequestedBy.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameter.RevisionNumber);
                    writer.WritePropertyName("scale"u8);

                    if(parameter.Scale.HasValue)
                    {
                        writer.WriteStringValue(parameter.Scale.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("stateDependence"u8);

                    if(parameter.StateDependence.HasValue)
                    {
                        writer.WriteStringValue(parameter.StateDependence.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(parameter.ThingPreference);
                    writer.WriteStartArray("valueSet"u8);

                    foreach(var valueSetItem in parameter.ValueSet.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueSetItem);
                    }

                    writer.WriteEndArray();
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
