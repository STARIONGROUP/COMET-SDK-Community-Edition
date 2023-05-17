// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SharedStyleSerializer.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Nodes;

    using CDP4Common.DTO;
    using CDP4Common.Types;
    
    /// <summary>
    /// The purpose of the <see cref="SharedStyleSerializer"/> class is to provide a <see cref="SharedStyle"/> specific serializer
    /// </summary>
    public class SharedStyleSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            
            
            
            
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            
            
            
            
            
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            
            
            
            
            
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            
            
            
            
            
            { "fillColor", fillColor => JsonValue.Create(fillColor) },
            
            
            
            
            
            { "fillOpacity", fillOpacity => JsonValue.Create(fillOpacity) },
            
            
            
            
            
            { "fontBold", fontBold => JsonValue.Create(fontBold) },
            
            
            
            
            
            { "fontColor", fontColor => JsonValue.Create(fontColor) },
            
            
            
            
            
            { "fontItalic", fontItalic => JsonValue.Create(fontItalic) },
            
            
            
            
            
            { "fontName", fontName => JsonValue.Create(fontName) },
            
            
            
            
            
            { "fontSize", fontSize => JsonValue.Create(fontSize) },
            
            
            
            
            
            { "fontStrokeThrough", fontStrokeThrough => JsonValue.Create(fontStrokeThrough) },
            
            
            
            
            
            { "fontUnderline", fontUnderline => JsonValue.Create(fontUnderline) },
            
            
            
            
            
            { "iid", iid => JsonValue.Create(iid) },
            
            
            
            
            
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            
            
            
            
            
            { "name", name => JsonValue.Create(name) },
            
            
            
            
            
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            
            
            
            
            
            { "strokeColor", strokeColor => JsonValue.Create(strokeColor) },
            
            
            
            
            
            { "strokeOpacity", strokeOpacity => JsonValue.Create(strokeOpacity) },
            
            
            
            
            
            { "strokeWidth", strokeWidth => JsonValue.Create(strokeWidth) },
            
            
            
            
            
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            
            
            
            
            
            { "usedColor", usedColor => JsonValue.Create(usedColor) },
            
            
        };

        /// <summary>
        /// Serialize the <see cref="SharedStyle"/>
        /// </summary>
        /// <param name="sharedStyle">The <see cref="SharedStyle"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(SharedStyle sharedStyle)
        {
            var jsonObject = new JsonObject
            {
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), sharedStyle.ClassKind))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](sharedStyle.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](sharedStyle.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"fillColor", this.PropertySerializerMap["fillColor"](sharedStyle.FillColor)},
                {"fillOpacity", this.PropertySerializerMap["fillOpacity"](sharedStyle.FillOpacity)},
                {"fontBold", this.PropertySerializerMap["fontBold"](sharedStyle.FontBold)},
                {"fontColor", this.PropertySerializerMap["fontColor"](sharedStyle.FontColor)},
                {"fontItalic", this.PropertySerializerMap["fontItalic"](sharedStyle.FontItalic)},
                {"fontName", this.PropertySerializerMap["fontName"](sharedStyle.FontName)},
                {"fontSize", this.PropertySerializerMap["fontSize"](sharedStyle.FontSize)},
                {"fontStrokeThrough", this.PropertySerializerMap["fontStrokeThrough"](sharedStyle.FontStrokeThrough)},
                {"fontUnderline", this.PropertySerializerMap["fontUnderline"](sharedStyle.FontUnderline)},
                {"iid", this.PropertySerializerMap["iid"](sharedStyle.Iid)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](sharedStyle.ModifiedOn)},
                {"name", this.PropertySerializerMap["name"](sharedStyle.Name)},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](sharedStyle.RevisionNumber)},
                {"strokeColor", this.PropertySerializerMap["strokeColor"](sharedStyle.StrokeColor)},
                {"strokeOpacity", this.PropertySerializerMap["strokeOpacity"](sharedStyle.StrokeOpacity)},
                {"strokeWidth", this.PropertySerializerMap["strokeWidth"](sharedStyle.StrokeWidth)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](sharedStyle.ThingPreference)},
                {"usedColor", this.PropertySerializerMap["usedColor"](sharedStyle.UsedColor.OrderBy(x => x, this.guidComparer))},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SharedStyle"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JsonValue>> PropertySerializerMap => this.propertySerializerMap;

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

            if (thing is not SharedStyle sharedStyle)
            {
                throw new InvalidOperationException("The thing is not a SharedStyle.");
            }

            return this.Serialize(sharedStyle);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
