// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RequirementSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequirementSerializer"/> class is to provide a <see cref="Requirement"/> specific serializer
    /// </summary>
    public class RequirementSerializer : IThingSerializer
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
            { "group", group => new JValue(group) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "parameterValue", parameterValue => new JArray(parameterValue) },
            { "parametricConstraint", parametricConstraint => new JArray(((IEnumerable)parametricConstraint).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="Requirement"/>
        /// </summary>
        /// <param name="requirement">The <see cref="Requirement"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Requirement requirement)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](requirement.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](requirement.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), requirement.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](requirement.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](requirement.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](requirement.ExcludedPerson));
            jsonObject.Add("group", this.PropertySerializerMap["group"](requirement.Group));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](requirement.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](requirement.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](requirement.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](requirement.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](requirement.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](requirement.Owner));
            jsonObject.Add("parameterValue", this.PropertySerializerMap["parameterValue"](requirement.ParameterValue));
            jsonObject.Add("parametricConstraint", this.PropertySerializerMap["parametricConstraint"](requirement.ParametricConstraint));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](requirement.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](requirement.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Requirement"/> class.
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

            var requirement = thing as Requirement;
            if (requirement == null)
            {
                throw new InvalidOperationException("The thing is not a Requirement.");
            }

            return this.Serialize(requirement);
        }
    }
}
