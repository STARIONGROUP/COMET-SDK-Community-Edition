// --------------------------------------------------------------------------------------------------------------------
// <copyright file "StakeHolderValueMapSettingsSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="StakeHolderValueMapSettingsSerializer"/> class is to provide a <see cref="StakeHolderValueMapSettings"/> specific serializer
    /// </summary>
    public class StakeHolderValueMapSettingsSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "goalToValueGroupRelationship", goalToValueGroupRelationship => new JValue(goalToValueGroupRelationship) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "stakeholderValueToRequirementRelationship", stakeholderValueToRequirementRelationship => new JValue(stakeholderValueToRequirementRelationship) },
            { "valueGroupToStakeholderValueRelationship", valueGroupToStakeholderValueRelationship => new JValue(valueGroupToStakeholderValueRelationship) },
        };

        /// <summary>
        /// Serialize the <see cref="StakeHolderValueMapSettings"/>
        /// </summary>
        /// <param name="stakeHolderValueMapSettings">The <see cref="StakeHolderValueMapSettings"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(StakeHolderValueMapSettings stakeHolderValueMapSettings)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), stakeHolderValueMapSettings.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](stakeHolderValueMapSettings.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](stakeHolderValueMapSettings.ExcludedPerson));
            jsonObject.Add("goalToValueGroupRelationship", this.PropertySerializerMap["goalToValueGroupRelationship"](stakeHolderValueMapSettings.GoalToValueGroupRelationship));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](stakeHolderValueMapSettings.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](stakeHolderValueMapSettings.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](stakeHolderValueMapSettings.RevisionNumber));
            jsonObject.Add("stakeholderValueToRequirementRelationship", this.PropertySerializerMap["stakeholderValueToRequirementRelationship"](stakeHolderValueMapSettings.StakeholderValueToRequirementRelationship));
            jsonObject.Add("valueGroupToStakeholderValueRelationship", this.PropertySerializerMap["valueGroupToStakeholderValueRelationship"](stakeHolderValueMapSettings.ValueGroupToStakeholderValueRelationship));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="StakeHolderValueMapSettings"/> class.
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

            var stakeHolderValueMapSettings = thing as StakeHolderValueMapSettings;
            if (stakeHolderValueMapSettings == null)
            {
                throw new InvalidOperationException("The thing is not a StakeHolderValueMapSettings.");
            }

            return this.Serialize(stakeHolderValueMapSettings);
        }
    }
}
