// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ArchitectureDiagramSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
    /// The purpose of the <see cref="ArchitectureDiagramSerializer"/> class is to provide a <see cref="ArchitectureDiagram"/> specific serializer
    /// </summary>
    public class ArchitectureDiagramSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "bounds", bounds => new JArray(bounds) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "description", description => new JValue(description) },
            { "diagramElement", diagramElement => new JArray(diagramElement) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "publicationState", publicationState => new JValue(publicationState.ToString()) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "topArchitectureElement", topArchitectureElement => new JValue(topArchitectureElement) },
        };

        /// <summary>
        /// Serialize the <see cref="ArchitectureDiagram"/>
        /// </summary>
        /// <param name="architectureDiagram">The <see cref="ArchitectureDiagram"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ArchitectureDiagram architectureDiagram)
        {
            var jsonObject = new JObject();
            jsonObject.Add("bounds", this.PropertySerializerMap["bounds"](architectureDiagram.Bounds));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), architectureDiagram.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](architectureDiagram.CreatedOn));
            jsonObject.Add("description", this.PropertySerializerMap["description"](architectureDiagram.Description));
            jsonObject.Add("diagramElement", this.PropertySerializerMap["diagramElement"](architectureDiagram.DiagramElement.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](architectureDiagram.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](architectureDiagram.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](architectureDiagram.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](architectureDiagram.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](architectureDiagram.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](architectureDiagram.Owner));
            jsonObject.Add("publicationState", this.PropertySerializerMap["publicationState"](Enum.GetName(typeof(CDP4Common.DiagramData.PublicationState), architectureDiagram.PublicationState)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](architectureDiagram.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](architectureDiagram.ThingPreference));
            jsonObject.Add("topArchitectureElement", this.PropertySerializerMap["topArchitectureElement"](architectureDiagram.TopArchitectureElement));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ArchitectureDiagram"/> class.
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

            var architectureDiagram = thing as ArchitectureDiagram;
            if (architectureDiagram == null)
            {
                throw new InvalidOperationException("The thing is not a ArchitectureDiagram.");
            }

            return this.Serialize(architectureDiagram);
        }
    }
}
