// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DiagramEdgeSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DiagramEdgeSerializer"/> class is to provide a <see cref="DiagramEdge"/> specific serializer
    /// </summary>
    public class DiagramEdgeSerializer : IThingSerializer
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
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "localStyle", localStyle => new JArray(localStyle) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "point", point => new JArray(((IEnumerable)point).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "sharedStyle", sharedStyle => new JValue(sharedStyle) },
            { "source", source => new JValue(source) },
            { "target", target => new JValue(target) },
        };

        /// <summary>
        /// Serialize the <see cref="DiagramEdge"/>
        /// </summary>
        /// <param name="diagramEdge">The <see cref="DiagramEdge"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DiagramEdge diagramEdge)
        {
            var jsonObject = new JObject();
            jsonObject.Add("bounds", this.PropertySerializerMap["bounds"](diagramEdge.Bounds));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), diagramEdge.ClassKind)));
            jsonObject.Add("depictedThing", this.PropertySerializerMap["depictedThing"](diagramEdge.DepictedThing));
            jsonObject.Add("diagramElement", this.PropertySerializerMap["diagramElement"](diagramEdge.DiagramElement));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](diagramEdge.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](diagramEdge.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](diagramEdge.Iid));
            jsonObject.Add("localStyle", this.PropertySerializerMap["localStyle"](diagramEdge.LocalStyle));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](diagramEdge.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](diagramEdge.Name));
            jsonObject.Add("point", this.PropertySerializerMap["point"](diagramEdge.Point));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](diagramEdge.RevisionNumber));
            jsonObject.Add("sharedStyle", this.PropertySerializerMap["sharedStyle"](diagramEdge.SharedStyle));
            jsonObject.Add("source", this.PropertySerializerMap["source"](diagramEdge.Source));
            jsonObject.Add("target", this.PropertySerializerMap["target"](diagramEdge.Target));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DiagramEdge"/> class.
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

            var diagramEdge = thing as DiagramEdge;
            if (diagramEdge == null)
            {
                throw new InvalidOperationException("The thing is not a DiagramEdge.");
            }

            return this.Serialize(diagramEdge);
        }
    }
}
