// --------------------------------------------------------------------------------------------------------------------
// <copyright file "StakeholderValueSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="StakeholderValueSerializer"/> class is to provide a <see cref="StakeholderValue"/> specific serializer
    /// </summary>
    public class StakeholderValueSerializer : IThingSerializer
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
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="StakeholderValue"/>
        /// </summary>
        /// <param name="stakeholderValue">The <see cref="StakeholderValue"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(StakeholderValue stakeholderValue)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](stakeholderValue.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](stakeholderValue.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), stakeholderValue.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](stakeholderValue.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](stakeholderValue.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](stakeholderValue.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](stakeholderValue.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](stakeholderValue.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](stakeholderValue.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](stakeholderValue.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](stakeholderValue.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](stakeholderValue.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="StakeholderValue"/> class.
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

            var stakeholderValue = thing as StakeholderValue;
            if (stakeholderValue == null)
            {
                throw new InvalidOperationException("The thing is not a StakeholderValue.");
            }

            return this.Serialize(stakeholderValue);
        }
    }
}
