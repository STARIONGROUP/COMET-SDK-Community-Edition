// --------------------------------------------------------------------------------------------------------------------
// <copyright file "IterationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IterationSerializer"/> class is to provide a <see cref="Iteration"/> specific serializer
    /// </summary>
    public class IterationSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            
            
            
            
            { "actualFiniteStateList", actualFiniteStateList => JsonValue.Create(actualFiniteStateList) },
            
            
            
            
            
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            
            
            
            
            
            { "defaultOption", defaultOption => JsonValue.Create(defaultOption) },
            
            
            
            
            
            { "diagramCanvas", diagramCanvas => JsonValue.Create(diagramCanvas) },
            
            
            
            
            
            { "domainFileStore", domainFileStore => JsonValue.Create(domainFileStore) },
            
            
            
            
            
            { "element", element => JsonValue.Create(element) },
            
            
            
            
            
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            
            
            
            
            
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            
            
            
            
            
            { "externalIdentifierMap", externalIdentifierMap => JsonValue.Create(externalIdentifierMap) },
            
            
            
            
            
            { "goal", goal => JsonValue.Create(goal) },
            
            
            
            
            
            { "iid", iid => JsonValue.Create(iid) },
            
            
            
            
            
            { "iterationSetup", iterationSetup => JsonValue.Create(iterationSetup) },
            
            
            
            
            
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            
            
            
            
            
            { "option", option => JsonValue.Create(((IEnumerable)option).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            
            
            
            
            
            { "possibleFiniteStateList", possibleFiniteStateList => JsonValue.Create(possibleFiniteStateList) },
            
            
            
            
            
            { "publication", publication => JsonValue.Create(publication) },
            
            
            
            
            
            { "relationship", relationship => JsonValue.Create(relationship) },
            
            
            
            
            
            { "requirementsSpecification", requirementsSpecification => JsonValue.Create(requirementsSpecification) },
            
            
            
            
            
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            
            
            
            
            
            { "ruleVerificationList", ruleVerificationList => JsonValue.Create(ruleVerificationList) },
            
            
            
            
            
            { "sharedDiagramStyle", sharedDiagramStyle => JsonValue.Create(sharedDiagramStyle) },
            
            
            
            
            
            { "sourceIterationIid", sourceIterationIid => JsonValue.Create(sourceIterationIid) },
            
            
            
            
            
            { "stakeholder", stakeholder => JsonValue.Create(stakeholder) },
            
            
            
            
            
            { "stakeholderValue", stakeholderValue => JsonValue.Create(stakeholderValue) },
            
            
            
            
            
            { "stakeholderValueMap", stakeholderValueMap => JsonValue.Create(stakeholderValueMap) },
            
            
            
            
            
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            
            
            
            
            
            { "topElement", topElement => JsonValue.Create(topElement) },
            
            
            
            
            
            { "valueGroup", valueGroup => JsonValue.Create(valueGroup) },
            
            
        };

        /// <summary>
        /// Serialize the <see cref="Iteration"/>
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(Iteration iteration)
        {
            var jsonObject = new JsonObject
            {
                {"actualFiniteStateList", this.PropertySerializerMap["actualFiniteStateList"](iteration.ActualFiniteStateList.OrderBy(x => x, this.guidComparer))},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), iteration.ClassKind))},
                {"defaultOption", this.PropertySerializerMap["defaultOption"](iteration.DefaultOption)},
                {"diagramCanvas", this.PropertySerializerMap["diagramCanvas"](iteration.DiagramCanvas.OrderBy(x => x, this.guidComparer))},
                {"domainFileStore", this.PropertySerializerMap["domainFileStore"](iteration.DomainFileStore.OrderBy(x => x, this.guidComparer))},
                {"element", this.PropertySerializerMap["element"](iteration.Element.OrderBy(x => x, this.guidComparer))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](iteration.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](iteration.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"externalIdentifierMap", this.PropertySerializerMap["externalIdentifierMap"](iteration.ExternalIdentifierMap.OrderBy(x => x, this.guidComparer))},
                {"goal", this.PropertySerializerMap["goal"](iteration.Goal.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](iteration.Iid)},
                {"iterationSetup", this.PropertySerializerMap["iterationSetup"](iteration.IterationSetup)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](iteration.ModifiedOn)},
                {"option", this.PropertySerializerMap["option"](iteration.Option.OrderBy(x => x, this.orderedItemComparer))},
                {"possibleFiniteStateList", this.PropertySerializerMap["possibleFiniteStateList"](iteration.PossibleFiniteStateList.OrderBy(x => x, this.guidComparer))},
                {"publication", this.PropertySerializerMap["publication"](iteration.Publication.OrderBy(x => x, this.guidComparer))},
                {"relationship", this.PropertySerializerMap["relationship"](iteration.Relationship.OrderBy(x => x, this.guidComparer))},
                {"requirementsSpecification", this.PropertySerializerMap["requirementsSpecification"](iteration.RequirementsSpecification.OrderBy(x => x, this.guidComparer))},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](iteration.RevisionNumber)},
                {"ruleVerificationList", this.PropertySerializerMap["ruleVerificationList"](iteration.RuleVerificationList.OrderBy(x => x, this.guidComparer))},
                {"sharedDiagramStyle", this.PropertySerializerMap["sharedDiagramStyle"](iteration.SharedDiagramStyle.OrderBy(x => x, this.guidComparer))},
                {"sourceIterationIid", this.PropertySerializerMap["sourceIterationIid"](iteration.SourceIterationIid)},
                {"stakeholder", this.PropertySerializerMap["stakeholder"](iteration.Stakeholder.OrderBy(x => x, this.guidComparer))},
                {"stakeholderValue", this.PropertySerializerMap["stakeholderValue"](iteration.StakeholderValue.OrderBy(x => x, this.guidComparer))},
                {"stakeholderValueMap", this.PropertySerializerMap["stakeholderValueMap"](iteration.StakeholderValueMap.OrderBy(x => x, this.guidComparer))},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](iteration.ThingPreference)},
                {"topElement", this.PropertySerializerMap["topElement"](iteration.TopElement)},
                {"valueGroup", this.PropertySerializerMap["valueGroup"](iteration.ValueGroup.OrderBy(x => x, this.guidComparer))},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Iteration"/> class.
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

            if (thing is not Iteration iteration)
            {
                throw new InvalidOperationException("The thing is not a Iteration.");
            }

            return this.Serialize(iteration);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
