// --------------------------------------------------------------------------------------------------------------------
// <copyright file "BoundsSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BoundsSerializer"/> class is to provide a <see cref="Bounds"/> specific serializer
    /// </summary>
    public class BoundsSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "height", height => new JValue(height) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "width", width => new JValue(width) },
            { "x", x => new JValue(x) },
            { "y", y => new JValue(y) },
        };

        /// <summary>
        /// Serialize the <see cref="Bounds"/>
        /// </summary>
        /// <param name="bounds">The <see cref="Bounds"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Bounds bounds)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), bounds.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](bounds.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](bounds.ExcludedPerson));
            jsonObject.Add("height", this.PropertySerializerMap["height"](bounds.Height));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](bounds.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](bounds.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](bounds.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](bounds.RevisionNumber));
            jsonObject.Add("width", this.PropertySerializerMap["width"](bounds.Width));
            jsonObject.Add("x", this.PropertySerializerMap["x"](bounds.X));
            jsonObject.Add("y", this.PropertySerializerMap["y"](bounds.Y));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Bounds"/> class.
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

            var bounds = thing as Bounds;
            if (bounds == null)
            {
                throw new InvalidOperationException("The thing is not a Bounds.");
            }

            return this.Serialize(bounds);
        }
    }
}
