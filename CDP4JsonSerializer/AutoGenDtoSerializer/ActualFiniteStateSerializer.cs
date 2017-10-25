// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ActualFiniteStateSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActualFiniteStateSerializer"/> class is to provide a <see cref="ActualFiniteState"/> specific serializer
    /// </summary>
    public class ActualFiniteStateSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "kind", kind => new JValue(kind.ToString()) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "possibleState", possibleState => new JArray(possibleState) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="ActualFiniteState"/>
        /// </summary>
        /// <param name="actualFiniteState">The <see cref="ActualFiniteState"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ActualFiniteState actualFiniteState)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), actualFiniteState.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](actualFiniteState.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](actualFiniteState.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](actualFiniteState.Iid));
            jsonObject.Add("kind", this.PropertySerializerMap["kind"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.ActualFiniteStateKind), actualFiniteState.Kind)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](actualFiniteState.ModifiedOn));
            jsonObject.Add("possibleState", this.PropertySerializerMap["possibleState"](actualFiniteState.PossibleState));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](actualFiniteState.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ActualFiniteState"/> class.
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

            var actualFiniteState = thing as ActualFiniteState;
            if (actualFiniteState == null)
            {
                throw new InvalidOperationException("The thing is not a ActualFiniteState.");
            }

            return this.Serialize(actualFiniteState);
        }
    }
}
