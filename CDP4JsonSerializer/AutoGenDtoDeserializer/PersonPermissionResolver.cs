// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonPermissionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PersonPermissionResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.PersonPermission"/>
    /// </summary>
    public static class PersonPermissionResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.PersonPermission"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.PersonPermission"/> to instantiate</returns>
        public static CDP4Common.DTO.PersonPermission FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonPermissionResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var personPermission = new CDP4Common.DTO.PersonPermission(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("accessRight"u8, out var accessRightProperty))
            {
                if(accessRightProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale accessRight property of the personPermission {id} is null", personPermission.Iid);
                }
                else
                {
                    personPermission.AccessRight = PersonAccessRightKindDeserializer.Deserialize(accessRightProperty);
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    personPermission.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    personPermission.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isDeprecated property of the personPermission {id} is null", personPermission.Iid);
                }
                else
                {
                    personPermission.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the personPermission {id} is null", personPermission.Iid);
                }
                else
                {
                    personPermission.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("objectClass"u8, out var objectClassProperty))
            {
                if(objectClassProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale objectClass property of the personPermission {id} is null", personPermission.Iid);
                }
                else
                {
                    personPermission.ObjectClass = ClassKindDeserializer.Deserialize(objectClassProperty);
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the personPermission {id} is null", personPermission.Iid);
                }
                else
                {
                    personPermission.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return personPermission;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
