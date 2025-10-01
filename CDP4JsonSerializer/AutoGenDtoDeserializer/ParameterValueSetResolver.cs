// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ParameterValueSetResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ParameterValueSet"/>
    /// </summary>
    public static class ParameterValueSetResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ParameterValueSet"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ParameterValueSet"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterValueSet FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ParameterValueSetResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var parameterValueSet = new CDP4Common.DTO.ParameterValueSet(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("actualOption"u8, out var actualOptionProperty))
            {
                if(actualOptionProperty.ValueKind == JsonValueKind.Null)
                {
                    parameterValueSet.ActualOption = null;
                }
                else
                {
                    parameterValueSet.ActualOption = actualOptionProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("actualState"u8, out var actualStateProperty))
            {
                if(actualStateProperty.ValueKind == JsonValueKind.Null)
                {
                    parameterValueSet.ActualState = null;
                }
                else
                {
                    parameterValueSet.ActualState = actualStateProperty.GetGuid();
                }
            }
            if (jsonElement.TryGetProperty("computed"u8, out var computedProperty))
            {
                if (computedProperty.ValueKind == JsonValueKind.Array)
                {
                    var newValueArrayItems = new List<string>();

                    foreach(var element in computedProperty.EnumerateArray())
                    {
                        newValueArrayItems.Add(element.GetString());
                    }
                    parameterValueSet.Computed = new ValueArray<string>(newValueArrayItems);
                }
                else
                {
                    parameterValueSet.Computed = SerializerHelper.ToValueArray<string>(computedProperty.GetString());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    parameterValueSet.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    parameterValueSet.ExcludedPerson.Add(element.GetGuid());
                }
            }
            if (jsonElement.TryGetProperty("formula"u8, out var formulaProperty))
            {
                if (formulaProperty.ValueKind == JsonValueKind.Array)
                {
                    var newValueArrayItems = new List<string>();

                    foreach(var element in formulaProperty.EnumerateArray())
                    {
                        newValueArrayItems.Add(element.GetString());
                    }
                    parameterValueSet.Formula = new ValueArray<string>(newValueArrayItems);
                }
                else
                {
                    parameterValueSet.Formula = SerializerHelper.ToValueArray<string>(formulaProperty.GetString());
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
                    parameterValueSet.Manual = new ValueArray<string>(newValueArrayItems);
                }
                else
                {
                    parameterValueSet.Manual = SerializerHelper.ToValueArray<string>(manualProperty.GetString());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the parameterValueSet {id} is null", parameterValueSet.Iid);
                }
                else
                {
                    parameterValueSet.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }
            if (jsonElement.TryGetProperty("published"u8, out var publishedProperty))
            {
                if (publishedProperty.ValueKind == JsonValueKind.Array)
                {
                    var newValueArrayItems = new List<string>();

                    foreach(var element in publishedProperty.EnumerateArray())
                    {
                        newValueArrayItems.Add(element.GetString());
                    }
                    parameterValueSet.Published = new ValueArray<string>(newValueArrayItems);
                }
                else
                {
                    parameterValueSet.Published = SerializerHelper.ToValueArray<string>(publishedProperty.GetString());
                }
            }
            if (jsonElement.TryGetProperty("reference"u8, out var referenceProperty))
            {
                if (referenceProperty.ValueKind == JsonValueKind.Array)
                {
                    var newValueArrayItems = new List<string>();

                    foreach(var element in referenceProperty.EnumerateArray())
                    {
                        newValueArrayItems.Add(element.GetString());
                    }
                    parameterValueSet.Reference = new ValueArray<string>(newValueArrayItems);
                }
                else
                {
                    parameterValueSet.Reference = SerializerHelper.ToValueArray<string>(referenceProperty.GetString());
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the parameterValueSet {id} is null", parameterValueSet.Iid);
                }
                else
                {
                    parameterValueSet.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("valueSwitch"u8, out var valueSwitchProperty))
            {
                if(valueSwitchProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale valueSwitch property of the parameterValueSet {id} is null", parameterValueSet.Iid);
                }
                else
                {
                    parameterValueSet.ValueSwitch = ParameterSwitchKindDeserializer.Deserialize(valueSwitchProperty);
                }
            }

            return parameterValueSet;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
