// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSetResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterOverrideValueSetResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ParameterOverrideValueSet"/>
    /// </summary>
    public static class ParameterOverrideValueSetResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ParameterOverrideValueSet"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ParameterOverrideValueSet"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterOverrideValueSet FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ParameterOverrideValueSetResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the ParameterOverrideValueSetResolver cannot be used to deserialize this JsonElement");
            }

            var parameterOverrideValueSet = new CDP4Common.DTO.ParameterOverrideValueSet(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("computed"u8, out var computedProperty))
            {
                parameterOverrideValueSet.Computed = SerializerHelper.ToValueArray<string>(computedProperty.GetString());
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    parameterOverrideValueSet.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    parameterOverrideValueSet.ExcludedPerson.Add(element.GetGuid());
                }
            }
            if (jsonElement.TryGetProperty("formula"u8, out var formulaProperty))
            {
                parameterOverrideValueSet.Formula = SerializerHelper.ToValueArray<string>(formulaProperty.GetString());
            }
            if (jsonElement.TryGetProperty("manual"u8, out var manualProperty))
            {
                parameterOverrideValueSet.Manual = SerializerHelper.ToValueArray<string>(manualProperty.GetString());
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the parameterOverrideValueSet {id} is null", parameterOverrideValueSet.Iid);
                }
                else
                {
                    parameterOverrideValueSet.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("parameterValueSet"u8, out var parameterValueSetProperty))
            {
                if(parameterValueSetProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale parameterValueSet property of the parameterOverrideValueSet {id} is null", parameterOverrideValueSet.Iid);
                }
                else
                {
                    parameterOverrideValueSet.ParameterValueSet = parameterValueSetProperty.GetGuid();
                }
            }
            if (jsonElement.TryGetProperty("published"u8, out var publishedProperty))
            {
                parameterOverrideValueSet.Published = SerializerHelper.ToValueArray<string>(publishedProperty.GetString());
            }
            if (jsonElement.TryGetProperty("reference"u8, out var referenceProperty))
            {
                parameterOverrideValueSet.Reference = SerializerHelper.ToValueArray<string>(referenceProperty.GetString());
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the parameterOverrideValueSet {id} is null", parameterOverrideValueSet.Iid);
                }
                else
                {
                    parameterOverrideValueSet.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("valueSwitch"u8, out var valueSwitchProperty))
            {
                if(valueSwitchProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale valueSwitch property of the parameterOverrideValueSet {id} is null", parameterOverrideValueSet.Iid);
                }
                else
                {
                    parameterOverrideValueSet.ValueSwitch = ParameterSwitchKindDeserializer.Deserialize(valueSwitchProperty);
                }
            }

            return parameterOverrideValueSet;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
