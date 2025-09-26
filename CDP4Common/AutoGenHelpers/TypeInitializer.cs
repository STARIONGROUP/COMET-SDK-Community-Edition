// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeInitializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4Common.Helpers
{
    using System;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose of the <see cref="TypeInitializer" /> is to provide  <see cref="Thing" /> initialization based on a
    /// <see cref="ClassKind" />
    /// </summary>
    public static class TypeInitializer
    {
        /// <summary>
        /// Initialize a new instance of a <see cref="Thing" /> based on its <see cref="ClassKind" />
        /// </summary>
        /// <param name="classKind">The <see cref="ClassKind" /> that needs to be initialized</param>
        /// <returns>The initialized <see cref="Thing" /> based on the <see cref="ClassKind" /></returns>
        public static Thing Initialize(ClassKind classKind)
        {
            switch (classKind)
            {
                case ClassKind.ActionItem:
                    return new ActionItem();
                case ClassKind.ActualFiniteState:
                    return new ActualFiniteState();
                case ClassKind.ActualFiniteStateList:
                    return new ActualFiniteStateList();
                case ClassKind.Alias:
                    return new Alias();
                case ClassKind.AndExpression:
                    return new AndExpression();
                case ClassKind.Approval:
                    return new Approval();
                case ClassKind.ArrayParameterType:
                    return new ArrayParameterType();
                case ClassKind.BinaryNote:
                    return new BinaryNote();
                case ClassKind.BinaryRelationship:
                    return new BinaryRelationship();
                case ClassKind.BinaryRelationshipRule:
                    return new BinaryRelationshipRule();
                case ClassKind.Book:
                    return new Book();
                case ClassKind.BooleanExpression:
                    throw new ArgumentException("Cannot initialized an BooleanExpression since this type is abstract", nameof(classKind));
                case ClassKind.BooleanParameterType:
                    return new BooleanParameterType();
                case ClassKind.Bounds:
                    return new Bounds();
                case ClassKind.BuiltInRuleVerification:
                    return new BuiltInRuleVerification();
                case ClassKind.Category:
                    return new Category();
                case ClassKind.ChangeProposal:
                    return new ChangeProposal();
                case ClassKind.ChangeRequest:
                    return new ChangeRequest();
                case ClassKind.Citation:
                    return new Citation();
                case ClassKind.Color:
                    return new Color();
                case ClassKind.CommonFileStore:
                    return new CommonFileStore();
                case ClassKind.CompoundParameterType:
                    return new CompoundParameterType();
                case ClassKind.Constant:
                    return new Constant();
                case ClassKind.ContractChangeNotice:
                    return new ContractChangeNotice();
                case ClassKind.ContractDeviation:
                    throw new ArgumentException("Cannot initialized an ContractDeviation since this type is abstract", nameof(classKind));
                case ClassKind.ConversionBasedUnit:
                    throw new ArgumentException("Cannot initialized an ConversionBasedUnit since this type is abstract", nameof(classKind));
                case ClassKind.CyclicRatioScale:
                    return new CyclicRatioScale();
                case ClassKind.DateParameterType:
                    return new DateParameterType();
                case ClassKind.DateTimeParameterType:
                    return new DateTimeParameterType();
                case ClassKind.DecompositionRule:
                    return new DecompositionRule();
                case ClassKind.DefinedThing:
                    throw new ArgumentException("Cannot initialized an DefinedThing since this type is abstract", nameof(classKind));
                case ClassKind.Definition:
                    return new Definition();
                case ClassKind.DependentParameterTypeAssignment:
                    return new DependentParameterTypeAssignment();
                case ClassKind.DerivedQuantityKind:
                    return new DerivedQuantityKind();
                case ClassKind.DerivedUnit:
                    return new DerivedUnit();
                case ClassKind.DiagramCanvas:
                    return new DiagramCanvas();
                case ClassKind.DiagramEdge:
                    return new DiagramEdge();
                case ClassKind.DiagramElementContainer:
                    throw new ArgumentException("Cannot initialized an DiagramElementContainer since this type is abstract", nameof(classKind));
                case ClassKind.DiagramElementThing:
                    throw new ArgumentException("Cannot initialized an DiagramElementThing since this type is abstract", nameof(classKind));
                case ClassKind.DiagrammingStyle:
                    throw new ArgumentException("Cannot initialized an DiagrammingStyle since this type is abstract", nameof(classKind));
                case ClassKind.DiagramObject:
                    return new DiagramObject();
                case ClassKind.DiagramShape:
                    throw new ArgumentException("Cannot initialized an DiagramShape since this type is abstract", nameof(classKind));
                case ClassKind.DiagramThingBase:
                    throw new ArgumentException("Cannot initialized an DiagramThingBase since this type is abstract", nameof(classKind));
                case ClassKind.DiscussionItem:
                    throw new ArgumentException("Cannot initialized an DiscussionItem since this type is abstract", nameof(classKind));
                case ClassKind.DomainFileStore:
                    return new DomainFileStore();
                case ClassKind.DomainOfExpertise:
                    return new DomainOfExpertise();
                case ClassKind.DomainOfExpertiseGroup:
                    return new DomainOfExpertiseGroup();
                case ClassKind.ElementBase:
                    throw new ArgumentException("Cannot initialized an ElementBase since this type is abstract", nameof(classKind));
                case ClassKind.ElementDefinition:
                    return new ElementDefinition();
                case ClassKind.ElementUsage:
                    return new ElementUsage();
                case ClassKind.EmailAddress:
                    return new EmailAddress();
                case ClassKind.EngineeringModel:
                    return new EngineeringModel();
                case ClassKind.EngineeringModelDataAnnotation:
                    throw new ArgumentException("Cannot initialized an EngineeringModelDataAnnotation since this type is abstract", nameof(classKind));
                case ClassKind.EngineeringModelDataDiscussionItem:
                    return new EngineeringModelDataDiscussionItem();
                case ClassKind.EngineeringModelDataNote:
                    return new EngineeringModelDataNote();
                case ClassKind.EngineeringModelSetup:
                    return new EngineeringModelSetup();
                case ClassKind.EnumerationParameterType:
                    return new EnumerationParameterType();
                case ClassKind.EnumerationValueDefinition:
                    return new EnumerationValueDefinition();
                case ClassKind.ExclusiveOrExpression:
                    return new ExclusiveOrExpression();
                case ClassKind.ExternalIdentifierMap:
                    return new ExternalIdentifierMap();
                case ClassKind.File:
                    return new File();
                case ClassKind.FileRevision:
                    return new FileRevision();
                case ClassKind.FileStore:
                    throw new ArgumentException("Cannot initialized an FileStore since this type is abstract", nameof(classKind));
                case ClassKind.FileType:
                    return new FileType();
                case ClassKind.Folder:
                    return new Folder();
                case ClassKind.GenericAnnotation:
                    throw new ArgumentException("Cannot initialized an GenericAnnotation since this type is abstract", nameof(classKind));
                case ClassKind.Glossary:
                    return new Glossary();
                case ClassKind.Goal:
                    return new Goal();
                case ClassKind.HyperLink:
                    return new HyperLink();
                case ClassKind.IdCorrespondence:
                    return new IdCorrespondence();
                case ClassKind.IndependentParameterTypeAssignment:
                    return new IndependentParameterTypeAssignment();
                case ClassKind.IntervalScale:
                    return new IntervalScale();
                case ClassKind.Iteration:
                    return new Iteration();
                case ClassKind.IterationSetup:
                    return new IterationSetup();
                case ClassKind.LinearConversionUnit:
                    return new LinearConversionUnit();
                case ClassKind.LogarithmicScale:
                    return new LogarithmicScale();
                case ClassKind.LogEntryChangelogItem:
                    return new LogEntryChangelogItem();
                case ClassKind.MappingToReferenceScale:
                    return new MappingToReferenceScale();
                case ClassKind.MeasurementScale:
                    throw new ArgumentException("Cannot initialized an MeasurementScale since this type is abstract", nameof(classKind));
                case ClassKind.MeasurementUnit:
                    throw new ArgumentException("Cannot initialized an MeasurementUnit since this type is abstract", nameof(classKind));
                case ClassKind.ModellingAnnotationItem:
                    throw new ArgumentException("Cannot initialized an ModellingAnnotationItem since this type is abstract", nameof(classKind));
                case ClassKind.ModellingThingReference:
                    return new ModellingThingReference();
                case ClassKind.ModelLogEntry:
                    return new ModelLogEntry();
                case ClassKind.ModelReferenceDataLibrary:
                    return new ModelReferenceDataLibrary();
                case ClassKind.MultiRelationship:
                    return new MultiRelationship();
                case ClassKind.MultiRelationshipRule:
                    return new MultiRelationshipRule();
                case ClassKind.NaturalLanguage:
                    return new NaturalLanguage();
                case ClassKind.NestedElement:
                    return new NestedElement();
                case ClassKind.NestedParameter:
                    return new NestedParameter();
                case ClassKind.Note:
                    throw new ArgumentException("Cannot initialized an Note since this type is abstract", nameof(classKind));
                case ClassKind.NotExpression:
                    return new NotExpression();
                case ClassKind.NotThing:
                    throw new ArgumentException("Cannot initialized an NotThing since this type is abstract", nameof(classKind));
                case ClassKind.Option:
                    return new Option();
                case ClassKind.OrdinalScale:
                    return new OrdinalScale();
                case ClassKind.OrExpression:
                    return new OrExpression();
                case ClassKind.Organization:
                    return new Organization();
                case ClassKind.OrganizationalParticipant:
                    return new OrganizationalParticipant();
                case ClassKind.OwnedStyle:
                    return new OwnedStyle();
                case ClassKind.Page:
                    return new Page();
                case ClassKind.Parameter:
                    return new Parameter();
                case ClassKind.ParameterBase:
                    throw new ArgumentException("Cannot initialized an ParameterBase since this type is abstract", nameof(classKind));
                case ClassKind.ParameterGroup:
                    return new ParameterGroup();
                case ClassKind.ParameterizedCategoryRule:
                    return new ParameterizedCategoryRule();
                case ClassKind.ParameterOrOverrideBase:
                    throw new ArgumentException("Cannot initialized an ParameterOrOverrideBase since this type is abstract", nameof(classKind));
                case ClassKind.ParameterOverride:
                    return new ParameterOverride();
                case ClassKind.ParameterOverrideValueSet:
                    return new ParameterOverrideValueSet();
                case ClassKind.ParameterSubscription:
                    return new ParameterSubscription();
                case ClassKind.ParameterSubscriptionValueSet:
                    return new ParameterSubscriptionValueSet();
                case ClassKind.ParameterType:
                    throw new ArgumentException("Cannot initialized an ParameterType since this type is abstract", nameof(classKind));
                case ClassKind.ParameterTypeComponent:
                    return new ParameterTypeComponent();
                case ClassKind.ParameterValue:
                    throw new ArgumentException("Cannot initialized an ParameterValue since this type is abstract", nameof(classKind));
                case ClassKind.ParameterValueSet:
                    return new ParameterValueSet();
                case ClassKind.ParameterValueSetBase:
                    throw new ArgumentException("Cannot initialized an ParameterValueSetBase since this type is abstract", nameof(classKind));
                case ClassKind.ParametricConstraint:
                    return new ParametricConstraint();
                case ClassKind.Participant:
                    return new Participant();
                case ClassKind.ParticipantPermission:
                    return new ParticipantPermission();
                case ClassKind.ParticipantRole:
                    return new ParticipantRole();
                case ClassKind.Person:
                    return new Person();
                case ClassKind.PersonPermission:
                    return new PersonPermission();
                case ClassKind.PersonRole:
                    return new PersonRole();
                case ClassKind.Point:
                    return new Point();
                case ClassKind.PossibleFiniteState:
                    return new PossibleFiniteState();
                case ClassKind.PossibleFiniteStateList:
                    return new PossibleFiniteStateList();
                case ClassKind.PrefixedUnit:
                    return new PrefixedUnit();
                case ClassKind.Publication:
                    return new Publication();
                case ClassKind.QuantityKind:
                    throw new ArgumentException("Cannot initialized an QuantityKind since this type is abstract", nameof(classKind));
                case ClassKind.QuantityKindFactor:
                    return new QuantityKindFactor();
                case ClassKind.RatioScale:
                    return new RatioScale();
                case ClassKind.ReferenceDataLibrary:
                    throw new ArgumentException("Cannot initialized an ReferenceDataLibrary since this type is abstract", nameof(classKind));
                case ClassKind.ReferencerRule:
                    return new ReferencerRule();
                case ClassKind.ReferenceSource:
                    return new ReferenceSource();
                case ClassKind.RelationalExpression:
                    return new RelationalExpression();
                case ClassKind.Relationship:
                    throw new ArgumentException("Cannot initialized an Relationship since this type is abstract", nameof(classKind));
                case ClassKind.RelationshipParameterValue:
                    return new RelationshipParameterValue();
                case ClassKind.RequestForDeviation:
                    return new RequestForDeviation();
                case ClassKind.RequestForWaiver:
                    return new RequestForWaiver();
                case ClassKind.Requirement:
                    return new Requirement();
                case ClassKind.RequirementsContainer:
                    throw new ArgumentException("Cannot initialized an RequirementsContainer since this type is abstract", nameof(classKind));
                case ClassKind.RequirementsContainerParameterValue:
                    return new RequirementsContainerParameterValue();
                case ClassKind.RequirementsGroup:
                    return new RequirementsGroup();
                case ClassKind.RequirementsSpecification:
                    return new RequirementsSpecification();
                case ClassKind.ReviewItemDiscrepancy:
                    return new ReviewItemDiscrepancy();
                case ClassKind.Rule:
                    throw new ArgumentException("Cannot initialized an Rule since this type is abstract", nameof(classKind));
                case ClassKind.RuleVerification:
                    throw new ArgumentException("Cannot initialized an RuleVerification since this type is abstract", nameof(classKind));
                case ClassKind.RuleVerificationList:
                    return new RuleVerificationList();
                case ClassKind.RuleViolation:
                    return new RuleViolation();
                case ClassKind.SampledFunctionParameterType:
                    return new SampledFunctionParameterType();
                case ClassKind.ScalarParameterType:
                    throw new ArgumentException("Cannot initialized an ScalarParameterType since this type is abstract", nameof(classKind));
                case ClassKind.ScaleReferenceQuantityValue:
                    return new ScaleReferenceQuantityValue();
                case ClassKind.ScaleValueDefinition:
                    return new ScaleValueDefinition();
                case ClassKind.Section:
                    return new Section();
                case ClassKind.SharedStyle:
                    return new SharedStyle();
                case ClassKind.SimpleParameterizableThing:
                    throw new ArgumentException("Cannot initialized an SimpleParameterizableThing since this type is abstract", nameof(classKind));
                case ClassKind.SimpleParameterValue:
                    return new SimpleParameterValue();
                case ClassKind.SimpleQuantityKind:
                    return new SimpleQuantityKind();
                case ClassKind.SimpleUnit:
                    return new SimpleUnit();
                case ClassKind.SiteDirectory:
                    return new SiteDirectory();
                case ClassKind.SiteDirectoryDataAnnotation:
                    return new SiteDirectoryDataAnnotation();
                case ClassKind.SiteDirectoryDataDiscussionItem:
                    return new SiteDirectoryDataDiscussionItem();
                case ClassKind.SiteDirectoryThingReference:
                    return new SiteDirectoryThingReference();
                case ClassKind.SiteLogEntry:
                    return new SiteLogEntry();
                case ClassKind.SiteReferenceDataLibrary:
                    return new SiteReferenceDataLibrary();
                case ClassKind.Solution:
                    return new Solution();
                case ClassKind.SpecializedQuantityKind:
                    return new SpecializedQuantityKind();
                case ClassKind.Stakeholder:
                    return new Stakeholder();
                case ClassKind.StakeholderValue:
                    return new StakeholderValue();
                case ClassKind.StakeHolderValueMap:
                    return new StakeHolderValueMap();
                case ClassKind.StakeHolderValueMapSettings:
                    return new StakeHolderValueMapSettings();
                case ClassKind.TelephoneNumber:
                    return new TelephoneNumber();
                case ClassKind.Term:
                    return new Term();
                case ClassKind.TextParameterType:
                    return new TextParameterType();
                case ClassKind.TextualNote:
                    return new TextualNote();
                case ClassKind.Thing:
                    throw new ArgumentException("Cannot initialized an Thing since this type is abstract", nameof(classKind));
                case ClassKind.ThingReference:
                    throw new ArgumentException("Cannot initialized an ThingReference since this type is abstract", nameof(classKind));
                case ClassKind.TimeOfDayParameterType:
                    return new TimeOfDayParameterType();
                case ClassKind.TopContainer:
                    throw new ArgumentException("Cannot initialized an TopContainer since this type is abstract", nameof(classKind));
                case ClassKind.UnitFactor:
                    return new UnitFactor();
                case ClassKind.UnitPrefix:
                    return new UnitPrefix();
                case ClassKind.UserPreference:
                    return new UserPreference();
                case ClassKind.UserRuleVerification:
                    return new UserRuleVerification();
                case ClassKind.ValueGroup:
                    return new ValueGroup();
                default:
                    throw new ArgumentOutOfRangeException(nameof(classKind), classKind, "Unrecognized ClassKind value");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
