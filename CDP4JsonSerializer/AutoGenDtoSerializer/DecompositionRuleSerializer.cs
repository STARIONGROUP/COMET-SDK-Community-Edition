// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DecompositionRuleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DecompositionRuleSerializer"/> class is to provide a <see cref="DecompositionRule"/> specific serializer
    /// </summary>
    public class DecompositionRuleSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "containedCategory", containedCategory => new JArray(containedCategory) },
            { "containingCategory", containingCategory => new JValue(containingCategory) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "maxContained", maxContained => new JValue(maxContained) },
            { "minContained", minContained => new JValue(minContained) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="DecompositionRule"/>
        /// </summary>
        /// <param name="decompositionRule">The <see cref="DecompositionRule"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DecompositionRule decompositionRule)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](decompositionRule.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), decompositionRule.ClassKind)));
            jsonObject.Add("containedCategory", this.PropertySerializerMap["containedCategory"](decompositionRule.ContainedCategory));
            jsonObject.Add("containingCategory", this.PropertySerializerMap["containingCategory"](decompositionRule.ContainingCategory));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](decompositionRule.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](decompositionRule.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](decompositionRule.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](decompositionRule.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](decompositionRule.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](decompositionRule.IsDeprecated));
            jsonObject.Add("maxContained", this.PropertySerializerMap["maxContained"](decompositionRule.MaxContained));
            jsonObject.Add("minContained", this.PropertySerializerMap["minContained"](decompositionRule.MinContained));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](decompositionRule.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](decompositionRule.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](decompositionRule.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](decompositionRule.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DecompositionRule"/> class.
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

            var decompositionRule = thing as DecompositionRule;
            if (decompositionRule == null)
            {
                throw new InvalidOperationException("The thing is not a DecompositionRule.");
            }

            return this.Serialize(decompositionRule);
        }
    }
}
