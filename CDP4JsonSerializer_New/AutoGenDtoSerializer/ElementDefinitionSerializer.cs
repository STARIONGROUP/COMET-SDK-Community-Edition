// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ElementDefinitionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ElementDefinitionSerializer"/> class is to provide a <see cref="ElementDefinition"/> specific serializer
    /// </summary>
    public class ElementDefinitionSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "alias", alias => JsonValue.Create(alias) },
            { "category", category => JsonValue.Create(category) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "containedElement", containedElement => JsonValue.Create(containedElement) },
            { "definition", definition => JsonValue.Create(definition) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            { "iid", iid => JsonValue.Create(iid) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "organizationalParticipant", organizationalParticipant => JsonValue.Create(organizationalParticipant) },
            { "owner", owner => JsonValue.Create(owner) },
            { "parameter", parameter => JsonValue.Create(parameter) },
            { "parameterGroup", parameterGroup => JsonValue.Create(parameterGroup) },
            { "referencedElement", referencedElement => JsonValue.Create(referencedElement) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ElementDefinition"/>
        /// </summary>
        /// <param name="elementDefinition">The <see cref="ElementDefinition"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ElementDefinition elementDefinition)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](elementDefinition.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](elementDefinition.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), elementDefinition.ClassKind)));
            jsonObject.Add("containedElement", this.PropertySerializerMap["containedElement"](elementDefinition.ContainedElement.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](elementDefinition.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](elementDefinition.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](elementDefinition.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](elementDefinition.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](elementDefinition.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](elementDefinition.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](elementDefinition.Name));
            jsonObject.Add("organizationalParticipant", this.PropertySerializerMap["organizationalParticipant"](elementDefinition.OrganizationalParticipant.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](elementDefinition.Owner));
            jsonObject.Add("parameter", this.PropertySerializerMap["parameter"](elementDefinition.Parameter.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("parameterGroup", this.PropertySerializerMap["parameterGroup"](elementDefinition.ParameterGroup.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("referencedElement", this.PropertySerializerMap["referencedElement"](elementDefinition.ReferencedElement.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](elementDefinition.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](elementDefinition.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](elementDefinition.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ElementDefinition"/> class.
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

            var elementDefinition = thing as ElementDefinition;
            if (elementDefinition == null)
            {
                throw new InvalidOperationException("The thing is not a ElementDefinition.");
            }

            return this.Serialize(elementDefinition);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
