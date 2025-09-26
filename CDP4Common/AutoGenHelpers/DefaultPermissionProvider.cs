// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultPermissionProvider.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;
#if NETFRAMEWORK
    using System.ComponentModel.Composition;
#endif
    using CDP4Common.CommonData;

    /// <summary>
    /// A utility class that supplies common functionalities to the Service layer.
    /// </summary>
#if NETFRAMEWORK
    [Export(typeof(IDefaultPermissionProvider))]
    [PartCreationPolicy(CreationPolicy.Shared)]
#endif
    public class DefaultPermissionProvider : IDefaultPermissionProvider
    {
        /// <summary>
        /// The ClassKind to default participant permission map.
        /// </summary>
        private readonly Dictionary<ClassKind, ParticipantAccessRightKind> classKindParticipantPermissionMap = new Dictionary<ClassKind, ParticipantAccessRightKind>
        {
            { ClassKind.ActionItem, ParticipantAccessRightKind.NONE },
            { ClassKind.ActualFiniteState, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ActualFiniteStateList, ParticipantAccessRightKind.NONE },
            { ClassKind.Alias, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.AndExpression, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Approval, ParticipantAccessRightKind.NONE },
            { ClassKind.ArrayParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.BinaryNote, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.BinaryRelationship, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.BinaryRelationshipRule, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Book, ParticipantAccessRightKind.NONE },
            { ClassKind.BooleanExpression, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.BooleanParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Bounds, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.BuiltInRuleVerification, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Category, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ChangeProposal, ParticipantAccessRightKind.NONE },
            { ClassKind.ChangeRequest, ParticipantAccessRightKind.NONE },
            { ClassKind.Citation, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Color, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.CommonFileStore, ParticipantAccessRightKind.NONE },
            { ClassKind.CompoundParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Constant, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ContractChangeNotice, ParticipantAccessRightKind.NONE },
            { ClassKind.ContractDeviation, ParticipantAccessRightKind.NONE },
            { ClassKind.ConversionBasedUnit, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.CyclicRatioScale, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DateParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DateTimeParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DecompositionRule, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DefinedThing, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Definition, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.DependentParameterTypeAssignment, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.DerivedQuantityKind, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DerivedUnit, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DiagramCanvas, ParticipantAccessRightKind.NONE },
            { ClassKind.DiagramEdge, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DiagramElementContainer, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagramElementThing, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.DiagrammingStyle, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagramObject, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DiagramShape, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DiagramThingBase, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiscussionItem, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DomainFileStore, ParticipantAccessRightKind.NONE },
            { ClassKind.DomainOfExpertise, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DomainOfExpertiseGroup, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ElementBase, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ElementDefinition, ParticipantAccessRightKind.NONE },
            { ClassKind.ElementUsage, ParticipantAccessRightKind.NONE },
            { ClassKind.EmailAddress, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.EngineeringModel, ParticipantAccessRightKind.NONE },
            { ClassKind.EngineeringModelDataAnnotation, ParticipantAccessRightKind.NONE },
            { ClassKind.EngineeringModelDataDiscussionItem, ParticipantAccessRightKind.NONE },
            { ClassKind.EngineeringModelDataNote, ParticipantAccessRightKind.NONE },
            { ClassKind.EngineeringModelSetup, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.EnumerationParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.EnumerationValueDefinition, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ExclusiveOrExpression, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ExternalIdentifierMap, ParticipantAccessRightKind.NONE },
            { ClassKind.File, ParticipantAccessRightKind.NONE },
            { ClassKind.FileRevision, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.FileStore, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.FileType, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Folder, ParticipantAccessRightKind.NONE },
            { ClassKind.GenericAnnotation, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Glossary, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Goal, ParticipantAccessRightKind.NONE },
            { ClassKind.HyperLink, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.IdCorrespondence, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.IndependentParameterTypeAssignment, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.IntervalScale, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Iteration, ParticipantAccessRightKind.NONE },
            { ClassKind.IterationSetup, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.LinearConversionUnit, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.LogarithmicScale, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.LogEntryChangelogItem, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.MappingToReferenceScale, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.MeasurementScale, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.MeasurementUnit, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ModellingAnnotationItem, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ModellingThingReference, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ModelLogEntry, ParticipantAccessRightKind.NONE },
            { ClassKind.ModelReferenceDataLibrary, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.MultiRelationship, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.MultiRelationshipRule, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.NaturalLanguage, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.NestedElement, ParticipantAccessRightKind.NONE },
            { ClassKind.NestedParameter, ParticipantAccessRightKind.NONE },
            { ClassKind.Note, ParticipantAccessRightKind.NONE },
            { ClassKind.NotExpression, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Option, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.OrdinalScale, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.OrExpression, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Organization, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.OrganizationalParticipant, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.OwnedStyle, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Page, ParticipantAccessRightKind.NONE },
            { ClassKind.Parameter, ParticipantAccessRightKind.NONE },
            { ClassKind.ParameterBase, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterGroup, ParticipantAccessRightKind.NONE },
            { ClassKind.ParameterizedCategoryRule, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ParameterOrOverrideBase, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterOverride, ParticipantAccessRightKind.NONE },
            { ClassKind.ParameterOverrideValueSet, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ParameterSubscription, ParticipantAccessRightKind.NONE },
            { ClassKind.ParameterSubscriptionValueSet, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ParameterType, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ParameterTypeComponent, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ParameterValue, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterValueSet, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ParameterValueSetBase, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParametricConstraint, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Participant, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParticipantPermission, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParticipantRole, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Person, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.PersonPermission, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.PersonRole, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Point, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.PossibleFiniteState, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.PossibleFiniteStateList, ParticipantAccessRightKind.NONE },
            { ClassKind.PrefixedUnit, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Publication, ParticipantAccessRightKind.NONE },
            { ClassKind.QuantityKind, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.QuantityKindFactor, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RatioScale, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ReferenceDataLibrary, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ReferencerRule, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ReferenceSource, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RelationalExpression, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Relationship, ParticipantAccessRightKind.NONE },
            { ClassKind.RelationshipParameterValue, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RequestForDeviation, ParticipantAccessRightKind.NONE },
            { ClassKind.RequestForWaiver, ParticipantAccessRightKind.NONE },
            { ClassKind.Requirement, ParticipantAccessRightKind.NONE },
            { ClassKind.RequirementsContainer, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RequirementsContainerParameterValue, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RequirementsGroup, ParticipantAccessRightKind.NONE },
            { ClassKind.RequirementsSpecification, ParticipantAccessRightKind.NONE },
            { ClassKind.ReviewItemDiscrepancy, ParticipantAccessRightKind.NONE },
            { ClassKind.Rule, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RuleVerification, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RuleVerificationList, ParticipantAccessRightKind.NONE },
            { ClassKind.RuleViolation, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.SampledFunctionParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ScalarParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ScaleReferenceQuantityValue, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ScaleValueDefinition, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Section, ParticipantAccessRightKind.NONE },
            { ClassKind.SharedStyle, ParticipantAccessRightKind.NONE },
            { ClassKind.SimpleParameterizableThing, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SimpleParameterValue, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.SimpleQuantityKind, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.SimpleUnit, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.SiteDirectory, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SiteDirectoryDataAnnotation, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SiteDirectoryDataDiscussionItem, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SiteDirectoryThingReference, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SiteLogEntry, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SiteReferenceDataLibrary, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Solution, ParticipantAccessRightKind.NONE },
            { ClassKind.SpecializedQuantityKind, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Stakeholder, ParticipantAccessRightKind.NONE },
            { ClassKind.StakeholderValue, ParticipantAccessRightKind.NONE },
            { ClassKind.StakeHolderValueMap, ParticipantAccessRightKind.NONE },
            { ClassKind.StakeHolderValueMapSettings, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.TelephoneNumber, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Term, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.TextParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.TextualNote, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Thing, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ThingReference, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.TimeOfDayParameterType, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.TopContainer, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.UnitFactor, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.UnitPrefix, ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.UserPreference, ParticipantAccessRightKind.NOT_APPLICABLE },
            { ClassKind.UserRuleVerification, ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ValueGroup, ParticipantAccessRightKind.NONE },
            { ClassKind.NotThing, ParticipantAccessRightKind.NOT_APPLICABLE }
        };

        /// <summary>
        /// The type to default participant permission map.
        /// </summary>
        private readonly Dictionary<string, ParticipantAccessRightKind> typeNameParticipantPermissionMap = new Dictionary<string, ParticipantAccessRightKind>
        {
            { "ActionItem", ParticipantAccessRightKind.NONE },
            { "ActualFiniteState", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ActualFiniteStateList", ParticipantAccessRightKind.NONE },
            { "Alias", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "AndExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Approval", ParticipantAccessRightKind.NONE },
            { "ArrayParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "BinaryNote", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "BinaryRelationship", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "BinaryRelationshipRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Book", ParticipantAccessRightKind.NONE },
            { "BooleanExpression", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "BooleanParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Bounds", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "BuiltInRuleVerification", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Category", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ChangeProposal", ParticipantAccessRightKind.NONE },
            { "ChangeRequest", ParticipantAccessRightKind.NONE },
            { "Citation", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Color", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "CommonFileStore", ParticipantAccessRightKind.NONE },
            { "CompoundParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Constant", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ContractChangeNotice", ParticipantAccessRightKind.NONE },
            { "ContractDeviation", ParticipantAccessRightKind.NONE },
            { "ConversionBasedUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "CyclicRatioScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DateParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DateTimeParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DecompositionRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DefinedThing", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Definition", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "DependentParameterTypeAssignment", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "DerivedQuantityKind", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DerivedUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramCanvas", ParticipantAccessRightKind.NONE },
            { "DiagramEdge", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramElementContainer", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DiagramElementThing", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "DiagrammingStyle", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DiagramObject", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramShape", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramThingBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DiscussionItem", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DomainFileStore", ParticipantAccessRightKind.NONE },
            { "DomainOfExpertise", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "DomainOfExpertiseGroup", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ElementBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ElementDefinition", ParticipantAccessRightKind.NONE },
            { "ElementUsage", ParticipantAccessRightKind.NONE },
            { "EmailAddress", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModel", ParticipantAccessRightKind.NONE },
            { "EngineeringModelDataAnnotation", ParticipantAccessRightKind.NONE },
            { "EngineeringModelDataDiscussionItem", ParticipantAccessRightKind.NONE },
            { "EngineeringModelDataNote", ParticipantAccessRightKind.NONE },
            { "EngineeringModelSetup", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "EnumerationParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "EnumerationValueDefinition", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ExclusiveOrExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ExternalIdentifierMap", ParticipantAccessRightKind.NONE },
            { "File", ParticipantAccessRightKind.NONE },
            { "FileRevision", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "FileStore", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "FileType", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Folder", ParticipantAccessRightKind.NONE },
            { "GenericAnnotation", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Glossary", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Goal", ParticipantAccessRightKind.NONE },
            { "HyperLink", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "IdCorrespondence", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "IndependentParameterTypeAssignment", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "IntervalScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Iteration", ParticipantAccessRightKind.NONE },
            { "IterationSetup", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "LinearConversionUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "LogarithmicScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "LogEntryChangelogItem", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "MappingToReferenceScale", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "MeasurementScale", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "MeasurementUnit", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ModellingAnnotationItem", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ModellingThingReference", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ModelLogEntry", ParticipantAccessRightKind.NONE },
            { "ModelReferenceDataLibrary", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "MultiRelationship", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "MultiRelationshipRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "NaturalLanguage", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "NestedElement", ParticipantAccessRightKind.NONE },
            { "NestedParameter", ParticipantAccessRightKind.NONE },
            { "Note", ParticipantAccessRightKind.NONE },
            { "NotExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Option", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "OrdinalScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "OrExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Organization", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "OrganizationalParticipant", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "OwnedStyle", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Page", ParticipantAccessRightKind.NONE },
            { "Parameter", ParticipantAccessRightKind.NONE },
            { "ParameterBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParameterGroup", ParticipantAccessRightKind.NONE },
            { "ParameterizedCategoryRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ParameterOrOverrideBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParameterOverride", ParticipantAccessRightKind.NONE },
            { "ParameterOverrideValueSet", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterSubscription", ParticipantAccessRightKind.NONE },
            { "ParameterSubscriptionValueSet", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterType", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterTypeComponent", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterValue", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParameterValueSet", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterValueSetBase", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParametricConstraint", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Participant", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParticipantPermission", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ParticipantRole", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Person", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "PersonPermission", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "PersonRole", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Point", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "PossibleFiniteState", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "PossibleFiniteStateList", ParticipantAccessRightKind.NONE },
            { "PrefixedUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Publication", ParticipantAccessRightKind.NONE },
            { "QuantityKind", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "QuantityKindFactor", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RatioScale", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ReferenceDataLibrary", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ReferencerRule", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ReferenceSource", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RelationalExpression", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Relationship", ParticipantAccessRightKind.NONE },
            { "RelationshipParameterValue", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RequestForDeviation", ParticipantAccessRightKind.NONE },
            { "RequestForWaiver", ParticipantAccessRightKind.NONE },
            { "Requirement", ParticipantAccessRightKind.NONE },
            { "RequirementsContainer", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "RequirementsContainerParameterValue", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RequirementsGroup", ParticipantAccessRightKind.NONE },
            { "RequirementsSpecification", ParticipantAccessRightKind.NONE },
            { "ReviewItemDiscrepancy", ParticipantAccessRightKind.NONE },
            { "Rule", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RuleVerification", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "RuleVerificationList", ParticipantAccessRightKind.NONE },
            { "RuleViolation", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "SampledFunctionParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ScalarParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ScaleReferenceQuantityValue", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "ScaleValueDefinition", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "Section", ParticipantAccessRightKind.NONE },
            { "SharedStyle", ParticipantAccessRightKind.NONE },
            { "SimpleParameterizableThing", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SimpleParameterValue", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "SimpleQuantityKind", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "SimpleUnit", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "SiteDirectory", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteDirectoryDataAnnotation", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteDirectoryDataDiscussionItem", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteDirectoryThingReference", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteLogEntry", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "SiteReferenceDataLibrary", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Solution", ParticipantAccessRightKind.NONE },
            { "SpecializedQuantityKind", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Stakeholder", ParticipantAccessRightKind.NONE },
            { "StakeholderValue", ParticipantAccessRightKind.NONE },
            { "StakeHolderValueMap", ParticipantAccessRightKind.NONE },
            { "StakeHolderValueMapSettings", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "TelephoneNumber", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "Term", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "TextParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "TextualNote", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "Thing", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "ThingReference", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "TimeOfDayParameterType", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "TopContainer", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "UnitFactor", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "UnitPrefix", ParticipantAccessRightKind.SAME_AS_CONTAINER },
            { "UserPreference", ParticipantAccessRightKind.NOT_APPLICABLE },
            { "UserRuleVerification", ParticipantAccessRightKind.SAME_AS_SUPERCLASS },
            { "ValueGroup", ParticipantAccessRightKind.NONE },
            { "NotThing", ParticipantAccessRightKind.NOT_APPLICABLE }
        };

        /// <summary>
        /// The ClassKind to default person permission map.
        /// </summary>
        private readonly Dictionary<ClassKind, PersonAccessRightKind> classKindPersonPermissionMap = new Dictionary<ClassKind, PersonAccessRightKind>
        {
            { ClassKind.ActionItem, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ActualFiniteState, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ActualFiniteStateList, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Alias, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.AndExpression, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Approval, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ArrayParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.BinaryNote, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.BinaryRelationship, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.BinaryRelationshipRule, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Book, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.BooleanExpression, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.BooleanParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Bounds, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.BuiltInRuleVerification, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Category, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ChangeProposal, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ChangeRequest, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Citation, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Color, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.CommonFileStore, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.CompoundParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Constant, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ContractChangeNotice, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ContractDeviation, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ConversionBasedUnit, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.CyclicRatioScale, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DateParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DateTimeParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DecompositionRule, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DefinedThing, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Definition, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.DependentParameterTypeAssignment, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.DerivedQuantityKind, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DerivedUnit, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.DiagramCanvas, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagramEdge, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagramElementContainer, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagramElementThing, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagrammingStyle, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagramObject, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagramShape, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiagramThingBase, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DiscussionItem, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DomainFileStore, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.DomainOfExpertise, PersonAccessRightKind.NONE },
            { ClassKind.DomainOfExpertiseGroup, PersonAccessRightKind.NONE },
            { ClassKind.ElementBase, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ElementDefinition, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ElementUsage, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.EmailAddress, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.EngineeringModel, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.EngineeringModelDataAnnotation, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.EngineeringModelDataDiscussionItem, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.EngineeringModelDataNote, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.EngineeringModelSetup, PersonAccessRightKind.NONE },
            { ClassKind.EnumerationParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.EnumerationValueDefinition, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ExclusiveOrExpression, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ExternalIdentifierMap, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.File, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.FileRevision, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.FileStore, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.FileType, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Folder, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.GenericAnnotation, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Glossary, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Goal, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.HyperLink, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.IdCorrespondence, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.IndependentParameterTypeAssignment, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.IntervalScale, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Iteration, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.IterationSetup, PersonAccessRightKind.NONE },
            { ClassKind.LinearConversionUnit, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.LogarithmicScale, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.LogEntryChangelogItem, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.MappingToReferenceScale, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.MeasurementScale, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.MeasurementUnit, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ModellingAnnotationItem, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ModellingThingReference, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ModelLogEntry, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ModelReferenceDataLibrary, PersonAccessRightKind.NONE },
            { ClassKind.MultiRelationship, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.MultiRelationshipRule, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.NaturalLanguage, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.NestedElement, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.NestedParameter, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Note, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.NotExpression, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Option, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.OrdinalScale, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.OrExpression, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Organization, PersonAccessRightKind.NONE },
            { ClassKind.OrganizationalParticipant, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.OwnedStyle, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Page, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Parameter, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterBase, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterGroup, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterizedCategoryRule, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ParameterOrOverrideBase, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterOverride, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterOverrideValueSet, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterSubscription, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterSubscriptionValueSet, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterType, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ParameterTypeComponent, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ParameterValue, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterValueSet, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParameterValueSetBase, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ParametricConstraint, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Participant, PersonAccessRightKind.NONE },
            { ClassKind.ParticipantPermission, PersonAccessRightKind.NONE },
            { ClassKind.ParticipantRole, PersonAccessRightKind.NONE },
            { ClassKind.Person, PersonAccessRightKind.NONE },
            { ClassKind.PersonPermission, PersonAccessRightKind.NONE },
            { ClassKind.PersonRole, PersonAccessRightKind.NONE },
            { ClassKind.Point, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.PossibleFiniteState, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.PossibleFiniteStateList, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.PrefixedUnit, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Publication, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.QuantityKind, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.QuantityKindFactor, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RatioScale, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ReferenceDataLibrary, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ReferencerRule, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ReferenceSource, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RelationalExpression, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Relationship, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RelationshipParameterValue, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RequestForDeviation, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RequestForWaiver, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Requirement, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RequirementsContainer, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RequirementsContainerParameterValue, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RequirementsGroup, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RequirementsSpecification, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ReviewItemDiscrepancy, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Rule, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.RuleVerification, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RuleVerificationList, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.RuleViolation, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SampledFunctionParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ScalarParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.ScaleReferenceQuantityValue, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.ScaleValueDefinition, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Section, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SharedStyle, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SimpleParameterizableThing, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SimpleParameterValue, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SimpleQuantityKind, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.SimpleUnit, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.SiteDirectory, PersonAccessRightKind.NONE },
            { ClassKind.SiteDirectoryDataAnnotation, PersonAccessRightKind.NONE },
            { ClassKind.SiteDirectoryDataDiscussionItem, PersonAccessRightKind.NONE },
            { ClassKind.SiteDirectoryThingReference, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.SiteLogEntry, PersonAccessRightKind.NONE },
            { ClassKind.SiteReferenceDataLibrary, PersonAccessRightKind.NONE },
            { ClassKind.Solution, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.SpecializedQuantityKind, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.Stakeholder, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.StakeholderValue, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.StakeHolderValueMap, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.StakeHolderValueMapSettings, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.TelephoneNumber, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.Term, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.TextParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.TextualNote, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.Thing, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ThingReference, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.TimeOfDayParameterType, PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { ClassKind.TopContainer, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.UnitFactor, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.UnitPrefix, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.UserPreference, PersonAccessRightKind.SAME_AS_CONTAINER },
            { ClassKind.UserRuleVerification, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.ValueGroup, PersonAccessRightKind.NOT_APPLICABLE },
            { ClassKind.NotThing, PersonAccessRightKind.NOT_APPLICABLE }
        };

        /// <summary>
        /// The type to default person permission map.
        /// </summary>
        private readonly Dictionary<string, PersonAccessRightKind> typeNamePersonPermissionMap = new Dictionary<string, PersonAccessRightKind>
        {
            { "ActionItem", PersonAccessRightKind.NOT_APPLICABLE },
            { "ActualFiniteState", PersonAccessRightKind.NOT_APPLICABLE },
            { "ActualFiniteStateList", PersonAccessRightKind.NOT_APPLICABLE },
            { "Alias", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "AndExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "Approval", PersonAccessRightKind.NOT_APPLICABLE },
            { "ArrayParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "BinaryNote", PersonAccessRightKind.NOT_APPLICABLE },
            { "BinaryRelationship", PersonAccessRightKind.NOT_APPLICABLE },
            { "BinaryRelationshipRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Book", PersonAccessRightKind.NOT_APPLICABLE },
            { "BooleanExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "BooleanParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Bounds", PersonAccessRightKind.NOT_APPLICABLE },
            { "BuiltInRuleVerification", PersonAccessRightKind.NOT_APPLICABLE },
            { "Category", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ChangeProposal", PersonAccessRightKind.NOT_APPLICABLE },
            { "ChangeRequest", PersonAccessRightKind.NOT_APPLICABLE },
            { "Citation", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Color", PersonAccessRightKind.NOT_APPLICABLE },
            { "CommonFileStore", PersonAccessRightKind.NOT_APPLICABLE },
            { "CompoundParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Constant", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ContractChangeNotice", PersonAccessRightKind.NOT_APPLICABLE },
            { "ContractDeviation", PersonAccessRightKind.NOT_APPLICABLE },
            { "ConversionBasedUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "CyclicRatioScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DateParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DateTimeParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DecompositionRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DefinedThing", PersonAccessRightKind.NOT_APPLICABLE },
            { "Definition", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "DependentParameterTypeAssignment", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "DerivedQuantityKind", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DerivedUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "DiagramCanvas", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramEdge", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramElementContainer", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramElementThing", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagrammingStyle", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramObject", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramShape", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiagramThingBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "DiscussionItem", PersonAccessRightKind.NOT_APPLICABLE },
            { "DomainFileStore", PersonAccessRightKind.NOT_APPLICABLE },
            { "DomainOfExpertise", PersonAccessRightKind.NONE },
            { "DomainOfExpertiseGroup", PersonAccessRightKind.NONE },
            { "ElementBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "ElementDefinition", PersonAccessRightKind.NOT_APPLICABLE },
            { "ElementUsage", PersonAccessRightKind.NOT_APPLICABLE },
            { "EmailAddress", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "EngineeringModel", PersonAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModelDataAnnotation", PersonAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModelDataDiscussionItem", PersonAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModelDataNote", PersonAccessRightKind.NOT_APPLICABLE },
            { "EngineeringModelSetup", PersonAccessRightKind.NONE },
            { "EnumerationParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "EnumerationValueDefinition", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ExclusiveOrExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "ExternalIdentifierMap", PersonAccessRightKind.NOT_APPLICABLE },
            { "File", PersonAccessRightKind.NOT_APPLICABLE },
            { "FileRevision", PersonAccessRightKind.NOT_APPLICABLE },
            { "FileStore", PersonAccessRightKind.NOT_APPLICABLE },
            { "FileType", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Folder", PersonAccessRightKind.NOT_APPLICABLE },
            { "GenericAnnotation", PersonAccessRightKind.NOT_APPLICABLE },
            { "Glossary", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Goal", PersonAccessRightKind.NOT_APPLICABLE },
            { "HyperLink", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "IdCorrespondence", PersonAccessRightKind.NOT_APPLICABLE },
            { "IndependentParameterTypeAssignment", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "IntervalScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Iteration", PersonAccessRightKind.NOT_APPLICABLE },
            { "IterationSetup", PersonAccessRightKind.NONE },
            { "LinearConversionUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "LogarithmicScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "LogEntryChangelogItem", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "MappingToReferenceScale", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "MeasurementScale", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "MeasurementUnit", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ModellingAnnotationItem", PersonAccessRightKind.NOT_APPLICABLE },
            { "ModellingThingReference", PersonAccessRightKind.NOT_APPLICABLE },
            { "ModelLogEntry", PersonAccessRightKind.NOT_APPLICABLE },
            { "ModelReferenceDataLibrary", PersonAccessRightKind.NONE },
            { "MultiRelationship", PersonAccessRightKind.NOT_APPLICABLE },
            { "MultiRelationshipRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "NaturalLanguage", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "NestedElement", PersonAccessRightKind.NOT_APPLICABLE },
            { "NestedParameter", PersonAccessRightKind.NOT_APPLICABLE },
            { "Note", PersonAccessRightKind.NOT_APPLICABLE },
            { "NotExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "Option", PersonAccessRightKind.NOT_APPLICABLE },
            { "OrdinalScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "OrExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "Organization", PersonAccessRightKind.NONE },
            { "OrganizationalParticipant", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "OwnedStyle", PersonAccessRightKind.NOT_APPLICABLE },
            { "Page", PersonAccessRightKind.NOT_APPLICABLE },
            { "Parameter", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterGroup", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterizedCategoryRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ParameterOrOverrideBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterOverride", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterOverrideValueSet", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterSubscription", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterSubscriptionValueSet", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterType", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterTypeComponent", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ParameterValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterValueSet", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParameterValueSetBase", PersonAccessRightKind.NOT_APPLICABLE },
            { "ParametricConstraint", PersonAccessRightKind.NOT_APPLICABLE },
            { "Participant", PersonAccessRightKind.NONE },
            { "ParticipantPermission", PersonAccessRightKind.NONE },
            { "ParticipantRole", PersonAccessRightKind.NONE },
            { "Person", PersonAccessRightKind.NONE },
            { "PersonPermission", PersonAccessRightKind.NONE },
            { "PersonRole", PersonAccessRightKind.NONE },
            { "Point", PersonAccessRightKind.NOT_APPLICABLE },
            { "PossibleFiniteState", PersonAccessRightKind.NOT_APPLICABLE },
            { "PossibleFiniteStateList", PersonAccessRightKind.NOT_APPLICABLE },
            { "PrefixedUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Publication", PersonAccessRightKind.NOT_APPLICABLE },
            { "QuantityKind", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "QuantityKindFactor", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "RatioScale", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ReferenceDataLibrary", PersonAccessRightKind.NOT_APPLICABLE },
            { "ReferencerRule", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ReferenceSource", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "RelationalExpression", PersonAccessRightKind.NOT_APPLICABLE },
            { "Relationship", PersonAccessRightKind.NOT_APPLICABLE },
            { "RelationshipParameterValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequestForDeviation", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequestForWaiver", PersonAccessRightKind.NOT_APPLICABLE },
            { "Requirement", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequirementsContainer", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequirementsContainerParameterValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequirementsGroup", PersonAccessRightKind.NOT_APPLICABLE },
            { "RequirementsSpecification", PersonAccessRightKind.NOT_APPLICABLE },
            { "ReviewItemDiscrepancy", PersonAccessRightKind.NOT_APPLICABLE },
            { "Rule", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "RuleVerification", PersonAccessRightKind.NOT_APPLICABLE },
            { "RuleVerificationList", PersonAccessRightKind.NOT_APPLICABLE },
            { "RuleViolation", PersonAccessRightKind.NOT_APPLICABLE },
            { "SampledFunctionParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ScalarParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "ScaleReferenceQuantityValue", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "ScaleValueDefinition", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Section", PersonAccessRightKind.NOT_APPLICABLE },
            { "SharedStyle", PersonAccessRightKind.NOT_APPLICABLE },
            { "SimpleParameterizableThing", PersonAccessRightKind.NOT_APPLICABLE },
            { "SimpleParameterValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "SimpleQuantityKind", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "SimpleUnit", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "SiteDirectory", PersonAccessRightKind.NONE },
            { "SiteDirectoryDataAnnotation", PersonAccessRightKind.NONE },
            { "SiteDirectoryDataDiscussionItem", PersonAccessRightKind.NONE },
            { "SiteDirectoryThingReference", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "SiteLogEntry", PersonAccessRightKind.NONE },
            { "SiteReferenceDataLibrary", PersonAccessRightKind.NONE },
            { "Solution", PersonAccessRightKind.NOT_APPLICABLE },
            { "SpecializedQuantityKind", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "Stakeholder", PersonAccessRightKind.NOT_APPLICABLE },
            { "StakeholderValue", PersonAccessRightKind.NOT_APPLICABLE },
            { "StakeHolderValueMap", PersonAccessRightKind.NOT_APPLICABLE },
            { "StakeHolderValueMapSettings", PersonAccessRightKind.NOT_APPLICABLE },
            { "TelephoneNumber", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "Term", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "TextParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "TextualNote", PersonAccessRightKind.NOT_APPLICABLE },
            { "Thing", PersonAccessRightKind.NOT_APPLICABLE },
            { "ThingReference", PersonAccessRightKind.NOT_APPLICABLE },
            { "TimeOfDayParameterType", PersonAccessRightKind.SAME_AS_SUPERCLASS },
            { "TopContainer", PersonAccessRightKind.NOT_APPLICABLE },
            { "UnitFactor", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "UnitPrefix", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "UserPreference", PersonAccessRightKind.SAME_AS_CONTAINER },
            { "UserRuleVerification", PersonAccessRightKind.NOT_APPLICABLE },
            { "ValueGroup", PersonAccessRightKind.NOT_APPLICABLE },
            { "NotThing", PersonAccessRightKind.NOT_APPLICABLE }
        };

        /// <summary>
        /// Return the default <see cref="ParticipantAccessRightKind"/> for the supplied <see cref="ClassKind"/>.
        /// </summary>
        /// <param name="classKind">
        /// The <see cref="ClassKind"/> for which the <see cref="ParticipantAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="ParticipantAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the <see cref="ClassKind"/> is not found, this should never happen
        /// </exception>
        public ParticipantAccessRightKind GetDefaultParticipantPermission(ClassKind classKind)
        {
            if (!this.classKindParticipantPermissionMap.ContainsKey(classKind))
            {
                throw new ArgumentException($"{classKind} does not have a default permission set");
            }

            return this.classKindParticipantPermissionMap[classKind];
        }

        /// <summary>
        /// Return the default <see cref="ParticipantAccessRightKind"/> for the supplied type.
        /// </summary>
        /// <param name="typeName">
        /// The type name for which the <see cref="ParticipantAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="ParticipantAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If type not found, this should never happen
        /// </exception>
        public ParticipantAccessRightKind GetDefaultParticipantPermission(string typeName)
        {
            if (!this.typeNameParticipantPermissionMap.ContainsKey(typeName))
            {
                throw new ArgumentException($"{typeName} does not have a default permission set");
            }

            return this.typeNameParticipantPermissionMap[typeName];
        }

        /// <summary>
        /// Return the default <see cref="PersonAccessRightKind"/> for the supplied ClassKind.
        /// </summary>
        /// <param name="classKind">
        /// The <see cref="ClassKind"/> for which the <see cref="PersonAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="PersonAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the <see cref="ClassKind"/> is not found, this should never happen
        /// </exception>
        public PersonAccessRightKind GetDefaultPersonPermission(ClassKind classKind)
        {
            if (!this.classKindPersonPermissionMap.ContainsKey(classKind))
            {
                throw new ArgumentException($"{classKind} does not have a default permission set");
            }

            return this.classKindPersonPermissionMap[classKind];
        }

        /// <summary>
        /// Return the default <see cref="PersonAccessRightKind"/> for the supplied type.
        /// </summary>
        /// <param name="typeName">
        /// The type name for which the <see cref="PersonAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="PersonAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If type not found, this should never happen
        /// </exception>
        public PersonAccessRightKind GetDefaultPersonPermission(string typeName)
        {
            if (!this.typeNamePersonPermissionMap.ContainsKey(typeName))
            {
                throw new ArgumentException($"{typeName} does not have a default permission set");
            }

            return this.typeNamePersonPermissionMap[typeName];
        }

        /// <summary>
        /// Provide the type to default person permission map.
        /// </summary>
        /// <returns>
        /// The type to default person permission map.
        /// </returns>
        public IReadOnlyDictionary<string, PersonAccessRightKind> GetDefaultTypeNamePersonPermissions()
        {
            return this.typeNamePersonPermissionMap;
        }

        /// <summary>
        /// Provide the type to default participant permission map.
        /// </summary>
        /// <returns>
        /// The type to default participant permission map.
        /// </returns>
        public IReadOnlyDictionary<string, ParticipantAccessRightKind> GetDefaultTypeNameParticipantPermissions()
        {
            return this.typeNameParticipantPermissionMap;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
