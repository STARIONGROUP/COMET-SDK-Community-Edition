// --------------------------------------------------------------------------------------------------------------------
// <copyright file "CommonFileStoreSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CommonFileStoreSerializer"/> class is to provide a <see cref="CommonFileStore"/> specific serializer
    /// </summary>
    public class CommonFileStoreSerializer : IThingSerializer
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
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="CommonFileStore"/>
        /// </summary>
        /// <param name="commonFileStore">The <see cref="CommonFileStore"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(CommonFileStore commonFileStore)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), commonFileStore.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](commonFileStore.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](commonFileStore.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](commonFileStore.ExcludedPerson));
            jsonObject.Add("file", this.PropertySerializerMap["file"](commonFileStore.File));
            jsonObject.Add("folder", this.PropertySerializerMap["folder"](commonFileStore.Folder));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](commonFileStore.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](commonFileStore.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](commonFileStore.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](commonFileStore.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](commonFileStore.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="CommonFileStore"/> class.
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

            var commonFileStore = thing as CommonFileStore;
            if (commonFileStore == null)
            {
                throw new InvalidOperationException("The thing is not a CommonFileStore.");
            }

            return this.Serialize(commonFileStore);
        }
    }
}
