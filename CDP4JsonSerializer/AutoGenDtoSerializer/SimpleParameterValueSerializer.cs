// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SimpleParameterValueSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SimpleParameterValueSerializer"/> class is to provide a <see cref="SimpleParameterValue"/> specific serializer
    /// </summary>
    public class SimpleParameterValueSerializer : IThingSerializer
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
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "parameterType", parameterType => new JValue(parameterType) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "scale", scale => new JValue(scale) },
            { "value", value => new JValue(((ValueArray<string>)value).ToJsonString()) },
        };

        /// <summary>
        /// Serialize the <see cref="SimpleParameterValue"/>
        /// </summary>
        /// <param name="simpleParameterValue">The <see cref="SimpleParameterValue"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SimpleParameterValue simpleParameterValue)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), simpleParameterValue.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](simpleParameterValue.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](simpleParameterValue.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](simpleParameterValue.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](simpleParameterValue.ModifiedOn));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](simpleParameterValue.ParameterType));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](simpleParameterValue.RevisionNumber));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](simpleParameterValue.Scale));
            jsonObject.Add("value", this.PropertySerializerMap["value"](simpleParameterValue.Value));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SimpleParameterValue"/> class.
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

            var simpleParameterValue = thing as SimpleParameterValue;
            if (simpleParameterValue == null)
            {
                throw new InvalidOperationException("The thing is not a SimpleParameterValue.");
            }

            return this.Serialize(simpleParameterValue);
        }
    }
}
