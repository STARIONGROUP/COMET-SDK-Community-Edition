// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntervalScaleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IntervalScaleResolver"/> is to deserialize a JSON object to a <see cref="IntervalScale"/>
    /// </summary>
    public static class IntervalScaleResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="IntervalScale"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="IntervalScale"/> to instantiate</returns>
        public static CDP4Common.DTO.IntervalScale FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            var intervalScale = new CDP4Common.DTO.IntervalScale(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty))
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    intervalScale.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty))
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    intervalScale.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    intervalScale.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    intervalScale.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty))
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    intervalScale.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isDeprecated property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("isMaximumInclusive"u8, out var isMaximumInclusiveProperty))
            {
                if(isMaximumInclusiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isMaximumInclusive property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.IsMaximumInclusive = isMaximumInclusiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("isMinimumInclusive"u8, out var isMinimumInclusiveProperty))
            {
                if(isMinimumInclusiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isMinimumInclusive property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.IsMinimumInclusive = isMinimumInclusiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("mappingToReferenceScale"u8, out var mappingToReferenceScaleProperty))
            {
                foreach(var element in mappingToReferenceScaleProperty.EnumerateArray())
                {
                    intervalScale.MappingToReferenceScale.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("maximumPermissibleValue"u8, out var maximumPermissibleValueProperty))
            {
                if(maximumPermissibleValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale maximumPermissibleValue property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.MaximumPermissibleValue = maximumPermissibleValueProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("minimumPermissibleValue"u8, out var minimumPermissibleValueProperty))
            {
                if(minimumPermissibleValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale minimumPermissibleValue property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.MinimumPermissibleValue = minimumPermissibleValueProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("negativeValueConnotation"u8, out var negativeValueConnotationProperty))
            {
                if(negativeValueConnotationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale negativeValueConnotation property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.NegativeValueConnotation = negativeValueConnotationProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("numberSet"u8, out var numberSetProperty))
            {
                if(numberSetProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale numberSet property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.NumberSet = NumberSetKindDeserializer.Deserialize(numberSetProperty);
                }
            }

            if (jsonElement.TryGetProperty("positiveValueConnotation"u8, out var positiveValueConnotationProperty))
            {
                if(positiveValueConnotationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale positiveValueConnotation property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.PositiveValueConnotation = positiveValueConnotationProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("unit"u8, out var unitProperty))
            {
                if(unitProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale unit property of the intervalScale {id} is null", intervalScale.Iid);
                }
                else
                {
                    intervalScale.Unit = unitProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("valueDefinition"u8, out var valueDefinitionProperty))
            {
                foreach(var element in valueDefinitionProperty.EnumerateArray())
                {
                    intervalScale.ValueDefinition.Add(element.GetGuid());
                }
            }
            return intervalScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
