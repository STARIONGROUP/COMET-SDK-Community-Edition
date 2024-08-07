// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrefixedUnitResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="PrefixedUnitResolver"/> is to deserialize a JSON object to a <see cref="PrefixedUnit"/>
    /// </summary>
    public static class PrefixedUnitResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="PrefixedUnit"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="PrefixedUnit"/> to instantiate</returns>
        public static CDP4Common.DTO.PrefixedUnit FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var prefixedUnit = new CDP4Common.DTO.PrefixedUnit(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                prefixedUnit.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                prefixedUnit.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                prefixedUnit.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                prefixedUnit.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                prefixedUnit.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                prefixedUnit.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                prefixedUnit.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                prefixedUnit.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["prefix"].IsNullOrEmpty())
            {
                prefixedUnit.Prefix = jObject["prefix"].ToObject<Guid>();
            }

            if (!jObject["referenceUnit"].IsNullOrEmpty())
            {
                prefixedUnit.ReferenceUnit = jObject["referenceUnit"].ToObject<Guid>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                prefixedUnit.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return prefixedUnit;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
