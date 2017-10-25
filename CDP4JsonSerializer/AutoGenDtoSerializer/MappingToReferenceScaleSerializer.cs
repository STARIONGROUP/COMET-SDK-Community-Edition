// --------------------------------------------------------------------------------------------------------------------
// <copyright file "MappingToReferenceScaleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="MappingToReferenceScaleSerializer"/> class is to provide a <see cref="MappingToReferenceScale"/> specific serializer
    /// </summary>
    public class MappingToReferenceScaleSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "dependentScaleValue", dependentScaleValue => new JValue(dependentScaleValue) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "referenceScaleValue", referenceScaleValue => new JValue(referenceScaleValue) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="MappingToReferenceScale"/>
        /// </summary>
        /// <param name="mappingToReferenceScale">The <see cref="MappingToReferenceScale"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(MappingToReferenceScale mappingToReferenceScale)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), mappingToReferenceScale.ClassKind)));
            jsonObject.Add("dependentScaleValue", this.PropertySerializerMap["dependentScaleValue"](mappingToReferenceScale.DependentScaleValue));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](mappingToReferenceScale.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](mappingToReferenceScale.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](mappingToReferenceScale.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](mappingToReferenceScale.ModifiedOn));
            jsonObject.Add("referenceScaleValue", this.PropertySerializerMap["referenceScaleValue"](mappingToReferenceScale.ReferenceScaleValue));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](mappingToReferenceScale.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="MappingToReferenceScale"/> class.
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

            var mappingToReferenceScale = thing as MappingToReferenceScale;
            if (mappingToReferenceScale == null)
            {
                throw new InvalidOperationException("The thing is not a MappingToReferenceScale.");
            }

            return this.Serialize(mappingToReferenceScale);
        }
    }
}
