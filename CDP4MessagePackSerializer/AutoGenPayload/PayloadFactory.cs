// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayloadFactory.cs" company="Starion Group S.A.">
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

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.DTO;

    /// <summary>
    /// The purpose of the <see cref="PayloadFactory"/> class is to create an
    /// instance of <see cref="Payload"/>
    /// </summary>
    internal static class PayloadFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="Payload"/> from the provided <see cref="IEnumerable{Thing}"/>
        /// </summary>
        /// <param name="things">
        /// The <see cref="IEnumerable{Thing}"/> on the bases of which the <see cref="Payload"/> will
        /// be created
        /// </param>
        /// <returns>
        /// An instance of <see cref="Payload"/>
        /// </returns>
        internal static Payload ToPayload(this IEnumerable<Thing> things)
        {
            if (things == null)
            {
                throw new ArgumentNullException(nameof(things));
            }

            var payload = new Payload
            {
                Created = DateTime.UtcNow,
            };

            foreach (var thing in things)
            {
                switch (thing)
                {
                    case ActualFiniteState actualFiniteState:
                        payload.ActualFiniteState.Add(actualFiniteState);
                        break;
                    case ActualFiniteStateList actualFiniteStateList:
                        payload.ActualFiniteStateList.Add(actualFiniteStateList);
                        break;
                    case Alias alias:
                        payload.Alias.Add(alias);
                        break;
                    case AndExpression andExpression:
                        payload.AndExpression.Add(andExpression);
                        break;
                    case ArrayParameterType arrayParameterType:
                        payload.ArrayParameterType.Add(arrayParameterType);
                        break;
                    case BinaryRelationship binaryRelationship:
                        payload.BinaryRelationship.Add(binaryRelationship);
                        break;
                    case BinaryRelationshipRule binaryRelationshipRule:
                        payload.BinaryRelationshipRule.Add(binaryRelationshipRule);
                        break;
                    case BooleanParameterType booleanParameterType:
                        payload.BooleanParameterType.Add(booleanParameterType);
                        break;
                    case BuiltInRuleVerification builtInRuleVerification:
                        payload.BuiltInRuleVerification.Add(builtInRuleVerification);
                        break;
                    case Category category:
                        payload.Category.Add(category);
                        break;
                    case Citation citation:
                        payload.Citation.Add(citation);
                        break;
                    case Color color:
                        payload.Color.Add(color);
                        break;
                    case CommonFileStore commonFileStore:
                        payload.CommonFileStore.Add(commonFileStore);
                        break;
                    case CompoundParameterType compoundParameterType:
                        payload.CompoundParameterType.Add(compoundParameterType);
                        break;
                    case Constant constant:
                        payload.Constant.Add(constant);
                        break;
                    case CyclicRatioScale cyclicRatioScale:
                        payload.CyclicRatioScale.Add(cyclicRatioScale);
                        break;
                    case DateParameterType dateParameterType:
                        payload.DateParameterType.Add(dateParameterType);
                        break;
                    case DateTimeParameterType dateTimeParameterType:
                        payload.DateTimeParameterType.Add(dateTimeParameterType);
                        break;
                    case DecompositionRule decompositionRule:
                        payload.DecompositionRule.Add(decompositionRule);
                        break;
                    case Definition definition:
                        payload.Definition.Add(definition);
                        break;
                    case DerivedQuantityKind derivedQuantityKind:
                        payload.DerivedQuantityKind.Add(derivedQuantityKind);
                        break;
                    case DerivedUnit derivedUnit:
                        payload.DerivedUnit.Add(derivedUnit);
                        break;
                    case DomainFileStore domainFileStore:
                        payload.DomainFileStore.Add(domainFileStore);
                        break;
                    case DomainOfExpertise domainOfExpertise:
                        payload.DomainOfExpertise.Add(domainOfExpertise);
                        break;
                    case DomainOfExpertiseGroup domainOfExpertiseGroup:
                        payload.DomainOfExpertiseGroup.Add(domainOfExpertiseGroup);
                        break;
                    case ElementDefinition elementDefinition:
                        payload.ElementDefinition.Add(elementDefinition);
                        break;
                    case ElementUsage elementUsage:
                        payload.ElementUsage.Add(elementUsage);
                        break;
                    case EmailAddress emailAddress:
                        payload.EmailAddress.Add(emailAddress);
                        break;
                    case EngineeringModel engineeringModel:
                        payload.EngineeringModel.Add(engineeringModel);
                        break;
                    case EngineeringModelSetup engineeringModelSetup:
                        payload.EngineeringModelSetup.Add(engineeringModelSetup);
                        break;
                    case EnumerationParameterType enumerationParameterType:
                        payload.EnumerationParameterType.Add(enumerationParameterType);
                        break;
                    case EnumerationValueDefinition enumerationValueDefinition:
                        payload.EnumerationValueDefinition.Add(enumerationValueDefinition);
                        break;
                    case ExclusiveOrExpression exclusiveOrExpression:
                        payload.ExclusiveOrExpression.Add(exclusiveOrExpression);
                        break;
                    case ExternalIdentifierMap externalIdentifierMap:
                        payload.ExternalIdentifierMap.Add(externalIdentifierMap);
                        break;
                    case File file:
                        payload.File.Add(file);
                        break;
                    case FileRevision fileRevision:
                        payload.FileRevision.Add(fileRevision);
                        break;
                    case FileType fileType:
                        payload.FileType.Add(fileType);
                        break;
                    case Folder folder:
                        payload.Folder.Add(folder);
                        break;
                    case Glossary glossary:
                        payload.Glossary.Add(glossary);
                        break;
                    case HyperLink hyperLink:
                        payload.HyperLink.Add(hyperLink);
                        break;
                    case IdCorrespondence idCorrespondence:
                        payload.IdCorrespondence.Add(idCorrespondence);
                        break;
                    case IntervalScale intervalScale:
                        payload.IntervalScale.Add(intervalScale);
                        break;
                    case Iteration iteration:
                        payload.Iteration.Add(iteration);
                        break;
                    case IterationSetup iterationSetup:
                        payload.IterationSetup.Add(iterationSetup);
                        break;
                    case LinearConversionUnit linearConversionUnit:
                        payload.LinearConversionUnit.Add(linearConversionUnit);
                        break;
                    case LogarithmicScale logarithmicScale:
                        payload.LogarithmicScale.Add(logarithmicScale);
                        break;
                    case MappingToReferenceScale mappingToReferenceScale:
                        payload.MappingToReferenceScale.Add(mappingToReferenceScale);
                        break;
                    case ModelLogEntry modelLogEntry:
                        payload.ModelLogEntry.Add(modelLogEntry);
                        break;
                    case ModelReferenceDataLibrary modelReferenceDataLibrary:
                        payload.ModelReferenceDataLibrary.Add(modelReferenceDataLibrary);
                        break;
                    case MultiRelationship multiRelationship:
                        payload.MultiRelationship.Add(multiRelationship);
                        break;
                    case MultiRelationshipRule multiRelationshipRule:
                        payload.MultiRelationshipRule.Add(multiRelationshipRule);
                        break;
                    case NaturalLanguage naturalLanguage:
                        payload.NaturalLanguage.Add(naturalLanguage);
                        break;
                    case NestedElement nestedElement:
                        payload.NestedElement.Add(nestedElement);
                        break;
                    case NestedParameter nestedParameter:
                        payload.NestedParameter.Add(nestedParameter);
                        break;
                    case NotExpression notExpression:
                        payload.NotExpression.Add(notExpression);
                        break;
                    case Option option:
                        payload.Option.Add(option);
                        break;
                    case OrdinalScale ordinalScale:
                        payload.OrdinalScale.Add(ordinalScale);
                        break;
                    case OrExpression orExpression:
                        payload.OrExpression.Add(orExpression);
                        break;
                    case Organization organization:
                        payload.Organization.Add(organization);
                        break;
                    case Parameter parameter:
                        payload.Parameter.Add(parameter);
                        break;
                    case ParameterGroup parameterGroup:
                        payload.ParameterGroup.Add(parameterGroup);
                        break;
                    case ParameterizedCategoryRule parameterizedCategoryRule:
                        payload.ParameterizedCategoryRule.Add(parameterizedCategoryRule);
                        break;
                    case ParameterOverride parameterOverride:
                        payload.ParameterOverride.Add(parameterOverride);
                        break;
                    case ParameterOverrideValueSet parameterOverrideValueSet:
                        payload.ParameterOverrideValueSet.Add(parameterOverrideValueSet);
                        break;
                    case ParameterSubscription parameterSubscription:
                        payload.ParameterSubscription.Add(parameterSubscription);
                        break;
                    case ParameterSubscriptionValueSet parameterSubscriptionValueSet:
                        payload.ParameterSubscriptionValueSet.Add(parameterSubscriptionValueSet);
                        break;
                    case ParameterTypeComponent parameterTypeComponent:
                        payload.ParameterTypeComponent.Add(parameterTypeComponent);
                        break;
                    case ParameterValueSet parameterValueSet:
                        payload.ParameterValueSet.Add(parameterValueSet);
                        break;
                    case ParametricConstraint parametricConstraint:
                        payload.ParametricConstraint.Add(parametricConstraint);
                        break;
                    case Participant participant:
                        payload.Participant.Add(participant);
                        break;
                    case ParticipantPermission participantPermission:
                        payload.ParticipantPermission.Add(participantPermission);
                        break;
                    case ParticipantRole participantRole:
                        payload.ParticipantRole.Add(participantRole);
                        break;
                    case Person person:
                        payload.Person.Add(person);
                        break;
                    case PersonPermission personPermission:
                        payload.PersonPermission.Add(personPermission);
                        break;
                    case PersonRole personRole:
                        payload.PersonRole.Add(personRole);
                        break;
                    case PossibleFiniteState possibleFiniteState:
                        payload.PossibleFiniteState.Add(possibleFiniteState);
                        break;
                    case PossibleFiniteStateList possibleFiniteStateList:
                        payload.PossibleFiniteStateList.Add(possibleFiniteStateList);
                        break;
                    case PrefixedUnit prefixedUnit:
                        payload.PrefixedUnit.Add(prefixedUnit);
                        break;
                    case Publication publication:
                        payload.Publication.Add(publication);
                        break;
                    case QuantityKindFactor quantityKindFactor:
                        payload.QuantityKindFactor.Add(quantityKindFactor);
                        break;
                    case RatioScale ratioScale:
                        payload.RatioScale.Add(ratioScale);
                        break;
                    case ReferencerRule referencerRule:
                        payload.ReferencerRule.Add(referencerRule);
                        break;
                    case ReferenceSource referenceSource:
                        payload.ReferenceSource.Add(referenceSource);
                        break;
                    case RelationalExpression relationalExpression:
                        payload.RelationalExpression.Add(relationalExpression);
                        break;
                    case Requirement requirement:
                        payload.Requirement.Add(requirement);
                        break;
                    case RequirementsGroup requirementsGroup:
                        payload.RequirementsGroup.Add(requirementsGroup);
                        break;
                    case RequirementsSpecification requirementsSpecification:
                        payload.RequirementsSpecification.Add(requirementsSpecification);
                        break;
                    case RuleVerificationList ruleVerificationList:
                        payload.RuleVerificationList.Add(ruleVerificationList);
                        break;
                    case RuleViolation ruleViolation:
                        payload.RuleViolation.Add(ruleViolation);
                        break;
                    case ScaleReferenceQuantityValue scaleReferenceQuantityValue:
                        payload.ScaleReferenceQuantityValue.Add(scaleReferenceQuantityValue);
                        break;
                    case ScaleValueDefinition scaleValueDefinition:
                        payload.ScaleValueDefinition.Add(scaleValueDefinition);
                        break;
                    case SimpleParameterValue simpleParameterValue:
                        payload.SimpleParameterValue.Add(simpleParameterValue);
                        break;
                    case SimpleQuantityKind simpleQuantityKind:
                        payload.SimpleQuantityKind.Add(simpleQuantityKind);
                        break;
                    case SimpleUnit simpleUnit:
                        payload.SimpleUnit.Add(simpleUnit);
                        break;
                    case SiteDirectory siteDirectory:
                        payload.SiteDirectory.Add(siteDirectory);
                        break;
                    case SiteLogEntry siteLogEntry:
                        payload.SiteLogEntry.Add(siteLogEntry);
                        break;
                    case SiteReferenceDataLibrary siteReferenceDataLibrary:
                        payload.SiteReferenceDataLibrary.Add(siteReferenceDataLibrary);
                        break;
                    case SpecializedQuantityKind specializedQuantityKind:
                        payload.SpecializedQuantityKind.Add(specializedQuantityKind);
                        break;
                    case TelephoneNumber telephoneNumber:
                        payload.TelephoneNumber.Add(telephoneNumber);
                        break;
                    case Term term:
                        payload.Term.Add(term);
                        break;
                    case TextParameterType textParameterType:
                        payload.TextParameterType.Add(textParameterType);
                        break;
                    case TimeOfDayParameterType timeOfDayParameterType:
                        payload.TimeOfDayParameterType.Add(timeOfDayParameterType);
                        break;
                    case UnitFactor unitFactor:
                        payload.UnitFactor.Add(unitFactor);
                        break;
                    case UnitPrefix unitPrefix:
                        payload.UnitPrefix.Add(unitPrefix);
                        break;
                    case UserPreference userPreference:
                        payload.UserPreference.Add(userPreference);
                        break;
                    case UserRuleVerification userRuleVerification:
                        payload.UserRuleVerification.Add(userRuleVerification);
                        break;
                    case ActionItem actionItem:
                        payload.ActionItem.Add(actionItem);
                        break;
                    case Approval approval:
                        payload.Approval.Add(approval);
                        break;
                    case BinaryNote binaryNote:
                        payload.BinaryNote.Add(binaryNote);
                        break;
                    case Book book:
                        payload.Book.Add(book);
                        break;
                    case Bounds bounds:
                        payload.Bounds.Add(bounds);
                        break;
                    case ChangeProposal changeProposal:
                        payload.ChangeProposal.Add(changeProposal);
                        break;
                    case ChangeRequest changeRequest:
                        payload.ChangeRequest.Add(changeRequest);
                        break;
                    case ContractChangeNotice contractChangeNotice:
                        payload.ContractChangeNotice.Add(contractChangeNotice);
                        break;
                    case DiagramCanvas diagramCanvas:
                        payload.DiagramCanvas.Add(diagramCanvas);
                        break;
                    case DiagramEdge diagramEdge:
                        payload.DiagramEdge.Add(diagramEdge);
                        break;
                    case DiagramObject diagramObject:
                        payload.DiagramObject.Add(diagramObject);
                        break;
                    case EngineeringModelDataDiscussionItem engineeringModelDataDiscussionItem:
                        payload.EngineeringModelDataDiscussionItem.Add(engineeringModelDataDiscussionItem);
                        break;
                    case EngineeringModelDataNote engineeringModelDataNote:
                        payload.EngineeringModelDataNote.Add(engineeringModelDataNote);
                        break;
                    case Goal goal:
                        payload.Goal.Add(goal);
                        break;
                    case ModellingThingReference modellingThingReference:
                        payload.ModellingThingReference.Add(modellingThingReference);
                        break;
                    case OwnedStyle ownedStyle:
                        payload.OwnedStyle.Add(ownedStyle);
                        break;
                    case Page page:
                        payload.Page.Add(page);
                        break;
                    case Point point:
                        payload.Point.Add(point);
                        break;
                    case RelationshipParameterValue relationshipParameterValue:
                        payload.RelationshipParameterValue.Add(relationshipParameterValue);
                        break;
                    case RequestForDeviation requestForDeviation:
                        payload.RequestForDeviation.Add(requestForDeviation);
                        break;
                    case RequestForWaiver requestForWaiver:
                        payload.RequestForWaiver.Add(requestForWaiver);
                        break;
                    case RequirementsContainerParameterValue requirementsContainerParameterValue:
                        payload.RequirementsContainerParameterValue.Add(requirementsContainerParameterValue);
                        break;
                    case ReviewItemDiscrepancy reviewItemDiscrepancy:
                        payload.ReviewItemDiscrepancy.Add(reviewItemDiscrepancy);
                        break;
                    case Section section:
                        payload.Section.Add(section);
                        break;
                    case SharedStyle sharedStyle:
                        payload.SharedStyle.Add(sharedStyle);
                        break;
                    case SiteDirectoryDataAnnotation siteDirectoryDataAnnotation:
                        payload.SiteDirectoryDataAnnotation.Add(siteDirectoryDataAnnotation);
                        break;
                    case SiteDirectoryDataDiscussionItem siteDirectoryDataDiscussionItem:
                        payload.SiteDirectoryDataDiscussionItem.Add(siteDirectoryDataDiscussionItem);
                        break;
                    case SiteDirectoryThingReference siteDirectoryThingReference:
                        payload.SiteDirectoryThingReference.Add(siteDirectoryThingReference);
                        break;
                    case Solution solution:
                        payload.Solution.Add(solution);
                        break;
                    case Stakeholder stakeholder:
                        payload.Stakeholder.Add(stakeholder);
                        break;
                    case StakeholderValue stakeholderValue:
                        payload.StakeholderValue.Add(stakeholderValue);
                        break;
                    case StakeHolderValueMap stakeHolderValueMap:
                        payload.StakeHolderValueMap.Add(stakeHolderValueMap);
                        break;
                    case StakeHolderValueMapSettings stakeHolderValueMapSettings:
                        payload.StakeHolderValueMapSettings.Add(stakeHolderValueMapSettings);
                        break;
                    case TextualNote textualNote:
                        payload.TextualNote.Add(textualNote);
                        break;
                    case ValueGroup valueGroup:
                        payload.ValueGroup.Add(valueGroup);
                        break;
                    case DependentParameterTypeAssignment dependentParameterTypeAssignment:
                        payload.DependentParameterTypeAssignment.Add(dependentParameterTypeAssignment);
                        break;
                    case IndependentParameterTypeAssignment independentParameterTypeAssignment:
                        payload.IndependentParameterTypeAssignment.Add(independentParameterTypeAssignment);
                        break;
                    case LogEntryChangelogItem logEntryChangelogItem:
                        payload.LogEntryChangelogItem.Add(logEntryChangelogItem);
                        break;
                    case OrganizationalParticipant organizationalParticipant:
                        payload.OrganizationalParticipant.Add(organizationalParticipant);
                        break;
                    case SampledFunctionParameterType sampledFunctionParameterType:
                        payload.SampledFunctionParameterType.Add(sampledFunctionParameterType);
                        break;
                }
            }

            return payload;
        }

        /// <summary>
        /// Creates an <see cref="IEnumerable{Thing}"/> from the provided <see cref="Payload"/>.
        /// </summary>
        /// <param name="payload">
        /// The <see cref="Payload"/> that carries the <see cref="Thing"/>s.
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{Thing}"/>.
        /// </returns>
        internal static IEnumerable<Thing> ToThings(this Payload payload)
        {
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            var result = new List<Thing>();

            result.AddRange(payload.ActualFiniteState);
            result.AddRange(payload.ActualFiniteStateList);
            result.AddRange(payload.Alias);
            result.AddRange(payload.AndExpression);
            result.AddRange(payload.ArrayParameterType);
            result.AddRange(payload.BinaryRelationship);
            result.AddRange(payload.BinaryRelationshipRule);
            result.AddRange(payload.BooleanParameterType);
            result.AddRange(payload.BuiltInRuleVerification);
            result.AddRange(payload.Category);
            result.AddRange(payload.Citation);
            result.AddRange(payload.Color);
            result.AddRange(payload.CommonFileStore);
            result.AddRange(payload.CompoundParameterType);
            result.AddRange(payload.Constant);
            result.AddRange(payload.CyclicRatioScale);
            result.AddRange(payload.DateParameterType);
            result.AddRange(payload.DateTimeParameterType);
            result.AddRange(payload.DecompositionRule);
            result.AddRange(payload.Definition);
            result.AddRange(payload.DerivedQuantityKind);
            result.AddRange(payload.DerivedUnit);
            result.AddRange(payload.DomainFileStore);
            result.AddRange(payload.DomainOfExpertise);
            result.AddRange(payload.DomainOfExpertiseGroup);
            result.AddRange(payload.ElementDefinition);
            result.AddRange(payload.ElementUsage);
            result.AddRange(payload.EmailAddress);
            result.AddRange(payload.EngineeringModel);
            result.AddRange(payload.EngineeringModelSetup);
            result.AddRange(payload.EnumerationParameterType);
            result.AddRange(payload.EnumerationValueDefinition);
            result.AddRange(payload.ExclusiveOrExpression);
            result.AddRange(payload.ExternalIdentifierMap);
            result.AddRange(payload.File);
            result.AddRange(payload.FileRevision);
            result.AddRange(payload.FileType);
            result.AddRange(payload.Folder);
            result.AddRange(payload.Glossary);
            result.AddRange(payload.HyperLink);
            result.AddRange(payload.IdCorrespondence);
            result.AddRange(payload.IntervalScale);
            result.AddRange(payload.Iteration);
            result.AddRange(payload.IterationSetup);
            result.AddRange(payload.LinearConversionUnit);
            result.AddRange(payload.LogarithmicScale);
            result.AddRange(payload.MappingToReferenceScale);
            result.AddRange(payload.ModelLogEntry);
            result.AddRange(payload.ModelReferenceDataLibrary);
            result.AddRange(payload.MultiRelationship);
            result.AddRange(payload.MultiRelationshipRule);
            result.AddRange(payload.NaturalLanguage);
            result.AddRange(payload.NestedElement);
            result.AddRange(payload.NestedParameter);
            result.AddRange(payload.NotExpression);
            result.AddRange(payload.Option);
            result.AddRange(payload.OrdinalScale);
            result.AddRange(payload.OrExpression);
            result.AddRange(payload.Organization);
            result.AddRange(payload.Parameter);
            result.AddRange(payload.ParameterGroup);
            result.AddRange(payload.ParameterizedCategoryRule);
            result.AddRange(payload.ParameterOverride);
            result.AddRange(payload.ParameterOverrideValueSet);
            result.AddRange(payload.ParameterSubscription);
            result.AddRange(payload.ParameterSubscriptionValueSet);
            result.AddRange(payload.ParameterTypeComponent);
            result.AddRange(payload.ParameterValueSet);
            result.AddRange(payload.ParametricConstraint);
            result.AddRange(payload.Participant);
            result.AddRange(payload.ParticipantPermission);
            result.AddRange(payload.ParticipantRole);
            result.AddRange(payload.Person);
            result.AddRange(payload.PersonPermission);
            result.AddRange(payload.PersonRole);
            result.AddRange(payload.PossibleFiniteState);
            result.AddRange(payload.PossibleFiniteStateList);
            result.AddRange(payload.PrefixedUnit);
            result.AddRange(payload.Publication);
            result.AddRange(payload.QuantityKindFactor);
            result.AddRange(payload.RatioScale);
            result.AddRange(payload.ReferencerRule);
            result.AddRange(payload.ReferenceSource);
            result.AddRange(payload.RelationalExpression);
            result.AddRange(payload.Requirement);
            result.AddRange(payload.RequirementsGroup);
            result.AddRange(payload.RequirementsSpecification);
            result.AddRange(payload.RuleVerificationList);
            result.AddRange(payload.RuleViolation);
            result.AddRange(payload.ScaleReferenceQuantityValue);
            result.AddRange(payload.ScaleValueDefinition);
            result.AddRange(payload.SimpleParameterValue);
            result.AddRange(payload.SimpleQuantityKind);
            result.AddRange(payload.SimpleUnit);
            result.AddRange(payload.SiteDirectory);
            result.AddRange(payload.SiteLogEntry);
            result.AddRange(payload.SiteReferenceDataLibrary);
            result.AddRange(payload.SpecializedQuantityKind);
            result.AddRange(payload.TelephoneNumber);
            result.AddRange(payload.Term);
            result.AddRange(payload.TextParameterType);
            result.AddRange(payload.TimeOfDayParameterType);
            result.AddRange(payload.UnitFactor);
            result.AddRange(payload.UnitPrefix);
            result.AddRange(payload.UserPreference);
            result.AddRange(payload.UserRuleVerification);
            result.AddRange(payload.ActionItem);
            result.AddRange(payload.Approval);
            result.AddRange(payload.BinaryNote);
            result.AddRange(payload.Book);
            result.AddRange(payload.Bounds);
            result.AddRange(payload.ChangeProposal);
            result.AddRange(payload.ChangeRequest);
            result.AddRange(payload.ContractChangeNotice);
            result.AddRange(payload.DiagramCanvas);
            result.AddRange(payload.DiagramEdge);
            result.AddRange(payload.DiagramObject);
            result.AddRange(payload.EngineeringModelDataDiscussionItem);
            result.AddRange(payload.EngineeringModelDataNote);
            result.AddRange(payload.Goal);
            result.AddRange(payload.ModellingThingReference);
            result.AddRange(payload.OwnedStyle);
            result.AddRange(payload.Page);
            result.AddRange(payload.Point);
            result.AddRange(payload.RelationshipParameterValue);
            result.AddRange(payload.RequestForDeviation);
            result.AddRange(payload.RequestForWaiver);
            result.AddRange(payload.RequirementsContainerParameterValue);
            result.AddRange(payload.ReviewItemDiscrepancy);
            result.AddRange(payload.Section);
            result.AddRange(payload.SharedStyle);
            result.AddRange(payload.SiteDirectoryDataAnnotation);
            result.AddRange(payload.SiteDirectoryDataDiscussionItem);
            result.AddRange(payload.SiteDirectoryThingReference);
            result.AddRange(payload.Solution);
            result.AddRange(payload.Stakeholder);
            result.AddRange(payload.StakeholderValue);
            result.AddRange(payload.StakeHolderValueMap);
            result.AddRange(payload.StakeHolderValueMapSettings);
            result.AddRange(payload.TextualNote);
            result.AddRange(payload.ValueGroup);
            result.AddRange(payload.DependentParameterTypeAssignment);
            result.AddRange(payload.IndependentParameterTypeAssignment);
            result.AddRange(payload.LogEntryChangelogItem);
            result.AddRange(payload.OrganizationalParticipant);
            result.AddRange(payload.SampledFunctionParameterType);

            return result;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
