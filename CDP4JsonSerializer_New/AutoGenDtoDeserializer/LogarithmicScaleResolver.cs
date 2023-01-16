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
    /// The purpose of the <see cref="LogarithmicScaleResolver"/> is to deserialize a JSON object to a <see cref="LogarithmicScale"/>
    /// </summary>
    public static class LogarithmicScaleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="LogarithmicScale"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="LogarithmicScale"/> to instantiate</returns>
        public static CDP4Common.DTO.LogarithmicScale FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var logarithmicScale = new CDP4Common.DTO.LogarithmicScale(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                logarithmicScale.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                logarithmicScale.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                logarithmicScale.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                logarithmicScale.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("exponent", out var exponentProperty))
            {
                logarithmicScale.Exponent = exponentProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("factor", out var factorProperty))
            {
                logarithmicScale.Factor = factorProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                logarithmicScale.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                logarithmicScale.IsDeprecated = isDeprecatedProperty.Deserialize<bool>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("isMaximumInclusive", out var isMaximumInclusiveProperty))
            {
                logarithmicScale.IsMaximumInclusive = isMaximumInclusiveProperty.Deserialize<bool>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("isMinimumInclusive", out var isMinimumInclusiveProperty))
            {
                logarithmicScale.IsMinimumInclusive = isMinimumInclusiveProperty.Deserialize<bool>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("logarithmBase", out var logarithmBaseProperty))
            {
                logarithmicScale.LogarithmBase = LogarithmBaseKindDeserializer.Deserialize(logarithmBaseProperty);
            }

            if (jObject.TryGetProperty("mappingToReferenceScale", out var mappingToReferenceScaleProperty))
            {
                logarithmicScale.MappingToReferenceScale.AddRange(mappingToReferenceScaleProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("maximumPermissibleValue", out var maximumPermissibleValueProperty))
            {
                logarithmicScale.MaximumPermissibleValue = maximumPermissibleValueProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("minimumPermissibleValue", out var minimumPermissibleValueProperty))
            {
                logarithmicScale.MinimumPermissibleValue = minimumPermissibleValueProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                logarithmicScale.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                logarithmicScale.Name = nameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("negativeValueConnotation", out var negativeValueConnotationProperty))
            {
                logarithmicScale.NegativeValueConnotation = negativeValueConnotationProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("numberSet", out var numberSetProperty))
            {
                logarithmicScale.NumberSet = NumberSetKindDeserializer.Deserialize(numberSetProperty);
            }

            if (jObject.TryGetProperty("positiveValueConnotation", out var positiveValueConnotationProperty))
            {
                logarithmicScale.PositiveValueConnotation = positiveValueConnotationProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("referenceQuantityKind", out var referenceQuantityKindProperty))
            {
                logarithmicScale.ReferenceQuantityKind = referenceQuantityKindProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("referenceQuantityValue", out var referenceQuantityValueProperty))
            {
                logarithmicScale.ReferenceQuantityValue.AddRange(referenceQuantityValueProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                logarithmicScale.ShortName = shortNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                logarithmicScale.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("unit", out var unitProperty))
            {
                logarithmicScale.Unit = unitProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("valueDefinition", out var valueDefinitionProperty))
            {
                logarithmicScale.ValueDefinition.AddRange(valueDefinitionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            return logarithmicScale;
        }
    }
}
