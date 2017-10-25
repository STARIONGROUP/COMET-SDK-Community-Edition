// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RequirementsSpecificationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequirementsSpecificationSerializer"/> class is to provide a <see cref="RequirementsSpecification"/> specific serializer
    /// </summary>
    public class RequirementsSpecificationSerializer : IThingSerializer
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
            { "group", group => new JArray(group) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "parameterValue", parameterValue => new JArray(parameterValue) },
            { "requirement", requirement => new JArray(requirement) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="RequirementsSpecification"/>
        /// </summary>
        /// <param name="requirementsSpecification">The <see cref="RequirementsSpecification"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RequirementsSpecification requirementsSpecification)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](requirementsSpecification.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](requirementsSpecification.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), requirementsSpecification.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](requirementsSpecification.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](requirementsSpecification.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](requirementsSpecification.ExcludedPerson));
            jsonObject.Add("group", this.PropertySerializerMap["group"](requirementsSpecification.Group));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](requirementsSpecification.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](requirementsSpecification.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](requirementsSpecification.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](requirementsSpecification.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](requirementsSpecification.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](requirementsSpecification.Owner));
            jsonObject.Add("parameterValue", this.PropertySerializerMap["parameterValue"](requirementsSpecification.ParameterValue));
            jsonObject.Add("requirement", this.PropertySerializerMap["requirement"](requirementsSpecification.Requirement));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](requirementsSpecification.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](requirementsSpecification.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RequirementsSpecification"/> class.
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

            var requirementsSpecification = thing as RequirementsSpecification;
            if (requirementsSpecification == null)
            {
                throw new InvalidOperationException("The thing is not a RequirementsSpecification.");
            }

            return this.Serialize(requirementsSpecification);
        }
    }
}
