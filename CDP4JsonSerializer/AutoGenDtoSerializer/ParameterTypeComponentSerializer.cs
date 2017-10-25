// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterTypeComponentSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterTypeComponentSerializer"/> class is to provide a <see cref="ParameterTypeComponent"/> specific serializer
    /// </summary>
    public class ParameterTypeComponentSerializer : IThingSerializer
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
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterTypeComponent"/>
        /// </summary>
        /// <param name="parameterTypeComponent">The <see cref="ParameterTypeComponent"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterTypeComponent parameterTypeComponent)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterTypeComponent.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterTypeComponent.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterTypeComponent.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterTypeComponent.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterTypeComponent.ModifiedOn));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](parameterTypeComponent.ParameterType));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterTypeComponent.RevisionNumber));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](parameterTypeComponent.Scale));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](parameterTypeComponent.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterTypeComponent"/> class.
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

            var parameterTypeComponent = thing as ParameterTypeComponent;
            if (parameterTypeComponent == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterTypeComponent.");
            }

            return this.Serialize(parameterTypeComponent);
        }
    }
}
