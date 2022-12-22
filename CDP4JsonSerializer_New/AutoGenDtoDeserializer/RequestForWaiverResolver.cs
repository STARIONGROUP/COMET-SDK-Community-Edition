// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestForWaiverResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequestForWaiverResolver"/> is to deserialize a JSON object to a <see cref="RequestForWaiver"/>
    /// </summary>
    public static class RequestForWaiverResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="RequestForWaiver"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="RequestForWaiver"/> to instantiate</returns>
        public static CDP4Common.DTO.RequestForWaiver FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var requestForWaiver = new CDP4Common.DTO.RequestForWaiver(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("approvedBy", out var approvedByProperty))
            {
                requestForWaiver.ApprovedBy.AddRange(approvedByProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("author", out var authorProperty))
            {
                requestForWaiver.Author = authorProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("category", out var categoryProperty))
            {
                requestForWaiver.Category.AddRange(categoryProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("classification", out var classificationProperty))
            {
                requestForWaiver.Classification = AnnotationClassificationKindDeserializer.Deserialize(classificationProperty);
            }

            if (jObject.TryGetProperty("content", out var contentProperty))
            {
                requestForWaiver.Content = contentProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("createdOn", out var createdOnProperty))
            {
                requestForWaiver.CreatedOn = createdOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("discussion", out var discussionProperty))
            {
                requestForWaiver.Discussion.AddRange(discussionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                requestForWaiver.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                requestForWaiver.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("languageCode", out var languageCodeProperty))
            {
                requestForWaiver.LanguageCode = languageCodeProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                requestForWaiver.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("owner", out var ownerProperty))
            {
                requestForWaiver.Owner = ownerProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("primaryAnnotatedThing", out var primaryAnnotatedThingProperty))
            {
                requestForWaiver.PrimaryAnnotatedThing = primaryAnnotatedThingProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("relatedThing", out var relatedThingProperty))
            {
                requestForWaiver.RelatedThing.AddRange(relatedThingProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                requestForWaiver.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("sourceAnnotation", out var sourceAnnotationProperty))
            {
                requestForWaiver.SourceAnnotation.AddRange(sourceAnnotationProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("status", out var statusProperty))
            {
                requestForWaiver.Status = AnnotationStatusKindDeserializer.Deserialize(statusProperty);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                requestForWaiver.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("title", out var titleProperty))
            {
                requestForWaiver.Title = titleProperty.Deserialize<string>();
            }

            return requestForWaiver;
        }
    }
}
