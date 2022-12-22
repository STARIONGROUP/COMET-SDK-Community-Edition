// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionItemResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActionItemResolver"/> is to deserialize a JSON object to a <see cref="ActionItem"/>
    /// </summary>
    public static class ActionItemResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="ActionItem"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="ActionItem"/> to instantiate</returns>
        public static CDP4Common.DTO.ActionItem FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var actionItem = new CDP4Common.DTO.ActionItem(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("actionee", out var actioneeProperty))
            {
                actionItem.Actionee = actioneeProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("approvedBy", out var approvedByProperty))
            {
                actionItem.ApprovedBy.AddRange(approvedByProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("author", out var authorProperty))
            {
                actionItem.Author = authorProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("category", out var categoryProperty))
            {
                actionItem.Category.AddRange(categoryProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("classification", out var classificationProperty))
            {
                actionItem.Classification = AnnotationClassificationKindDeserializer.Deserialize(classificationProperty);
            }

            if (jObject.TryGetProperty("closeOutDate", out var closeOutDateProperty))
            {
                actionItem.CloseOutDate = closeOutDateProperty.Deserialize<DateTime?>();
            }

            if (jObject.TryGetProperty("closeOutStatement", out var closeOutStatementProperty))
            {
                actionItem.CloseOutStatement = closeOutStatementProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("content", out var contentProperty))
            {
                actionItem.Content = contentProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("createdOn", out var createdOnProperty))
            {
                actionItem.CreatedOn = createdOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("discussion", out var discussionProperty))
            {
                actionItem.Discussion.AddRange(discussionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("dueDate", out var dueDateProperty))
            {
                actionItem.DueDate = dueDateProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                actionItem.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                actionItem.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("languageCode", out var languageCodeProperty))
            {
                actionItem.LanguageCode = languageCodeProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                actionItem.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("owner", out var ownerProperty))
            {
                actionItem.Owner = ownerProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("primaryAnnotatedThing", out var primaryAnnotatedThingProperty))
            {
                actionItem.PrimaryAnnotatedThing = primaryAnnotatedThingProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("relatedThing", out var relatedThingProperty))
            {
                actionItem.RelatedThing.AddRange(relatedThingProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                actionItem.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("sourceAnnotation", out var sourceAnnotationProperty))
            {
                actionItem.SourceAnnotation.AddRange(sourceAnnotationProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("status", out var statusProperty))
            {
                actionItem.Status = AnnotationStatusKindDeserializer.Deserialize(statusProperty);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                actionItem.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("title", out var titleProperty))
            {
                actionItem.Title = titleProperty.Deserialize<string>();
            }

            return actionItem;
        }
    }
}
