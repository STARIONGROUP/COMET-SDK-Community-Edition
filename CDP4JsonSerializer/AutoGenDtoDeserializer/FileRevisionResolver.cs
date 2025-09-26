// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevisionResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="FileRevisionResolver"/> is to deserialize a JSON object to a <see cref="FileRevision"/>
    /// </summary>
    public static class FileRevisionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="FileRevision"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="FileRevision"/> to instantiate</returns>
        public static CDP4Common.DTO.FileRevision FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var fileRevision = new CDP4Common.DTO.FileRevision(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                fileRevision.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["containingFolder"].IsNullOrEmpty())
            {
                fileRevision.ContainingFolder = jObject["containingFolder"].ToObject<Guid?>();
            }

            if (!jObject["contentHash"].IsNullOrEmpty())
            {
                fileRevision.ContentHash = jObject["contentHash"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                fileRevision.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["creator"].IsNullOrEmpty())
            {
                fileRevision.Creator = jObject["creator"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                fileRevision.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                fileRevision.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fileType"].IsNullOrEmpty())
            {
                fileRevision.FileType.AddRange(jObject["fileType"].ToOrderedItemCollection());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                fileRevision.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                fileRevision.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                fileRevision.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return fileRevision;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
