// ------------------------------------------------------------------------------------------------
// <copyright file="ThingEquatable.cs" company="Starion Group S.A.">
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
// ------------------------------------------------------------------------------------------------

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

namespace CDP4Common.DTO.Equatable
{
    using CDP4Common.DTO;

    /// <summary>
    /// An utility class for the <see cref="Thing"/> class to support the computation
    /// of property based equality
    /// </summary>
    public static class ThingEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="Thing"/> objects are the same
        /// by comparing all the properties, including <see cref="CDP4Common.CommonData.ClassKind"/>
        /// </summary>
        /// <param name="me">
        /// The current <see cref="Thing"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="Thing"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="Thing"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(Thing me, Thing other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.ClassKind.Equals(other.ClassKind)) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            switch (me)
            {
                case ActualFiniteState actualFiniteState:
                    return actualFiniteState.ArePropertiesEqual((ActualFiniteState)other);
                case ActualFiniteStateList actualFiniteStateList:
                    return actualFiniteStateList.ArePropertiesEqual((ActualFiniteStateList)other);
                case Alias alias:
                    return alias.ArePropertiesEqual((Alias)other);
                case AndExpression andExpression:
                    return andExpression.ArePropertiesEqual((AndExpression)other);
                case ArrayParameterType arrayParameterType:
                    return arrayParameterType.ArePropertiesEqual((ArrayParameterType)other);
                case BinaryRelationship binaryRelationship:
                    return binaryRelationship.ArePropertiesEqual((BinaryRelationship)other);
                case BinaryRelationshipRule binaryRelationshipRule:
                    return binaryRelationshipRule.ArePropertiesEqual((BinaryRelationshipRule)other);
                case BooleanParameterType booleanParameterType:
                    return booleanParameterType.ArePropertiesEqual((BooleanParameterType)other);
                case BuiltInRuleVerification builtInRuleVerification:
                    return builtInRuleVerification.ArePropertiesEqual((BuiltInRuleVerification)other);
                case Category category:
                    return category.ArePropertiesEqual((Category)other);
                case Citation citation:
                    return citation.ArePropertiesEqual((Citation)other);
                case Color color:
                    return color.ArePropertiesEqual((Color)other);
                case CommonFileStore commonFileStore:
                    return commonFileStore.ArePropertiesEqual((CommonFileStore)other);
                case CompoundParameterType compoundParameterType:
                    return compoundParameterType.ArePropertiesEqual((CompoundParameterType)other);
                case Constant constant:
                    return constant.ArePropertiesEqual((Constant)other);
                case CyclicRatioScale cyclicRatioScale:
                    return cyclicRatioScale.ArePropertiesEqual((CyclicRatioScale)other);
                case DateParameterType dateParameterType:
                    return dateParameterType.ArePropertiesEqual((DateParameterType)other);
                case DateTimeParameterType dateTimeParameterType:
                    return dateTimeParameterType.ArePropertiesEqual((DateTimeParameterType)other);
                case DecompositionRule decompositionRule:
                    return decompositionRule.ArePropertiesEqual((DecompositionRule)other);
                case Definition definition:
                    return definition.ArePropertiesEqual((Definition)other);
                case DerivedQuantityKind derivedQuantityKind:
                    return derivedQuantityKind.ArePropertiesEqual((DerivedQuantityKind)other);
                case DerivedUnit derivedUnit:
                    return derivedUnit.ArePropertiesEqual((DerivedUnit)other);
                case DomainFileStore domainFileStore:
                    return domainFileStore.ArePropertiesEqual((DomainFileStore)other);
                case DomainOfExpertise domainOfExpertise:
                    return domainOfExpertise.ArePropertiesEqual((DomainOfExpertise)other);
                case DomainOfExpertiseGroup domainOfExpertiseGroup:
                    return domainOfExpertiseGroup.ArePropertiesEqual((DomainOfExpertiseGroup)other);
                case ElementDefinition elementDefinition:
                    return elementDefinition.ArePropertiesEqual((ElementDefinition)other);
                case ElementUsage elementUsage:
                    return elementUsage.ArePropertiesEqual((ElementUsage)other);
                case EmailAddress emailAddress:
                    return emailAddress.ArePropertiesEqual((EmailAddress)other);
                case EngineeringModel engineeringModel:
                    return engineeringModel.ArePropertiesEqual((EngineeringModel)other);
                case EngineeringModelSetup engineeringModelSetup:
                    return engineeringModelSetup.ArePropertiesEqual((EngineeringModelSetup)other);
                case EnumerationParameterType enumerationParameterType:
                    return enumerationParameterType.ArePropertiesEqual((EnumerationParameterType)other);
                case EnumerationValueDefinition enumerationValueDefinition:
                    return enumerationValueDefinition.ArePropertiesEqual((EnumerationValueDefinition)other);
                case ExclusiveOrExpression exclusiveOrExpression:
                    return exclusiveOrExpression.ArePropertiesEqual((ExclusiveOrExpression)other);
                case ExternalIdentifierMap externalIdentifierMap:
                    return externalIdentifierMap.ArePropertiesEqual((ExternalIdentifierMap)other);
                case File file:
                    return file.ArePropertiesEqual((File)other);
                case FileRevision fileRevision:
                    return fileRevision.ArePropertiesEqual((FileRevision)other);
                case FileType fileType:
                    return fileType.ArePropertiesEqual((FileType)other);
                case Folder folder:
                    return folder.ArePropertiesEqual((Folder)other);
                case Glossary glossary:
                    return glossary.ArePropertiesEqual((Glossary)other);
                case HyperLink hyperLink:
                    return hyperLink.ArePropertiesEqual((HyperLink)other);
                case IdCorrespondence idCorrespondence:
                    return idCorrespondence.ArePropertiesEqual((IdCorrespondence)other);
                case IntervalScale intervalScale:
                    return intervalScale.ArePropertiesEqual((IntervalScale)other);
                case Iteration iteration:
                    return iteration.ArePropertiesEqual((Iteration)other);
                case IterationSetup iterationSetup:
                    return iterationSetup.ArePropertiesEqual((IterationSetup)other);
                case LinearConversionUnit linearConversionUnit:
                    return linearConversionUnit.ArePropertiesEqual((LinearConversionUnit)other);
                case LogarithmicScale logarithmicScale:
                    return logarithmicScale.ArePropertiesEqual((LogarithmicScale)other);
                case MappingToReferenceScale mappingToReferenceScale:
                    return mappingToReferenceScale.ArePropertiesEqual((MappingToReferenceScale)other);
                case ModelLogEntry modelLogEntry:
                    return modelLogEntry.ArePropertiesEqual((ModelLogEntry)other);
                case ModelReferenceDataLibrary modelReferenceDataLibrary:
                    return modelReferenceDataLibrary.ArePropertiesEqual((ModelReferenceDataLibrary)other);
                case MultiRelationship multiRelationship:
                    return multiRelationship.ArePropertiesEqual((MultiRelationship)other);
                case MultiRelationshipRule multiRelationshipRule:
                    return multiRelationshipRule.ArePropertiesEqual((MultiRelationshipRule)other);
                case NaturalLanguage naturalLanguage:
                    return naturalLanguage.ArePropertiesEqual((NaturalLanguage)other);
                case NestedElement nestedElement:
                    return nestedElement.ArePropertiesEqual((NestedElement)other);
                case NestedParameter nestedParameter:
                    return nestedParameter.ArePropertiesEqual((NestedParameter)other);
                case NotExpression notExpression:
                    return notExpression.ArePropertiesEqual((NotExpression)other);
                case Option option:
                    return option.ArePropertiesEqual((Option)other);
                case OrdinalScale ordinalScale:
                    return ordinalScale.ArePropertiesEqual((OrdinalScale)other);
                case OrExpression orExpression:
                    return orExpression.ArePropertiesEqual((OrExpression)other);
                case Organization organization:
                    return organization.ArePropertiesEqual((Organization)other);
                case Parameter parameter:
                    return parameter.ArePropertiesEqual((Parameter)other);
                case ParameterGroup parameterGroup:
                    return parameterGroup.ArePropertiesEqual((ParameterGroup)other);
                case ParameterizedCategoryRule parameterizedCategoryRule:
                    return parameterizedCategoryRule.ArePropertiesEqual((ParameterizedCategoryRule)other);
                case ParameterOverride parameterOverride:
                    return parameterOverride.ArePropertiesEqual((ParameterOverride)other);
                case ParameterOverrideValueSet parameterOverrideValueSet:
                    return parameterOverrideValueSet.ArePropertiesEqual((ParameterOverrideValueSet)other);
                case ParameterSubscription parameterSubscription:
                    return parameterSubscription.ArePropertiesEqual((ParameterSubscription)other);
                case ParameterSubscriptionValueSet parameterSubscriptionValueSet:
                    return parameterSubscriptionValueSet.ArePropertiesEqual((ParameterSubscriptionValueSet)other);
                case ParameterTypeComponent parameterTypeComponent:
                    return parameterTypeComponent.ArePropertiesEqual((ParameterTypeComponent)other);
                case ParameterValueSet parameterValueSet:
                    return parameterValueSet.ArePropertiesEqual((ParameterValueSet)other);
                case ParametricConstraint parametricConstraint:
                    return parametricConstraint.ArePropertiesEqual((ParametricConstraint)other);
                case Participant participant:
                    return participant.ArePropertiesEqual((Participant)other);
                case ParticipantPermission participantPermission:
                    return participantPermission.ArePropertiesEqual((ParticipantPermission)other);
                case ParticipantRole participantRole:
                    return participantRole.ArePropertiesEqual((ParticipantRole)other);
                case Person person:
                    return person.ArePropertiesEqual((Person)other);
                case PersonPermission personPermission:
                    return personPermission.ArePropertiesEqual((PersonPermission)other);
                case PersonRole personRole:
                    return personRole.ArePropertiesEqual((PersonRole)other);
                case PossibleFiniteState possibleFiniteState:
                    return possibleFiniteState.ArePropertiesEqual((PossibleFiniteState)other);
                case PossibleFiniteStateList possibleFiniteStateList:
                    return possibleFiniteStateList.ArePropertiesEqual((PossibleFiniteStateList)other);
                case PrefixedUnit prefixedUnit:
                    return prefixedUnit.ArePropertiesEqual((PrefixedUnit)other);
                case Publication publication:
                    return publication.ArePropertiesEqual((Publication)other);
                case QuantityKindFactor quantityKindFactor:
                    return quantityKindFactor.ArePropertiesEqual((QuantityKindFactor)other);
                case RatioScale ratioScale:
                    return ratioScale.ArePropertiesEqual((RatioScale)other);
                case ReferencerRule referencerRule:
                    return referencerRule.ArePropertiesEqual((ReferencerRule)other);
                case ReferenceSource referenceSource:
                    return referenceSource.ArePropertiesEqual((ReferenceSource)other);
                case RelationalExpression relationalExpression:
                    return relationalExpression.ArePropertiesEqual((RelationalExpression)other);
                case Requirement requirement:
                    return requirement.ArePropertiesEqual((Requirement)other);
                case RequirementsGroup requirementsGroup:
                    return requirementsGroup.ArePropertiesEqual((RequirementsGroup)other);
                case RequirementsSpecification requirementsSpecification:
                    return requirementsSpecification.ArePropertiesEqual((RequirementsSpecification)other);
                case RuleVerificationList ruleVerificationList:
                    return ruleVerificationList.ArePropertiesEqual((RuleVerificationList)other);
                case RuleViolation ruleViolation:
                    return ruleViolation.ArePropertiesEqual((RuleViolation)other);
                case ScaleReferenceQuantityValue scaleReferenceQuantityValue:
                    return scaleReferenceQuantityValue.ArePropertiesEqual((ScaleReferenceQuantityValue)other);
                case ScaleValueDefinition scaleValueDefinition:
                    return scaleValueDefinition.ArePropertiesEqual((ScaleValueDefinition)other);
                case SimpleParameterValue simpleParameterValue:
                    return simpleParameterValue.ArePropertiesEqual((SimpleParameterValue)other);
                case SimpleQuantityKind simpleQuantityKind:
                    return simpleQuantityKind.ArePropertiesEqual((SimpleQuantityKind)other);
                case SimpleUnit simpleUnit:
                    return simpleUnit.ArePropertiesEqual((SimpleUnit)other);
                case SiteDirectory siteDirectory:
                    return siteDirectory.ArePropertiesEqual((SiteDirectory)other);
                case SiteLogEntry siteLogEntry:
                    return siteLogEntry.ArePropertiesEqual((SiteLogEntry)other);
                case SiteReferenceDataLibrary siteReferenceDataLibrary:
                    return siteReferenceDataLibrary.ArePropertiesEqual((SiteReferenceDataLibrary)other);
                case SpecializedQuantityKind specializedQuantityKind:
                    return specializedQuantityKind.ArePropertiesEqual((SpecializedQuantityKind)other);
                case TelephoneNumber telephoneNumber:
                    return telephoneNumber.ArePropertiesEqual((TelephoneNumber)other);
                case Term term:
                    return term.ArePropertiesEqual((Term)other);
                case TextParameterType textParameterType:
                    return textParameterType.ArePropertiesEqual((TextParameterType)other);
                case TimeOfDayParameterType timeOfDayParameterType:
                    return timeOfDayParameterType.ArePropertiesEqual((TimeOfDayParameterType)other);
                case UnitFactor unitFactor:
                    return unitFactor.ArePropertiesEqual((UnitFactor)other);
                case UnitPrefix unitPrefix:
                    return unitPrefix.ArePropertiesEqual((UnitPrefix)other);
                case UserPreference userPreference:
                    return userPreference.ArePropertiesEqual((UserPreference)other);
                case UserRuleVerification userRuleVerification:
                    return userRuleVerification.ArePropertiesEqual((UserRuleVerification)other);
                case ActionItem actionItem:
                    return actionItem.ArePropertiesEqual((ActionItem)other);
                case Approval approval:
                    return approval.ArePropertiesEqual((Approval)other);
                case BinaryNote binaryNote:
                    return binaryNote.ArePropertiesEqual((BinaryNote)other);
                case Book book:
                    return book.ArePropertiesEqual((Book)other);
                case Bounds bounds:
                    return bounds.ArePropertiesEqual((Bounds)other);
                case ChangeProposal changeProposal:
                    return changeProposal.ArePropertiesEqual((ChangeProposal)other);
                case ChangeRequest changeRequest:
                    return changeRequest.ArePropertiesEqual((ChangeRequest)other);
                case ContractChangeNotice contractChangeNotice:
                    return contractChangeNotice.ArePropertiesEqual((ContractChangeNotice)other);
                case DiagramCanvas diagramCanvas:
                    return diagramCanvas.ArePropertiesEqual((DiagramCanvas)other);
                case DiagramEdge diagramEdge:
                    return diagramEdge.ArePropertiesEqual((DiagramEdge)other);
                case DiagramObject diagramObject:
                    return diagramObject.ArePropertiesEqual((DiagramObject)other);
                case EngineeringModelDataDiscussionItem engineeringModelDataDiscussionItem:
                    return engineeringModelDataDiscussionItem.ArePropertiesEqual((EngineeringModelDataDiscussionItem)other);
                case EngineeringModelDataNote engineeringModelDataNote:
                    return engineeringModelDataNote.ArePropertiesEqual((EngineeringModelDataNote)other);
                case Goal goal:
                    return goal.ArePropertiesEqual((Goal)other);
                case ModellingThingReference modellingThingReference:
                    return modellingThingReference.ArePropertiesEqual((ModellingThingReference)other);
                case OwnedStyle ownedStyle:
                    return ownedStyle.ArePropertiesEqual((OwnedStyle)other);
                case Page page:
                    return page.ArePropertiesEqual((Page)other);
                case Point point:
                    return point.ArePropertiesEqual((Point)other);
                case RelationshipParameterValue relationshipParameterValue:
                    return relationshipParameterValue.ArePropertiesEqual((RelationshipParameterValue)other);
                case RequestForDeviation requestForDeviation:
                    return requestForDeviation.ArePropertiesEqual((RequestForDeviation)other);
                case RequestForWaiver requestForWaiver:
                    return requestForWaiver.ArePropertiesEqual((RequestForWaiver)other);
                case RequirementsContainerParameterValue requirementsContainerParameterValue:
                    return requirementsContainerParameterValue.ArePropertiesEqual((RequirementsContainerParameterValue)other);
                case ReviewItemDiscrepancy reviewItemDiscrepancy:
                    return reviewItemDiscrepancy.ArePropertiesEqual((ReviewItemDiscrepancy)other);
                case Section section:
                    return section.ArePropertiesEqual((Section)other);
                case SharedStyle sharedStyle:
                    return sharedStyle.ArePropertiesEqual((SharedStyle)other);
                case SiteDirectoryDataAnnotation siteDirectoryDataAnnotation:
                    return siteDirectoryDataAnnotation.ArePropertiesEqual((SiteDirectoryDataAnnotation)other);
                case SiteDirectoryDataDiscussionItem siteDirectoryDataDiscussionItem:
                    return siteDirectoryDataDiscussionItem.ArePropertiesEqual((SiteDirectoryDataDiscussionItem)other);
                case SiteDirectoryThingReference siteDirectoryThingReference:
                    return siteDirectoryThingReference.ArePropertiesEqual((SiteDirectoryThingReference)other);
                case Solution solution:
                    return solution.ArePropertiesEqual((Solution)other);
                case Stakeholder stakeholder:
                    return stakeholder.ArePropertiesEqual((Stakeholder)other);
                case StakeholderValue stakeholderValue:
                    return stakeholderValue.ArePropertiesEqual((StakeholderValue)other);
                case StakeHolderValueMap stakeHolderValueMap:
                    return stakeHolderValueMap.ArePropertiesEqual((StakeHolderValueMap)other);
                case StakeHolderValueMapSettings stakeHolderValueMapSettings:
                    return stakeHolderValueMapSettings.ArePropertiesEqual((StakeHolderValueMapSettings)other);
                case TextualNote textualNote:
                    return textualNote.ArePropertiesEqual((TextualNote)other);
                case ValueGroup valueGroup:
                    return valueGroup.ArePropertiesEqual((ValueGroup)other);
                case DependentParameterTypeAssignment dependentParameterTypeAssignment:
                    return dependentParameterTypeAssignment.ArePropertiesEqual((DependentParameterTypeAssignment)other);
                case IndependentParameterTypeAssignment independentParameterTypeAssignment:
                    return independentParameterTypeAssignment.ArePropertiesEqual((IndependentParameterTypeAssignment)other);
                case LogEntryChangelogItem logEntryChangelogItem:
                    return logEntryChangelogItem.ArePropertiesEqual((LogEntryChangelogItem)other);
                case OrganizationalParticipant organizationalParticipant:
                    return organizationalParticipant.ArePropertiesEqual((OrganizationalParticipant)other);
                case SampledFunctionParameterType sampledFunctionParameterType:
                    return sampledFunctionParameterType.ArePropertiesEqual((SampledFunctionParameterType)other);
                default:
                    return false;
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
