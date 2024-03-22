// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionSerializer.cs" company="RHEA System S.A.">
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

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NLog;

    using Thing = CDP4Common.DTO.Thing;
    using ElementDefinition = CDP4Common.DTO.ElementDefinition;

    /// <summary>
    /// The purpose of the <see cref="ElementDefinitionSerializer"/> class is to provide a <see cref="ElementDefinition"/> specific serializer
    /// </summary>
    public class ElementDefinitionSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ElementDefinition" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not ElementDefinition elementDefinition)
            {
                throw new ArgumentException("The thing shall be a ElementDefinition", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of ElementDefinition since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Trace, "Serializing ElementDefinition for Version 1.0.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in elementDefinition.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in elementDefinition.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(elementDefinition.ClassKind.ToString());
                    writer.WriteStartArray("containedElement"u8);

                    foreach(var containedElementItem in elementDefinition.ContainedElement.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(containedElementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in elementDefinition.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in elementDefinition.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(elementDefinition.Iid);
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(elementDefinition.Name);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(elementDefinition.Owner);
                    writer.WriteStartArray("parameter"u8);

                    foreach(var parameterItem in elementDefinition.Parameter.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("parameterGroup"u8);

                    foreach(var parameterGroupItem in elementDefinition.ParameterGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("referencedElement"u8);

                    foreach(var referencedElementItem in elementDefinition.ReferencedElement.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referencedElementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(elementDefinition.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(elementDefinition.ShortName);
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Trace, "Serializing ElementDefinition for Version 1.1.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in elementDefinition.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in elementDefinition.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(elementDefinition.ClassKind.ToString());
                    writer.WriteStartArray("containedElement"u8);

                    foreach(var containedElementItem in elementDefinition.ContainedElement.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(containedElementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in elementDefinition.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in elementDefinition.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in elementDefinition.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in elementDefinition.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(elementDefinition.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(elementDefinition.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(elementDefinition.Name);
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(elementDefinition.Owner);
                    writer.WriteStartArray("parameter"u8);

                    foreach(var parameterItem in elementDefinition.Parameter.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("parameterGroup"u8);

                    foreach(var parameterGroupItem in elementDefinition.ParameterGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("referencedElement"u8);

                    foreach(var referencedElementItem in elementDefinition.ReferencedElement.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referencedElementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(elementDefinition.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(elementDefinition.ShortName);
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing ElementDefinition for Version 1.2.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in elementDefinition.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in elementDefinition.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(elementDefinition.ClassKind.ToString());
                    writer.WriteStartArray("containedElement"u8);

                    foreach(var containedElementItem in elementDefinition.ContainedElement.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(containedElementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in elementDefinition.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in elementDefinition.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in elementDefinition.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in elementDefinition.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(elementDefinition.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(elementDefinition.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(elementDefinition.Name);
                    writer.WriteStartArray("organizationalParticipant"u8);

                    foreach(var organizationalParticipantItem in elementDefinition.OrganizationalParticipant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(organizationalParticipantItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(elementDefinition.Owner);
                    writer.WriteStartArray("parameter"u8);

                    foreach(var parameterItem in elementDefinition.Parameter.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("parameterGroup"u8);

                    foreach(var parameterGroupItem in elementDefinition.ParameterGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("referencedElement"u8);

                    foreach(var referencedElementItem in elementDefinition.ReferencedElement.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referencedElementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(elementDefinition.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(elementDefinition.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(elementDefinition.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing ElementDefinition for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(elementDefinition.Actor.HasValue)
                    {
                        writer.WriteStringValue(elementDefinition.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in elementDefinition.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in elementDefinition.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(elementDefinition.ClassKind.ToString());
                    writer.WriteStartArray("containedElement"u8);

                    foreach(var containedElementItem in elementDefinition.ContainedElement.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(containedElementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in elementDefinition.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in elementDefinition.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in elementDefinition.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in elementDefinition.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(elementDefinition.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(elementDefinition.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(elementDefinition.Name);
                    writer.WriteStartArray("organizationalParticipant"u8);

                    foreach(var organizationalParticipantItem in elementDefinition.OrganizationalParticipant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(organizationalParticipantItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("owner"u8);
                    writer.WriteStringValue(elementDefinition.Owner);
                    writer.WriteStartArray("parameter"u8);

                    foreach(var parameterItem in elementDefinition.Parameter.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("parameterGroup"u8);

                    foreach(var parameterGroupItem in elementDefinition.ParameterGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("referencedElement"u8);

                    foreach(var referencedElementItem in elementDefinition.ReferencedElement.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referencedElementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(elementDefinition.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(elementDefinition.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(elementDefinition.ThingPreference);
                    break;
                default:
                    throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported");
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="ElementDefinition"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            var requestedVersion = requestedDataModelVersion.ToString(3);

            switch(propertyName.ToLower())
            {
                case "actor":
                    if(!AllowedVersionsPerProperty["actor"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["alias"].Contains(requestedVersion))
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
                case "category":
                    if(!AllowedVersionsPerProperty["category"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["classKind"].Contains(requestedVersion))
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
                case "containedelement":
                    if(!AllowedVersionsPerProperty["containedElement"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("containedElement"u8);

                    if(value is IEnumerable<object> objectListContainedElement)
                    {
                        foreach(var containedElementItem in objectListContainedElement.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(containedElementItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "definition":
                    if(!AllowedVersionsPerProperty["definition"].Contains(requestedVersion))
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
                case "excludeddomain":
                    if(!AllowedVersionsPerProperty["excludedDomain"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["excludedPerson"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["hyperLink"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["iid"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["modifiedOn"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["name"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["organizationalParticipant"].Contains(requestedVersion))
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
                case "owner":
                    if(!AllowedVersionsPerProperty["owner"].Contains(requestedVersion))
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
                case "parameter":
                    if(!AllowedVersionsPerProperty["parameter"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("parameter"u8);

                    if(value is IEnumerable<object> objectListParameter)
                    {
                        foreach(var parameterItem in objectListParameter.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(parameterItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "parametergroup":
                    if(!AllowedVersionsPerProperty["parameterGroup"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("parameterGroup"u8);

                    if(value is IEnumerable<object> objectListParameterGroup)
                    {
                        foreach(var parameterGroupItem in objectListParameterGroup.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(parameterGroupItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "referencedelement":
                    if(!AllowedVersionsPerProperty["referencedElement"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("referencedElement"u8);

                    if(value is IEnumerable<object> objectListReferencedElement)
                    {
                        foreach(var referencedElementItem in objectListReferencedElement.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(referencedElementItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "revisionnumber":
                    if(!AllowedVersionsPerProperty["revisionNumber"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["shortName"].Contains(requestedVersion))
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
                    if(!AllowedVersionsPerProperty["thingPreference"].Contains(requestedVersion))
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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the ElementDefinition");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "alias", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "category", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "classKind", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "containedElement", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "definition", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "hyperLink", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "name", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "organizationalParticipant", new []{ "1.2.0", "1.3.0" }},
            { "owner", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "parameter", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "parameterGroup", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "referencedElement", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "shortName", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
