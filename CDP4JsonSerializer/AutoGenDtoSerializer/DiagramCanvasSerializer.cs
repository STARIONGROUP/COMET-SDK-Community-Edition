// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DiagramCanvasSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DiagramCanvasSerializer"/> class is to provide a <see cref="DiagramCanvas"/> specific serializer
    /// </summary>
    public class DiagramCanvasSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "bounds", bounds => new JArray(bounds) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "diagramElement", diagramElement => new JArray(diagramElement) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="DiagramCanvas"/>
        /// </summary>
        /// <param name="diagramCanvas">The <see cref="DiagramCanvas"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DiagramCanvas diagramCanvas)
        {
            var jsonObject = new JObject();
            jsonObject.Add("bounds", this.PropertySerializerMap["bounds"](diagramCanvas.Bounds));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), diagramCanvas.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](diagramCanvas.CreatedOn));
            jsonObject.Add("diagramElement", this.PropertySerializerMap["diagramElement"](diagramCanvas.DiagramElement));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](diagramCanvas.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](diagramCanvas.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](diagramCanvas.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](diagramCanvas.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](diagramCanvas.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](diagramCanvas.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DiagramCanvas"/> class.
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

            var diagramCanvas = thing as DiagramCanvas;
            if (diagramCanvas == null)
            {
                throw new InvalidOperationException("The thing is not a DiagramCanvas.");
            }

            return this.Serialize(diagramCanvas);
        }
    }
}
