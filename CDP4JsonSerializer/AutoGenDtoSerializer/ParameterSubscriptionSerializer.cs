// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterSubscriptionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterSubscriptionSerializer"/> class is to provide a <see cref="ParameterSubscription"/> specific serializer
    /// </summary>
    public class ParameterSubscriptionSerializer : IThingSerializer
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
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "valueSet", valueSet => new JArray(valueSet) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterSubscription"/>
        /// </summary>
        /// <param name="parameterSubscription">The <see cref="ParameterSubscription"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterSubscription parameterSubscription)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterSubscription.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterSubscription.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterSubscription.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterSubscription.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterSubscription.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](parameterSubscription.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterSubscription.RevisionNumber));
            jsonObject.Add("valueSet", this.PropertySerializerMap["valueSet"](parameterSubscription.ValueSet));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterSubscription"/> class.
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

            var parameterSubscription = thing as ParameterSubscription;
            if (parameterSubscription == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterSubscription.");
            }

            return this.Serialize(parameterSubscription);
        }
    }
}
