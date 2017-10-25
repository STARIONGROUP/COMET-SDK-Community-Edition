// --------------------------------------------------------------------------------------------------------------------
// <copyright file "BuiltInRuleVerificationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BuiltInRuleVerificationSerializer"/> class is to provide a <see cref="BuiltInRuleVerification"/> specific serializer
    /// </summary>
    public class BuiltInRuleVerificationSerializer : IThingSerializer
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
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "status", status => new JValue(status.ToString()) },
            { "violation", violation => new JArray(violation) },
        };

        /// <summary>
        /// Serialize the <see cref="BuiltInRuleVerification"/>
        /// </summary>
        /// <param name="builtInRuleVerification">The <see cref="BuiltInRuleVerification"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(BuiltInRuleVerification builtInRuleVerification)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), builtInRuleVerification.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](builtInRuleVerification.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](builtInRuleVerification.ExcludedPerson));
            jsonObject.Add("executedOn", this.PropertySerializerMap["executedOn"](builtInRuleVerification.ExecutedOn));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](builtInRuleVerification.Iid));
            jsonObject.Add("isActive", this.PropertySerializerMap["isActive"](builtInRuleVerification.IsActive));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](builtInRuleVerification.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](builtInRuleVerification.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](builtInRuleVerification.RevisionNumber));
            jsonObject.Add("status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.RuleVerificationStatusKind), builtInRuleVerification.Status)));
            jsonObject.Add("violation", this.PropertySerializerMap["violation"](builtInRuleVerification.Violation));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="BuiltInRuleVerification"/> class.
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

            var builtInRuleVerification = thing as BuiltInRuleVerification;
            if (builtInRuleVerification == null)
            {
                throw new InvalidOperationException("The thing is not a BuiltInRuleVerification.");
            }

            return this.Serialize(builtInRuleVerification);
        }
    }
}
