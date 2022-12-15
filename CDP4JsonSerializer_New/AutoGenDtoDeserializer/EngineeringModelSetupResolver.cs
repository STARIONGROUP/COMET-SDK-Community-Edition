// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetupResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelSetupResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModelSetup"/>
    /// </summary>
    public static class EngineeringModelSetupResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="EngineeringModelSetup"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModelSetup"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModelSetup FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var engineeringModelSetup = new CDP4Common.DTO.EngineeringModelSetup(iid, revisionNumber);

            if (!jObject["activeDomain"].IsNullOrEmpty())
            {
                engineeringModelSetup.ActiveDomain.AddRange(jObject["activeDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                engineeringModelSetup.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["defaultOrganizationalParticipant"].IsNullOrEmpty())
            {
                engineeringModelSetup.DefaultOrganizationalParticipant = jObject["defaultOrganizationalParticipant"].ToObject<Guid?>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                engineeringModelSetup.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["engineeringModelIid"].IsNullOrEmpty())
            {
                engineeringModelSetup.EngineeringModelIid = jObject["engineeringModelIid"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                engineeringModelSetup.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                engineeringModelSetup.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                engineeringModelSetup.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["iterationSetup"].IsNullOrEmpty())
            {
                engineeringModelSetup.IterationSetup.AddRange(jObject["iterationSetup"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["kind"].IsNullOrEmpty())
            {
                engineeringModelSetup.Kind = jObject["kind"].ToObject<EngineeringModelKind>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                engineeringModelSetup.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                engineeringModelSetup.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["organizationalParticipant"].IsNullOrEmpty())
            {
                engineeringModelSetup.OrganizationalParticipant.AddRange(jObject["organizationalParticipant"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["participant"].IsNullOrEmpty())
            {
                engineeringModelSetup.Participant.AddRange(jObject["participant"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["requiredRdl"].IsNullOrEmpty())
            {
                engineeringModelSetup.RequiredRdl.AddRange(jObject["requiredRdl"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                engineeringModelSetup.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["sourceEngineeringModelSetupIid"].IsNullOrEmpty())
            {
                engineeringModelSetup.SourceEngineeringModelSetupIid = jObject["sourceEngineeringModelSetupIid"].ToObject<Guid?>();
            }

            if (!jObject["studyPhase"].IsNullOrEmpty())
            {
                engineeringModelSetup.StudyPhase = jObject["studyPhase"].ToObject<StudyPhaseKind>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                engineeringModelSetup.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return engineeringModelSetup;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
