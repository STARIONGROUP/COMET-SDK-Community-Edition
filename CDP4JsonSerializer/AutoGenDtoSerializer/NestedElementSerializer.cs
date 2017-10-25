// --------------------------------------------------------------------------------------------------------------------
// <copyright file "NestedElementSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NestedElementSerializer"/> class is to provide a <see cref="NestedElement"/> specific serializer
    /// </summary>
    public class NestedElementSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "elementUsage", elementUsage => new JArray(((IEnumerable)elementUsage).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "isVolatile", isVolatile => new JValue(isVolatile) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "nestedParameter", nestedParameter => new JArray(nestedParameter) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "rootElement", rootElement => new JValue(rootElement) },
        };

        /// <summary>
        /// Serialize the <see cref="NestedElement"/>
        /// </summary>
        /// <param name="nestedElement">The <see cref="NestedElement"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(NestedElement nestedElement)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), nestedElement.ClassKind)));
            jsonObject.Add("elementUsage", this.PropertySerializerMap["elementUsage"](nestedElement.ElementUsage));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](nestedElement.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](nestedElement.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](nestedElement.Iid));
            jsonObject.Add("isVolatile", this.PropertySerializerMap["isVolatile"](nestedElement.IsVolatile));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](nestedElement.ModifiedOn));
            jsonObject.Add("nestedParameter", this.PropertySerializerMap["nestedParameter"](nestedElement.NestedParameter));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](nestedElement.RevisionNumber));
            jsonObject.Add("rootElement", this.PropertySerializerMap["rootElement"](nestedElement.RootElement));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="NestedElement"/> class.
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

            var nestedElement = thing as NestedElement;
            if (nestedElement == null)
            {
                throw new InvalidOperationException("The thing is not a NestedElement.");
            }

            return this.Serialize(nestedElement);
        }
    }
}
