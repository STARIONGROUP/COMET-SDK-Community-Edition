// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleQuantityKindResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
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

namespace CDP4JsonSerializer_New
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
    /// The purpose of the <see cref="SimpleQuantityKindResolver"/> is to deserialize a JSON object to a <see cref="SimpleQuantityKind"/>
    /// </summary>
    public static class SimpleQuantityKindResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SimpleQuantityKind"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SimpleQuantityKind"/> to instantiate</returns>
        public static CDP4Common.DTO.SimpleQuantityKind FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var simpleQuantityKind = new CDP4Common.DTO.SimpleQuantityKind(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                simpleQuantityKind.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                simpleQuantityKind.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["defaultScale"].IsNullOrEmpty())
            {
                simpleQuantityKind.DefaultScale = jObject["defaultScale"].ToObject<Guid>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                simpleQuantityKind.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                simpleQuantityKind.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                simpleQuantityKind.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                simpleQuantityKind.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                simpleQuantityKind.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                simpleQuantityKind.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                simpleQuantityKind.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["possibleScale"].IsNullOrEmpty())
            {
                simpleQuantityKind.PossibleScale.AddRange(jObject["possibleScale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["quantityDimensionSymbol"].IsNullOrEmpty())
            {
                simpleQuantityKind.QuantityDimensionSymbol = jObject["quantityDimensionSymbol"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                simpleQuantityKind.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["symbol"].IsNullOrEmpty())
            {
                simpleQuantityKind.Symbol = jObject["symbol"].ToObject<string>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                simpleQuantityKind.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return simpleQuantityKind;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
