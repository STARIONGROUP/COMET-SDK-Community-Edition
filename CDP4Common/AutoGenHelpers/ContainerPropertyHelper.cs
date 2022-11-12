// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerPropertyHelper.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.Polyfills;

    /// <summary>
    /// The purpose of the <see cref="ContainerPropertyHelper"/> class is to provide static methods to compute
    /// the container property name of a <see cref="Thing"/> based on it's <see cref="ClassKind"/>
    /// </summary>
    public static class ContainerPropertyHelper
    {
        /// <summary>
        /// The dictionary that contains for each <see cref="ClassKind"/> the KeyValuePair {Class, Property} of the Container of it's direct container
        /// </summary>
        private static readonly Dictionary<string, KeyValuePair<string, string>> ContainerPropertyMap = new Dictionary<string, KeyValuePair<string, string>>
        {
            { "ActionItem", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "ActualFiniteState", new KeyValuePair<string, string>("ActualFiniteStateList", "actualState") },
            { "ActualFiniteStateList", new KeyValuePair<string, string>("Iteration", "actualFiniteStateList") },
            { "Alias", new KeyValuePair<string, string>("DefinedThing", "alias") },
            { "AndExpression", new KeyValuePair<string, string>("ParametricConstraint", "expression") },
            { "Approval", new KeyValuePair<string, string>("ModellingAnnotationItem", "approvedBy") },
            { "ArrayParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "BinaryNote", new KeyValuePair<string, string>("Page", "note") },
            { "BinaryRelationship", new KeyValuePair<string, string>("Iteration", "relationship") },
            { "BinaryRelationshipRule", new KeyValuePair<string, string>("ReferenceDataLibrary", "rule") },
            { "Book", new KeyValuePair<string, string>("EngineeringModel", "book") },
            { "BooleanExpression", new KeyValuePair<string, string>("ParametricConstraint", "expression") },
            { "BooleanParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "Bounds", new KeyValuePair<string, string>("DiagramElementContainer", "bounds") },
            { "BuiltInRuleVerification", new KeyValuePair<string, string>("RuleVerificationList", "ruleVerification") },
            { "Category", new KeyValuePair<string, string>("ReferenceDataLibrary", "definedCategory") },
            { "ChangeProposal", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "ChangeRequest", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "Citation", new KeyValuePair<string, string>("Definition", "citation") },
            { "Color", new KeyValuePair<string, string>("DiagrammingStyle", "usedColor") },
            { "CommonFileStore", new KeyValuePair<string, string>("EngineeringModel", "commonFileStore") },
            { "CompoundParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "Constant", new KeyValuePair<string, string>("ReferenceDataLibrary", "constant") },
            { "ContractChangeNotice", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "ContractDeviation", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "ConversionBasedUnit", new KeyValuePair<string, string>("ReferenceDataLibrary", "unit") },
            { "CyclicRatioScale", new KeyValuePair<string, string>("ReferenceDataLibrary", "scale") },
            { "DateParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "DateTimeParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "DecompositionRule", new KeyValuePair<string, string>("ReferenceDataLibrary", "rule") },
            { "Definition", new KeyValuePair<string, string>("DefinedThing", "definition") },
            { "DependentParameterTypeAssignment", new KeyValuePair<string, string>("SampledFunctionParameterType", "dependentParameterType") },
            { "DerivedQuantityKind", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "DerivedUnit", new KeyValuePair<string, string>("ReferenceDataLibrary", "unit") },
            { "DiagramCanvas", new KeyValuePair<string, string>("Iteration", "diagramCanvas") },
            { "DiagramEdge", new KeyValuePair<string, string>("DiagramElementContainer", "diagramElement") },
            { "DiagramElementThing", new KeyValuePair<string, string>("DiagramElementContainer", "diagramElement") },
            { "DiagramObject", new KeyValuePair<string, string>("DiagramElementContainer", "diagramElement") },
            { "DiagramShape", new KeyValuePair<string, string>("DiagramElementContainer", "diagramElement") },
            { "DomainFileStore", new KeyValuePair<string, string>("Iteration", "domainFileStore") },
            { "DomainOfExpertise", new KeyValuePair<string, string>("SiteDirectory", "domain") },
            { "DomainOfExpertiseGroup", new KeyValuePair<string, string>("SiteDirectory", "domainGroup") },
            { "ElementDefinition", new KeyValuePair<string, string>("Iteration", "element") },
            { "ElementUsage", new KeyValuePair<string, string>("ElementDefinition", "containedElement") },
            { "EmailAddress", new KeyValuePair<string, string>("Person", "emailAddress") },
            { "EngineeringModel", new KeyValuePair<string, string>("EngineeringModel", "EngineeringModel") },
            { "EngineeringModelDataDiscussionItem", new KeyValuePair<string, string>("EngineeringModelDataAnnotation", "discussion") },
            { "EngineeringModelDataNote", new KeyValuePair<string, string>("EngineeringModel", "genericNote") },
            { "EngineeringModelSetup", new KeyValuePair<string, string>("SiteDirectory", "model") },
            { "EnumerationParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "EnumerationValueDefinition", new KeyValuePair<string, string>("EnumerationParameterType", "valueDefinition") },
            { "ExclusiveOrExpression", new KeyValuePair<string, string>("ParametricConstraint", "expression") },
            { "ExternalIdentifierMap", new KeyValuePair<string, string>("Iteration", "externalIdentifierMap") },
            { "File", new KeyValuePair<string, string>("FileStore", "file") },
            { "FileRevision", new KeyValuePair<string, string>("File", "fileRevision") },
            { "FileType", new KeyValuePair<string, string>("ReferenceDataLibrary", "fileType") },
            { "Folder", new KeyValuePair<string, string>("FileStore", "folder") },
            { "Glossary", new KeyValuePair<string, string>("ReferenceDataLibrary", "glossary") },
            { "Goal", new KeyValuePair<string, string>("Iteration", "goal") },
            { "HyperLink", new KeyValuePair<string, string>("DefinedThing", "hyperLink") },
            { "IdCorrespondence", new KeyValuePair<string, string>("ExternalIdentifierMap", "correspondence") },
            { "IndependentParameterTypeAssignment", new KeyValuePair<string, string>("SampledFunctionParameterType", "independentParameterType") },
            { "IntervalScale", new KeyValuePair<string, string>("ReferenceDataLibrary", "scale") },
            { "Iteration", new KeyValuePair<string, string>("EngineeringModel", "iteration") },
            { "IterationSetup", new KeyValuePair<string, string>("EngineeringModelSetup", "iterationSetup") },
            { "LinearConversionUnit", new KeyValuePair<string, string>("ReferenceDataLibrary", "unit") },
            { "LogarithmicScale", new KeyValuePair<string, string>("ReferenceDataLibrary", "scale") },
            { "LogEntryChangelogItem", new KeyValuePair<string, string>("LogEntry", "logEntryChangelogItem") },
            { "MappingToReferenceScale", new KeyValuePair<string, string>("MeasurementScale", "mappingToReferenceScale") },
            { "MeasurementScale", new KeyValuePair<string, string>("ReferenceDataLibrary", "scale") },
            { "MeasurementUnit", new KeyValuePair<string, string>("ReferenceDataLibrary", "unit") },
            { "ModellingAnnotationItem", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "ModellingThingReference", new KeyValuePair<string, string>("EngineeringModelDataAnnotation", "relatedThing") },
            { "ModelLogEntry", new KeyValuePair<string, string>("EngineeringModel", "logEntry") },
            { "ModelReferenceDataLibrary", new KeyValuePair<string, string>("EngineeringModelSetup", "requiredRdl") },
            { "MultiRelationship", new KeyValuePair<string, string>("Iteration", "relationship") },
            { "MultiRelationshipRule", new KeyValuePair<string, string>("ReferenceDataLibrary", "rule") },
            { "NaturalLanguage", new KeyValuePair<string, string>("SiteDirectory", "naturalLanguage") },
            { "NestedElement", new KeyValuePair<string, string>("Option", "nestedElement") },
            { "NestedParameter", new KeyValuePair<string, string>("NestedElement", "nestedParameter") },
            { "Note", new KeyValuePair<string, string>("Page", "note") },
            { "NotExpression", new KeyValuePair<string, string>("ParametricConstraint", "expression") },
            { "Option", new KeyValuePair<string, string>("Iteration", "option") },
            { "OrdinalScale", new KeyValuePair<string, string>("ReferenceDataLibrary", "scale") },
            { "OrExpression", new KeyValuePair<string, string>("ParametricConstraint", "expression") },
            { "Organization", new KeyValuePair<string, string>("SiteDirectory", "organization") },
            { "OrganizationalParticipant", new KeyValuePair<string, string>("EngineeringModelSetup", "organizationalParticipant") },
            { "OwnedStyle", new KeyValuePair<string, string>("DiagramElementThing", "localStyle") },
            { "Page", new KeyValuePair<string, string>("Section", "page") },
            { "Parameter", new KeyValuePair<string, string>("ElementDefinition", "parameter") },
            { "ParameterGroup", new KeyValuePair<string, string>("ElementDefinition", "parameterGroup") },
            { "ParameterizedCategoryRule", new KeyValuePair<string, string>("ReferenceDataLibrary", "rule") },
            { "ParameterOverride", new KeyValuePair<string, string>("ElementUsage", "parameterOverride") },
            { "ParameterOverrideValueSet", new KeyValuePair<string, string>("ParameterOverride", "valueSet") },
            { "ParameterSubscription", new KeyValuePair<string, string>("ParameterOrOverrideBase", "parameterSubscription") },
            { "ParameterSubscriptionValueSet", new KeyValuePair<string, string>("ParameterSubscription", "valueSet") },
            { "ParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "ParameterTypeComponent", new KeyValuePair<string, string>("CompoundParameterType", "component") },
            { "ParameterValueSet", new KeyValuePair<string, string>("Parameter", "valueSet") },
            { "ParametricConstraint", new KeyValuePair<string, string>("Requirement", "parametricConstraint") },
            { "Participant", new KeyValuePair<string, string>("EngineeringModelSetup", "participant") },
            { "ParticipantPermission", new KeyValuePair<string, string>("ParticipantRole", "participantPermission") },
            { "ParticipantRole", new KeyValuePair<string, string>("SiteDirectory", "participantRole") },
            { "Person", new KeyValuePair<string, string>("SiteDirectory", "person") },
            { "PersonPermission", new KeyValuePair<string, string>("PersonRole", "personPermission") },
            { "PersonRole", new KeyValuePair<string, string>("SiteDirectory", "personRole") },
            { "Point", new KeyValuePair<string, string>("DiagramEdge", "point") },
            { "PossibleFiniteState", new KeyValuePair<string, string>("PossibleFiniteStateList", "possibleState") },
            { "PossibleFiniteStateList", new KeyValuePair<string, string>("Iteration", "possibleFiniteStateList") },
            { "PrefixedUnit", new KeyValuePair<string, string>("ReferenceDataLibrary", "unit") },
            { "Publication", new KeyValuePair<string, string>("Iteration", "publication") },
            { "QuantityKind", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "QuantityKindFactor", new KeyValuePair<string, string>("DerivedQuantityKind", "quantityKindFactor") },
            { "RatioScale", new KeyValuePair<string, string>("ReferenceDataLibrary", "scale") },
            { "ReferencerRule", new KeyValuePair<string, string>("ReferenceDataLibrary", "rule") },
            { "ReferenceSource", new KeyValuePair<string, string>("ReferenceDataLibrary", "referenceSource") },
            { "RelationalExpression", new KeyValuePair<string, string>("ParametricConstraint", "expression") },
            { "Relationship", new KeyValuePair<string, string>("Iteration", "relationship") },
            { "RelationshipParameterValue", new KeyValuePair<string, string>("Relationship", "parameterValue") },
            { "RequestForDeviation", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "RequestForWaiver", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "Requirement", new KeyValuePair<string, string>("RequirementsSpecification", "requirement") },
            { "RequirementsContainerParameterValue", new KeyValuePair<string, string>("RequirementsContainer", "parameterValue") },
            { "RequirementsGroup", new KeyValuePair<string, string>("RequirementsContainer", "group") },
            { "RequirementsSpecification", new KeyValuePair<string, string>("Iteration", "requirementsSpecification") },
            { "ReviewItemDiscrepancy", new KeyValuePair<string, string>("EngineeringModel", "modellingAnnotation") },
            { "Rule", new KeyValuePair<string, string>("ReferenceDataLibrary", "rule") },
            { "RuleVerification", new KeyValuePair<string, string>("RuleVerificationList", "ruleVerification") },
            { "RuleVerificationList", new KeyValuePair<string, string>("Iteration", "ruleVerificationList") },
            { "RuleViolation", new KeyValuePair<string, string>("RuleVerification", "violation") },
            { "SampledFunctionParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "ScalarParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "ScaleReferenceQuantityValue", new KeyValuePair<string, string>("LogarithmicScale", "referenceQuantityValue") },
            { "ScaleValueDefinition", new KeyValuePair<string, string>("MeasurementScale", "valueDefinition") },
            { "Section", new KeyValuePair<string, string>("Book", "section") },
            { "SharedStyle", new KeyValuePair<string, string>("Iteration", "sharedDiagramStyle") },
            { "SimpleParameterValue", new KeyValuePair<string, string>("SimpleParameterizableThing", "parameterValue") },
            { "SimpleQuantityKind", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "SimpleUnit", new KeyValuePair<string, string>("ReferenceDataLibrary", "unit") },
            { "SiteDirectory", new KeyValuePair<string, string>("SiteDirectory", "SiteDirectory") },
            { "SiteDirectoryDataAnnotation", new KeyValuePair<string, string>("SiteDirectory", "annotation") },
            { "SiteDirectoryDataDiscussionItem", new KeyValuePair<string, string>("SiteDirectoryDataAnnotation", "discussion") },
            { "SiteDirectoryThingReference", new KeyValuePair<string, string>("SiteDirectoryDataAnnotation", "relatedThing") },
            { "SiteLogEntry", new KeyValuePair<string, string>("SiteDirectory", "logEntry") },
            { "SiteReferenceDataLibrary", new KeyValuePair<string, string>("SiteDirectory", "siteReferenceDataLibrary") },
            { "Solution", new KeyValuePair<string, string>("ReviewItemDiscrepancy", "solution") },
            { "SpecializedQuantityKind", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "Stakeholder", new KeyValuePair<string, string>("Iteration", "stakeholder") },
            { "StakeholderValue", new KeyValuePair<string, string>("Iteration", "stakeholderValue") },
            { "StakeHolderValueMap", new KeyValuePair<string, string>("Iteration", "stakeholderValueMap") },
            { "StakeHolderValueMapSettings", new KeyValuePair<string, string>("StakeHolderValueMap", "settings") },
            { "TelephoneNumber", new KeyValuePair<string, string>("Person", "telephoneNumber") },
            { "Term", new KeyValuePair<string, string>("Glossary", "term") },
            { "TextParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "TextualNote", new KeyValuePair<string, string>("Page", "note") },
            { "TimeOfDayParameterType", new KeyValuePair<string, string>("ReferenceDataLibrary", "parameterType") },
            { "UnitFactor", new KeyValuePair<string, string>("DerivedUnit", "unitFactor") },
            { "UnitPrefix", new KeyValuePair<string, string>("ReferenceDataLibrary", "unitPrefix") },
            { "UserPreference", new KeyValuePair<string, string>("Person", "userPreference") },
            { "UserRuleVerification", new KeyValuePair<string, string>("RuleVerificationList", "ruleVerification") },
            { "ValueGroup", new KeyValuePair<string, string>("Iteration", "valueGroup") }
        };

        /// <summary>
        /// Returns the name of the property of the container class that contains the provided <see cref="ClassKind"/>
        /// </summary>
        /// <param name="classKind">
        /// The string representing the <see cref="ClassKind"/>
        /// </param>
        /// <returns>
        /// The name of the container property
        /// </returns>
        public static string ContainerPropertyName(string classKind)
        {
            KeyValuePair<string, string> result;
            if (ContainerPropertyMap.TryGetValue(classKind, out result))
            {
                return result.Value;
            }
            throw new ArgumentException(string.Format("The ClassKind {0} does not exist in the CDP4Common library", classKind));
        }

        /// <summary>
        /// Returns the name of the property of the container class that contains the provided <see cref="ClassKind"/>
        /// </summary>
        /// <param name="classKind">
        /// The <see cref="ClassKind"/>
        /// </param>
        /// <returns>
        /// The name of the container property
        /// </returns>
        public static string ContainerPropertyName(ClassKind classKind)
        {
            return ContainerPropertyName(classKind.ToString());
        }

        /// <summary>
        /// Returns the name of the container class that contains the provided <see cref="ClassKind"/>
        /// </summary>
        /// <param name="classKind">
        /// The string representing the <see cref="ClassKind"/>
        /// </param>
        /// <returns>
        /// The name of the container class
        /// </returns>
        public static string ContainerClassName(string classKind)
        {
            KeyValuePair<string, string> result;
            if (ContainerPropertyMap.TryGetValue(classKind, out result))
            {
                return result.Key;
            }
            throw new ArgumentException(string.Format("The ClassKind {0} does not exist in the CDP4Common library", classKind));
        }

        /// <summary>
        /// Returns the name of the container class that contains the provided <see cref="ClassKind"/>
        /// </summary>
        /// <param name="classKind">
        /// the <see cref="ClassKind"/>
        /// </param>
        /// <returns>
        /// The name of the container class
        /// </returns>
        public static string ContainerClassName(ClassKind classKind)
        {
            return ContainerClassName(classKind.ToString());
        }

        /// <summary>
        /// Returns the <see cref="ClassKind"/> from the container property
        /// </summary>
        /// <param name="containerProperty">the provided container property</param>
        /// <returns>the <see cref="ClassKind"/></returns>
        public static ClassKind ClassKindFromContainerProperty(string containerProperty)
        {
            var pairs = ContainerPropertyMap.Where(p => p.Value.Value == containerProperty).ToList();
            if (pairs.Count() != 0)
            {
                //get the abstract class if a container property name is in the dictionary multiple time
                var pair = (pairs.Count() == 1) ? pairs.Single() : pairs.SingleOrDefault(p => Type.GetType("CDP4Common.DTO." + p.Key).QueryIsAbstract());
                return (ClassKind)Enum.Parse(typeof(ClassKind), pair.Key, true);
            }
            throw new ArgumentException(string.Format("the container property {0} does not exist", containerProperty));
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
