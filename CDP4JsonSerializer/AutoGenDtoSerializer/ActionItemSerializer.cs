// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ActionItemSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActionItemSerializer"/> class is to provide a <see cref="ActionItem"/> specific serializer
    /// </summary>
    public class ActionItemSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actionee", actionee => new JValue(actionee) },
            { "approvedBy", approvedBy => new JArray(approvedBy) },
            { "author", author => new JValue(author) },
            { "category", category => new JArray(category) },
            { "classification", classification => new JValue(classification.ToString()) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "closeOutDate", closeOutDate => new JValue(closeOutDate != null ? ((DateTime)closeOutDate).ToString("yyyy-MM-ddTHH:mm:ss.fffZ") : null) },
            { "closeOutStatement", closeOutStatement => new JValue(closeOutStatement) },
            { "content", content => new JValue(content) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "discussion", discussion => new JArray(discussion) },
            { "dueDate", dueDate => new JValue(((DateTime)dueDate).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
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
        /// Serialize the <see cref="ActionItem"/>
        /// </summary>
        /// <param name="actionItem">The <see cref="ActionItem"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ActionItem actionItem)
        {
            var jsonObject = new JObject();
            jsonObject.Add("actionee", this.PropertySerializerMap["actionee"](actionItem.Actionee));
            jsonObject.Add("approvedBy", this.PropertySerializerMap["approvedBy"](actionItem.ApprovedBy));
            jsonObject.Add("author", this.PropertySerializerMap["author"](actionItem.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](actionItem.Category));
            jsonObject.Add("classification", this.PropertySerializerMap["classification"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), actionItem.Classification)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), actionItem.ClassKind)));
            jsonObject.Add("closeOutDate", this.PropertySerializerMap["closeOutDate"](actionItem.CloseOutDate));
            jsonObject.Add("closeOutStatement", this.PropertySerializerMap["closeOutStatement"](actionItem.CloseOutStatement));
            jsonObject.Add("content", this.PropertySerializerMap["content"](actionItem.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](actionItem.CreatedOn));
            jsonObject.Add("discussion", this.PropertySerializerMap["discussion"](actionItem.Discussion));
            jsonObject.Add("dueDate", this.PropertySerializerMap["dueDate"](actionItem.DueDate));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](actionItem.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](actionItem.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](actionItem.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](actionItem.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](actionItem.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](actionItem.Owner));
            jsonObject.Add("primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](actionItem.PrimaryAnnotatedThing));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](actionItem.RelatedThing));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](actionItem.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](actionItem.ShortName));
            jsonObject.Add("sourceAnnotation", this.PropertySerializerMap["sourceAnnotation"](actionItem.SourceAnnotation));
            jsonObject.Add("status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.ReportingData.AnnotationStatusKind), actionItem.Status)));
            jsonObject.Add("title", this.PropertySerializerMap["title"](actionItem.Title));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ActionItem"/> class.
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

            var actionItem = thing as ActionItem;
            if (actionItem == null)
            {
                throw new InvalidOperationException("The thing is not a ActionItem.");
            }

            return this.Serialize(actionItem);
        }
    }
}
