// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedQuantityKindResolver.cs" company="RHEA System S.A.">
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

    using CDP4JsonSerializer_SystemTextJson.EnumDeserializers;
    
    /// <summary>
    /// The purpose of the <see cref="DerivedQuantityKindResolver"/> is to deserialize a JSON object to a <see cref="DerivedQuantityKind"/>
    /// </summary>
    public static class DerivedQuantityKindResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="DerivedQuantityKind"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="DerivedQuantityKind"/> to instantiate</returns>
        public static CDP4Common.DTO.DerivedQuantityKind FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var derivedQuantityKind = new CDP4Common.DTO.DerivedQuantityKind(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                derivedQuantityKind.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("category", out var categoryProperty))
            {
                derivedQuantityKind.Category.AddRange(categoryProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("defaultScale", out var defaultScaleProperty))
            {
                derivedQuantityKind.DefaultScale = defaultScaleProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                derivedQuantityKind.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                derivedQuantityKind.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                derivedQuantityKind.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                derivedQuantityKind.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                derivedQuantityKind.IsDeprecated = isDeprecatedProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                derivedQuantityKind.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                derivedQuantityKind.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("possibleScale", out var possibleScaleProperty))
            {
                derivedQuantityKind.PossibleScale.AddRange(possibleScaleProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("quantityDimensionSymbol", out var quantityDimensionSymbolProperty))
            {
                derivedQuantityKind.QuantityDimensionSymbol = quantityDimensionSymbolProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("quantityKindFactor", out var quantityKindFactorProperty))
            {
                foreach(var arrayItem in quantityKindFactorProperty.EnumerateArray())
                {
                    var arrayItemValue = arrayItem.Deserialize<OrderedItem>();
                    if (arrayItemValue != null)
                    {
                        derivedQuantityKind.QuantityKindFactor.Add(arrayItemValue);
                    }
                }
            }

            
            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                derivedQuantityKind.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("symbol", out var symbolProperty))
            {
                derivedQuantityKind.Symbol = symbolProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                derivedQuantityKind.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            return derivedQuantityKind;
        }
    }
}
