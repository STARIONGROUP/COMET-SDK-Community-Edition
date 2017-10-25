// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ColorSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ColorSerializer"/> class is to provide a <see cref="Color"/> specific serializer
    /// </summary>
    public class ColorSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "blue", blue => new JValue(blue) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "green", green => new JValue(green) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "red", red => new JValue(red) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="Color"/>
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Color color)
        {
            var jsonObject = new JObject();
            jsonObject.Add("blue", this.PropertySerializerMap["blue"](color.Blue));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), color.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](color.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](color.ExcludedPerson));
            jsonObject.Add("green", this.PropertySerializerMap["green"](color.Green));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](color.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](color.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](color.Name));
            jsonObject.Add("red", this.PropertySerializerMap["red"](color.Red));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](color.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Color"/> class.
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

            var color = thing as Color;
            if (color == null)
            {
                throw new InvalidOperationException("The thing is not a Color.");
            }

            return this.Serialize(color);
        }
    }
}
