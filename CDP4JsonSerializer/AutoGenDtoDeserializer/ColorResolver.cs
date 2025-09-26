// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    /// The purpose of the <see cref="ColorResolver"/> is to deserialize a JSON object to a <see cref="Color"/>
    /// </summary>
    public static class ColorResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Color"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Color"/> to instantiate</returns>
        public static CDP4Common.DTO.Color FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var color = new CDP4Common.DTO.Color(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                color.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["blue"].IsNullOrEmpty())
            {
                color.Blue = jObject["blue"].ToObject<int>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                color.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                color.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["green"].IsNullOrEmpty())
            {
                color.Green = jObject["green"].ToObject<int>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                color.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                color.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["red"].IsNullOrEmpty())
            {
                color.Red = jObject["red"].ToObject<int>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                color.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return color;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
