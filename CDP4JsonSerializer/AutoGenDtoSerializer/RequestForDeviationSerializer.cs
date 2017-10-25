// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RequestForDeviationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequestForDeviationSerializer"/> class is to provide a <see cref="RequestForDeviation"/> specific serializer
    /// </summary>
    public class RequestForDeviationSerializer : IThingSerializer
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
        /// Serialize the <see cref="RequestForDeviation"/>
        /// </summary>
        /// <param name="requestForDeviation">The <see cref="RequestForDeviation"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RequestForDeviation requestForDeviation)
        {
            var jsonObject = new JObject();
            jsonObject.Add("approvedBy", this.PropertySerializerMap["approvedBy"](requestForDeviation.ApprovedBy));
            jsonObject.Add("author", this.PropertySerializerMap["author"](requestForDeviation.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](requestForDeviation.Category));
            jsonObject.Add("classification", this.PropertySerializerMap["classification"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), requestForDeviation.Classification)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), requestForDeviation.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](requestForDeviation.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](requestForDeviation.CreatedOn));
            jsonObject.Add("discussion", this.PropertySerializerMap["discussion"](requestForDeviation.Discussion));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](requestForDeviation.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](requestForDeviation.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](requestForDeviation.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](requestForDeviation.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](requestForDeviation.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](requestForDeviation.Owner));
            jsonObject.Add("primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](requestForDeviation.PrimaryAnnotatedThing));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](requestForDeviation.RelatedThing));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](requestForDeviation.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](requestForDeviation.ShortName));
            jsonObject.Add("sourceAnnotation", this.PropertySerializerMap["sourceAnnotation"](requestForDeviation.SourceAnnotation));
            jsonObject.Add("status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationStatusKind), requestForDeviation.Status)));
            jsonObject.Add("title", this.PropertySerializerMap["title"](requestForDeviation.Title));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RequestForDeviation"/> class.
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

            var requestForDeviation = thing as RequestForDeviation;
            if (requestForDeviation == null)
            {
                throw new InvalidOperationException("The thing is not a RequestForDeviation.");
            }

            return this.Serialize(requestForDeviation);
        }
    }
}
