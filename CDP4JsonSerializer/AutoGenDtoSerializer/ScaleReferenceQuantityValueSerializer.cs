// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ScaleReferenceQuantityValueSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ScaleReferenceQuantityValueSerializer"/> class is to provide a <see cref="ScaleReferenceQuantityValue"/> specific serializer
    /// </summary>
    public class ScaleReferenceQuantityValueSerializer : IThingSerializer
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
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "scale", scale => new JValue(scale) },
            { "value", value => new JValue(value) },
        };

        /// <summary>
        /// Serialize the <see cref="ScaleReferenceQuantityValue"/>
        /// </summary>
        /// <param name="scaleReferenceQuantityValue">The <see cref="ScaleReferenceQuantityValue"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ScaleReferenceQuantityValue scaleReferenceQuantityValue)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), scaleReferenceQuantityValue.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](scaleReferenceQuantityValue.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](scaleReferenceQuantityValue.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](scaleReferenceQuantityValue.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](scaleReferenceQuantityValue.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](scaleReferenceQuantityValue.RevisionNumber));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](scaleReferenceQuantityValue.Scale));
            jsonObject.Add("value", this.PropertySerializerMap["value"](scaleReferenceQuantityValue.Value));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ScaleReferenceQuantityValue"/> class.
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

            var scaleReferenceQuantityValue = thing as ScaleReferenceQuantityValue;
            if (scaleReferenceQuantityValue == null)
            {
                throw new InvalidOperationException("The thing is not a ScaleReferenceQuantityValue.");
            }

            return this.Serialize(scaleReferenceQuantityValue);
        }
    }
}
