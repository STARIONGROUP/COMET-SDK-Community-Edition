// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalIdentifierMapResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ExternalIdentifierMapResolver"/> is to deserialize a JSON object to a <see cref="ExternalIdentifierMap"/>
    /// </summary>
    public static class ExternalIdentifierMapResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="ExternalIdentifierMap"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="ExternalIdentifierMap"/> to instantiate</returns>
        public static CDP4Common.DTO.ExternalIdentifierMap FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var externalIdentifierMap = new CDP4Common.DTO.ExternalIdentifierMap(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("correspondence", out var correspondenceProperty))
            {
                externalIdentifierMap.Correspondence.AddRange(correspondenceProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                externalIdentifierMap.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                externalIdentifierMap.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("externalFormat", out var externalFormatProperty))
            {
                externalIdentifierMap.ExternalFormat = externalFormatProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("externalModelName", out var externalModelNameProperty))
            {
                externalIdentifierMap.ExternalModelName = externalModelNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("externalToolName", out var externalToolNameProperty))
            {
                externalIdentifierMap.ExternalToolName = externalToolNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("externalToolVersion", out var externalToolVersionProperty))
            {
                externalIdentifierMap.ExternalToolVersion = externalToolVersionProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                externalIdentifierMap.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                externalIdentifierMap.Name = nameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("owner", out var ownerProperty))
            {
                externalIdentifierMap.Owner = ownerProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                externalIdentifierMap.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            return externalIdentifierMap;
        }
    }
}
