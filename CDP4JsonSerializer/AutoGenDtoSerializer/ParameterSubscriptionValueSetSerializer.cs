// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterSubscriptionValueSetSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterSubscriptionValueSetSerializer"/> class is to provide a <see cref="ParameterSubscriptionValueSet"/> specific serializer
    /// </summary>
    public class ParameterSubscriptionValueSetSerializer : IThingSerializer
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
            { "manual", manual => new JValue(((ValueArray<string>)manual).ToJsonString()) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "subscribedValueSet", subscribedValueSet => new JValue(subscribedValueSet) },
            { "valueSwitch", valueSwitch => new JValue(valueSwitch.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterSubscriptionValueSet"/>
        /// </summary>
        /// <param name="parameterSubscriptionValueSet">The <see cref="ParameterSubscriptionValueSet"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterSubscriptionValueSet parameterSubscriptionValueSet)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterSubscriptionValueSet.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterSubscriptionValueSet.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterSubscriptionValueSet.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterSubscriptionValueSet.Iid));
            jsonObject.Add("manual", this.PropertySerializerMap["manual"](parameterSubscriptionValueSet.Manual));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterSubscriptionValueSet.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterSubscriptionValueSet.RevisionNumber));
            jsonObject.Add("subscribedValueSet", this.PropertySerializerMap["subscribedValueSet"](parameterSubscriptionValueSet.SubscribedValueSet));
            jsonObject.Add("valueSwitch", this.PropertySerializerMap["valueSwitch"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.ParameterSwitchKind), parameterSubscriptionValueSet.ValueSwitch)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterSubscriptionValueSet"/> class.
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

            var parameterSubscriptionValueSet = thing as ParameterSubscriptionValueSet;
            if (parameterSubscriptionValueSet == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterSubscriptionValueSet.");
            }

            return this.Serialize(parameterSubscriptionValueSet);
        }
    }
}
