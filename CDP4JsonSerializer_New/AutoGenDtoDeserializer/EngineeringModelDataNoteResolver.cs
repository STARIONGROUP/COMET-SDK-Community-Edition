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
    /// The purpose of the <see cref="EngineeringModelDataNoteResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModelDataNote"/>
    /// </summary>
    public static class EngineeringModelDataNoteResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="EngineeringModelDataNote"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModelDataNote"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModelDataNote FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var engineeringModelDataNote = new CDP4Common.DTO.EngineeringModelDataNote(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("author", out var authorProperty))
            {
                engineeringModelDataNote.Author = authorProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("content", out var contentProperty))
            {
                engineeringModelDataNote.Content = contentProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("createdOn", out var createdOnProperty))
            {
                engineeringModelDataNote.CreatedOn = createdOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("discussion", out var discussionProperty))
            {
                engineeringModelDataNote.Discussion.AddRange(discussionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                engineeringModelDataNote.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                engineeringModelDataNote.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("languageCode", out var languageCodeProperty))
            {
                engineeringModelDataNote.LanguageCode = languageCodeProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                engineeringModelDataNote.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("primaryAnnotatedThing", out var primaryAnnotatedThingProperty))
            {
                engineeringModelDataNote.PrimaryAnnotatedThing = primaryAnnotatedThingProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("relatedThing", out var relatedThingProperty))
            {
                engineeringModelDataNote.RelatedThing.AddRange(relatedThingProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                engineeringModelDataNote.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            return engineeringModelDataNote;
        }
    }
}
