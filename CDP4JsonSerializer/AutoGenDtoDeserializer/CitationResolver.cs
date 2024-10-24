// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="CitationResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="CitationResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.Citation"/>
    /// </summary>
    public static class CitationResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.Citation"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.Citation"/> to instantiate</returns>
        public static CDP4Common.DTO.Citation FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the CitationResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var citation = new CDP4Common.DTO.Citation(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    citation.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    citation.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isAdaptation"u8, out var isAdaptationProperty))
            {
                if(isAdaptationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale isAdaptation property of the citation {id} is null", citation.Iid);
                }
                else
                {
                    citation.IsAdaptation = isAdaptationProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("location"u8, out var locationProperty))
            {
                if(locationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale location property of the citation {id} is null", citation.Iid);
                }
                else
                {
                    citation.Location = locationProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the citation {id} is null", citation.Iid);
                }
                else
                {
                    citation.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("remark"u8, out var remarkProperty))
            {
                if(remarkProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale remark property of the citation {id} is null", citation.Iid);
                }
                else
                {
                    citation.Remark = remarkProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale shortName property of the citation {id} is null", citation.Iid);
                }
                else
                {
                    citation.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("source"u8, out var sourceProperty))
            {
                if(sourceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale source property of the citation {id} is null", citation.Iid);
                }
                else
                {
                    citation.Source = sourceProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the citation {id} is null", citation.Iid);
                }
                else
                {
                    citation.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return citation;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
