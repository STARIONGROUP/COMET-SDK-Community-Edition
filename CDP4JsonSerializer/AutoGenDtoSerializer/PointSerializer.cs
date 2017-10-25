// --------------------------------------------------------------------------------------------------------------------
// <copyright file "PointSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PointSerializer"/> class is to provide a <see cref="Point"/> specific serializer
    /// </summary>
    public class PointSerializer : IThingSerializer
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
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "x", x => new JValue(x) },
            { "y", y => new JValue(y) },
        };

        /// <summary>
        /// Serialize the <see cref="Point"/>
        /// </summary>
        /// <param name="point">The <see cref="Point"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Point point)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), point.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](point.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](point.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](point.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](point.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](point.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](point.RevisionNumber));
            jsonObject.Add("x", this.PropertySerializerMap["x"](point.X));
            jsonObject.Add("y", this.PropertySerializerMap["y"](point.Y));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Point"/> class.
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

            var point = thing as Point;
            if (point == null)
            {
                throw new InvalidOperationException("The thing is not a Point.");
            }

            return this.Serialize(point);
        }
    }
}
