// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
    /// The purpose of the <see cref="IterationSerializer"/> class is to provide a <see cref="Iteration"/> specific serializer
    /// </summary>
    public class IterationSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actualFiniteStateList", actualFiniteStateList => new JArray(actualFiniteStateList) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "defaultOption", defaultOption => new JValue(defaultOption) },
            { "diagramCanvas", diagramCanvas => new JArray(diagramCanvas) },
            { "domainFileStore", domainFileStore => new JArray(domainFileStore) },
            { "element", element => new JArray(element) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "externalIdentifierMap", externalIdentifierMap => new JArray(externalIdentifierMap) },
            { "goal", goal => new JArray(goal) },
            { "iid", iid => new JValue(iid) },
            { "iterationSetup", iterationSetup => new JValue(iterationSetup) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "option", option => new JArray(((IEnumerable)option).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "possibleFiniteStateList", possibleFiniteStateList => new JArray(possibleFiniteStateList) },
            { "publication", publication => new JArray(publication) },
            { "relationship", relationship => new JArray(relationship) },
            { "requirementsSpecification", requirementsSpecification => new JArray(requirementsSpecification) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "ruleVerificationList", ruleVerificationList => new JArray(ruleVerificationList) },
            { "sharedDiagramStyle", sharedDiagramStyle => new JArray(sharedDiagramStyle) },
            { "sourceIterationIid", sourceIterationIid => new JValue(sourceIterationIid) },
            { "stakeholder", stakeholder => new JArray(stakeholder) },
            { "stakeholderValue", stakeholderValue => new JArray(stakeholderValue) },
            { "stakeholderValueMap", stakeholderValueMap => new JArray(stakeholderValueMap) },
            { "topElement", topElement => new JValue(topElement) },
            { "valueGroup", valueGroup => new JArray(valueGroup) },
        };

        /// <summary>
        /// Serialize the <see cref="Iteration"/>
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Iteration iteration)
        {
            var jsonObject = new JObject();
            jsonObject.Add("actualFiniteStateList", this.PropertySerializerMap["actualFiniteStateList"](iteration.ActualFiniteStateList.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), iteration.ClassKind)));
            jsonObject.Add("defaultOption", this.PropertySerializerMap["defaultOption"](iteration.DefaultOption));
            jsonObject.Add("diagramCanvas", this.PropertySerializerMap["diagramCanvas"](iteration.DiagramCanvas.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("domainFileStore", this.PropertySerializerMap["domainFileStore"](iteration.DomainFileStore.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("element", this.PropertySerializerMap["element"](iteration.Element.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](iteration.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](iteration.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("externalIdentifierMap", this.PropertySerializerMap["externalIdentifierMap"](iteration.ExternalIdentifierMap.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("goal", this.PropertySerializerMap["goal"](iteration.Goal.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](iteration.Iid));
            jsonObject.Add("iterationSetup", this.PropertySerializerMap["iterationSetup"](iteration.IterationSetup));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](iteration.ModifiedOn));
            jsonObject.Add("option", this.PropertySerializerMap["option"](iteration.Option.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("possibleFiniteStateList", this.PropertySerializerMap["possibleFiniteStateList"](iteration.PossibleFiniteStateList.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("publication", this.PropertySerializerMap["publication"](iteration.Publication.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("relationship", this.PropertySerializerMap["relationship"](iteration.Relationship.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("requirementsSpecification", this.PropertySerializerMap["requirementsSpecification"](iteration.RequirementsSpecification.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](iteration.RevisionNumber));
            jsonObject.Add("ruleVerificationList", this.PropertySerializerMap["ruleVerificationList"](iteration.RuleVerificationList.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("sharedDiagramStyle", this.PropertySerializerMap["sharedDiagramStyle"](iteration.SharedDiagramStyle.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("sourceIterationIid", this.PropertySerializerMap["sourceIterationIid"](iteration.SourceIterationIid));
            jsonObject.Add("stakeholder", this.PropertySerializerMap["stakeholder"](iteration.Stakeholder.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("stakeholderValue", this.PropertySerializerMap["stakeholderValue"](iteration.StakeholderValue.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("stakeholderValueMap", this.PropertySerializerMap["stakeholderValueMap"](iteration.StakeholderValueMap.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("topElement", this.PropertySerializerMap["topElement"](iteration.TopElement));
            jsonObject.Add("valueGroup", this.PropertySerializerMap["valueGroup"](iteration.ValueGroup.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Iteration"/> class.
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

            var iteration = thing as Iteration;
            if (iteration == null)
            {
                throw new InvalidOperationException("The thing is not a Iteration.");
            }

            return this.Serialize(iteration);
        }
    }
}
