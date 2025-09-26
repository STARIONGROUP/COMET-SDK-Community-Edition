// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Payload.cs" company="Starion Group S.A.">
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

    /* ------------------------------------------- | ------- *
     | index | property name                       | version |
     | ------------------------------------------- | ------- |
     |  0    | Created                             |  0.0.0  |
     | ------------------------------------------- | ------- |
     | 1     | ActualFiniteState                   |  1.0.0  |
     | 2     | ActualFiniteStateList               |  1.0.0  |
     | 3     | Alias                               |  1.0.0  |
     | 4     | AndExpression                       |  1.0.0  |
     | 5     | ArrayParameterType                  |  1.0.0  |
     | 6     | BinaryRelationship                  |  1.0.0  |
     | 7     | BinaryRelationshipRule              |  1.0.0  |
     | 8     | BooleanParameterType                |  1.0.0  |
     | 9     | BuiltInRuleVerification             |  1.0.0  |
     | 10    | Category                            |  1.0.0  |
     | 11    | Citation                            |  1.0.0  |
     | 12    | Color                               |  1.0.0  |
     | 13    | CommonFileStore                     |  1.0.0  |
     | 14    | CompoundParameterType               |  1.0.0  |
     | 15    | Constant                            |  1.0.0  |
     | 16    | CyclicRatioScale                    |  1.0.0  |
     | 17    | DateParameterType                   |  1.0.0  |
     | 18    | DateTimeParameterType               |  1.0.0  |
     | 19    | DecompositionRule                   |  1.0.0  |
     | 20    | Definition                          |  1.0.0  |
     | 21    | DerivedQuantityKind                 |  1.0.0  |
     | 22    | DerivedUnit                         |  1.0.0  |
     | 23    | DomainFileStore                     |  1.0.0  |
     | 24    | DomainOfExpertise                   |  1.0.0  |
     | 25    | DomainOfExpertiseGroup              |  1.0.0  |
     | 26    | ElementDefinition                   |  1.0.0  |
     | 27    | ElementUsage                        |  1.0.0  |
     | 28    | EmailAddress                        |  1.0.0  |
     | 29    | EngineeringModel                    |  1.0.0  |
     | 30    | EngineeringModelSetup               |  1.0.0  |
     | 31    | EnumerationParameterType            |  1.0.0  |
     | 32    | EnumerationValueDefinition          |  1.0.0  |
     | 33    | ExclusiveOrExpression               |  1.0.0  |
     | 34    | ExternalIdentifierMap               |  1.0.0  |
     | 35    | File                                |  1.0.0  |
     | 36    | FileRevision                        |  1.0.0  |
     | 37    | FileType                            |  1.0.0  |
     | 38    | Folder                              |  1.0.0  |
     | 39    | Glossary                            |  1.0.0  |
     | 40    | HyperLink                           |  1.0.0  |
     | 41    | IdCorrespondence                    |  1.0.0  |
     | 42    | IntervalScale                       |  1.0.0  |
     | 43    | Iteration                           |  1.0.0  |
     | 44    | IterationSetup                      |  1.0.0  |
     | 45    | LinearConversionUnit                |  1.0.0  |
     | 46    | LogarithmicScale                    |  1.0.0  |
     | 47    | MappingToReferenceScale             |  1.0.0  |
     | 48    | ModelLogEntry                       |  1.0.0  |
     | 49    | ModelReferenceDataLibrary           |  1.0.0  |
     | 50    | MultiRelationship                   |  1.0.0  |
     | 51    | MultiRelationshipRule               |  1.0.0  |
     | 52    | NaturalLanguage                     |  1.0.0  |
     | 53    | NestedElement                       |  1.0.0  |
     | 54    | NestedParameter                     |  1.0.0  |
     | 55    | NotExpression                       |  1.0.0  |
     | 56    | Option                              |  1.0.0  |
     | 57    | OrdinalScale                        |  1.0.0  |
     | 58    | OrExpression                        |  1.0.0  |
     | 59    | Organization                        |  1.0.0  |
     | 60    | Parameter                           |  1.0.0  |
     | 61    | ParameterGroup                      |  1.0.0  |
     | 62    | ParameterizedCategoryRule           |  1.0.0  |
     | 63    | ParameterOverride                   |  1.0.0  |
     | 64    | ParameterOverrideValueSet           |  1.0.0  |
     | 65    | ParameterSubscription               |  1.0.0  |
     | 66    | ParameterSubscriptionValueSet       |  1.0.0  |
     | 67    | ParameterTypeComponent              |  1.0.0  |
     | 68    | ParameterValueSet                   |  1.0.0  |
     | 69    | ParametricConstraint                |  1.0.0  |
     | 70    | Participant                         |  1.0.0  |
     | 71    | ParticipantPermission               |  1.0.0  |
     | 72    | ParticipantRole                     |  1.0.0  |
     | 73    | Person                              |  1.0.0  |
     | 74    | PersonPermission                    |  1.0.0  |
     | 75    | PersonRole                          |  1.0.0  |
     | 76    | PossibleFiniteState                 |  1.0.0  |
     | 77    | PossibleFiniteStateList             |  1.0.0  |
     | 78    | PrefixedUnit                        |  1.0.0  |
     | 79    | Publication                         |  1.0.0  |
     | 80    | QuantityKindFactor                  |  1.0.0  |
     | 81    | RatioScale                          |  1.0.0  |
     | 82    | ReferencerRule                      |  1.0.0  |
     | 83    | ReferenceSource                     |  1.0.0  |
     | 84    | RelationalExpression                |  1.0.0  |
     | 85    | Requirement                         |  1.0.0  |
     | 86    | RequirementsGroup                   |  1.0.0  |
     | 87    | RequirementsSpecification           |  1.0.0  |
     | 88    | RuleVerificationList                |  1.0.0  |
     | 89    | RuleViolation                       |  1.0.0  |
     | 90    | ScaleReferenceQuantityValue         |  1.0.0  |
     | 91    | ScaleValueDefinition                |  1.0.0  |
     | 92    | SimpleParameterValue                |  1.0.0  |
     | 93    | SimpleQuantityKind                  |  1.0.0  |
     | 94    | SimpleUnit                          |  1.0.0  |
     | 95    | SiteDirectory                       |  1.0.0  |
     | 96    | SiteLogEntry                        |  1.0.0  |
     | 97    | SiteReferenceDataLibrary            |  1.0.0  |
     | 98    | SpecializedQuantityKind             |  1.0.0  |
     | 99    | TelephoneNumber                     |  1.0.0  |
     | 100   | Term                                |  1.0.0  |
     | 101   | TextParameterType                   |  1.0.0  |
     | 102   | TimeOfDayParameterType              |  1.0.0  |
     | 103   | UnitFactor                          |  1.0.0  |
     | 104   | UnitPrefix                          |  1.0.0  |
     | 105   | UserPreference                      |  1.0.0  |
     | 106   | UserRuleVerification                |  1.0.0  |
     | 107   | ActionItem                          |  1.1.0  |
     | 108   | Approval                            |  1.1.0  |
     | 109   | BinaryNote                          |  1.1.0  |
     | 110   | Book                                |  1.1.0  |
     | 111   | Bounds                              |  1.1.0  |
     | 112   | ChangeProposal                      |  1.1.0  |
     | 113   | ChangeRequest                       |  1.1.0  |
     | 114   | ContractChangeNotice                |  1.1.0  |
     | 115   | DiagramCanvas                       |  1.1.0  |
     | 116   | DiagramEdge                         |  1.1.0  |
     | 117   | DiagramObject                       |  1.1.0  |
     | 118   | EngineeringModelDataDiscussionItem  |  1.1.0  |
     | 119   | EngineeringModelDataNote            |  1.1.0  |
     | 120   | Goal                                |  1.1.0  |
     | 121   | ModellingThingReference             |  1.1.0  |
     | 122   | OwnedStyle                          |  1.1.0  |
     | 123   | Page                                |  1.1.0  |
     | 124   | Point                               |  1.1.0  |
     | 125   | RelationshipParameterValue          |  1.1.0  |
     | 126   | RequestForDeviation                 |  1.1.0  |
     | 127   | RequestForWaiver                    |  1.1.0  |
     | 128   | RequirementsContainerParameterValue |  1.1.0  |
     | 129   | ReviewItemDiscrepancy               |  1.1.0  |
     | 130   | Section                             |  1.1.0  |
     | 131   | SharedStyle                         |  1.1.0  |
     | 132   | SiteDirectoryDataAnnotation         |  1.1.0  |
     | 133   | SiteDirectoryDataDiscussionItem     |  1.1.0  |
     | 134   | SiteDirectoryThingReference         |  1.1.0  |
     | 135   | Solution                            |  1.1.0  |
     | 136   | Stakeholder                         |  1.1.0  |
     | 137   | StakeholderValue                    |  1.1.0  |
     | 138   | StakeHolderValueMap                 |  1.1.0  |
     | 139   | StakeHolderValueMapSettings         |  1.1.0  |
     | 140   | TextualNote                         |  1.1.0  |
     | 141   | ValueGroup                          |  1.1.0  |
     | 142   | DependentParameterTypeAssignment    |  1.2.0  |
     | 143   | IndependentParameterTypeAssignment  |  1.2.0  |
     | 144   | LogEntryChangelogItem               |  1.2.0  |
     | 145   | OrganizationalParticipant           |  1.2.0  |
     | 146   | SampledFunctionParameterType        |  1.2.0  |
     * ------------------------------------------- | ------- */

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.DTO;

    /// <summary>
    /// The <see cref="Payload"/> acts as envelope around the <see cref="CDP4Common.DTO"/> classes and is used as
    /// construct to transport the objects using MessagePack
    /// </summary>
    internal class Payload
    {
        /// <summary>
        /// Gets or sets the <see cref="DateTime"/> at which the <see cref="Payload"/> was created
        /// </summary>
        internal DateTime Created { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the list of <see cref="ActualFiniteState"/>.
        /// </summary>
        internal List<ActualFiniteState> ActualFiniteState { get; set; } = new List<ActualFiniteState>();

        /// <summary>
        /// Gets or sets the list of <see cref="ActualFiniteStateList"/>.
        /// </summary>
        internal List<ActualFiniteStateList> ActualFiniteStateList { get; set; } = new List<ActualFiniteStateList>();

        /// <summary>
        /// Gets or sets the list of <see cref="Alias"/>.
        /// </summary>
        internal List<Alias> Alias { get; set; } = new List<Alias>();

        /// <summary>
        /// Gets or sets the list of <see cref="AndExpression"/>.
        /// </summary>
        internal List<AndExpression> AndExpression { get; set; } = new List<AndExpression>();

        /// <summary>
        /// Gets or sets the list of <see cref="ArrayParameterType"/>.
        /// </summary>
        internal List<ArrayParameterType> ArrayParameterType { get; set; } = new List<ArrayParameterType>();

        /// <summary>
        /// Gets or sets the list of <see cref="BinaryRelationship"/>.
        /// </summary>
        internal List<BinaryRelationship> BinaryRelationship { get; set; } = new List<BinaryRelationship>();

        /// <summary>
        /// Gets or sets the list of <see cref="BinaryRelationshipRule"/>.
        /// </summary>
        internal List<BinaryRelationshipRule> BinaryRelationshipRule { get; set; } = new List<BinaryRelationshipRule>();

        /// <summary>
        /// Gets or sets the list of <see cref="BooleanParameterType"/>.
        /// </summary>
        internal List<BooleanParameterType> BooleanParameterType { get; set; } = new List<BooleanParameterType>();

        /// <summary>
        /// Gets or sets the list of <see cref="BuiltInRuleVerification"/>.
        /// </summary>
        internal List<BuiltInRuleVerification> BuiltInRuleVerification { get; set; } = new List<BuiltInRuleVerification>();

        /// <summary>
        /// Gets or sets the list of <see cref="Category"/>.
        /// </summary>
        internal List<Category> Category { get; set; } = new List<Category>();

        /// <summary>
        /// Gets or sets the list of <see cref="Citation"/>.
        /// </summary>
        internal List<Citation> Citation { get; set; } = new List<Citation>();

        /// <summary>
        /// Gets or sets the list of <see cref="Color"/>.
        /// </summary>
        internal List<Color> Color { get; set; } = new List<Color>();

        /// <summary>
        /// Gets or sets the list of <see cref="CommonFileStore"/>.
        /// </summary>
        internal List<CommonFileStore> CommonFileStore { get; set; } = new List<CommonFileStore>();

        /// <summary>
        /// Gets or sets the list of <see cref="CompoundParameterType"/>.
        /// </summary>
        internal List<CompoundParameterType> CompoundParameterType { get; set; } = new List<CompoundParameterType>();

        /// <summary>
        /// Gets or sets the list of <see cref="Constant"/>.
        /// </summary>
        internal List<Constant> Constant { get; set; } = new List<Constant>();

        /// <summary>
        /// Gets or sets the list of <see cref="CyclicRatioScale"/>.
        /// </summary>
        internal List<CyclicRatioScale> CyclicRatioScale { get; set; } = new List<CyclicRatioScale>();

        /// <summary>
        /// Gets or sets the list of <see cref="DateParameterType"/>.
        /// </summary>
        internal List<DateParameterType> DateParameterType { get; set; } = new List<DateParameterType>();

        /// <summary>
        /// Gets or sets the list of <see cref="DateTimeParameterType"/>.
        /// </summary>
        internal List<DateTimeParameterType> DateTimeParameterType { get; set; } = new List<DateTimeParameterType>();

        /// <summary>
        /// Gets or sets the list of <see cref="DecompositionRule"/>.
        /// </summary>
        internal List<DecompositionRule> DecompositionRule { get; set; } = new List<DecompositionRule>();

        /// <summary>
        /// Gets or sets the list of <see cref="Definition"/>.
        /// </summary>
        internal List<Definition> Definition { get; set; } = new List<Definition>();

        /// <summary>
        /// Gets or sets the list of <see cref="DerivedQuantityKind"/>.
        /// </summary>
        internal List<DerivedQuantityKind> DerivedQuantityKind { get; set; } = new List<DerivedQuantityKind>();

        /// <summary>
        /// Gets or sets the list of <see cref="DerivedUnit"/>.
        /// </summary>
        internal List<DerivedUnit> DerivedUnit { get; set; } = new List<DerivedUnit>();

        /// <summary>
        /// Gets or sets the list of <see cref="DomainFileStore"/>.
        /// </summary>
        internal List<DomainFileStore> DomainFileStore { get; set; } = new List<DomainFileStore>();

        /// <summary>
        /// Gets or sets the list of <see cref="DomainOfExpertise"/>.
        /// </summary>
        internal List<DomainOfExpertise> DomainOfExpertise { get; set; } = new List<DomainOfExpertise>();

        /// <summary>
        /// Gets or sets the list of <see cref="DomainOfExpertiseGroup"/>.
        /// </summary>
        internal List<DomainOfExpertiseGroup> DomainOfExpertiseGroup { get; set; } = new List<DomainOfExpertiseGroup>();

        /// <summary>
        /// Gets or sets the list of <see cref="ElementDefinition"/>.
        /// </summary>
        internal List<ElementDefinition> ElementDefinition { get; set; } = new List<ElementDefinition>();

        /// <summary>
        /// Gets or sets the list of <see cref="ElementUsage"/>.
        /// </summary>
        internal List<ElementUsage> ElementUsage { get; set; } = new List<ElementUsage>();

        /// <summary>
        /// Gets or sets the list of <see cref="EmailAddress"/>.
        /// </summary>
        internal List<EmailAddress> EmailAddress { get; set; } = new List<EmailAddress>();

        /// <summary>
        /// Gets or sets the list of <see cref="EngineeringModel"/>.
        /// </summary>
        internal List<EngineeringModel> EngineeringModel { get; set; } = new List<EngineeringModel>();

        /// <summary>
        /// Gets or sets the list of <see cref="EngineeringModelSetup"/>.
        /// </summary>
        internal List<EngineeringModelSetup> EngineeringModelSetup { get; set; } = new List<EngineeringModelSetup>();

        /// <summary>
        /// Gets or sets the list of <see cref="EnumerationParameterType"/>.
        /// </summary>
        internal List<EnumerationParameterType> EnumerationParameterType { get; set; } = new List<EnumerationParameterType>();

        /// <summary>
        /// Gets or sets the list of <see cref="EnumerationValueDefinition"/>.
        /// </summary>
        internal List<EnumerationValueDefinition> EnumerationValueDefinition { get; set; } = new List<EnumerationValueDefinition>();

        /// <summary>
        /// Gets or sets the list of <see cref="ExclusiveOrExpression"/>.
        /// </summary>
        internal List<ExclusiveOrExpression> ExclusiveOrExpression { get; set; } = new List<ExclusiveOrExpression>();

        /// <summary>
        /// Gets or sets the list of <see cref="ExternalIdentifierMap"/>.
        /// </summary>
        internal List<ExternalIdentifierMap> ExternalIdentifierMap { get; set; } = new List<ExternalIdentifierMap>();

        /// <summary>
        /// Gets or sets the list of <see cref="File"/>.
        /// </summary>
        internal List<File> File { get; set; } = new List<File>();

        /// <summary>
        /// Gets or sets the list of <see cref="FileRevision"/>.
        /// </summary>
        internal List<FileRevision> FileRevision { get; set; } = new List<FileRevision>();

        /// <summary>
        /// Gets or sets the list of <see cref="FileType"/>.
        /// </summary>
        internal List<FileType> FileType { get; set; } = new List<FileType>();

        /// <summary>
        /// Gets or sets the list of <see cref="Folder"/>.
        /// </summary>
        internal List<Folder> Folder { get; set; } = new List<Folder>();

        /// <summary>
        /// Gets or sets the list of <see cref="Glossary"/>.
        /// </summary>
        internal List<Glossary> Glossary { get; set; } = new List<Glossary>();

        /// <summary>
        /// Gets or sets the list of <see cref="HyperLink"/>.
        /// </summary>
        internal List<HyperLink> HyperLink { get; set; } = new List<HyperLink>();

        /// <summary>
        /// Gets or sets the list of <see cref="IdCorrespondence"/>.
        /// </summary>
        internal List<IdCorrespondence> IdCorrespondence { get; set; } = new List<IdCorrespondence>();

        /// <summary>
        /// Gets or sets the list of <see cref="IntervalScale"/>.
        /// </summary>
        internal List<IntervalScale> IntervalScale { get; set; } = new List<IntervalScale>();

        /// <summary>
        /// Gets or sets the list of <see cref="Iteration"/>.
        /// </summary>
        internal List<Iteration> Iteration { get; set; } = new List<Iteration>();

        /// <summary>
        /// Gets or sets the list of <see cref="IterationSetup"/>.
        /// </summary>
        internal List<IterationSetup> IterationSetup { get; set; } = new List<IterationSetup>();

        /// <summary>
        /// Gets or sets the list of <see cref="LinearConversionUnit"/>.
        /// </summary>
        internal List<LinearConversionUnit> LinearConversionUnit { get; set; } = new List<LinearConversionUnit>();

        /// <summary>
        /// Gets or sets the list of <see cref="LogarithmicScale"/>.
        /// </summary>
        internal List<LogarithmicScale> LogarithmicScale { get; set; } = new List<LogarithmicScale>();

        /// <summary>
        /// Gets or sets the list of <see cref="MappingToReferenceScale"/>.
        /// </summary>
        internal List<MappingToReferenceScale> MappingToReferenceScale { get; set; } = new List<MappingToReferenceScale>();

        /// <summary>
        /// Gets or sets the list of <see cref="ModelLogEntry"/>.
        /// </summary>
        internal List<ModelLogEntry> ModelLogEntry { get; set; } = new List<ModelLogEntry>();

        /// <summary>
        /// Gets or sets the list of <see cref="ModelReferenceDataLibrary"/>.
        /// </summary>
        internal List<ModelReferenceDataLibrary> ModelReferenceDataLibrary { get; set; } = new List<ModelReferenceDataLibrary>();

        /// <summary>
        /// Gets or sets the list of <see cref="MultiRelationship"/>.
        /// </summary>
        internal List<MultiRelationship> MultiRelationship { get; set; } = new List<MultiRelationship>();

        /// <summary>
        /// Gets or sets the list of <see cref="MultiRelationshipRule"/>.
        /// </summary>
        internal List<MultiRelationshipRule> MultiRelationshipRule { get; set; } = new List<MultiRelationshipRule>();

        /// <summary>
        /// Gets or sets the list of <see cref="NaturalLanguage"/>.
        /// </summary>
        internal List<NaturalLanguage> NaturalLanguage { get; set; } = new List<NaturalLanguage>();

        /// <summary>
        /// Gets or sets the list of <see cref="NestedElement"/>.
        /// </summary>
        internal List<NestedElement> NestedElement { get; set; } = new List<NestedElement>();

        /// <summary>
        /// Gets or sets the list of <see cref="NestedParameter"/>.
        /// </summary>
        internal List<NestedParameter> NestedParameter { get; set; } = new List<NestedParameter>();

        /// <summary>
        /// Gets or sets the list of <see cref="NotExpression"/>.
        /// </summary>
        internal List<NotExpression> NotExpression { get; set; } = new List<NotExpression>();

        /// <summary>
        /// Gets or sets the list of <see cref="Option"/>.
        /// </summary>
        internal List<Option> Option { get; set; } = new List<Option>();

        /// <summary>
        /// Gets or sets the list of <see cref="OrdinalScale"/>.
        /// </summary>
        internal List<OrdinalScale> OrdinalScale { get; set; } = new List<OrdinalScale>();

        /// <summary>
        /// Gets or sets the list of <see cref="OrExpression"/>.
        /// </summary>
        internal List<OrExpression> OrExpression { get; set; } = new List<OrExpression>();

        /// <summary>
        /// Gets or sets the list of <see cref="Organization"/>.
        /// </summary>
        internal List<Organization> Organization { get; set; } = new List<Organization>();

        /// <summary>
        /// Gets or sets the list of <see cref="Parameter"/>.
        /// </summary>
        internal List<Parameter> Parameter { get; set; } = new List<Parameter>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParameterGroup"/>.
        /// </summary>
        internal List<ParameterGroup> ParameterGroup { get; set; } = new List<ParameterGroup>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParameterizedCategoryRule"/>.
        /// </summary>
        internal List<ParameterizedCategoryRule> ParameterizedCategoryRule { get; set; } = new List<ParameterizedCategoryRule>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParameterOverride"/>.
        /// </summary>
        internal List<ParameterOverride> ParameterOverride { get; set; } = new List<ParameterOverride>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParameterOverrideValueSet"/>.
        /// </summary>
        internal List<ParameterOverrideValueSet> ParameterOverrideValueSet { get; set; } = new List<ParameterOverrideValueSet>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParameterSubscription"/>.
        /// </summary>
        internal List<ParameterSubscription> ParameterSubscription { get; set; } = new List<ParameterSubscription>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParameterSubscriptionValueSet"/>.
        /// </summary>
        internal List<ParameterSubscriptionValueSet> ParameterSubscriptionValueSet { get; set; } = new List<ParameterSubscriptionValueSet>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParameterTypeComponent"/>.
        /// </summary>
        internal List<ParameterTypeComponent> ParameterTypeComponent { get; set; } = new List<ParameterTypeComponent>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParameterValueSet"/>.
        /// </summary>
        internal List<ParameterValueSet> ParameterValueSet { get; set; } = new List<ParameterValueSet>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParametricConstraint"/>.
        /// </summary>
        internal List<ParametricConstraint> ParametricConstraint { get; set; } = new List<ParametricConstraint>();

        /// <summary>
        /// Gets or sets the list of <see cref="Participant"/>.
        /// </summary>
        internal List<Participant> Participant { get; set; } = new List<Participant>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParticipantPermission"/>.
        /// </summary>
        internal List<ParticipantPermission> ParticipantPermission { get; set; } = new List<ParticipantPermission>();

        /// <summary>
        /// Gets or sets the list of <see cref="ParticipantRole"/>.
        /// </summary>
        internal List<ParticipantRole> ParticipantRole { get; set; } = new List<ParticipantRole>();

        /// <summary>
        /// Gets or sets the list of <see cref="Person"/>.
        /// </summary>
        internal List<Person> Person { get; set; } = new List<Person>();

        /// <summary>
        /// Gets or sets the list of <see cref="PersonPermission"/>.
        /// </summary>
        internal List<PersonPermission> PersonPermission { get; set; } = new List<PersonPermission>();

        /// <summary>
        /// Gets or sets the list of <see cref="PersonRole"/>.
        /// </summary>
        internal List<PersonRole> PersonRole { get; set; } = new List<PersonRole>();

        /// <summary>
        /// Gets or sets the list of <see cref="PossibleFiniteState"/>.
        /// </summary>
        internal List<PossibleFiniteState> PossibleFiniteState { get; set; } = new List<PossibleFiniteState>();

        /// <summary>
        /// Gets or sets the list of <see cref="PossibleFiniteStateList"/>.
        /// </summary>
        internal List<PossibleFiniteStateList> PossibleFiniteStateList { get; set; } = new List<PossibleFiniteStateList>();

        /// <summary>
        /// Gets or sets the list of <see cref="PrefixedUnit"/>.
        /// </summary>
        internal List<PrefixedUnit> PrefixedUnit { get; set; } = new List<PrefixedUnit>();

        /// <summary>
        /// Gets or sets the list of <see cref="Publication"/>.
        /// </summary>
        internal List<Publication> Publication { get; set; } = new List<Publication>();

        /// <summary>
        /// Gets or sets the list of <see cref="QuantityKindFactor"/>.
        /// </summary>
        internal List<QuantityKindFactor> QuantityKindFactor { get; set; } = new List<QuantityKindFactor>();

        /// <summary>
        /// Gets or sets the list of <see cref="RatioScale"/>.
        /// </summary>
        internal List<RatioScale> RatioScale { get; set; } = new List<RatioScale>();

        /// <summary>
        /// Gets or sets the list of <see cref="ReferencerRule"/>.
        /// </summary>
        internal List<ReferencerRule> ReferencerRule { get; set; } = new List<ReferencerRule>();

        /// <summary>
        /// Gets or sets the list of <see cref="ReferenceSource"/>.
        /// </summary>
        internal List<ReferenceSource> ReferenceSource { get; set; } = new List<ReferenceSource>();

        /// <summary>
        /// Gets or sets the list of <see cref="RelationalExpression"/>.
        /// </summary>
        internal List<RelationalExpression> RelationalExpression { get; set; } = new List<RelationalExpression>();

        /// <summary>
        /// Gets or sets the list of <see cref="Requirement"/>.
        /// </summary>
        internal List<Requirement> Requirement { get; set; } = new List<Requirement>();

        /// <summary>
        /// Gets or sets the list of <see cref="RequirementsGroup"/>.
        /// </summary>
        internal List<RequirementsGroup> RequirementsGroup { get; set; } = new List<RequirementsGroup>();

        /// <summary>
        /// Gets or sets the list of <see cref="RequirementsSpecification"/>.
        /// </summary>
        internal List<RequirementsSpecification> RequirementsSpecification { get; set; } = new List<RequirementsSpecification>();

        /// <summary>
        /// Gets or sets the list of <see cref="RuleVerificationList"/>.
        /// </summary>
        internal List<RuleVerificationList> RuleVerificationList { get; set; } = new List<RuleVerificationList>();

        /// <summary>
        /// Gets or sets the list of <see cref="RuleViolation"/>.
        /// </summary>
        internal List<RuleViolation> RuleViolation { get; set; } = new List<RuleViolation>();

        /// <summary>
        /// Gets or sets the list of <see cref="ScaleReferenceQuantityValue"/>.
        /// </summary>
        internal List<ScaleReferenceQuantityValue> ScaleReferenceQuantityValue { get; set; } = new List<ScaleReferenceQuantityValue>();

        /// <summary>
        /// Gets or sets the list of <see cref="ScaleValueDefinition"/>.
        /// </summary>
        internal List<ScaleValueDefinition> ScaleValueDefinition { get; set; } = new List<ScaleValueDefinition>();

        /// <summary>
        /// Gets or sets the list of <see cref="SimpleParameterValue"/>.
        /// </summary>
        internal List<SimpleParameterValue> SimpleParameterValue { get; set; } = new List<SimpleParameterValue>();

        /// <summary>
        /// Gets or sets the list of <see cref="SimpleQuantityKind"/>.
        /// </summary>
        internal List<SimpleQuantityKind> SimpleQuantityKind { get; set; } = new List<SimpleQuantityKind>();

        /// <summary>
        /// Gets or sets the list of <see cref="SimpleUnit"/>.
        /// </summary>
        internal List<SimpleUnit> SimpleUnit { get; set; } = new List<SimpleUnit>();

        /// <summary>
        /// Gets or sets the list of <see cref="SiteDirectory"/>.
        /// </summary>
        internal List<SiteDirectory> SiteDirectory { get; set; } = new List<SiteDirectory>();

        /// <summary>
        /// Gets or sets the list of <see cref="SiteLogEntry"/>.
        /// </summary>
        internal List<SiteLogEntry> SiteLogEntry { get; set; } = new List<SiteLogEntry>();

        /// <summary>
        /// Gets or sets the list of <see cref="SiteReferenceDataLibrary"/>.
        /// </summary>
        internal List<SiteReferenceDataLibrary> SiteReferenceDataLibrary { get; set; } = new List<SiteReferenceDataLibrary>();

        /// <summary>
        /// Gets or sets the list of <see cref="SpecializedQuantityKind"/>.
        /// </summary>
        internal List<SpecializedQuantityKind> SpecializedQuantityKind { get; set; } = new List<SpecializedQuantityKind>();

        /// <summary>
        /// Gets or sets the list of <see cref="TelephoneNumber"/>.
        /// </summary>
        internal List<TelephoneNumber> TelephoneNumber { get; set; } = new List<TelephoneNumber>();

        /// <summary>
        /// Gets or sets the list of <see cref="Term"/>.
        /// </summary>
        internal List<Term> Term { get; set; } = new List<Term>();

        /// <summary>
        /// Gets or sets the list of <see cref="TextParameterType"/>.
        /// </summary>
        internal List<TextParameterType> TextParameterType { get; set; } = new List<TextParameterType>();

        /// <summary>
        /// Gets or sets the list of <see cref="TimeOfDayParameterType"/>.
        /// </summary>
        internal List<TimeOfDayParameterType> TimeOfDayParameterType { get; set; } = new List<TimeOfDayParameterType>();

        /// <summary>
        /// Gets or sets the list of <see cref="UnitFactor"/>.
        /// </summary>
        internal List<UnitFactor> UnitFactor { get; set; } = new List<UnitFactor>();

        /// <summary>
        /// Gets or sets the list of <see cref="UnitPrefix"/>.
        /// </summary>
        internal List<UnitPrefix> UnitPrefix { get; set; } = new List<UnitPrefix>();

        /// <summary>
        /// Gets or sets the list of <see cref="UserPreference"/>.
        /// </summary>
        internal List<UserPreference> UserPreference { get; set; } = new List<UserPreference>();

        /// <summary>
        /// Gets or sets the list of <see cref="UserRuleVerification"/>.
        /// </summary>
        internal List<UserRuleVerification> UserRuleVerification { get; set; } = new List<UserRuleVerification>();

        /// <summary>
        /// Gets or sets the list of <see cref="ActionItem"/>.
        /// </summary>
        internal List<ActionItem> ActionItem { get; set; } = new List<ActionItem>();

        /// <summary>
        /// Gets or sets the list of <see cref="Approval"/>.
        /// </summary>
        internal List<Approval> Approval { get; set; } = new List<Approval>();

        /// <summary>
        /// Gets or sets the list of <see cref="BinaryNote"/>.
        /// </summary>
        internal List<BinaryNote> BinaryNote { get; set; } = new List<BinaryNote>();

        /// <summary>
        /// Gets or sets the list of <see cref="Book"/>.
        /// </summary>
        internal List<Book> Book { get; set; } = new List<Book>();

        /// <summary>
        /// Gets or sets the list of <see cref="Bounds"/>.
        /// </summary>
        internal List<Bounds> Bounds { get; set; } = new List<Bounds>();

        /// <summary>
        /// Gets or sets the list of <see cref="ChangeProposal"/>.
        /// </summary>
        internal List<ChangeProposal> ChangeProposal { get; set; } = new List<ChangeProposal>();

        /// <summary>
        /// Gets or sets the list of <see cref="ChangeRequest"/>.
        /// </summary>
        internal List<ChangeRequest> ChangeRequest { get; set; } = new List<ChangeRequest>();

        /// <summary>
        /// Gets or sets the list of <see cref="ContractChangeNotice"/>.
        /// </summary>
        internal List<ContractChangeNotice> ContractChangeNotice { get; set; } = new List<ContractChangeNotice>();

        /// <summary>
        /// Gets or sets the list of <see cref="DiagramCanvas"/>.
        /// </summary>
        internal List<DiagramCanvas> DiagramCanvas { get; set; } = new List<DiagramCanvas>();

        /// <summary>
        /// Gets or sets the list of <see cref="DiagramEdge"/>.
        /// </summary>
        internal List<DiagramEdge> DiagramEdge { get; set; } = new List<DiagramEdge>();

        /// <summary>
        /// Gets or sets the list of <see cref="DiagramObject"/>.
        /// </summary>
        internal List<DiagramObject> DiagramObject { get; set; } = new List<DiagramObject>();

        /// <summary>
        /// Gets or sets the list of <see cref="EngineeringModelDataDiscussionItem"/>.
        /// </summary>
        internal List<EngineeringModelDataDiscussionItem> EngineeringModelDataDiscussionItem { get; set; } = new List<EngineeringModelDataDiscussionItem>();

        /// <summary>
        /// Gets or sets the list of <see cref="EngineeringModelDataNote"/>.
        /// </summary>
        internal List<EngineeringModelDataNote> EngineeringModelDataNote { get; set; } = new List<EngineeringModelDataNote>();

        /// <summary>
        /// Gets or sets the list of <see cref="Goal"/>.
        /// </summary>
        internal List<Goal> Goal { get; set; } = new List<Goal>();

        /// <summary>
        /// Gets or sets the list of <see cref="ModellingThingReference"/>.
        /// </summary>
        internal List<ModellingThingReference> ModellingThingReference { get; set; } = new List<ModellingThingReference>();

        /// <summary>
        /// Gets or sets the list of <see cref="OwnedStyle"/>.
        /// </summary>
        internal List<OwnedStyle> OwnedStyle { get; set; } = new List<OwnedStyle>();

        /// <summary>
        /// Gets or sets the list of <see cref="Page"/>.
        /// </summary>
        internal List<Page> Page { get; set; } = new List<Page>();

        /// <summary>
        /// Gets or sets the list of <see cref="Point"/>.
        /// </summary>
        internal List<Point> Point { get; set; } = new List<Point>();

        /// <summary>
        /// Gets or sets the list of <see cref="RelationshipParameterValue"/>.
        /// </summary>
        internal List<RelationshipParameterValue> RelationshipParameterValue { get; set; } = new List<RelationshipParameterValue>();

        /// <summary>
        /// Gets or sets the list of <see cref="RequestForDeviation"/>.
        /// </summary>
        internal List<RequestForDeviation> RequestForDeviation { get; set; } = new List<RequestForDeviation>();

        /// <summary>
        /// Gets or sets the list of <see cref="RequestForWaiver"/>.
        /// </summary>
        internal List<RequestForWaiver> RequestForWaiver { get; set; } = new List<RequestForWaiver>();

        /// <summary>
        /// Gets or sets the list of <see cref="RequirementsContainerParameterValue"/>.
        /// </summary>
        internal List<RequirementsContainerParameterValue> RequirementsContainerParameterValue { get; set; } = new List<RequirementsContainerParameterValue>();

        /// <summary>
        /// Gets or sets the list of <see cref="ReviewItemDiscrepancy"/>.
        /// </summary>
        internal List<ReviewItemDiscrepancy> ReviewItemDiscrepancy { get; set; } = new List<ReviewItemDiscrepancy>();

        /// <summary>
        /// Gets or sets the list of <see cref="Section"/>.
        /// </summary>
        internal List<Section> Section { get; set; } = new List<Section>();

        /// <summary>
        /// Gets or sets the list of <see cref="SharedStyle"/>.
        /// </summary>
        internal List<SharedStyle> SharedStyle { get; set; } = new List<SharedStyle>();

        /// <summary>
        /// Gets or sets the list of <see cref="SiteDirectoryDataAnnotation"/>.
        /// </summary>
        internal List<SiteDirectoryDataAnnotation> SiteDirectoryDataAnnotation { get; set; } = new List<SiteDirectoryDataAnnotation>();

        /// <summary>
        /// Gets or sets the list of <see cref="SiteDirectoryDataDiscussionItem"/>.
        /// </summary>
        internal List<SiteDirectoryDataDiscussionItem> SiteDirectoryDataDiscussionItem { get; set; } = new List<SiteDirectoryDataDiscussionItem>();

        /// <summary>
        /// Gets or sets the list of <see cref="SiteDirectoryThingReference"/>.
        /// </summary>
        internal List<SiteDirectoryThingReference> SiteDirectoryThingReference { get; set; } = new List<SiteDirectoryThingReference>();

        /// <summary>
        /// Gets or sets the list of <see cref="Solution"/>.
        /// </summary>
        internal List<Solution> Solution { get; set; } = new List<Solution>();

        /// <summary>
        /// Gets or sets the list of <see cref="Stakeholder"/>.
        /// </summary>
        internal List<Stakeholder> Stakeholder { get; set; } = new List<Stakeholder>();

        /// <summary>
        /// Gets or sets the list of <see cref="StakeholderValue"/>.
        /// </summary>
        internal List<StakeholderValue> StakeholderValue { get; set; } = new List<StakeholderValue>();

        /// <summary>
        /// Gets or sets the list of <see cref="StakeHolderValueMap"/>.
        /// </summary>
        internal List<StakeHolderValueMap> StakeHolderValueMap { get; set; } = new List<StakeHolderValueMap>();

        /// <summary>
        /// Gets or sets the list of <see cref="StakeHolderValueMapSettings"/>.
        /// </summary>
        internal List<StakeHolderValueMapSettings> StakeHolderValueMapSettings { get; set; } = new List<StakeHolderValueMapSettings>();

        /// <summary>
        /// Gets or sets the list of <see cref="TextualNote"/>.
        /// </summary>
        internal List<TextualNote> TextualNote { get; set; } = new List<TextualNote>();

        /// <summary>
        /// Gets or sets the list of <see cref="ValueGroup"/>.
        /// </summary>
        internal List<ValueGroup> ValueGroup { get; set; } = new List<ValueGroup>();

        /// <summary>
        /// Gets or sets the list of <see cref="DependentParameterTypeAssignment"/>.
        /// </summary>
        internal List<DependentParameterTypeAssignment> DependentParameterTypeAssignment { get; set; } = new List<DependentParameterTypeAssignment>();

        /// <summary>
        /// Gets or sets the list of <see cref="IndependentParameterTypeAssignment"/>.
        /// </summary>
        internal List<IndependentParameterTypeAssignment> IndependentParameterTypeAssignment { get; set; } = new List<IndependentParameterTypeAssignment>();

        /// <summary>
        /// Gets or sets the list of <see cref="LogEntryChangelogItem"/>.
        /// </summary>
        internal List<LogEntryChangelogItem> LogEntryChangelogItem { get; set; } = new List<LogEntryChangelogItem>();

        /// <summary>
        /// Gets or sets the list of <see cref="OrganizationalParticipant"/>.
        /// </summary>
        internal List<OrganizationalParticipant> OrganizationalParticipant { get; set; } = new List<OrganizationalParticipant>();

        /// <summary>
        /// Gets or sets the list of <see cref="SampledFunctionParameterType"/>.
        /// </summary>
        internal List<SampledFunctionParameterType> SampledFunctionParameterType { get; set; } = new List<SampledFunctionParameterType>();
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
