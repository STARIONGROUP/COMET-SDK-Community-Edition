// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSetResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ParameterSubscriptionValueSetResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ParameterSubscriptionValueSet"/>
    /// </summary>
    public static class ParameterSubscriptionValueSetResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ParameterSubscriptionValueSet"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ParameterSubscriptionValueSet"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterSubscriptionValueSet FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ParameterSubscriptionValueSetResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var parameterSubscriptionValueSet = new CDP4Common.DTO.ParameterSubscriptionValueSet(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    parameterSubscriptionValueSet.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    parameterSubscriptionValueSet.ExcludedPerson.Add(element.GetGuid());
                }
            }
            if (jsonElement.TryGetProperty("manual"u8, out var manualProperty))
            {
                if (manualProperty.ValueKind == JsonValueKind.Array)
                {
                    var newValueArrayItems = new List<string>();

                    foreach(var element in manualProperty.EnumerateArray())
                    {
                        newValueArrayItems.Add(element.GetString());
                    }
                    parameterSubscriptionValueSet.Manual = new ValueArray<string>(newValueArrayItems);
                }
                else
                {
                    parameterSubscriptionValueSet.Manual = SerializerHelper.ToValueArray<string>(manualProperty.GetString());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the parameterSubscriptionValueSet {id} is null", parameterSubscriptionValueSet.Iid);
                }
                else
                {
                    parameterSubscriptionValueSet.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("subscribedValueSet"u8, out var subscribedValueSetProperty))
            {
                if(subscribedValueSetProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale subscribedValueSet property of the parameterSubscriptionValueSet {id} is null", parameterSubscriptionValueSet.Iid);
                }
                else
                {
                    parameterSubscriptionValueSet.SubscribedValueSet = subscribedValueSetProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the parameterSubscriptionValueSet {id} is null", parameterSubscriptionValueSet.Iid);
                }
                else
                {
                    parameterSubscriptionValueSet.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("valueSwitch"u8, out var valueSwitchProperty))
            {
                if(valueSwitchProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale valueSwitch property of the parameterSubscriptionValueSet {id} is null", parameterSubscriptionValueSet.Iid);
                }
                else
                {
                    parameterSubscriptionValueSet.ValueSwitch = ParameterSwitchKindDeserializer.Deserialize(valueSwitchProperty);
                }
            }

            return parameterSubscriptionValueSet;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
