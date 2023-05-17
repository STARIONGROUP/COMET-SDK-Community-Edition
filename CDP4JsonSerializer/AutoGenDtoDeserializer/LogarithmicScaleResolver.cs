// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogarithmicScaleResolver.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer
{
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="LogarithmicScaleResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.LogarithmicScale"/>
    /// </summary>
    public static class LogarithmicScaleResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.LogarithmicScale"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.LogarithmicScale"/> to instantiate</returns>
        public static CDP4Common.DTO.LogarithmicScale FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the LogarithmicScaleResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the LogarithmicScaleResolver cannot be used to deserialize this JsonElement");
            }

            var logarithmicScale = new CDP4Common.DTO.LogarithmicScale(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    logarithmicScale.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    logarithmicScale.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    logarithmicScale.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    logarithmicScale.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("exponent"u8, out var exponentProperty))
            {
                if(exponentProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale exponent property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.Exponent = exponentProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("factor"u8, out var factorProperty))
            {
                if(factorProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale factor property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.Factor = factorProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    logarithmicScale.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isDeprecated property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("isMaximumInclusive"u8, out var isMaximumInclusiveProperty))
            {
                if(isMaximumInclusiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isMaximumInclusive property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.IsMaximumInclusive = isMaximumInclusiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("isMinimumInclusive"u8, out var isMinimumInclusiveProperty))
            {
                if(isMinimumInclusiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isMinimumInclusive property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.IsMinimumInclusive = isMinimumInclusiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("logarithmBase"u8, out var logarithmBaseProperty))
            {
                if(logarithmBaseProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale logarithmBase property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.LogarithmBase = LogarithmBaseKindDeserializer.Deserialize(logarithmBaseProperty);
                }
            }

            if (jsonElement.TryGetProperty("mappingToReferenceScale"u8, out var mappingToReferenceScaleProperty) && mappingToReferenceScaleProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in mappingToReferenceScaleProperty.EnumerateArray())
                {
                    logarithmicScale.MappingToReferenceScale.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("maximumPermissibleValue"u8, out var maximumPermissibleValueProperty))
            {
                if(maximumPermissibleValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale maximumPermissibleValue property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.MaximumPermissibleValue = maximumPermissibleValueProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("minimumPermissibleValue"u8, out var minimumPermissibleValueProperty))
            {
                if(minimumPermissibleValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale minimumPermissibleValue property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.MinimumPermissibleValue = minimumPermissibleValueProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("negativeValueConnotation"u8, out var negativeValueConnotationProperty))
            {
                if(negativeValueConnotationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale negativeValueConnotation property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.NegativeValueConnotation = negativeValueConnotationProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("numberSet"u8, out var numberSetProperty))
            {
                if(numberSetProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale numberSet property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.NumberSet = NumberSetKindDeserializer.Deserialize(numberSetProperty);
                }
            }

            if (jsonElement.TryGetProperty("positiveValueConnotation"u8, out var positiveValueConnotationProperty))
            {
                if(positiveValueConnotationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale positiveValueConnotation property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.PositiveValueConnotation = positiveValueConnotationProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("referenceQuantityKind"u8, out var referenceQuantityKindProperty))
            {
                if(referenceQuantityKindProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale referenceQuantityKind property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.ReferenceQuantityKind = referenceQuantityKindProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("referenceQuantityValue"u8, out var referenceQuantityValueProperty) && referenceQuantityValueProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in referenceQuantityValueProperty.EnumerateArray())
                {
                    logarithmicScale.ReferenceQuantityValue.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("unit"u8, out var unitProperty))
            {
                if(unitProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale unit property of the logarithmicScale {id} is null", logarithmicScale.Iid);
                }
                else
                {
                    logarithmicScale.Unit = unitProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("valueDefinition"u8, out var valueDefinitionProperty) && valueDefinitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in valueDefinitionProperty.EnumerateArray())
                {
                    logarithmicScale.ValueDefinition.Add(element.GetGuid());
                }
            }

            return logarithmicScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
