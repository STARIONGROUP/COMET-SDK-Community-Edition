// --------------------------------------------------------------------------------------------------------------------
// <copyright file "TimeOfDayParameterTypeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="TimeOfDayParameterTypeSerializer"/> class is to provide a <see cref="TimeOfDayParameterType"/> specific serializer
    /// </summary>
    public class TimeOfDayParameterTypeSerializer : IThingSerializer
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
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "symbol", symbol => new JValue(symbol) },
        };

        /// <summary>
        /// Serialize the <see cref="TimeOfDayParameterType"/>
        /// </summary>
        /// <param name="timeOfDayParameterType">The <see cref="TimeOfDayParameterType"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(TimeOfDayParameterType timeOfDayParameterType)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](timeOfDayParameterType.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](timeOfDayParameterType.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), timeOfDayParameterType.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](timeOfDayParameterType.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](timeOfDayParameterType.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](timeOfDayParameterType.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](timeOfDayParameterType.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](timeOfDayParameterType.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](timeOfDayParameterType.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](timeOfDayParameterType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](timeOfDayParameterType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](timeOfDayParameterType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](timeOfDayParameterType.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](timeOfDayParameterType.Symbol));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="TimeOfDayParameterType"/> class.
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

            var timeOfDayParameterType = thing as TimeOfDayParameterType;
            if (timeOfDayParameterType == null)
            {
                throw new InvalidOperationException("The thing is not a TimeOfDayParameterType.");
            }

            return this.Serialize(timeOfDayParameterType);
        }
    }
}
