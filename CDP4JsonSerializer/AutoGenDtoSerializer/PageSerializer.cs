// --------------------------------------------------------------------------------------------------------------------
// <copyright file "PageSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PageSerializer"/> class is to provide a <see cref="Page"/> specific serializer
    /// </summary>
    public class PageSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "note", note => new JArray(((IEnumerable)note).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="Page"/>
        /// </summary>
        /// <param name="page">The <see cref="Page"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Page page)
        {
            var jsonObject = new JObject();
            jsonObject.Add("category", this.PropertySerializerMap["category"](page.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), page.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](page.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](page.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](page.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](page.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](page.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](page.Name));
            jsonObject.Add("note", this.PropertySerializerMap["note"](page.Note));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](page.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](page.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](page.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Page"/> class.
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

            var page = thing as Page;
            if (page == null)
            {
                throw new InvalidOperationException("The thing is not a Page.");
            }

            return this.Serialize(page);
        }
    }
}
