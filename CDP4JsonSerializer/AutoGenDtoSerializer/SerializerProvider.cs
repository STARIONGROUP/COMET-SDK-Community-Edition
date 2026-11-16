// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerProvider.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2026 Starion Group S.A.
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
    using System.Buffers;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.Json;
    
    using CDP4Common;
    using CDP4Common.CommonData;

    using CDP4JsonSerializer.Helper;

    using Thing = CDP4Common.DTO.Thing;

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
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="thing"/>, <paramref name="writer"/> or <paramref name="requestedVersion"/> is null</exception>
        /// <exception cref="NotSupportedException">Thrown when no serializer is registered for the <see cref="ClassKind"/> of the <paramref name="thing"/></exception>
        public static void SerializeThing(this Thing thing, Utf8JsonWriter writer, Version requestedVersion)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (requestedVersion == null)
            {
                throw new ArgumentNullException(nameof(requestedVersion));
            }

            GetSerializer(thing.ClassKind).Serialize(thing, writer, requestedVersion);
        }

        /// <summary>
        /// Serialize a <see cref="Thing"/> into an <see cref="Utf8JsonWriter" /> without a requested data model version:
        /// every property of the <see cref="Thing"/> is written, regardless of the data model version it was introduced in.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /> to write to. The writer is owned by the caller and is not flushed by this method,
        /// which allows the same writer (and its underlying buffer) to be reused for many <see cref="Thing"/>s with <see cref="Utf8JsonWriter.Reset()"/>.</param>
        /// <remarks>
        /// This is the allocation-friendly way to produce UTF-8 JSON for a <see cref="Thing"/>: no intermediate <see cref="string"/> or byte array is created.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="thing"/> or <paramref name="writer"/> is null</exception>
        /// <exception cref="NotSupportedException">Thrown when no serializer is registered for the <see cref="ClassKind"/> of the <paramref name="thing"/></exception>
        public static void SerializeThing(this Thing thing, Utf8JsonWriter writer)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing));
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            GetSerializer(thing.ClassKind).Serialize(thing, writer);
        }

        /// <summary>
        /// Serialize a <see cref="Thing"/> as UTF-8 JSON into an <see cref="IBufferWriter{T}"/> without a requested data model version:
        /// every property of the <see cref="Thing"/> is written, regardless of the data model version it was introduced in.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <param name="bufferWriter">The <see cref="IBufferWriter{T}"/> that receives the UTF-8 encoded JSON. The written bytes are flushed into it before this method returns.</param>
        /// <param name="options">The <see cref="JsonWriterOptions"/> used to create the <see cref="Utf8JsonWriter"/></param>
        /// <remarks>
        /// A new <see cref="Utf8JsonWriter"/> is created for each call. When many <see cref="Thing"/>s are serialized in a loop,
        /// prefer <see cref="SerializeThing(Thing, Utf8JsonWriter)"/> with a writer that is reused through <see cref="Utf8JsonWriter.Reset(IBufferWriter{byte})"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="thing"/> or <paramref name="bufferWriter"/> is null</exception>
        /// <exception cref="NotSupportedException">Thrown when no serializer is registered for the <see cref="ClassKind"/> of the <paramref name="thing"/></exception>
        public static void SerializeThing(this Thing thing, IBufferWriter<byte> bufferWriter, JsonWriterOptions options = default)
        {
            if (bufferWriter == null)
            {
                throw new ArgumentNullException(nameof(bufferWriter));
            }

            using (var writer = new Utf8JsonWriter(bufferWriter, options))
            {
                thing.SerializeThing(writer);
            }
        }

        /// <summary>
        /// Serialize a <see cref="ClasslessDTO"/> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="classlessDto">The <see cref="ClasslessDTO"/></param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="classlessDto"/>, <paramref name="writer"/> or <paramref name="requestedVersion"/> is null</exception>
        /// <exception cref="NotSupportedException">Thrown when no serializer is registered for the ClassKind of the <paramref name="classlessDto"/></exception>
        public static void SerializeClasslessDto(this ClasslessDTO classlessDto, Utf8JsonWriter writer, Version requestedVersion)
        {
            if (classlessDto == null)
            {
                throw new ArgumentNullException(nameof(classlessDto));
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (requestedVersion == null)
            {
                throw new ArgumentNullException(nameof(requestedVersion));
            }

            var serializer = GetSerializer(classlessDto);

            writer.WriteStartObject();

            foreach (var keyValue in classlessDto)
            {
                var key = Utils.LowercaseFirstLetter(keyValue.Key);
                serializer.SerializeProperty(key, keyValue.Value, writer, requestedVersion);
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a <see cref="ClasslessDTO"/> into an <see cref="Utf8JsonWriter" /> without a requested data model version:
        /// every entry of the <see cref="ClasslessDTO"/> is written, regardless of the data model version its property was introduced in.
        /// </summary>
        /// <param name="classlessDto">The <see cref="ClasslessDTO"/></param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /> to write to. The writer is owned by the caller and is not flushed by this method,
        /// which allows the same writer (and its underlying buffer) to be reused for many <see cref="ClasslessDTO"/>s with <see cref="Utf8JsonWriter.Reset()"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="classlessDto"/> or <paramref name="writer"/> is null</exception>
        /// <exception cref="NotSupportedException">Thrown when no serializer is registered for the ClassKind of the <paramref name="classlessDto"/></exception>
        public static void SerializeClasslessDto(this ClasslessDTO classlessDto, Utf8JsonWriter writer)
        {
            if (classlessDto == null)
            {
                throw new ArgumentNullException(nameof(classlessDto));
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            var serializer = GetSerializer(classlessDto);

            writer.WriteStartObject();

            foreach (var keyValue in classlessDto)
            {
                var key = Utils.LowercaseFirstLetter(keyValue.Key);
                serializer.SerializeProperty(key, keyValue.Value, writer);
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a <see cref="ClasslessDTO"/> as UTF-8 JSON into an <see cref="IBufferWriter{T}"/> without a requested data model version:
        /// every entry of the <see cref="ClasslessDTO"/> is written, regardless of the data model version its property was introduced in.
        /// </summary>
        /// <param name="classlessDto">The <see cref="ClasslessDTO"/></param>
        /// <param name="bufferWriter">The <see cref="IBufferWriter{T}"/> that receives the UTF-8 encoded JSON. The written bytes are flushed into it before this method returns.</param>
        /// <param name="options">The <see cref="JsonWriterOptions"/> used to create the <see cref="Utf8JsonWriter"/></param>
        /// <remarks>
        /// A new <see cref="Utf8JsonWriter"/> is created for each call. When many <see cref="ClasslessDTO"/>s are serialized in a loop,
        /// prefer <see cref="SerializeClasslessDto(ClasslessDTO, Utf8JsonWriter)"/> with a writer that is reused through <see cref="Utf8JsonWriter.Reset(IBufferWriter{byte})"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="classlessDto"/> or <paramref name="bufferWriter"/> is null</exception>
        /// <exception cref="NotSupportedException">Thrown when no serializer is registered for the ClassKind of the <paramref name="classlessDto"/></exception>
        public static void SerializeClasslessDto(this ClasslessDTO classlessDto, IBufferWriter<byte> bufferWriter, JsonWriterOptions options = default)
        {
            if (bufferWriter == null)
            {
                throw new ArgumentNullException(nameof(bufferWriter));
            }

            using (var writer = new Utf8JsonWriter(bufferWriter, options))
            {
                classlessDto.SerializeClasslessDto(writer);
            }
        }

        /// <summary>
        /// Serialize a <see cref="Thing"/> into a JSON <see cref="string"/> without a requested data model version:
        /// every property of the <see cref="Thing"/> is written, regardless of the data model version it was introduced in.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <returns>A json representation of the <see cref="Thing"/></returns>
        /// <remarks>
        /// When the UTF-8 bytes are what is needed, use <see cref="SerializeThing(Thing, Utf8JsonWriter)"/> or
        /// <see cref="SerializeThing(Thing, IBufferWriter{byte}, JsonWriterOptions)"/> instead to avoid the intermediate <see cref="string"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="thing"/> is null</exception>
        /// <exception cref="NotSupportedException">Thrown when no serializer is registered for the <see cref="ClassKind"/> of the <paramref name="thing"/></exception>
        public static string ToJsonString(this Thing thing)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream))
                {
                    thing.SerializeThing(writer);
                }

                return Utf8ToString(stream);
            }
        }

        /// <summary>
        /// Serialize a <see cref="ClasslessDTO"/> into a JSON <see cref="string"/> without a requested data model version:
        /// every entry of the <see cref="ClasslessDTO"/> is written, regardless of the data model version its property was introduced in.
        /// </summary>
        /// <param name="classlessDto">The <see cref="ClasslessDTO"/></param>
        /// <returns>A json representation of the <see cref="ClasslessDTO"/></returns>
        /// <remarks>
        /// When the UTF-8 bytes are what is needed, use <see cref="SerializeClasslessDto(ClasslessDTO, Utf8JsonWriter)"/> or
        /// <see cref="SerializeClasslessDto(ClasslessDTO, IBufferWriter{byte}, JsonWriterOptions)"/> instead to avoid the intermediate <see cref="string"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="classlessDto"/> is null</exception>
        /// <exception cref="NotSupportedException">Thrown when no serializer is registered for the ClassKind of the <paramref name="classlessDto"/></exception>
        public static string ToJsonString(this ClasslessDTO classlessDto)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream))
                {
                    classlessDto.SerializeClasslessDto(writer);
                }

                return Utf8ToString(stream);
            }
        }

        /// <summary>
        /// Gets the <see cref="IThingSerializer"/> that is registered for the provided <see cref="ClassKind"/>
        /// </summary>
        /// <param name="classKind">The <see cref="ClassKind"/> to look up</param>
        /// <returns>The registered <see cref="IThingSerializer"/></returns>
        /// <exception cref="NotSupportedException">Thrown when no <see cref="IThingSerializer"/> is registered for the <paramref name="classKind"/></exception>
        private static IThingSerializer GetSerializer(ClassKind classKind)
        {
            if (!SerializerMap.TryGetValue(classKind.ToString(), out var serializer))
            {
                throw new NotSupportedException($"The {classKind} class is not registered");
            }

            return serializer;
        }

        /// <summary>
        /// Gets the <see cref="IThingSerializer"/> that is registered for the ClassKind entry of the provided <see cref="ClasslessDTO"/>
        /// </summary>
        /// <param name="classlessDto">The <see cref="ClasslessDTO"/> to look up the serializer for</param>
        /// <returns>The registered <see cref="IThingSerializer"/></returns>
        /// <exception cref="NotSupportedException">Thrown when no <see cref="IThingSerializer"/> is registered for the ClassKind of the <paramref name="classlessDto"/></exception>
        private static IThingSerializer GetSerializer(ClasslessDTO classlessDto)
        {
            var classKind = classlessDto["ClassKind"];

            if (!SerializerMap.TryGetValue(classKind.ToString(), out var serializer))
            {
                throw new NotSupportedException($"The {classKind} class is not registered");
            }

            return serializer;
        }

        /// <summary>
        /// Decodes the UTF-8 content of a <see cref="MemoryStream"/> into a <see cref="string"/> without copying the underlying buffer first
        /// </summary>
        /// <param name="stream">The <see cref="MemoryStream"/> that holds the UTF-8 encoded JSON</param>
        /// <returns>The decoded <see cref="string"/></returns>
        private static string Utf8ToString(MemoryStream stream)
        {
            if (stream.TryGetBuffer(out var buffer))
            {
                return Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
