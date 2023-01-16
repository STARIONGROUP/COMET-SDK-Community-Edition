// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampledFunctionParameterTypeResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SampledFunctionParameterTypeResolver"/> is to deserialize a JSON object to a <see cref="SampledFunctionParameterType"/>
    /// </summary>
    public static class SampledFunctionParameterTypeResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="SampledFunctionParameterType"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="SampledFunctionParameterType"/> to instantiate</returns>
        public static CDP4Common.DTO.SampledFunctionParameterType FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var sampledFunctionParameterType = new CDP4Common.DTO.SampledFunctionParameterType(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                sampledFunctionParameterType.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("category", out var categoryProperty))
            {
                sampledFunctionParameterType.Category.AddRange(categoryProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                sampledFunctionParameterType.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("degreeOfInterpolation", out var degreeOfInterpolationProperty))
            {
                sampledFunctionParameterType.DegreeOfInterpolation = degreeOfInterpolationProperty.Deserialize<int?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("dependentParameterType", out var dependentParameterTypeProperty))
            {
                foreach(var arrayItem in dependentParameterTypeProperty.EnumerateArray())
                {
                    var arrayItemValue = arrayItem.Deserialize<OrderedItem>(SerializerOptions.Options);
                    if (arrayItemValue != null)
                    {
                        sampledFunctionParameterType.DependentParameterType.Add(arrayItemValue);
                    }
                }
            }
            
            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                sampledFunctionParameterType.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                sampledFunctionParameterType.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                sampledFunctionParameterType.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("independentParameterType", out var independentParameterTypeProperty))
            {
                foreach(var arrayItem in independentParameterTypeProperty.EnumerateArray())
                {
                    var arrayItemValue = arrayItem.Deserialize<OrderedItem>(SerializerOptions.Options);
                    if (arrayItemValue != null)
                    {
                        sampledFunctionParameterType.IndependentParameterType.Add(arrayItemValue);
                    }
                }
            }
            
            if (jObject.TryGetProperty("interpolationPeriod", out var interpolationPeriodProperty))
            {
                sampledFunctionParameterType.InterpolationPeriod = SerializerHelper.ToValueArray<string>(interpolationPeriodProperty.GetString());
            }

            
            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                sampledFunctionParameterType.IsDeprecated = isDeprecatedProperty.Deserialize<bool>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                sampledFunctionParameterType.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                sampledFunctionParameterType.Name = nameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                sampledFunctionParameterType.ShortName = shortNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("symbol", out var symbolProperty))
            {
                sampledFunctionParameterType.Symbol = symbolProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                sampledFunctionParameterType.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            return sampledFunctionParameterType;
        }
    }
}
