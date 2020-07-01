// --------------------------------------------------------------------------------------------------------------------
// <copyright file "EngineeringModelSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelSerializer"/> class is to provide a <see cref="EngineeringModel"/> specific serializer
    /// </summary>
    public class EngineeringModelSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "book", book => new JArray(((IEnumerable)book).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "commonFileStore", commonFileStore => new JArray(commonFileStore) },
            { "engineeringModelSetup", engineeringModelSetup => new JValue(engineeringModelSetup) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "genericNote", genericNote => new JArray(genericNote) },
            { "iid", iid => new JValue(iid) },
            { "iteration", iteration => new JArray(iteration) },
            { "lastModifiedOn", lastModifiedOn => new JValue(((DateTime)lastModifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "logEntry", logEntry => new JArray(logEntry) },
            { "modellingAnnotation", modellingAnnotation => new JArray(modellingAnnotation) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="EngineeringModel"/>
        /// </summary>
        /// <param name="engineeringModel">The <see cref="EngineeringModel"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(EngineeringModel engineeringModel)
        {
            var jsonObject = new JObject();
            jsonObject.Add("book", this.PropertySerializerMap["book"](engineeringModel.Book));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), engineeringModel.ClassKind)));
            jsonObject.Add("commonFileStore", this.PropertySerializerMap["commonFileStore"](engineeringModel.CommonFileStore));
            jsonObject.Add("engineeringModelSetup", this.PropertySerializerMap["engineeringModelSetup"](engineeringModel.EngineeringModelSetup));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](engineeringModel.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](engineeringModel.ExcludedPerson));
            jsonObject.Add("genericNote", this.PropertySerializerMap["genericNote"](engineeringModel.GenericNote));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](engineeringModel.Iid));
            jsonObject.Add("iteration", this.PropertySerializerMap["iteration"](engineeringModel.Iteration));
            jsonObject.Add("lastModifiedOn", this.PropertySerializerMap["lastModifiedOn"](engineeringModel.LastModifiedOn));
            jsonObject.Add("logEntry", this.PropertySerializerMap["logEntry"](engineeringModel.LogEntry));
            jsonObject.Add("modellingAnnotation", this.PropertySerializerMap["modellingAnnotation"](engineeringModel.ModellingAnnotation));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](engineeringModel.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](engineeringModel.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="EngineeringModel"/> class.
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

            var engineeringModel = thing as EngineeringModel;
            if (engineeringModel == null)
            {
                throw new InvalidOperationException("The thing is not a EngineeringModel.");
            }

            return this.Serialize(engineeringModel);
        }
    }
}
