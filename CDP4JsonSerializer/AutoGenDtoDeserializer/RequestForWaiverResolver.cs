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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="RequestForWaiverResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.RequestForWaiver"/>
    /// </summary>
    public static class RequestForWaiverResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.RequestForWaiver"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.RequestForWaiver"/> to instantiate</returns>
        public static CDP4Common.DTO.RequestForWaiver FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the RequestForWaiverResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the RequestForWaiverResolver cannot be used to deserialize this JsonElement");
            }

            var requestForWaiver = new CDP4Common.DTO.RequestForWaiver(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("approvedBy"u8, out var approvedByProperty) && approvedByProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in approvedByProperty.EnumerateArray())
                {
                    requestForWaiver.ApprovedBy.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("author"u8, out var authorProperty))
            {
                if(authorProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale author property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.Author = authorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    requestForWaiver.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("classification"u8, out var classificationProperty))
            {
                if(classificationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale classification property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.Classification = AnnotationClassificationKindDeserializer.Deserialize(classificationProperty);
                }
            }

            if (jsonElement.TryGetProperty("content"u8, out var contentProperty))
            {
                if(contentProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale content property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.Content = contentProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale createdOn property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("discussion"u8, out var discussionProperty) && discussionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in discussionProperty.EnumerateArray())
                {
                    requestForWaiver.Discussion.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    requestForWaiver.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    requestForWaiver.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("languageCode"u8, out var languageCodeProperty))
            {
                if(languageCodeProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale languageCode property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.LanguageCode = languageCodeProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("primaryAnnotatedThing"u8, out var primaryAnnotatedThingProperty))
            {
                if(primaryAnnotatedThingProperty.ValueKind == JsonValueKind.Null)
                {
                    requestForWaiver.PrimaryAnnotatedThing = null;
                }
                else
                {
                    requestForWaiver.PrimaryAnnotatedThing = primaryAnnotatedThingProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("relatedThing"u8, out var relatedThingProperty) && relatedThingProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in relatedThingProperty.EnumerateArray())
                {
                    requestForWaiver.RelatedThing.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("sourceAnnotation"u8, out var sourceAnnotationProperty) && sourceAnnotationProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in sourceAnnotationProperty.EnumerateArray())
                {
                    requestForWaiver.SourceAnnotation.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("status"u8, out var statusProperty))
            {
                if(statusProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale status property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.Status = AnnotationStatusKindDeserializer.Deserialize(statusProperty);
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("title"u8, out var titleProperty))
            {
                if(titleProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale title property of the requestForWaiver {id} is null", requestForWaiver.Iid);
                }
                else
                {
                    requestForWaiver.Title = titleProperty.GetString();
                }
            }

            return requestForWaiver;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
