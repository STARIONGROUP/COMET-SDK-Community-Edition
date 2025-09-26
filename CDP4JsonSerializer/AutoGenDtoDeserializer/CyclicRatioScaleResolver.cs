// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CyclicRatioScaleResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="CyclicRatioScaleResolver"/> is to deserialize a JSON object to a <see cref="CyclicRatioScale"/>
    /// </summary>
    public static class CyclicRatioScaleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="CyclicRatioScale"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="CyclicRatioScale"/> to instantiate</returns>
        public static CDP4Common.DTO.CyclicRatioScale FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var cyclicRatioScale = new CDP4Common.DTO.CyclicRatioScale(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                cyclicRatioScale.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                cyclicRatioScale.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                cyclicRatioScale.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                cyclicRatioScale.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                cyclicRatioScale.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                cyclicRatioScale.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                cyclicRatioScale.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["isMaximumInclusive"].IsNullOrEmpty())
            {
                cyclicRatioScale.IsMaximumInclusive = jObject["isMaximumInclusive"].ToObject<bool>();
            }

            if (!jObject["isMinimumInclusive"].IsNullOrEmpty())
            {
                cyclicRatioScale.IsMinimumInclusive = jObject["isMinimumInclusive"].ToObject<bool>();
            }

            if (!jObject["mappingToReferenceScale"].IsNullOrEmpty())
            {
                cyclicRatioScale.MappingToReferenceScale.AddRange(jObject["mappingToReferenceScale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["maximumPermissibleValue"].IsNullOrEmpty())
            {
                cyclicRatioScale.MaximumPermissibleValue = jObject["maximumPermissibleValue"].ToObject<string>();
            }

            if (!jObject["minimumPermissibleValue"].IsNullOrEmpty())
            {
                cyclicRatioScale.MinimumPermissibleValue = jObject["minimumPermissibleValue"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                cyclicRatioScale.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["modulus"].IsNullOrEmpty())
            {
                cyclicRatioScale.Modulus = jObject["modulus"].ToObject<string>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                cyclicRatioScale.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["negativeValueConnotation"].IsNullOrEmpty())
            {
                cyclicRatioScale.NegativeValueConnotation = jObject["negativeValueConnotation"].ToObject<string>();
            }

            if (!jObject["numberSet"].IsNullOrEmpty())
            {
                cyclicRatioScale.NumberSet = jObject["numberSet"].ToObject<NumberSetKind>();
            }

            if (!jObject["positiveValueConnotation"].IsNullOrEmpty())
            {
                cyclicRatioScale.PositiveValueConnotation = jObject["positiveValueConnotation"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                cyclicRatioScale.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                cyclicRatioScale.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["unit"].IsNullOrEmpty())
            {
                cyclicRatioScale.Unit = jObject["unit"].ToObject<Guid>();
            }

            if (!jObject["valueDefinition"].IsNullOrEmpty())
            {
                cyclicRatioScale.ValueDefinition.AddRange(jObject["valueDefinition"].ToObject<IEnumerable<Guid>>());
            }

            return cyclicRatioScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
