// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipRuleResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="BinaryRelationshipRuleResolver"/> is to deserialize a JSON object to a <see cref="BinaryRelationshipRule"/>
    /// </summary>
    public static class BinaryRelationshipRuleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="BinaryRelationshipRule"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="BinaryRelationshipRule"/> to instantiate</returns>
        public static CDP4Common.DTO.BinaryRelationshipRule FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var binaryRelationshipRule = new CDP4Common.DTO.BinaryRelationshipRule(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                binaryRelationshipRule.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                binaryRelationshipRule.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                binaryRelationshipRule.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                binaryRelationshipRule.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                binaryRelationshipRule.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["forwardRelationshipName"].IsNullOrEmpty())
            {
                binaryRelationshipRule.ForwardRelationshipName = jObject["forwardRelationshipName"].ToObject<string>();
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                binaryRelationshipRule.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["inverseRelationshipName"].IsNullOrEmpty())
            {
                binaryRelationshipRule.InverseRelationshipName = jObject["inverseRelationshipName"].ToObject<string>();
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                binaryRelationshipRule.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                binaryRelationshipRule.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                binaryRelationshipRule.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["relationshipCategory"].IsNullOrEmpty())
            {
                binaryRelationshipRule.RelationshipCategory = jObject["relationshipCategory"].ToObject<Guid>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                binaryRelationshipRule.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["sourceCategory"].IsNullOrEmpty())
            {
                binaryRelationshipRule.SourceCategory = jObject["sourceCategory"].ToObject<Guid>();
            }

            if (!jObject["targetCategory"].IsNullOrEmpty())
            {
                binaryRelationshipRule.TargetCategory = jObject["targetCategory"].ToObject<Guid>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                binaryRelationshipRule.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return binaryRelationshipRule;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
