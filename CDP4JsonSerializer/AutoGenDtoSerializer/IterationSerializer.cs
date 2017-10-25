// --------------------------------------------------------------------------------------------------------------------
// <copyright file "IterationSerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Serializer class. Any manual changes on this file will be overwritten!
// </summary>
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
    public class IterationSerializer : IThingSerializer
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
            jsonObject.Add("actualFiniteStateList", this.PropertySerializerMap["actualFiniteStateList"](iteration.ActualFiniteStateList));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), iteration.ClassKind)));
            jsonObject.Add("defaultOption", this.PropertySerializerMap["defaultOption"](iteration.DefaultOption));
            jsonObject.Add("diagramCanvas", this.PropertySerializerMap["diagramCanvas"](iteration.DiagramCanvas));
            jsonObject.Add("domainFileStore", this.PropertySerializerMap["domainFileStore"](iteration.DomainFileStore));
            jsonObject.Add("element", this.PropertySerializerMap["element"](iteration.Element));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](iteration.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](iteration.ExcludedPerson));
            jsonObject.Add("externalIdentifierMap", this.PropertySerializerMap["externalIdentifierMap"](iteration.ExternalIdentifierMap));
            jsonObject.Add("goal", this.PropertySerializerMap["goal"](iteration.Goal));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](iteration.Iid));
            jsonObject.Add("iterationSetup", this.PropertySerializerMap["iterationSetup"](iteration.IterationSetup));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](iteration.ModifiedOn));
            jsonObject.Add("option", this.PropertySerializerMap["option"](iteration.Option));
            jsonObject.Add("possibleFiniteStateList", this.PropertySerializerMap["possibleFiniteStateList"](iteration.PossibleFiniteStateList));
            jsonObject.Add("publication", this.PropertySerializerMap["publication"](iteration.Publication));
            jsonObject.Add("relationship", this.PropertySerializerMap["relationship"](iteration.Relationship));
            jsonObject.Add("requirementsSpecification", this.PropertySerializerMap["requirementsSpecification"](iteration.RequirementsSpecification));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](iteration.RevisionNumber));
            jsonObject.Add("ruleVerificationList", this.PropertySerializerMap["ruleVerificationList"](iteration.RuleVerificationList));
            jsonObject.Add("sharedDiagramStyle", this.PropertySerializerMap["sharedDiagramStyle"](iteration.SharedDiagramStyle));
            jsonObject.Add("sourceIterationIid", this.PropertySerializerMap["sourceIterationIid"](iteration.SourceIterationIid));
            jsonObject.Add("stakeholder", this.PropertySerializerMap["stakeholder"](iteration.Stakeholder));
            jsonObject.Add("stakeholderValue", this.PropertySerializerMap["stakeholderValue"](iteration.StakeholderValue));
            jsonObject.Add("stakeholderValueMap", this.PropertySerializerMap["stakeholderValueMap"](iteration.StakeholderValueMap));
            jsonObject.Add("topElement", this.PropertySerializerMap["topElement"](iteration.TopElement));
            jsonObject.Add("valueGroup", this.PropertySerializerMap["valueGroup"](iteration.ValueGroup));
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
                throw new ArgumentNullException("thing");
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
