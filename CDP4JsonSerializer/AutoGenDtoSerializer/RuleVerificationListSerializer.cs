// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RuleVerificationListSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RuleVerificationListSerializer"/> class is to provide a <see cref="RuleVerificationList"/> specific serializer
    /// </summary>
    public class RuleVerificationListSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "ruleVerification", ruleVerification => new JArray(((IEnumerable)ruleVerification).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="RuleVerificationList"/>
        /// </summary>
        /// <param name="ruleVerificationList">The <see cref="RuleVerificationList"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RuleVerificationList ruleVerificationList)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](ruleVerificationList.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), ruleVerificationList.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](ruleVerificationList.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](ruleVerificationList.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](ruleVerificationList.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](ruleVerificationList.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](ruleVerificationList.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](ruleVerificationList.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](ruleVerificationList.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](ruleVerificationList.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](ruleVerificationList.RevisionNumber));
            jsonObject.Add("ruleVerification", this.PropertySerializerMap["ruleVerification"](ruleVerificationList.RuleVerification));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](ruleVerificationList.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RuleVerificationList"/> class.
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

            var ruleVerificationList = thing as RuleVerificationList;
            if (ruleVerificationList == null)
            {
                throw new InvalidOperationException("The thing is not a RuleVerificationList.");
            }

            return this.Serialize(ruleVerificationList);
        }
    }
}
