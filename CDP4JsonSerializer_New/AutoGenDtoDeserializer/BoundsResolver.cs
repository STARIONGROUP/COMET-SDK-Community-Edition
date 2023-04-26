// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoundsResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BoundsResolver"/> is to deserialize a JSON object to a <see cref="Bounds"/>
    /// </summary>
    public static class BoundsResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="Bounds"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="Bounds"/> to instantiate</returns>
        public static CDP4Common.DTO.Bounds FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            var bounds = new CDP4Common.DTO.Bounds(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    bounds.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    bounds.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("height"u8, out var heightProperty))
            {
                if(heightProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale height property of the bounds {id} is null", bounds.Iid);
                }
                else
                {
                    bounds.Height = (float)heightProperty.GetDouble();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the bounds {id} is null", bounds.Iid);
                }
                else
                {
                    bounds.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the bounds {id} is null", bounds.Iid);
                }
                else
                {
                    bounds.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the bounds {id} is null", bounds.Iid);
                }
                else
                {
                    bounds.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("width"u8, out var widthProperty))
            {
                if(widthProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale width property of the bounds {id} is null", bounds.Iid);
                }
                else
                {
                    bounds.Width = (float)widthProperty.GetDouble();
                }
            }

            if (jsonElement.TryGetProperty("x"u8, out var xProperty))
            {
                if(xProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale x property of the bounds {id} is null", bounds.Iid);
                }
                else
                {
                    bounds.X = (float)xProperty.GetDouble();
                }
            }

            if (jsonElement.TryGetProperty("y"u8, out var yProperty))
            {
                if(yProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale y property of the bounds {id} is null", bounds.Iid);
                }
                else
                {
                    bounds.Y = (float)yProperty.GetDouble();
                }
            }
            return bounds;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
