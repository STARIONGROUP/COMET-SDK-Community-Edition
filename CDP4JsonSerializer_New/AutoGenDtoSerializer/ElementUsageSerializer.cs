// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ElementUsageSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ElementUsageSerializer"/> class is to provide a <see cref="ElementUsage"/> specific serializer
    /// </summary>
    public class ElementUsageSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {            
            { "alias", alias => JsonValue.Create(alias) },
            { "category", category => JsonValue.Create(category) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "definition", definition => JsonValue.Create(definition) },
            { "elementDefinition", elementDefinition => JsonValue.Create(elementDefinition) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "excludeOption", excludeOption => JsonValue.Create(excludeOption) },
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            { "iid", iid => JsonValue.Create(iid) },
            { "interfaceEnd", interfaceEnd => JsonValue.Create(interfaceEnd.ToString()) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "owner", owner => JsonValue.Create(owner) },
            { "parameterOverride", parameterOverride => JsonValue.Create(parameterOverride) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ElementUsage"/>
        /// </summary>
        /// <param name="elementUsage">The <see cref="ElementUsage"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ElementUsage elementUsage)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](elementUsage.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](elementUsage.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), elementUsage.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](elementUsage.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("elementDefinition", this.PropertySerializerMap["elementDefinition"](elementUsage.ElementDefinition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](elementUsage.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](elementUsage.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludeOption", this.PropertySerializerMap["excludeOption"](elementUsage.ExcludeOption.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](elementUsage.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](elementUsage.Iid));
            jsonObject.Add("interfaceEnd", this.PropertySerializerMap["interfaceEnd"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.InterfaceEndKind), elementUsage.InterfaceEnd)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](elementUsage.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](elementUsage.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](elementUsage.Owner));
            jsonObject.Add("parameterOverride", this.PropertySerializerMap["parameterOverride"](elementUsage.ParameterOverride.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](elementUsage.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](elementUsage.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](elementUsage.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ElementUsage"/> class.
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

            var elementUsage = thing as ElementUsage;
            if (elementUsage == null)
            {
                throw new InvalidOperationException("The thing is not a ElementUsage.");
            }

            return this.Serialize(elementUsage);
        }
    }
}
