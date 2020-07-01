// --------------------------------------------------------------------------------------------------------------------
// <copyright file "IterationSetupSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IterationSetupSerializer"/> class is to provide a <see cref="IterationSetup"/> specific serializer
    /// </summary>
    public class IterationSetupSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "description", description => new JValue(description) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "frozenOn", frozenOn => new JValue(frozenOn != null ? ((DateTime)frozenOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ") : null) },
            { "iid", iid => new JValue(iid) },
            { "isDeleted", isDeleted => new JValue(isDeleted) },
            { "iterationIid", iterationIid => new JValue(iterationIid) },
            { "iterationNumber", iterationNumber => new JValue(iterationNumber) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "sourceIterationSetup", sourceIterationSetup => new JValue(sourceIterationSetup) },
        };

        /// <summary>
        /// Serialize the <see cref="IterationSetup"/>
        /// </summary>
        /// <param name="iterationSetup">The <see cref="IterationSetup"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(IterationSetup iterationSetup)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), iterationSetup.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](iterationSetup.CreatedOn));
            jsonObject.Add("description", this.PropertySerializerMap["description"](iterationSetup.Description));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](iterationSetup.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](iterationSetup.ExcludedPerson));
            jsonObject.Add("frozenOn", this.PropertySerializerMap["frozenOn"](iterationSetup.FrozenOn));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](iterationSetup.Iid));
            jsonObject.Add("isDeleted", this.PropertySerializerMap["isDeleted"](iterationSetup.IsDeleted));
            jsonObject.Add("iterationIid", this.PropertySerializerMap["iterationIid"](iterationSetup.IterationIid));
            jsonObject.Add("iterationNumber", this.PropertySerializerMap["iterationNumber"](iterationSetup.IterationNumber));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](iterationSetup.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](iterationSetup.RevisionNumber));
            jsonObject.Add("sourceIterationSetup", this.PropertySerializerMap["sourceIterationSetup"](iterationSetup.SourceIterationSetup));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="IterationSetup"/> class.
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

            var iterationSetup = thing as IterationSetup;
            if (iterationSetup == null)
            {
                throw new InvalidOperationException("The thing is not a IterationSetup.");
            }

            return this.Serialize(iterationSetup);
        }
    }
}
