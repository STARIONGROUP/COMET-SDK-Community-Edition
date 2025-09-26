// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryResolver"/> is to deserialize a JSON object to a <see cref="SiteDirectory"/>
    /// </summary>
    public static class SiteDirectoryResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SiteDirectory"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SiteDirectory"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteDirectory FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var siteDirectory = new CDP4Common.DTO.SiteDirectory(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                siteDirectory.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["annotation"].IsNullOrEmpty())
            {
                siteDirectory.Annotation.AddRange(jObject["annotation"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                siteDirectory.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["defaultParticipantRole"].IsNullOrEmpty())
            {
                siteDirectory.DefaultParticipantRole = jObject["defaultParticipantRole"].ToObject<Guid?>();
            }

            if (!jObject["defaultPersonRole"].IsNullOrEmpty())
            {
                siteDirectory.DefaultPersonRole = jObject["defaultPersonRole"].ToObject<Guid?>();
            }

            if (!jObject["domain"].IsNullOrEmpty())
            {
                siteDirectory.Domain.AddRange(jObject["domain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["domainGroup"].IsNullOrEmpty())
            {
                siteDirectory.DomainGroup.AddRange(jObject["domainGroup"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                siteDirectory.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                siteDirectory.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["lastModifiedOn"].IsNullOrEmpty())
            {
                siteDirectory.LastModifiedOn = jObject["lastModifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["logEntry"].IsNullOrEmpty())
            {
                siteDirectory.LogEntry.AddRange(jObject["logEntry"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["model"].IsNullOrEmpty())
            {
                siteDirectory.Model.AddRange(jObject["model"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                siteDirectory.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                siteDirectory.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["naturalLanguage"].IsNullOrEmpty())
            {
                siteDirectory.NaturalLanguage.AddRange(jObject["naturalLanguage"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["organization"].IsNullOrEmpty())
            {
                siteDirectory.Organization.AddRange(jObject["organization"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["participantRole"].IsNullOrEmpty())
            {
                siteDirectory.ParticipantRole.AddRange(jObject["participantRole"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["person"].IsNullOrEmpty())
            {
                siteDirectory.Person.AddRange(jObject["person"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["personRole"].IsNullOrEmpty())
            {
                siteDirectory.PersonRole.AddRange(jObject["personRole"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                siteDirectory.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["siteReferenceDataLibrary"].IsNullOrEmpty())
            {
                siteDirectory.SiteReferenceDataLibrary.AddRange(jObject["siteReferenceDataLibrary"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                siteDirectory.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return siteDirectory;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
