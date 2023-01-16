// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModel"/>
    /// </summary>
    public static class EngineeringModelResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="EngineeringModel"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModel"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModel FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var engineeringModel = new CDP4Common.DTO.EngineeringModel(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("book", out var bookProperty))
            {
                foreach(var arrayItem in bookProperty.EnumerateArray())
                {
                    var arrayItemValue = arrayItem.Deserialize<OrderedItem>(SerializerOptions.Options);
                    if (arrayItemValue != null)
                    {
                        engineeringModel.Book.Add(arrayItemValue);
                    }
                }
            }
            
            if (jObject.TryGetProperty("commonFileStore", out var commonFileStoreProperty))
            {
                engineeringModel.CommonFileStore.AddRange(commonFileStoreProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("engineeringModelSetup", out var engineeringModelSetupProperty))
            {
                engineeringModel.EngineeringModelSetup = engineeringModelSetupProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                engineeringModel.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                engineeringModel.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("genericNote", out var genericNoteProperty))
            {
                engineeringModel.GenericNote.AddRange(genericNoteProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("iteration", out var iterationProperty))
            {
                engineeringModel.Iteration.AddRange(iterationProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("lastModifiedOn", out var lastModifiedOnProperty))
            {
                engineeringModel.LastModifiedOn = lastModifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("logEntry", out var logEntryProperty))
            {
                engineeringModel.LogEntry.AddRange(logEntryProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("modellingAnnotation", out var modellingAnnotationProperty))
            {
                engineeringModel.ModellingAnnotation.AddRange(modellingAnnotationProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                engineeringModel.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                engineeringModel.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            return engineeringModel;
        }
    }
}
