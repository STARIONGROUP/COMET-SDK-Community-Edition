// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="StakeHolderValueMapResolver"/> is to deserialize a JSON object to a <see cref="StakeHolderValueMap"/>
    /// </summary>
    public static class StakeHolderValueMapResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="StakeHolderValueMap"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="StakeHolderValueMap"/> to instantiate</returns>
        public static CDP4Common.DTO.StakeHolderValueMap FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var stakeHolderValueMap = new CDP4Common.DTO.StakeHolderValueMap(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                stakeHolderValueMap.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("category", out var categoryProperty))
            {
                stakeHolderValueMap.Category.AddRange(categoryProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                stakeHolderValueMap.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                stakeHolderValueMap.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                stakeHolderValueMap.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("goal", out var goalProperty))
            {
                stakeHolderValueMap.Goal.AddRange(goalProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                stakeHolderValueMap.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                stakeHolderValueMap.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                stakeHolderValueMap.Name = nameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("requirement", out var requirementProperty))
            {
                stakeHolderValueMap.Requirement.AddRange(requirementProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("settings", out var settingsProperty))
            {
                stakeHolderValueMap.Settings.AddRange(settingsProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                stakeHolderValueMap.ShortName = shortNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("stakeholderValue", out var stakeholderValueProperty))
            {
                stakeHolderValueMap.StakeholderValue.AddRange(stakeholderValueProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                stakeHolderValueMap.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("valueGroup", out var valueGroupProperty))
            {
                stakeHolderValueMap.ValueGroup.AddRange(valueGroupProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            return stakeHolderValueMap;
        }
    }
}
