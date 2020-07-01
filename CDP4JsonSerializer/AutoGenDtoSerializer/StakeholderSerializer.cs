// --------------------------------------------------------------------------------------------------------------------
// <copyright file "StakeholderSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="StakeholderSerializer"/> class is to provide a <see cref="Stakeholder"/> specific serializer
    /// </summary>
    public class StakeholderSerializer : IThingSerializer
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
            { "stakeholderValue", stakeholderValue => new JArray(stakeholderValue) },
        };

        /// <summary>
        /// Serialize the <see cref="Stakeholder"/>
        /// </summary>
        /// <param name="stakeholder">The <see cref="Stakeholder"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Stakeholder stakeholder)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](stakeholder.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](stakeholder.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), stakeholder.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](stakeholder.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](stakeholder.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](stakeholder.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](stakeholder.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](stakeholder.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](stakeholder.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](stakeholder.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](stakeholder.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](stakeholder.ShortName));
            jsonObject.Add("stakeholderValue", this.PropertySerializerMap["stakeholderValue"](stakeholder.StakeholderValue));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Stakeholder"/> class.
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

            var stakeholder = thing as Stakeholder;
            if (stakeholder == null)
            {
                throw new InvalidOperationException("The thing is not a Stakeholder.");
            }

            return this.Serialize(stakeholder);
        }
    }
}
