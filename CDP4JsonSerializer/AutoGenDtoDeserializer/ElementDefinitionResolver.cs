// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ElementDefinitionResolver"/> is to deserialize a JSON object to a <see cref="ElementDefinition"/>
    /// </summary>
    public static class ElementDefinitionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ElementDefinition"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ElementDefinition"/> to instantiate</returns>
        public static CDP4Common.DTO.ElementDefinition FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var elementDefinition = new CDP4Common.DTO.ElementDefinition(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                elementDefinition.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                elementDefinition.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                elementDefinition.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["containedElement"].IsNullOrEmpty())
            {
                elementDefinition.ContainedElement.AddRange(jObject["containedElement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                elementDefinition.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                elementDefinition.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                elementDefinition.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                elementDefinition.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                elementDefinition.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                elementDefinition.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["organizationalParticipant"].IsNullOrEmpty())
            {
                elementDefinition.OrganizationalParticipant.AddRange(jObject["organizationalParticipant"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                elementDefinition.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameter"].IsNullOrEmpty())
            {
                elementDefinition.Parameter.AddRange(jObject["parameter"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["parameterGroup"].IsNullOrEmpty())
            {
                elementDefinition.ParameterGroup.AddRange(jObject["parameterGroup"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["referencedElement"].IsNullOrEmpty())
            {
                elementDefinition.ReferencedElement.AddRange(jObject["referencedElement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                elementDefinition.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                elementDefinition.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return elementDefinition;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
