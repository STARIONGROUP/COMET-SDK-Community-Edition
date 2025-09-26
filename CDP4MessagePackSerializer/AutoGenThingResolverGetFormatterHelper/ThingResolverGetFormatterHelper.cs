// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingResolverGetFormatterHelper.cs" company="Starion Group S.A.">
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

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.DTO;
    
    using global::MessagePack.Formatters;

    /// <summary>
    /// Helper class that resolves a <see cref="IMessagePackFormatter"/> based on a <see cref="Type"/>
    /// </summary>
    internal static class ThingResolverGetFormatterHelper
    {
        // If type is concrete type, use type-formatter map
        private static readonly Dictionary<Type, object> FormatterMap = new Dictionary<Type, object>()
        {
            {typeof(Payload), new PayloadMessagePackFormatter()},
            {typeof(ActualFiniteState), new ActualFiniteStateMessagePackFormatter()},
            {typeof(ActualFiniteStateList), new ActualFiniteStateListMessagePackFormatter()},
            {typeof(Alias), new AliasMessagePackFormatter()},
            {typeof(AndExpression), new AndExpressionMessagePackFormatter()},
            {typeof(ArrayParameterType), new ArrayParameterTypeMessagePackFormatter()},
            {typeof(BinaryRelationship), new BinaryRelationshipMessagePackFormatter()},
            {typeof(BinaryRelationshipRule), new BinaryRelationshipRuleMessagePackFormatter()},
            {typeof(BooleanParameterType), new BooleanParameterTypeMessagePackFormatter()},
            {typeof(BuiltInRuleVerification), new BuiltInRuleVerificationMessagePackFormatter()},
            {typeof(Category), new CategoryMessagePackFormatter()},
            {typeof(Citation), new CitationMessagePackFormatter()},
            {typeof(Color), new ColorMessagePackFormatter()},
            {typeof(CommonFileStore), new CommonFileStoreMessagePackFormatter()},
            {typeof(CompoundParameterType), new CompoundParameterTypeMessagePackFormatter()},
            {typeof(Constant), new ConstantMessagePackFormatter()},
            {typeof(CyclicRatioScale), new CyclicRatioScaleMessagePackFormatter()},
            {typeof(DateParameterType), new DateParameterTypeMessagePackFormatter()},
            {typeof(DateTimeParameterType), new DateTimeParameterTypeMessagePackFormatter()},
            {typeof(DecompositionRule), new DecompositionRuleMessagePackFormatter()},
            {typeof(Definition), new DefinitionMessagePackFormatter()},
            {typeof(DerivedQuantityKind), new DerivedQuantityKindMessagePackFormatter()},
            {typeof(DerivedUnit), new DerivedUnitMessagePackFormatter()},
            {typeof(DomainFileStore), new DomainFileStoreMessagePackFormatter()},
            {typeof(DomainOfExpertise), new DomainOfExpertiseMessagePackFormatter()},
            {typeof(DomainOfExpertiseGroup), new DomainOfExpertiseGroupMessagePackFormatter()},
            {typeof(ElementDefinition), new ElementDefinitionMessagePackFormatter()},
            {typeof(ElementUsage), new ElementUsageMessagePackFormatter()},
            {typeof(EmailAddress), new EmailAddressMessagePackFormatter()},
            {typeof(EngineeringModel), new EngineeringModelMessagePackFormatter()},
            {typeof(EngineeringModelSetup), new EngineeringModelSetupMessagePackFormatter()},
            {typeof(EnumerationParameterType), new EnumerationParameterTypeMessagePackFormatter()},
            {typeof(EnumerationValueDefinition), new EnumerationValueDefinitionMessagePackFormatter()},
            {typeof(ExclusiveOrExpression), new ExclusiveOrExpressionMessagePackFormatter()},
            {typeof(ExternalIdentifierMap), new ExternalIdentifierMapMessagePackFormatter()},
            {typeof(File), new FileMessagePackFormatter()},
            {typeof(FileRevision), new FileRevisionMessagePackFormatter()},
            {typeof(FileType), new FileTypeMessagePackFormatter()},
            {typeof(Folder), new FolderMessagePackFormatter()},
            {typeof(Glossary), new GlossaryMessagePackFormatter()},
            {typeof(HyperLink), new HyperLinkMessagePackFormatter()},
            {typeof(IdCorrespondence), new IdCorrespondenceMessagePackFormatter()},
            {typeof(IntervalScale), new IntervalScaleMessagePackFormatter()},
            {typeof(Iteration), new IterationMessagePackFormatter()},
            {typeof(IterationSetup), new IterationSetupMessagePackFormatter()},
            {typeof(LinearConversionUnit), new LinearConversionUnitMessagePackFormatter()},
            {typeof(LogarithmicScale), new LogarithmicScaleMessagePackFormatter()},
            {typeof(MappingToReferenceScale), new MappingToReferenceScaleMessagePackFormatter()},
            {typeof(ModelLogEntry), new ModelLogEntryMessagePackFormatter()},
            {typeof(ModelReferenceDataLibrary), new ModelReferenceDataLibraryMessagePackFormatter()},
            {typeof(MultiRelationship), new MultiRelationshipMessagePackFormatter()},
            {typeof(MultiRelationshipRule), new MultiRelationshipRuleMessagePackFormatter()},
            {typeof(NaturalLanguage), new NaturalLanguageMessagePackFormatter()},
            {typeof(NestedElement), new NestedElementMessagePackFormatter()},
            {typeof(NestedParameter), new NestedParameterMessagePackFormatter()},
            {typeof(NotExpression), new NotExpressionMessagePackFormatter()},
            {typeof(Option), new OptionMessagePackFormatter()},
            {typeof(OrdinalScale), new OrdinalScaleMessagePackFormatter()},
            {typeof(OrExpression), new OrExpressionMessagePackFormatter()},
            {typeof(Organization), new OrganizationMessagePackFormatter()},
            {typeof(Parameter), new ParameterMessagePackFormatter()},
            {typeof(ParameterGroup), new ParameterGroupMessagePackFormatter()},
            {typeof(ParameterizedCategoryRule), new ParameterizedCategoryRuleMessagePackFormatter()},
            {typeof(ParameterOverride), new ParameterOverrideMessagePackFormatter()},
            {typeof(ParameterOverrideValueSet), new ParameterOverrideValueSetMessagePackFormatter()},
            {typeof(ParameterSubscription), new ParameterSubscriptionMessagePackFormatter()},
            {typeof(ParameterSubscriptionValueSet), new ParameterSubscriptionValueSetMessagePackFormatter()},
            {typeof(ParameterTypeComponent), new ParameterTypeComponentMessagePackFormatter()},
            {typeof(ParameterValueSet), new ParameterValueSetMessagePackFormatter()},
            {typeof(ParametricConstraint), new ParametricConstraintMessagePackFormatter()},
            {typeof(Participant), new ParticipantMessagePackFormatter()},
            {typeof(ParticipantPermission), new ParticipantPermissionMessagePackFormatter()},
            {typeof(ParticipantRole), new ParticipantRoleMessagePackFormatter()},
            {typeof(Person), new PersonMessagePackFormatter()},
            {typeof(PersonPermission), new PersonPermissionMessagePackFormatter()},
            {typeof(PersonRole), new PersonRoleMessagePackFormatter()},
            {typeof(PossibleFiniteState), new PossibleFiniteStateMessagePackFormatter()},
            {typeof(PossibleFiniteStateList), new PossibleFiniteStateListMessagePackFormatter()},
            {typeof(PrefixedUnit), new PrefixedUnitMessagePackFormatter()},
            {typeof(Publication), new PublicationMessagePackFormatter()},
            {typeof(QuantityKindFactor), new QuantityKindFactorMessagePackFormatter()},
            {typeof(RatioScale), new RatioScaleMessagePackFormatter()},
            {typeof(ReferencerRule), new ReferencerRuleMessagePackFormatter()},
            {typeof(ReferenceSource), new ReferenceSourceMessagePackFormatter()},
            {typeof(RelationalExpression), new RelationalExpressionMessagePackFormatter()},
            {typeof(Requirement), new RequirementMessagePackFormatter()},
            {typeof(RequirementsGroup), new RequirementsGroupMessagePackFormatter()},
            {typeof(RequirementsSpecification), new RequirementsSpecificationMessagePackFormatter()},
            {typeof(RuleVerificationList), new RuleVerificationListMessagePackFormatter()},
            {typeof(RuleViolation), new RuleViolationMessagePackFormatter()},
            {typeof(ScaleReferenceQuantityValue), new ScaleReferenceQuantityValueMessagePackFormatter()},
            {typeof(ScaleValueDefinition), new ScaleValueDefinitionMessagePackFormatter()},
            {typeof(SimpleParameterValue), new SimpleParameterValueMessagePackFormatter()},
            {typeof(SimpleQuantityKind), new SimpleQuantityKindMessagePackFormatter()},
            {typeof(SimpleUnit), new SimpleUnitMessagePackFormatter()},
            {typeof(SiteDirectory), new SiteDirectoryMessagePackFormatter()},
            {typeof(SiteLogEntry), new SiteLogEntryMessagePackFormatter()},
            {typeof(SiteReferenceDataLibrary), new SiteReferenceDataLibraryMessagePackFormatter()},
            {typeof(SpecializedQuantityKind), new SpecializedQuantityKindMessagePackFormatter()},
            {typeof(TelephoneNumber), new TelephoneNumberMessagePackFormatter()},
            {typeof(Term), new TermMessagePackFormatter()},
            {typeof(TextParameterType), new TextParameterTypeMessagePackFormatter()},
            {typeof(TimeOfDayParameterType), new TimeOfDayParameterTypeMessagePackFormatter()},
            {typeof(UnitFactor), new UnitFactorMessagePackFormatter()},
            {typeof(UnitPrefix), new UnitPrefixMessagePackFormatter()},
            {typeof(UserPreference), new UserPreferenceMessagePackFormatter()},
            {typeof(UserRuleVerification), new UserRuleVerificationMessagePackFormatter()},
            {typeof(ActionItem), new ActionItemMessagePackFormatter()},
            {typeof(Approval), new ApprovalMessagePackFormatter()},
            {typeof(BinaryNote), new BinaryNoteMessagePackFormatter()},
            {typeof(Book), new BookMessagePackFormatter()},
            {typeof(Bounds), new BoundsMessagePackFormatter()},
            {typeof(ChangeProposal), new ChangeProposalMessagePackFormatter()},
            {typeof(ChangeRequest), new ChangeRequestMessagePackFormatter()},
            {typeof(ContractChangeNotice), new ContractChangeNoticeMessagePackFormatter()},
            {typeof(DiagramCanvas), new DiagramCanvasMessagePackFormatter()},
            {typeof(DiagramEdge), new DiagramEdgeMessagePackFormatter()},
            {typeof(DiagramObject), new DiagramObjectMessagePackFormatter()},
            {typeof(EngineeringModelDataDiscussionItem), new EngineeringModelDataDiscussionItemMessagePackFormatter()},
            {typeof(EngineeringModelDataNote), new EngineeringModelDataNoteMessagePackFormatter()},
            {typeof(Goal), new GoalMessagePackFormatter()},
            {typeof(ModellingThingReference), new ModellingThingReferenceMessagePackFormatter()},
            {typeof(OwnedStyle), new OwnedStyleMessagePackFormatter()},
            {typeof(Page), new PageMessagePackFormatter()},
            {typeof(Point), new PointMessagePackFormatter()},
            {typeof(RelationshipParameterValue), new RelationshipParameterValueMessagePackFormatter()},
            {typeof(RequestForDeviation), new RequestForDeviationMessagePackFormatter()},
            {typeof(RequestForWaiver), new RequestForWaiverMessagePackFormatter()},
            {typeof(RequirementsContainerParameterValue), new RequirementsContainerParameterValueMessagePackFormatter()},
            {typeof(ReviewItemDiscrepancy), new ReviewItemDiscrepancyMessagePackFormatter()},
            {typeof(Section), new SectionMessagePackFormatter()},
            {typeof(SharedStyle), new SharedStyleMessagePackFormatter()},
            {typeof(SiteDirectoryDataAnnotation), new SiteDirectoryDataAnnotationMessagePackFormatter()},
            {typeof(SiteDirectoryDataDiscussionItem), new SiteDirectoryDataDiscussionItemMessagePackFormatter()},
            {typeof(SiteDirectoryThingReference), new SiteDirectoryThingReferenceMessagePackFormatter()},
            {typeof(Solution), new SolutionMessagePackFormatter()},
            {typeof(Stakeholder), new StakeholderMessagePackFormatter()},
            {typeof(StakeholderValue), new StakeholderValueMessagePackFormatter()},
            {typeof(StakeHolderValueMap), new StakeHolderValueMapMessagePackFormatter()},
            {typeof(StakeHolderValueMapSettings), new StakeHolderValueMapSettingsMessagePackFormatter()},
            {typeof(TextualNote), new TextualNoteMessagePackFormatter()},
            {typeof(ValueGroup), new ValueGroupMessagePackFormatter()},
            {typeof(DependentParameterTypeAssignment), new DependentParameterTypeAssignmentMessagePackFormatter()},
            {typeof(IndependentParameterTypeAssignment), new IndependentParameterTypeAssignmentMessagePackFormatter()},
            {typeof(LogEntryChangelogItem), new LogEntryChangelogItemMessagePackFormatter()},
            {typeof(OrganizationalParticipant), new OrganizationalParticipantMessagePackFormatter()},
            {typeof(SampledFunctionParameterType), new SampledFunctionParameterTypeMessagePackFormatter()},
        };

        /// <summary>
        /// Gets a <see cref="IMessagePackFormatter"/> for the specific <see cref="Type"/>
        /// </summary>
        /// <param name="t">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IMessagePackFormatter"/>
        /// </returns>
        internal static object GetFormatter(Type t)
        {
            object formatter;
            if (FormatterMap.TryGetValue(t, out formatter))
            {
                return formatter;
            }

            // If type can not get, must return null for fallback mechanism.
            return null;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
