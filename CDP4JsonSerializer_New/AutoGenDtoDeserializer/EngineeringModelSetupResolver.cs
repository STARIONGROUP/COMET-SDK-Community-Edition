// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetupResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Jaime Bernar
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4JsonSerializer_SystemTextJson.EnumDeserializers;
    
    /// <summary>
    /// The purpose of the <see cref="EngineeringModelSetupResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModelSetup"/>
    /// </summary>
    public static class EngineeringModelSetupResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="EngineeringModelSetup"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModelSetup"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModelSetup FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var engineeringModelSetup = new CDP4Common.DTO.EngineeringModelSetup(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("activeDomain", out var activeDomainProperty))
            {
                engineeringModelSetup.ActiveDomain.AddRange(activeDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                engineeringModelSetup.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("defaultOrganizationalParticipant", out var defaultOrganizationalParticipantProperty))
            {
                engineeringModelSetup.DefaultOrganizationalParticipant = defaultOrganizationalParticipantProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                engineeringModelSetup.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("engineeringModelIid", out var engineeringModelIidProperty))
            {
                engineeringModelSetup.EngineeringModelIid = engineeringModelIidProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                engineeringModelSetup.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                engineeringModelSetup.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                engineeringModelSetup.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("iterationSetup", out var iterationSetupProperty))
            {
                engineeringModelSetup.IterationSetup.AddRange(iterationSetupProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("kind", out var kindProperty))
            {
                engineeringModelSetup.Kind = EngineeringModelKindDeserializer.Deserialize(kindProperty);
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                engineeringModelSetup.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                engineeringModelSetup.Name = nameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("organizationalParticipant", out var organizationalParticipantProperty))
            {
                engineeringModelSetup.OrganizationalParticipant.AddRange(organizationalParticipantProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("participant", out var participantProperty))
            {
                engineeringModelSetup.Participant.AddRange(participantProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("requiredRdl", out var requiredRdlProperty))
            {
                engineeringModelSetup.RequiredRdl.AddRange(requiredRdlProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                engineeringModelSetup.ShortName = shortNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("sourceEngineeringModelSetupIid", out var sourceEngineeringModelSetupIidProperty))
            {
                engineeringModelSetup.SourceEngineeringModelSetupIid = sourceEngineeringModelSetupIidProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("studyPhase", out var studyPhaseProperty))
            {
                engineeringModelSetup.StudyPhase = StudyPhaseKindDeserializer.Deserialize(studyPhaseProperty);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                engineeringModelSetup.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            return engineeringModelSetup;
        }
    }
}
