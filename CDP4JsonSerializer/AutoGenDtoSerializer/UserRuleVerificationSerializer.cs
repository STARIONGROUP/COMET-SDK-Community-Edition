// --------------------------------------------------------------------------------------------------------------------
// <copyright file "UserRuleVerificationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="UserRuleVerificationSerializer"/> class is to provide a <see cref="UserRuleVerification"/> specific serializer
    /// </summary>
    public class UserRuleVerificationSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "executedOn", executedOn => new JValue(executedOn != null ? ((DateTime)executedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ") : null) },
            { "iid", iid => new JValue(iid) },
            { "isActive", isActive => new JValue(isActive) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "rule", rule => new JValue(rule) },
            { "status", status => new JValue(status.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="UserRuleVerification"/>
        /// </summary>
        /// <param name="userRuleVerification">The <see cref="UserRuleVerification"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(UserRuleVerification userRuleVerification)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), userRuleVerification.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](userRuleVerification.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](userRuleVerification.ExcludedPerson));
            jsonObject.Add("executedOn", this.PropertySerializerMap["executedOn"](userRuleVerification.ExecutedOn));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](userRuleVerification.Iid));
            jsonObject.Add("isActive", this.PropertySerializerMap["isActive"](userRuleVerification.IsActive));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](userRuleVerification.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](userRuleVerification.RevisionNumber));
            jsonObject.Add("rule", this.PropertySerializerMap["rule"](userRuleVerification.Rule));
            jsonObject.Add("status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.RuleVerificationStatusKind), userRuleVerification.Status)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="UserRuleVerification"/> class.
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

            var userRuleVerification = thing as UserRuleVerification;
            if (userRuleVerification == null)
            {
                throw new InvalidOperationException("The thing is not a UserRuleVerification.");
            }

            return this.Serialize(userRuleVerification);
        }
    }
}
