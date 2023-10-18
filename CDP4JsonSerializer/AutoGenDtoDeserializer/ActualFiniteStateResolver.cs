// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActualFiniteStateResolver"/> is to deserialize a JSON object to a <see cref="ActualFiniteState"/>
    /// </summary>
    public static class ActualFiniteStateResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ActualFiniteState"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ActualFiniteState"/> to instantiate</returns>
        public static CDP4Common.DTO.ActualFiniteState FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var actualFiniteState = new CDP4Common.DTO.ActualFiniteState(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                actualFiniteState.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                actualFiniteState.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                actualFiniteState.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["kind"].IsNullOrEmpty())
            {
                actualFiniteState.Kind = jObject["kind"].ToObject<ActualFiniteStateKind>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                actualFiniteState.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["possibleState"].IsNullOrEmpty())
            {
                actualFiniteState.PossibleState.AddRange(jObject["possibleState"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                actualFiniteState.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return actualFiniteState;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
