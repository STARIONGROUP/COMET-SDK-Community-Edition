// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FolderResolver"/> is to deserialize a JSON object to a <see cref="Folder"/>
    /// </summary>
    public static class FolderResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="Folder"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="Folder"/> to instantiate</returns>
        public static CDP4Common.DTO.Folder FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var folder = new CDP4Common.DTO.Folder(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("containingFolder", out var containingFolderProperty))
            {
                folder.ContainingFolder = containingFolderProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("createdOn", out var createdOnProperty))
            {
                folder.CreatedOn = createdOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("creator", out var creatorProperty))
            {
                folder.Creator = creatorProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                folder.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                folder.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                folder.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                folder.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("owner", out var ownerProperty))
            {
                folder.Owner = ownerProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                folder.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            return folder;
        }
    }
}
