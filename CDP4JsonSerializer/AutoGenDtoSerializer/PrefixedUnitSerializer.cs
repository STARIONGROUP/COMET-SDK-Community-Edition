// --------------------------------------------------------------------------------------------------------------------
// <copyright file "PrefixedUnitSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PrefixedUnitSerializer"/> class is to provide a <see cref="PrefixedUnit"/> specific serializer
    /// </summary>
    public class PrefixedUnitSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            
            
            
            
            { "alias", alias => JsonValue.Create(alias) },
            
            
            
            
            
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            
            
             
             
            
            
            
            { "definition", definition => JsonValue.Create(definition) },
            
            
            
            
            
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            
            
            
            
            
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            
            
            
            
            
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            
            
            
            
            
            { "iid", iid => JsonValue.Create(iid) },
            
            
            
            
            
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            
            
            
            
            
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            
            
             
             
            
            
            
            { "prefix", prefix => JsonValue.Create(prefix) },
            
            
            
            
            
            { "referenceUnit", referenceUnit => JsonValue.Create(referenceUnit) },
            
            
            
            
            
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            
            
             
             
            
            
            
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            
            
        };

        /// <summary>
        /// Serialize the <see cref="PrefixedUnit"/>
        /// </summary>
        /// <param name="prefixedUnit">The <see cref="PrefixedUnit"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(PrefixedUnit prefixedUnit)
        {
            var jsonObject = new JsonObject
            {
                {"alias", this.PropertySerializerMap["alias"](prefixedUnit.Alias.OrderBy(x => x, this.guidComparer))},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), prefixedUnit.ClassKind))},
                {"definition", this.PropertySerializerMap["definition"](prefixedUnit.Definition.OrderBy(x => x, this.guidComparer))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](prefixedUnit.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](prefixedUnit.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"hyperLink", this.PropertySerializerMap["hyperLink"](prefixedUnit.HyperLink.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](prefixedUnit.Iid)},
                {"isDeprecated", this.PropertySerializerMap["isDeprecated"](prefixedUnit.IsDeprecated)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](prefixedUnit.ModifiedOn)},
                {"prefix", this.PropertySerializerMap["prefix"](prefixedUnit.Prefix)},
                {"referenceUnit", this.PropertySerializerMap["referenceUnit"](prefixedUnit.ReferenceUnit)},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](prefixedUnit.RevisionNumber)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](prefixedUnit.ThingPreference)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="PrefixedUnit"/> class.
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

            if (thing is not PrefixedUnit prefixedUnit)
            {
                throw new InvalidOperationException("The thing is not a PrefixedUnit.");
            }

            return this.Serialize(prefixedUnit);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
