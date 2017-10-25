// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DomainOfExpertiseGroupSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DomainOfExpertiseGroupSerializer"/> class is to provide a <see cref="DomainOfExpertiseGroup"/> specific serializer
    /// </summary>
    public class DomainOfExpertiseGroupSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "domain", domain => new JArray(domain) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="DomainOfExpertiseGroup"/>
        /// </summary>
        /// <param name="domainOfExpertiseGroup">The <see cref="DomainOfExpertiseGroup"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DomainOfExpertiseGroup domainOfExpertiseGroup)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](domainOfExpertiseGroup.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), domainOfExpertiseGroup.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](domainOfExpertiseGroup.Definition));
            jsonObject.Add("domain", this.PropertySerializerMap["domain"](domainOfExpertiseGroup.Domain));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](domainOfExpertiseGroup.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](domainOfExpertiseGroup.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](domainOfExpertiseGroup.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](domainOfExpertiseGroup.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](domainOfExpertiseGroup.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](domainOfExpertiseGroup.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](domainOfExpertiseGroup.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](domainOfExpertiseGroup.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](domainOfExpertiseGroup.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DomainOfExpertiseGroup"/> class.
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

            var domainOfExpertiseGroup = thing as DomainOfExpertiseGroup;
            if (domainOfExpertiseGroup == null)
            {
                throw new InvalidOperationException("The thing is not a DomainOfExpertiseGroup.");
            }

            return this.Serialize(domainOfExpertiseGroup);
        }
    }
}
