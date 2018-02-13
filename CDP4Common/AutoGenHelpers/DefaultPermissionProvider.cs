#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultPermissionProvider.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
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
#endregion

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;

    /// <summary>
    /// A utility class that supplies common functionalities to the Service layer.
    /// </summary>
    public class DefaultPermissionProvider : IDefaultPermissionProvider
    {
        /// <summary>
        /// The type to default participant permission map.
        /// </summary>
        private readonly Dictionary<string, ParticipantAccessRightKind> participantPermissionMap = new Dictionary<string, ParticipantAccessRightKind>
        {
            { "ActionItem", ParticipantAccessRightKind.NONE },
            { "ActualFiniteState", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ActualFiniteStateList", ParticipantAccessRightKind.NONE },
            { "Alias", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "AndExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Approval", ParticipantAccessRightKind.NONE },
            { "ArrayParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "BinaryNote", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "BinaryRelationship", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "BinaryRelationshipRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Book", ParticipantAccessRightKind.NONE },
            { "BooleanExpression", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "BooleanParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Bounds", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "BuiltInRuleVerification", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Category", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ChangeProposal", ParticipantAccessRightKind.NONE },
            { "ChangeRequest", ParticipantAccessRightKind.NONE },
            { "Citation", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Color", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "CommonFileStore", ParticipantAccessRightKind.NONE },
            { "CompoundParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Constant", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ContractChangeNotice", ParticipantAccessRightKind.NONE },
            { "ContractDeviation", ParticipantAccessRightKind.NONE },
            { "ConversionBasedUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "CyclicRatioScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DateParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DateTimeParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DecompositionRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DefinedThing", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Definition", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "DerivedQuantityKind", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DerivedUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramCanvas", ParticipantAccessRightKind.NONE },
            { "DiagramEdge", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramElementContainer", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DiagramElementThing", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "DiagrammingStyle", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DiagramObject", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramShape", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramThingBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DiscussionItem", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DomainFileStore", ParticipantAccessRightKind.NONE },
            { "DomainOfExpertise", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DomainOfExpertiseGroup", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ElementBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ElementDefinition", ParticipantAccessRightKind.NONE },
            { "ElementUsage", ParticipantAccessRightKind.NONE },
            { "EmailAddress", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModel", ParticipantAccessRightKind.NONE },
            { "EngineeringModelDataAnnotation", ParticipantAccessRightKind.NONE },
            { "EngineeringModelDataDiscussionItem", ParticipantAccessRightKind.NONE },
            { "EngineeringModelDataNote", ParticipantAccessRightKind.NONE },
            { "EngineeringModelSetup", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "EnumerationParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "EnumerationValueDefinition", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ExclusiveOrExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ExternalIdentifierMap", ParticipantAccessRightKind.NONE },
            { "File", ParticipantAccessRightKind.NONE },
            { "FileRevision", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "FileStore", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "FileType", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Folder", ParticipantAccessRightKind.NONE },
            { "GenericAnnotation", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Glossary", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Goal", ParticipantAccessRightKind.NONE },
            { "HyperLink", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "IdCorrespondence", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "IntervalScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Iteration", ParticipantAccessRightKind.NONE },
            { "IterationSetup", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "LinearConversionUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "LogarithmicScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "MappingToReferenceScale", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "MeasurementScale", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "MeasurementUnit", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ModellingAnnotationItem", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ModellingThingReference", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ModelLogEntry", ParticipantAccessRightKind.NONE },
            { "ModelReferenceDataLibrary", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "MultiRelationship", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "MultiRelationshipRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "NaturalLanguage", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "NestedElement", ParticipantAccessRightKind.NONE },
            { "NestedParameter", ParticipantAccessRightKind.NONE },
            { "Note", ParticipantAccessRightKind.NONE },
            { "NotExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Option", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "OrdinalScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "OrExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Organization", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "OwnedStyle", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Page", ParticipantAccessRightKind.NONE },
            { "Parameter", ParticipantAccessRightKind.NONE },
            { "ParameterBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParameterGroup", ParticipantAccessRightKind.NONE },
            { "ParameterizedCategoryRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ParameterOrOverrideBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParameterOverride", ParticipantAccessRightKind.NONE },
            { "ParameterOverrideValueSet", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterSubscription", ParticipantAccessRightKind.NONE },
            { "ParameterSubscriptionValueSet", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterType", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterTypeComponent", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterValue", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParameterValueSet", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterValueSetBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParametricConstraint", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Participant", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParticipantPermission", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParticipantRole", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Person", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "PersonPermission", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "PersonRole", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Point", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "PossibleFiniteState", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "PossibleFiniteStateList", ParticipantAccessRightKind.NONE },
            { "PrefixedUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Publication", ParticipantAccessRightKind.NONE },
            { "QuantityKind", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "QuantityKindFactor", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RatioScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ReferenceDataLibrary", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ReferencerRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ReferenceSource", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RelationalExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Relationship", ParticipantAccessRightKind.NONE },
            { "RelationshipParameterValue", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RequestForDeviation", ParticipantAccessRightKind.NONE },
            { "RequestForWaiver", ParticipantAccessRightKind.NONE },
            { "Requirement", ParticipantAccessRightKind.NONE },
            { "RequirementsContainer", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "RequirementsContainerParameterValue", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RequirementsGroup", ParticipantAccessRightKind.NONE },
            { "RequirementsSpecification", ParticipantAccessRightKind.NONE },
            { "ReviewItemDiscrepancy", ParticipantAccessRightKind.NONE },
            { "Rule", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RuleVerification", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RuleVerificationList", ParticipantAccessRightKind.NONE },
            { "RuleViolation", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ScalarParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ScaleReferenceQuantityValue", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ScaleValueDefinition", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Section", ParticipantAccessRightKind.NONE },
            { "SharedStyle", ParticipantAccessRightKind.NONE },
            { "SimpleParameterizableThing", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SimpleParameterValue", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "SimpleQuantityKind", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "SimpleUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "SiteDirectory", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteDirectoryDataAnnotation", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteDirectoryDataDiscussionItem", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteDirectoryThingReference", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteLogEntry", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteReferenceDataLibrary", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Solution", ParticipantAccessRightKind.NONE },
            { "SpecializedQuantityKind", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Stakeholder", ParticipantAccessRightKind.NONE },
            { "StakeholderValue", ParticipantAccessRightKind.NONE },
            { "StakeHolderValueMap", ParticipantAccessRightKind.NONE },
            { "StakeHolderValueMapSettings", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "TelephoneNumber", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Term", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "TextParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "TextualNote", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Thing", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ThingReference", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "TimeOfDayParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "TopContainer", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "UnitFactor", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "UnitPrefix", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "UserPreference", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "UserRuleVerification", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ValueGroup", ParticipantAccessRightKind.NONE },
        };

        /// <summary>
        /// The type to default participant permission map.
        /// </summary>
        private readonly Dictionary<string, PersonAccessRightKind> personPermissionMap = new Dictionary<string, PersonAccessRightKind>
        {
            { "ActionItem", PersonAccessRightKind.NOT_APPLICABLE },
            { "ActualFiniteState", PersonAccessRightKind.NOT_APPLICABLE },
            { "ActualFiniteStateList", PersonAccessRightKind.NOT_APPLICABLE },
            { "Alias", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "AndExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "Approval", PersonAccessRightKind.NOT_APPLICABLE },
            { "ArrayParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "BinaryNote", PersonAccessRightKind.NOT_APPLICABLE },
            { "BinaryRelationship", PersonAccessRightKind.NOT_APPLICABLE },
            { "BinaryRelationshipRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Book", PersonAccessRightKind.NOT_APPLICABLE },
            { "BooleanExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "BooleanParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Bounds", PersonAccessRightKind.NOT_APPLICABLE },
            { "BuiltInRuleVerification", PersonAccessRightKind.NOT_APPLICABLE },
            { "Category", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ChangeProposal", PersonAccessRightKind.NOT_APPLICABLE },
            { "ChangeRequest", PersonAccessRightKind.NOT_APPLICABLE },
            { "Citation", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Color", PersonAccessRightKind.NOT_APPLICABLE },
            { "CommonFileStore", PersonAccessRightKind.NOT_APPLICABLE },
            { "CompoundParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Constant", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ContractChangeNotice", PersonAccessRightKind.NOT_APPLICABLE },
            { "ContractDeviation", PersonAccessRightKind.NOT_APPLICABLE },
            { "ConversionBasedUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "CyclicRatioScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DateParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DateTimeParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DecompositionRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DefinedThing", PersonAccessRightKind.NOT_APPLICABLE },
            { "Definition", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "DerivedQuantityKind", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DerivedUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramCanvas", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramEdge", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramElementContainer", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramElementThing", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagrammingStyle", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramObject", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramShape", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramThingBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiscussionItem", PersonAccessRightKind.NOT_APPLICABLE },
            { "DomainFileStore", PersonAccessRightKind.NOT_APPLICABLE },
            { "DomainOfExpertise", PersonAccessRightKind.NONE },
            { "DomainOfExpertiseGroup", PersonAccessRightKind.NONE },
            { "ElementBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "ElementDefinition", PersonAccessRightKind.NOT_APPLICABLE },
            { "ElementUsage", PersonAccessRightKind.NOT_APPLICABLE },
            { "EmailAddress", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "EngineeringModel", PersonAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModelDataAnnotation", PersonAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModelDataDiscussionItem", PersonAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModelDataNote", PersonAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModelSetup", PersonAccessRightKind.NONE },
            { "EnumerationParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "EnumerationValueDefinition", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ExclusiveOrExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "ExternalIdentifierMap", PersonAccessRightKind.NOT_APPLICABLE },
            { "File", PersonAccessRightKind.NOT_APPLICABLE },
            { "FileRevision", PersonAccessRightKind.NOT_APPLICABLE },
            { "FileStore", PersonAccessRightKind.NOT_APPLICABLE },
            { "FileType", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Folder", PersonAccessRightKind.NOT_APPLICABLE },
            { "GenericAnnotation", PersonAccessRightKind.NOT_APPLICABLE },
            { "Glossary", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Goal", PersonAccessRightKind.NOT_APPLICABLE },
            { "HyperLink", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "IdCorrespondence", PersonAccessRightKind.NOT_APPLICABLE },
            { "IntervalScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Iteration", PersonAccessRightKind.NOT_APPLICABLE },
            { "IterationSetup", PersonAccessRightKind.NONE },
            { "LinearConversionUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "LogarithmicScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "MappingToReferenceScale", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "MeasurementScale", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "MeasurementUnit", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ModellingAnnotationItem", PersonAccessRightKind.NOT_APPLICABLE },
            { "ModellingThingReference", PersonAccessRightKind.NOT_APPLICABLE },
            { "ModelLogEntry", PersonAccessRightKind.NOT_APPLICABLE },
            { "ModelReferenceDataLibrary", PersonAccessRightKind.NONE },
            { "MultiRelationship", PersonAccessRightKind.NOT_APPLICABLE },
            { "MultiRelationshipRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "NaturalLanguage", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "NestedElement", PersonAccessRightKind.NOT_APPLICABLE },
            { "NestedParameter", PersonAccessRightKind.NOT_APPLICABLE },
            { "Note", PersonAccessRightKind.NOT_APPLICABLE },
            { "NotExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "Option", PersonAccessRightKind.NOT_APPLICABLE },
            { "OrdinalScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "OrExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "Organization", PersonAccessRightKind.NONE },
            { "OwnedStyle", PersonAccessRightKind.NOT_APPLICABLE },
            { "Page", PersonAccessRightKind.NOT_APPLICABLE },
            { "Parameter", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterGroup", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterizedCategoryRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ParameterOrOverrideBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterOverride", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterOverrideValueSet", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterSubscription", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterSubscriptionValueSet", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterType", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterTypeComponent", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterValueSet", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterValueSetBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParametricConstraint", PersonAccessRightKind.NOT_APPLICABLE },
            { "Participant", PersonAccessRightKind.NONE },
            { "ParticipantPermission", PersonAccessRightKind.NONE },
            { "ParticipantRole", PersonAccessRightKind.NONE },
            { "Person", PersonAccessRightKind.NONE },
            { "PersonPermission", PersonAccessRightKind.NONE },
            { "PersonRole", PersonAccessRightKind.NONE },
            { "Point", PersonAccessRightKind.NOT_APPLICABLE },
            { "PossibleFiniteState", PersonAccessRightKind.NOT_APPLICABLE },
            { "PossibleFiniteStateList", PersonAccessRightKind.NOT_APPLICABLE },
            { "PrefixedUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Publication", PersonAccessRightKind.NOT_APPLICABLE },
            { "QuantityKind", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "QuantityKindFactor", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "RatioScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ReferenceDataLibrary", PersonAccessRightKind.NOT_APPLICABLE },
            { "ReferencerRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ReferenceSource", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "RelationalExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "Relationship", PersonAccessRightKind.NOT_APPLICABLE },
            { "RelationshipParameterValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequestForDeviation", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequestForWaiver", PersonAccessRightKind.NOT_APPLICABLE },
            { "Requirement", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequirementsContainer", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequirementsContainerParameterValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequirementsGroup", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequirementsSpecification", PersonAccessRightKind.NOT_APPLICABLE },
            { "ReviewItemDiscrepancy", PersonAccessRightKind.NOT_APPLICABLE },
            { "Rule", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "RuleVerification", PersonAccessRightKind.NOT_APPLICABLE },
            { "RuleVerificationList", PersonAccessRightKind.NOT_APPLICABLE },
            { "RuleViolation", PersonAccessRightKind.NOT_APPLICABLE },
            { "ScalarParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ScaleReferenceQuantityValue", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ScaleValueDefinition", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Section", PersonAccessRightKind.NOT_APPLICABLE },
            { "SharedStyle", PersonAccessRightKind.NOT_APPLICABLE },
            { "SimpleParameterizableThing", PersonAccessRightKind.NOT_APPLICABLE },
            { "SimpleParameterValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "SimpleQuantityKind", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "SimpleUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "SiteDirectory", PersonAccessRightKind.NONE },
            { "SiteDirectoryDataAnnotation", PersonAccessRightKind.NONE },
            { "SiteDirectoryDataDiscussionItem", PersonAccessRightKind.NONE },
            { "SiteDirectoryThingReference", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "SiteLogEntry", PersonAccessRightKind.NONE },
            { "SiteReferenceDataLibrary", PersonAccessRightKind.NONE },
            { "Solution", PersonAccessRightKind.NOT_APPLICABLE },
            { "SpecializedQuantityKind", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Stakeholder", PersonAccessRightKind.NOT_APPLICABLE },
            { "StakeholderValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "StakeHolderValueMap", PersonAccessRightKind.NOT_APPLICABLE },
            { "StakeHolderValueMapSettings", PersonAccessRightKind.NOT_APPLICABLE },
            { "TelephoneNumber", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Term", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "TextParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "TextualNote", PersonAccessRightKind.NOT_APPLICABLE },
            { "Thing", PersonAccessRightKind.NOT_APPLICABLE },
            { "ThingReference", PersonAccessRightKind.NOT_APPLICABLE },
            { "TimeOfDayParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "TopContainer", PersonAccessRightKind.NOT_APPLICABLE },
            { "UnitFactor", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "UnitPrefix", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "UserPreference", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "UserRuleVerification", PersonAccessRightKind.NOT_APPLICABLE },
            { "ValueGroup", PersonAccessRightKind.NOT_APPLICABLE },
        };

        /// <summary>
        /// Return the default <see cref="ParticipantAccessRightKind"/> for the supplied type.
        /// </summary>
        /// <param name="typeName">
        /// The type name for which the <see cref="ParticipantAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="ParticipantAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If type not found, this should never happen
        /// </exception>
        public ParticipantAccessRightKind GetDefaultParticipantPermission(string typeName)
        {
            if (!this.participantPermissionMap.ContainsKey(typeName))
            {
                throw new ArgumentException(string.Format("{0} does not have a default permission set", typeName));
            }

            return this.participantPermissionMap[typeName];
        }

        /// <summary>
        /// Return the default <see cref="PersonAccessRightKind"/> for the supplied type.
        /// </summary>
        /// <param name="typeName">
        /// The type name for which the <see cref="PersonAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="PersonAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If type not found, this should never happen
        /// </exception>
        public PersonAccessRightKind GetDefaultPersonPermission(string typeName)
        {
            if (!this.personPermissionMap.ContainsKey(typeName))
            {
                throw new ArgumentException(string.Format("{0} does not have a default permission set", typeName));
            }

            return this.personPermissionMap[typeName];
        }
    }
}
