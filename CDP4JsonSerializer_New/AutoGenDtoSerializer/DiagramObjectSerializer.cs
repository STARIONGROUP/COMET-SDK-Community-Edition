// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DiagramObjectSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski, Jaime Bernar
//
//    This file is part of CDP4-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
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

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Nodes;

    using CDP4Common.DTO;
    using CDP4Common.Types;
    
    /// <summary>
    /// The purpose of the <see cref="DiagramObjectSerializer"/> class is to provide a <see cref="DiagramObject"/> specific serializer
    /// </summary>
    public class DiagramObjectSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "bounds", bounds => JsonValue.Create(bounds) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "depictedThing", depictedThing => JsonValue.Create(depictedThing) },
            { "diagramElement", diagramElement => JsonValue.Create(diagramElement) },
            { "documentation", documentation => JsonValue.Create(documentation) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "iid", iid => JsonValue.Create(iid) },
            { "localStyle", localStyle => JsonValue.Create(localStyle) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "resolution", resolution => JsonValue.Create(resolution) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "sharedStyle", sharedStyle => JsonValue.Create(sharedStyle) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="DiagramObject"/>
        /// </summary>
        /// <param name="diagramObject">The <see cref="DiagramObject"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(DiagramObject diagramObject)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("bounds", this.PropertySerializerMap["bounds"](diagramObject.Bounds));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), diagramObject.ClassKind)));
            jsonObject.Add("depictedThing", this.PropertySerializerMap["depictedThing"](diagramObject.DepictedThing));
            jsonObject.Add("diagramElement", this.PropertySerializerMap["diagramElement"](diagramObject.DiagramElement.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("documentation", this.PropertySerializerMap["documentation"](diagramObject.Documentation));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](diagramObject.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](diagramObject.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](diagramObject.Iid));
            jsonObject.Add("localStyle", this.PropertySerializerMap["localStyle"](diagramObject.LocalStyle));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](diagramObject.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](diagramObject.Name));
            jsonObject.Add("resolution", this.PropertySerializerMap["resolution"](diagramObject.Resolution));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](diagramObject.RevisionNumber));
            jsonObject.Add("sharedStyle", this.PropertySerializerMap["sharedStyle"](diagramObject.SharedStyle));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](diagramObject.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DiagramObject"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JsonValue>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        public JsonObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
