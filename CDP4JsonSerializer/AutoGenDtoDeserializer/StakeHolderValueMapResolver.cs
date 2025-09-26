// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="StakeHolderValueMapResolver"/> is to deserialize a JSON object to a <see cref="StakeHolderValueMap"/>
    /// </summary>
    public static class StakeHolderValueMapResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="StakeHolderValueMap"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="StakeHolderValueMap"/> to instantiate</returns>
        public static CDP4Common.DTO.StakeHolderValueMap FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var stakeHolderValueMap = new CDP4Common.DTO.StakeHolderValueMap(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["goal"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Goal.AddRange(jObject["goal"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                stakeHolderValueMap.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["requirement"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Requirement.AddRange(jObject["requirement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["settings"].IsNullOrEmpty())
            {
                stakeHolderValueMap.Settings.AddRange(jObject["settings"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["stakeholderValue"].IsNullOrEmpty())
            {
                stakeHolderValueMap.StakeholderValue.AddRange(jObject["stakeholderValue"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["valueGroup"].IsNullOrEmpty())
            {
                stakeHolderValueMap.ValueGroup.AddRange(jObject["valueGroup"].ToObject<IEnumerable<Guid>>());
            }

            return stakeHolderValueMap;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
