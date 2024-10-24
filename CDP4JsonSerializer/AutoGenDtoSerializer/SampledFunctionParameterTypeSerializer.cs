// -------------------------------------------------------------------------------------------------------------------------------// <copyright file="SampledFunctionParameterTypeSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    using SampledFunctionParameterType = CDP4Common.DTO.SampledFunctionParameterType;

    /// <summary>
    /// The purpose of the <see cref="SampledFunctionParameterTypeSerializer"/> class is to provide a <see cref="SampledFunctionParameterType"/> specific serializer
    /// </summary>
    public class SampledFunctionParameterTypeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="SampledFunctionParameterType" />.
        /// An error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version minimalAllowedDataModelVersion = Version.Parse("1.0.0");

        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="SampledFunctionParameterType" />.
        /// When a Requested Data Model version for Serialization is lower than this, the object will not be Serialized, just ignored.
        /// NO error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version thingMinimalAllowedDataModelVersion = Version.Parse("1.2.0");

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="SampledFunctionParameterType" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not SampledFunctionParameterType sampledFunctionParameterType)
            {
                throw new ArgumentException("The thing shall be a SampledFunctionParameterType", nameof(thing));
            }

            if (requestedDataModelVersion < minimalAllowedDataModelVersion)
            {
                throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported for serialization of SampledFunctionParameterType.");
            }

            if (requestedDataModelVersion < thingMinimalAllowedDataModelVersion)
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of SampledFunctionParameterType since Version is below 1.2.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing SampledFunctionParameterType for Version 1.2.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in sampledFunctionParameterType.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in sampledFunctionParameterType.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in sampledFunctionParameterType.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("degreeOfInterpolation"u8);

                    if (sampledFunctionParameterType.DegreeOfInterpolation.HasValue)
                    {
                        writer.WriteNumberValue(sampledFunctionParameterType.DegreeOfInterpolation.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("dependentParameterType"u8);

                    foreach(var dependentParameterTypeItem in sampledFunctionParameterType.DependentParameterType.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(dependentParameterTypeItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in sampledFunctionParameterType.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in sampledFunctionParameterType.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in sampledFunctionParameterType.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.Iid);
                    writer.WriteStartArray("independentParameterType"u8);

                    foreach(var independentParameterTypeItem in sampledFunctionParameterType.IndependentParameterType.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(independentParameterTypeItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteString("interpolationPeriod"u8, sampledFunctionParameterType.InterpolationPeriod.ToJsonString());
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(sampledFunctionParameterType.IsDeprecated);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.Name);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(sampledFunctionParameterType.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.ShortName);
                    writer.WritePropertyName("symbol"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.Symbol);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.ThingPreference);
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing SampledFunctionParameterType for Version 1.3.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in sampledFunctionParameterType.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("category"u8);

                    foreach(var categoryItem in sampledFunctionParameterType.Category.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(categoryItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in sampledFunctionParameterType.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("degreeOfInterpolation"u8);

                    if (sampledFunctionParameterType.DegreeOfInterpolation.HasValue)
                    {
                        writer.WriteNumberValue(sampledFunctionParameterType.DegreeOfInterpolation.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("dependentParameterType"u8);

                    foreach(var dependentParameterTypeItem in sampledFunctionParameterType.DependentParameterType.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(dependentParameterTypeItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in sampledFunctionParameterType.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in sampledFunctionParameterType.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in sampledFunctionParameterType.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.Iid);
                    writer.WriteStartArray("independentParameterType"u8);

                    foreach(var independentParameterTypeItem in sampledFunctionParameterType.IndependentParameterType.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(independentParameterTypeItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteString("interpolationPeriod"u8, sampledFunctionParameterType.InterpolationPeriod.ToJsonString());
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(sampledFunctionParameterType.IsDeprecated);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.Name);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(sampledFunctionParameterType.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.ShortName);
                    writer.WritePropertyName("symbol"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.Symbol);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(sampledFunctionParameterType.ThingPreference);
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
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="SampledFunctionParameterType" /></exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer)
        {
            if (thing is not SampledFunctionParameterType sampledFunctionParameterType)
            {
                throw new ArgumentException("The thing shall be a SampledFunctionParameterType", nameof(thing));
            }

            writer.WriteStartObject();

                writer.WriteStartArray("alias"u8);

                foreach(var aliasItem in sampledFunctionParameterType.Alias.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(aliasItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("category"u8);

                foreach(var categoryItem in sampledFunctionParameterType.Category.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(categoryItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("classKind"u8);
                writer.WriteStringValue(sampledFunctionParameterType.ClassKind.ToString());

                writer.WriteStartArray("definition"u8);

                foreach(var definitionItem in sampledFunctionParameterType.Definition.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(definitionItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("degreeOfInterpolation"u8);

                if (sampledFunctionParameterType.DegreeOfInterpolation.HasValue)
                {
                    writer.WriteNumberValue(sampledFunctionParameterType.DegreeOfInterpolation.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WriteStartArray("dependentParameterType"u8);

                foreach(var dependentParameterTypeItem in sampledFunctionParameterType.DependentParameterType.OrderBy(x => x, this.OrderedItemComparer))
                {
                    writer.WriteOrderedItem(dependentParameterTypeItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedDomain"u8);

                foreach(var excludedDomainItem in sampledFunctionParameterType.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedDomainItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedPerson"u8);

                foreach(var excludedPersonItem in sampledFunctionParameterType.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedPersonItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("hyperLink"u8);

                foreach(var hyperLinkItem in sampledFunctionParameterType.HyperLink.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(hyperLinkItem);
                }

                writer.WriteEndArray();
                
                writer.WritePropertyName("iid"u8);
                writer.WriteStringValue(sampledFunctionParameterType.Iid);

                writer.WriteStartArray("independentParameterType"u8);

                foreach(var independentParameterTypeItem in sampledFunctionParameterType.IndependentParameterType.OrderBy(x => x, this.OrderedItemComparer))
                {
                    writer.WriteOrderedItem(independentParameterTypeItem);
                }

                writer.WriteEndArray();
                
                writer.WriteString("interpolationPeriod"u8, sampledFunctionParameterType.InterpolationPeriod.ToJsonString());
                writer.WritePropertyName("isDeprecated"u8);
                writer.WriteBooleanValue(sampledFunctionParameterType.IsDeprecated);
                writer.WritePropertyName("modifiedOn"u8);
                writer.WriteStringValue(sampledFunctionParameterType.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(sampledFunctionParameterType.Name);
                writer.WritePropertyName("revisionNumber"u8);
                writer.WriteNumberValue(sampledFunctionParameterType.RevisionNumber);
                writer.WritePropertyName("shortName"u8);
                writer.WriteStringValue(sampledFunctionParameterType.ShortName);
                writer.WritePropertyName("symbol"u8);
                writer.WriteStringValue(sampledFunctionParameterType.Symbol);
                writer.WritePropertyName("thingPreference"u8);
                writer.WriteStringValue(sampledFunctionParameterType.ThingPreference);

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="SampledFunctionParameterType"/> property into a <see cref="Utf8JsonWriter" />
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
        /// Serialize a value for a <see cref="SampledFunctionParameterType"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer)
        {
            switch(propertyName.ToLower())
            {
                case "alias":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListAlias && objectListAlias.Any())
                    {
                        writer.WriteStartArray("alias"u8);

                        foreach(var aliasItem in objectListAlias.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(aliasItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "category":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListCategory && objectListCategory.Any())
                    {
                        writer.WriteStartArray("category"u8);

                        foreach(var categoryItem in objectListCategory.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(categoryItem);
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
                case "definition":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListDefinition && objectListDefinition.Any())
                    {
                        writer.WriteStartArray("definition"u8);

                        foreach(var definitionItem in objectListDefinition.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(definitionItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "degreeofinterpolation":
                    writer.WritePropertyName("degreeOfInterpolation"u8);
                    
                    if(value != null)
                    {
                        writer.WriteNumberValue((int)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "dependentparametertype":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListDependentParameterType && objectListDependentParameterType.Any())
                    {
                        writer.WriteStartArray("dependentParameterType"u8);

                        foreach(var dependentParameterTypeItem in objectListDependentParameterType.OfType<OrderedItem>().OrderBy(x => x, this.OrderedItemComparer))
                        {
                            writer.WriteOrderedItem(dependentParameterTypeItem);
                        }
                        writer.WriteEndArray();
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
                case "hyperlink":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListHyperLink && objectListHyperLink.Any())
                    {
                        writer.WriteStartArray("hyperLink"u8);

                        foreach(var hyperLinkItem in objectListHyperLink.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(hyperLinkItem);
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
                case "independentparametertype":
                    if (value == null)
                    {
                        break;
                    }

                    if (value is IEnumerable<object> objectListIndependentParameterType && objectListIndependentParameterType.Any())
                    {
                        writer.WriteStartArray("independentParameterType"u8);

                        foreach(var independentParameterTypeItem in objectListIndependentParameterType.OfType<OrderedItem>().OrderBy(x => x, this.OrderedItemComparer))
                        {
                            writer.WriteOrderedItem(independentParameterTypeItem);
                        }
                        writer.WriteEndArray();
                    }
                    break;
                case "interpolationperiod":
                    writer.WriteString("interpolationPeriod"u8, ((ValueArray<string>)value).ToJsonString());
                    break;
                case "isdeprecated":
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
                case "name":
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
                case "shortname":
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
                case "symbol":
                    writer.WritePropertyName("symbol"u8);
                    
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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the SampledFunctionParameterType");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "alias", new []{ "1.2.0", "1.3.0" }},
            { "category", new []{ "1.2.0", "1.3.0" }},
            { "classKind", new []{ "1.2.0", "1.3.0" }},
            { "definition", new []{ "1.2.0", "1.3.0" }},
            { "degreeOfInterpolation", new []{ "1.2.0", "1.3.0" }},
            { "dependentParameterType", new []{ "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "hyperLink", new []{ "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.2.0", "1.3.0" }},
            { "independentParameterType", new []{ "1.2.0", "1.3.0" }},
            { "interpolationPeriod", new []{ "1.2.0", "1.3.0" }},
            { "isDeprecated", new []{ "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "name", new []{ "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.2.0", "1.3.0" }},
            { "shortName", new []{ "1.2.0", "1.3.0" }},
            { "symbol", new []{ "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
