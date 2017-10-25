// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterizedCategoryRuleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterizedCategoryRuleSerializer"/> class is to provide a <see cref="ParameterizedCategoryRule"/> specific serializer
    /// </summary>
    public class ParameterizedCategoryRuleSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JValue(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "parameterType", parameterType => new JArray(parameterType) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterizedCategoryRule"/>
        /// </summary>
        /// <param name="parameterizedCategoryRule">The <see cref="ParameterizedCategoryRule"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterizedCategoryRule parameterizedCategoryRule)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](parameterizedCategoryRule.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](parameterizedCategoryRule.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterizedCategoryRule.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](parameterizedCategoryRule.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterizedCategoryRule.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterizedCategoryRule.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](parameterizedCategoryRule.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterizedCategoryRule.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](parameterizedCategoryRule.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterizedCategoryRule.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](parameterizedCategoryRule.Name));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](parameterizedCategoryRule.ParameterType));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterizedCategoryRule.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](parameterizedCategoryRule.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterizedCategoryRule"/> class.
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

            var parameterizedCategoryRule = thing as ParameterizedCategoryRule;
            if (parameterizedCategoryRule == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterizedCategoryRule.");
            }

            return this.Serialize(parameterizedCategoryRule);
        }
    }
}
