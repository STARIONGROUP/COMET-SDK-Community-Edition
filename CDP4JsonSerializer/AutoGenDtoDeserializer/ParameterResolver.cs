// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.Parameter"/>
    /// </summary>
    public static class ParameterResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.Parameter"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.Parameter"/> to instantiate</returns>
        public static CDP4Common.DTO.Parameter FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ParameterResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the ParameterResolver cannot be used to deserialize this JsonElement");
            }

            var parameter = new CDP4Common.DTO.Parameter(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("allowDifferentOwnerOfOverride"u8, out var allowDifferentOwnerOfOverrideProperty))
            {
                if(allowDifferentOwnerOfOverrideProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale allowDifferentOwnerOfOverride property of the parameter {id} is null", parameter.Iid);
                }
                else
                {
                    parameter.AllowDifferentOwnerOfOverride = allowDifferentOwnerOfOverrideProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    parameter.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    parameter.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("expectsOverride"u8, out var expectsOverrideProperty))
            {
                if(expectsOverrideProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale expectsOverride property of the parameter {id} is null", parameter.Iid);
                }
                else
                {
                    parameter.ExpectsOverride = expectsOverrideProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("group"u8, out var groupProperty))
            {
                if(groupProperty.ValueKind == JsonValueKind.Null)
                {
                    parameter.Group = null;
                }
                else
                {
                    parameter.Group = groupProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("isOptionDependent"u8, out var isOptionDependentProperty))
            {
                if(isOptionDependentProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isOptionDependent property of the parameter {id} is null", parameter.Iid);
                }
                else
                {
                    parameter.IsOptionDependent = isOptionDependentProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the parameter {id} is null", parameter.Iid);
                }
                else
                {
                    parameter.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the parameter {id} is null", parameter.Iid);
                }
                else
                {
                    parameter.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("parameterSubscription"u8, out var parameterSubscriptionProperty) && parameterSubscriptionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in parameterSubscriptionProperty.EnumerateArray())
                {
                    parameter.ParameterSubscription.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("parameterType"u8, out var parameterTypeProperty))
            {
                if(parameterTypeProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale parameterType property of the parameter {id} is null", parameter.Iid);
                }
                else
                {
                    parameter.ParameterType = parameterTypeProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("requestedBy"u8, out var requestedByProperty))
            {
                if(requestedByProperty.ValueKind == JsonValueKind.Null)
                {
                    parameter.RequestedBy = null;
                }
                else
                {
                    parameter.RequestedBy = requestedByProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("scale"u8, out var scaleProperty))
            {
                if(scaleProperty.ValueKind == JsonValueKind.Null)
                {
                    parameter.Scale = null;
                }
                else
                {
                    parameter.Scale = scaleProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("stateDependence"u8, out var stateDependenceProperty))
            {
                if(stateDependenceProperty.ValueKind == JsonValueKind.Null)
                {
                    parameter.StateDependence = null;
                }
                else
                {
                    parameter.StateDependence = stateDependenceProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the parameter {id} is null", parameter.Iid);
                }
                else
                {
                    parameter.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("valueSet"u8, out var valueSetProperty) && valueSetProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in valueSetProperty.EnumerateArray())
                {
                    parameter.ValueSet.Add(element.GetGuid());
                }
            }

            return parameter;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
