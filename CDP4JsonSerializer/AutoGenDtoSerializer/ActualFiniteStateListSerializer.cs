// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ActualFiniteStateListSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActualFiniteStateListSerializer"/> class is to provide a <see cref="ActualFiniteStateList"/> specific serializer
    /// </summary>
    public class ActualFiniteStateListSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actualState", actualState => new JArray(actualState) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "excludeOption", excludeOption => new JArray(excludeOption) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => new JValue(owner) },
            { "possibleFiniteStateList", possibleFiniteStateList => new JArray(((IEnumerable)possibleFiniteStateList).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="ActualFiniteStateList"/>
        /// </summary>
        /// <param name="actualFiniteStateList">The <see cref="ActualFiniteStateList"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ActualFiniteStateList actualFiniteStateList)
        {
            var jsonObject = new JObject();
            jsonObject.Add("actualState", this.PropertySerializerMap["actualState"](actualFiniteStateList.ActualState));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), actualFiniteStateList.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](actualFiniteStateList.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](actualFiniteStateList.ExcludedPerson));
            jsonObject.Add("excludeOption", this.PropertySerializerMap["excludeOption"](actualFiniteStateList.ExcludeOption));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](actualFiniteStateList.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](actualFiniteStateList.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](actualFiniteStateList.Owner));
            jsonObject.Add("possibleFiniteStateList", this.PropertySerializerMap["possibleFiniteStateList"](actualFiniteStateList.PossibleFiniteStateList));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](actualFiniteStateList.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ActualFiniteStateList"/> class.
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

            var actualFiniteStateList = thing as ActualFiniteStateList;
            if (actualFiniteStateList == null)
            {
                throw new InvalidOperationException("The thing is not a ActualFiniteStateList.");
            }

            return this.Serialize(actualFiniteStateList);
        }
    }
}
