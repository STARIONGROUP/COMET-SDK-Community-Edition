// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FolderResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.Folder"/>
    /// </summary>
    public static class FolderResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.Folder"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.Folder"/> to instantiate</returns>
        public static CDP4Common.DTO.Folder FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the FolderResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var folder = new CDP4Common.DTO.Folder(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("containingFolder"u8, out var containingFolderProperty))
            {
                if(containingFolderProperty.ValueKind == JsonValueKind.Null)
                {
                    folder.ContainingFolder = null;
                }
                else
                {
                    folder.ContainingFolder = containingFolderProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale createdOn property of the folder {id} is null", folder.Iid);
                }
                else
                {
                    folder.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("creator"u8, out var creatorProperty))
            {
                if(creatorProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale creator property of the folder {id} is null", folder.Iid);
                }
                else
                {
                    folder.Creator = creatorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    folder.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    folder.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the folder {id} is null", folder.Iid);
                }
                else
                {
                    folder.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the folder {id} is null", folder.Iid);
                }
                else
                {
                    folder.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the folder {id} is null", folder.Iid);
                }
                else
                {
                    folder.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the folder {id} is null", folder.Iid);
                }
                else
                {
                    folder.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return folder;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
