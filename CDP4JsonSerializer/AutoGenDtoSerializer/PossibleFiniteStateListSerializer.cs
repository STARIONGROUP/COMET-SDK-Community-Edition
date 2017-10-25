// --------------------------------------------------------------------------------------------------------------------
// <copyright file "PossibleFiniteStateListSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PossibleFiniteStateListSerializer"/> class is to provide a <see cref="PossibleFiniteStateList"/> specific serializer
    /// </summary>
    public class PossibleFiniteStateListSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "defaultState", defaultState => new JValue(defaultState) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "possibleState", possibleState => new JArray(((IEnumerable)possibleState).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="PossibleFiniteStateList"/>
        /// </summary>
        /// <param name="possibleFiniteStateList">The <see cref="PossibleFiniteStateList"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(PossibleFiniteStateList possibleFiniteStateList)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](possibleFiniteStateList.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](possibleFiniteStateList.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), possibleFiniteStateList.ClassKind)));
            jsonObject.Add("defaultState", this.PropertySerializerMap["defaultState"](possibleFiniteStateList.DefaultState));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](possibleFiniteStateList.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](possibleFiniteStateList.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](possibleFiniteStateList.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](possibleFiniteStateList.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](possibleFiniteStateList.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](possibleFiniteStateList.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](possibleFiniteStateList.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](possibleFiniteStateList.Owner));
            jsonObject.Add("possibleState", this.PropertySerializerMap["possibleState"](possibleFiniteStateList.PossibleState));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](possibleFiniteStateList.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](possibleFiniteStateList.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="PossibleFiniteStateList"/> class.
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

            var possibleFiniteStateList = thing as PossibleFiniteStateList;
            if (possibleFiniteStateList == null)
            {
                throw new InvalidOperationException("The thing is not a PossibleFiniteStateList.");
            }

            return this.Serialize(possibleFiniteStateList);
        }
    }
}
