// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DerivedUnitSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DerivedUnitSerializer"/> class is to provide a <see cref="DerivedUnit"/> specific serializer
    /// </summary>
    public class DerivedUnitSerializer : IThingSerializer
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
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "unitFactor", unitFactor => new JArray(((IEnumerable)unitFactor).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
        };

        /// <summary>
        /// Serialize the <see cref="DerivedUnit"/>
        /// </summary>
        /// <param name="derivedUnit">The <see cref="DerivedUnit"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DerivedUnit derivedUnit)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](derivedUnit.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), derivedUnit.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](derivedUnit.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](derivedUnit.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](derivedUnit.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](derivedUnit.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](derivedUnit.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](derivedUnit.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](derivedUnit.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](derivedUnit.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](derivedUnit.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](derivedUnit.ShortName));
            jsonObject.Add("unitFactor", this.PropertySerializerMap["unitFactor"](derivedUnit.UnitFactor));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DerivedUnit"/> class.
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

            var derivedUnit = thing as DerivedUnit;
            if (derivedUnit == null)
            {
                throw new InvalidOperationException("The thing is not a DerivedUnit.");
            }

            return this.Serialize(derivedUnit);
        }
    }
}
