// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantResolver.cs" company="RHEA System S.A.">
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="ParticipantResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.Participant"/>
    /// </summary>
    public static class ParticipantResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.Participant"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.Participant"/> to instantiate</returns>
        public static CDP4Common.DTO.Participant FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ParticipantResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the ParticipantResolver cannot be used to deserialize this JsonElement");
            }

            var participant = new CDP4Common.DTO.Participant(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("domain"u8, out var domainProperty) && domainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in domainProperty.EnumerateArray())
                {
                    participant.Domain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    participant.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    participant.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isActive"u8, out var isActiveProperty))
            {
                if(isActiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isActive property of the participant {id} is null", participant.Iid);
                }
                else
                {
                    participant.IsActive = isActiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the participant {id} is null", participant.Iid);
                }
                else
                {
                    participant.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("person"u8, out var personProperty))
            {
                if(personProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale person property of the participant {id} is null", participant.Iid);
                }
                else
                {
                    participant.Person = personProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("role"u8, out var roleProperty))
            {
                if(roleProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale role property of the participant {id} is null", participant.Iid);
                }
                else
                {
                    participant.Role = roleProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("selectedDomain"u8, out var selectedDomainProperty))
            {
                if(selectedDomainProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale selectedDomain property of the participant {id} is null", participant.Iid);
                }
                else
                {
                    participant.SelectedDomain = selectedDomainProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the participant {id} is null", participant.Iid);
                }
                else
                {
                    participant.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return participant;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
