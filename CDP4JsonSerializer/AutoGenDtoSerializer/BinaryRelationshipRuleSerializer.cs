// --------------------------------------------------------------------------------------------------------------------
// <copyright file "BinaryRelationshipRuleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BinaryRelationshipRuleSerializer"/> class is to provide a <see cref="BinaryRelationshipRule"/> specific serializer
    /// </summary>
    public class BinaryRelationshipRuleSerializer : BaseThingSerializer, IThingSerializer
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
            
            
            
            
            
            { "forwardRelationshipName", forwardRelationshipName => JsonValue.Create(forwardRelationshipName) },
            
            
            
            
            
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            
            
            
            
            
            { "iid", iid => JsonValue.Create(iid) },
            
            
            
            
            
            { "inverseRelationshipName", inverseRelationshipName => JsonValue.Create(inverseRelationshipName) },
            
            
            
            
            
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            
            
            
            
            
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            
            
            
            
            
            { "name", name => JsonValue.Create(name) },
            
            
            
            
            
            { "relationshipCategory", relationshipCategory => JsonValue.Create(relationshipCategory) },
            
            
            
            
            
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            
            
            
            
            
            { "shortName", shortName => JsonValue.Create(shortName) },
            
            
            
            
            
            { "sourceCategory", sourceCategory => JsonValue.Create(sourceCategory) },
            
            
            
            
            
            { "targetCategory", targetCategory => JsonValue.Create(targetCategory) },
            
            
            
            
            
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            
            
        };

        /// <summary>
        /// Serialize the <see cref="BinaryRelationshipRule"/>
        /// </summary>
        /// <param name="binaryRelationshipRule">The <see cref="BinaryRelationshipRule"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(BinaryRelationshipRule binaryRelationshipRule)
        {
            var jsonObject = new JsonObject
            {
                {"alias", this.PropertySerializerMap["alias"](binaryRelationshipRule.Alias.OrderBy(x => x, this.guidComparer))},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), binaryRelationshipRule.ClassKind))},
                {"definition", this.PropertySerializerMap["definition"](binaryRelationshipRule.Definition.OrderBy(x => x, this.guidComparer))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](binaryRelationshipRule.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](binaryRelationshipRule.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"forwardRelationshipName", this.PropertySerializerMap["forwardRelationshipName"](binaryRelationshipRule.ForwardRelationshipName)},
                {"hyperLink", this.PropertySerializerMap["hyperLink"](binaryRelationshipRule.HyperLink.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](binaryRelationshipRule.Iid)},
                {"inverseRelationshipName", this.PropertySerializerMap["inverseRelationshipName"](binaryRelationshipRule.InverseRelationshipName)},
                {"isDeprecated", this.PropertySerializerMap["isDeprecated"](binaryRelationshipRule.IsDeprecated)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](binaryRelationshipRule.ModifiedOn)},
                {"name", this.PropertySerializerMap["name"](binaryRelationshipRule.Name)},
                {"relationshipCategory", this.PropertySerializerMap["relationshipCategory"](binaryRelationshipRule.RelationshipCategory)},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](binaryRelationshipRule.RevisionNumber)},
                {"shortName", this.PropertySerializerMap["shortName"](binaryRelationshipRule.ShortName)},
                {"sourceCategory", this.PropertySerializerMap["sourceCategory"](binaryRelationshipRule.SourceCategory)},
                {"targetCategory", this.PropertySerializerMap["targetCategory"](binaryRelationshipRule.TargetCategory)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](binaryRelationshipRule.ThingPreference)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="BinaryRelationshipRule"/> class.
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

            if (thing is not BinaryRelationshipRule binaryRelationshipRule)
            {
                throw new InvalidOperationException("The thing is not a BinaryRelationshipRule.");
            }

            return this.Serialize(binaryRelationshipRule);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
