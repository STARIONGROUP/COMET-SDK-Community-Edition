// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerProvider.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
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
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.Json;
    
    using CDP4Common;
    using CDP4Common.DTO;
    
    using CDP4JsonSerializer.Helper;

    /// <summary>
    /// A static class that provides method to serialize a <see cref="Thing"/> or a <see cref="ClasslessDTO"/>
    /// </summary>
    public static class SerializerProvider
    {
        /// <summary>
        /// The map containing the Serializers
        /// </summary>
        private static readonly Dictionary<string, IThingSerializer> SerializerMap = new()
        {
            { "ActionItem", new ActionItemSerializer() },
            { "ActualFiniteState", new ActualFiniteStateSerializer() },
            { "ActualFiniteStateList", new ActualFiniteStateListSerializer() },
            { "Alias", new AliasSerializer() },
            { "AndExpression", new AndExpressionSerializer() },
            { "Approval", new ApprovalSerializer() },
            { "ArrayParameterType", new ArrayParameterTypeSerializer() },
            { "BinaryNote", new BinaryNoteSerializer() },
            { "BinaryRelationship", new BinaryRelationshipSerializer() },
            { "BinaryRelationshipRule", new BinaryRelationshipRuleSerializer() },
            { "Book", new BookSerializer() },
            { "BooleanParameterType", new BooleanParameterTypeSerializer() },
            { "Bounds", new BoundsSerializer() },
            { "BuiltInRuleVerification", new BuiltInRuleVerificationSerializer() },
            { "Category", new CategorySerializer() },
            { "ChangeProposal", new ChangeProposalSerializer() },
            { "ChangeRequest", new ChangeRequestSerializer() },
            { "Citation", new CitationSerializer() },
            { "Color", new ColorSerializer() },
            { "CommonFileStore", new CommonFileStoreSerializer() },
            { "CompoundParameterType", new CompoundParameterTypeSerializer() },
            { "Constant", new ConstantSerializer() },
            { "ContractChangeNotice", new ContractChangeNoticeSerializer() },
            { "CyclicRatioScale", new CyclicRatioScaleSerializer() },
            { "DateParameterType", new DateParameterTypeSerializer() },
            { "DateTimeParameterType", new DateTimeParameterTypeSerializer() },
            { "DecompositionRule", new DecompositionRuleSerializer() },
            { "Definition", new DefinitionSerializer() },
            { "DependentParameterTypeAssignment", new DependentParameterTypeAssignmentSerializer() },
            { "DerivedQuantityKind", new DerivedQuantityKindSerializer() },
            { "DerivedUnit", new DerivedUnitSerializer() },
            { "DiagramCanvas", new DiagramCanvasSerializer() },
            { "DiagramEdge", new DiagramEdgeSerializer() },
            { "DiagramObject", new DiagramObjectSerializer() },
            { "DomainFileStore", new DomainFileStoreSerializer() },
            { "DomainOfExpertise", new DomainOfExpertiseSerializer() },
            { "DomainOfExpertiseGroup", new DomainOfExpertiseGroupSerializer() },
            { "ElementDefinition", new ElementDefinitionSerializer() },
            { "ElementUsage", new ElementUsageSerializer() },
            { "EmailAddress", new EmailAddressSerializer() },
            { "EngineeringModel", new EngineeringModelSerializer() },
            { "EngineeringModelDataDiscussionItem", new EngineeringModelDataDiscussionItemSerializer() },
            { "EngineeringModelDataNote", new EngineeringModelDataNoteSerializer() },
            { "EngineeringModelSetup", new EngineeringModelSetupSerializer() },
            { "EnumerationParameterType", new EnumerationParameterTypeSerializer() },
            { "EnumerationValueDefinition", new EnumerationValueDefinitionSerializer() },
            { "ExclusiveOrExpression", new ExclusiveOrExpressionSerializer() },
            { "ExternalIdentifierMap", new ExternalIdentifierMapSerializer() },
            { "File", new FileSerializer() },
            { "FileRevision", new FileRevisionSerializer() },
            { "FileType", new FileTypeSerializer() },
            { "Folder", new FolderSerializer() },
            { "Glossary", new GlossarySerializer() },
            { "Goal", new GoalSerializer() },
            { "HyperLink", new HyperLinkSerializer() },
            { "IdCorrespondence", new IdCorrespondenceSerializer() },
            { "IndependentParameterTypeAssignment", new IndependentParameterTypeAssignmentSerializer() },
            { "IntervalScale", new IntervalScaleSerializer() },
            { "Iteration", new IterationSerializer() },
            { "IterationSetup", new IterationSetupSerializer() },
            { "LinearConversionUnit", new LinearConversionUnitSerializer() },
            { "LogarithmicScale", new LogarithmicScaleSerializer() },
            { "LogEntryChangelogItem", new LogEntryChangelogItemSerializer() },
            { "MappingToReferenceScale", new MappingToReferenceScaleSerializer() },
            { "ModellingThingReference", new ModellingThingReferenceSerializer() },
            { "ModelLogEntry", new ModelLogEntrySerializer() },
            { "ModelReferenceDataLibrary", new ModelReferenceDataLibrarySerializer() },
            { "MultiRelationship", new MultiRelationshipSerializer() },
            { "MultiRelationshipRule", new MultiRelationshipRuleSerializer() },
            { "NaturalLanguage", new NaturalLanguageSerializer() },
            { "NestedElement", new NestedElementSerializer() },
            { "NestedParameter", new NestedParameterSerializer() },
            { "NotExpression", new NotExpressionSerializer() },
            { "Option", new OptionSerializer() },
            { "OrdinalScale", new OrdinalScaleSerializer() },
            { "OrExpression", new OrExpressionSerializer() },
            { "Organization", new OrganizationSerializer() },
            { "OrganizationalParticipant", new OrganizationalParticipantSerializer() },
            { "OwnedStyle", new OwnedStyleSerializer() },
            { "Page", new PageSerializer() },
            { "Parameter", new ParameterSerializer() },
            { "ParameterGroup", new ParameterGroupSerializer() },
            { "ParameterizedCategoryRule", new ParameterizedCategoryRuleSerializer() },
            { "ParameterOverride", new ParameterOverrideSerializer() },
            { "ParameterOverrideValueSet", new ParameterOverrideValueSetSerializer() },
            { "ParameterSubscription", new ParameterSubscriptionSerializer() },
            { "ParameterSubscriptionValueSet", new ParameterSubscriptionValueSetSerializer() },
            { "ParameterTypeComponent", new ParameterTypeComponentSerializer() },
            { "ParameterValueSet", new ParameterValueSetSerializer() },
            { "ParametricConstraint", new ParametricConstraintSerializer() },
            { "Participant", new ParticipantSerializer() },
            { "ParticipantPermission", new ParticipantPermissionSerializer() },
            { "ParticipantRole", new ParticipantRoleSerializer() },
            { "Person", new PersonSerializer() },
            { "PersonPermission", new PersonPermissionSerializer() },
            { "PersonRole", new PersonRoleSerializer() },
            { "Point", new PointSerializer() },
            { "PossibleFiniteState", new PossibleFiniteStateSerializer() },
            { "PossibleFiniteStateList", new PossibleFiniteStateListSerializer() },
            { "PrefixedUnit", new PrefixedUnitSerializer() },
            { "Publication", new PublicationSerializer() },
            { "QuantityKindFactor", new QuantityKindFactorSerializer() },
            { "RatioScale", new RatioScaleSerializer() },
            { "ReferencerRule", new ReferencerRuleSerializer() },
            { "ReferenceSource", new ReferenceSourceSerializer() },
            { "RelationalExpression", new RelationalExpressionSerializer() },
            { "RelationshipParameterValue", new RelationshipParameterValueSerializer() },
            { "RequestForDeviation", new RequestForDeviationSerializer() },
            { "RequestForWaiver", new RequestForWaiverSerializer() },
            { "Requirement", new RequirementSerializer() },
            { "RequirementsContainerParameterValue", new RequirementsContainerParameterValueSerializer() },
            { "RequirementsGroup", new RequirementsGroupSerializer() },
            { "RequirementsSpecification", new RequirementsSpecificationSerializer() },
            { "ReviewItemDiscrepancy", new ReviewItemDiscrepancySerializer() },
            { "RuleVerificationList", new RuleVerificationListSerializer() },
            { "RuleViolation", new RuleViolationSerializer() },
            { "SampledFunctionParameterType", new SampledFunctionParameterTypeSerializer() },
            { "ScaleReferenceQuantityValue", new ScaleReferenceQuantityValueSerializer() },
            { "ScaleValueDefinition", new ScaleValueDefinitionSerializer() },
            { "Section", new SectionSerializer() },
            { "SharedStyle", new SharedStyleSerializer() },
            { "SimpleParameterValue", new SimpleParameterValueSerializer() },
            { "SimpleQuantityKind", new SimpleQuantityKindSerializer() },
            { "SimpleUnit", new SimpleUnitSerializer() },
            { "SiteDirectory", new SiteDirectorySerializer() },
            { "SiteDirectoryDataAnnotation", new SiteDirectoryDataAnnotationSerializer() },
            { "SiteDirectoryDataDiscussionItem", new SiteDirectoryDataDiscussionItemSerializer() },
            { "SiteDirectoryThingReference", new SiteDirectoryThingReferenceSerializer() },
            { "SiteLogEntry", new SiteLogEntrySerializer() },
            { "SiteReferenceDataLibrary", new SiteReferenceDataLibrarySerializer() },
            { "Solution", new SolutionSerializer() },
            { "SpecializedQuantityKind", new SpecializedQuantityKindSerializer() },
            { "Stakeholder", new StakeholderSerializer() },
            { "StakeholderValue", new StakeholderValueSerializer() },
            { "StakeHolderValueMap", new StakeHolderValueMapSerializer() },
            { "StakeHolderValueMapSettings", new StakeHolderValueMapSettingsSerializer() },
            { "TelephoneNumber", new TelephoneNumberSerializer() },
            { "Term", new TermSerializer() },
            { "TextParameterType", new TextParameterTypeSerializer() },
            { "TextualNote", new TextualNoteSerializer() },
            { "TimeOfDayParameterType", new TimeOfDayParameterTypeSerializer() },
            { "UnitFactor", new UnitFactorSerializer() },
            { "UnitPrefix", new UnitPrefixSerializer() },
            { "UserPreference", new UserPreferenceSerializer() },
            { "UserRuleVerification", new UserRuleVerificationSerializer() },
            { "ValueGroup", new ValueGroupSerializer() },
        };

        /// <summary>
        /// Serialize a <see cref="Thing"/> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        public static void SerializeThing(this Thing thing, Utf8JsonWriter writer, Version requestedVersion)
        {
            if(!SerializerMap.TryGetValue(thing.ClassKind.ToString(), out var serializer))
            {
                throw new NotSupportedException($"The {thing.ClassKind} class is not registered");
            }
        
            serializer.Serialize(thing, writer, requestedVersion);
        }
        
        /// <summary>
        /// Serialize a <see cref="ClasslessDTO"/> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="classlessDto">The <see cref="ClasslessDTO"/></param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        public static void SerializeClasslessDto(this ClasslessDTO classlessDto, Utf8JsonWriter writer, Version requestedVersion)
        {
            if(!SerializerMap.TryGetValue(classlessDto["ClassKind"].ToString(), out var serializer))
            {
                throw new NotSupportedException($"The {classlessDto["ClassKind"]} class is not registered");
            }

            writer.WriteStartObject();

            foreach (var keyValue in classlessDto)
            {
                var key = Utils.LowercaseFirstLetter(keyValue.Key);
                serializer.SerializeProperty(key, keyValue.Value, writer, requestedVersion); 
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a <see cref="Thing"/> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <returns>A json representation of the <see cref="Thing"/></returns>
        public static string ToJsonString(this Thing thing)
        {
            if(!SerializerMap.TryGetValue(thing.ClassKind.ToString(), out var serializer))
            {
                throw new NotSupportedException($"The {thing.ClassKind} class is not registered");
            }

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream))
                {
                    serializer.Serialize(thing, writer);
                    writer.Flush();
                    stream.Flush();
                    return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
        }

        /// <summary>
        /// Serialize a <see cref="ClasslessDTO"/> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="classlessDto">The <see cref="ClasslessDTO"/></param>
        /// <returns>A json representation of the <see cref="ClasslessDTO"/></returns>
        public static string ToJsonString(this ClasslessDTO classlessDto)
        {
            if(!SerializerMap.TryGetValue(classlessDto["ClassKind"].ToString(), out var serializer))
            {
                throw new NotSupportedException($"The {classlessDto["ClassKind"]} class is not registered");
            }

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteStartObject();

                    foreach (var keyValue in classlessDto)
                    {
                        var key = Utils.LowercaseFirstLetter(keyValue.Key);
                        serializer.SerializeProperty(key, keyValue.Value, writer);
                    }

                    writer.WriteEndObject();

                    writer.Flush();
                    stream.Flush();
                    return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
