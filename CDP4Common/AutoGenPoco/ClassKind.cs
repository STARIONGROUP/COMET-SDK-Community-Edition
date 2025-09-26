// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassKind.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
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

namespace CDP4Common.CommonData
{
    /// <summary>
    /// enumeration datatype that denotes the possible classes in the current data model
    /// Note 1: Values are used to represent classes in instance directories and in the definition of validation rules.
    /// Note 2: The implementation in a programming language needs to provide a reflection capability that allows 
    ///         runtime evaluation of an instance's class against the enumeration literal that represents the class name.
    /// </summary>
    public enum ClassKind
    {
        /// <summary>
        /// Assertion that the Class is an instance of ActionItem
        /// </summary>
        ActionItem,

        /// <summary>
        /// Assertion that the Class is an instance of ActualFiniteState
        /// </summary>
        ActualFiniteState,

        /// <summary>
        /// Assertion that the Class is an instance of ActualFiniteStateList
        /// </summary>
        ActualFiniteStateList,

        /// <summary>
        /// Assertion that the Class is an instance of Alias
        /// </summary>
        Alias,

        /// <summary>
        /// Assertion that the Class is an instance of AndExpression
        /// </summary>
        AndExpression,

        /// <summary>
        /// Assertion that the Class is an instance of Approval
        /// </summary>
        Approval,

        /// <summary>
        /// Assertion that the Class is an instance of ArrayParameterType
        /// </summary>
        ArrayParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of BinaryNote
        /// </summary>
        BinaryNote,

        /// <summary>
        /// Assertion that the Class is an instance of BinaryRelationship
        /// </summary>
        BinaryRelationship,

        /// <summary>
        /// Assertion that the Class is an instance of BinaryRelationshipRule
        /// </summary>
        BinaryRelationshipRule,

        /// <summary>
        /// Assertion that the Class is an instance of Book
        /// </summary>
        Book,

        /// <summary>
        /// Assertion that the Class is an instance of BooleanExpression
        /// </summary>
        BooleanExpression,

        /// <summary>
        /// Assertion that the Class is an instance of BooleanParameterType
        /// </summary>
        BooleanParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of Bounds
        /// </summary>
        Bounds,

        /// <summary>
        /// Assertion that the Class is an instance of BuiltInRuleVerification
        /// </summary>
        BuiltInRuleVerification,

        /// <summary>
        /// Assertion that the Class is an instance of Category
        /// </summary>
        Category,

        /// <summary>
        /// Assertion that the Class is an instance of ChangeProposal
        /// </summary>
        ChangeProposal,

        /// <summary>
        /// Assertion that the Class is an instance of ChangeRequest
        /// </summary>
        ChangeRequest,

        /// <summary>
        /// Assertion that the Class is an instance of Citation
        /// </summary>
        Citation,

        /// <summary>
        /// Assertion that the Class is an instance of Color
        /// </summary>
        Color,

        /// <summary>
        /// Assertion that the Class is an instance of CommonFileStore
        /// </summary>
        CommonFileStore,

        /// <summary>
        /// Assertion that the Class is an instance of CompoundParameterType
        /// </summary>
        CompoundParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of Constant
        /// </summary>
        Constant,

        /// <summary>
        /// Assertion that the Class is an instance of ContractChangeNotice
        /// </summary>
        ContractChangeNotice,

        /// <summary>
        /// Assertion that the Class is an instance of ContractDeviation
        /// </summary>
        ContractDeviation,

        /// <summary>
        /// Assertion that the Class is an instance of ConversionBasedUnit
        /// </summary>
        ConversionBasedUnit,

        /// <summary>
        /// Assertion that the Class is an instance of CyclicRatioScale
        /// </summary>
        CyclicRatioScale,

        /// <summary>
        /// Assertion that the Class is an instance of DateParameterType
        /// </summary>
        DateParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of DateTimeParameterType
        /// </summary>
        DateTimeParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of DecompositionRule
        /// </summary>
        DecompositionRule,

        /// <summary>
        /// Assertion that the Class is an instance of DefinedThing
        /// </summary>
        DefinedThing,

        /// <summary>
        /// Assertion that the Class is an instance of Definition
        /// </summary>
        Definition,

        /// <summary>
        /// Assertion that the Class is an instance of DependentParameterTypeAssignment
        /// </summary>
        DependentParameterTypeAssignment,

        /// <summary>
        /// Assertion that the Class is an instance of DerivedQuantityKind
        /// </summary>
        DerivedQuantityKind,

        /// <summary>
        /// Assertion that the Class is an instance of DerivedUnit
        /// </summary>
        DerivedUnit,

        /// <summary>
        /// Assertion that the Class is an instance of DiagramCanvas
        /// </summary>
        DiagramCanvas,

        /// <summary>
        /// Assertion that the Class is an instance of DiagramEdge
        /// </summary>
        DiagramEdge,

        /// <summary>
        /// Assertion that the Class is an instance of DiagramElementContainer
        /// </summary>
        DiagramElementContainer,

        /// <summary>
        /// Assertion that the Class is an instance of DiagramElementThing
        /// </summary>
        DiagramElementThing,

        /// <summary>
        /// Assertion that the Class is an instance of DiagrammingStyle
        /// </summary>
        DiagrammingStyle,

        /// <summary>
        /// Assertion that the Class is an instance of DiagramObject
        /// </summary>
        DiagramObject,

        /// <summary>
        /// Assertion that the Class is an instance of DiagramShape
        /// </summary>
        DiagramShape,

        /// <summary>
        /// Assertion that the Class is an instance of DiagramThingBase
        /// </summary>
        DiagramThingBase,

        /// <summary>
        /// Assertion that the Class is an instance of DiscussionItem
        /// </summary>
        DiscussionItem,

        /// <summary>
        /// Assertion that the Class is an instance of DomainFileStore
        /// </summary>
        DomainFileStore,

        /// <summary>
        /// Assertion that the Class is an instance of DomainOfExpertise
        /// </summary>
        DomainOfExpertise,

        /// <summary>
        /// Assertion that the Class is an instance of DomainOfExpertiseGroup
        /// </summary>
        DomainOfExpertiseGroup,

        /// <summary>
        /// Assertion that the Class is an instance of ElementBase
        /// </summary>
        ElementBase,

        /// <summary>
        /// Assertion that the Class is an instance of ElementDefinition
        /// </summary>
        ElementDefinition,

        /// <summary>
        /// Assertion that the Class is an instance of ElementUsage
        /// </summary>
        ElementUsage,

        /// <summary>
        /// Assertion that the Class is an instance of EmailAddress
        /// </summary>
        EmailAddress,

        /// <summary>
        /// Assertion that the Class is an instance of EngineeringModel
        /// </summary>
        EngineeringModel,

        /// <summary>
        /// Assertion that the Class is an instance of EngineeringModelDataAnnotation
        /// </summary>
        EngineeringModelDataAnnotation,

        /// <summary>
        /// Assertion that the Class is an instance of EngineeringModelDataDiscussionItem
        /// </summary>
        EngineeringModelDataDiscussionItem,

        /// <summary>
        /// Assertion that the Class is an instance of EngineeringModelDataNote
        /// </summary>
        EngineeringModelDataNote,

        /// <summary>
        /// Assertion that the Class is an instance of EngineeringModelSetup
        /// </summary>
        EngineeringModelSetup,

        /// <summary>
        /// Assertion that the Class is an instance of EnumerationParameterType
        /// </summary>
        EnumerationParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of EnumerationValueDefinition
        /// </summary>
        EnumerationValueDefinition,

        /// <summary>
        /// Assertion that the Class is an instance of ExclusiveOrExpression
        /// </summary>
        ExclusiveOrExpression,

        /// <summary>
        /// Assertion that the Class is an instance of ExternalIdentifierMap
        /// </summary>
        ExternalIdentifierMap,

        /// <summary>
        /// Assertion that the Class is an instance of File
        /// </summary>
        File,

        /// <summary>
        /// Assertion that the Class is an instance of FileRevision
        /// </summary>
        FileRevision,

        /// <summary>
        /// Assertion that the Class is an instance of FileStore
        /// </summary>
        FileStore,

        /// <summary>
        /// Assertion that the Class is an instance of FileType
        /// </summary>
        FileType,

        /// <summary>
        /// Assertion that the Class is an instance of Folder
        /// </summary>
        Folder,

        /// <summary>
        /// Assertion that the Class is an instance of GenericAnnotation
        /// </summary>
        GenericAnnotation,

        /// <summary>
        /// Assertion that the Class is an instance of Glossary
        /// </summary>
        Glossary,

        /// <summary>
        /// Assertion that the Class is an instance of Goal
        /// </summary>
        Goal,

        /// <summary>
        /// Assertion that the Class is an instance of HyperLink
        /// </summary>
        HyperLink,

        /// <summary>
        /// Assertion that the Class is an instance of IdCorrespondence
        /// </summary>
        IdCorrespondence,

        /// <summary>
        /// Assertion that the Class is an instance of IndependentParameterTypeAssignment
        /// </summary>
        IndependentParameterTypeAssignment,

        /// <summary>
        /// Assertion that the Class is an instance of IntervalScale
        /// </summary>
        IntervalScale,

        /// <summary>
        /// Assertion that the Class is an instance of Iteration
        /// </summary>
        Iteration,

        /// <summary>
        /// Assertion that the Class is an instance of IterationSetup
        /// </summary>
        IterationSetup,

        /// <summary>
        /// Assertion that the Class is an instance of LinearConversionUnit
        /// </summary>
        LinearConversionUnit,

        /// <summary>
        /// Assertion that the Class is an instance of LogarithmicScale
        /// </summary>
        LogarithmicScale,

        /// <summary>
        /// Assertion that the Class is an instance of LogEntryChangelogItem
        /// </summary>
        LogEntryChangelogItem,

        /// <summary>
        /// Assertion that the Class is an instance of MappingToReferenceScale
        /// </summary>
        MappingToReferenceScale,

        /// <summary>
        /// Assertion that the Class is an instance of MeasurementScale
        /// </summary>
        MeasurementScale,

        /// <summary>
        /// Assertion that the Class is an instance of MeasurementUnit
        /// </summary>
        MeasurementUnit,

        /// <summary>
        /// Assertion that the Class is an instance of ModellingAnnotationItem
        /// </summary>
        ModellingAnnotationItem,

        /// <summary>
        /// Assertion that the Class is an instance of ModellingThingReference
        /// </summary>
        ModellingThingReference,

        /// <summary>
        /// Assertion that the Class is an instance of ModelLogEntry
        /// </summary>
        ModelLogEntry,

        /// <summary>
        /// Assertion that the Class is an instance of ModelReferenceDataLibrary
        /// </summary>
        ModelReferenceDataLibrary,

        /// <summary>
        /// Assertion that the Class is an instance of MultiRelationship
        /// </summary>
        MultiRelationship,

        /// <summary>
        /// Assertion that the Class is an instance of MultiRelationshipRule
        /// </summary>
        MultiRelationshipRule,

        /// <summary>
        /// Assertion that the Class is an instance of NaturalLanguage
        /// </summary>
        NaturalLanguage,

        /// <summary>
        /// Assertion that the Class is an instance of NestedElement
        /// </summary>
        NestedElement,

        /// <summary>
        /// Assertion that the Class is an instance of NestedParameter
        /// </summary>
        NestedParameter,

        /// <summary>
        /// Assertion that the Class is an instance of Note
        /// </summary>
        Note,

        /// <summary>
        /// Assertion that the Class is an instance of NotExpression
        /// </summary>
        NotExpression,

        /// <summary>
        /// Assertion that the Class is an instance of NotThing
        /// </summary>
        NotThing,

        /// <summary>
        /// Assertion that the Class is an instance of Option
        /// </summary>
        Option,

        /// <summary>
        /// Assertion that the Class is an instance of OrdinalScale
        /// </summary>
        OrdinalScale,

        /// <summary>
        /// Assertion that the Class is an instance of OrExpression
        /// </summary>
        OrExpression,

        /// <summary>
        /// Assertion that the Class is an instance of Organization
        /// </summary>
        Organization,

        /// <summary>
        /// Assertion that the Class is an instance of OrganizationalParticipant
        /// </summary>
        OrganizationalParticipant,

        /// <summary>
        /// Assertion that the Class is an instance of OwnedStyle
        /// </summary>
        OwnedStyle,

        /// <summary>
        /// Assertion that the Class is an instance of Page
        /// </summary>
        Page,

        /// <summary>
        /// Assertion that the Class is an instance of Parameter
        /// </summary>
        Parameter,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterBase
        /// </summary>
        ParameterBase,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterGroup
        /// </summary>
        ParameterGroup,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterizedCategoryRule
        /// </summary>
        ParameterizedCategoryRule,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterOrOverrideBase
        /// </summary>
        ParameterOrOverrideBase,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterOverride
        /// </summary>
        ParameterOverride,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterOverrideValueSet
        /// </summary>
        ParameterOverrideValueSet,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterSubscription
        /// </summary>
        ParameterSubscription,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterSubscriptionValueSet
        /// </summary>
        ParameterSubscriptionValueSet,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterType
        /// </summary>
        ParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterTypeComponent
        /// </summary>
        ParameterTypeComponent,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterValue
        /// </summary>
        ParameterValue,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterValueSet
        /// </summary>
        ParameterValueSet,

        /// <summary>
        /// Assertion that the Class is an instance of ParameterValueSetBase
        /// </summary>
        ParameterValueSetBase,

        /// <summary>
        /// Assertion that the Class is an instance of ParametricConstraint
        /// </summary>
        ParametricConstraint,

        /// <summary>
        /// Assertion that the Class is an instance of Participant
        /// </summary>
        Participant,

        /// <summary>
        /// Assertion that the Class is an instance of ParticipantPermission
        /// </summary>
        ParticipantPermission,

        /// <summary>
        /// Assertion that the Class is an instance of ParticipantRole
        /// </summary>
        ParticipantRole,

        /// <summary>
        /// Assertion that the Class is an instance of Person
        /// </summary>
        Person,

        /// <summary>
        /// Assertion that the Class is an instance of PersonPermission
        /// </summary>
        PersonPermission,

        /// <summary>
        /// Assertion that the Class is an instance of PersonRole
        /// </summary>
        PersonRole,

        /// <summary>
        /// Assertion that the Class is an instance of Point
        /// </summary>
        Point,

        /// <summary>
        /// Assertion that the Class is an instance of PossibleFiniteState
        /// </summary>
        PossibleFiniteState,

        /// <summary>
        /// Assertion that the Class is an instance of PossibleFiniteStateList
        /// </summary>
        PossibleFiniteStateList,

        /// <summary>
        /// Assertion that the Class is an instance of PrefixedUnit
        /// </summary>
        PrefixedUnit,

        /// <summary>
        /// Assertion that the Class is an instance of Publication
        /// </summary>
        Publication,

        /// <summary>
        /// Assertion that the Class is an instance of QuantityKind
        /// </summary>
        QuantityKind,

        /// <summary>
        /// Assertion that the Class is an instance of QuantityKindFactor
        /// </summary>
        QuantityKindFactor,

        /// <summary>
        /// Assertion that the Class is an instance of RatioScale
        /// </summary>
        RatioScale,

        /// <summary>
        /// Assertion that the Class is an instance of ReferenceDataLibrary
        /// </summary>
        ReferenceDataLibrary,

        /// <summary>
        /// Assertion that the Class is an instance of ReferencerRule
        /// </summary>
        ReferencerRule,

        /// <summary>
        /// Assertion that the Class is an instance of ReferenceSource
        /// </summary>
        ReferenceSource,

        /// <summary>
        /// Assertion that the Class is an instance of RelationalExpression
        /// </summary>
        RelationalExpression,

        /// <summary>
        /// Assertion that the Class is an instance of Relationship
        /// </summary>
        Relationship,

        /// <summary>
        /// Assertion that the Class is an instance of RelationshipParameterValue
        /// </summary>
        RelationshipParameterValue,

        /// <summary>
        /// Assertion that the Class is an instance of RequestForDeviation
        /// </summary>
        RequestForDeviation,

        /// <summary>
        /// Assertion that the Class is an instance of RequestForWaiver
        /// </summary>
        RequestForWaiver,

        /// <summary>
        /// Assertion that the Class is an instance of Requirement
        /// </summary>
        Requirement,

        /// <summary>
        /// Assertion that the Class is an instance of RequirementsContainer
        /// </summary>
        RequirementsContainer,

        /// <summary>
        /// Assertion that the Class is an instance of RequirementsContainerParameterValue
        /// </summary>
        RequirementsContainerParameterValue,

        /// <summary>
        /// Assertion that the Class is an instance of RequirementsGroup
        /// </summary>
        RequirementsGroup,

        /// <summary>
        /// Assertion that the Class is an instance of RequirementsSpecification
        /// </summary>
        RequirementsSpecification,

        /// <summary>
        /// Assertion that the Class is an instance of ReviewItemDiscrepancy
        /// </summary>
        ReviewItemDiscrepancy,

        /// <summary>
        /// Assertion that the Class is an instance of Rule
        /// </summary>
        Rule,

        /// <summary>
        /// Assertion that the Class is an instance of RuleVerification
        /// </summary>
        RuleVerification,

        /// <summary>
        /// Assertion that the Class is an instance of RuleVerificationList
        /// </summary>
        RuleVerificationList,

        /// <summary>
        /// Assertion that the Class is an instance of RuleViolation
        /// </summary>
        RuleViolation,

        /// <summary>
        /// Assertion that the Class is an instance of SampledFunctionParameterType
        /// </summary>
        SampledFunctionParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of ScalarParameterType
        /// </summary>
        ScalarParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of ScaleReferenceQuantityValue
        /// </summary>
        ScaleReferenceQuantityValue,

        /// <summary>
        /// Assertion that the Class is an instance of ScaleValueDefinition
        /// </summary>
        ScaleValueDefinition,

        /// <summary>
        /// Assertion that the Class is an instance of Section
        /// </summary>
        Section,

        /// <summary>
        /// Assertion that the Class is an instance of SharedStyle
        /// </summary>
        SharedStyle,

        /// <summary>
        /// Assertion that the Class is an instance of SimpleParameterizableThing
        /// </summary>
        SimpleParameterizableThing,

        /// <summary>
        /// Assertion that the Class is an instance of SimpleParameterValue
        /// </summary>
        SimpleParameterValue,

        /// <summary>
        /// Assertion that the Class is an instance of SimpleQuantityKind
        /// </summary>
        SimpleQuantityKind,

        /// <summary>
        /// Assertion that the Class is an instance of SimpleUnit
        /// </summary>
        SimpleUnit,

        /// <summary>
        /// Assertion that the Class is an instance of SiteDirectory
        /// </summary>
        SiteDirectory,

        /// <summary>
        /// Assertion that the Class is an instance of SiteDirectoryDataAnnotation
        /// </summary>
        SiteDirectoryDataAnnotation,

        /// <summary>
        /// Assertion that the Class is an instance of SiteDirectoryDataDiscussionItem
        /// </summary>
        SiteDirectoryDataDiscussionItem,

        /// <summary>
        /// Assertion that the Class is an instance of SiteDirectoryThingReference
        /// </summary>
        SiteDirectoryThingReference,

        /// <summary>
        /// Assertion that the Class is an instance of SiteLogEntry
        /// </summary>
        SiteLogEntry,

        /// <summary>
        /// Assertion that the Class is an instance of SiteReferenceDataLibrary
        /// </summary>
        SiteReferenceDataLibrary,

        /// <summary>
        /// Assertion that the Class is an instance of Solution
        /// </summary>
        Solution,

        /// <summary>
        /// Assertion that the Class is an instance of SpecializedQuantityKind
        /// </summary>
        SpecializedQuantityKind,

        /// <summary>
        /// Assertion that the Class is an instance of Stakeholder
        /// </summary>
        Stakeholder,

        /// <summary>
        /// Assertion that the Class is an instance of StakeholderValue
        /// </summary>
        StakeholderValue,

        /// <summary>
        /// Assertion that the Class is an instance of StakeHolderValueMap
        /// </summary>
        StakeHolderValueMap,

        /// <summary>
        /// Assertion that the Class is an instance of StakeHolderValueMapSettings
        /// </summary>
        StakeHolderValueMapSettings,

        /// <summary>
        /// Assertion that the Class is an instance of TelephoneNumber
        /// </summary>
        TelephoneNumber,

        /// <summary>
        /// Assertion that the Class is an instance of Term
        /// </summary>
        Term,

        /// <summary>
        /// Assertion that the Class is an instance of TextParameterType
        /// </summary>
        TextParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of TextualNote
        /// </summary>
        TextualNote,

        /// <summary>
        /// Assertion that the Class is an instance of Thing
        /// </summary>
        Thing,

        /// <summary>
        /// Assertion that the Class is an instance of ThingReference
        /// </summary>
        ThingReference,

        /// <summary>
        /// Assertion that the Class is an instance of TimeOfDayParameterType
        /// </summary>
        TimeOfDayParameterType,

        /// <summary>
        /// Assertion that the Class is an instance of TopContainer
        /// </summary>
        TopContainer,

        /// <summary>
        /// Assertion that the Class is an instance of UnitFactor
        /// </summary>
        UnitFactor,

        /// <summary>
        /// Assertion that the Class is an instance of UnitPrefix
        /// </summary>
        UnitPrefix,

        /// <summary>
        /// Assertion that the Class is an instance of UserPreference
        /// </summary>
        UserPreference,

        /// <summary>
        /// Assertion that the Class is an instance of UserRuleVerification
        /// </summary>
        UserRuleVerification,

        /// <summary>
        /// Assertion that the Class is an instance of ValueGroup
        /// </summary>
        ValueGroup
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
