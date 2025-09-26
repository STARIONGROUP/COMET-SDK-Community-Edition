// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuiltInRuleVerificationResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="BuiltInRuleVerificationResolver"/> is to deserialize a JSON object to a <see cref="BuiltInRuleVerification"/>
    /// </summary>
    public static class BuiltInRuleVerificationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="BuiltInRuleVerification"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="BuiltInRuleVerification"/> to instantiate</returns>
        public static CDP4Common.DTO.BuiltInRuleVerification FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var builtInRuleVerification = new CDP4Common.DTO.BuiltInRuleVerification(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                builtInRuleVerification.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                builtInRuleVerification.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                builtInRuleVerification.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["executedOn"].IsNullOrEmpty())
            {
                builtInRuleVerification.ExecutedOn = jObject["executedOn"].ToObject<DateTime?>();
            }

            if (!jObject["isActive"].IsNullOrEmpty())
            {
                builtInRuleVerification.IsActive = jObject["isActive"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                builtInRuleVerification.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                builtInRuleVerification.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["status"].IsNullOrEmpty())
            {
                builtInRuleVerification.Status = jObject["status"].ToObject<RuleVerificationStatusKind>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                builtInRuleVerification.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["violation"].IsNullOrEmpty())
            {
                builtInRuleVerification.Violation.AddRange(jObject["violation"].ToObject<IEnumerable<Guid>>());
            }

            return builtInRuleVerification;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
