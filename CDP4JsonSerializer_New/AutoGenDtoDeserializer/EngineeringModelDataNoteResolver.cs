// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataNoteResolver.cs" company="RHEA System S.A.">
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

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

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="EngineeringModelDataNoteResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModelDataNote"/>
    /// </summary>
    public static class EngineeringModelDataNoteResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="EngineeringModelDataNote"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModelDataNote"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModelDataNote FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            var engineeringModelDataNote = new CDP4Common.DTO.EngineeringModelDataNote(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("author"u8, out var authorProperty))
            {
                if(authorProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale author property of the engineeringModelDataNote {id} is null", engineeringModelDataNote.Iid);
                }
                else
                {
                    engineeringModelDataNote.Author = authorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("content"u8, out var contentProperty))
            {
                if(contentProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale content property of the engineeringModelDataNote {id} is null", engineeringModelDataNote.Iid);
                }
                else
                {
                    engineeringModelDataNote.Content = contentProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale createdOn property of the engineeringModelDataNote {id} is null", engineeringModelDataNote.Iid);
                }
                else
                {
                    engineeringModelDataNote.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("discussion"u8, out var discussionProperty))
            {
                foreach(var element in discussionProperty.EnumerateArray())
                {
                    engineeringModelDataNote.Discussion.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    engineeringModelDataNote.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    engineeringModelDataNote.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("languageCode"u8, out var languageCodeProperty))
            {
                if(languageCodeProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale languageCode property of the engineeringModelDataNote {id} is null", engineeringModelDataNote.Iid);
                }
                else
                {
                    engineeringModelDataNote.LanguageCode = languageCodeProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the engineeringModelDataNote {id} is null", engineeringModelDataNote.Iid);
                }
                else
                {
                    engineeringModelDataNote.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("primaryAnnotatedThing"u8, out var primaryAnnotatedThingProperty))
            {
                if(primaryAnnotatedThingProperty.ValueKind == JsonValueKind.Null)
                {
                    engineeringModelDataNote.PrimaryAnnotatedThing = null;
                }
                else
                {
                    engineeringModelDataNote.PrimaryAnnotatedThing = primaryAnnotatedThingProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("relatedThing"u8, out var relatedThingProperty))
            {
                foreach(var element in relatedThingProperty.EnumerateArray())
                {
                    engineeringModelDataNote.RelatedThing.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the engineeringModelDataNote {id} is null", engineeringModelDataNote.Iid);
                }
                else
                {
                    engineeringModelDataNote.ThingPreference = thingPreferenceProperty.GetString();
                }
            }
            return engineeringModelDataNote;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
