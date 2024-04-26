// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedStyleResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="SharedStyleResolver"/> is to deserialize a JSON object to a <see cref="SharedStyle"/>
    /// </summary>
    public static class SharedStyleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SharedStyle"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SharedStyle"/> to instantiate</returns>
        public static CDP4Common.DTO.SharedStyle FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var sharedStyle = new CDP4Common.DTO.SharedStyle(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                sharedStyle.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                sharedStyle.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                sharedStyle.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fillColor"].IsNullOrEmpty())
            {
                sharedStyle.FillColor = jObject["fillColor"].ToObject<Guid?>();
            }

            if (!jObject["fillOpacity"].IsNullOrEmpty())
            {
                sharedStyle.FillOpacity = jObject["fillOpacity"].ToObject<float?>();
            }

            if (!jObject["fontBold"].IsNullOrEmpty())
            {
                sharedStyle.FontBold = jObject["fontBold"].ToObject<bool?>();
            }

            if (!jObject["fontColor"].IsNullOrEmpty())
            {
                sharedStyle.FontColor = jObject["fontColor"].ToObject<Guid?>();
            }

            if (!jObject["fontItalic"].IsNullOrEmpty())
            {
                sharedStyle.FontItalic = jObject["fontItalic"].ToObject<bool?>();
            }

            if (!jObject["fontName"].IsNullOrEmpty())
            {
                sharedStyle.FontName = jObject["fontName"].ToObject<string>();
            }

            if (!jObject["fontSize"].IsNullOrEmpty())
            {
                sharedStyle.FontSize = jObject["fontSize"].ToObject<float?>();
            }

            if (!jObject["fontStrokeThrough"].IsNullOrEmpty())
            {
                sharedStyle.FontStrokeThrough = jObject["fontStrokeThrough"].ToObject<bool?>();
            }

            if (!jObject["fontUnderline"].IsNullOrEmpty())
            {
                sharedStyle.FontUnderline = jObject["fontUnderline"].ToObject<bool?>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                sharedStyle.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                sharedStyle.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["strokeColor"].IsNullOrEmpty())
            {
                sharedStyle.StrokeColor = jObject["strokeColor"].ToObject<Guid?>();
            }

            if (!jObject["strokeOpacity"].IsNullOrEmpty())
            {
                sharedStyle.StrokeOpacity = jObject["strokeOpacity"].ToObject<float?>();
            }

            if (!jObject["strokeWidth"].IsNullOrEmpty())
            {
                sharedStyle.StrokeWidth = jObject["strokeWidth"].ToObject<float?>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                sharedStyle.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["usedColor"].IsNullOrEmpty())
            {
                sharedStyle.UsedColor.AddRange(jObject["usedColor"].ToObject<IEnumerable<Guid>>());
            }

            return sharedStyle;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
