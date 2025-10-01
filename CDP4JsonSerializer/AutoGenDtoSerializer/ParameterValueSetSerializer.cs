// -------------------------------------------------------------------------------------------------------------------------------// <copyright file="ParameterValueSetSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using ParameterValueSet = CDP4Common.DTO.ParameterValueSet;

    /// <summary>
    /// The purpose of the <see cref="ParameterValueSetSerializer"/> class is to provide a <see cref="ParameterValueSet"/> specific serializer
    /// </summary>
    public class ParameterValueSetSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="ParameterValueSet" />.
        /// An error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version minimalAllowedDataModelVersion = Version.Parse("1.0.0");

        /// <summary>
        /// The minimal <see cref="Version" /> that is allowed for serialization of a <see cref="ParameterValueSet" />.
        /// When a Requested Data Model version for Serialization is lower than this, the object will not be Serialized, just ignored.
        /// NO error will be thrown when a Requested Data Model version for Serialization is lower than this.
        /// </summary>
        private static Version thingMinimalAllowedDataModelVersion = Version.Parse("1.0.0");

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ParameterValueSet" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not ParameterValueSet parameterValueSet)
            {
                throw new ArgumentException("The thing shall be a ParameterValueSet", nameof(thing));
            }

            if (requestedDataModelVersion < minimalAllowedDataModelVersion)
            {
                throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported for serialization of ParameterValueSet.");
            }

            if (requestedDataModelVersion < thingMinimalAllowedDataModelVersion)
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of ParameterValueSet since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Trace, "Serializing ParameterValueSet for Version 1.0.0");
                    writer.WritePropertyName("actualOption"u8);

                    if (parameterValueSet.ActualOption.HasValue)
                    {
                        writer.WriteStringValue(parameterValueSet.ActualOption.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("actualState"u8);

                    if (parameterValueSet.ActualState.HasValue)
                    {
                        writer.WriteStringValue(parameterValueSet.ActualState.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameterValueSet.ClassKind.ToString());
                    writer.WriteString("computed"u8, parameterValueSet.Computed.ToJsonString());
                    writer.WriteString("formula"u8, parameterValueSet.Formula.ToJsonString());
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameterValueSet.Iid);
                    writer.WriteString("manual"u8, parameterValueSet.Manual.ToJsonString());
                    writer.WriteString("published"u8, parameterValueSet.Published.ToJsonString());
                    writer.WriteString("reference"u8, parameterValueSet.Reference.ToJsonString());
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameterValueSet.RevisionNumber);
                    writer.WritePropertyName("valueSwitch"u8);
                    writer.WriteStringValue(parameterValueSet.ValueSwitch.ToString());
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Trace, "Serializing ParameterValueSet for Version 1.1.0");
                    writer.WritePropertyName("actualOption"u8);

                    if (parameterValueSet.ActualOption.HasValue)
                    {
                        writer.WriteStringValue(parameterValueSet.ActualOption.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("actualState"u8);

                    if (parameterValueSet.ActualState.HasValue)
                    {
                        writer.WriteStringValue(parameterValueSet.ActualState.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameterValueSet.ClassKind.ToString());
                    writer.WriteString("computed"u8, parameterValueSet.Computed.ToJsonString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameterValueSet.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameterValueSet.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteString("formula"u8, parameterValueSet.Formula.ToJsonString());
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameterValueSet.Iid);
                    writer.WriteString("manual"u8, parameterValueSet.Manual.ToJsonString());
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameterValueSet.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteString("published"u8, parameterValueSet.Published.ToJsonString());
                    writer.WriteString("reference"u8, parameterValueSet.Reference.ToJsonString());
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameterValueSet.RevisionNumber);
                    writer.WritePropertyName("valueSwitch"u8);
                    writer.WriteStringValue(parameterValueSet.ValueSwitch.ToString());
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing ParameterValueSet for Version 1.2.0");
                    writer.WritePropertyName("actualOption"u8);

                    if (parameterValueSet.ActualOption.HasValue)
                    {
                        writer.WriteStringValue(parameterValueSet.ActualOption.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("actualState"u8);

                    if (parameterValueSet.ActualState.HasValue)
                    {
                        writer.WriteStringValue(parameterValueSet.ActualState.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameterValueSet.ClassKind.ToString());
                    writer.WriteString("computed"u8, parameterValueSet.Computed.ToJsonString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameterValueSet.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameterValueSet.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteString("formula"u8, parameterValueSet.Formula.ToJsonString());
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameterValueSet.Iid);
                    writer.WriteString("manual"u8, parameterValueSet.Manual.ToJsonString());
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameterValueSet.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteString("published"u8, parameterValueSet.Published.ToJsonString());
                    writer.WriteString("reference"u8, parameterValueSet.Reference.ToJsonString());
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameterValueSet.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(parameterValueSet.ThingPreference);
                    writer.WritePropertyName("valueSwitch"u8);
                    writer.WriteStringValue(parameterValueSet.ValueSwitch.ToString());
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing ParameterValueSet for Version 1.3.0");
                    writer.WritePropertyName("actualOption"u8);

                    if (parameterValueSet.ActualOption.HasValue)
                    {
                        writer.WriteStringValue(parameterValueSet.ActualOption.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("actualState"u8);

                    if (parameterValueSet.ActualState.HasValue)
                    {
                        writer.WriteStringValue(parameterValueSet.ActualState.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(parameterValueSet.ClassKind.ToString());
                    writer.WriteString("computed"u8, parameterValueSet.Computed.ToJsonString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in parameterValueSet.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in parameterValueSet.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteString("formula"u8, parameterValueSet.Formula.ToJsonString());
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(parameterValueSet.Iid);
                    writer.WriteString("manual"u8, parameterValueSet.Manual.ToJsonString());
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(parameterValueSet.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteString("published"u8, parameterValueSet.Published.ToJsonString());
                    writer.WriteString("reference"u8, parameterValueSet.Reference.ToJsonString());
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(parameterValueSet.RevisionNumber);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(parameterValueSet.ThingPreference);
                    writer.WritePropertyName("valueSwitch"u8);
                    writer.WriteStringValue(parameterValueSet.ValueSwitch.ToString());
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
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="ParameterValueSet" /></exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer)
        {
            if (thing is not ParameterValueSet parameterValueSet)
            {
                throw new ArgumentException("The thing shall be a ParameterValueSet", nameof(thing));
            }

            writer.WriteStartObject();

                writer.WritePropertyName("actualOption"u8);

                if (parameterValueSet.ActualOption.HasValue)
                {
                    writer.WriteStringValue(parameterValueSet.ActualOption.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WritePropertyName("actualState"u8);

                if (parameterValueSet.ActualState.HasValue)
                {
                    writer.WriteStringValue(parameterValueSet.ActualState.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }

                writer.WritePropertyName("classKind"u8);
                writer.WriteStringValue(parameterValueSet.ClassKind.ToString());
                writer.WriteString("computed"u8, parameterValueSet.Computed.ToJsonString());

                writer.WriteStartArray("excludedDomain"u8);

                foreach(var excludedDomainItem in parameterValueSet.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedDomainItem);
                }

                writer.WriteEndArray();
                

                writer.WriteStartArray("excludedPerson"u8);

                foreach(var excludedPersonItem in parameterValueSet.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                {
                    writer.WriteStringValue(excludedPersonItem);
                }

                writer.WriteEndArray();
                
                writer.WriteString("formula"u8, parameterValueSet.Formula.ToJsonString());
                writer.WritePropertyName("iid"u8);
                writer.WriteStringValue(parameterValueSet.Iid);
                writer.WriteString("manual"u8, parameterValueSet.Manual.ToJsonString());
                writer.WritePropertyName("modifiedOn"u8);
                writer.WriteStringValue(parameterValueSet.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                writer.WriteString("published"u8, parameterValueSet.Published.ToJsonString());
                writer.WriteString("reference"u8, parameterValueSet.Reference.ToJsonString());
                writer.WritePropertyName("revisionNumber"u8);
                writer.WriteNumberValue(parameterValueSet.RevisionNumber);
                writer.WritePropertyName("thingPreference"u8);
                writer.WriteStringValue(parameterValueSet.ThingPreference);
                writer.WritePropertyName("valueSwitch"u8);
                writer.WriteStringValue(parameterValueSet.ValueSwitch.ToString());

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="ParameterValueSet"/> property into a <see cref="Utf8JsonWriter" />
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
        /// Serialize a value for a <see cref="ParameterValueSet"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer)
        {
            switch(propertyName.ToLower())
            {
                case "actualoption":
                    writer.WritePropertyName("actualOption"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "actualstate":
                    writer.WritePropertyName("actualState"u8);
                    
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
                case "computed":
                    writer.WriteString("computed"u8, ((ValueArray<string>)value).ToJsonString());
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
                case "formula":
                    writer.WriteString("formula"u8, ((ValueArray<string>)value).ToJsonString());
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
                case "manual":
                    writer.WriteString("manual"u8, ((ValueArray<string>)value).ToJsonString());
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
                case "published":
                    writer.WriteString("published"u8, ((ValueArray<string>)value).ToJsonString());
                    break;
                case "reference":
                    writer.WriteString("reference"u8, ((ValueArray<string>)value).ToJsonString());
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
                case "valueswitch":
                    writer.WritePropertyName("valueSwitch"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((ParameterSwitchKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the ParameterValueSet");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "actualOption", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "actualState", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "classKind", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "computed", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "formula", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "manual", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "published", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "reference", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
            { "valueSwitch", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
