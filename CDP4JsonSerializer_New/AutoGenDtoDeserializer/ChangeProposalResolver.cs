// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeProposalResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ChangeProposalResolver"/> is to deserialize a JSON object to a <see cref="ChangeProposal"/>
    /// </summary>
    public static class ChangeProposalResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="ChangeProposal"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="ChangeProposal"/> to instantiate</returns>
        public static CDP4Common.DTO.ChangeProposal FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            var changeProposal = new CDP4Common.DTO.ChangeProposal(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("approvedBy"u8, out var approvedByProperty))
            {
                foreach(var element in approvedByProperty.EnumerateArray())
                {
                    changeProposal.ApprovedBy.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("author"u8, out var authorProperty))
            {
                if(authorProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale author property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.Author = authorProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty))
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    changeProposal.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("changeRequest"u8, out var changeRequestProperty))
            {
                if(changeRequestProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale changeRequest property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.ChangeRequest = changeRequestProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("classification"u8, out var classificationProperty))
            {
                if(classificationProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale classification property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.Classification = AnnotationClassificationKindDeserializer.Deserialize(classificationProperty);
                }
            }

            if (jsonElement.TryGetProperty("content"u8, out var contentProperty))
            {
                if(contentProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale content property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.Content = contentProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale createdOn property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("discussion"u8, out var discussionProperty))
            {
                foreach(var element in discussionProperty.EnumerateArray())
                {
                    changeProposal.Discussion.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    changeProposal.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    changeProposal.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("languageCode"u8, out var languageCodeProperty))
            {
                if(languageCodeProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale languageCode property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.LanguageCode = languageCodeProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("primaryAnnotatedThing"u8, out var primaryAnnotatedThingProperty))
            {
                if(primaryAnnotatedThingProperty.ValueKind == JsonValueKind.Null)
                {
                    changeProposal.PrimaryAnnotatedThing = null;
                }
                else
                {
                    changeProposal.PrimaryAnnotatedThing = primaryAnnotatedThingProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("relatedThing"u8, out var relatedThingProperty))
            {
                foreach(var element in relatedThingProperty.EnumerateArray())
                {
                    changeProposal.RelatedThing.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("sourceAnnotation"u8, out var sourceAnnotationProperty))
            {
                foreach(var element in sourceAnnotationProperty.EnumerateArray())
                {
                    changeProposal.SourceAnnotation.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("status"u8, out var statusProperty))
            {
                if(statusProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale status property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.Status = AnnotationStatusKindDeserializer.Deserialize(statusProperty);
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("title"u8, out var titleProperty))
            {
                if(titleProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale title property of the changeProposal {id} is null", changeProposal.Iid);
                }
                else
                {
                    changeProposal.Title = titleProperty.GetString();
                }
            }
            return changeProposal;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
