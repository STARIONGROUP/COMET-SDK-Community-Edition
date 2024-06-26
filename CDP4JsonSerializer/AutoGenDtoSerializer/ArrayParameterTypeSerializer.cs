// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayParameterTypeSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    /// The purpose of the <see cref="ArrayParameterTypeSerializer"/> class is to provide a <see cref="ArrayParameterType"/> specific serializer
    /// </summary>
    public class ArrayParameterTypeSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "component", component => new JArray(((IEnumerable)component).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "definition", definition => new JArray(definition) },
            { "dimension", dimension => new JArray(((IEnumerable)dimension).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "isFinalized", isFinalized => new JValue(isFinalized) },
            { "isTensor", isTensor => new JValue(isTensor) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "symbol", symbol => new JValue(symbol) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ArrayParameterType"/>
        /// </summary>
        /// <param name="arrayParameterType">The <see cref="ArrayParameterType"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ArrayParameterType arrayParameterType)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](arrayParameterType.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](arrayParameterType.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), arrayParameterType.ClassKind)));
            jsonObject.Add("component", this.PropertySerializerMap["component"](arrayParameterType.Component.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](arrayParameterType.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("dimension", this.PropertySerializerMap["dimension"](arrayParameterType.Dimension.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](arrayParameterType.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](arrayParameterType.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](arrayParameterType.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](arrayParameterType.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](arrayParameterType.IsDeprecated));
            jsonObject.Add("isFinalized", this.PropertySerializerMap["isFinalized"](arrayParameterType.IsFinalized));
            jsonObject.Add("isTensor", this.PropertySerializerMap["isTensor"](arrayParameterType.IsTensor));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](arrayParameterType.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](arrayParameterType.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](arrayParameterType.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](arrayParameterType.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](arrayParameterType.Symbol));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](arrayParameterType.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ArrayParameterType"/> class.
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

            var arrayParameterType = thing as ArrayParameterType;
            if (arrayParameterType == null)
            {
                throw new InvalidOperationException("The thing is not a ArrayParameterType.");
            }

            return this.Serialize(arrayParameterType);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
