// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RequirementsGroupSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequirementsGroupSerializer"/> class is to provide a <see cref="RequirementsGroup"/> specific serializer
    /// </summary>
    public class RequirementsGroupSerializer : IThingSerializer
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
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "parameterValue", parameterValue => new JArray(parameterValue) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="RequirementsGroup"/>
        /// </summary>
        /// <param name="requirementsGroup">The <see cref="RequirementsGroup"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RequirementsGroup requirementsGroup)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](requirementsGroup.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](requirementsGroup.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), requirementsGroup.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](requirementsGroup.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](requirementsGroup.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](requirementsGroup.ExcludedPerson));
            jsonObject.Add("group", this.PropertySerializerMap["group"](requirementsGroup.Group));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](requirementsGroup.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](requirementsGroup.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](requirementsGroup.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](requirementsGroup.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](requirementsGroup.Owner));
            jsonObject.Add("parameterValue", this.PropertySerializerMap["parameterValue"](requirementsGroup.ParameterValue));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](requirementsGroup.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](requirementsGroup.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RequirementsGroup"/> class.
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

            var requirementsGroup = thing as RequirementsGroup;
            if (requirementsGroup == null)
            {
                throw new InvalidOperationException("The thing is not a RequirementsGroup.");
            }

            return this.Serialize(requirementsGroup);
        }
    }
}
