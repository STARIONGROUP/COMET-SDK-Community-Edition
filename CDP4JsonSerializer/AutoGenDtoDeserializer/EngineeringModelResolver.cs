// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.EngineeringModel"/>
    /// </summary>
    public static class EngineeringModelResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.EngineeringModel"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.EngineeringModel"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModel FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the EngineeringModelResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var engineeringModel = new CDP4Common.DTO.EngineeringModel(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("book"u8, out var bookProperty))
            {
                engineeringModel.Book.AddRange(bookProperty.ToOrderedItemCollection());
            }

            if (jsonElement.TryGetProperty("commonFileStore"u8, out var commonFileStoreProperty) && commonFileStoreProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in commonFileStoreProperty.EnumerateArray())
                {
                    engineeringModel.CommonFileStore.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("engineeringModelSetup"u8, out var engineeringModelSetupProperty))
            {
                if(engineeringModelSetupProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale engineeringModelSetup property of the engineeringModel {id} is null", engineeringModel.Iid);
                }
                else
                {
                    engineeringModel.EngineeringModelSetup = engineeringModelSetupProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    engineeringModel.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    engineeringModel.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("genericNote"u8, out var genericNoteProperty) && genericNoteProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in genericNoteProperty.EnumerateArray())
                {
                    engineeringModel.GenericNote.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("iteration"u8, out var iterationProperty) && iterationProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in iterationProperty.EnumerateArray())
                {
                    engineeringModel.Iteration.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("lastModifiedOn"u8, out var lastModifiedOnProperty))
            {
                if(lastModifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale lastModifiedOn property of the engineeringModel {id} is null", engineeringModel.Iid);
                }
                else
                {
                    engineeringModel.LastModifiedOn = lastModifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("logEntry"u8, out var logEntryProperty) && logEntryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in logEntryProperty.EnumerateArray())
                {
                    engineeringModel.LogEntry.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modellingAnnotation"u8, out var modellingAnnotationProperty) && modellingAnnotationProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in modellingAnnotationProperty.EnumerateArray())
                {
                    engineeringModel.ModellingAnnotation.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the engineeringModel {id} is null", engineeringModel.Iid);
                }
                else
                {
                    engineeringModel.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the engineeringModel {id} is null", engineeringModel.Iid);
                }
                else
                {
                    engineeringModel.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return engineeringModel;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
