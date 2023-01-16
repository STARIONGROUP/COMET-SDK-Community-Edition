// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewItemDiscrepancyResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ReviewItemDiscrepancyResolver"/> is to deserialize a JSON object to a <see cref="ReviewItemDiscrepancy"/>
    /// </summary>
    public static class ReviewItemDiscrepancyResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="ReviewItemDiscrepancy"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="ReviewItemDiscrepancy"/> to instantiate</returns>
        public static CDP4Common.DTO.ReviewItemDiscrepancy FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var reviewItemDiscrepancy = new CDP4Common.DTO.ReviewItemDiscrepancy(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("approvedBy", out var approvedByProperty))
            {
                reviewItemDiscrepancy.ApprovedBy.AddRange(approvedByProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("author", out var authorProperty))
            {
                reviewItemDiscrepancy.Author = authorProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("category", out var categoryProperty))
            {
                reviewItemDiscrepancy.Category.AddRange(categoryProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("classification", out var classificationProperty))
            {
                reviewItemDiscrepancy.Classification = AnnotationClassificationKindDeserializer.Deserialize(classificationProperty);
            }

            if (jObject.TryGetProperty("content", out var contentProperty))
            {
                reviewItemDiscrepancy.Content = contentProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("createdOn", out var createdOnProperty))
            {
                reviewItemDiscrepancy.CreatedOn = createdOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("discussion", out var discussionProperty))
            {
                reviewItemDiscrepancy.Discussion.AddRange(discussionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                reviewItemDiscrepancy.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                reviewItemDiscrepancy.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("languageCode", out var languageCodeProperty))
            {
                reviewItemDiscrepancy.LanguageCode = languageCodeProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                reviewItemDiscrepancy.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("owner", out var ownerProperty))
            {
                reviewItemDiscrepancy.Owner = ownerProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("primaryAnnotatedThing", out var primaryAnnotatedThingProperty))
            {
                reviewItemDiscrepancy.PrimaryAnnotatedThing = primaryAnnotatedThingProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("relatedThing", out var relatedThingProperty))
            {
                reviewItemDiscrepancy.RelatedThing.AddRange(relatedThingProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                reviewItemDiscrepancy.ShortName = shortNameProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("solution", out var solutionProperty))
            {
                reviewItemDiscrepancy.Solution.AddRange(solutionProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("sourceAnnotation", out var sourceAnnotationProperty))
            {
                reviewItemDiscrepancy.SourceAnnotation.AddRange(sourceAnnotationProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("status", out var statusProperty))
            {
                reviewItemDiscrepancy.Status = AnnotationStatusKindDeserializer.Deserialize(statusProperty);
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                reviewItemDiscrepancy.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("title", out var titleProperty))
            {
                reviewItemDiscrepancy.Title = titleProperty.Deserialize<string>(SerializerOptions.Options);
            }

            return reviewItemDiscrepancy;
        }
    }
}
