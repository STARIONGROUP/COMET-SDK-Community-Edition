// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryNoteResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BinaryNoteResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.BinaryNote"/>
    /// </summary>
    public static class BinaryNoteResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.BinaryNote"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.BinaryNote"/> to instantiate</returns>
        public static CDP4Common.DTO.BinaryNote FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the BinaryNoteResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var binaryNote = new CDP4Common.DTO.BinaryNote(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("caption"u8, out var captionProperty))
            {
                if(captionProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale caption property of the binaryNote {id} is null", binaryNote.Iid);
                }
                else
                {
                    binaryNote.Caption = captionProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    binaryNote.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale createdOn property of the binaryNote {id} is null", binaryNote.Iid);
                }
                else
                {
                    binaryNote.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    binaryNote.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    binaryNote.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("fileType"u8, out var fileTypeProperty))
            {
                if(fileTypeProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale fileType property of the binaryNote {id} is null", binaryNote.Iid);
                }
                else
                {
                    binaryNote.FileType = fileTypeProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the binaryNote {id} is null", binaryNote.Iid);
                }
                else
                {
                    binaryNote.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the binaryNote {id} is null", binaryNote.Iid);
                }
                else
                {
                    binaryNote.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the binaryNote {id} is null", binaryNote.Iid);
                }
                else
                {
                    binaryNote.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the binaryNote {id} is null", binaryNote.Iid);
                }
                else
                {
                    binaryNote.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the binaryNote {id} is null", binaryNote.Iid);
                }
                else
                {
                    binaryNote.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return binaryNote;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
