// --------------------------------------------------------------------------------------------------------------------
// <copyright file "CitationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CitationSerializer"/> class is to provide a <see cref="Citation"/> specific serializer
    /// </summary>
    public class CitationSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "isAdaptation", isAdaptation => new JValue(isAdaptation) },
            { "location", location => new JValue(location) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "remark", remark => new JValue(remark) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "source", source => new JValue(source) },
        };

        /// <summary>
        /// Serialize the <see cref="Citation"/>
        /// </summary>
        /// <param name="citation">The <see cref="Citation"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Citation citation)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), citation.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](citation.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](citation.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](citation.Iid));
            jsonObject.Add("isAdaptation", this.PropertySerializerMap["isAdaptation"](citation.IsAdaptation));
            jsonObject.Add("location", this.PropertySerializerMap["location"](citation.Location));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](citation.ModifiedOn));
            jsonObject.Add("remark", this.PropertySerializerMap["remark"](citation.Remark));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](citation.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](citation.ShortName));
            jsonObject.Add("source", this.PropertySerializerMap["source"](citation.Source));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Citation"/> class.
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

            var citation = thing as Citation;
            if (citation == null)
            {
                throw new InvalidOperationException("The thing is not a Citation.");
            }

            return this.Serialize(citation);
        }
    }
}
