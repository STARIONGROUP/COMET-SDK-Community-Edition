// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnedStyleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="OwnedStyleResolver"/> is to deserialize a JSON object to a <see cref="OwnedStyle"/>
    /// </summary>
    public static class OwnedStyleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="OwnedStyle"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="OwnedStyle"/> to instantiate</returns>
        public static CDP4Common.DTO.OwnedStyle FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var ownedStyle = new CDP4Common.DTO.OwnedStyle(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                ownedStyle.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                ownedStyle.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("fillColor", out var fillColorProperty))
            {
                ownedStyle.FillColor = fillColorProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("fillOpacity", out var fillOpacityProperty))
            {
                ownedStyle.FillOpacity = fillOpacityProperty.Deserialize<float?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("fontBold", out var fontBoldProperty))
            {
                ownedStyle.FontBold = fontBoldProperty.Deserialize<bool?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("fontColor", out var fontColorProperty))
            {
                ownedStyle.FontColor = fontColorProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("fontItalic", out var fontItalicProperty))
            {
                ownedStyle.FontItalic = fontItalicProperty.Deserialize<bool?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("fontName", out var fontNameProperty))
            {
                ownedStyle.FontName = fontNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("fontSize", out var fontSizeProperty))
            {
                ownedStyle.FontSize = fontSizeProperty.Deserialize<float?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("fontStrokeThrough", out var fontStrokeThroughProperty))
            {
                ownedStyle.FontStrokeThrough = fontStrokeThroughProperty.Deserialize<bool?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("fontUnderline", out var fontUnderlineProperty))
            {
                ownedStyle.FontUnderline = fontUnderlineProperty.Deserialize<bool?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                ownedStyle.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                ownedStyle.Name = nameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("strokeColor", out var strokeColorProperty))
            {
                ownedStyle.StrokeColor = strokeColorProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("strokeOpacity", out var strokeOpacityProperty))
            {
                ownedStyle.StrokeOpacity = strokeOpacityProperty.Deserialize<float?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("strokeWidth", out var strokeWidthProperty))
            {
                ownedStyle.StrokeWidth = strokeWidthProperty.Deserialize<float?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                ownedStyle.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("usedColor", out var usedColorProperty))
            {
                ownedStyle.UsedColor.AddRange(usedColorProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            return ownedStyle;
        }
    }
}
