// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingToReferenceScaleResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="MappingToReferenceScaleResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.MappingToReferenceScale"/>
    /// </summary>
    public static class MappingToReferenceScaleResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.MappingToReferenceScale"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.MappingToReferenceScale"/> to instantiate</returns>
        public static CDP4Common.DTO.MappingToReferenceScale FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the MappingToReferenceScaleResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var mappingToReferenceScale = new CDP4Common.DTO.MappingToReferenceScale(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("dependentScaleValue"u8, out var dependentScaleValueProperty))
            {
                if(dependentScaleValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale dependentScaleValue property of the mappingToReferenceScale {id} is null", mappingToReferenceScale.Iid);
                }
                else
                {
                    mappingToReferenceScale.DependentScaleValue = dependentScaleValueProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    mappingToReferenceScale.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    mappingToReferenceScale.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the mappingToReferenceScale {id} is null", mappingToReferenceScale.Iid);
                }
                else
                {
                    mappingToReferenceScale.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("referenceScaleValue"u8, out var referenceScaleValueProperty))
            {
                if(referenceScaleValueProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale referenceScaleValue property of the mappingToReferenceScale {id} is null", mappingToReferenceScale.Iid);
                }
                else
                {
                    mappingToReferenceScale.ReferenceScaleValue = referenceScaleValueProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the mappingToReferenceScale {id} is null", mappingToReferenceScale.Iid);
                }
                else
                {
                    mappingToReferenceScale.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return mappingToReferenceScale;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
