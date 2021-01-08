// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoFactory.cs" company="RHEA System S.A.">
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.DTO;
    using Newtonsoft.Json.Linq;
    
    /// <summary>
    /// Utility class that is responsible for instantiating a <see cref="Thing"/>
    /// </summary>
    public static class DtoFactory
    {
        /// <summary>
        /// The type to Constructor map
        /// </summary>
        private static readonly Dictionary<string, Func<JObject, Thing>> DtoConstructorMap = new Dictionary<string, Func<JObject, Thing>>
        {
            { "ActionItem", ActionItemResolver.FromJsonObject },
            { "ActualFiniteState", ActualFiniteStateResolver.FromJsonObject },
            { "ActualFiniteStateList", ActualFiniteStateListResolver.FromJsonObject },
            { "Alias", AliasResolver.FromJsonObject },
            { "AndExpression", AndExpressionResolver.FromJsonObject },
            { "Approval", ApprovalResolver.FromJsonObject },
            { "ArrayParameterType", ArrayParameterTypeResolver.FromJsonObject },
            { "BinaryNote", BinaryNoteResolver.FromJsonObject },
            { "BinaryRelationship", BinaryRelationshipResolver.FromJsonObject },
            { "BinaryRelationshipRule", BinaryRelationshipRuleResolver.FromJsonObject },
            { "Book", BookResolver.FromJsonObject },
            { "BooleanParameterType", BooleanParameterTypeResolver.FromJsonObject },
            { "Bounds", BoundsResolver.FromJsonObject },
            { "BuiltInRuleVerification", BuiltInRuleVerificationResolver.FromJsonObject },
            { "Category", CategoryResolver.FromJsonObject },
            { "ChangeProposal", ChangeProposalResolver.FromJsonObject },
            { "ChangeRequest", ChangeRequestResolver.FromJsonObject },
            { "Citation", CitationResolver.FromJsonObject },
            { "Color", ColorResolver.FromJsonObject },
            { "CommonFileStore", CommonFileStoreResolver.FromJsonObject },
            { "CompoundParameterType", CompoundParameterTypeResolver.FromJsonObject },
            { "Constant", ConstantResolver.FromJsonObject },
            { "ContractChangeNotice", ContractChangeNoticeResolver.FromJsonObject },
            { "CyclicRatioScale", CyclicRatioScaleResolver.FromJsonObject },
            { "DateParameterType", DateParameterTypeResolver.FromJsonObject },
            { "DateTimeParameterType", DateTimeParameterTypeResolver.FromJsonObject },
            { "DecompositionRule", DecompositionRuleResolver.FromJsonObject },
            { "Definition", DefinitionResolver.FromJsonObject },
            { "DependentParameterTypeAssignment", DependentParameterTypeAssignmentResolver.FromJsonObject },
            { "DerivedQuantityKind", DerivedQuantityKindResolver.FromJsonObject },
            { "DerivedUnit", DerivedUnitResolver.FromJsonObject },
            { "DiagramCanvas", DiagramCanvasResolver.FromJsonObject },
            { "DiagramEdge", DiagramEdgeResolver.FromJsonObject },
            { "DiagramObject", DiagramObjectResolver.FromJsonObject },
            { "DomainFileStore", DomainFileStoreResolver.FromJsonObject },
            { "DomainOfExpertise", DomainOfExpertiseResolver.FromJsonObject },
            { "DomainOfExpertiseGroup", DomainOfExpertiseGroupResolver.FromJsonObject },
            { "ElementDefinition", ElementDefinitionResolver.FromJsonObject },
            { "ElementUsage", ElementUsageResolver.FromJsonObject },
            { "EmailAddress", EmailAddressResolver.FromJsonObject },
            { "EngineeringModel", EngineeringModelResolver.FromJsonObject },
            { "EngineeringModelDataDiscussionItem", EngineeringModelDataDiscussionItemResolver.FromJsonObject },
            { "EngineeringModelDataNote", EngineeringModelDataNoteResolver.FromJsonObject },
            { "EngineeringModelSetup", EngineeringModelSetupResolver.FromJsonObject },
            { "EnumerationParameterType", EnumerationParameterTypeResolver.FromJsonObject },
            { "EnumerationValueDefinition", EnumerationValueDefinitionResolver.FromJsonObject },
            { "ExclusiveOrExpression", ExclusiveOrExpressionResolver.FromJsonObject },
            { "ExternalIdentifierMap", ExternalIdentifierMapResolver.FromJsonObject },
            { "File", FileResolver.FromJsonObject },
            { "FileRevision", FileRevisionResolver.FromJsonObject },
            { "FileType", FileTypeResolver.FromJsonObject },
            { "Folder", FolderResolver.FromJsonObject },
            { "Glossary", GlossaryResolver.FromJsonObject },
            { "Goal", GoalResolver.FromJsonObject },
            { "HyperLink", HyperLinkResolver.FromJsonObject },
            { "IdCorrespondence", IdCorrespondenceResolver.FromJsonObject },
            { "IndependentParameterTypeAssignment", IndependentParameterTypeAssignmentResolver.FromJsonObject },
            { "IntervalScale", IntervalScaleResolver.FromJsonObject },
            { "Iteration", IterationResolver.FromJsonObject },
            { "IterationSetup", IterationSetupResolver.FromJsonObject },
            { "LinearConversionUnit", LinearConversionUnitResolver.FromJsonObject },
            { "LogarithmicScale", LogarithmicScaleResolver.FromJsonObject },
            { "LogEntryChangelogItem", LogEntryChangelogItemResolver.FromJsonObject },
            { "MappingToReferenceScale", MappingToReferenceScaleResolver.FromJsonObject },
            { "ModellingThingReference", ModellingThingReferenceResolver.FromJsonObject },
            { "ModelLogEntry", ModelLogEntryResolver.FromJsonObject },
            { "ModelReferenceDataLibrary", ModelReferenceDataLibraryResolver.FromJsonObject },
            { "MultiRelationship", MultiRelationshipResolver.FromJsonObject },
            { "MultiRelationshipRule", MultiRelationshipRuleResolver.FromJsonObject },
            { "NaturalLanguage", NaturalLanguageResolver.FromJsonObject },
            { "NestedElement", NestedElementResolver.FromJsonObject },
            { "NestedParameter", NestedParameterResolver.FromJsonObject },
            { "NotExpression", NotExpressionResolver.FromJsonObject },
            { "Option", OptionResolver.FromJsonObject },
            { "OrdinalScale", OrdinalScaleResolver.FromJsonObject },
            { "OrExpression", OrExpressionResolver.FromJsonObject },
            { "Organization", OrganizationResolver.FromJsonObject },
            { "OrganizationalParticipant", OrganizationalParticipantResolver.FromJsonObject },
            { "OwnedStyle", OwnedStyleResolver.FromJsonObject },
            { "Page", PageResolver.FromJsonObject },
            { "Parameter", ParameterResolver.FromJsonObject },
            { "ParameterGroup", ParameterGroupResolver.FromJsonObject },
            { "ParameterizedCategoryRule", ParameterizedCategoryRuleResolver.FromJsonObject },
            { "ParameterOverride", ParameterOverrideResolver.FromJsonObject },
            { "ParameterOverrideValueSet", ParameterOverrideValueSetResolver.FromJsonObject },
            { "ParameterSubscription", ParameterSubscriptionResolver.FromJsonObject },
            { "ParameterSubscriptionValueSet", ParameterSubscriptionValueSetResolver.FromJsonObject },
            { "ParameterTypeComponent", ParameterTypeComponentResolver.FromJsonObject },
            { "ParameterValueSet", ParameterValueSetResolver.FromJsonObject },
            { "ParametricConstraint", ParametricConstraintResolver.FromJsonObject },
            { "Participant", ParticipantResolver.FromJsonObject },
            { "ParticipantPermission", ParticipantPermissionResolver.FromJsonObject },
            { "ParticipantRole", ParticipantRoleResolver.FromJsonObject },
            { "Person", PersonResolver.FromJsonObject },
            { "PersonPermission", PersonPermissionResolver.FromJsonObject },
            { "PersonRole", PersonRoleResolver.FromJsonObject },
            { "Point", PointResolver.FromJsonObject },
            { "PossibleFiniteState", PossibleFiniteStateResolver.FromJsonObject },
            { "PossibleFiniteStateList", PossibleFiniteStateListResolver.FromJsonObject },
            { "PrefixedUnit", PrefixedUnitResolver.FromJsonObject },
            { "Publication", PublicationResolver.FromJsonObject },
            { "QuantityKindFactor", QuantityKindFactorResolver.FromJsonObject },
            { "RatioScale", RatioScaleResolver.FromJsonObject },
            { "ReferencerRule", ReferencerRuleResolver.FromJsonObject },
            { "ReferenceSource", ReferenceSourceResolver.FromJsonObject },
            { "RelationalExpression", RelationalExpressionResolver.FromJsonObject },
            { "RelationshipParameterValue", RelationshipParameterValueResolver.FromJsonObject },
            { "RequestForDeviation", RequestForDeviationResolver.FromJsonObject },
            { "RequestForWaiver", RequestForWaiverResolver.FromJsonObject },
            { "Requirement", RequirementResolver.FromJsonObject },
            { "RequirementsContainerParameterValue", RequirementsContainerParameterValueResolver.FromJsonObject },
            { "RequirementsGroup", RequirementsGroupResolver.FromJsonObject },
            { "RequirementsSpecification", RequirementsSpecificationResolver.FromJsonObject },
            { "ReviewItemDiscrepancy", ReviewItemDiscrepancyResolver.FromJsonObject },
            { "RuleVerificationList", RuleVerificationListResolver.FromJsonObject },
            { "RuleViolation", RuleViolationResolver.FromJsonObject },
            { "SampledFunctionParameterType", SampledFunctionParameterTypeResolver.FromJsonObject },
            { "ScaleReferenceQuantityValue", ScaleReferenceQuantityValueResolver.FromJsonObject },
            { "ScaleValueDefinition", ScaleValueDefinitionResolver.FromJsonObject },
            { "Section", SectionResolver.FromJsonObject },
            { "SharedStyle", SharedStyleResolver.FromJsonObject },
            { "SimpleParameterValue", SimpleParameterValueResolver.FromJsonObject },
            { "SimpleQuantityKind", SimpleQuantityKindResolver.FromJsonObject },
            { "SimpleUnit", SimpleUnitResolver.FromJsonObject },
            { "SiteDirectory", SiteDirectoryResolver.FromJsonObject },
            { "SiteDirectoryDataAnnotation", SiteDirectoryDataAnnotationResolver.FromJsonObject },
            { "SiteDirectoryDataDiscussionItem", SiteDirectoryDataDiscussionItemResolver.FromJsonObject },
            { "SiteDirectoryThingReference", SiteDirectoryThingReferenceResolver.FromJsonObject },
            { "SiteLogEntry", SiteLogEntryResolver.FromJsonObject },
            { "SiteReferenceDataLibrary", SiteReferenceDataLibraryResolver.FromJsonObject },
            { "Solution", SolutionResolver.FromJsonObject },
            { "SpecializedQuantityKind", SpecializedQuantityKindResolver.FromJsonObject },
            { "Stakeholder", StakeholderResolver.FromJsonObject },
            { "StakeholderValue", StakeholderValueResolver.FromJsonObject },
            { "StakeHolderValueMap", StakeHolderValueMapResolver.FromJsonObject },
            { "StakeHolderValueMapSettings", StakeHolderValueMapSettingsResolver.FromJsonObject },
            { "TelephoneNumber", TelephoneNumberResolver.FromJsonObject },
            { "Term", TermResolver.FromJsonObject },
            { "TextParameterType", TextParameterTypeResolver.FromJsonObject },
            { "TextualNote", TextualNoteResolver.FromJsonObject },
            { "TimeOfDayParameterType", TimeOfDayParameterTypeResolver.FromJsonObject },
            { "UnitFactor", UnitFactorResolver.FromJsonObject },
            { "UnitPrefix", UnitPrefixResolver.FromJsonObject },
            { "UserPreference", UserPreferenceResolver.FromJsonObject },
            { "UserRuleVerification", UserRuleVerificationResolver.FromJsonObject },
            { "ValueGroup", ValueGroupResolver.FromJsonObject },
        };

        /// <summary>
        /// Instantiates a new <see cref="Thing"/> from a <see cref="JObject"/>
        /// </summary>
        /// <param name="dataObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Thing"/> to instantiate</returns>
        public static Thing ToDto(this JObject dataObject)
        {
            var classKind = dataObject["classKind"].ToString();
            Func<JObject, Thing> constructor;
            if (!DtoConstructorMap.TryGetValue(classKind, out constructor))
            {
                throw new InvalidOperationException(string.Format("The dto resolver was not found for {0}", classKind));
            }

            return constructor(dataObject);
        }
    }
}
