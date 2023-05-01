// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameterResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NestedParameterResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.NestedParameter"/>
    /// </summary>
    public static class NestedParameterResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.NestedParameter"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.NestedParameter"/> to instantiate</returns>
        public static CDP4Common.DTO.NestedParameter FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the NestedParameterResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the NestedParameterResolver cannot be used to deserialize this JsonElement");
            }

            var nestedParameter = new CDP4Common.DTO.NestedParameter(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("actualState"u8, out var actualStateProperty))
            {
                if(actualStateProperty.ValueKind == JsonValueKind.Null)
                {
                    nestedParameter.ActualState = null;
                }
                else
                {
                    nestedParameter.ActualState = actualStateProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("actualValue"u8, out var actualValueProperty))
            {
                if(actualValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale actualValue property of the nestedParameter {id} is null", nestedParameter.Iid);
                }
                else
                {
                    nestedParameter.ActualValue = actualValueProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("associatedParameter"u8, out var associatedParameterProperty))
            {
                if(associatedParameterProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale associatedParameter property of the nestedParameter {id} is null", nestedParameter.Iid);
                }
                else
                {
                    nestedParameter.AssociatedParameter = associatedParameterProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    nestedParameter.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    nestedParameter.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("formula"u8, out var formulaProperty))
            {
                if(formulaProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale formula property of the nestedParameter {id} is null", nestedParameter.Iid);
                }
                else
                {
                    nestedParameter.Formula = formulaProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("isVolatile"u8, out var isVolatileProperty))
            {
                if(isVolatileProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isVolatile property of the nestedParameter {id} is null", nestedParameter.Iid);
                }
                else
                {
                    nestedParameter.IsVolatile = isVolatileProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the nestedParameter {id} is null", nestedParameter.Iid);
                }
                else
                {
                    nestedParameter.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the nestedParameter {id} is null", nestedParameter.Iid);
                }
                else
                {
                    nestedParameter.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the nestedParameter {id} is null", nestedParameter.Iid);
                }
                else
                {
                    nestedParameter.ThingPreference = thingPreferenceProperty.GetString();
                }
            }
            return nestedParameter;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
