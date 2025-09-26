// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameterResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="NestedParameterResolver"/> is to deserialize a JSON object to a <see cref="NestedParameter"/>
    /// </summary>
    public static class NestedParameterResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="NestedParameter"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="NestedParameter"/> to instantiate</returns>
        public static CDP4Common.DTO.NestedParameter FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var nestedParameter = new CDP4Common.DTO.NestedParameter(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                nestedParameter.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["actualState"].IsNullOrEmpty())
            {
                nestedParameter.ActualState = jObject["actualState"].ToObject<Guid?>();
            }

            if (!jObject["actualValue"].IsNullOrEmpty())
            {
                nestedParameter.ActualValue = jObject["actualValue"].ToObject<string>();
            }

            if (!jObject["associatedParameter"].IsNullOrEmpty())
            {
                nestedParameter.AssociatedParameter = jObject["associatedParameter"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                nestedParameter.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                nestedParameter.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["formula"].IsNullOrEmpty())
            {
                nestedParameter.Formula = jObject["formula"].ToObject<string>();
            }

            if (!jObject["isVolatile"].IsNullOrEmpty())
            {
                nestedParameter.IsVolatile = jObject["isVolatile"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                nestedParameter.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                nestedParameter.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                nestedParameter.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return nestedParameter;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
