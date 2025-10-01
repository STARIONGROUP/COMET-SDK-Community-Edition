// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnedStyleResolver.cs" company="Starion Group S.A.">
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
    using System.Collections.Generic;
    using System.Text.Json;

    using CDP4Common.Types;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="OwnedStyleResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.OwnedStyle"/>
    /// </summary>
    public static class OwnedStyleResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.OwnedStyle"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.OwnedStyle"/> to instantiate</returns>
        public static CDP4Common.DTO.OwnedStyle FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the OwnedStyleResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var ownedStyle = new CDP4Common.DTO.OwnedStyle(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    ownedStyle.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    ownedStyle.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("fillColor"u8, out var fillColorProperty))
            {
                if(fillColorProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.FillColor = null;
                }
                else
                {
                    ownedStyle.FillColor = fillColorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("fillOpacity"u8, out var fillOpacityProperty))
            {
                if(fillOpacityProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.FillOpacity = null;
                }
                else
                {
                    ownedStyle.FillOpacity = fillOpacityProperty.GetSingle();
                }
            }

            if (jsonElement.TryGetProperty("fontBold"u8, out var fontBoldProperty))
            {
                if(fontBoldProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.FontBold = null;
                }
                else
                {
                    ownedStyle.FontBold = fontBoldProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("fontColor"u8, out var fontColorProperty))
            {
                if(fontColorProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.FontColor = null;
                }
                else
                {
                    ownedStyle.FontColor = fontColorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("fontItalic"u8, out var fontItalicProperty))
            {
                if(fontItalicProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.FontItalic = null;
                }
                else
                {
                    ownedStyle.FontItalic = fontItalicProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("fontName"u8, out var fontNameProperty))
            {
                if(fontNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale fontName property of the ownedStyle {id} is null", ownedStyle.Iid);
                }
                else
                {
                    ownedStyle.FontName = fontNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("fontSize"u8, out var fontSizeProperty))
            {
                if(fontSizeProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.FontSize = null;
                }
                else
                {
                    ownedStyle.FontSize = fontSizeProperty.GetSingle();
                }
            }

            if (jsonElement.TryGetProperty("fontStrokeThrough"u8, out var fontStrokeThroughProperty))
            {
                if(fontStrokeThroughProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.FontStrokeThrough = null;
                }
                else
                {
                    ownedStyle.FontStrokeThrough = fontStrokeThroughProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("fontUnderline"u8, out var fontUnderlineProperty))
            {
                if(fontUnderlineProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.FontUnderline = null;
                }
                else
                {
                    ownedStyle.FontUnderline = fontUnderlineProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the ownedStyle {id} is null", ownedStyle.Iid);
                }
                else
                {
                    ownedStyle.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale name property of the ownedStyle {id} is null", ownedStyle.Iid);
                }
                else
                {
                    ownedStyle.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("strokeColor"u8, out var strokeColorProperty))
            {
                if(strokeColorProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.StrokeColor = null;
                }
                else
                {
                    ownedStyle.StrokeColor = strokeColorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("strokeOpacity"u8, out var strokeOpacityProperty))
            {
                if(strokeOpacityProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.StrokeOpacity = null;
                }
                else
                {
                    ownedStyle.StrokeOpacity = strokeOpacityProperty.GetSingle();
                }
            }

            if (jsonElement.TryGetProperty("strokeWidth"u8, out var strokeWidthProperty))
            {
                if(strokeWidthProperty.ValueKind == JsonValueKind.Null)
                {
                    ownedStyle.StrokeWidth = null;
                }
                else
                {
                    ownedStyle.StrokeWidth = strokeWidthProperty.GetSingle();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the ownedStyle {id} is null", ownedStyle.Iid);
                }
                else
                {
                    ownedStyle.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("usedColor"u8, out var usedColorProperty) && usedColorProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in usedColorProperty.EnumerateArray())
                {
                    ownedStyle.UsedColor.Add(element.GetGuid());
                }
            }

            return ownedStyle;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
