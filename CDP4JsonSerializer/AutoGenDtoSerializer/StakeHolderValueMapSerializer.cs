// --------------------------------------------------------------------------------------------------------------------
// <copyright file "StakeHolderValueMapSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="StakeHolderValueMapSerializer"/> class is to provide a <see cref="StakeHolderValueMap"/> specific serializer
    /// </summary>
    public class StakeHolderValueMapSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "goal", goal => new JArray(goal) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "requirement", requirement => new JArray(requirement) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "settings", settings => new JArray(settings) },
            { "shortName", shortName => new JValue(shortName) },
            { "stakeholderValue", stakeholderValue => new JArray(stakeholderValue) },
            { "valueGroup", valueGroup => new JArray(valueGroup) },
        };

        /// <summary>
        /// Serialize the <see cref="StakeHolderValueMap"/>
        /// </summary>
        /// <param name="stakeHolderValueMap">The <see cref="StakeHolderValueMap"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(StakeHolderValueMap stakeHolderValueMap)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](stakeHolderValueMap.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](stakeHolderValueMap.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), stakeHolderValueMap.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](stakeHolderValueMap.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](stakeHolderValueMap.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](stakeHolderValueMap.ExcludedPerson));
            jsonObject.Add("goal", this.PropertySerializerMap["goal"](stakeHolderValueMap.Goal));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](stakeHolderValueMap.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](stakeHolderValueMap.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](stakeHolderValueMap.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](stakeHolderValueMap.Name));
            jsonObject.Add("requirement", this.PropertySerializerMap["requirement"](stakeHolderValueMap.Requirement));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](stakeHolderValueMap.RevisionNumber));
            jsonObject.Add("settings", this.PropertySerializerMap["settings"](stakeHolderValueMap.Settings));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](stakeHolderValueMap.ShortName));
            jsonObject.Add("stakeholderValue", this.PropertySerializerMap["stakeholderValue"](stakeHolderValueMap.StakeholderValue));
            jsonObject.Add("valueGroup", this.PropertySerializerMap["valueGroup"](stakeHolderValueMap.ValueGroup));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="StakeHolderValueMap"/> class.
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

            var stakeHolderValueMap = thing as StakeHolderValueMap;
            if (stakeHolderValueMap == null)
            {
                throw new InvalidOperationException("The thing is not a StakeHolderValueMap.");
            }

            return this.Serialize(stakeHolderValueMap);
        }
    }
}
