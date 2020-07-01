// --------------------------------------------------------------------------------------------------------------------
// <copyright file "NestedParameterSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NestedParameterSerializer"/> class is to provide a <see cref="NestedParameter"/> specific serializer
    /// </summary>
    public class NestedParameterSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actualState", actualState => new JValue(actualState) },
            { "actualValue", actualValue => new JValue(actualValue) },
            { "associatedParameter", associatedParameter => new JValue(associatedParameter) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "formula", formula => new JValue(formula) },
            { "iid", iid => new JValue(iid) },
            { "isVolatile", isVolatile => new JValue(isVolatile) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="NestedParameter"/>
        /// </summary>
        /// <param name="nestedParameter">The <see cref="NestedParameter"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(NestedParameter nestedParameter)
        {
            var jsonObject = new JObject();
            jsonObject.Add("actualState", this.PropertySerializerMap["actualState"](nestedParameter.ActualState));
            jsonObject.Add("actualValue", this.PropertySerializerMap["actualValue"](nestedParameter.ActualValue));
            jsonObject.Add("associatedParameter", this.PropertySerializerMap["associatedParameter"](nestedParameter.AssociatedParameter));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), nestedParameter.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](nestedParameter.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](nestedParameter.ExcludedPerson));
            jsonObject.Add("formula", this.PropertySerializerMap["formula"](nestedParameter.Formula));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](nestedParameter.Iid));
            jsonObject.Add("isVolatile", this.PropertySerializerMap["isVolatile"](nestedParameter.IsVolatile));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](nestedParameter.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](nestedParameter.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](nestedParameter.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="NestedParameter"/> class.
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

            var nestedParameter = thing as NestedParameter;
            if (nestedParameter == null)
            {
                throw new InvalidOperationException("The thing is not a NestedParameter.");
            }

            return this.Serialize(nestedParameter);
        }
    }
}
