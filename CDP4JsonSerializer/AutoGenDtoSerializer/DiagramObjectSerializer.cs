// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DiagramObjectSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DiagramObjectSerializer"/> class is to provide a <see cref="DiagramObject"/> specific serializer
    /// </summary>
    public class DiagramObjectSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "bounds", bounds => new JArray(bounds) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "depictedThing", depictedThing => new JValue(depictedThing) },
            { "diagramElement", diagramElement => new JArray(diagramElement) },
            { "documentation", documentation => new JValue(documentation) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "localStyle", localStyle => new JArray(localStyle) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "resolution", resolution => new JValue(resolution) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "sharedStyle", sharedStyle => new JValue(sharedStyle) },
        };

        /// <summary>
        /// Serialize the <see cref="DiagramObject"/>
        /// </summary>
        /// <param name="diagramObject">The <see cref="DiagramObject"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DiagramObject diagramObject)
        {
            var jsonObject = new JObject();
            jsonObject.Add("bounds", this.PropertySerializerMap["bounds"](diagramObject.Bounds));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), diagramObject.ClassKind)));
            jsonObject.Add("depictedThing", this.PropertySerializerMap["depictedThing"](diagramObject.DepictedThing));
            jsonObject.Add("diagramElement", this.PropertySerializerMap["diagramElement"](diagramObject.DiagramElement));
            jsonObject.Add("documentation", this.PropertySerializerMap["documentation"](diagramObject.Documentation));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](diagramObject.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](diagramObject.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](diagramObject.Iid));
            jsonObject.Add("localStyle", this.PropertySerializerMap["localStyle"](diagramObject.LocalStyle));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](diagramObject.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](diagramObject.Name));
            jsonObject.Add("resolution", this.PropertySerializerMap["resolution"](diagramObject.Resolution));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](diagramObject.RevisionNumber));
            jsonObject.Add("sharedStyle", this.PropertySerializerMap["sharedStyle"](diagramObject.SharedStyle));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DiagramObject"/> class.
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

            var diagramObject = thing as DiagramObject;
            if (diagramObject == null)
            {
                throw new InvalidOperationException("The thing is not a DiagramObject.");
            }

            return this.Serialize(diagramObject);
        }
    }
}
