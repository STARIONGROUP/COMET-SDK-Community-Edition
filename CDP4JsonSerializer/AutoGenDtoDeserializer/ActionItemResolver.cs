// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionItemResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="ActionItemResolver"/> is to deserialize a JSON object to a <see cref="ActionItem"/>
    /// </summary>
    public static class ActionItemResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ActionItem"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ActionItem"/> to instantiate</returns>
        public static CDP4Common.DTO.ActionItem FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var actionItem = new CDP4Common.DTO.ActionItem(iid, revisionNumber);

            if (!jObject["actionee"].IsNullOrEmpty())
            {
                actionItem.Actionee = jObject["actionee"].ToObject<Guid>();
            }

            if (!jObject["actor"].IsNullOrEmpty())
            {
                actionItem.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["approvedBy"].IsNullOrEmpty())
            {
                actionItem.ApprovedBy.AddRange(jObject["approvedBy"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["author"].IsNullOrEmpty())
            {
                actionItem.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                actionItem.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["classification"].IsNullOrEmpty())
            {
                actionItem.Classification = jObject["classification"].ToObject<AnnotationClassificationKind>();
            }

            if (!jObject["closeOutDate"].IsNullOrEmpty())
            {
                actionItem.CloseOutDate = jObject["closeOutDate"].ToObject<DateTime?>();
            }

            if (!jObject["closeOutStatement"].IsNullOrEmpty())
            {
                actionItem.CloseOutStatement = jObject["closeOutStatement"].ToObject<string>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                actionItem.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                actionItem.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["discussion"].IsNullOrEmpty())
            {
                actionItem.Discussion.AddRange(jObject["discussion"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["dueDate"].IsNullOrEmpty())
            {
                actionItem.DueDate = jObject["dueDate"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                actionItem.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                actionItem.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                actionItem.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                actionItem.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                actionItem.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["primaryAnnotatedThing"].IsNullOrEmpty())
            {
                actionItem.PrimaryAnnotatedThing = jObject["primaryAnnotatedThing"].ToObject<Guid?>();
            }

            if (!jObject["relatedThing"].IsNullOrEmpty())
            {
                actionItem.RelatedThing.AddRange(jObject["relatedThing"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                actionItem.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["sourceAnnotation"].IsNullOrEmpty())
            {
                actionItem.SourceAnnotation.AddRange(jObject["sourceAnnotation"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["status"].IsNullOrEmpty())
            {
                actionItem.Status = jObject["status"].ToObject<AnnotationStatusKind>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                actionItem.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["title"].IsNullOrEmpty())
            {
                actionItem.Title = jObject["title"].ToObject<string>();
            }

            return actionItem;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
