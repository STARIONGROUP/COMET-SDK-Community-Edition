// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterOverrideSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterOverrideSerializer"/> class is to provide a <see cref="ParameterOverride"/> specific serializer
    /// </summary>
    public class ParameterOverrideSerializer : IThingSerializer
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
            { "owner", owner => new JValue(owner) },
            { "parameter", parameter => new JValue(parameter) },
            { "parameterSubscription", parameterSubscription => new JArray(parameterSubscription) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "valueSet", valueSet => new JArray(valueSet) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterOverride"/>
        /// </summary>
        /// <param name="parameterOverride">The <see cref="ParameterOverride"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterOverride parameterOverride)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterOverride.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterOverride.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterOverride.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterOverride.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterOverride.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](parameterOverride.Owner));
            jsonObject.Add("parameter", this.PropertySerializerMap["parameter"](parameterOverride.Parameter));
            jsonObject.Add("parameterSubscription", this.PropertySerializerMap["parameterSubscription"](parameterOverride.ParameterSubscription));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterOverride.RevisionNumber));
            jsonObject.Add("valueSet", this.PropertySerializerMap["valueSet"](parameterOverride.ValueSet));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterOverride"/> class.
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

            var parameterOverride = thing as ParameterOverride;
            if (parameterOverride == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterOverride.");
            }

            return this.Serialize(parameterOverride);
        }
    }
}
