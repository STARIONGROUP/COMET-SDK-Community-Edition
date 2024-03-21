// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedStyleSerializer.cs" company="RHEA System S.A.">
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
    using SharedStyle = CDP4Common.DTO.SharedStyle;

    /// <summary>
    /// The purpose of the <see cref="SharedStyleSerializer"/> class is to provide a <see cref="SharedStyle"/> specific serializer
    /// </summary>
    public class SharedStyleSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="SharedStyle"/> property into a <see cref="Utf8JsonWriter" />
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
                case "fillcolor":
                    var allowedVersionsForFillColor = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFillColor.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fillColor"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "fillopacity":
                    var allowedVersionsForFillOpacity = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFillOpacity.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fillOpacity"u8);
                    
                    if(value != null)
                    {
                        writer.WriteNumberValue((float)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "fontbold":
                    var allowedVersionsForFontBold = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFontBold.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fontBold"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "fontcolor":
                    var allowedVersionsForFontColor = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFontColor.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fontColor"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "fontitalic":
                    var allowedVersionsForFontItalic = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFontItalic.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fontItalic"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "fontname":
                    var allowedVersionsForFontName = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFontName.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fontName"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "fontsize":
                    var allowedVersionsForFontSize = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFontSize.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fontSize"u8);
                    
                    if(value != null)
                    {
                        writer.WriteNumberValue((float)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "fontstrokethrough":
                    var allowedVersionsForFontStrokeThrough = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFontStrokeThrough.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fontStrokeThrough"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "fontunderline":
                    var allowedVersionsForFontUnderline = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForFontUnderline.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("fontUnderline"u8);
                    
                    if(value != null)
                    {
                        writer.WriteBooleanValue((bool)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "iid":
                    var allowedVersionsForIid = new List<string>
                    {
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
                case "revisionnumber":
                    var allowedVersionsForRevisionNumber = new List<string>
                    {
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
                case "strokecolor":
                    var allowedVersionsForStrokeColor = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForStrokeColor.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("strokeColor"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "strokeopacity":
                    var allowedVersionsForStrokeOpacity = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForStrokeOpacity.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("strokeOpacity"u8);
                    
                    if(value != null)
                    {
                        writer.WriteNumberValue((float)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "strokewidth":
                    var allowedVersionsForStrokeWidth = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForStrokeWidth.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("strokeWidth"u8);
                    
                    if(value != null)
                    {
                        writer.WriteNumberValue((float)value);
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
                case "usedcolor":
                    var allowedVersionsForUsedColor = new List<string>
                    {
                        "1.1.0",
                        "1.2.0",
                        "1.3.0",
                    };

                    if(!allowedVersionsForUsedColor.Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("usedColor"u8);

                    if(value is IEnumerable<object> objectListUsedColor)
                    {
                        foreach(var usedColorItem in objectListUsedColor.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(usedColorItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the SharedStyle");
            }
        }

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="SharedStyle" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not SharedStyle sharedStyle)
            {
                throw new ArgumentException("The thing shall be a SharedStyle", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.1.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of SharedStyle since Version is below 1.1.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.1.0":
                    Logger.Log(LogLevel.Debug, "Serializing SharedStyle for Version 1.1.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(sharedStyle.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in sharedStyle.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in sharedStyle.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("fillColor"u8);

                    if(sharedStyle.FillColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.FillColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fillOpacity"u8);

                    if(sharedStyle.FillOpacity.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.FillOpacity.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontBold"u8);

                    if(sharedStyle.FontBold.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontBold.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontColor"u8);

                    if(sharedStyle.FontColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.FontColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontItalic"u8);

                    if(sharedStyle.FontItalic.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontItalic.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontName"u8);
                    writer.WriteStringValue(sharedStyle.FontName);
                    writer.WritePropertyName("fontSize"u8);

                    if(sharedStyle.FontSize.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.FontSize.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontStrokeThrough"u8);

                    if(sharedStyle.FontStrokeThrough.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontStrokeThrough.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontUnderline"u8);

                    if(sharedStyle.FontUnderline.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontUnderline.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(sharedStyle.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(sharedStyle.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(sharedStyle.Name);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(sharedStyle.RevisionNumber);
                    writer.WritePropertyName("strokeColor"u8);

                    if(sharedStyle.StrokeColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.StrokeColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("strokeOpacity"u8);

                    if(sharedStyle.StrokeOpacity.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.StrokeOpacity.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("strokeWidth"u8);

                    if(sharedStyle.StrokeWidth.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.StrokeWidth.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("usedColor"u8);

                    foreach(var usedColorItem in sharedStyle.UsedColor.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(usedColorItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Debug, "Serializing SharedStyle for Version 1.2.0");
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(sharedStyle.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in sharedStyle.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in sharedStyle.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("fillColor"u8);

                    if(sharedStyle.FillColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.FillColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fillOpacity"u8);

                    if(sharedStyle.FillOpacity.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.FillOpacity.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontBold"u8);

                    if(sharedStyle.FontBold.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontBold.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontColor"u8);

                    if(sharedStyle.FontColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.FontColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontItalic"u8);

                    if(sharedStyle.FontItalic.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontItalic.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontName"u8);
                    writer.WriteStringValue(sharedStyle.FontName);
                    writer.WritePropertyName("fontSize"u8);

                    if(sharedStyle.FontSize.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.FontSize.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontStrokeThrough"u8);

                    if(sharedStyle.FontStrokeThrough.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontStrokeThrough.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontUnderline"u8);

                    if(sharedStyle.FontUnderline.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontUnderline.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(sharedStyle.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(sharedStyle.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(sharedStyle.Name);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(sharedStyle.RevisionNumber);
                    writer.WritePropertyName("strokeColor"u8);

                    if(sharedStyle.StrokeColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.StrokeColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("strokeOpacity"u8);

                    if(sharedStyle.StrokeOpacity.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.StrokeOpacity.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("strokeWidth"u8);

                    if(sharedStyle.StrokeWidth.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.StrokeWidth.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(sharedStyle.ThingPreference);
                    writer.WriteStartArray("usedColor"u8);

                    foreach(var usedColorItem in sharedStyle.UsedColor.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(usedColorItem);
                    }

                    writer.WriteEndArray();
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Debug, "Serializing SharedStyle for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(sharedStyle.Actor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(sharedStyle.ClassKind.ToString());
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in sharedStyle.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in sharedStyle.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    writer.WritePropertyName("fillColor"u8);

                    if(sharedStyle.FillColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.FillColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fillOpacity"u8);

                    if(sharedStyle.FillOpacity.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.FillOpacity.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontBold"u8);

                    if(sharedStyle.FontBold.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontBold.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontColor"u8);

                    if(sharedStyle.FontColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.FontColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontItalic"u8);

                    if(sharedStyle.FontItalic.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontItalic.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontName"u8);
                    writer.WriteStringValue(sharedStyle.FontName);
                    writer.WritePropertyName("fontSize"u8);

                    if(sharedStyle.FontSize.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.FontSize.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontStrokeThrough"u8);

                    if(sharedStyle.FontStrokeThrough.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontStrokeThrough.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("fontUnderline"u8);

                    if(sharedStyle.FontUnderline.HasValue)
                    {
                        writer.WriteBooleanValue(sharedStyle.FontUnderline.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(sharedStyle.Iid);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(sharedStyle.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(sharedStyle.Name);
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(sharedStyle.RevisionNumber);
                    writer.WritePropertyName("strokeColor"u8);

                    if(sharedStyle.StrokeColor.HasValue)
                    {
                        writer.WriteStringValue(sharedStyle.StrokeColor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("strokeOpacity"u8);

                    if(sharedStyle.StrokeOpacity.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.StrokeOpacity.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("strokeWidth"u8);

                    if(sharedStyle.StrokeWidth.HasValue)
                    {
                        writer.WriteNumberValue(sharedStyle.StrokeWidth.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(sharedStyle.ThingPreference);
                    writer.WriteStartArray("usedColor"u8);

                    foreach(var usedColorItem in sharedStyle.UsedColor.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(usedColorItem);
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
