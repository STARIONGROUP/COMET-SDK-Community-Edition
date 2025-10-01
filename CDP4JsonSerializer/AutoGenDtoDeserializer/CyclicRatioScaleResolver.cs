// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="CyclicRatioScaleResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Text.Json;

    using CDP4Common.Types;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="CyclicRatioScaleResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.CyclicRatioScale"/>
    /// </summary>
    public static class CyclicRatioScaleResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.CyclicRatioScale"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.CyclicRatioScale"/> to instantiate</returns>
        public static CDP4Common.DTO.CyclicRatioScale FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the CyclicRatioScaleResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var cyclicRatioScale = new CDP4Common.DTO.CyclicRatioScale(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    cyclicRatioScale.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    cyclicRatioScale.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    cyclicRatioScale.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    cyclicRatioScale.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    cyclicRatioScale.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale isDeprecated property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("isMaximumInclusive"u8, out var isMaximumInclusiveProperty))
            {
                if(isMaximumInclusiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale isMaximumInclusive property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.IsMaximumInclusive = isMaximumInclusiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("isMinimumInclusive"u8, out var isMinimumInclusiveProperty))
            {
                if(isMinimumInclusiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale isMinimumInclusive property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.IsMinimumInclusive = isMinimumInclusiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("mappingToReferenceScale"u8, out var mappingToReferenceScaleProperty) && mappingToReferenceScaleProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in mappingToReferenceScaleProperty.EnumerateArray())
                {
                    cyclicRatioScale.MappingToReferenceScale.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("maximumPermissibleValue"u8, out var maximumPermissibleValueProperty))
            {
                if(maximumPermissibleValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale maximumPermissibleValue property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.MaximumPermissibleValue = maximumPermissibleValueProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("minimumPermissibleValue"u8, out var minimumPermissibleValueProperty))
            {
                if(minimumPermissibleValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale minimumPermissibleValue property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.MinimumPermissibleValue = minimumPermissibleValueProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("modulus"u8, out var modulusProperty))
            {
                if(modulusProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modulus property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.Modulus = modulusProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale name property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("negativeValueConnotation"u8, out var negativeValueConnotationProperty))
            {
                if(negativeValueConnotationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale negativeValueConnotation property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.NegativeValueConnotation = negativeValueConnotationProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("numberSet"u8, out var numberSetProperty))
            {
                if(numberSetProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale numberSet property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.NumberSet = NumberSetKindDeserializer.Deserialize(numberSetProperty);
                }
            }

            if (jsonElement.TryGetProperty("positiveValueConnotation"u8, out var positiveValueConnotationProperty))
            {
                if(positiveValueConnotationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale positiveValueConnotation property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.PositiveValueConnotation = positiveValueConnotationProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale shortName property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("unit"u8, out var unitProperty))
            {
                if(unitProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale unit property of the cyclicRatioScale {id} is null", cyclicRatioScale.Iid);
                }
                else
                {
                    cyclicRatioScale.Unit = unitProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("valueDefinition"u8, out var valueDefinitionProperty) && valueDefinitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in valueDefinitionProperty.EnumerateArray())
                {
                    cyclicRatioScale.ValueDefinition.Add(element.GetGuid());
                }
            }

            return cyclicRatioScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
