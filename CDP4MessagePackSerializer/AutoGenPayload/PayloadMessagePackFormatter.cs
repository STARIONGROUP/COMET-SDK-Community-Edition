// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayloadMessagePackFormatter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    
    using CDP4Common.DTO;

    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// The purpose of the <see cref="PayloadMessagePackFormatter"/> is to provide
    /// the contract for serialization of the <see cref="Payload"/> type
    /// </summary>
    internal class PayloadMessagePackFormatter : IMessagePackFormatter<Payload>
    {
        /// <summary>
        /// Serializes an <see cref="Payload"/>.
        /// </summary>
        /// <param name="writer">
        /// The writer to use when serializing the <see cref="Payload"/>.
        /// </param>
        /// <param name="payload">
        /// The <see cref="Payload"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Payload payload, MessagePackSerializerOptions options)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload), "The Payload may not be null");
            }

            var formatterResolver = options.Resolver;

            writer.WriteArrayHeader(147);

            writer.Write(payload.Created);

            writer.WriteArrayHeader(payload.ActualFiniteState.Count);
            foreach (var actualFiniteState in payload.ActualFiniteState)
            {
                formatterResolver.GetFormatterWithVerify<ActualFiniteState>().Serialize(ref writer, actualFiniteState, options);
            }

            writer.WriteArrayHeader(payload.ActualFiniteStateList.Count);
            foreach (var actualFiniteStateList in payload.ActualFiniteStateList)
            {
                formatterResolver.GetFormatterWithVerify<ActualFiniteStateList>().Serialize(ref writer, actualFiniteStateList, options);
            }

            writer.WriteArrayHeader(payload.Alias.Count);
            foreach (var alias in payload.Alias)
            {
                formatterResolver.GetFormatterWithVerify<Alias>().Serialize(ref writer, alias, options);
            }

            writer.WriteArrayHeader(payload.AndExpression.Count);
            foreach (var andExpression in payload.AndExpression)
            {
                formatterResolver.GetFormatterWithVerify<AndExpression>().Serialize(ref writer, andExpression, options);
            }

            writer.WriteArrayHeader(payload.ArrayParameterType.Count);
            foreach (var arrayParameterType in payload.ArrayParameterType)
            {
                formatterResolver.GetFormatterWithVerify<ArrayParameterType>().Serialize(ref writer, arrayParameterType, options);
            }

            writer.WriteArrayHeader(payload.BinaryRelationship.Count);
            foreach (var binaryRelationship in payload.BinaryRelationship)
            {
                formatterResolver.GetFormatterWithVerify<BinaryRelationship>().Serialize(ref writer, binaryRelationship, options);
            }

            writer.WriteArrayHeader(payload.BinaryRelationshipRule.Count);
            foreach (var binaryRelationshipRule in payload.BinaryRelationshipRule)
            {
                formatterResolver.GetFormatterWithVerify<BinaryRelationshipRule>().Serialize(ref writer, binaryRelationshipRule, options);
            }

            writer.WriteArrayHeader(payload.BooleanParameterType.Count);
            foreach (var booleanParameterType in payload.BooleanParameterType)
            {
                formatterResolver.GetFormatterWithVerify<BooleanParameterType>().Serialize(ref writer, booleanParameterType, options);
            }

            writer.WriteArrayHeader(payload.BuiltInRuleVerification.Count);
            foreach (var builtInRuleVerification in payload.BuiltInRuleVerification)
            {
                formatterResolver.GetFormatterWithVerify<BuiltInRuleVerification>().Serialize(ref writer, builtInRuleVerification, options);
            }

            writer.WriteArrayHeader(payload.Category.Count);
            foreach (var category in payload.Category)
            {
                formatterResolver.GetFormatterWithVerify<Category>().Serialize(ref writer, category, options);
            }

            writer.WriteArrayHeader(payload.Citation.Count);
            foreach (var citation in payload.Citation)
            {
                formatterResolver.GetFormatterWithVerify<Citation>().Serialize(ref writer, citation, options);
            }

            writer.WriteArrayHeader(payload.Color.Count);
            foreach (var color in payload.Color)
            {
                formatterResolver.GetFormatterWithVerify<Color>().Serialize(ref writer, color, options);
            }

            writer.WriteArrayHeader(payload.CommonFileStore.Count);
            foreach (var commonFileStore in payload.CommonFileStore)
            {
                formatterResolver.GetFormatterWithVerify<CommonFileStore>().Serialize(ref writer, commonFileStore, options);
            }

            writer.WriteArrayHeader(payload.CompoundParameterType.Count);
            foreach (var compoundParameterType in payload.CompoundParameterType)
            {
                formatterResolver.GetFormatterWithVerify<CompoundParameterType>().Serialize(ref writer, compoundParameterType, options);
            }

            writer.WriteArrayHeader(payload.Constant.Count);
            foreach (var constant in payload.Constant)
            {
                formatterResolver.GetFormatterWithVerify<Constant>().Serialize(ref writer, constant, options);
            }

            writer.WriteArrayHeader(payload.CyclicRatioScale.Count);
            foreach (var cyclicRatioScale in payload.CyclicRatioScale)
            {
                formatterResolver.GetFormatterWithVerify<CyclicRatioScale>().Serialize(ref writer, cyclicRatioScale, options);
            }

            writer.WriteArrayHeader(payload.DateParameterType.Count);
            foreach (var dateParameterType in payload.DateParameterType)
            {
                formatterResolver.GetFormatterWithVerify<DateParameterType>().Serialize(ref writer, dateParameterType, options);
            }

            writer.WriteArrayHeader(payload.DateTimeParameterType.Count);
            foreach (var dateTimeParameterType in payload.DateTimeParameterType)
            {
                formatterResolver.GetFormatterWithVerify<DateTimeParameterType>().Serialize(ref writer, dateTimeParameterType, options);
            }

            writer.WriteArrayHeader(payload.DecompositionRule.Count);
            foreach (var decompositionRule in payload.DecompositionRule)
            {
                formatterResolver.GetFormatterWithVerify<DecompositionRule>().Serialize(ref writer, decompositionRule, options);
            }

            writer.WriteArrayHeader(payload.Definition.Count);
            foreach (var definition in payload.Definition)
            {
                formatterResolver.GetFormatterWithVerify<Definition>().Serialize(ref writer, definition, options);
            }

            writer.WriteArrayHeader(payload.DerivedQuantityKind.Count);
            foreach (var derivedQuantityKind in payload.DerivedQuantityKind)
            {
                formatterResolver.GetFormatterWithVerify<DerivedQuantityKind>().Serialize(ref writer, derivedQuantityKind, options);
            }

            writer.WriteArrayHeader(payload.DerivedUnit.Count);
            foreach (var derivedUnit in payload.DerivedUnit)
            {
                formatterResolver.GetFormatterWithVerify<DerivedUnit>().Serialize(ref writer, derivedUnit, options);
            }

            writer.WriteArrayHeader(payload.DomainFileStore.Count);
            foreach (var domainFileStore in payload.DomainFileStore)
            {
                formatterResolver.GetFormatterWithVerify<DomainFileStore>().Serialize(ref writer, domainFileStore, options);
            }

            writer.WriteArrayHeader(payload.DomainOfExpertise.Count);
            foreach (var domainOfExpertise in payload.DomainOfExpertise)
            {
                formatterResolver.GetFormatterWithVerify<DomainOfExpertise>().Serialize(ref writer, domainOfExpertise, options);
            }

            writer.WriteArrayHeader(payload.DomainOfExpertiseGroup.Count);
            foreach (var domainOfExpertiseGroup in payload.DomainOfExpertiseGroup)
            {
                formatterResolver.GetFormatterWithVerify<DomainOfExpertiseGroup>().Serialize(ref writer, domainOfExpertiseGroup, options);
            }

            writer.WriteArrayHeader(payload.ElementDefinition.Count);
            foreach (var elementDefinition in payload.ElementDefinition)
            {
                formatterResolver.GetFormatterWithVerify<ElementDefinition>().Serialize(ref writer, elementDefinition, options);
            }

            writer.WriteArrayHeader(payload.ElementUsage.Count);
            foreach (var elementUsage in payload.ElementUsage)
            {
                formatterResolver.GetFormatterWithVerify<ElementUsage>().Serialize(ref writer, elementUsage, options);
            }

            writer.WriteArrayHeader(payload.EmailAddress.Count);
            foreach (var emailAddress in payload.EmailAddress)
            {
                formatterResolver.GetFormatterWithVerify<EmailAddress>().Serialize(ref writer, emailAddress, options);
            }

            writer.WriteArrayHeader(payload.EngineeringModel.Count);
            foreach (var engineeringModel in payload.EngineeringModel)
            {
                formatterResolver.GetFormatterWithVerify<EngineeringModel>().Serialize(ref writer, engineeringModel, options);
            }

            writer.WriteArrayHeader(payload.EngineeringModelSetup.Count);
            foreach (var engineeringModelSetup in payload.EngineeringModelSetup)
            {
                formatterResolver.GetFormatterWithVerify<EngineeringModelSetup>().Serialize(ref writer, engineeringModelSetup, options);
            }

            writer.WriteArrayHeader(payload.EnumerationParameterType.Count);
            foreach (var enumerationParameterType in payload.EnumerationParameterType)
            {
                formatterResolver.GetFormatterWithVerify<EnumerationParameterType>().Serialize(ref writer, enumerationParameterType, options);
            }

            writer.WriteArrayHeader(payload.EnumerationValueDefinition.Count);
            foreach (var enumerationValueDefinition in payload.EnumerationValueDefinition)
            {
                formatterResolver.GetFormatterWithVerify<EnumerationValueDefinition>().Serialize(ref writer, enumerationValueDefinition, options);
            }

            writer.WriteArrayHeader(payload.ExclusiveOrExpression.Count);
            foreach (var exclusiveOrExpression in payload.ExclusiveOrExpression)
            {
                formatterResolver.GetFormatterWithVerify<ExclusiveOrExpression>().Serialize(ref writer, exclusiveOrExpression, options);
            }

            writer.WriteArrayHeader(payload.ExternalIdentifierMap.Count);
            foreach (var externalIdentifierMap in payload.ExternalIdentifierMap)
            {
                formatterResolver.GetFormatterWithVerify<ExternalIdentifierMap>().Serialize(ref writer, externalIdentifierMap, options);
            }

            writer.WriteArrayHeader(payload.File.Count);
            foreach (var file in payload.File)
            {
                formatterResolver.GetFormatterWithVerify<File>().Serialize(ref writer, file, options);
            }

            writer.WriteArrayHeader(payload.FileRevision.Count);
            foreach (var fileRevision in payload.FileRevision)
            {
                formatterResolver.GetFormatterWithVerify<FileRevision>().Serialize(ref writer, fileRevision, options);
            }

            writer.WriteArrayHeader(payload.FileType.Count);
            foreach (var fileType in payload.FileType)
            {
                formatterResolver.GetFormatterWithVerify<FileType>().Serialize(ref writer, fileType, options);
            }

            writer.WriteArrayHeader(payload.Folder.Count);
            foreach (var folder in payload.Folder)
            {
                formatterResolver.GetFormatterWithVerify<Folder>().Serialize(ref writer, folder, options);
            }

            writer.WriteArrayHeader(payload.Glossary.Count);
            foreach (var glossary in payload.Glossary)
            {
                formatterResolver.GetFormatterWithVerify<Glossary>().Serialize(ref writer, glossary, options);
            }

            writer.WriteArrayHeader(payload.HyperLink.Count);
            foreach (var hyperLink in payload.HyperLink)
            {
                formatterResolver.GetFormatterWithVerify<HyperLink>().Serialize(ref writer, hyperLink, options);
            }

            writer.WriteArrayHeader(payload.IdCorrespondence.Count);
            foreach (var idCorrespondence in payload.IdCorrespondence)
            {
                formatterResolver.GetFormatterWithVerify<IdCorrespondence>().Serialize(ref writer, idCorrespondence, options);
            }

            writer.WriteArrayHeader(payload.IntervalScale.Count);
            foreach (var intervalScale in payload.IntervalScale)
            {
                formatterResolver.GetFormatterWithVerify<IntervalScale>().Serialize(ref writer, intervalScale, options);
            }

            writer.WriteArrayHeader(payload.Iteration.Count);
            foreach (var iteration in payload.Iteration)
            {
                formatterResolver.GetFormatterWithVerify<Iteration>().Serialize(ref writer, iteration, options);
            }

            writer.WriteArrayHeader(payload.IterationSetup.Count);
            foreach (var iterationSetup in payload.IterationSetup)
            {
                formatterResolver.GetFormatterWithVerify<IterationSetup>().Serialize(ref writer, iterationSetup, options);
            }

            writer.WriteArrayHeader(payload.LinearConversionUnit.Count);
            foreach (var linearConversionUnit in payload.LinearConversionUnit)
            {
                formatterResolver.GetFormatterWithVerify<LinearConversionUnit>().Serialize(ref writer, linearConversionUnit, options);
            }

            writer.WriteArrayHeader(payload.LogarithmicScale.Count);
            foreach (var logarithmicScale in payload.LogarithmicScale)
            {
                formatterResolver.GetFormatterWithVerify<LogarithmicScale>().Serialize(ref writer, logarithmicScale, options);
            }

            writer.WriteArrayHeader(payload.MappingToReferenceScale.Count);
            foreach (var mappingToReferenceScale in payload.MappingToReferenceScale)
            {
                formatterResolver.GetFormatterWithVerify<MappingToReferenceScale>().Serialize(ref writer, mappingToReferenceScale, options);
            }

            writer.WriteArrayHeader(payload.ModelLogEntry.Count);
            foreach (var modelLogEntry in payload.ModelLogEntry)
            {
                formatterResolver.GetFormatterWithVerify<ModelLogEntry>().Serialize(ref writer, modelLogEntry, options);
            }

            writer.WriteArrayHeader(payload.ModelReferenceDataLibrary.Count);
            foreach (var modelReferenceDataLibrary in payload.ModelReferenceDataLibrary)
            {
                formatterResolver.GetFormatterWithVerify<ModelReferenceDataLibrary>().Serialize(ref writer, modelReferenceDataLibrary, options);
            }

            writer.WriteArrayHeader(payload.MultiRelationship.Count);
            foreach (var multiRelationship in payload.MultiRelationship)
            {
                formatterResolver.GetFormatterWithVerify<MultiRelationship>().Serialize(ref writer, multiRelationship, options);
            }

            writer.WriteArrayHeader(payload.MultiRelationshipRule.Count);
            foreach (var multiRelationshipRule in payload.MultiRelationshipRule)
            {
                formatterResolver.GetFormatterWithVerify<MultiRelationshipRule>().Serialize(ref writer, multiRelationshipRule, options);
            }

            writer.WriteArrayHeader(payload.NaturalLanguage.Count);
            foreach (var naturalLanguage in payload.NaturalLanguage)
            {
                formatterResolver.GetFormatterWithVerify<NaturalLanguage>().Serialize(ref writer, naturalLanguage, options);
            }

            writer.WriteArrayHeader(payload.NestedElement.Count);
            foreach (var nestedElement in payload.NestedElement)
            {
                formatterResolver.GetFormatterWithVerify<NestedElement>().Serialize(ref writer, nestedElement, options);
            }

            writer.WriteArrayHeader(payload.NestedParameter.Count);
            foreach (var nestedParameter in payload.NestedParameter)
            {
                formatterResolver.GetFormatterWithVerify<NestedParameter>().Serialize(ref writer, nestedParameter, options);
            }

            writer.WriteArrayHeader(payload.NotExpression.Count);
            foreach (var notExpression in payload.NotExpression)
            {
                formatterResolver.GetFormatterWithVerify<NotExpression>().Serialize(ref writer, notExpression, options);
            }

            writer.WriteArrayHeader(payload.Option.Count);
            foreach (var option in payload.Option)
            {
                formatterResolver.GetFormatterWithVerify<Option>().Serialize(ref writer, option, options);
            }

            writer.WriteArrayHeader(payload.OrdinalScale.Count);
            foreach (var ordinalScale in payload.OrdinalScale)
            {
                formatterResolver.GetFormatterWithVerify<OrdinalScale>().Serialize(ref writer, ordinalScale, options);
            }

            writer.WriteArrayHeader(payload.OrExpression.Count);
            foreach (var orExpression in payload.OrExpression)
            {
                formatterResolver.GetFormatterWithVerify<OrExpression>().Serialize(ref writer, orExpression, options);
            }

            writer.WriteArrayHeader(payload.Organization.Count);
            foreach (var organization in payload.Organization)
            {
                formatterResolver.GetFormatterWithVerify<Organization>().Serialize(ref writer, organization, options);
            }

            writer.WriteArrayHeader(payload.Parameter.Count);
            foreach (var parameter in payload.Parameter)
            {
                formatterResolver.GetFormatterWithVerify<Parameter>().Serialize(ref writer, parameter, options);
            }

            writer.WriteArrayHeader(payload.ParameterGroup.Count);
            foreach (var parameterGroup in payload.ParameterGroup)
            {
                formatterResolver.GetFormatterWithVerify<ParameterGroup>().Serialize(ref writer, parameterGroup, options);
            }

            writer.WriteArrayHeader(payload.ParameterizedCategoryRule.Count);
            foreach (var parameterizedCategoryRule in payload.ParameterizedCategoryRule)
            {
                formatterResolver.GetFormatterWithVerify<ParameterizedCategoryRule>().Serialize(ref writer, parameterizedCategoryRule, options);
            }

            writer.WriteArrayHeader(payload.ParameterOverride.Count);
            foreach (var parameterOverride in payload.ParameterOverride)
            {
                formatterResolver.GetFormatterWithVerify<ParameterOverride>().Serialize(ref writer, parameterOverride, options);
            }

            writer.WriteArrayHeader(payload.ParameterOverrideValueSet.Count);
            foreach (var parameterOverrideValueSet in payload.ParameterOverrideValueSet)
            {
                formatterResolver.GetFormatterWithVerify<ParameterOverrideValueSet>().Serialize(ref writer, parameterOverrideValueSet, options);
            }

            writer.WriteArrayHeader(payload.ParameterSubscription.Count);
            foreach (var parameterSubscription in payload.ParameterSubscription)
            {
                formatterResolver.GetFormatterWithVerify<ParameterSubscription>().Serialize(ref writer, parameterSubscription, options);
            }

            writer.WriteArrayHeader(payload.ParameterSubscriptionValueSet.Count);
            foreach (var parameterSubscriptionValueSet in payload.ParameterSubscriptionValueSet)
            {
                formatterResolver.GetFormatterWithVerify<ParameterSubscriptionValueSet>().Serialize(ref writer, parameterSubscriptionValueSet, options);
            }

            writer.WriteArrayHeader(payload.ParameterTypeComponent.Count);
            foreach (var parameterTypeComponent in payload.ParameterTypeComponent)
            {
                formatterResolver.GetFormatterWithVerify<ParameterTypeComponent>().Serialize(ref writer, parameterTypeComponent, options);
            }

            writer.WriteArrayHeader(payload.ParameterValueSet.Count);
            foreach (var parameterValueSet in payload.ParameterValueSet)
            {
                formatterResolver.GetFormatterWithVerify<ParameterValueSet>().Serialize(ref writer, parameterValueSet, options);
            }

            writer.WriteArrayHeader(payload.ParametricConstraint.Count);
            foreach (var parametricConstraint in payload.ParametricConstraint)
            {
                formatterResolver.GetFormatterWithVerify<ParametricConstraint>().Serialize(ref writer, parametricConstraint, options);
            }

            writer.WriteArrayHeader(payload.Participant.Count);
            foreach (var participant in payload.Participant)
            {
                formatterResolver.GetFormatterWithVerify<Participant>().Serialize(ref writer, participant, options);
            }

            writer.WriteArrayHeader(payload.ParticipantPermission.Count);
            foreach (var participantPermission in payload.ParticipantPermission)
            {
                formatterResolver.GetFormatterWithVerify<ParticipantPermission>().Serialize(ref writer, participantPermission, options);
            }

            writer.WriteArrayHeader(payload.ParticipantRole.Count);
            foreach (var participantRole in payload.ParticipantRole)
            {
                formatterResolver.GetFormatterWithVerify<ParticipantRole>().Serialize(ref writer, participantRole, options);
            }

            writer.WriteArrayHeader(payload.Person.Count);
            foreach (var person in payload.Person)
            {
                formatterResolver.GetFormatterWithVerify<Person>().Serialize(ref writer, person, options);
            }

            writer.WriteArrayHeader(payload.PersonPermission.Count);
            foreach (var personPermission in payload.PersonPermission)
            {
                formatterResolver.GetFormatterWithVerify<PersonPermission>().Serialize(ref writer, personPermission, options);
            }

            writer.WriteArrayHeader(payload.PersonRole.Count);
            foreach (var personRole in payload.PersonRole)
            {
                formatterResolver.GetFormatterWithVerify<PersonRole>().Serialize(ref writer, personRole, options);
            }

            writer.WriteArrayHeader(payload.PossibleFiniteState.Count);
            foreach (var possibleFiniteState in payload.PossibleFiniteState)
            {
                formatterResolver.GetFormatterWithVerify<PossibleFiniteState>().Serialize(ref writer, possibleFiniteState, options);
            }

            writer.WriteArrayHeader(payload.PossibleFiniteStateList.Count);
            foreach (var possibleFiniteStateList in payload.PossibleFiniteStateList)
            {
                formatterResolver.GetFormatterWithVerify<PossibleFiniteStateList>().Serialize(ref writer, possibleFiniteStateList, options);
            }

            writer.WriteArrayHeader(payload.PrefixedUnit.Count);
            foreach (var prefixedUnit in payload.PrefixedUnit)
            {
                formatterResolver.GetFormatterWithVerify<PrefixedUnit>().Serialize(ref writer, prefixedUnit, options);
            }

            writer.WriteArrayHeader(payload.Publication.Count);
            foreach (var publication in payload.Publication)
            {
                formatterResolver.GetFormatterWithVerify<Publication>().Serialize(ref writer, publication, options);
            }

            writer.WriteArrayHeader(payload.QuantityKindFactor.Count);
            foreach (var quantityKindFactor in payload.QuantityKindFactor)
            {
                formatterResolver.GetFormatterWithVerify<QuantityKindFactor>().Serialize(ref writer, quantityKindFactor, options);
            }

            writer.WriteArrayHeader(payload.RatioScale.Count);
            foreach (var ratioScale in payload.RatioScale)
            {
                formatterResolver.GetFormatterWithVerify<RatioScale>().Serialize(ref writer, ratioScale, options);
            }

            writer.WriteArrayHeader(payload.ReferencerRule.Count);
            foreach (var referencerRule in payload.ReferencerRule)
            {
                formatterResolver.GetFormatterWithVerify<ReferencerRule>().Serialize(ref writer, referencerRule, options);
            }

            writer.WriteArrayHeader(payload.ReferenceSource.Count);
            foreach (var referenceSource in payload.ReferenceSource)
            {
                formatterResolver.GetFormatterWithVerify<ReferenceSource>().Serialize(ref writer, referenceSource, options);
            }

            writer.WriteArrayHeader(payload.RelationalExpression.Count);
            foreach (var relationalExpression in payload.RelationalExpression)
            {
                formatterResolver.GetFormatterWithVerify<RelationalExpression>().Serialize(ref writer, relationalExpression, options);
            }

            writer.WriteArrayHeader(payload.Requirement.Count);
            foreach (var requirement in payload.Requirement)
            {
                formatterResolver.GetFormatterWithVerify<Requirement>().Serialize(ref writer, requirement, options);
            }

            writer.WriteArrayHeader(payload.RequirementsGroup.Count);
            foreach (var requirementsGroup in payload.RequirementsGroup)
            {
                formatterResolver.GetFormatterWithVerify<RequirementsGroup>().Serialize(ref writer, requirementsGroup, options);
            }

            writer.WriteArrayHeader(payload.RequirementsSpecification.Count);
            foreach (var requirementsSpecification in payload.RequirementsSpecification)
            {
                formatterResolver.GetFormatterWithVerify<RequirementsSpecification>().Serialize(ref writer, requirementsSpecification, options);
            }

            writer.WriteArrayHeader(payload.RuleVerificationList.Count);
            foreach (var ruleVerificationList in payload.RuleVerificationList)
            {
                formatterResolver.GetFormatterWithVerify<RuleVerificationList>().Serialize(ref writer, ruleVerificationList, options);
            }

            writer.WriteArrayHeader(payload.RuleViolation.Count);
            foreach (var ruleViolation in payload.RuleViolation)
            {
                formatterResolver.GetFormatterWithVerify<RuleViolation>().Serialize(ref writer, ruleViolation, options);
            }

            writer.WriteArrayHeader(payload.ScaleReferenceQuantityValue.Count);
            foreach (var scaleReferenceQuantityValue in payload.ScaleReferenceQuantityValue)
            {
                formatterResolver.GetFormatterWithVerify<ScaleReferenceQuantityValue>().Serialize(ref writer, scaleReferenceQuantityValue, options);
            }

            writer.WriteArrayHeader(payload.ScaleValueDefinition.Count);
            foreach (var scaleValueDefinition in payload.ScaleValueDefinition)
            {
                formatterResolver.GetFormatterWithVerify<ScaleValueDefinition>().Serialize(ref writer, scaleValueDefinition, options);
            }

            writer.WriteArrayHeader(payload.SimpleParameterValue.Count);
            foreach (var simpleParameterValue in payload.SimpleParameterValue)
            {
                formatterResolver.GetFormatterWithVerify<SimpleParameterValue>().Serialize(ref writer, simpleParameterValue, options);
            }

            writer.WriteArrayHeader(payload.SimpleQuantityKind.Count);
            foreach (var simpleQuantityKind in payload.SimpleQuantityKind)
            {
                formatterResolver.GetFormatterWithVerify<SimpleQuantityKind>().Serialize(ref writer, simpleQuantityKind, options);
            }

            writer.WriteArrayHeader(payload.SimpleUnit.Count);
            foreach (var simpleUnit in payload.SimpleUnit)
            {
                formatterResolver.GetFormatterWithVerify<SimpleUnit>().Serialize(ref writer, simpleUnit, options);
            }

            writer.WriteArrayHeader(payload.SiteDirectory.Count);
            foreach (var siteDirectory in payload.SiteDirectory)
            {
                formatterResolver.GetFormatterWithVerify<SiteDirectory>().Serialize(ref writer, siteDirectory, options);
            }

            writer.WriteArrayHeader(payload.SiteLogEntry.Count);
            foreach (var siteLogEntry in payload.SiteLogEntry)
            {
                formatterResolver.GetFormatterWithVerify<SiteLogEntry>().Serialize(ref writer, siteLogEntry, options);
            }

            writer.WriteArrayHeader(payload.SiteReferenceDataLibrary.Count);
            foreach (var siteReferenceDataLibrary in payload.SiteReferenceDataLibrary)
            {
                formatterResolver.GetFormatterWithVerify<SiteReferenceDataLibrary>().Serialize(ref writer, siteReferenceDataLibrary, options);
            }

            writer.WriteArrayHeader(payload.SpecializedQuantityKind.Count);
            foreach (var specializedQuantityKind in payload.SpecializedQuantityKind)
            {
                formatterResolver.GetFormatterWithVerify<SpecializedQuantityKind>().Serialize(ref writer, specializedQuantityKind, options);
            }

            writer.WriteArrayHeader(payload.TelephoneNumber.Count);
            foreach (var telephoneNumber in payload.TelephoneNumber)
            {
                formatterResolver.GetFormatterWithVerify<TelephoneNumber>().Serialize(ref writer, telephoneNumber, options);
            }

            writer.WriteArrayHeader(payload.Term.Count);
            foreach (var term in payload.Term)
            {
                formatterResolver.GetFormatterWithVerify<Term>().Serialize(ref writer, term, options);
            }

            writer.WriteArrayHeader(payload.TextParameterType.Count);
            foreach (var textParameterType in payload.TextParameterType)
            {
                formatterResolver.GetFormatterWithVerify<TextParameterType>().Serialize(ref writer, textParameterType, options);
            }

            writer.WriteArrayHeader(payload.TimeOfDayParameterType.Count);
            foreach (var timeOfDayParameterType in payload.TimeOfDayParameterType)
            {
                formatterResolver.GetFormatterWithVerify<TimeOfDayParameterType>().Serialize(ref writer, timeOfDayParameterType, options);
            }

            writer.WriteArrayHeader(payload.UnitFactor.Count);
            foreach (var unitFactor in payload.UnitFactor)
            {
                formatterResolver.GetFormatterWithVerify<UnitFactor>().Serialize(ref writer, unitFactor, options);
            }

            writer.WriteArrayHeader(payload.UnitPrefix.Count);
            foreach (var unitPrefix in payload.UnitPrefix)
            {
                formatterResolver.GetFormatterWithVerify<UnitPrefix>().Serialize(ref writer, unitPrefix, options);
            }

            writer.WriteArrayHeader(payload.UserPreference.Count);
            foreach (var userPreference in payload.UserPreference)
            {
                formatterResolver.GetFormatterWithVerify<UserPreference>().Serialize(ref writer, userPreference, options);
            }

            writer.WriteArrayHeader(payload.UserRuleVerification.Count);
            foreach (var userRuleVerification in payload.UserRuleVerification)
            {
                formatterResolver.GetFormatterWithVerify<UserRuleVerification>().Serialize(ref writer, userRuleVerification, options);
            }

            writer.WriteArrayHeader(payload.ActionItem.Count);
            foreach (var actionItem in payload.ActionItem)
            {
                formatterResolver.GetFormatterWithVerify<ActionItem>().Serialize(ref writer, actionItem, options);
            }

            writer.WriteArrayHeader(payload.Approval.Count);
            foreach (var approval in payload.Approval)
            {
                formatterResolver.GetFormatterWithVerify<Approval>().Serialize(ref writer, approval, options);
            }

            writer.WriteArrayHeader(payload.BinaryNote.Count);
            foreach (var binaryNote in payload.BinaryNote)
            {
                formatterResolver.GetFormatterWithVerify<BinaryNote>().Serialize(ref writer, binaryNote, options);
            }

            writer.WriteArrayHeader(payload.Book.Count);
            foreach (var book in payload.Book)
            {
                formatterResolver.GetFormatterWithVerify<Book>().Serialize(ref writer, book, options);
            }

            writer.WriteArrayHeader(payload.Bounds.Count);
            foreach (var bounds in payload.Bounds)
            {
                formatterResolver.GetFormatterWithVerify<Bounds>().Serialize(ref writer, bounds, options);
            }

            writer.WriteArrayHeader(payload.ChangeProposal.Count);
            foreach (var changeProposal in payload.ChangeProposal)
            {
                formatterResolver.GetFormatterWithVerify<ChangeProposal>().Serialize(ref writer, changeProposal, options);
            }

            writer.WriteArrayHeader(payload.ChangeRequest.Count);
            foreach (var changeRequest in payload.ChangeRequest)
            {
                formatterResolver.GetFormatterWithVerify<ChangeRequest>().Serialize(ref writer, changeRequest, options);
            }

            writer.WriteArrayHeader(payload.ContractChangeNotice.Count);
            foreach (var contractChangeNotice in payload.ContractChangeNotice)
            {
                formatterResolver.GetFormatterWithVerify<ContractChangeNotice>().Serialize(ref writer, contractChangeNotice, options);
            }

            writer.WriteArrayHeader(payload.DiagramCanvas.Count);
            foreach (var diagramCanvas in payload.DiagramCanvas)
            {
                formatterResolver.GetFormatterWithVerify<DiagramCanvas>().Serialize(ref writer, diagramCanvas, options);
            }

            writer.WriteArrayHeader(payload.DiagramEdge.Count);
            foreach (var diagramEdge in payload.DiagramEdge)
            {
                formatterResolver.GetFormatterWithVerify<DiagramEdge>().Serialize(ref writer, diagramEdge, options);
            }

            writer.WriteArrayHeader(payload.DiagramObject.Count);
            foreach (var diagramObject in payload.DiagramObject)
            {
                formatterResolver.GetFormatterWithVerify<DiagramObject>().Serialize(ref writer, diagramObject, options);
            }

            writer.WriteArrayHeader(payload.EngineeringModelDataDiscussionItem.Count);
            foreach (var engineeringModelDataDiscussionItem in payload.EngineeringModelDataDiscussionItem)
            {
                formatterResolver.GetFormatterWithVerify<EngineeringModelDataDiscussionItem>().Serialize(ref writer, engineeringModelDataDiscussionItem, options);
            }

            writer.WriteArrayHeader(payload.EngineeringModelDataNote.Count);
            foreach (var engineeringModelDataNote in payload.EngineeringModelDataNote)
            {
                formatterResolver.GetFormatterWithVerify<EngineeringModelDataNote>().Serialize(ref writer, engineeringModelDataNote, options);
            }

            writer.WriteArrayHeader(payload.Goal.Count);
            foreach (var goal in payload.Goal)
            {
                formatterResolver.GetFormatterWithVerify<Goal>().Serialize(ref writer, goal, options);
            }

            writer.WriteArrayHeader(payload.ModellingThingReference.Count);
            foreach (var modellingThingReference in payload.ModellingThingReference)
            {
                formatterResolver.GetFormatterWithVerify<ModellingThingReference>().Serialize(ref writer, modellingThingReference, options);
            }

            writer.WriteArrayHeader(payload.OwnedStyle.Count);
            foreach (var ownedStyle in payload.OwnedStyle)
            {
                formatterResolver.GetFormatterWithVerify<OwnedStyle>().Serialize(ref writer, ownedStyle, options);
            }

            writer.WriteArrayHeader(payload.Page.Count);
            foreach (var page in payload.Page)
            {
                formatterResolver.GetFormatterWithVerify<Page>().Serialize(ref writer, page, options);
            }

            writer.WriteArrayHeader(payload.Point.Count);
            foreach (var point in payload.Point)
            {
                formatterResolver.GetFormatterWithVerify<Point>().Serialize(ref writer, point, options);
            }

            writer.WriteArrayHeader(payload.RelationshipParameterValue.Count);
            foreach (var relationshipParameterValue in payload.RelationshipParameterValue)
            {
                formatterResolver.GetFormatterWithVerify<RelationshipParameterValue>().Serialize(ref writer, relationshipParameterValue, options);
            }

            writer.WriteArrayHeader(payload.RequestForDeviation.Count);
            foreach (var requestForDeviation in payload.RequestForDeviation)
            {
                formatterResolver.GetFormatterWithVerify<RequestForDeviation>().Serialize(ref writer, requestForDeviation, options);
            }

            writer.WriteArrayHeader(payload.RequestForWaiver.Count);
            foreach (var requestForWaiver in payload.RequestForWaiver)
            {
                formatterResolver.GetFormatterWithVerify<RequestForWaiver>().Serialize(ref writer, requestForWaiver, options);
            }

            writer.WriteArrayHeader(payload.RequirementsContainerParameterValue.Count);
            foreach (var requirementsContainerParameterValue in payload.RequirementsContainerParameterValue)
            {
                formatterResolver.GetFormatterWithVerify<RequirementsContainerParameterValue>().Serialize(ref writer, requirementsContainerParameterValue, options);
            }

            writer.WriteArrayHeader(payload.ReviewItemDiscrepancy.Count);
            foreach (var reviewItemDiscrepancy in payload.ReviewItemDiscrepancy)
            {
                formatterResolver.GetFormatterWithVerify<ReviewItemDiscrepancy>().Serialize(ref writer, reviewItemDiscrepancy, options);
            }

            writer.WriteArrayHeader(payload.Section.Count);
            foreach (var section in payload.Section)
            {
                formatterResolver.GetFormatterWithVerify<Section>().Serialize(ref writer, section, options);
            }

            writer.WriteArrayHeader(payload.SharedStyle.Count);
            foreach (var sharedStyle in payload.SharedStyle)
            {
                formatterResolver.GetFormatterWithVerify<SharedStyle>().Serialize(ref writer, sharedStyle, options);
            }

            writer.WriteArrayHeader(payload.SiteDirectoryDataAnnotation.Count);
            foreach (var siteDirectoryDataAnnotation in payload.SiteDirectoryDataAnnotation)
            {
                formatterResolver.GetFormatterWithVerify<SiteDirectoryDataAnnotation>().Serialize(ref writer, siteDirectoryDataAnnotation, options);
            }

            writer.WriteArrayHeader(payload.SiteDirectoryDataDiscussionItem.Count);
            foreach (var siteDirectoryDataDiscussionItem in payload.SiteDirectoryDataDiscussionItem)
            {
                formatterResolver.GetFormatterWithVerify<SiteDirectoryDataDiscussionItem>().Serialize(ref writer, siteDirectoryDataDiscussionItem, options);
            }

            writer.WriteArrayHeader(payload.SiteDirectoryThingReference.Count);
            foreach (var siteDirectoryThingReference in payload.SiteDirectoryThingReference)
            {
                formatterResolver.GetFormatterWithVerify<SiteDirectoryThingReference>().Serialize(ref writer, siteDirectoryThingReference, options);
            }

            writer.WriteArrayHeader(payload.Solution.Count);
            foreach (var solution in payload.Solution)
            {
                formatterResolver.GetFormatterWithVerify<Solution>().Serialize(ref writer, solution, options);
            }

            writer.WriteArrayHeader(payload.Stakeholder.Count);
            foreach (var stakeholder in payload.Stakeholder)
            {
                formatterResolver.GetFormatterWithVerify<Stakeholder>().Serialize(ref writer, stakeholder, options);
            }

            writer.WriteArrayHeader(payload.StakeholderValue.Count);
            foreach (var stakeholderValue in payload.StakeholderValue)
            {
                formatterResolver.GetFormatterWithVerify<StakeholderValue>().Serialize(ref writer, stakeholderValue, options);
            }

            writer.WriteArrayHeader(payload.StakeHolderValueMap.Count);
            foreach (var stakeHolderValueMap in payload.StakeHolderValueMap)
            {
                formatterResolver.GetFormatterWithVerify<StakeHolderValueMap>().Serialize(ref writer, stakeHolderValueMap, options);
            }

            writer.WriteArrayHeader(payload.StakeHolderValueMapSettings.Count);
            foreach (var stakeHolderValueMapSettings in payload.StakeHolderValueMapSettings)
            {
                formatterResolver.GetFormatterWithVerify<StakeHolderValueMapSettings>().Serialize(ref writer, stakeHolderValueMapSettings, options);
            }

            writer.WriteArrayHeader(payload.TextualNote.Count);
            foreach (var textualNote in payload.TextualNote)
            {
                formatterResolver.GetFormatterWithVerify<TextualNote>().Serialize(ref writer, textualNote, options);
            }

            writer.WriteArrayHeader(payload.ValueGroup.Count);
            foreach (var valueGroup in payload.ValueGroup)
            {
                formatterResolver.GetFormatterWithVerify<ValueGroup>().Serialize(ref writer, valueGroup, options);
            }

            writer.WriteArrayHeader(payload.DependentParameterTypeAssignment.Count);
            foreach (var dependentParameterTypeAssignment in payload.DependentParameterTypeAssignment)
            {
                formatterResolver.GetFormatterWithVerify<DependentParameterTypeAssignment>().Serialize(ref writer, dependentParameterTypeAssignment, options);
            }

            writer.WriteArrayHeader(payload.IndependentParameterTypeAssignment.Count);
            foreach (var independentParameterTypeAssignment in payload.IndependentParameterTypeAssignment)
            {
                formatterResolver.GetFormatterWithVerify<IndependentParameterTypeAssignment>().Serialize(ref writer, independentParameterTypeAssignment, options);
            }

            writer.WriteArrayHeader(payload.LogEntryChangelogItem.Count);
            foreach (var logEntryChangelogItem in payload.LogEntryChangelogItem)
            {
                formatterResolver.GetFormatterWithVerify<LogEntryChangelogItem>().Serialize(ref writer, logEntryChangelogItem, options);
            }

            writer.WriteArrayHeader(payload.OrganizationalParticipant.Count);
            foreach (var organizationalParticipant in payload.OrganizationalParticipant)
            {
                formatterResolver.GetFormatterWithVerify<OrganizationalParticipant>().Serialize(ref writer, organizationalParticipant, options);
            }

            writer.WriteArrayHeader(payload.SampledFunctionParameterType.Count);
            foreach (var sampledFunctionParameterType in payload.SampledFunctionParameterType)
            {
                formatterResolver.GetFormatterWithVerify<SampledFunctionParameterType>().Serialize(ref writer, sampledFunctionParameterType, options);
            }

            
            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Payload"/>.
        /// </summary>
        /// <param name="reader">
        /// The reader to deserialize from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized value.
        /// </returns>
        public Payload Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            var formatterResolver = options.Resolver;
            options.Security.DepthStep(ref reader);

            var payload = new Payload();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;

                switch (i)
                {
                    case 0:
                        payload.Created = reader.ReadDateTime();
                        break;
                    case 1:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var actualFiniteState = formatterResolver.GetFormatterWithVerify<ActualFiniteState>().Deserialize(ref reader, options);
                            payload.ActualFiniteState.Add(actualFiniteState);
                        }
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var actualFiniteStateList = formatterResolver.GetFormatterWithVerify<ActualFiniteStateList>().Deserialize(ref reader, options);
                            payload.ActualFiniteStateList.Add(actualFiniteStateList);
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var alias = formatterResolver.GetFormatterWithVerify<Alias>().Deserialize(ref reader, options);
                            payload.Alias.Add(alias);
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var andExpression = formatterResolver.GetFormatterWithVerify<AndExpression>().Deserialize(ref reader, options);
                            payload.AndExpression.Add(andExpression);
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var arrayParameterType = formatterResolver.GetFormatterWithVerify<ArrayParameterType>().Deserialize(ref reader, options);
                            payload.ArrayParameterType.Add(arrayParameterType);
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var binaryRelationship = formatterResolver.GetFormatterWithVerify<BinaryRelationship>().Deserialize(ref reader, options);
                            payload.BinaryRelationship.Add(binaryRelationship);
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var binaryRelationshipRule = formatterResolver.GetFormatterWithVerify<BinaryRelationshipRule>().Deserialize(ref reader, options);
                            payload.BinaryRelationshipRule.Add(binaryRelationshipRule);
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var booleanParameterType = formatterResolver.GetFormatterWithVerify<BooleanParameterType>().Deserialize(ref reader, options);
                            payload.BooleanParameterType.Add(booleanParameterType);
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var builtInRuleVerification = formatterResolver.GetFormatterWithVerify<BuiltInRuleVerification>().Deserialize(ref reader, options);
                            payload.BuiltInRuleVerification.Add(builtInRuleVerification);
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var category = formatterResolver.GetFormatterWithVerify<Category>().Deserialize(ref reader, options);
                            payload.Category.Add(category);
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var citation = formatterResolver.GetFormatterWithVerify<Citation>().Deserialize(ref reader, options);
                            payload.Citation.Add(citation);
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var color = formatterResolver.GetFormatterWithVerify<Color>().Deserialize(ref reader, options);
                            payload.Color.Add(color);
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var commonFileStore = formatterResolver.GetFormatterWithVerify<CommonFileStore>().Deserialize(ref reader, options);
                            payload.CommonFileStore.Add(commonFileStore);
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var compoundParameterType = formatterResolver.GetFormatterWithVerify<CompoundParameterType>().Deserialize(ref reader, options);
                            payload.CompoundParameterType.Add(compoundParameterType);
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var constant = formatterResolver.GetFormatterWithVerify<Constant>().Deserialize(ref reader, options);
                            payload.Constant.Add(constant);
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var cyclicRatioScale = formatterResolver.GetFormatterWithVerify<CyclicRatioScale>().Deserialize(ref reader, options);
                            payload.CyclicRatioScale.Add(cyclicRatioScale);
                        }
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var dateParameterType = formatterResolver.GetFormatterWithVerify<DateParameterType>().Deserialize(ref reader, options);
                            payload.DateParameterType.Add(dateParameterType);
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var dateTimeParameterType = formatterResolver.GetFormatterWithVerify<DateTimeParameterType>().Deserialize(ref reader, options);
                            payload.DateTimeParameterType.Add(dateTimeParameterType);
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var decompositionRule = formatterResolver.GetFormatterWithVerify<DecompositionRule>().Deserialize(ref reader, options);
                            payload.DecompositionRule.Add(decompositionRule);
                        }
                        break;
                    case 20:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var definition = formatterResolver.GetFormatterWithVerify<Definition>().Deserialize(ref reader, options);
                            payload.Definition.Add(definition);
                        }
                        break;
                    case 21:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var derivedQuantityKind = formatterResolver.GetFormatterWithVerify<DerivedQuantityKind>().Deserialize(ref reader, options);
                            payload.DerivedQuantityKind.Add(derivedQuantityKind);
                        }
                        break;
                    case 22:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var derivedUnit = formatterResolver.GetFormatterWithVerify<DerivedUnit>().Deserialize(ref reader, options);
                            payload.DerivedUnit.Add(derivedUnit);
                        }
                        break;
                    case 23:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var domainFileStore = formatterResolver.GetFormatterWithVerify<DomainFileStore>().Deserialize(ref reader, options);
                            payload.DomainFileStore.Add(domainFileStore);
                        }
                        break;
                    case 24:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var domainOfExpertise = formatterResolver.GetFormatterWithVerify<DomainOfExpertise>().Deserialize(ref reader, options);
                            payload.DomainOfExpertise.Add(domainOfExpertise);
                        }
                        break;
                    case 25:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var domainOfExpertiseGroup = formatterResolver.GetFormatterWithVerify<DomainOfExpertiseGroup>().Deserialize(ref reader, options);
                            payload.DomainOfExpertiseGroup.Add(domainOfExpertiseGroup);
                        }
                        break;
                    case 26:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var elementDefinition = formatterResolver.GetFormatterWithVerify<ElementDefinition>().Deserialize(ref reader, options);
                            payload.ElementDefinition.Add(elementDefinition);
                        }
                        break;
                    case 27:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var elementUsage = formatterResolver.GetFormatterWithVerify<ElementUsage>().Deserialize(ref reader, options);
                            payload.ElementUsage.Add(elementUsage);
                        }
                        break;
                    case 28:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var emailAddress = formatterResolver.GetFormatterWithVerify<EmailAddress>().Deserialize(ref reader, options);
                            payload.EmailAddress.Add(emailAddress);
                        }
                        break;
                    case 29:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var engineeringModel = formatterResolver.GetFormatterWithVerify<EngineeringModel>().Deserialize(ref reader, options);
                            payload.EngineeringModel.Add(engineeringModel);
                        }
                        break;
                    case 30:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var engineeringModelSetup = formatterResolver.GetFormatterWithVerify<EngineeringModelSetup>().Deserialize(ref reader, options);
                            payload.EngineeringModelSetup.Add(engineeringModelSetup);
                        }
                        break;
                    case 31:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var enumerationParameterType = formatterResolver.GetFormatterWithVerify<EnumerationParameterType>().Deserialize(ref reader, options);
                            payload.EnumerationParameterType.Add(enumerationParameterType);
                        }
                        break;
                    case 32:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var enumerationValueDefinition = formatterResolver.GetFormatterWithVerify<EnumerationValueDefinition>().Deserialize(ref reader, options);
                            payload.EnumerationValueDefinition.Add(enumerationValueDefinition);
                        }
                        break;
                    case 33:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var exclusiveOrExpression = formatterResolver.GetFormatterWithVerify<ExclusiveOrExpression>().Deserialize(ref reader, options);
                            payload.ExclusiveOrExpression.Add(exclusiveOrExpression);
                        }
                        break;
                    case 34:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var externalIdentifierMap = formatterResolver.GetFormatterWithVerify<ExternalIdentifierMap>().Deserialize(ref reader, options);
                            payload.ExternalIdentifierMap.Add(externalIdentifierMap);
                        }
                        break;
                    case 35:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var file = formatterResolver.GetFormatterWithVerify<File>().Deserialize(ref reader, options);
                            payload.File.Add(file);
                        }
                        break;
                    case 36:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var fileRevision = formatterResolver.GetFormatterWithVerify<FileRevision>().Deserialize(ref reader, options);
                            payload.FileRevision.Add(fileRevision);
                        }
                        break;
                    case 37:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var fileType = formatterResolver.GetFormatterWithVerify<FileType>().Deserialize(ref reader, options);
                            payload.FileType.Add(fileType);
                        }
                        break;
                    case 38:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var folder = formatterResolver.GetFormatterWithVerify<Folder>().Deserialize(ref reader, options);
                            payload.Folder.Add(folder);
                        }
                        break;
                    case 39:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var glossary = formatterResolver.GetFormatterWithVerify<Glossary>().Deserialize(ref reader, options);
                            payload.Glossary.Add(glossary);
                        }
                        break;
                    case 40:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var hyperLink = formatterResolver.GetFormatterWithVerify<HyperLink>().Deserialize(ref reader, options);
                            payload.HyperLink.Add(hyperLink);
                        }
                        break;
                    case 41:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var idCorrespondence = formatterResolver.GetFormatterWithVerify<IdCorrespondence>().Deserialize(ref reader, options);
                            payload.IdCorrespondence.Add(idCorrespondence);
                        }
                        break;
                    case 42:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var intervalScale = formatterResolver.GetFormatterWithVerify<IntervalScale>().Deserialize(ref reader, options);
                            payload.IntervalScale.Add(intervalScale);
                        }
                        break;
                    case 43:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var iteration = formatterResolver.GetFormatterWithVerify<Iteration>().Deserialize(ref reader, options);
                            payload.Iteration.Add(iteration);
                        }
                        break;
                    case 44:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var iterationSetup = formatterResolver.GetFormatterWithVerify<IterationSetup>().Deserialize(ref reader, options);
                            payload.IterationSetup.Add(iterationSetup);
                        }
                        break;
                    case 45:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var linearConversionUnit = formatterResolver.GetFormatterWithVerify<LinearConversionUnit>().Deserialize(ref reader, options);
                            payload.LinearConversionUnit.Add(linearConversionUnit);
                        }
                        break;
                    case 46:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var logarithmicScale = formatterResolver.GetFormatterWithVerify<LogarithmicScale>().Deserialize(ref reader, options);
                            payload.LogarithmicScale.Add(logarithmicScale);
                        }
                        break;
                    case 47:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var mappingToReferenceScale = formatterResolver.GetFormatterWithVerify<MappingToReferenceScale>().Deserialize(ref reader, options);
                            payload.MappingToReferenceScale.Add(mappingToReferenceScale);
                        }
                        break;
                    case 48:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var modelLogEntry = formatterResolver.GetFormatterWithVerify<ModelLogEntry>().Deserialize(ref reader, options);
                            payload.ModelLogEntry.Add(modelLogEntry);
                        }
                        break;
                    case 49:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var modelReferenceDataLibrary = formatterResolver.GetFormatterWithVerify<ModelReferenceDataLibrary>().Deserialize(ref reader, options);
                            payload.ModelReferenceDataLibrary.Add(modelReferenceDataLibrary);
                        }
                        break;
                    case 50:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var multiRelationship = formatterResolver.GetFormatterWithVerify<MultiRelationship>().Deserialize(ref reader, options);
                            payload.MultiRelationship.Add(multiRelationship);
                        }
                        break;
                    case 51:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var multiRelationshipRule = formatterResolver.GetFormatterWithVerify<MultiRelationshipRule>().Deserialize(ref reader, options);
                            payload.MultiRelationshipRule.Add(multiRelationshipRule);
                        }
                        break;
                    case 52:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var naturalLanguage = formatterResolver.GetFormatterWithVerify<NaturalLanguage>().Deserialize(ref reader, options);
                            payload.NaturalLanguage.Add(naturalLanguage);
                        }
                        break;
                    case 53:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var nestedElement = formatterResolver.GetFormatterWithVerify<NestedElement>().Deserialize(ref reader, options);
                            payload.NestedElement.Add(nestedElement);
                        }
                        break;
                    case 54:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var nestedParameter = formatterResolver.GetFormatterWithVerify<NestedParameter>().Deserialize(ref reader, options);
                            payload.NestedParameter.Add(nestedParameter);
                        }
                        break;
                    case 55:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var notExpression = formatterResolver.GetFormatterWithVerify<NotExpression>().Deserialize(ref reader, options);
                            payload.NotExpression.Add(notExpression);
                        }
                        break;
                    case 56:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var option = formatterResolver.GetFormatterWithVerify<Option>().Deserialize(ref reader, options);
                            payload.Option.Add(option);
                        }
                        break;
                    case 57:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var ordinalScale = formatterResolver.GetFormatterWithVerify<OrdinalScale>().Deserialize(ref reader, options);
                            payload.OrdinalScale.Add(ordinalScale);
                        }
                        break;
                    case 58:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var orExpression = formatterResolver.GetFormatterWithVerify<OrExpression>().Deserialize(ref reader, options);
                            payload.OrExpression.Add(orExpression);
                        }
                        break;
                    case 59:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var organization = formatterResolver.GetFormatterWithVerify<Organization>().Deserialize(ref reader, options);
                            payload.Organization.Add(organization);
                        }
                        break;
                    case 60:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameter = formatterResolver.GetFormatterWithVerify<Parameter>().Deserialize(ref reader, options);
                            payload.Parameter.Add(parameter);
                        }
                        break;
                    case 61:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameterGroup = formatterResolver.GetFormatterWithVerify<ParameterGroup>().Deserialize(ref reader, options);
                            payload.ParameterGroup.Add(parameterGroup);
                        }
                        break;
                    case 62:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameterizedCategoryRule = formatterResolver.GetFormatterWithVerify<ParameterizedCategoryRule>().Deserialize(ref reader, options);
                            payload.ParameterizedCategoryRule.Add(parameterizedCategoryRule);
                        }
                        break;
                    case 63:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameterOverride = formatterResolver.GetFormatterWithVerify<ParameterOverride>().Deserialize(ref reader, options);
                            payload.ParameterOverride.Add(parameterOverride);
                        }
                        break;
                    case 64:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameterOverrideValueSet = formatterResolver.GetFormatterWithVerify<ParameterOverrideValueSet>().Deserialize(ref reader, options);
                            payload.ParameterOverrideValueSet.Add(parameterOverrideValueSet);
                        }
                        break;
                    case 65:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameterSubscription = formatterResolver.GetFormatterWithVerify<ParameterSubscription>().Deserialize(ref reader, options);
                            payload.ParameterSubscription.Add(parameterSubscription);
                        }
                        break;
                    case 66:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameterSubscriptionValueSet = formatterResolver.GetFormatterWithVerify<ParameterSubscriptionValueSet>().Deserialize(ref reader, options);
                            payload.ParameterSubscriptionValueSet.Add(parameterSubscriptionValueSet);
                        }
                        break;
                    case 67:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameterTypeComponent = formatterResolver.GetFormatterWithVerify<ParameterTypeComponent>().Deserialize(ref reader, options);
                            payload.ParameterTypeComponent.Add(parameterTypeComponent);
                        }
                        break;
                    case 68:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parameterValueSet = formatterResolver.GetFormatterWithVerify<ParameterValueSet>().Deserialize(ref reader, options);
                            payload.ParameterValueSet.Add(parameterValueSet);
                        }
                        break;
                    case 69:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var parametricConstraint = formatterResolver.GetFormatterWithVerify<ParametricConstraint>().Deserialize(ref reader, options);
                            payload.ParametricConstraint.Add(parametricConstraint);
                        }
                        break;
                    case 70:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var participant = formatterResolver.GetFormatterWithVerify<Participant>().Deserialize(ref reader, options);
                            payload.Participant.Add(participant);
                        }
                        break;
                    case 71:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var participantPermission = formatterResolver.GetFormatterWithVerify<ParticipantPermission>().Deserialize(ref reader, options);
                            payload.ParticipantPermission.Add(participantPermission);
                        }
                        break;
                    case 72:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var participantRole = formatterResolver.GetFormatterWithVerify<ParticipantRole>().Deserialize(ref reader, options);
                            payload.ParticipantRole.Add(participantRole);
                        }
                        break;
                    case 73:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var person = formatterResolver.GetFormatterWithVerify<Person>().Deserialize(ref reader, options);
                            payload.Person.Add(person);
                        }
                        break;
                    case 74:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var personPermission = formatterResolver.GetFormatterWithVerify<PersonPermission>().Deserialize(ref reader, options);
                            payload.PersonPermission.Add(personPermission);
                        }
                        break;
                    case 75:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var personRole = formatterResolver.GetFormatterWithVerify<PersonRole>().Deserialize(ref reader, options);
                            payload.PersonRole.Add(personRole);
                        }
                        break;
                    case 76:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var possibleFiniteState = formatterResolver.GetFormatterWithVerify<PossibleFiniteState>().Deserialize(ref reader, options);
                            payload.PossibleFiniteState.Add(possibleFiniteState);
                        }
                        break;
                    case 77:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var possibleFiniteStateList = formatterResolver.GetFormatterWithVerify<PossibleFiniteStateList>().Deserialize(ref reader, options);
                            payload.PossibleFiniteStateList.Add(possibleFiniteStateList);
                        }
                        break;
                    case 78:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var prefixedUnit = formatterResolver.GetFormatterWithVerify<PrefixedUnit>().Deserialize(ref reader, options);
                            payload.PrefixedUnit.Add(prefixedUnit);
                        }
                        break;
                    case 79:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var publication = formatterResolver.GetFormatterWithVerify<Publication>().Deserialize(ref reader, options);
                            payload.Publication.Add(publication);
                        }
                        break;
                    case 80:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var quantityKindFactor = formatterResolver.GetFormatterWithVerify<QuantityKindFactor>().Deserialize(ref reader, options);
                            payload.QuantityKindFactor.Add(quantityKindFactor);
                        }
                        break;
                    case 81:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var ratioScale = formatterResolver.GetFormatterWithVerify<RatioScale>().Deserialize(ref reader, options);
                            payload.RatioScale.Add(ratioScale);
                        }
                        break;
                    case 82:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var referencerRule = formatterResolver.GetFormatterWithVerify<ReferencerRule>().Deserialize(ref reader, options);
                            payload.ReferencerRule.Add(referencerRule);
                        }
                        break;
                    case 83:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var referenceSource = formatterResolver.GetFormatterWithVerify<ReferenceSource>().Deserialize(ref reader, options);
                            payload.ReferenceSource.Add(referenceSource);
                        }
                        break;
                    case 84:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var relationalExpression = formatterResolver.GetFormatterWithVerify<RelationalExpression>().Deserialize(ref reader, options);
                            payload.RelationalExpression.Add(relationalExpression);
                        }
                        break;
                    case 85:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var requirement = formatterResolver.GetFormatterWithVerify<Requirement>().Deserialize(ref reader, options);
                            payload.Requirement.Add(requirement);
                        }
                        break;
                    case 86:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var requirementsGroup = formatterResolver.GetFormatterWithVerify<RequirementsGroup>().Deserialize(ref reader, options);
                            payload.RequirementsGroup.Add(requirementsGroup);
                        }
                        break;
                    case 87:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var requirementsSpecification = formatterResolver.GetFormatterWithVerify<RequirementsSpecification>().Deserialize(ref reader, options);
                            payload.RequirementsSpecification.Add(requirementsSpecification);
                        }
                        break;
                    case 88:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var ruleVerificationList = formatterResolver.GetFormatterWithVerify<RuleVerificationList>().Deserialize(ref reader, options);
                            payload.RuleVerificationList.Add(ruleVerificationList);
                        }
                        break;
                    case 89:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var ruleViolation = formatterResolver.GetFormatterWithVerify<RuleViolation>().Deserialize(ref reader, options);
                            payload.RuleViolation.Add(ruleViolation);
                        }
                        break;
                    case 90:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var scaleReferenceQuantityValue = formatterResolver.GetFormatterWithVerify<ScaleReferenceQuantityValue>().Deserialize(ref reader, options);
                            payload.ScaleReferenceQuantityValue.Add(scaleReferenceQuantityValue);
                        }
                        break;
                    case 91:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var scaleValueDefinition = formatterResolver.GetFormatterWithVerify<ScaleValueDefinition>().Deserialize(ref reader, options);
                            payload.ScaleValueDefinition.Add(scaleValueDefinition);
                        }
                        break;
                    case 92:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var simpleParameterValue = formatterResolver.GetFormatterWithVerify<SimpleParameterValue>().Deserialize(ref reader, options);
                            payload.SimpleParameterValue.Add(simpleParameterValue);
                        }
                        break;
                    case 93:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var simpleQuantityKind = formatterResolver.GetFormatterWithVerify<SimpleQuantityKind>().Deserialize(ref reader, options);
                            payload.SimpleQuantityKind.Add(simpleQuantityKind);
                        }
                        break;
                    case 94:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var simpleUnit = formatterResolver.GetFormatterWithVerify<SimpleUnit>().Deserialize(ref reader, options);
                            payload.SimpleUnit.Add(simpleUnit);
                        }
                        break;
                    case 95:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var siteDirectory = formatterResolver.GetFormatterWithVerify<SiteDirectory>().Deserialize(ref reader, options);
                            payload.SiteDirectory.Add(siteDirectory);
                        }
                        break;
                    case 96:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var siteLogEntry = formatterResolver.GetFormatterWithVerify<SiteLogEntry>().Deserialize(ref reader, options);
                            payload.SiteLogEntry.Add(siteLogEntry);
                        }
                        break;
                    case 97:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var siteReferenceDataLibrary = formatterResolver.GetFormatterWithVerify<SiteReferenceDataLibrary>().Deserialize(ref reader, options);
                            payload.SiteReferenceDataLibrary.Add(siteReferenceDataLibrary);
                        }
                        break;
                    case 98:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var specializedQuantityKind = formatterResolver.GetFormatterWithVerify<SpecializedQuantityKind>().Deserialize(ref reader, options);
                            payload.SpecializedQuantityKind.Add(specializedQuantityKind);
                        }
                        break;
                    case 99:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var telephoneNumber = formatterResolver.GetFormatterWithVerify<TelephoneNumber>().Deserialize(ref reader, options);
                            payload.TelephoneNumber.Add(telephoneNumber);
                        }
                        break;
                    case 100:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var term = formatterResolver.GetFormatterWithVerify<Term>().Deserialize(ref reader, options);
                            payload.Term.Add(term);
                        }
                        break;
                    case 101:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var textParameterType = formatterResolver.GetFormatterWithVerify<TextParameterType>().Deserialize(ref reader, options);
                            payload.TextParameterType.Add(textParameterType);
                        }
                        break;
                    case 102:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var timeOfDayParameterType = formatterResolver.GetFormatterWithVerify<TimeOfDayParameterType>().Deserialize(ref reader, options);
                            payload.TimeOfDayParameterType.Add(timeOfDayParameterType);
                        }
                        break;
                    case 103:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var unitFactor = formatterResolver.GetFormatterWithVerify<UnitFactor>().Deserialize(ref reader, options);
                            payload.UnitFactor.Add(unitFactor);
                        }
                        break;
                    case 104:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var unitPrefix = formatterResolver.GetFormatterWithVerify<UnitPrefix>().Deserialize(ref reader, options);
                            payload.UnitPrefix.Add(unitPrefix);
                        }
                        break;
                    case 105:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var userPreference = formatterResolver.GetFormatterWithVerify<UserPreference>().Deserialize(ref reader, options);
                            payload.UserPreference.Add(userPreference);
                        }
                        break;
                    case 106:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var userRuleVerification = formatterResolver.GetFormatterWithVerify<UserRuleVerification>().Deserialize(ref reader, options);
                            payload.UserRuleVerification.Add(userRuleVerification);
                        }
                        break;
                    case 107:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var actionItem = formatterResolver.GetFormatterWithVerify<ActionItem>().Deserialize(ref reader, options);
                            payload.ActionItem.Add(actionItem);
                        }
                        break;
                    case 108:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var approval = formatterResolver.GetFormatterWithVerify<Approval>().Deserialize(ref reader, options);
                            payload.Approval.Add(approval);
                        }
                        break;
                    case 109:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var binaryNote = formatterResolver.GetFormatterWithVerify<BinaryNote>().Deserialize(ref reader, options);
                            payload.BinaryNote.Add(binaryNote);
                        }
                        break;
                    case 110:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var book = formatterResolver.GetFormatterWithVerify<Book>().Deserialize(ref reader, options);
                            payload.Book.Add(book);
                        }
                        break;
                    case 111:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var bounds = formatterResolver.GetFormatterWithVerify<Bounds>().Deserialize(ref reader, options);
                            payload.Bounds.Add(bounds);
                        }
                        break;
                    case 112:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var changeProposal = formatterResolver.GetFormatterWithVerify<ChangeProposal>().Deserialize(ref reader, options);
                            payload.ChangeProposal.Add(changeProposal);
                        }
                        break;
                    case 113:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var changeRequest = formatterResolver.GetFormatterWithVerify<ChangeRequest>().Deserialize(ref reader, options);
                            payload.ChangeRequest.Add(changeRequest);
                        }
                        break;
                    case 114:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var contractChangeNotice = formatterResolver.GetFormatterWithVerify<ContractChangeNotice>().Deserialize(ref reader, options);
                            payload.ContractChangeNotice.Add(contractChangeNotice);
                        }
                        break;
                    case 115:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var diagramCanvas = formatterResolver.GetFormatterWithVerify<DiagramCanvas>().Deserialize(ref reader, options);
                            payload.DiagramCanvas.Add(diagramCanvas);
                        }
                        break;
                    case 116:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var diagramEdge = formatterResolver.GetFormatterWithVerify<DiagramEdge>().Deserialize(ref reader, options);
                            payload.DiagramEdge.Add(diagramEdge);
                        }
                        break;
                    case 117:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var diagramObject = formatterResolver.GetFormatterWithVerify<DiagramObject>().Deserialize(ref reader, options);
                            payload.DiagramObject.Add(diagramObject);
                        }
                        break;
                    case 118:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var engineeringModelDataDiscussionItem = formatterResolver.GetFormatterWithVerify<EngineeringModelDataDiscussionItem>().Deserialize(ref reader, options);
                            payload.EngineeringModelDataDiscussionItem.Add(engineeringModelDataDiscussionItem);
                        }
                        break;
                    case 119:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var engineeringModelDataNote = formatterResolver.GetFormatterWithVerify<EngineeringModelDataNote>().Deserialize(ref reader, options);
                            payload.EngineeringModelDataNote.Add(engineeringModelDataNote);
                        }
                        break;
                    case 120:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var goal = formatterResolver.GetFormatterWithVerify<Goal>().Deserialize(ref reader, options);
                            payload.Goal.Add(goal);
                        }
                        break;
                    case 121:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var modellingThingReference = formatterResolver.GetFormatterWithVerify<ModellingThingReference>().Deserialize(ref reader, options);
                            payload.ModellingThingReference.Add(modellingThingReference);
                        }
                        break;
                    case 122:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var ownedStyle = formatterResolver.GetFormatterWithVerify<OwnedStyle>().Deserialize(ref reader, options);
                            payload.OwnedStyle.Add(ownedStyle);
                        }
                        break;
                    case 123:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var page = formatterResolver.GetFormatterWithVerify<Page>().Deserialize(ref reader, options);
                            payload.Page.Add(page);
                        }
                        break;
                    case 124:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var point = formatterResolver.GetFormatterWithVerify<Point>().Deserialize(ref reader, options);
                            payload.Point.Add(point);
                        }
                        break;
                    case 125:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var relationshipParameterValue = formatterResolver.GetFormatterWithVerify<RelationshipParameterValue>().Deserialize(ref reader, options);
                            payload.RelationshipParameterValue.Add(relationshipParameterValue);
                        }
                        break;
                    case 126:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var requestForDeviation = formatterResolver.GetFormatterWithVerify<RequestForDeviation>().Deserialize(ref reader, options);
                            payload.RequestForDeviation.Add(requestForDeviation);
                        }
                        break;
                    case 127:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var requestForWaiver = formatterResolver.GetFormatterWithVerify<RequestForWaiver>().Deserialize(ref reader, options);
                            payload.RequestForWaiver.Add(requestForWaiver);
                        }
                        break;
                    case 128:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var requirementsContainerParameterValue = formatterResolver.GetFormatterWithVerify<RequirementsContainerParameterValue>().Deserialize(ref reader, options);
                            payload.RequirementsContainerParameterValue.Add(requirementsContainerParameterValue);
                        }
                        break;
                    case 129:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var reviewItemDiscrepancy = formatterResolver.GetFormatterWithVerify<ReviewItemDiscrepancy>().Deserialize(ref reader, options);
                            payload.ReviewItemDiscrepancy.Add(reviewItemDiscrepancy);
                        }
                        break;
                    case 130:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var section = formatterResolver.GetFormatterWithVerify<Section>().Deserialize(ref reader, options);
                            payload.Section.Add(section);
                        }
                        break;
                    case 131:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var sharedStyle = formatterResolver.GetFormatterWithVerify<SharedStyle>().Deserialize(ref reader, options);
                            payload.SharedStyle.Add(sharedStyle);
                        }
                        break;
                    case 132:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var siteDirectoryDataAnnotation = formatterResolver.GetFormatterWithVerify<SiteDirectoryDataAnnotation>().Deserialize(ref reader, options);
                            payload.SiteDirectoryDataAnnotation.Add(siteDirectoryDataAnnotation);
                        }
                        break;
                    case 133:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var siteDirectoryDataDiscussionItem = formatterResolver.GetFormatterWithVerify<SiteDirectoryDataDiscussionItem>().Deserialize(ref reader, options);
                            payload.SiteDirectoryDataDiscussionItem.Add(siteDirectoryDataDiscussionItem);
                        }
                        break;
                    case 134:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var siteDirectoryThingReference = formatterResolver.GetFormatterWithVerify<SiteDirectoryThingReference>().Deserialize(ref reader, options);
                            payload.SiteDirectoryThingReference.Add(siteDirectoryThingReference);
                        }
                        break;
                    case 135:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var solution = formatterResolver.GetFormatterWithVerify<Solution>().Deserialize(ref reader, options);
                            payload.Solution.Add(solution);
                        }
                        break;
                    case 136:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var stakeholder = formatterResolver.GetFormatterWithVerify<Stakeholder>().Deserialize(ref reader, options);
                            payload.Stakeholder.Add(stakeholder);
                        }
                        break;
                    case 137:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var stakeholderValue = formatterResolver.GetFormatterWithVerify<StakeholderValue>().Deserialize(ref reader, options);
                            payload.StakeholderValue.Add(stakeholderValue);
                        }
                        break;
                    case 138:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var stakeHolderValueMap = formatterResolver.GetFormatterWithVerify<StakeHolderValueMap>().Deserialize(ref reader, options);
                            payload.StakeHolderValueMap.Add(stakeHolderValueMap);
                        }
                        break;
                    case 139:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var stakeHolderValueMapSettings = formatterResolver.GetFormatterWithVerify<StakeHolderValueMapSettings>().Deserialize(ref reader, options);
                            payload.StakeHolderValueMapSettings.Add(stakeHolderValueMapSettings);
                        }
                        break;
                    case 140:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var textualNote = formatterResolver.GetFormatterWithVerify<TextualNote>().Deserialize(ref reader, options);
                            payload.TextualNote.Add(textualNote);
                        }
                        break;
                    case 141:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var valueGroup = formatterResolver.GetFormatterWithVerify<ValueGroup>().Deserialize(ref reader, options);
                            payload.ValueGroup.Add(valueGroup);
                        }
                        break;
                    case 142:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var dependentParameterTypeAssignment = formatterResolver.GetFormatterWithVerify<DependentParameterTypeAssignment>().Deserialize(ref reader, options);
                            payload.DependentParameterTypeAssignment.Add(dependentParameterTypeAssignment);
                        }
                        break;
                    case 143:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var independentParameterTypeAssignment = formatterResolver.GetFormatterWithVerify<IndependentParameterTypeAssignment>().Deserialize(ref reader, options);
                            payload.IndependentParameterTypeAssignment.Add(independentParameterTypeAssignment);
                        }
                        break;
                    case 144:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var logEntryChangelogItem = formatterResolver.GetFormatterWithVerify<LogEntryChangelogItem>().Deserialize(ref reader, options);
                            payload.LogEntryChangelogItem.Add(logEntryChangelogItem);
                        }
                        break;
                    case 145:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var organizationalParticipant = formatterResolver.GetFormatterWithVerify<OrganizationalParticipant>().Deserialize(ref reader, options);
                            payload.OrganizationalParticipant.Add(organizationalParticipant);
                        }
                        break;
                    case 146:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            var sampledFunctionParameterType = formatterResolver.GetFormatterWithVerify<SampledFunctionParameterType>().Deserialize(ref reader, options);
                            payload.SampledFunctionParameterType.Add(sampledFunctionParameterType);
                        }
                        break;
                }
            }

            return payload;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
