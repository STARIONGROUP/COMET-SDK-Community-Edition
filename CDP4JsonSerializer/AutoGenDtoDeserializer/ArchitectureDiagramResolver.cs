// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArchitectureDiagramResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
    /// The purpose of the <see cref="ArchitectureDiagramResolver"/> is to deserialize a JSON object to a <see cref="ArchitectureDiagram"/>
    /// </summary>
    public static class ArchitectureDiagramResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ArchitectureDiagram"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ArchitectureDiagram"/> to instantiate</returns>
        public static CDP4Common.DTO.ArchitectureDiagram FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var architectureDiagram = new CDP4Common.DTO.ArchitectureDiagram(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                architectureDiagram.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["bounds"].IsNullOrEmpty())
            {
                architectureDiagram.Bounds.AddRange(jObject["bounds"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                architectureDiagram.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["description"].IsNullOrEmpty())
            {
                architectureDiagram.Description = jObject["description"].ToObject<string>();
            }

            if (!jObject["diagramElement"].IsNullOrEmpty())
            {
                architectureDiagram.DiagramElement.AddRange(jObject["diagramElement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                architectureDiagram.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                architectureDiagram.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isHidden"].IsNullOrEmpty())
            {
                architectureDiagram.IsHidden = jObject["isHidden"].ToObject<bool>();
            }

            if (!jObject["lockedBy"].IsNullOrEmpty())
            {
                architectureDiagram.LockedBy = jObject["lockedBy"].ToObject<Guid>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                architectureDiagram.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                architectureDiagram.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                architectureDiagram.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                architectureDiagram.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["topArchitectureElement"].IsNullOrEmpty())
            {
                architectureDiagram.TopArchitectureElement = jObject["topArchitectureElement"].ToObject<Guid?>();
            }

            return architectureDiagram;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
