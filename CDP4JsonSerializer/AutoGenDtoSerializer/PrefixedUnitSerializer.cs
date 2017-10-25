// --------------------------------------------------------------------------------------------------------------------
// <copyright file "PrefixedUnitSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PrefixedUnitSerializer"/> class is to provide a <see cref="PrefixedUnit"/> specific serializer
    /// </summary>
    public class PrefixedUnitSerializer : IThingSerializer
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
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "prefix", prefix => new JValue(prefix) },
            { "referenceUnit", referenceUnit => new JValue(referenceUnit) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="PrefixedUnit"/>
        /// </summary>
        /// <param name="prefixedUnit">The <see cref="PrefixedUnit"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(PrefixedUnit prefixedUnit)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](prefixedUnit.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), prefixedUnit.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](prefixedUnit.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](prefixedUnit.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](prefixedUnit.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](prefixedUnit.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](prefixedUnit.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](prefixedUnit.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](prefixedUnit.ModifiedOn));
            jsonObject.Add("prefix", this.PropertySerializerMap["prefix"](prefixedUnit.Prefix));
            jsonObject.Add("referenceUnit", this.PropertySerializerMap["referenceUnit"](prefixedUnit.ReferenceUnit));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](prefixedUnit.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="PrefixedUnit"/> class.
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

            var prefixedUnit = thing as PrefixedUnit;
            if (prefixedUnit == null)
            {
                throw new InvalidOperationException("The thing is not a PrefixedUnit.");
            }

            return this.Serialize(prefixedUnit);
        }
    }
}
