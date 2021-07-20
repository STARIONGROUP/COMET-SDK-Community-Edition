// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ArchitectureElementSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ArchitectureElementSerializer"/> class is to provide a <see cref="ArchitectureElement"/> specific serializer
    /// </summary>
    public class ArchitectureElementSerializer : BaseThingSerializer, IThingSerializer
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
            { "diagramPort", diagramPort => new JArray(diagramPort) },
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
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ArchitectureElement"/>
        /// </summary>
        /// <param name="architectureElement">The <see cref="ArchitectureElement"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ArchitectureElement architectureElement)
        {
            var jsonObject = new JObject();
            jsonObject.Add("bounds", this.PropertySerializerMap["bounds"](architectureElement.Bounds));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), architectureElement.ClassKind)));
            jsonObject.Add("depictedThing", this.PropertySerializerMap["depictedThing"](architectureElement.DepictedThing));
            jsonObject.Add("diagramElement", this.PropertySerializerMap["diagramElement"](architectureElement.DiagramElement.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("diagramPort", this.PropertySerializerMap["diagramPort"](architectureElement.DiagramPort.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("documentation", this.PropertySerializerMap["documentation"](architectureElement.Documentation));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](architectureElement.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](architectureElement.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](architectureElement.Iid));
            jsonObject.Add("localStyle", this.PropertySerializerMap["localStyle"](architectureElement.LocalStyle));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](architectureElement.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](architectureElement.Name));
            jsonObject.Add("resolution", this.PropertySerializerMap["resolution"](architectureElement.Resolution));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](architectureElement.RevisionNumber));
            jsonObject.Add("sharedStyle", this.PropertySerializerMap["sharedStyle"](architectureElement.SharedStyle));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](architectureElement.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ArchitectureElement"/> class.
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

            var architectureElement = thing as ArchitectureElement;
            if (architectureElement == null)
            {
                throw new InvalidOperationException("The thing is not a ArchitectureElement.");
            }

            return this.Serialize(architectureElement);
        }
    }
}
