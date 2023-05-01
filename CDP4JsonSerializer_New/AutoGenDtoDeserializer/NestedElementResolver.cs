// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NestedElementResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.NestedElement"/>
    /// </summary>
    public static class NestedElementResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.NestedElement"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.NestedElement"/> to instantiate</returns>
        public static CDP4Common.DTO.NestedElement FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the NestedElementResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the NestedElementResolver cannot be used to deserialize this JsonElement");
            }

            var nestedElement = new CDP4Common.DTO.NestedElement(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("elementUsage"u8, out var elementUsageProperty))
            {
                nestedElement.ElementUsage.AddRange(elementUsageProperty.ToOrderedItemCollection());
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    nestedElement.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    nestedElement.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isVolatile"u8, out var isVolatileProperty))
            {
                if(isVolatileProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isVolatile property of the nestedElement {id} is null", nestedElement.Iid);
                }
                else
                {
                    nestedElement.IsVolatile = isVolatileProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the nestedElement {id} is null", nestedElement.Iid);
                }
                else
                {
                    nestedElement.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("nestedParameter"u8, out var nestedParameterProperty))
            {
                foreach(var element in nestedParameterProperty.EnumerateArray())
                {
                    nestedElement.NestedParameter.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("rootElement"u8, out var rootElementProperty))
            {
                if(rootElementProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale rootElement property of the nestedElement {id} is null", nestedElement.Iid);
                }
                else
                {
                    nestedElement.RootElement = rootElementProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the nestedElement {id} is null", nestedElement.Iid);
                }
                else
                {
                    nestedElement.ThingPreference = thingPreferenceProperty.GetString();
                }
            }
            return nestedElement;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
