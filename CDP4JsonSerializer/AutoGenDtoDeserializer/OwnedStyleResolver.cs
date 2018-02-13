#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnedStyleResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="OwnedStyleResolver"/> is to deserialize a JSON object to a <see cref="OwnedStyle"/>
    /// </summary>
    public static class OwnedStyleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="OwnedStyle"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="OwnedStyle"/> to instantiate</returns>
        public static CDP4Common.DTO.OwnedStyle FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var ownedStyle = new CDP4Common.DTO.OwnedStyle(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                ownedStyle.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                ownedStyle.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fillColor"].IsNullOrEmpty())
            {
                ownedStyle.FillColor = jObject["fillColor"].ToObject<Guid?>();
            }

            if (!jObject["fillOpacity"].IsNullOrEmpty())
            {
                ownedStyle.FillOpacity = jObject["fillOpacity"].ToObject<float?>();
            }

            if (!jObject["fontBold"].IsNullOrEmpty())
            {
                ownedStyle.FontBold = jObject["fontBold"].ToObject<bool?>();
            }

            if (!jObject["fontColor"].IsNullOrEmpty())
            {
                ownedStyle.FontColor = jObject["fontColor"].ToObject<Guid?>();
            }

            if (!jObject["fontItalic"].IsNullOrEmpty())
            {
                ownedStyle.FontItalic = jObject["fontItalic"].ToObject<bool?>();
            }

            if (!jObject["fontName"].IsNullOrEmpty())
            {
                ownedStyle.FontName = jObject["fontName"].ToObject<string>();
            }

            if (!jObject["fontSize"].IsNullOrEmpty())
            {
                ownedStyle.FontSize = jObject["fontSize"].ToObject<float?>();
            }

            if (!jObject["fontStrokeThrough"].IsNullOrEmpty())
            {
                ownedStyle.FontStrokeThrough = jObject["fontStrokeThrough"].ToObject<bool?>();
            }

            if (!jObject["fontUnderline"].IsNullOrEmpty())
            {
                ownedStyle.FontUnderline = jObject["fontUnderline"].ToObject<bool?>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                ownedStyle.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                ownedStyle.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["strokeColor"].IsNullOrEmpty())
            {
                ownedStyle.StrokeColor = jObject["strokeColor"].ToObject<Guid?>();
            }

            if (!jObject["strokeOpacity"].IsNullOrEmpty())
            {
                ownedStyle.StrokeOpacity = jObject["strokeOpacity"].ToObject<float?>();
            }

            if (!jObject["strokeWidth"].IsNullOrEmpty())
            {
                ownedStyle.StrokeWidth = jObject["strokeWidth"].ToObject<float?>();
            }

            if (!jObject["usedColor"].IsNullOrEmpty())
            {
                ownedStyle.UsedColor.AddRange(jObject["usedColor"].ToObject<IEnumerable<Guid>>());
            }

            return ownedStyle;
        }
    }
}
