// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ContractChangeNoticeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ContractChangeNoticeSerializer"/> class is to provide a <see cref="ContractChangeNotice"/> specific serializer
    /// </summary>
    public class ContractChangeNoticeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            { "approvedBy", approvedBy => JsonValue.Create(approvedBy) },
            { "author", author => JsonValue.Create(author) },
            { "category", category => JsonValue.Create(category) },
            { "changeProposal", changeProposal => JsonValue.Create(changeProposal) },
            { "classification", classification => JsonValue.Create(classification.ToString()) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "content", content => JsonValue.Create(content) },
            { "createdOn", createdOn => JsonValue.Create(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "discussion", discussion => JsonValue.Create(discussion) },
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
        /// Serialize the <see cref="ContractChangeNotice"/>
        /// </summary>
        /// <param name="contractChangeNotice">The <see cref="ContractChangeNotice"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ContractChangeNotice contractChangeNotice)
        {
            var jsonObject = new JsonObject
            {
                {"approvedBy", this.PropertySerializerMap["approvedBy"](contractChangeNotice.ApprovedBy.OrderBy(x => x, this.guidComparer))},
                {"author", this.PropertySerializerMap["author"](contractChangeNotice.Author)},
                {"category", this.PropertySerializerMap["category"](contractChangeNotice.Category.OrderBy(x => x, this.guidComparer))},
                {"changeProposal", this.PropertySerializerMap["changeProposal"](contractChangeNotice.ChangeProposal)},
                {"classification", this.PropertySerializerMap["classification"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), contractChangeNotice.Classification))},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), contractChangeNotice.ClassKind))},
                {"content", this.PropertySerializerMap["content"](contractChangeNotice.Content)},
                {"createdOn", this.PropertySerializerMap["createdOn"](contractChangeNotice.CreatedOn)},
                {"discussion", this.PropertySerializerMap["discussion"](contractChangeNotice.Discussion.OrderBy(x => x, this.guidComparer))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](contractChangeNotice.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](contractChangeNotice.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](contractChangeNotice.Iid)},
                {"languageCode", this.PropertySerializerMap["languageCode"](contractChangeNotice.LanguageCode)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](contractChangeNotice.ModifiedOn)},
                {"owner", this.PropertySerializerMap["owner"](contractChangeNotice.Owner)},
                {"primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](contractChangeNotice.PrimaryAnnotatedThing)},
                {"relatedThing", this.PropertySerializerMap["relatedThing"](contractChangeNotice.RelatedThing.OrderBy(x => x, this.guidComparer))},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](contractChangeNotice.RevisionNumber)},
                {"shortName", this.PropertySerializerMap["shortName"](contractChangeNotice.ShortName)},
                {"sourceAnnotation", this.PropertySerializerMap["sourceAnnotation"](contractChangeNotice.SourceAnnotation.OrderBy(x => x, this.guidComparer))},
                {"status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationStatusKind), contractChangeNotice.Status))},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](contractChangeNotice.ThingPreference)},
                {"title", this.PropertySerializerMap["title"](contractChangeNotice.Title)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ContractChangeNotice"/> class.
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

            if (thing is not ContractChangeNotice contractChangeNotice)
            {
                throw new InvalidOperationException("The thing is not a ContractChangeNotice.");
            }

            return this.Serialize(contractChangeNotice);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
