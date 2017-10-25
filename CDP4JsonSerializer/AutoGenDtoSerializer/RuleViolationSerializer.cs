// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RuleViolationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RuleViolationSerializer"/> class is to provide a <see cref="RuleViolation"/> specific serializer
    /// </summary>
    public class RuleViolationSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "description", description => new JValue(description) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "violatingThing", violatingThing => new JArray(violatingThing) },
        };

        /// <summary>
        /// Serialize the <see cref="RuleViolation"/>
        /// </summary>
        /// <param name="ruleViolation">The <see cref="RuleViolation"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RuleViolation ruleViolation)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), ruleViolation.ClassKind)));
            jsonObject.Add("description", this.PropertySerializerMap["description"](ruleViolation.Description));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](ruleViolation.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](ruleViolation.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](ruleViolation.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](ruleViolation.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](ruleViolation.RevisionNumber));
            jsonObject.Add("violatingThing", this.PropertySerializerMap["violatingThing"](ruleViolation.ViolatingThing));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RuleViolation"/> class.
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

            var ruleViolation = thing as RuleViolation;
            if (ruleViolation == null)
            {
                throw new InvalidOperationException("The thing is not a RuleViolation.");
            }

            return this.Serialize(ruleViolation);
        }
    }
}
