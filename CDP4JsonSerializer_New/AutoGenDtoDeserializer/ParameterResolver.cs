// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterResolver"/> is to deserialize a JSON object to a <see cref="Parameter"/>
    /// </summary>
    public static class ParameterResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Parameter"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Parameter"/> to instantiate</returns>
        public static CDP4Common.DTO.Parameter FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameter = new CDP4Common.DTO.Parameter(iid, revisionNumber);

            if (!jObject["allowDifferentOwnerOfOverride"].IsNullOrEmpty())
            {
                parameter.AllowDifferentOwnerOfOverride = jObject["allowDifferentOwnerOfOverride"].ToObject<bool>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameter.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameter.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["expectsOverride"].IsNullOrEmpty())
            {
                parameter.ExpectsOverride = jObject["expectsOverride"].ToObject<bool>();
            }

            if (!jObject["group"].IsNullOrEmpty())
            {
                parameter.Group = jObject["group"].ToObject<Guid?>();
            }

            if (!jObject["isOptionDependent"].IsNullOrEmpty())
            {
                parameter.IsOptionDependent = jObject["isOptionDependent"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameter.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                parameter.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameterSubscription"].IsNullOrEmpty())
            {
                parameter.ParameterSubscription.AddRange(jObject["parameterSubscription"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                parameter.ParameterType = jObject["parameterType"].ToObject<Guid>();
            }

            if (!jObject["requestedBy"].IsNullOrEmpty())
            {
                parameter.RequestedBy = jObject["requestedBy"].ToObject<Guid?>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                parameter.Scale = jObject["scale"].ToObject<Guid?>();
            }

            if (!jObject["stateDependence"].IsNullOrEmpty())
            {
                parameter.StateDependence = jObject["stateDependence"].ToObject<Guid?>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                parameter.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["valueSet"].IsNullOrEmpty())
            {
                parameter.ValueSet.AddRange(jObject["valueSet"].ToObject<IEnumerable<Guid>>());
            }

            return parameter;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
