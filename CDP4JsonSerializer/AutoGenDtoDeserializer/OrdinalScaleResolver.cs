// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrdinalScaleResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="OrdinalScaleResolver"/> is to deserialize a JSON object to a <see cref="OrdinalScale"/>
    /// </summary>
    public static class OrdinalScaleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="OrdinalScale"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="OrdinalScale"/> to instantiate</returns>
        public static CDP4Common.DTO.OrdinalScale FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var ordinalScale = new CDP4Common.DTO.OrdinalScale(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                ordinalScale.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                ordinalScale.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                ordinalScale.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                ordinalScale.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                ordinalScale.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                ordinalScale.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                ordinalScale.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["isMaximumInclusive"].IsNullOrEmpty())
            {
                ordinalScale.IsMaximumInclusive = jObject["isMaximumInclusive"].ToObject<bool>();
            }

            if (!jObject["isMinimumInclusive"].IsNullOrEmpty())
            {
                ordinalScale.IsMinimumInclusive = jObject["isMinimumInclusive"].ToObject<bool>();
            }

            if (!jObject["mappingToReferenceScale"].IsNullOrEmpty())
            {
                ordinalScale.MappingToReferenceScale.AddRange(jObject["mappingToReferenceScale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["maximumPermissibleValue"].IsNullOrEmpty())
            {
                ordinalScale.MaximumPermissibleValue = jObject["maximumPermissibleValue"].ToObject<string>();
            }

            if (!jObject["minimumPermissibleValue"].IsNullOrEmpty())
            {
                ordinalScale.MinimumPermissibleValue = jObject["minimumPermissibleValue"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                ordinalScale.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                ordinalScale.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["negativeValueConnotation"].IsNullOrEmpty())
            {
                ordinalScale.NegativeValueConnotation = jObject["negativeValueConnotation"].ToObject<string>();
            }

            if (!jObject["numberSet"].IsNullOrEmpty())
            {
                ordinalScale.NumberSet = jObject["numberSet"].ToObject<NumberSetKind>();
            }

            if (!jObject["positiveValueConnotation"].IsNullOrEmpty())
            {
                ordinalScale.PositiveValueConnotation = jObject["positiveValueConnotation"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                ordinalScale.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                ordinalScale.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["unit"].IsNullOrEmpty())
            {
                ordinalScale.Unit = jObject["unit"].ToObject<Guid>();
            }

            if (!jObject["useShortNameValues"].IsNullOrEmpty())
            {
                ordinalScale.UseShortNameValues = jObject["useShortNameValues"].ToObject<bool>();
            }

            if (!jObject["valueDefinition"].IsNullOrEmpty())
            {
                ordinalScale.ValueDefinition.AddRange(jObject["valueDefinition"].ToObject<IEnumerable<Guid>>());
            }

            return ordinalScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
