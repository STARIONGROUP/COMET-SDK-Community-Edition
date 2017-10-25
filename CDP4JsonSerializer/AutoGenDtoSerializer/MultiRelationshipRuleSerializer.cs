// --------------------------------------------------------------------------------------------------------------------
// <copyright file "MultiRelationshipRuleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="MultiRelationshipRuleSerializer"/> class is to provide a <see cref="MultiRelationshipRule"/> specific serializer
    /// </summary>
    public class MultiRelationshipRuleSerializer : IThingSerializer
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
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "maxRelated", maxRelated => new JValue(maxRelated) },
            { "minRelated", minRelated => new JValue(minRelated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "relatedCategory", relatedCategory => new JArray(relatedCategory) },
            { "relationshipCategory", relationshipCategory => new JValue(relationshipCategory) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="MultiRelationshipRule"/>
        /// </summary>
        /// <param name="multiRelationshipRule">The <see cref="MultiRelationshipRule"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(MultiRelationshipRule multiRelationshipRule)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](multiRelationshipRule.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), multiRelationshipRule.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](multiRelationshipRule.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](multiRelationshipRule.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](multiRelationshipRule.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](multiRelationshipRule.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](multiRelationshipRule.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](multiRelationshipRule.IsDeprecated));
            jsonObject.Add("maxRelated", this.PropertySerializerMap["maxRelated"](multiRelationshipRule.MaxRelated));
            jsonObject.Add("minRelated", this.PropertySerializerMap["minRelated"](multiRelationshipRule.MinRelated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](multiRelationshipRule.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](multiRelationshipRule.Name));
            jsonObject.Add("relatedCategory", this.PropertySerializerMap["relatedCategory"](multiRelationshipRule.RelatedCategory));
            jsonObject.Add("relationshipCategory", this.PropertySerializerMap["relationshipCategory"](multiRelationshipRule.RelationshipCategory));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](multiRelationshipRule.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](multiRelationshipRule.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="MultiRelationshipRule"/> class.
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

            var multiRelationshipRule = thing as MultiRelationshipRule;
            if (multiRelationshipRule == null)
            {
                throw new InvalidOperationException("The thing is not a MultiRelationshipRule.");
            }

            return this.Serialize(multiRelationshipRule);
        }
    }
}
