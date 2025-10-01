// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecializedQuantityKindResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="SpecializedQuantityKindResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.SpecializedQuantityKind"/>
    /// </summary>
    public static class SpecializedQuantityKindResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.SpecializedQuantityKind"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.SpecializedQuantityKind"/> to instantiate</returns>
        public static CDP4Common.DTO.SpecializedQuantityKind FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the SpecializedQuantityKindResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var specializedQuantityKind = new CDP4Common.DTO.SpecializedQuantityKind(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    specializedQuantityKind.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    specializedQuantityKind.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("defaultScale"u8, out var defaultScaleProperty))
            {
                if(defaultScaleProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale defaultScale property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.DefaultScale = defaultScaleProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    specializedQuantityKind.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    specializedQuantityKind.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    specializedQuantityKind.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("general"u8, out var generalProperty))
            {
                if(generalProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale general property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.General = generalProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    specializedQuantityKind.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale isDeprecated property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale name property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("possibleScale"u8, out var possibleScaleProperty) && possibleScaleProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in possibleScaleProperty.EnumerateArray())
                {
                    specializedQuantityKind.PossibleScale.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("quantityDimensionSymbol"u8, out var quantityDimensionSymbolProperty))
            {
                if(quantityDimensionSymbolProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale quantityDimensionSymbol property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.QuantityDimensionSymbol = quantityDimensionSymbolProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale shortName property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("symbol"u8, out var symbolProperty))
            {
                if(symbolProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale symbol property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.Symbol = symbolProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the specializedQuantityKind {id} is null", specializedQuantityKind.Iid);
                }
                else
                {
                    specializedQuantityKind.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return specializedQuantityKind;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
