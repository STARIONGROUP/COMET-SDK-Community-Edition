// --------------------------------------------------------------------------------------------------------------------
// <copyright file "FileRevisionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FileRevisionSerializer"/> class is to provide a <see cref="FileRevision"/> specific serializer
    /// </summary>
    public class FileRevisionSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "containingFolder", containingFolder => new JValue(containingFolder) },
            { "contentHash", contentHash => new JValue(contentHash) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "creator", creator => new JValue(creator) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "fileType", fileType => new JArray(((IEnumerable)fileType).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="FileRevision"/>
        /// </summary>
        /// <param name="fileRevision">The <see cref="FileRevision"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(FileRevision fileRevision)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), fileRevision.ClassKind)));
            jsonObject.Add("containingFolder", this.PropertySerializerMap["containingFolder"](fileRevision.ContainingFolder));
            jsonObject.Add("contentHash", this.PropertySerializerMap["contentHash"](fileRevision.ContentHash));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](fileRevision.CreatedOn));
            jsonObject.Add("creator", this.PropertySerializerMap["creator"](fileRevision.Creator));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](fileRevision.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](fileRevision.ExcludedPerson));
            jsonObject.Add("fileType", this.PropertySerializerMap["fileType"](fileRevision.FileType));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](fileRevision.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](fileRevision.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](fileRevision.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](fileRevision.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="FileRevision"/> class.
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

            var fileRevision = thing as FileRevision;
            if (fileRevision == null)
            {
                throw new InvalidOperationException("The thing is not a FileRevision.");
            }

            return this.Serialize(fileRevision);
        }
    }
}
