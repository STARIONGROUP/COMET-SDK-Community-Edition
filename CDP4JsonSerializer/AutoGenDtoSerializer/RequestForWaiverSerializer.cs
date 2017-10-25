// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RequestForWaiverSerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Serializer class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    /// The purpose of the <see cref="RequestForWaiverSerializer"/> class is to provide a <see cref="RequestForWaiver"/> specific serializer
    /// </summary>
    public class RequestForWaiverSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "approvedBy", approvedBy => new JArray(approvedBy) },
            { "author", author => new JValue(author) },
            { "category", category => new JArray(category) },
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
        /// Serialize the <see cref="RequestForWaiver"/>
        /// </summary>
        /// <param name="requestForWaiver">The <see cref="RequestForWaiver"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RequestForWaiver requestForWaiver)
        {
            var jsonObject = new JObject();
            jsonObject.Add("approvedBy", this.PropertySerializerMap["approvedBy"](requestForWaiver.ApprovedBy));
            jsonObject.Add("author", this.PropertySerializerMap["author"](requestForWaiver.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](requestForWaiver.Category));
            jsonObject.Add("classification", this.PropertySerializerMap["classification"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), requestForWaiver.Classification)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), requestForWaiver.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](requestForWaiver.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](requestForWaiver.CreatedOn));
            jsonObject.Add("discussion", this.PropertySerializerMap["discussion"](requestForWaiver.Discussion));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](requestForWaiver.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](requestForWaiver.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](requestForWaiver.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](requestForWaiver.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](requestForWaiver.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](requestForWaiver.Owner));
            jsonObject.Add("primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](requestForWaiver.PrimaryAnnotatedThing));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](requestForWaiver.RelatedThing));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](requestForWaiver.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](requestForWaiver.ShortName));
            jsonObject.Add("sourceAnnotation", this.PropertySerializerMap["sourceAnnotation"](requestForWaiver.SourceAnnotation));
            jsonObject.Add("status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationStatusKind), requestForWaiver.Status)));
            jsonObject.Add("title", this.PropertySerializerMap["title"](requestForWaiver.Title));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RequestForWaiver"/> class.
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

            var requestForWaiver = thing as RequestForWaiver;
            if (requestForWaiver == null)
            {
                throw new InvalidOperationException("The thing is not a RequestForWaiver.");
            }

            return this.Serialize(requestForWaiver);
        }
    }
}
