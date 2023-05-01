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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

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

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="ExternalIdentifierMapResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ExternalIdentifierMap"/>
    /// </summary>
    public static class ExternalIdentifierMapResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ExternalIdentifierMap"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ExternalIdentifierMap"/> to instantiate</returns>
        public static CDP4Common.DTO.ExternalIdentifierMap FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ExternalIdentifierMapResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the ExternalIdentifierMapResolver cannot be used to deserialize this JsonElement");
            }

            var externalIdentifierMap = new CDP4Common.DTO.ExternalIdentifierMap(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("correspondence"u8, out var correspondenceProperty))
            {
                foreach(var element in correspondenceProperty.EnumerateArray())
                {
                    externalIdentifierMap.Correspondence.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    externalIdentifierMap.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    externalIdentifierMap.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("externalFormat"u8, out var externalFormatProperty))
            {
                if(externalFormatProperty.ValueKind == JsonValueKind.Null)
                {
                    externalIdentifierMap.ExternalFormat = null;
                }
                else
                {
                    externalIdentifierMap.ExternalFormat = externalFormatProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("externalModelName"u8, out var externalModelNameProperty))
            {
                if(externalModelNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale externalModelName property of the externalIdentifierMap {id} is null", externalIdentifierMap.Iid);
                }
                else
                {
                    externalIdentifierMap.ExternalModelName = externalModelNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("externalToolName"u8, out var externalToolNameProperty))
            {
                if(externalToolNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale externalToolName property of the externalIdentifierMap {id} is null", externalIdentifierMap.Iid);
                }
                else
                {
                    externalIdentifierMap.ExternalToolName = externalToolNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("externalToolVersion"u8, out var externalToolVersionProperty))
            {
                if(externalToolVersionProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale externalToolVersion property of the externalIdentifierMap {id} is null", externalIdentifierMap.Iid);
                }
                else
                {
                    externalIdentifierMap.ExternalToolVersion = externalToolVersionProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the externalIdentifierMap {id} is null", externalIdentifierMap.Iid);
                }
                else
                {
                    externalIdentifierMap.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the externalIdentifierMap {id} is null", externalIdentifierMap.Iid);
                }
                else
                {
                    externalIdentifierMap.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the externalIdentifierMap {id} is null", externalIdentifierMap.Iid);
                }
                else
                {
                    externalIdentifierMap.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the externalIdentifierMap {id} is null", externalIdentifierMap.Iid);
                }
                else
                {
                    externalIdentifierMap.ThingPreference = thingPreferenceProperty.GetString();
                }
            }
            return externalIdentifierMap;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
