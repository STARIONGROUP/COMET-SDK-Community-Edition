// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DomainFileStoreSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DomainFileStoreSerializer"/> class is to provide a <see cref="DomainFileStore"/> specific serializer
    /// </summary>
    public class DomainFileStoreSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "file", file => new JArray(file) },
            { "folder", folder => new JArray(folder) },
            { "iid", iid => new JValue(iid) },
            { "isHidden", isHidden => new JValue(isHidden) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="DomainFileStore"/>
        /// </summary>
        /// <param name="domainFileStore">The <see cref="DomainFileStore"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DomainFileStore domainFileStore)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), domainFileStore.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](domainFileStore.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](domainFileStore.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](domainFileStore.ExcludedPerson));
            jsonObject.Add("file", this.PropertySerializerMap["file"](domainFileStore.File));
            jsonObject.Add("folder", this.PropertySerializerMap["folder"](domainFileStore.Folder));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](domainFileStore.Iid));
            jsonObject.Add("isHidden", this.PropertySerializerMap["isHidden"](domainFileStore.IsHidden));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](domainFileStore.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](domainFileStore.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](domainFileStore.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](domainFileStore.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DomainFileStore"/> class.
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

            var domainFileStore = thing as DomainFileStore;
            if (domainFileStore == null)
            {
                throw new InvalidOperationException("The thing is not a DomainFileStore.");
            }

            return this.Serialize(domainFileStore);
        }
    }
}
