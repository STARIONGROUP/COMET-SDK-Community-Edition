// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteDirectoryDataAnnotationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryDataAnnotationSerializer"/> class is to provide a <see cref="SiteDirectoryDataAnnotation"/> specific serializer
    /// </summary>
    public class SiteDirectoryDataAnnotationSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "author", author => new JValue(author) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "discussion", discussion => new JArray(discussion) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "primaryAnnotatedThing", primaryAnnotatedThing => new JValue(primaryAnnotatedThing) },
            { "relatedThing", relatedThing => new JArray(relatedThing) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="SiteDirectoryDataAnnotation"/>
        /// </summary>
        /// <param name="siteDirectoryDataAnnotation">The <see cref="SiteDirectoryDataAnnotation"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SiteDirectoryDataAnnotation siteDirectoryDataAnnotation)
        {
            var jsonObject = new JObject();
            jsonObject.Add("author", this.PropertySerializerMap["author"](siteDirectoryDataAnnotation.Author));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteDirectoryDataAnnotation.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](siteDirectoryDataAnnotation.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](siteDirectoryDataAnnotation.CreatedOn));
            jsonObject.Add("discussion", this.PropertySerializerMap["discussion"](siteDirectoryDataAnnotation.Discussion));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteDirectoryDataAnnotation.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteDirectoryDataAnnotation.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteDirectoryDataAnnotation.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](siteDirectoryDataAnnotation.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteDirectoryDataAnnotation.ModifiedOn));
            jsonObject.Add("primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](siteDirectoryDataAnnotation.PrimaryAnnotatedThing));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](siteDirectoryDataAnnotation.RelatedThing));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteDirectoryDataAnnotation.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteDirectoryDataAnnotation"/> class.
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

            var siteDirectoryDataAnnotation = thing as SiteDirectoryDataAnnotation;
            if (siteDirectoryDataAnnotation == null)
            {
                throw new InvalidOperationException("The thing is not a SiteDirectoryDataAnnotation.");
            }

            return this.Serialize(siteDirectoryDataAnnotation);
        }
    }
}
