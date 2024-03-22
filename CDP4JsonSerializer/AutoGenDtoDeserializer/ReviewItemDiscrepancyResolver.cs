// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewItemDiscrepancyResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ReviewItemDiscrepancyResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>
    /// </summary>
    public static class ReviewItemDiscrepancyResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/> to instantiate</returns>
        public static CDP4Common.DTO.ReviewItemDiscrepancy FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ReviewItemDiscrepancyResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var reviewItemDiscrepancy = new CDP4Common.DTO.ReviewItemDiscrepancy(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("approvedBy"u8, out var approvedByProperty) && approvedByProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in approvedByProperty.EnumerateArray())
                {
                    reviewItemDiscrepancy.ApprovedBy.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("author"u8, out var authorProperty))
            {
                if(authorProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale author property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.Author = authorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    reviewItemDiscrepancy.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("classification"u8, out var classificationProperty))
            {
                if(classificationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale classification property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.Classification = AnnotationClassificationKindDeserializer.Deserialize(classificationProperty);
                }
            }

            if (jsonElement.TryGetProperty("content"u8, out var contentProperty))
            {
                if(contentProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale content property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.Content = contentProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale createdOn property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("discussion"u8, out var discussionProperty) && discussionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in discussionProperty.EnumerateArray())
                {
                    reviewItemDiscrepancy.Discussion.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    reviewItemDiscrepancy.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    reviewItemDiscrepancy.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("languageCode"u8, out var languageCodeProperty))
            {
                if(languageCodeProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale languageCode property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.LanguageCode = languageCodeProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale owner property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("primaryAnnotatedThing"u8, out var primaryAnnotatedThingProperty))
            {
                if(primaryAnnotatedThingProperty.ValueKind == JsonValueKind.Null)
                {
                    reviewItemDiscrepancy.PrimaryAnnotatedThing = null;
                }
                else
                {
                    reviewItemDiscrepancy.PrimaryAnnotatedThing = primaryAnnotatedThingProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("relatedThing"u8, out var relatedThingProperty) && relatedThingProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in relatedThingProperty.EnumerateArray())
                {
                    reviewItemDiscrepancy.RelatedThing.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale shortName property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("solution"u8, out var solutionProperty) && solutionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in solutionProperty.EnumerateArray())
                {
                    reviewItemDiscrepancy.Solution.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("sourceAnnotation"u8, out var sourceAnnotationProperty) && sourceAnnotationProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in sourceAnnotationProperty.EnumerateArray())
                {
                    reviewItemDiscrepancy.SourceAnnotation.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("status"u8, out var statusProperty))
            {
                if(statusProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale status property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.Status = AnnotationStatusKindDeserializer.Deserialize(statusProperty);
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("title"u8, out var titleProperty))
            {
                if(titleProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale title property of the reviewItemDiscrepancy {id} is null", reviewItemDiscrepancy.Iid);
                }
                else
                {
                    reviewItemDiscrepancy.Title = titleProperty.GetString();
                }
            }

            return reviewItemDiscrepancy;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
