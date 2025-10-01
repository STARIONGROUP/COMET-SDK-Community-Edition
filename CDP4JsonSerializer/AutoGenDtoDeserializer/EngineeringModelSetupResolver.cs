// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetupResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
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
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System.Collections.Generic;
    using System.Text.Json;

    using CDP4Common.Types;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="EngineeringModelSetupResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.EngineeringModelSetup"/>
    /// </summary>
    public static class EngineeringModelSetupResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.EngineeringModelSetup"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.EngineeringModelSetup"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModelSetup FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the EngineeringModelSetupResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var engineeringModelSetup = new CDP4Common.DTO.EngineeringModelSetup(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("activeDomain"u8, out var activeDomainProperty) && activeDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in activeDomainProperty.EnumerateArray())
                {
                    engineeringModelSetup.ActiveDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    engineeringModelSetup.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("defaultOrganizationalParticipant"u8, out var defaultOrganizationalParticipantProperty))
            {
                if(defaultOrganizationalParticipantProperty.ValueKind == JsonValueKind.Null)
                {
                    engineeringModelSetup.DefaultOrganizationalParticipant = null;
                }
                else
                {
                    engineeringModelSetup.DefaultOrganizationalParticipant = defaultOrganizationalParticipantProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    engineeringModelSetup.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("engineeringModelIid"u8, out var engineeringModelIidProperty))
            {
                if(engineeringModelIidProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale engineeringModelIid property of the engineeringModelSetup {id} is null", engineeringModelSetup.Iid);
                }
                else
                {
                    engineeringModelSetup.EngineeringModelIid = engineeringModelIidProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    engineeringModelSetup.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    engineeringModelSetup.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    engineeringModelSetup.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("iterationSetup"u8, out var iterationSetupProperty) && iterationSetupProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in iterationSetupProperty.EnumerateArray())
                {
                    engineeringModelSetup.IterationSetup.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("kind"u8, out var kindProperty))
            {
                if(kindProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale kind property of the engineeringModelSetup {id} is null", engineeringModelSetup.Iid);
                }
                else
                {
                    engineeringModelSetup.Kind = EngineeringModelKindDeserializer.Deserialize(kindProperty);
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the engineeringModelSetup {id} is null", engineeringModelSetup.Iid);
                }
                else
                {
                    engineeringModelSetup.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale name property of the engineeringModelSetup {id} is null", engineeringModelSetup.Iid);
                }
                else
                {
                    engineeringModelSetup.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("organizationalParticipant"u8, out var organizationalParticipantProperty) && organizationalParticipantProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in organizationalParticipantProperty.EnumerateArray())
                {
                    engineeringModelSetup.OrganizationalParticipant.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("participant"u8, out var participantProperty) && participantProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in participantProperty.EnumerateArray())
                {
                    engineeringModelSetup.Participant.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("requiredRdl"u8, out var requiredRdlProperty) && requiredRdlProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in requiredRdlProperty.EnumerateArray())
                {
                    engineeringModelSetup.RequiredRdl.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale shortName property of the engineeringModelSetup {id} is null", engineeringModelSetup.Iid);
                }
                else
                {
                    engineeringModelSetup.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("sourceEngineeringModelSetupIid"u8, out var sourceEngineeringModelSetupIidProperty))
            {
                if(sourceEngineeringModelSetupIidProperty.ValueKind == JsonValueKind.Null)
                {
                    engineeringModelSetup.SourceEngineeringModelSetupIid = null;
                }
                else
                {
                    engineeringModelSetup.SourceEngineeringModelSetupIid = sourceEngineeringModelSetupIidProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("studyPhase"u8, out var studyPhaseProperty))
            {
                if(studyPhaseProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale studyPhase property of the engineeringModelSetup {id} is null", engineeringModelSetup.Iid);
                }
                else
                {
                    engineeringModelSetup.StudyPhase = StudyPhaseKindDeserializer.Deserialize(studyPhaseProperty);
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the engineeringModelSetup {id} is null", engineeringModelSetup.Iid);
                }
                else
                {
                    engineeringModelSetup.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return engineeringModelSetup;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
