// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedStyleResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Jaime Bernar
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4JsonSerializer_SystemTextJson.EnumDeserializers;
    
    /// <summary>
    /// The purpose of the <see cref="SharedStyleResolver"/> is to deserialize a JSON object to a <see cref="SharedStyle"/>
    /// </summary>
    public static class SharedStyleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="SharedStyle"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="SharedStyle"/> to instantiate</returns>
        public static CDP4Common.DTO.SharedStyle FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var sharedStyle = new CDP4Common.DTO.SharedStyle(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                sharedStyle.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                sharedStyle.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("fillColor", out var fillColorProperty))
            {
                sharedStyle.FillColor = fillColorProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("fillOpacity", out var fillOpacityProperty))
            {
                sharedStyle.FillOpacity = fillOpacityProperty.Deserialize<float?>();
            }

            if (jObject.TryGetProperty("fontBold", out var fontBoldProperty))
            {
                sharedStyle.FontBold = fontBoldProperty.Deserialize<bool?>();
            }

            if (jObject.TryGetProperty("fontColor", out var fontColorProperty))
            {
                sharedStyle.FontColor = fontColorProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("fontItalic", out var fontItalicProperty))
            {
                sharedStyle.FontItalic = fontItalicProperty.Deserialize<bool?>();
            }

            if (jObject.TryGetProperty("fontName", out var fontNameProperty))
            {
                sharedStyle.FontName = fontNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("fontSize", out var fontSizeProperty))
            {
                sharedStyle.FontSize = fontSizeProperty.Deserialize<float?>();
            }

            if (jObject.TryGetProperty("fontStrokeThrough", out var fontStrokeThroughProperty))
            {
                sharedStyle.FontStrokeThrough = fontStrokeThroughProperty.Deserialize<bool?>();
            }

            if (jObject.TryGetProperty("fontUnderline", out var fontUnderlineProperty))
            {
                sharedStyle.FontUnderline = fontUnderlineProperty.Deserialize<bool?>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                sharedStyle.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                sharedStyle.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("strokeColor", out var strokeColorProperty))
            {
                sharedStyle.StrokeColor = strokeColorProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("strokeOpacity", out var strokeOpacityProperty))
            {
                sharedStyle.StrokeOpacity = strokeOpacityProperty.Deserialize<float?>();
            }

            if (jObject.TryGetProperty("strokeWidth", out var strokeWidthProperty))
            {
                sharedStyle.StrokeWidth = strokeWidthProperty.Deserialize<float?>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                sharedStyle.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("usedColor", out var usedColorProperty))
            {
                sharedStyle.UsedColor.AddRange(usedColorProperty.Deserialize<IEnumerable<Guid>>());
            }

            return sharedStyle;
        }
    }
}
