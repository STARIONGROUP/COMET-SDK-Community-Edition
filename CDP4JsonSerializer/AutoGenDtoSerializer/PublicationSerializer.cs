// --------------------------------------------------------------------------------------------------------------------
// <copyright file "PublicationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PublicationSerializer"/> class is to provide a <see cref="Publication"/> specific serializer
    /// </summary>
    public class PublicationSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "domain", domain => new JArray(domain) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "publishedParameter", publishedParameter => new JArray(publishedParameter) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="Publication"/>
        /// </summary>
        /// <param name="publication">The <see cref="Publication"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Publication publication)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), publication.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](publication.CreatedOn));
            jsonObject.Add("domain", this.PropertySerializerMap["domain"](publication.Domain));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](publication.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](publication.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](publication.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](publication.ModifiedOn));
            jsonObject.Add("publishedParameter", this.PropertySerializerMap["publishedParameter"](publication.PublishedParameter));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](publication.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Publication"/> class.
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

            var publication = thing as Publication;
            if (publication == null)
            {
                throw new InvalidOperationException("The thing is not a Publication.");
            }

            return this.Serialize(publication);
        }
    }
}
