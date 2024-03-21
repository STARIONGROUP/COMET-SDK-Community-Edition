// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinitionResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="DefinitionResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.Definition"/>
    /// </summary>
    public static class DefinitionResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.Definition"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.Definition"/> to instantiate</returns>
        public static CDP4Common.DTO.Definition FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the DefinitionResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var definition = new CDP4Common.DTO.Definition(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("citation"u8, out var citationProperty) && citationProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in citationProperty.EnumerateArray())
                {
                    definition.Citation.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("content"u8, out var contentProperty))
            {
                if(contentProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale content property of the definition {id} is null", definition.Iid);
                }
                else
                {
                    definition.Content = contentProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("example"u8, out var exampleProperty))
            {
                definition.Example.AddRange(exampleProperty.ToOrderedItemCollection());
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    definition.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    definition.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("languageCode"u8, out var languageCodeProperty))
            {
                if(languageCodeProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale languageCode property of the definition {id} is null", definition.Iid);
                }
                else
                {
                    definition.LanguageCode = languageCodeProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the definition {id} is null", definition.Iid);
                }
                else
                {
                    definition.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("note"u8, out var noteProperty))
            {
                definition.Note.AddRange(noteProperty.ToOrderedItemCollection());
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the definition {id} is null", definition.Iid);
                }
                else
                {
                    definition.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return definition;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
