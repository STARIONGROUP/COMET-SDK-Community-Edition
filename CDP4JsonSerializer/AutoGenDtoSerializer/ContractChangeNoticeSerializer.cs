// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractChangeNoticeSerializer.cs" company="Starion Group S.A.">
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.DTO;
    using CDP4Common.Types;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="ContractChangeNoticeSerializer"/> class is to provide a <see cref="ContractChangeNotice"/> specific serializer
    /// </summary>
    public class ContractChangeNoticeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "approvedBy", approvedBy => new JArray(approvedBy) },
            { "author", author => new JValue(author) },
            { "category", category => new JArray(category) },
            { "changeProposal", changeProposal => new JValue(changeProposal) },
            { "classification", classification => new JValue(classification.ToString()) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "discussion", discussion => new JArray(discussion) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => new JValue(owner) },
            { "primaryAnnotatedThing", primaryAnnotatedThing => new JValue(primaryAnnotatedThing) },
            { "relatedThing", relatedThing => new JArray(relatedThing) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "sourceAnnotation", sourceAnnotation => new JArray(sourceAnnotation) },
            { "status", status => new JValue(status.ToString()) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "title", title => new JValue(title) },
        };

        /// <summary>
        /// Serialize the <see cref="ContractChangeNotice"/>
        /// </summary>
        /// <param name="contractChangeNotice">The <see cref="ContractChangeNotice"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ContractChangeNotice contractChangeNotice)
        {
            var jsonObject = new JObject();
            jsonObject.Add("approvedBy", this.PropertySerializerMap["approvedBy"](contractChangeNotice.ApprovedBy.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("author", this.PropertySerializerMap["author"](contractChangeNotice.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](contractChangeNotice.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("changeProposal", this.PropertySerializerMap["changeProposal"](contractChangeNotice.ChangeProposal));
            jsonObject.Add("classification", this.PropertySerializerMap["classification"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), contractChangeNotice.Classification)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), contractChangeNotice.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](contractChangeNotice.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](contractChangeNotice.CreatedOn));
            jsonObject.Add("discussion", this.PropertySerializerMap["discussion"](contractChangeNotice.Discussion.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](contractChangeNotice.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](contractChangeNotice.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](contractChangeNotice.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](contractChangeNotice.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](contractChangeNotice.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](contractChangeNotice.Owner));
            jsonObject.Add("primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](contractChangeNotice.PrimaryAnnotatedThing));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](contractChangeNotice.RelatedThing.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](contractChangeNotice.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](contractChangeNotice.ShortName));
            jsonObject.Add("sourceAnnotation", this.PropertySerializerMap["sourceAnnotation"](contractChangeNotice.SourceAnnotation.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationStatusKind), contractChangeNotice.Status)));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](contractChangeNotice.ThingPreference));
            jsonObject.Add("title", this.PropertySerializerMap["title"](contractChangeNotice.Title));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ContractChangeNotice"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JToken>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        public JObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
            }

            var contractChangeNotice = thing as ContractChangeNotice;
            if (contractChangeNotice == null)
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
