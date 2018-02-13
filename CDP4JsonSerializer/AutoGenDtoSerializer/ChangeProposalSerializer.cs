#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeProposalSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

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
    /// The purpose of the <see cref="ChangeProposalSerializer"/> class is to provide a <see cref="ChangeProposal"/> specific serializer
    /// </summary>
    public class ChangeProposalSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "approvedBy", approvedBy => new JArray(approvedBy) },
            { "author", author => new JValue(author) },
            { "category", category => new JArray(category) },
            { "changeRequest", changeRequest => new JValue(changeRequest) },
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
            { "title", title => new JValue(title) },
        };

        /// <summary>
        /// Serialize the <see cref="ChangeProposal"/>
        /// </summary>
        /// <param name="changeProposal">The <see cref="ChangeProposal"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ChangeProposal changeProposal)
        {
            var jsonObject = new JObject();
            jsonObject.Add("approvedBy", this.PropertySerializerMap["approvedBy"](changeProposal.ApprovedBy));
            jsonObject.Add("author", this.PropertySerializerMap["author"](changeProposal.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](changeProposal.Category));
            jsonObject.Add("changeRequest", this.PropertySerializerMap["changeRequest"](changeProposal.ChangeRequest));
            jsonObject.Add("classification", this.PropertySerializerMap["classification"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), changeProposal.Classification)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), changeProposal.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](changeProposal.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](changeProposal.CreatedOn));
            jsonObject.Add("discussion", this.PropertySerializerMap["discussion"](changeProposal.Discussion));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](changeProposal.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](changeProposal.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](changeProposal.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](changeProposal.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](changeProposal.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](changeProposal.Owner));
            jsonObject.Add("primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](changeProposal.PrimaryAnnotatedThing));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](changeProposal.RelatedThing));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](changeProposal.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](changeProposal.ShortName));
            jsonObject.Add("sourceAnnotation", this.PropertySerializerMap["sourceAnnotation"](changeProposal.SourceAnnotation));
            jsonObject.Add("status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationStatusKind), changeProposal.Status)));
            jsonObject.Add("title", this.PropertySerializerMap["title"](changeProposal.Title));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ChangeProposal"/> class.
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
                throw new ArgumentNullException("thing");
            }

            var changeProposal = thing as ChangeProposal;
            if (changeProposal == null)
            {
                throw new InvalidOperationException("The thing is not a ChangeProposal.");
            }

            return this.Serialize(changeProposal);
        }
    }
}
