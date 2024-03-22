// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="StakeHolderValueMapResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.StakeHolderValueMap"/>
    /// </summary>
    public static class StakeHolderValueMapResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.StakeHolderValueMap"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.StakeHolderValueMap"/> to instantiate</returns>
        public static CDP4Common.DTO.StakeHolderValueMap FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the StakeHolderValueMapResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var stakeHolderValueMap = new CDP4Common.DTO.StakeHolderValueMap(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    stakeHolderValueMap.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    stakeHolderValueMap.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    stakeHolderValueMap.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    stakeHolderValueMap.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    stakeHolderValueMap.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("goal"u8, out var goalProperty) && goalProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in goalProperty.EnumerateArray())
                {
                    stakeHolderValueMap.Goal.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    stakeHolderValueMap.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the stakeHolderValueMap {id} is null", stakeHolderValueMap.Iid);
                }
                else
                {
                    stakeHolderValueMap.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale name property of the stakeHolderValueMap {id} is null", stakeHolderValueMap.Iid);
                }
                else
                {
                    stakeHolderValueMap.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("requirement"u8, out var requirementProperty) && requirementProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in requirementProperty.EnumerateArray())
                {
                    stakeHolderValueMap.Requirement.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("settings"u8, out var settingsProperty) && settingsProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in settingsProperty.EnumerateArray())
                {
                    stakeHolderValueMap.Settings.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale shortName property of the stakeHolderValueMap {id} is null", stakeHolderValueMap.Iid);
                }
                else
                {
                    stakeHolderValueMap.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("stakeholderValue"u8, out var stakeholderValueProperty) && stakeholderValueProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in stakeholderValueProperty.EnumerateArray())
                {
                    stakeHolderValueMap.StakeholderValue.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the stakeHolderValueMap {id} is null", stakeHolderValueMap.Iid);
                }
                else
                {
                    stakeHolderValueMap.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("valueGroup"u8, out var valueGroupProperty) && valueGroupProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in valueGroupProperty.EnumerateArray())
                {
                    stakeHolderValueMap.ValueGroup.Add(element.GetGuid());
                }
            }

            return stakeHolderValueMap;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
