// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassKindDeserializer.cs" company="Starion Group S.A.">
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
    using System.IO;
    using System.Text.Json;

    using CDP4Common.CommonData;

    /// <summary>
    /// The purpose of the <see cref="ClassKindDeserializer"/> is to deserialize a JSON object to a <see cref="ClassKind"/>
    /// </summary>
    internal static class ClassKindDeserializer
    {
        /// <summary>
        /// Deserializes the <see cref="JsonElement"/> into a <see cref="ClassKind"/>
        /// </summary>
        /// <param name="jsonElement">the element to deserialize</param>
        /// <returns>the <see cref="ClassKind"/></returns>
        /// <exception cref="ArgumentException">if the <see cref="JsonElement"/> can't be parsed into the <see cref="ClassKind"/></exception>
        internal static ClassKind Deserialize(JsonElement jsonElement)
        {
            var value = jsonElement.GetString();

            return value switch
            {
                "ActionItem" => ClassKind.ActionItem,
                "ActualFiniteState" => ClassKind.ActualFiniteState,
                "ActualFiniteStateList" => ClassKind.ActualFiniteStateList,
                "Alias" => ClassKind.Alias,
                "AndExpression" => ClassKind.AndExpression,
                "Approval" => ClassKind.Approval,
                "ArrayParameterType" => ClassKind.ArrayParameterType,
                "BinaryNote" => ClassKind.BinaryNote,
                "BinaryRelationship" => ClassKind.BinaryRelationship,
                "BinaryRelationshipRule" => ClassKind.BinaryRelationshipRule,
                "Book" => ClassKind.Book,
                "BooleanExpression" => ClassKind.BooleanExpression,
                "BooleanParameterType" => ClassKind.BooleanParameterType,
                "Bounds" => ClassKind.Bounds,
                "BuiltInRuleVerification" => ClassKind.BuiltInRuleVerification,
                "Category" => ClassKind.Category,
                "ChangeProposal" => ClassKind.ChangeProposal,
                "ChangeRequest" => ClassKind.ChangeRequest,
                "Citation" => ClassKind.Citation,
                "Color" => ClassKind.Color,
                "CommonFileStore" => ClassKind.CommonFileStore,
                "CompoundParameterType" => ClassKind.CompoundParameterType,
                "Constant" => ClassKind.Constant,
                "ContractChangeNotice" => ClassKind.ContractChangeNotice,
                "ContractDeviation" => ClassKind.ContractDeviation,
                "ConversionBasedUnit" => ClassKind.ConversionBasedUnit,
                "CyclicRatioScale" => ClassKind.CyclicRatioScale,
                "DateParameterType" => ClassKind.DateParameterType,
                "DateTimeParameterType" => ClassKind.DateTimeParameterType,
                "DecompositionRule" => ClassKind.DecompositionRule,
                "DefinedThing" => ClassKind.DefinedThing,
                "Definition" => ClassKind.Definition,
                "DependentParameterTypeAssignment" => ClassKind.DependentParameterTypeAssignment,
                "DerivedQuantityKind" => ClassKind.DerivedQuantityKind,
                "DerivedUnit" => ClassKind.DerivedUnit,
                "DiagramCanvas" => ClassKind.DiagramCanvas,
                "DiagramEdge" => ClassKind.DiagramEdge,
                "DiagramElementContainer" => ClassKind.DiagramElementContainer,
                "DiagramElementThing" => ClassKind.DiagramElementThing,
                "DiagrammingStyle" => ClassKind.DiagrammingStyle,
                "DiagramObject" => ClassKind.DiagramObject,
                "DiagramShape" => ClassKind.DiagramShape,
                "DiagramThingBase" => ClassKind.DiagramThingBase,
                "DiscussionItem" => ClassKind.DiscussionItem,
                "DomainFileStore" => ClassKind.DomainFileStore,
                "DomainOfExpertise" => ClassKind.DomainOfExpertise,
                "DomainOfExpertiseGroup" => ClassKind.DomainOfExpertiseGroup,
                "ElementBase" => ClassKind.ElementBase,
                "ElementDefinition" => ClassKind.ElementDefinition,
                "ElementUsage" => ClassKind.ElementUsage,
                "EmailAddress" => ClassKind.EmailAddress,
                "EngineeringModel" => ClassKind.EngineeringModel,
                "EngineeringModelDataAnnotation" => ClassKind.EngineeringModelDataAnnotation,
                "EngineeringModelDataDiscussionItem" => ClassKind.EngineeringModelDataDiscussionItem,
                "EngineeringModelDataNote" => ClassKind.EngineeringModelDataNote,
                "EngineeringModelSetup" => ClassKind.EngineeringModelSetup,
                "EnumerationParameterType" => ClassKind.EnumerationParameterType,
                "EnumerationValueDefinition" => ClassKind.EnumerationValueDefinition,
                "ExclusiveOrExpression" => ClassKind.ExclusiveOrExpression,
                "ExternalIdentifierMap" => ClassKind.ExternalIdentifierMap,
                "File" => ClassKind.File,
                "FileRevision" => ClassKind.FileRevision,
                "FileStore" => ClassKind.FileStore,
                "FileType" => ClassKind.FileType,
                "Folder" => ClassKind.Folder,
                "GenericAnnotation" => ClassKind.GenericAnnotation,
                "Glossary" => ClassKind.Glossary,
                "Goal" => ClassKind.Goal,
                "HyperLink" => ClassKind.HyperLink,
                "IdCorrespondence" => ClassKind.IdCorrespondence,
                "IndependentParameterTypeAssignment" => ClassKind.IndependentParameterTypeAssignment,
                "IntervalScale" => ClassKind.IntervalScale,
                "Iteration" => ClassKind.Iteration,
                "IterationSetup" => ClassKind.IterationSetup,
                "LinearConversionUnit" => ClassKind.LinearConversionUnit,
                "LogarithmicScale" => ClassKind.LogarithmicScale,
                "LogEntryChangelogItem" => ClassKind.LogEntryChangelogItem,
                "MappingToReferenceScale" => ClassKind.MappingToReferenceScale,
                "MeasurementScale" => ClassKind.MeasurementScale,
                "MeasurementUnit" => ClassKind.MeasurementUnit,
                "ModellingAnnotationItem" => ClassKind.ModellingAnnotationItem,
                "ModellingThingReference" => ClassKind.ModellingThingReference,
                "ModelLogEntry" => ClassKind.ModelLogEntry,
                "ModelReferenceDataLibrary" => ClassKind.ModelReferenceDataLibrary,
                "MultiRelationship" => ClassKind.MultiRelationship,
                "MultiRelationshipRule" => ClassKind.MultiRelationshipRule,
                "NaturalLanguage" => ClassKind.NaturalLanguage,
                "NestedElement" => ClassKind.NestedElement,
                "NestedParameter" => ClassKind.NestedParameter,
                "Note" => ClassKind.Note,
                "NotExpression" => ClassKind.NotExpression,
                "NotThing" => ClassKind.NotThing,
                "Option" => ClassKind.Option,
                "OrdinalScale" => ClassKind.OrdinalScale,
                "OrExpression" => ClassKind.OrExpression,
                "Organization" => ClassKind.Organization,
                "OrganizationalParticipant" => ClassKind.OrganizationalParticipant,
                "OwnedStyle" => ClassKind.OwnedStyle,
                "Page" => ClassKind.Page,
                "Parameter" => ClassKind.Parameter,
                "ParameterBase" => ClassKind.ParameterBase,
                "ParameterGroup" => ClassKind.ParameterGroup,
                "ParameterizedCategoryRule" => ClassKind.ParameterizedCategoryRule,
                "ParameterOrOverrideBase" => ClassKind.ParameterOrOverrideBase,
                "ParameterOverride" => ClassKind.ParameterOverride,
                "ParameterOverrideValueSet" => ClassKind.ParameterOverrideValueSet,
                "ParameterSubscription" => ClassKind.ParameterSubscription,
                "ParameterSubscriptionValueSet" => ClassKind.ParameterSubscriptionValueSet,
                "ParameterType" => ClassKind.ParameterType,
                "ParameterTypeComponent" => ClassKind.ParameterTypeComponent,
                "ParameterValue" => ClassKind.ParameterValue,
                "ParameterValueSet" => ClassKind.ParameterValueSet,
                "ParameterValueSetBase" => ClassKind.ParameterValueSetBase,
                "ParametricConstraint" => ClassKind.ParametricConstraint,
                "Participant" => ClassKind.Participant,
                "ParticipantPermission" => ClassKind.ParticipantPermission,
                "ParticipantRole" => ClassKind.ParticipantRole,
                "Person" => ClassKind.Person,
                "PersonPermission" => ClassKind.PersonPermission,
                "PersonRole" => ClassKind.PersonRole,
                "Point" => ClassKind.Point,
                "PossibleFiniteState" => ClassKind.PossibleFiniteState,
                "PossibleFiniteStateList" => ClassKind.PossibleFiniteStateList,
                "PrefixedUnit" => ClassKind.PrefixedUnit,
                "Publication" => ClassKind.Publication,
                "QuantityKind" => ClassKind.QuantityKind,
                "QuantityKindFactor" => ClassKind.QuantityKindFactor,
                "RatioScale" => ClassKind.RatioScale,
                "ReferenceDataLibrary" => ClassKind.ReferenceDataLibrary,
                "ReferencerRule" => ClassKind.ReferencerRule,
                "ReferenceSource" => ClassKind.ReferenceSource,
                "RelationalExpression" => ClassKind.RelationalExpression,
                "Relationship" => ClassKind.Relationship,
                "RelationshipParameterValue" => ClassKind.RelationshipParameterValue,
                "RequestForDeviation" => ClassKind.RequestForDeviation,
                "RequestForWaiver" => ClassKind.RequestForWaiver,
                "Requirement" => ClassKind.Requirement,
                "RequirementsContainer" => ClassKind.RequirementsContainer,
                "RequirementsContainerParameterValue" => ClassKind.RequirementsContainerParameterValue,
                "RequirementsGroup" => ClassKind.RequirementsGroup,
                "RequirementsSpecification" => ClassKind.RequirementsSpecification,
                "ReviewItemDiscrepancy" => ClassKind.ReviewItemDiscrepancy,
                "Rule" => ClassKind.Rule,
                "RuleVerification" => ClassKind.RuleVerification,
                "RuleVerificationList" => ClassKind.RuleVerificationList,
                "RuleViolation" => ClassKind.RuleViolation,
                "SampledFunctionParameterType" => ClassKind.SampledFunctionParameterType,
                "ScalarParameterType" => ClassKind.ScalarParameterType,
                "ScaleReferenceQuantityValue" => ClassKind.ScaleReferenceQuantityValue,
                "ScaleValueDefinition" => ClassKind.ScaleValueDefinition,
                "Section" => ClassKind.Section,
                "SharedStyle" => ClassKind.SharedStyle,
                "SimpleParameterizableThing" => ClassKind.SimpleParameterizableThing,
                "SimpleParameterValue" => ClassKind.SimpleParameterValue,
                "SimpleQuantityKind" => ClassKind.SimpleQuantityKind,
                "SimpleUnit" => ClassKind.SimpleUnit,
                "SiteDirectory" => ClassKind.SiteDirectory,
                "SiteDirectoryDataAnnotation" => ClassKind.SiteDirectoryDataAnnotation,
                "SiteDirectoryDataDiscussionItem" => ClassKind.SiteDirectoryDataDiscussionItem,
                "SiteDirectoryThingReference" => ClassKind.SiteDirectoryThingReference,
                "SiteLogEntry" => ClassKind.SiteLogEntry,
                "SiteReferenceDataLibrary" => ClassKind.SiteReferenceDataLibrary,
                "Solution" => ClassKind.Solution,
                "SpecializedQuantityKind" => ClassKind.SpecializedQuantityKind,
                "Stakeholder" => ClassKind.Stakeholder,
                "StakeholderValue" => ClassKind.StakeholderValue,
                "StakeHolderValueMap" => ClassKind.StakeHolderValueMap,
                "StakeHolderValueMapSettings" => ClassKind.StakeHolderValueMapSettings,
                "TelephoneNumber" => ClassKind.TelephoneNumber,
                "Term" => ClassKind.Term,
                "TextParameterType" => ClassKind.TextParameterType,
                "TextualNote" => ClassKind.TextualNote,
                "Thing" => ClassKind.Thing,
                "ThingReference" => ClassKind.ThingReference,
                "TimeOfDayParameterType" => ClassKind.TimeOfDayParameterType,
                "TopContainer" => ClassKind.TopContainer,
                "UnitFactor" => ClassKind.UnitFactor,
                "UnitPrefix" => ClassKind.UnitPrefix,
                "UserPreference" => ClassKind.UserPreference,
                "UserRuleVerification" => ClassKind.UserRuleVerification,
                "ValueGroup" => ClassKind.ValueGroup,
                _ => throw new InvalidDataException($"{value} is not a valid for ClassKind")
            };
        }        
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
