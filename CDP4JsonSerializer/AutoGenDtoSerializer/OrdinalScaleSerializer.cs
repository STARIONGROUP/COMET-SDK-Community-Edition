// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="OrdinalScaleSerializer.cs" company="RHEA System S.A.">
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
    using OrdinalScale = CDP4Common.DTO.OrdinalScale;

    /// <summary>
    /// The purpose of the <see cref="OrdinalScaleSerializer"/> class is to provide a <see cref="OrdinalScale"/> specific serializer
    /// </summary>
    public class OrdinalScaleSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="OrdinalScale" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not OrdinalScale ordinalScale)
            {
                throw new ArgumentException("The thing shall be a OrdinalScale", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of OrdinalScale since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Trace, "Serializing OrdinalScale for Version 1.0.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in ordinalScale.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(ordinalScale.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in ordinalScale.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in ordinalScale.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(ordinalScale.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(ordinalScale.IsDeprecated);
                    writer.WritePropertyName("isMaximumInclusive"u8);
                    writer.WriteBooleanValue(ordinalScale.IsMaximumInclusive);
                    writer.WritePropertyName("isMinimumInclusive"u8);
                    writer.WriteBooleanValue(ordinalScale.IsMinimumInclusive);
                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    foreach(var mappingToReferenceScaleItem in ordinalScale.MappingToReferenceScale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(mappingToReferenceScaleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    writer.WriteStringValue(ordinalScale.MaximumPermissibleValue);
                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    writer.WriteStringValue(ordinalScale.MinimumPermissibleValue);
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(ordinalScale.Name);
                    writer.WritePropertyName("negativeValueConnotation"u8);
                    writer.WriteStringValue(ordinalScale.NegativeValueConnotation);
                    writer.WritePropertyName("numberSet"u8);
                    writer.WriteStringValue(ordinalScale.NumberSet.ToString());
                    writer.WritePropertyName("positiveValueConnotation"u8);
                    writer.WriteStringValue(ordinalScale.PositiveValueConnotation);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(ordinalScale.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(ordinalScale.ShortName);
                    writer.WritePropertyName("unit"u8);
                    writer.WriteStringValue(ordinalScale.Unit);
                    writer.WritePropertyName("useShortNameValues"u8);
                    writer.WriteBooleanValue(ordinalScale.UseShortNameValues);
                    writer.WriteStartArray("valueDefinition"u8);

                    foreach(var valueDefinitionItem in ordinalScale.ValueDefinition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueDefinitionItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Trace, "Serializing OrdinalScale for Version 1.1.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in ordinalScale.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(ordinalScale.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in ordinalScale.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in ordinalScale.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in ordinalScale.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in ordinalScale.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(ordinalScale.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(ordinalScale.IsDeprecated);
                    writer.WritePropertyName("isMaximumInclusive"u8);
                    writer.WriteBooleanValue(ordinalScale.IsMaximumInclusive);
                    writer.WritePropertyName("isMinimumInclusive"u8);
                    writer.WriteBooleanValue(ordinalScale.IsMinimumInclusive);
                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    foreach(var mappingToReferenceScaleItem in ordinalScale.MappingToReferenceScale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(mappingToReferenceScaleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    writer.WriteStringValue(ordinalScale.MaximumPermissibleValue);
                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    writer.WriteStringValue(ordinalScale.MinimumPermissibleValue);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(ordinalScale.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(ordinalScale.Name);
                    writer.WritePropertyName("negativeValueConnotation"u8);
                    writer.WriteStringValue(ordinalScale.NegativeValueConnotation);
                    writer.WritePropertyName("numberSet"u8);
                    writer.WriteStringValue(ordinalScale.NumberSet.ToString());
                    writer.WritePropertyName("positiveValueConnotation"u8);
                    writer.WriteStringValue(ordinalScale.PositiveValueConnotation);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(ordinalScale.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(ordinalScale.ShortName);
                    writer.WritePropertyName("unit"u8);
                    writer.WriteStringValue(ordinalScale.Unit);
                    writer.WritePropertyName("useShortNameValues"u8);
                    writer.WriteBooleanValue(ordinalScale.UseShortNameValues);
                    writer.WriteStartArray("valueDefinition"u8);

                    foreach(var valueDefinitionItem in ordinalScale.ValueDefinition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueDefinitionItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing OrdinalScale for Version 1.2.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in ordinalScale.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(ordinalScale.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in ordinalScale.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in ordinalScale.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in ordinalScale.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in ordinalScale.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(ordinalScale.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(ordinalScale.IsDeprecated);
                    writer.WritePropertyName("isMaximumInclusive"u8);
                    writer.WriteBooleanValue(ordinalScale.IsMaximumInclusive);
                    writer.WritePropertyName("isMinimumInclusive"u8);
                    writer.WriteBooleanValue(ordinalScale.IsMinimumInclusive);
                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    foreach(var mappingToReferenceScaleItem in ordinalScale.MappingToReferenceScale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(mappingToReferenceScaleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    writer.WriteStringValue(ordinalScale.MaximumPermissibleValue);
                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    writer.WriteStringValue(ordinalScale.MinimumPermissibleValue);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(ordinalScale.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(ordinalScale.Name);
                    writer.WritePropertyName("negativeValueConnotation"u8);
                    writer.WriteStringValue(ordinalScale.NegativeValueConnotation);
                    writer.WritePropertyName("numberSet"u8);
                    writer.WriteStringValue(ordinalScale.NumberSet.ToString());
                    writer.WritePropertyName("positiveValueConnotation"u8);
                    writer.WriteStringValue(ordinalScale.PositiveValueConnotation);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(ordinalScale.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(ordinalScale.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(ordinalScale.ThingPreference);
                    writer.WritePropertyName("unit"u8);
                    writer.WriteStringValue(ordinalScale.Unit);
                    writer.WritePropertyName("useShortNameValues"u8);
                    writer.WriteBooleanValue(ordinalScale.UseShortNameValues);
                    writer.WriteStartArray("valueDefinition"u8);

                    foreach(var valueDefinitionItem in ordinalScale.ValueDefinition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueDefinitionItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing OrdinalScale for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(ordinalScale.Actor.HasValue)
                    {
                        writer.WriteStringValue(ordinalScale.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in ordinalScale.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(ordinalScale.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in ordinalScale.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in ordinalScale.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in ordinalScale.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in ordinalScale.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(ordinalScale.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(ordinalScale.IsDeprecated);
                    writer.WritePropertyName("isMaximumInclusive"u8);
                    writer.WriteBooleanValue(ordinalScale.IsMaximumInclusive);
                    writer.WritePropertyName("isMinimumInclusive"u8);
                    writer.WriteBooleanValue(ordinalScale.IsMinimumInclusive);
                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    foreach(var mappingToReferenceScaleItem in ordinalScale.MappingToReferenceScale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(mappingToReferenceScaleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    writer.WriteStringValue(ordinalScale.MaximumPermissibleValue);
                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    writer.WriteStringValue(ordinalScale.MinimumPermissibleValue);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(ordinalScale.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(ordinalScale.Name);
                    writer.WritePropertyName("negativeValueConnotation"u8);
                    writer.WriteStringValue(ordinalScale.NegativeValueConnotation);
                    writer.WritePropertyName("numberSet"u8);
                    writer.WriteStringValue(ordinalScale.NumberSet.ToString());
                    writer.WritePropertyName("positiveValueConnotation"u8);
                    writer.WriteStringValue(ordinalScale.PositiveValueConnotation);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(ordinalScale.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(ordinalScale.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(ordinalScale.ThingPreference);
                    writer.WritePropertyName("unit"u8);
                    writer.WriteStringValue(ordinalScale.Unit);
                    writer.WritePropertyName("useShortNameValues"u8);
                    writer.WriteBooleanValue(ordinalScale.UseShortNameValues);
                    writer.WriteStartArray("valueDefinition"u8);

                    foreach(var valueDefinitionItem in ordinalScale.ValueDefinition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueDefinitionItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                default:
                    throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported");
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="OrdinalScale"/> property into a <see cref="Utf8JsonWriter" />
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
                case "isdeprecated":
                    if(!AllowedVersionsPerProperty["isDeprecated"].Contains(requestedVersion))
                    {
                        return;
                    }

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
                case "ismaximuminclusive":
                    if(!AllowedVersionsPerProperty["isMaximumInclusive"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("isMaximumInclusive"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "isminimuminclusive":
                    if(!AllowedVersionsPerProperty["isMinimumInclusive"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("isMinimumInclusive"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "mappingtoreferencescale":
                    if(!AllowedVersionsPerProperty["mappingToReferenceScale"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    if(value is IEnumerable<object> objectListMappingToReferenceScale)
                    {
                        foreach(var mappingToReferenceScaleItem in objectListMappingToReferenceScale.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(mappingToReferenceScaleItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "maximumpermissiblevalue":
                    if(!AllowedVersionsPerProperty["maximumPermissibleValue"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "minimumpermissiblevalue":
                    if(!AllowedVersionsPerProperty["minimumPermissibleValue"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    
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
                case "negativevalueconnotation":
                    if(!AllowedVersionsPerProperty["negativeValueConnotation"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("negativeValueConnotation"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "numberset":
                    if(!AllowedVersionsPerProperty["numberSet"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("numberSet"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((NumberSetKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "positivevalueconnotation":
                    if(!AllowedVersionsPerProperty["positiveValueConnotation"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("positiveValueConnotation"u8);
                    
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
                case "unit":
                    if(!AllowedVersionsPerProperty["unit"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("unit"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "useshortnamevalues":
                    if(!AllowedVersionsPerProperty["useShortNameValues"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("useShortNameValues"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "valuedefinition":
                    if(!AllowedVersionsPerProperty["valueDefinition"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("valueDefinition"u8);

                    if(value is IEnumerable<object> objectListValueDefinition)
                    {
                        foreach(var valueDefinitionItem in objectListValueDefinition.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(valueDefinitionItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the OrdinalScale");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "alias", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "classKind", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "definition", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "hyperLink", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "isDeprecated", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "isMaximumInclusive", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "isMinimumInclusive", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "mappingToReferenceScale", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "maximumPermissibleValue", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "minimumPermissibleValue", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "name", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "negativeValueConnotation", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "numberSet", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "positiveValueConnotation", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "shortName", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
            { "unit", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "useShortNameValues", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "valueDefinition", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
