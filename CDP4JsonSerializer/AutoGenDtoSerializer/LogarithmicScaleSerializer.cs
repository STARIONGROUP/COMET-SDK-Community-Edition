// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="LogarithmicScaleSerializer.cs" company="RHEA System S.A.">
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
    using LogarithmicScale = CDP4Common.DTO.LogarithmicScale;

    /// <summary>
    /// The purpose of the <see cref="LogarithmicScaleSerializer"/> class is to provide a <see cref="LogarithmicScale"/> specific serializer
    /// </summary>
    public class LogarithmicScaleSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="LogarithmicScale"/> property into a <see cref="Utf8JsonWriter" />
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
                case "exponent":
                    var allowedVersionsForExponent = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForExponent.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("exponent"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "factor":
                    var allowedVersionsForFactor = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFactor.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("factor"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

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
                case "isdeprecated":
                    var allowedVersionsForIsDeprecated = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForIsDeprecated.Contains(requestedVersion))
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
                    var allowedVersionsForIsMaximumInclusive = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForIsMaximumInclusive.Contains(requestedVersion))
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
                    var allowedVersionsForIsMinimumInclusive = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForIsMinimumInclusive.Contains(requestedVersion))
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
                case "logarithmbase":
                    var allowedVersionsForLogarithmBase = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForLogarithmBase.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("logarithmBase"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((LogarithmBaseKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "mappingtoreferencescale":
                    var allowedVersionsForMappingToReferenceScale = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForMappingToReferenceScale.Contains(requestedVersion))
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
                    var allowedVersionsForMaximumPermissibleValue = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForMaximumPermissibleValue.Contains(requestedVersion))
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
                    var allowedVersionsForMinimumPermissibleValue = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForMinimumPermissibleValue.Contains(requestedVersion))
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
                case "negativevalueconnotation":
                    var allowedVersionsForNegativeValueConnotation = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForNegativeValueConnotation.Contains(requestedVersion))
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
                    var allowedVersionsForNumberSet = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForNumberSet.Contains(requestedVersion))
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
                    var allowedVersionsForPositiveValueConnotation = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForPositiveValueConnotation.Contains(requestedVersion))
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
                case "referencequantitykind":
                    var allowedVersionsForReferenceQuantityKind = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForReferenceQuantityKind.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("referenceQuantityKind"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "referencequantityvalue":
                    var allowedVersionsForReferenceQuantityValue = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForReferenceQuantityValue.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("referenceQuantityValue"u8);

                    if(value is IEnumerable<object> objectListReferenceQuantityValue)
                    {
                        foreach(var referenceQuantityValueItem in objectListReferenceQuantityValue.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(referenceQuantityValueItem);
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
                case "unit":
                    var allowedVersionsForUnit = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForUnit.Contains(requestedVersion))
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
                case "valuedefinition":
                    var allowedVersionsForValueDefinition = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForValueDefinition.Contains(requestedVersion))
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
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the LogarithmicScale");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="LogarithmicScale" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not LogarithmicScale logarithmicScale)
            {
                throw new ArgumentException("The thing shall be a LogarithmicScale", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of LogarithmicScale since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Debug, "Serializing LogarithmicScale for Version 1.0.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in logarithmicScale.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(logarithmicScale.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in logarithmicScale.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("exponent"u8);
                    writer.WriteStringValue(logarithmicScale.Exponent);
                    writer.WritePropertyName("factor"u8);
                    writer.WriteStringValue(logarithmicScale.Factor);
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in logarithmicScale.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(logarithmicScale.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsDeprecated);
                    writer.WritePropertyName("isMaximumInclusive"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsMaximumInclusive);
                    writer.WritePropertyName("isMinimumInclusive"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsMinimumInclusive);
                    writer.WritePropertyName("logarithmBase"u8);
                    writer.WriteStringValue(logarithmicScale.LogarithmBase.ToString());
                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    foreach(var mappingToReferenceScaleItem in logarithmicScale.MappingToReferenceScale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(mappingToReferenceScaleItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    writer.WriteStringValue(logarithmicScale.MaximumPermissibleValue);
                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    writer.WriteStringValue(logarithmicScale.MinimumPermissibleValue);
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(logarithmicScale.Name);
                    writer.WritePropertyName("negativeValueConnotation"u8);
                    writer.WriteStringValue(logarithmicScale.NegativeValueConnotation);
                    writer.WritePropertyName("numberSet"u8);
                    writer.WriteStringValue(logarithmicScale.NumberSet.ToString());
                    writer.WritePropertyName("positiveValueConnotation"u8);
                    writer.WriteStringValue(logarithmicScale.PositiveValueConnotation);
                    writer.WritePropertyName("referenceQuantityKind"u8);
                    writer.WriteStringValue(logarithmicScale.ReferenceQuantityKind);
                    writer.WriteStartArray("referenceQuantityValue"u8);

                    foreach(var referenceQuantityValueItem in logarithmicScale.ReferenceQuantityValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referenceQuantityValueItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(logarithmicScale.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(logarithmicScale.ShortName);
                    writer.WritePropertyName("unit"u8);
                    writer.WriteStringValue(logarithmicScale.Unit);
                    writer.WriteStartArray("valueDefinition"u8);

                    foreach(var valueDefinitionItem in logarithmicScale.ValueDefinition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueDefinitionItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing LogarithmicScale for Version 1.1.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in logarithmicScale.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(logarithmicScale.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in logarithmicScale.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in logarithmicScale.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in logarithmicScale.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("exponent"u8);
                    writer.WriteStringValue(logarithmicScale.Exponent);
                    writer.WritePropertyName("factor"u8);
                    writer.WriteStringValue(logarithmicScale.Factor);
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in logarithmicScale.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(logarithmicScale.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsDeprecated);
                    writer.WritePropertyName("isMaximumInclusive"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsMaximumInclusive);
                    writer.WritePropertyName("isMinimumInclusive"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsMinimumInclusive);
                    writer.WritePropertyName("logarithmBase"u8);
                    writer.WriteStringValue(logarithmicScale.LogarithmBase.ToString());
                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    foreach(var mappingToReferenceScaleItem in logarithmicScale.MappingToReferenceScale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(mappingToReferenceScaleItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    writer.WriteStringValue(logarithmicScale.MaximumPermissibleValue);
                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    writer.WriteStringValue(logarithmicScale.MinimumPermissibleValue);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(logarithmicScale.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(logarithmicScale.Name);
                    writer.WritePropertyName("negativeValueConnotation"u8);
                    writer.WriteStringValue(logarithmicScale.NegativeValueConnotation);
                    writer.WritePropertyName("numberSet"u8);
                    writer.WriteStringValue(logarithmicScale.NumberSet.ToString());
                    writer.WritePropertyName("positiveValueConnotation"u8);
                    writer.WriteStringValue(logarithmicScale.PositiveValueConnotation);
                    writer.WritePropertyName("referenceQuantityKind"u8);
                    writer.WriteStringValue(logarithmicScale.ReferenceQuantityKind);
                    writer.WriteStartArray("referenceQuantityValue"u8);

                    foreach(var referenceQuantityValueItem in logarithmicScale.ReferenceQuantityValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referenceQuantityValueItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(logarithmicScale.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(logarithmicScale.ShortName);
                    writer.WritePropertyName("unit"u8);
                    writer.WriteStringValue(logarithmicScale.Unit);
                    writer.WriteStartArray("valueDefinition"u8);

                    foreach(var valueDefinitionItem in logarithmicScale.ValueDefinition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueDefinitionItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing LogarithmicScale for Version 1.2.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in logarithmicScale.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(logarithmicScale.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in logarithmicScale.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in logarithmicScale.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in logarithmicScale.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("exponent"u8);
                    writer.WriteStringValue(logarithmicScale.Exponent);
                    writer.WritePropertyName("factor"u8);
                    writer.WriteStringValue(logarithmicScale.Factor);
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in logarithmicScale.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(logarithmicScale.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsDeprecated);
                    writer.WritePropertyName("isMaximumInclusive"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsMaximumInclusive);
                    writer.WritePropertyName("isMinimumInclusive"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsMinimumInclusive);
                    writer.WritePropertyName("logarithmBase"u8);
                    writer.WriteStringValue(logarithmicScale.LogarithmBase.ToString());
                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    foreach(var mappingToReferenceScaleItem in logarithmicScale.MappingToReferenceScale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(mappingToReferenceScaleItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    writer.WriteStringValue(logarithmicScale.MaximumPermissibleValue);
                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    writer.WriteStringValue(logarithmicScale.MinimumPermissibleValue);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(logarithmicScale.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(logarithmicScale.Name);
                    writer.WritePropertyName("negativeValueConnotation"u8);
                    writer.WriteStringValue(logarithmicScale.NegativeValueConnotation);
                    writer.WritePropertyName("numberSet"u8);
                    writer.WriteStringValue(logarithmicScale.NumberSet.ToString());
                    writer.WritePropertyName("positiveValueConnotation"u8);
                    writer.WriteStringValue(logarithmicScale.PositiveValueConnotation);
                    writer.WritePropertyName("referenceQuantityKind"u8);
                    writer.WriteStringValue(logarithmicScale.ReferenceQuantityKind);
                    writer.WriteStartArray("referenceQuantityValue"u8);

                    foreach(var referenceQuantityValueItem in logarithmicScale.ReferenceQuantityValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referenceQuantityValueItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(logarithmicScale.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(logarithmicScale.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(logarithmicScale.ThingPreference);
                    writer.WritePropertyName("unit"u8);
                    writer.WriteStringValue(logarithmicScale.Unit);
                    writer.WriteStartArray("valueDefinition"u8);

                    foreach(var valueDefinitionItem in logarithmicScale.ValueDefinition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueDefinitionItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing LogarithmicScale for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(logarithmicScale.Actor.HasValue)
                    {
                        writer.WriteStringValue(logarithmicScale.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in logarithmicScale.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(logarithmicScale.ClassKind.ToString());
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in logarithmicScale.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in logarithmicScale.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in logarithmicScale.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("exponent"u8);
                    writer.WriteStringValue(logarithmicScale.Exponent);
                    writer.WritePropertyName("factor"u8);
                    writer.WriteStringValue(logarithmicScale.Factor);
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in logarithmicScale.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(logarithmicScale.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsDeprecated);
                    writer.WritePropertyName("isMaximumInclusive"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsMaximumInclusive);
                    writer.WritePropertyName("isMinimumInclusive"u8);
                    writer.WriteBooleanValue(logarithmicScale.IsMinimumInclusive);
                    writer.WritePropertyName("logarithmBase"u8);
                    writer.WriteStringValue(logarithmicScale.LogarithmBase.ToString());
                    writer.WriteStartArray("mappingToReferenceScale"u8);

                    foreach(var mappingToReferenceScaleItem in logarithmicScale.MappingToReferenceScale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(mappingToReferenceScaleItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("maximumPermissibleValue"u8);
                    writer.WriteStringValue(logarithmicScale.MaximumPermissibleValue);
                    writer.WritePropertyName("minimumPermissibleValue"u8);
                    writer.WriteStringValue(logarithmicScale.MinimumPermissibleValue);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(logarithmicScale.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(logarithmicScale.Name);
                    writer.WritePropertyName("negativeValueConnotation"u8);
                    writer.WriteStringValue(logarithmicScale.NegativeValueConnotation);
                    writer.WritePropertyName("numberSet"u8);
                    writer.WriteStringValue(logarithmicScale.NumberSet.ToString());
                    writer.WritePropertyName("positiveValueConnotation"u8);
                    writer.WriteStringValue(logarithmicScale.PositiveValueConnotation);
                    writer.WritePropertyName("referenceQuantityKind"u8);
                    writer.WriteStringValue(logarithmicScale.ReferenceQuantityKind);
                    writer.WriteStartArray("referenceQuantityValue"u8);

                    foreach(var referenceQuantityValueItem in logarithmicScale.ReferenceQuantityValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referenceQuantityValueItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(logarithmicScale.RevisionNumber);
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(logarithmicScale.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(logarithmicScale.ThingPreference);
                    writer.WritePropertyName("unit"u8);
                    writer.WriteStringValue(logarithmicScale.Unit);
                    writer.WriteStartArray("valueDefinition"u8);

                    foreach(var valueDefinitionItem in logarithmicScale.ValueDefinition.OrderBy(x => x, this.GuidComparer))
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
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
