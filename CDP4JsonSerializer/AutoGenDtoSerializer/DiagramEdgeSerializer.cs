// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramEdgeSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

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
    public class DiagramEdgeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
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
            { "thingPreference", thingPreference => new JValue(thingPreference) },
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
            jsonObject.Add("diagramElement", this.PropertySerializerMap["diagramElement"](diagramEdge.DiagramElement.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](diagramEdge.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](diagramEdge.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](diagramEdge.Iid));
            jsonObject.Add("localStyle", this.PropertySerializerMap["localStyle"](diagramEdge.LocalStyle));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](diagramEdge.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](diagramEdge.Name));
            jsonObject.Add("point", this.PropertySerializerMap["point"](diagramEdge.Point.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](diagramEdge.RevisionNumber));
            jsonObject.Add("sharedStyle", this.PropertySerializerMap["sharedStyle"](diagramEdge.SharedStyle));
            jsonObject.Add("source", this.PropertySerializerMap["source"](diagramEdge.Source));
            jsonObject.Add("target", this.PropertySerializerMap["target"](diagramEdge.Target));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](diagramEdge.ThingPreference));
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
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
