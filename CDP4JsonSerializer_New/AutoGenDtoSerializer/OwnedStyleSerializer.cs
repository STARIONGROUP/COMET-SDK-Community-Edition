// --------------------------------------------------------------------------------------------------------------------
// <copyright file "OwnedStyleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="OwnedStyleSerializer"/> class is to provide a <see cref="OwnedStyle"/> specific serializer
    /// </summary>
    public class OwnedStyleSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
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
        /// Serialize the <see cref="OwnedStyle"/>
        /// </summary>
        /// <param name="ownedStyle">The <see cref="OwnedStyle"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(OwnedStyle ownedStyle)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), ownedStyle.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](ownedStyle.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](ownedStyle.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("fillColor", this.PropertySerializerMap["fillColor"](ownedStyle.FillColor));
            jsonObject.Add("fillOpacity", this.PropertySerializerMap["fillOpacity"](ownedStyle.FillOpacity));
            jsonObject.Add("fontBold", this.PropertySerializerMap["fontBold"](ownedStyle.FontBold));
            jsonObject.Add("fontColor", this.PropertySerializerMap["fontColor"](ownedStyle.FontColor));
            jsonObject.Add("fontItalic", this.PropertySerializerMap["fontItalic"](ownedStyle.FontItalic));
            jsonObject.Add("fontName", this.PropertySerializerMap["fontName"](ownedStyle.FontName));
            jsonObject.Add("fontSize", this.PropertySerializerMap["fontSize"](ownedStyle.FontSize));
            jsonObject.Add("fontStrokeThrough", this.PropertySerializerMap["fontStrokeThrough"](ownedStyle.FontStrokeThrough));
            jsonObject.Add("fontUnderline", this.PropertySerializerMap["fontUnderline"](ownedStyle.FontUnderline));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](ownedStyle.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](ownedStyle.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](ownedStyle.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](ownedStyle.RevisionNumber));
            jsonObject.Add("strokeColor", this.PropertySerializerMap["strokeColor"](ownedStyle.StrokeColor));
            jsonObject.Add("strokeOpacity", this.PropertySerializerMap["strokeOpacity"](ownedStyle.StrokeOpacity));
            jsonObject.Add("strokeWidth", this.PropertySerializerMap["strokeWidth"](ownedStyle.StrokeWidth));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](ownedStyle.ThingPreference));
            jsonObject.Add("usedColor", this.PropertySerializerMap["usedColor"](ownedStyle.UsedColor.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="OwnedStyle"/> class.
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

            var ownedStyle = thing as OwnedStyle;
            if (ownedStyle == null)
            {
                throw new InvalidOperationException("The thing is not a OwnedStyle.");
            }

            return this.Serialize(ownedStyle);
        }
    }
}
