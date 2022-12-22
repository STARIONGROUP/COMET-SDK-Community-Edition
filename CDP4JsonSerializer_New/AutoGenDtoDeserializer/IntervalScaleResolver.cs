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
    /// The purpose of the <see cref="IntervalScaleResolver"/> is to deserialize a JSON object to a <see cref="IntervalScale"/>
    /// </summary>
    public static class IntervalScaleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="IntervalScale"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="IntervalScale"/> to instantiate</returns>
        public static CDP4Common.DTO.IntervalScale FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var intervalScale = new CDP4Common.DTO.IntervalScale(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                intervalScale.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                intervalScale.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                intervalScale.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                intervalScale.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                intervalScale.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                intervalScale.IsDeprecated = isDeprecatedProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("isMaximumInclusive", out var isMaximumInclusiveProperty))
            {
                intervalScale.IsMaximumInclusive = isMaximumInclusiveProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("isMinimumInclusive", out var isMinimumInclusiveProperty))
            {
                intervalScale.IsMinimumInclusive = isMinimumInclusiveProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("mappingToReferenceScale", out var mappingToReferenceScaleProperty))
            {
                intervalScale.MappingToReferenceScale.AddRange(mappingToReferenceScaleProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("maximumPermissibleValue", out var maximumPermissibleValueProperty))
            {
                intervalScale.MaximumPermissibleValue = maximumPermissibleValueProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("minimumPermissibleValue", out var minimumPermissibleValueProperty))
            {
                intervalScale.MinimumPermissibleValue = minimumPermissibleValueProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                intervalScale.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                intervalScale.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("negativeValueConnotation", out var negativeValueConnotationProperty))
            {
                intervalScale.NegativeValueConnotation = negativeValueConnotationProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("numberSet", out var numberSetProperty))
            {
                intervalScale.NumberSet = NumberSetKindDeserializer.Deserialize(numberSetProperty);
            }

            if (jObject.TryGetProperty("positiveValueConnotation", out var positiveValueConnotationProperty))
            {
                intervalScale.PositiveValueConnotation = positiveValueConnotationProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                intervalScale.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                intervalScale.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("unit", out var unitProperty))
            {
                intervalScale.Unit = unitProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("valueDefinition", out var valueDefinitionProperty))
            {
                intervalScale.ValueDefinition.AddRange(valueDefinitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            return intervalScale;
        }
    }
}
