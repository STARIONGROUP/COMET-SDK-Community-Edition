// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RatioScaleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RatioScaleResolver"/> is to deserialize a JSON object to a <see cref="RatioScale"/>
    /// </summary>
    public static class RatioScaleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="RatioScale"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="RatioScale"/> to instantiate</returns>
        public static CDP4Common.DTO.RatioScale FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var ratioScale = new CDP4Common.DTO.RatioScale(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                ratioScale.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                ratioScale.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                ratioScale.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                ratioScale.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                ratioScale.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                ratioScale.IsDeprecated = isDeprecatedProperty.Deserialize<bool>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("isMaximumInclusive", out var isMaximumInclusiveProperty))
            {
                ratioScale.IsMaximumInclusive = isMaximumInclusiveProperty.Deserialize<bool>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("isMinimumInclusive", out var isMinimumInclusiveProperty))
            {
                ratioScale.IsMinimumInclusive = isMinimumInclusiveProperty.Deserialize<bool>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("mappingToReferenceScale", out var mappingToReferenceScaleProperty))
            {
                ratioScale.MappingToReferenceScale.AddRange(mappingToReferenceScaleProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("maximumPermissibleValue", out var maximumPermissibleValueProperty))
            {
                ratioScale.MaximumPermissibleValue = maximumPermissibleValueProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("minimumPermissibleValue", out var minimumPermissibleValueProperty))
            {
                ratioScale.MinimumPermissibleValue = minimumPermissibleValueProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                ratioScale.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                ratioScale.Name = nameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("negativeValueConnotation", out var negativeValueConnotationProperty))
            {
                ratioScale.NegativeValueConnotation = negativeValueConnotationProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("numberSet", out var numberSetProperty))
            {
                ratioScale.NumberSet = NumberSetKindDeserializer.Deserialize(numberSetProperty);
            }

            if (jObject.TryGetProperty("positiveValueConnotation", out var positiveValueConnotationProperty))
            {
                ratioScale.PositiveValueConnotation = positiveValueConnotationProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                ratioScale.ShortName = shortNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                ratioScale.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("unit", out var unitProperty))
            {
                ratioScale.Unit = unitProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("valueDefinition", out var valueDefinitionProperty))
            {
                ratioScale.ValueDefinition.AddRange(valueDefinitionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            return ratioScale;
        }
    }
}
