// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteReferenceDataLibrarySerializer.cs" company="RHEA System S.A.">
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
    using SiteReferenceDataLibrary = CDP4Common.DTO.SiteReferenceDataLibrary;

    /// <summary>
    /// The purpose of the <see cref="SiteReferenceDataLibrarySerializer"/> class is to provide a <see cref="SiteReferenceDataLibrary"/> specific serializer
    /// </summary>
    public class SiteReferenceDataLibrarySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="SiteReferenceDataLibrary"/> property into a <see cref="Utf8JsonWriter" />
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
                case "basequantitykind":
                    var allowedVersionsForBaseQuantityKind = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForBaseQuantityKind.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("baseQuantityKind"u8);

                    if(value is IEnumerable<object> objectListBaseQuantityKind)
                    {
                        foreach(var baseQuantityKindItem in objectListBaseQuantityKind.OfType<OrderedItem>().OrderBy(x => x, this.OrderedItemComparer))
                        {
                            writer.WriteOrderedItem(baseQuantityKindItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "baseunit":
                    var allowedVersionsForBaseUnit = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForBaseUnit.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("baseUnit"u8);

                    if(value is IEnumerable<object> objectListBaseUnit)
                    {
                        foreach(var baseUnitItem in objectListBaseUnit.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(baseUnitItem);
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
                case "constant":
                    var allowedVersionsForConstant = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForConstant.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("constant"u8);

                    if(value is IEnumerable<object> objectListConstant)
                    {
                        foreach(var constantItem in objectListConstant.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(constantItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "definedcategory":
                    var allowedVersionsForDefinedCategory = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForDefinedCategory.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("definedCategory"u8);

                    if(value is IEnumerable<object> objectListDefinedCategory)
                    {
                        foreach(var definedCategoryItem in objectListDefinedCategory.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(definedCategoryItem);
                        }
                    }
                    
                    writer.WriteEndArray();
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
                case "filetype":
                    var allowedVersionsForFileType = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFileType.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("fileType"u8);

                    if(value is IEnumerable<object> objectListFileType)
                    {
                        foreach(var fileTypeItem in objectListFileType.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(fileTypeItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "glossary":
                    var allowedVersionsForGlossary = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForGlossary.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("glossary"u8);

                    if(value is IEnumerable<object> objectListGlossary)
                    {
                        foreach(var glossaryItem in objectListGlossary.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(glossaryItem);
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

                    writer.WriteStartArray("parameterType"u8);

                    if(value is IEnumerable<object> objectListParameterType)
                    {
                        foreach(var parameterTypeItem in objectListParameterType.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(parameterTypeItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "referencesource":
                    var allowedVersionsForReferenceSource = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForReferenceSource.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("referenceSource"u8);

                    if(value is IEnumerable<object> objectListReferenceSource)
                    {
                        foreach(var referenceSourceItem in objectListReferenceSource.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(referenceSourceItem);
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

                    writer.WritePropertyName("requiredRdl"u8);
                    
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
                case "rule":
                    var allowedVersionsForRule = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForRule.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("rule"u8);

                    if(value is IEnumerable<object> objectListRule)
                    {
                        foreach(var ruleItem in objectListRule.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(ruleItem);
                        }
                    }
                    
                    writer.WriteEndArray();
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

                    writer.WriteStartArray("scale"u8);

                    if(value is IEnumerable<object> objectListScale)
                    {
                        foreach(var scaleItem in objectListScale.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(scaleItem);
                        }
                    }
                    
                    writer.WriteEndArray();
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

                    writer.WriteStartArray("unit"u8);

                    if(value is IEnumerable<object> objectListUnit)
                    {
                        foreach(var unitItem in objectListUnit.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(unitItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "unitprefix":
                    var allowedVersionsForUnitPrefix = new List<string>
                    {
                        "1.0.0",
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForUnitPrefix.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("unitPrefix"u8);

                    if(value is IEnumerable<object> objectListUnitPrefix)
                    {
                        foreach(var unitPrefixItem in objectListUnitPrefix.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(unitPrefixItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the SiteReferenceDataLibrary");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="SiteReferenceDataLibrary" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not SiteReferenceDataLibrary siteReferenceDataLibrary)
            {
                throw new ArgumentException("The thing shall be a SiteReferenceDataLibrary", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of SiteReferenceDataLibrary since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Debug, "Serializing SiteReferenceDataLibrary for Version 1.0.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in siteReferenceDataLibrary.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("baseQuantityKind"u8);

                    foreach(var baseQuantityKindItem in siteReferenceDataLibrary.BaseQuantityKind.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(baseQuantityKindItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("baseUnit"u8);

                    foreach(var baseUnitItem in siteReferenceDataLibrary.BaseUnit.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(baseUnitItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ClassKind.ToString());
                    writer.WriteStartArray("constant"u8);

                    foreach(var constantItem in siteReferenceDataLibrary.Constant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(constantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("definedCategory"u8);

                    foreach(var definedCategoryItem in siteReferenceDataLibrary.DefinedCategory.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definedCategoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in siteReferenceDataLibrary.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("fileType"u8);

                    foreach(var fileTypeItem in siteReferenceDataLibrary.FileType.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(fileTypeItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("glossary"u8);

                    foreach(var glossaryItem in siteReferenceDataLibrary.Glossary.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(glossaryItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in siteReferenceDataLibrary.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(siteReferenceDataLibrary.IsDeprecated);
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.Name);
                    writer.WriteStartArray("parameterType"u8);

                    foreach(var parameterTypeItem in siteReferenceDataLibrary.ParameterType.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterTypeItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("referenceSource"u8);

                    foreach(var referenceSourceItem in siteReferenceDataLibrary.ReferenceSource.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referenceSourceItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("requiredRdl"u8);

                    if(siteReferenceDataLibrary.RequiredRdl.HasValue)
                    {
                        writer.WriteStringValue(siteReferenceDataLibrary.RequiredRdl.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(siteReferenceDataLibrary.RevisionNumber);
                    writer.WriteStartArray("rule"u8);

                    foreach(var ruleItem in siteReferenceDataLibrary.Rule.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(ruleItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("scale"u8);

                    foreach(var scaleItem in siteReferenceDataLibrary.Scale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(scaleItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ShortName);
                    writer.WriteStartArray("unit"u8);

                    foreach(var unitItem in siteReferenceDataLibrary.Unit.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(unitItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("unitPrefix"u8);

                    foreach(var unitPrefixItem in siteReferenceDataLibrary.UnitPrefix.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(unitPrefixItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing SiteReferenceDataLibrary for Version 1.1.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in siteReferenceDataLibrary.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("baseQuantityKind"u8);

                    foreach(var baseQuantityKindItem in siteReferenceDataLibrary.BaseQuantityKind.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(baseQuantityKindItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("baseUnit"u8);

                    foreach(var baseUnitItem in siteReferenceDataLibrary.BaseUnit.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(baseUnitItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ClassKind.ToString());
                    writer.WriteStartArray("constant"u8);

                    foreach(var constantItem in siteReferenceDataLibrary.Constant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(constantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("definedCategory"u8);

                    foreach(var definedCategoryItem in siteReferenceDataLibrary.DefinedCategory.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definedCategoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in siteReferenceDataLibrary.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in siteReferenceDataLibrary.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in siteReferenceDataLibrary.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("fileType"u8);

                    foreach(var fileTypeItem in siteReferenceDataLibrary.FileType.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(fileTypeItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("glossary"u8);

                    foreach(var glossaryItem in siteReferenceDataLibrary.Glossary.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(glossaryItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in siteReferenceDataLibrary.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(siteReferenceDataLibrary.IsDeprecated);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.Name);
                    writer.WriteStartArray("parameterType"u8);

                    foreach(var parameterTypeItem in siteReferenceDataLibrary.ParameterType.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterTypeItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("referenceSource"u8);

                    foreach(var referenceSourceItem in siteReferenceDataLibrary.ReferenceSource.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referenceSourceItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("requiredRdl"u8);

                    if(siteReferenceDataLibrary.RequiredRdl.HasValue)
                    {
                        writer.WriteStringValue(siteReferenceDataLibrary.RequiredRdl.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(siteReferenceDataLibrary.RevisionNumber);
                    writer.WriteStartArray("rule"u8);

                    foreach(var ruleItem in siteReferenceDataLibrary.Rule.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(ruleItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("scale"u8);

                    foreach(var scaleItem in siteReferenceDataLibrary.Scale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(scaleItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ShortName);
                    writer.WriteStartArray("unit"u8);

                    foreach(var unitItem in siteReferenceDataLibrary.Unit.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(unitItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("unitPrefix"u8);

                    foreach(var unitPrefixItem in siteReferenceDataLibrary.UnitPrefix.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(unitPrefixItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing SiteReferenceDataLibrary for Version 1.2.0");
                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in siteReferenceDataLibrary.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("baseQuantityKind"u8);

                    foreach(var baseQuantityKindItem in siteReferenceDataLibrary.BaseQuantityKind.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(baseQuantityKindItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("baseUnit"u8);

                    foreach(var baseUnitItem in siteReferenceDataLibrary.BaseUnit.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(baseUnitItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ClassKind.ToString());
                    writer.WriteStartArray("constant"u8);

                    foreach(var constantItem in siteReferenceDataLibrary.Constant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(constantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("definedCategory"u8);

                    foreach(var definedCategoryItem in siteReferenceDataLibrary.DefinedCategory.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definedCategoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in siteReferenceDataLibrary.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in siteReferenceDataLibrary.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in siteReferenceDataLibrary.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("fileType"u8);

                    foreach(var fileTypeItem in siteReferenceDataLibrary.FileType.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(fileTypeItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("glossary"u8);

                    foreach(var glossaryItem in siteReferenceDataLibrary.Glossary.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(glossaryItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in siteReferenceDataLibrary.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(siteReferenceDataLibrary.IsDeprecated);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.Name);
                    writer.WriteStartArray("parameterType"u8);

                    foreach(var parameterTypeItem in siteReferenceDataLibrary.ParameterType.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterTypeItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("referenceSource"u8);

                    foreach(var referenceSourceItem in siteReferenceDataLibrary.ReferenceSource.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referenceSourceItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("requiredRdl"u8);

                    if(siteReferenceDataLibrary.RequiredRdl.HasValue)
                    {
                        writer.WriteStringValue(siteReferenceDataLibrary.RequiredRdl.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(siteReferenceDataLibrary.RevisionNumber);
                    writer.WriteStartArray("rule"u8);

                    foreach(var ruleItem in siteReferenceDataLibrary.Rule.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(ruleItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("scale"u8);

                    foreach(var scaleItem in siteReferenceDataLibrary.Scale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(scaleItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ThingPreference);
                    writer.WriteStartArray("unit"u8);

                    foreach(var unitItem in siteReferenceDataLibrary.Unit.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(unitItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("unitPrefix"u8);

                    foreach(var unitPrefixItem in siteReferenceDataLibrary.UnitPrefix.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(unitPrefixItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing SiteReferenceDataLibrary for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(siteReferenceDataLibrary.Actor.HasValue)
                    {
                        writer.WriteStringValue(siteReferenceDataLibrary.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("alias"u8);

                    foreach(var aliasItem in siteReferenceDataLibrary.Alias.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(aliasItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("baseQuantityKind"u8);

                    foreach(var baseQuantityKindItem in siteReferenceDataLibrary.BaseQuantityKind.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(baseQuantityKindItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("baseUnit"u8);

                    foreach(var baseUnitItem in siteReferenceDataLibrary.BaseUnit.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(baseUnitItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ClassKind.ToString());
                    writer.WriteStartArray("constant"u8);

                    foreach(var constantItem in siteReferenceDataLibrary.Constant.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(constantItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("definedCategory"u8);

                    foreach(var definedCategoryItem in siteReferenceDataLibrary.DefinedCategory.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definedCategoryItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("definition"u8);

                    foreach(var definitionItem in siteReferenceDataLibrary.Definition.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(definitionItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in siteReferenceDataLibrary.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in siteReferenceDataLibrary.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("fileType"u8);

                    foreach(var fileTypeItem in siteReferenceDataLibrary.FileType.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(fileTypeItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("glossary"u8);

                    foreach(var glossaryItem in siteReferenceDataLibrary.Glossary.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(glossaryItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("hyperLink"u8);

                    foreach(var hyperLinkItem in siteReferenceDataLibrary.HyperLink.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(hyperLinkItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.Iid);
                    writer.WritePropertyName("isDeprecated"u8);
                    writer.WriteBooleanValue(siteReferenceDataLibrary.IsDeprecated);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.Name);
                    writer.WriteStartArray("parameterType"u8);

                    foreach(var parameterTypeItem in siteReferenceDataLibrary.ParameterType.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(parameterTypeItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("referenceSource"u8);

                    foreach(var referenceSourceItem in siteReferenceDataLibrary.ReferenceSource.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(referenceSourceItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("requiredRdl"u8);

                    if(siteReferenceDataLibrary.RequiredRdl.HasValue)
                    {
                        writer.WriteStringValue(siteReferenceDataLibrary.RequiredRdl.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(siteReferenceDataLibrary.RevisionNumber);
                    writer.WriteStartArray("rule"u8);

                    foreach(var ruleItem in siteReferenceDataLibrary.Rule.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(ruleItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("scale"u8);

                    foreach(var scaleItem in siteReferenceDataLibrary.Scale.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(scaleItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("shortName"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ShortName);
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(siteReferenceDataLibrary.ThingPreference);
                    writer.WriteStartArray("unit"u8);

                    foreach(var unitItem in siteReferenceDataLibrary.Unit.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(unitItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("unitPrefix"u8);

                    foreach(var unitPrefixItem in siteReferenceDataLibrary.UnitPrefix.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(unitPrefixItem);
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
