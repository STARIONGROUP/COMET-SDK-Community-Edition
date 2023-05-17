// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ActionItemSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski, Jaime Bernar
//
//    This file is part of CDP4-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Nodes;

    using CDP4Common.DTO;
    using CDP4Common.Types;
    
    /// <summary>
    /// The purpose of the <see cref="ActionItemSerializer"/> class is to provide a <see cref="ActionItem"/> specific serializer
    /// </summary>
    public class ActionItemSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            { "actionee", actionee => JsonValue.Create(actionee) },
            { "approvedBy", approvedBy => JsonValue.Create(approvedBy) },
            { "author", author => JsonValue.Create(author) },
            { "category", category => JsonValue.Create(category) },
            { "classification", classification => JsonValue.Create(classification.ToString()) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "closeOutDate", closeOutDate => JsonValue.Create(closeOutDate != null ? ((DateTime)closeOutDate).ToString("yyyy-MM-ddTHH:mm:ss.fffZ") : null) },
            { "closeOutStatement", closeOutStatement => JsonValue.Create(closeOutStatement) },
            { "content", content => JsonValue.Create(content) },
            { "createdOn", createdOn => JsonValue.Create(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "discussion", discussion => JsonValue.Create(discussion) },
            { "dueDate", dueDate => JsonValue.Create(((DateTime)dueDate).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "iid", iid => JsonValue.Create(iid) },
            { "languageCode", languageCode => JsonValue.Create(languageCode) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => JsonValue.Create(owner) },
            { "primaryAnnotatedThing", primaryAnnotatedThing => JsonValue.Create(primaryAnnotatedThing) },
            { "relatedThing", relatedThing => JsonValue.Create(relatedThing) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "sourceAnnotation", sourceAnnotation => JsonValue.Create(sourceAnnotation) },
            { "status", status => JsonValue.Create(status.ToString()) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "title", title => JsonValue.Create(title) },
        };

        /// <summary>
        /// Serialize the <see cref="ActionItem"/>
        /// </summary>
        /// <param name="actionItem">The <see cref="ActionItem"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ActionItem actionItem)
        {
            var jsonObject = new JsonObject
            {
                {"actionee", this.PropertySerializerMap["actionee"](actionItem.Actionee)},
                {"approvedBy", this.PropertySerializerMap["approvedBy"](actionItem.ApprovedBy.OrderBy(x => x, this.guidComparer))},
                {"author", this.PropertySerializerMap["author"](actionItem.Author)},
                {"category", this.PropertySerializerMap["category"](actionItem.Category.OrderBy(x => x, this.guidComparer))},
                {"classification", this.PropertySerializerMap["classification"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), actionItem.Classification))},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), actionItem.ClassKind))},
                {"closeOutDate", this.PropertySerializerMap["closeOutDate"](actionItem.CloseOutDate)},
                {"closeOutStatement", this.PropertySerializerMap["closeOutStatement"](actionItem.CloseOutStatement)},
                {"content", this.PropertySerializerMap["content"](actionItem.Content)},
                {"createdOn", this.PropertySerializerMap["createdOn"](actionItem.CreatedOn)},
                {"discussion", this.PropertySerializerMap["discussion"](actionItem.Discussion.OrderBy(x => x, this.guidComparer))},
                {"dueDate", this.PropertySerializerMap["dueDate"](actionItem.DueDate)},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](actionItem.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](actionItem.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](actionItem.Iid)},
                {"languageCode", this.PropertySerializerMap["languageCode"](actionItem.LanguageCode)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](actionItem.ModifiedOn)},
                {"owner", this.PropertySerializerMap["owner"](actionItem.Owner)},
                {"primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](actionItem.PrimaryAnnotatedThing)},
                {"relatedThing", this.PropertySerializerMap["relatedThing"](actionItem.RelatedThing.OrderBy(x => x, this.guidComparer))},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](actionItem.RevisionNumber)},
                {"shortName", this.PropertySerializerMap["shortName"](actionItem.ShortName)},
                {"sourceAnnotation", this.PropertySerializerMap["sourceAnnotation"](actionItem.SourceAnnotation.OrderBy(x => x, this.guidComparer))},
                {"status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationStatusKind), actionItem.Status))},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](actionItem.ThingPreference)},
                {"title", this.PropertySerializerMap["title"](actionItem.Title)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ActionItem"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JsonValue>> PropertySerializerMap => this.propertySerializerMap;

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        public JsonObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
            }

            if (thing is not ActionItem actionItem)
            {
                throw new InvalidOperationException("The thing is not a ActionItem.");
            }

            return this.Serialize(actionItem);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
