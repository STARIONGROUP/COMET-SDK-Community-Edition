// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetupSerializer.cs" company="RHEA System S.A.">
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
    using EngineeringModelSetup = CDP4Common.DTO.EngineeringModelSetup;

    /// <summary>
    /// The purpose of the <see cref="EngineeringModelSetupSerializer"/> class is to provide a <see cref="EngineeringModelSetup"/> specific serializer
    /// </summary>
    public class EngineeringModelSetupSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="EngineeringModelSetup"/> property into a <see cref="Utf8JsonWriter" />
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
                case "activedomain":
                    var allowedVersionsForActiveDomain = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForActiveDomain.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("activeDomain"u8);

                    if(value is IEnumerable<object> objectListActiveDomain)
                    {
                        foreach(var activeDomainItem in objectListActiveDomain.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(activeDomainItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
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
                case "alias":
                    var allowedVersionsForAlias = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForAlias.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("alias"u8);

                    if(value is IEnumerable<object> objectListAlias)
                    {
                        foreach(var aliasItem in objectListAlias.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(aliasItem);
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
                case "defaultorganizationalparticipant":
                    var allowedVersionsForDefaultOrganizationalParticipant = new List<string>
                    {
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForDefaultOrganizationalParticipant.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("defaultOrganizationalParticipant"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "definition":
                    var allowedVersionsForDefinition = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForDefinition.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("definition"u8);

                    if(value is IEnumerable<object> objectListDefinition)
                    {
                        foreach(var definitionItem in objectListDefinition.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(definitionItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "engineeringmodeliid":
                    var allowedVersionsForEngineeringModelIid = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForEngineeringModelIid.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("engineeringModelIid"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
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
                case "hyperlink":
                    var allowedVersionsForHyperLink = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForHyperLink.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("hyperLink"u8);

                    if(value is IEnumerable<object> objectListHyperLink)
                    {
                        foreach(var hyperLinkItem in objectListHyperLink.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(hyperLinkItem);
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
                case "iterationsetup":
                    var allowedVersionsForIterationSetup = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForIterationSetup.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("iterationSetup"u8);

                    if(value is IEnumerable<object> objectListIterationSetup)
                    {
                        foreach(var iterationSetupItem in objectListIterationSetup.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(iterationSetupItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "kind":
                    var allowedVersionsForKind = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForKind.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("kind"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((EngineeringModelKind)value).ToString());
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
                case "organizationalparticipant":
                    var allowedVersionsForOrganizationalParticipant = new List<string>
                    {
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForOrganizationalParticipant.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("organizationalParticipant"u8);

                    if(value is IEnumerable<object> objectListOrganizationalParticipant)
                    {
                        foreach(var organizationalParticipantItem in objectListOrganizationalParticipant.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(organizationalParticipantItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "participant":
                    var allowedVersionsForParticipant = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForParticipant.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("participant"u8);

                    if(value is IEnumerable<object> objectListParticipant)
                    {
                        foreach(var participantItem in objectListParticipant.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(participantItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "requiredrdl":
                    var allowedVersionsForRequiredRdl = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForRequiredRdl.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("requiredRdl"u8);

                    if(value is IEnumerable<object> objectListRequiredRdl)
                    {
                        foreach(var requiredRdlItem in objectListRequiredRdl.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(requiredRdlItem);
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
                case "sourceengineeringmodelsetupiid":
                    var allowedVersionsForSourceEngineeringModelSetupIid = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForSourceEngineeringModelSetupIid.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("sourceEngineeringModelSetupIid"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "studyphase":
                    var allowedVersionsForStudyPhase = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForStudyPhase.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("studyPhase"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((StudyPhaseKind)value).ToString());
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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the EngineeringModelSetup");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="EngineeringModelSetup" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not EngineeringModelSetup engineeringModelSetup)
            {
                throw new ArgumentException("The thing shall be a EngineeringModelSetup", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of EngineeringModelSetup since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Debug, "Serializing EngineeringModelSetup for Version 1.0.0");
                    writer.WriteStartArray("activeDomain"u8);

                    foreach(var activeDomainItem in engineeringModelSetup.ActiveDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(activeDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in engineeringModelSetup.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(engineeringModelSetup.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in engineeringModelSetup.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("engineeringModelIid"u8);
                    writer.WriteStringValue(engineeringModelSetup.EngineeringModelIid);
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in engineeringModelSetup.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(engineeringModelSetup.Iid);
                    writer.WriteStartArray("iterationSetup"u8);

                    foreach(var iterationSetupItem in engineeringModelSetup.IterationSetup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(iterationSetupItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("kind"u8);
                    writer.WriteStringValue(engineeringModelSetup.Kind.ToString());
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(engineeringModelSetup.Name);
                    writer.WriteStartArray("participant"u8);

                    foreach(var participantItem in engineeringModelSetup.Participant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(participantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("requiredRdl"u8);

                    foreach(var requiredRdlItem in engineeringModelSetup.RequiredRdl.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(requiredRdlItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(engineeringModelSetup.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(engineeringModelSetup.ShortName);
                    writer.WritePropertyName("sourceEngineeringModelSetupIid"u8);

                    if(engineeringModelSetup.SourceEngineeringModelSetupIid.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelSetup.SourceEngineeringModelSetupIid.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("studyPhase"u8);
                    writer.WriteStringValue(engineeringModelSetup.StudyPhase.ToString());
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing EngineeringModelSetup for Version 1.1.0");
                    writer.WriteStartArray("activeDomain"u8);

                    foreach(var activeDomainItem in engineeringModelSetup.ActiveDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(activeDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in engineeringModelSetup.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(engineeringModelSetup.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in engineeringModelSetup.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("engineeringModelIid"u8);
                    writer.WriteStringValue(engineeringModelSetup.EngineeringModelIid);
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in engineeringModelSetup.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in engineeringModelSetup.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in engineeringModelSetup.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(engineeringModelSetup.Iid);
                    writer.WriteStartArray("iterationSetup"u8);

                    foreach(var iterationSetupItem in engineeringModelSetup.IterationSetup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(iterationSetupItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("kind"u8);
                    writer.WriteStringValue(engineeringModelSetup.Kind.ToString());
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(engineeringModelSetup.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(engineeringModelSetup.Name);
                    writer.WriteStartArray("participant"u8);

                    foreach(var participantItem in engineeringModelSetup.Participant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(participantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("requiredRdl"u8);

                    foreach(var requiredRdlItem in engineeringModelSetup.RequiredRdl.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(requiredRdlItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(engineeringModelSetup.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(engineeringModelSetup.ShortName);
                    writer.WritePropertyName("sourceEngineeringModelSetupIid"u8);

                    if(engineeringModelSetup.SourceEngineeringModelSetupIid.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelSetup.SourceEngineeringModelSetupIid.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("studyPhase"u8);
                    writer.WriteStringValue(engineeringModelSetup.StudyPhase.ToString());
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing EngineeringModelSetup for Version 1.2.0");
                    writer.WriteStartArray("activeDomain"u8);

                    foreach(var activeDomainItem in engineeringModelSetup.ActiveDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(activeDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in engineeringModelSetup.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(engineeringModelSetup.ClassKind.ToString());
                    writer.WritePropertyName("defaultOrganizationalParticipant"u8);

                    if(engineeringModelSetup.DefaultOrganizationalParticipant.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelSetup.DefaultOrganizationalParticipant.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in engineeringModelSetup.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("engineeringModelIid"u8);
                    writer.WriteStringValue(engineeringModelSetup.EngineeringModelIid);
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in engineeringModelSetup.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in engineeringModelSetup.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in engineeringModelSetup.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(engineeringModelSetup.Iid);
                    writer.WriteStartArray("iterationSetup"u8);

                    foreach(var iterationSetupItem in engineeringModelSetup.IterationSetup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(iterationSetupItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("kind"u8);
                    writer.WriteStringValue(engineeringModelSetup.Kind.ToString());
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(engineeringModelSetup.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(engineeringModelSetup.Name);
                    writer.WriteStartArray("organizationalParticipant"u8);

                    foreach(var organizationalParticipantItem in engineeringModelSetup.OrganizationalParticipant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(organizationalParticipantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("participant"u8);

                    foreach(var participantItem in engineeringModelSetup.Participant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(participantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("requiredRdl"u8);

                    foreach(var requiredRdlItem in engineeringModelSetup.RequiredRdl.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(requiredRdlItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(engineeringModelSetup.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(engineeringModelSetup.ShortName);
                    writer.WritePropertyName("sourceEngineeringModelSetupIid"u8);

                    if(engineeringModelSetup.SourceEngineeringModelSetupIid.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelSetup.SourceEngineeringModelSetupIid.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("studyPhase"u8);
                    writer.WriteStringValue(engineeringModelSetup.StudyPhase.ToString());
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(engineeringModelSetup.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing EngineeringModelSetup for Version 1.3.0");
                    writer.WriteStartArray("activeDomain"u8);

                    foreach(var activeDomainItem in engineeringModelSetup.ActiveDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(activeDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("actor"u8);

                    if(engineeringModelSetup.Actor.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelSetup.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in engineeringModelSetup.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(engineeringModelSetup.ClassKind.ToString());
                    writer.WritePropertyName("defaultOrganizationalParticipant"u8);

                    if(engineeringModelSetup.DefaultOrganizationalParticipant.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelSetup.DefaultOrganizationalParticipant.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in engineeringModelSetup.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("engineeringModelIid"u8);
                    writer.WriteStringValue(engineeringModelSetup.EngineeringModelIid);
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in engineeringModelSetup.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in engineeringModelSetup.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in engineeringModelSetup.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(engineeringModelSetup.Iid);
                    writer.WriteStartArray("iterationSetup"u8);

                    foreach(var iterationSetupItem in engineeringModelSetup.IterationSetup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(iterationSetupItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("kind"u8);
                    writer.WriteStringValue(engineeringModelSetup.Kind.ToString());
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(engineeringModelSetup.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(engineeringModelSetup.Name);
                    writer.WriteStartArray("organizationalParticipant"u8);

                    foreach(var organizationalParticipantItem in engineeringModelSetup.OrganizationalParticipant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(organizationalParticipantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("participant"u8);

                    foreach(var participantItem in engineeringModelSetup.Participant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(participantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("requiredRdl"u8);

                    foreach(var requiredRdlItem in engineeringModelSetup.RequiredRdl.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(requiredRdlItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(engineeringModelSetup.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(engineeringModelSetup.ShortName);
                    writer.WritePropertyName("sourceEngineeringModelSetupIid"u8);

                    if(engineeringModelSetup.SourceEngineeringModelSetupIid.HasValue)
                    {
                        writer.WriteStringValue(engineeringModelSetup.SourceEngineeringModelSetupIid.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("studyPhase"u8);
                    writer.WriteStringValue(engineeringModelSetup.StudyPhase.ToString());
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(engineeringModelSetup.ThingPreference);
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
