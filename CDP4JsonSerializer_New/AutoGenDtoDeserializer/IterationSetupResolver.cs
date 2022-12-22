// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationSetupResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IterationSetupResolver"/> is to deserialize a JSON object to a <see cref="IterationSetup"/>
    /// </summary>
    public static class IterationSetupResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="IterationSetup"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="IterationSetup"/> to instantiate</returns>
        public static CDP4Common.DTO.IterationSetup FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var iterationSetup = new CDP4Common.DTO.IterationSetup(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("createdOn", out var createdOnProperty))
            {
                iterationSetup.CreatedOn = createdOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("description", out var descriptionProperty))
            {
                iterationSetup.Description = descriptionProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                iterationSetup.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                iterationSetup.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("frozenOn", out var frozenOnProperty))
            {
                iterationSetup.FrozenOn = frozenOnProperty.Deserialize<DateTime?>();
            }

            if (jObject.TryGetProperty("isDeleted", out var isDeletedProperty))
            {
                iterationSetup.IsDeleted = isDeletedProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("iterationIid", out var iterationIidProperty))
            {
                iterationSetup.IterationIid = iterationIidProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("iterationNumber", out var iterationNumberProperty))
            {
                iterationSetup.IterationNumber = iterationNumberProperty.Deserialize<int>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                iterationSetup.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("sourceIterationSetup", out var sourceIterationSetupProperty))
            {
                iterationSetup.SourceIterationSetup = sourceIterationSetupProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                iterationSetup.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            return iterationSetup;
        }
    }
}
