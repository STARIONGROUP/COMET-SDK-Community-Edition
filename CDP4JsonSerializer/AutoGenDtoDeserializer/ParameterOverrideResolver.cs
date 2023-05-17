// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterOverrideResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ParameterOverride"/>
    /// </summary>
    public static class ParameterOverrideResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ParameterOverride"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ParameterOverride"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterOverride FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ParameterOverrideResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the ParameterOverrideResolver cannot be used to deserialize this JsonElement");
            }

            var parameterOverride = new CDP4Common.DTO.ParameterOverride(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    parameterOverride.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    parameterOverride.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the parameterOverride {id} is null", parameterOverride.Iid);
                }
                else
                {
                    parameterOverride.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the parameterOverride {id} is null", parameterOverride.Iid);
                }
                else
                {
                    parameterOverride.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("parameter"u8, out var parameterProperty))
            {
                if(parameterProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale parameter property of the parameterOverride {id} is null", parameterOverride.Iid);
                }
                else
                {
                    parameterOverride.Parameter = parameterProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("parameterSubscription"u8, out var parameterSubscriptionProperty) && parameterSubscriptionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in parameterSubscriptionProperty.EnumerateArray())
                {
                    parameterOverride.ParameterSubscription.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the parameterOverride {id} is null", parameterOverride.Iid);
                }
                else
                {
                    parameterOverride.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("valueSet"u8, out var valueSetProperty) && valueSetProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in valueSetProperty.EnumerateArray())
                {
                    parameterOverride.ValueSet.Add(element.GetGuid());
                }
            }

            return parameterOverride;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
