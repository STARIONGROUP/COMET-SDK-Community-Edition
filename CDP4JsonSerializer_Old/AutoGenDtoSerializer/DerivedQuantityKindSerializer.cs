// --------------------------------------------------------------------------------------------------------------------
// <copyright file "DerivedQuantityKindSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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
    /// The purpose of the <see cref="DerivedQuantityKindSerializer"/> class is to provide a <see cref="DerivedQuantityKind"/> specific serializer
    /// </summary>
    public class DerivedQuantityKindSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "defaultScale", defaultScale => new JValue(defaultScale) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "possibleScale", possibleScale => new JArray(possibleScale) },
            { "quantityDimensionSymbol", quantityDimensionSymbol => new JValue(quantityDimensionSymbol) },
            { "quantityKindFactor", quantityKindFactor => new JArray(((IEnumerable)quantityKindFactor).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "symbol", symbol => new JValue(symbol) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="DerivedQuantityKind"/>
        /// </summary>
        /// <param name="derivedQuantityKind">The <see cref="DerivedQuantityKind"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DerivedQuantityKind derivedQuantityKind)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](derivedQuantityKind.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](derivedQuantityKind.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), derivedQuantityKind.ClassKind)));
            jsonObject.Add("defaultScale", this.PropertySerializerMap["defaultScale"](derivedQuantityKind.DefaultScale));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](derivedQuantityKind.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](derivedQuantityKind.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](derivedQuantityKind.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](derivedQuantityKind.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](derivedQuantityKind.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](derivedQuantityKind.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](derivedQuantityKind.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](derivedQuantityKind.Name));
            jsonObject.Add("possibleScale", this.PropertySerializerMap["possibleScale"](derivedQuantityKind.PossibleScale.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("quantityDimensionSymbol", this.PropertySerializerMap["quantityDimensionSymbol"](derivedQuantityKind.QuantityDimensionSymbol));
            jsonObject.Add("quantityKindFactor", this.PropertySerializerMap["quantityKindFactor"](derivedQuantityKind.QuantityKindFactor.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](derivedQuantityKind.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](derivedQuantityKind.ShortName));
            jsonObject.Add("symbol", this.PropertySerializerMap["symbol"](derivedQuantityKind.Symbol));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](derivedQuantityKind.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DerivedQuantityKind"/> class.
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

            var derivedQuantityKind = thing as DerivedQuantityKind;
            if (derivedQuantityKind == null)
            {
                throw new InvalidOperationException("The thing is not a DerivedQuantityKind.");
            }

            return this.Serialize(derivedQuantityKind);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
