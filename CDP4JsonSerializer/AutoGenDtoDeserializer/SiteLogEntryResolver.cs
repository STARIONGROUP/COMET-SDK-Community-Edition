// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteLogEntryResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="SiteLogEntryResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.SiteLogEntry"/>
    /// </summary>
    public static class SiteLogEntryResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.SiteLogEntry"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.SiteLogEntry"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteLogEntry FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the SiteLogEntryResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var siteLogEntry = new CDP4Common.DTO.SiteLogEntry(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("affectedDomainIid"u8, out var affectedDomainIidProperty) && affectedDomainIidProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in affectedDomainIidProperty.EnumerateArray())
                {
                    siteLogEntry.AffectedDomainIid.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("affectedItemIid"u8, out var affectedItemIidProperty) && affectedItemIidProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in affectedItemIidProperty.EnumerateArray())
                {
                    siteLogEntry.AffectedItemIid.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("author"u8, out var authorProperty))
            {
                if(authorProperty.ValueKind == JsonValueKind.Null)
                {
                    siteLogEntry.Author = null;
                }
                else
                {
                    siteLogEntry.Author = authorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    siteLogEntry.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("content"u8, out var contentProperty))
            {
                if(contentProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale content property of the siteLogEntry {id} is null", siteLogEntry.Iid);
                }
                else
                {
                    siteLogEntry.Content = contentProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale createdOn property of the siteLogEntry {id} is null", siteLogEntry.Iid);
                }
                else
                {
                    siteLogEntry.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    siteLogEntry.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    siteLogEntry.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("languageCode"u8, out var languageCodeProperty))
            {
                if(languageCodeProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale languageCode property of the siteLogEntry {id} is null", siteLogEntry.Iid);
                }
                else
                {
                    siteLogEntry.LanguageCode = languageCodeProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("level"u8, out var levelProperty))
            {
                if(levelProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale level property of the siteLogEntry {id} is null", siteLogEntry.Iid);
                }
                else
                {
                    siteLogEntry.Level = LogLevelKindDeserializer.Deserialize(levelProperty);
                }
            }

            if (jsonElement.TryGetProperty("logEntryChangelogItem"u8, out var logEntryChangelogItemProperty) && logEntryChangelogItemProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in logEntryChangelogItemProperty.EnumerateArray())
                {
                    siteLogEntry.LogEntryChangelogItem.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the siteLogEntry {id} is null", siteLogEntry.Iid);
                }
                else
                {
                    siteLogEntry.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the siteLogEntry {id} is null", siteLogEntry.Iid);
                }
                else
                {
                    siteLogEntry.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return siteLogEntry;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
