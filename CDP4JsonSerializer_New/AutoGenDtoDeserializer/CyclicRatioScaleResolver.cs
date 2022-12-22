// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CyclicRatioScaleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CyclicRatioScaleResolver"/> is to deserialize a JSON object to a <see cref="CyclicRatioScale"/>
    /// </summary>
    public static class CyclicRatioScaleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CyclicRatioScale"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CyclicRatioScale"/> to instantiate</returns>
        public static CDP4Common.DTO.CyclicRatioScale FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var cyclicRatioScale = new CDP4Common.DTO.CyclicRatioScale(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                cyclicRatioScale.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                cyclicRatioScale.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                cyclicRatioScale.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                cyclicRatioScale.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                cyclicRatioScale.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                cyclicRatioScale.IsDeprecated = isDeprecatedProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("isMaximumInclusive", out var isMaximumInclusiveProperty))
            {
                cyclicRatioScale.IsMaximumInclusive = isMaximumInclusiveProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("isMinimumInclusive", out var isMinimumInclusiveProperty))
            {
                cyclicRatioScale.IsMinimumInclusive = isMinimumInclusiveProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("mappingToReferenceScale", out var mappingToReferenceScaleProperty))
            {
                cyclicRatioScale.MappingToReferenceScale.AddRange(mappingToReferenceScaleProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("maximumPermissibleValue", out var maximumPermissibleValueProperty))
            {
                cyclicRatioScale.MaximumPermissibleValue = maximumPermissibleValueProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("minimumPermissibleValue", out var minimumPermissibleValueProperty))
            {
                cyclicRatioScale.MinimumPermissibleValue = minimumPermissibleValueProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                cyclicRatioScale.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("modulus", out var modulusProperty))
            {
                cyclicRatioScale.Modulus = modulusProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                cyclicRatioScale.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("negativeValueConnotation", out var negativeValueConnotationProperty))
            {
                cyclicRatioScale.NegativeValueConnotation = negativeValueConnotationProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("numberSet", out var numberSetProperty))
            {
                cyclicRatioScale.NumberSet = NumberSetKindDeserializer.Deserialize(numberSetProperty);
            }

            if (jObject.TryGetProperty("positiveValueConnotation", out var positiveValueConnotationProperty))
            {
                cyclicRatioScale.PositiveValueConnotation = positiveValueConnotationProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                cyclicRatioScale.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                cyclicRatioScale.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("unit", out var unitProperty))
            {
                cyclicRatioScale.Unit = unitProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("valueDefinition", out var valueDefinitionProperty))
            {
                cyclicRatioScale.ValueDefinition.AddRange(valueDefinitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            return cyclicRatioScale;
        }
    }
}
