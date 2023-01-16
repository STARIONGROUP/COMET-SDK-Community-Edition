// --------------------------------------------------------------------------------------------------------------------
// <copyright file "MultiRelationshipRuleSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="MultiRelationshipRuleSerializer"/> class is to provide a <see cref="MultiRelationshipRule"/> specific serializer
    /// </summary>
    public class MultiRelationshipRuleSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {            
            { "alias", alias => JsonValue.Create(alias) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "definition", definition => JsonValue.Create(definition) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            { "iid", iid => JsonValue.Create(iid) },
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            { "maxRelated", maxRelated => JsonValue.Create(maxRelated) },
            { "minRelated", minRelated => JsonValue.Create(minRelated) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "relatedCategory", relatedCategory => JsonValue.Create(relatedCategory) },
            { "relationshipCategory", relationshipCategory => JsonValue.Create(relationshipCategory) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="MultiRelationshipRule"/>
        /// </summary>
        /// <param name="multiRelationshipRule">The <see cref="MultiRelationshipRule"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(MultiRelationshipRule multiRelationshipRule)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](multiRelationshipRule.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), multiRelationshipRule.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](multiRelationshipRule.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](multiRelationshipRule.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](multiRelationshipRule.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](multiRelationshipRule.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](multiRelationshipRule.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](multiRelationshipRule.IsDeprecated));
            jsonObject.Add("maxRelated", this.PropertySerializerMap["maxRelated"](multiRelationshipRule.MaxRelated));
            jsonObject.Add("minRelated", this.PropertySerializerMap["minRelated"](multiRelationshipRule.MinRelated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](multiRelationshipRule.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](multiRelationshipRule.Name));
            jsonObject.Add("relatedCategory", this.PropertySerializerMap["relatedCategory"](multiRelationshipRule.RelatedCategory.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("relationshipCategory", this.PropertySerializerMap["relationshipCategory"](multiRelationshipRule.RelationshipCategory));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](multiRelationshipRule.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](multiRelationshipRule.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](multiRelationshipRule.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="MultiRelationshipRule"/> class.
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

            var multiRelationshipRule = thing as MultiRelationshipRule;
            if (multiRelationshipRule == null)
            {
                throw new InvalidOperationException("The thing is not a MultiRelationshipRule.");
            }

            return this.Serialize(multiRelationshipRule);
        }
    }
}
