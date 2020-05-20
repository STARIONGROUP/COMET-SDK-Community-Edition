// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetaDataProvider.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Kamil Wojnowski, 
//            Nathanael Smiechowski
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
// <summary>
//   This is an auto-generated MetaInfo class. Any manual changes on this file will be overwritten.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.MetaInfo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Utility class that responsible for providing meta-data for any <see cref="Thing"/>.
    /// </summary>
    public class MetaDataProvider : IMetaDataProvider
    {
        /// <summary>
        /// The default model version.
        /// </summary>
        private const string DefaultModelVersion = "1.0.0";

        /// <summary>
        /// A map containing all the metadata for a <see cref="Thing"/>.
        /// </summary>
        private readonly Dictionary<string, IMetaInfo> metaDataMap = new Dictionary<string, IMetaInfo>
        {
            { "ActionItem", new ActionItemMetaInfo() },
            { "ActualFiniteState", new ActualFiniteStateMetaInfo() },
            { "ActualFiniteStateList", new ActualFiniteStateListMetaInfo() },
            { "Alias", new AliasMetaInfo() },
            { "AndExpression", new AndExpressionMetaInfo() },
            { "Approval", new ApprovalMetaInfo() },
            { "ArrayParameterType", new ArrayParameterTypeMetaInfo() },
            { "BinaryNote", new BinaryNoteMetaInfo() },
            { "BinaryRelationship", new BinaryRelationshipMetaInfo() },
            { "BinaryRelationshipRule", new BinaryRelationshipRuleMetaInfo() },
            { "Book", new BookMetaInfo() },
            { "BooleanExpression", new BooleanExpressionMetaInfo() },
            { "BooleanParameterType", new BooleanParameterTypeMetaInfo() },
            { "Bounds", new BoundsMetaInfo() },
            { "BuiltInRuleVerification", new BuiltInRuleVerificationMetaInfo() },
            { "Category", new CategoryMetaInfo() },
            { "ChangeProposal", new ChangeProposalMetaInfo() },
            { "ChangeRequest", new ChangeRequestMetaInfo() },
            { "Citation", new CitationMetaInfo() },
            { "Color", new ColorMetaInfo() },
            { "CommonFileStore", new CommonFileStoreMetaInfo() },
            { "CompoundParameterType", new CompoundParameterTypeMetaInfo() },
            { "Constant", new ConstantMetaInfo() },
            { "ContractChangeNotice", new ContractChangeNoticeMetaInfo() },
            { "ContractDeviation", new ContractDeviationMetaInfo() },
            { "ConversionBasedUnit", new ConversionBasedUnitMetaInfo() },
            { "CyclicRatioScale", new CyclicRatioScaleMetaInfo() },
            { "DateParameterType", new DateParameterTypeMetaInfo() },
            { "DateTimeParameterType", new DateTimeParameterTypeMetaInfo() },
            { "DecompositionRule", new DecompositionRuleMetaInfo() },
            { "DefinedThing", new DefinedThingMetaInfo() },
            { "Definition", new DefinitionMetaInfo() },
            { "DerivedQuantityKind", new DerivedQuantityKindMetaInfo() },
            { "DerivedUnit", new DerivedUnitMetaInfo() },
            { "DiagramCanvas", new DiagramCanvasMetaInfo() },
            { "DiagramEdge", new DiagramEdgeMetaInfo() },
            { "DiagramElementContainer", new DiagramElementContainerMetaInfo() },
            { "DiagramElementThing", new DiagramElementThingMetaInfo() },
            { "DiagrammingStyle", new DiagrammingStyleMetaInfo() },
            { "DiagramObject", new DiagramObjectMetaInfo() },
            { "DiagramShape", new DiagramShapeMetaInfo() },
            { "DiagramThingBase", new DiagramThingBaseMetaInfo() },
            { "DiscussionItem", new DiscussionItemMetaInfo() },
            { "DomainFileStore", new DomainFileStoreMetaInfo() },
            { "DomainOfExpertise", new DomainOfExpertiseMetaInfo() },
            { "DomainOfExpertiseGroup", new DomainOfExpertiseGroupMetaInfo() },
            { "ElementBase", new ElementBaseMetaInfo() },
            { "ElementDefinition", new ElementDefinitionMetaInfo() },
            { "ElementUsage", new ElementUsageMetaInfo() },
            { "EmailAddress", new EmailAddressMetaInfo() },
            { "EngineeringModel", new EngineeringModelMetaInfo() },
            { "EngineeringModelDataAnnotation", new EngineeringModelDataAnnotationMetaInfo() },
            { "EngineeringModelDataDiscussionItem", new EngineeringModelDataDiscussionItemMetaInfo() },
            { "EngineeringModelDataNote", new EngineeringModelDataNoteMetaInfo() },
            { "EngineeringModelSetup", new EngineeringModelSetupMetaInfo() },
            { "EnumerationParameterType", new EnumerationParameterTypeMetaInfo() },
            { "EnumerationValueDefinition", new EnumerationValueDefinitionMetaInfo() },
            { "ExclusiveOrExpression", new ExclusiveOrExpressionMetaInfo() },
            { "ExternalIdentifierMap", new ExternalIdentifierMapMetaInfo() },
            { "File", new FileMetaInfo() },
            { "FileRevision", new FileRevisionMetaInfo() },
            { "FileStore", new FileStoreMetaInfo() },
            { "FileType", new FileTypeMetaInfo() },
            { "Folder", new FolderMetaInfo() },
            { "GenericAnnotation", new GenericAnnotationMetaInfo() },
            { "Glossary", new GlossaryMetaInfo() },
            { "Goal", new GoalMetaInfo() },
            { "HyperLink", new HyperLinkMetaInfo() },
            { "IdCorrespondence", new IdCorrespondenceMetaInfo() },
            { "IntervalScale", new IntervalScaleMetaInfo() },
            { "Iteration", new IterationMetaInfo() },
            { "IterationSetup", new IterationSetupMetaInfo() },
            { "LinearConversionUnit", new LinearConversionUnitMetaInfo() },
            { "LogarithmicScale", new LogarithmicScaleMetaInfo() },
            { "MappingToReferenceScale", new MappingToReferenceScaleMetaInfo() },
            { "MeasurementScale", new MeasurementScaleMetaInfo() },
            { "MeasurementUnit", new MeasurementUnitMetaInfo() },
            { "ModellingAnnotationItem", new ModellingAnnotationItemMetaInfo() },
            { "ModellingThingReference", new ModellingThingReferenceMetaInfo() },
            { "ModelLogEntry", new ModelLogEntryMetaInfo() },
            { "ModelReferenceDataLibrary", new ModelReferenceDataLibraryMetaInfo() },
            { "MultiRelationship", new MultiRelationshipMetaInfo() },
            { "MultiRelationshipRule", new MultiRelationshipRuleMetaInfo() },
            { "NaturalLanguage", new NaturalLanguageMetaInfo() },
            { "NestedElement", new NestedElementMetaInfo() },
            { "NestedParameter", new NestedParameterMetaInfo() },
            { "Note", new NoteMetaInfo() },
            { "NotExpression", new NotExpressionMetaInfo() },
            { "Option", new OptionMetaInfo() },
            { "OrdinalScale", new OrdinalScaleMetaInfo() },
            { "OrExpression", new OrExpressionMetaInfo() },
            { "Organization", new OrganizationMetaInfo() },
            { "OwnedStyle", new OwnedStyleMetaInfo() },
            { "Page", new PageMetaInfo() },
            { "Parameter", new ParameterMetaInfo() },
            { "ParameterBase", new ParameterBaseMetaInfo() },
            { "ParameterGroup", new ParameterGroupMetaInfo() },
            { "ParameterizedCategoryRule", new ParameterizedCategoryRuleMetaInfo() },
            { "ParameterOrOverrideBase", new ParameterOrOverrideBaseMetaInfo() },
            { "ParameterOverride", new ParameterOverrideMetaInfo() },
            { "ParameterOverrideValueSet", new ParameterOverrideValueSetMetaInfo() },
            { "ParameterSubscription", new ParameterSubscriptionMetaInfo() },
            { "ParameterSubscriptionValueSet", new ParameterSubscriptionValueSetMetaInfo() },
            { "ParameterType", new ParameterTypeMetaInfo() },
            { "ParameterTypeComponent", new ParameterTypeComponentMetaInfo() },
            { "ParameterValue", new ParameterValueMetaInfo() },
            { "ParameterValueSet", new ParameterValueSetMetaInfo() },
            { "ParameterValueSetBase", new ParameterValueSetBaseMetaInfo() },
            { "ParametricConstraint", new ParametricConstraintMetaInfo() },
            { "Participant", new ParticipantMetaInfo() },
            { "ParticipantPermission", new ParticipantPermissionMetaInfo() },
            { "ParticipantRole", new ParticipantRoleMetaInfo() },
            { "Person", new PersonMetaInfo() },
            { "PersonPermission", new PersonPermissionMetaInfo() },
            { "PersonRole", new PersonRoleMetaInfo() },
            { "Point", new PointMetaInfo() },
            { "PossibleFiniteState", new PossibleFiniteStateMetaInfo() },
            { "PossibleFiniteStateList", new PossibleFiniteStateListMetaInfo() },
            { "PrefixedUnit", new PrefixedUnitMetaInfo() },
            { "Publication", new PublicationMetaInfo() },
            { "QuantityKind", new QuantityKindMetaInfo() },
            { "QuantityKindFactor", new QuantityKindFactorMetaInfo() },
            { "RatioScale", new RatioScaleMetaInfo() },
            { "ReferenceDataLibrary", new ReferenceDataLibraryMetaInfo() },
            { "ReferencerRule", new ReferencerRuleMetaInfo() },
            { "ReferenceSource", new ReferenceSourceMetaInfo() },
            { "RelationalExpression", new RelationalExpressionMetaInfo() },
            { "Relationship", new RelationshipMetaInfo() },
            { "RelationshipParameterValue", new RelationshipParameterValueMetaInfo() },
            { "RequestForDeviation", new RequestForDeviationMetaInfo() },
            { "RequestForWaiver", new RequestForWaiverMetaInfo() },
            { "Requirement", new RequirementMetaInfo() },
            { "RequirementsContainer", new RequirementsContainerMetaInfo() },
            { "RequirementsContainerParameterValue", new RequirementsContainerParameterValueMetaInfo() },
            { "RequirementsGroup", new RequirementsGroupMetaInfo() },
            { "RequirementsSpecification", new RequirementsSpecificationMetaInfo() },
            { "ReviewItemDiscrepancy", new ReviewItemDiscrepancyMetaInfo() },
            { "Rule", new RuleMetaInfo() },
            { "RuleVerification", new RuleVerificationMetaInfo() },
            { "RuleVerificationList", new RuleVerificationListMetaInfo() },
            { "RuleViolation", new RuleViolationMetaInfo() },
            { "ScalarParameterType", new ScalarParameterTypeMetaInfo() },
            { "ScaleReferenceQuantityValue", new ScaleReferenceQuantityValueMetaInfo() },
            { "ScaleValueDefinition", new ScaleValueDefinitionMetaInfo() },
            { "Section", new SectionMetaInfo() },
            { "SharedStyle", new SharedStyleMetaInfo() },
            { "SimpleParameterizableThing", new SimpleParameterizableThingMetaInfo() },
            { "SimpleParameterValue", new SimpleParameterValueMetaInfo() },
            { "SimpleQuantityKind", new SimpleQuantityKindMetaInfo() },
            { "SimpleUnit", new SimpleUnitMetaInfo() },
            { "SiteDirectory", new SiteDirectoryMetaInfo() },
            { "SiteDirectoryDataAnnotation", new SiteDirectoryDataAnnotationMetaInfo() },
            { "SiteDirectoryDataDiscussionItem", new SiteDirectoryDataDiscussionItemMetaInfo() },
            { "SiteDirectoryThingReference", new SiteDirectoryThingReferenceMetaInfo() },
            { "SiteLogEntry", new SiteLogEntryMetaInfo() },
            { "SiteReferenceDataLibrary", new SiteReferenceDataLibraryMetaInfo() },
            { "Solution", new SolutionMetaInfo() },
            { "SpecializedQuantityKind", new SpecializedQuantityKindMetaInfo() },
            { "Stakeholder", new StakeholderMetaInfo() },
            { "StakeholderValue", new StakeholderValueMetaInfo() },
            { "StakeHolderValueMap", new StakeHolderValueMapMetaInfo() },
            { "StakeHolderValueMapSettings", new StakeHolderValueMapSettingsMetaInfo() },
            { "TelephoneNumber", new TelephoneNumberMetaInfo() },
            { "Term", new TermMetaInfo() },
            { "TextParameterType", new TextParameterTypeMetaInfo() },
            { "TextualNote", new TextualNoteMetaInfo() },
            { "Thing", new ThingMetaInfo() },
            { "ThingReference", new ThingReferenceMetaInfo() },
            { "TimeOfDayParameterType", new TimeOfDayParameterTypeMetaInfo() },
            { "TopContainer", new TopContainerMetaInfo() },
            { "UnitFactor", new UnitFactorMetaInfo() },
            { "UnitPrefix", new UnitPrefixMetaInfo() },
            { "UserPreference", new UserPreferenceMetaInfo() },
            { "UserRuleVerification", new UserRuleVerificationMetaInfo() },
            { "ValueGroup", new ValueGroupMetaInfo() },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataProvider"/> class.
        /// </summary>
        public MetaDataProvider()
        {
        }

        /// <summary>
        /// Returns a meta info instance based on the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// A meta info instance.
        /// </returns>
        /// <exception cref="TypeLoadException">
        /// If type name not supported
        /// </exception>
        public IMetaInfo GetMetaInfo(string typeName)
        {
            if (!this.metaDataMap.ContainsKey(typeName))
            {
                throw new TypeLoadException(string.Format("Type not supported {0}", typeName));
            }

            return this.metaDataMap[typeName];
        }

        /// <summary>
        /// Get the base type name of the supplied type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The base type or the same type name if class is the inheritance root.
        /// </returns>
        public string BaseType(string typeName)
        {
            var metaInfo = this.GetMetaInfo(typeName);
            return metaInfo.BaseType;
        }

        /// <summary>
        /// Get the class version for the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        public string GetClassVersion(string typeName)
        {
            var metaInfo = this.GetMetaInfo(typeName);
            return metaInfo.ClassVersion ?? DefaultModelVersion;
        }

        /// <summary>
        /// Get the property version for the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        public string GetPropertyVersion(string typeName, string propertyName)
        {
            var metaInfo = this.GetMetaInfo(typeName);
            return metaInfo.GetPropertyVersion(propertyName) ?? DefaultModelVersion;
        }
    }
}
