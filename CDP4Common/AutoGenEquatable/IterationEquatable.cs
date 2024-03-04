// ------------------------------------------------------------------------------------------------
// <copyright file="IterationEquatable.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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

/* -------------------------------------------- | ---------------------------- | ----------- | ------- *
 | index | name                                 | Type                         | Cardinality | version |
 | -------------------------------------------- | ---------------------------- | ----------- | ------- |
 | 0     | iid                                  | Guid                         |  1..1       |  1.0.0  |
 | 1     | revisionNumber                       | int                          |  1..1       |  1.0.0  |
 | -------------------------------------------- | ---------------------------- | ----------- | ------- |
 | 2     | actualFiniteStateList                | Guid                         | 0..*        |  1.0.0  |
 | 3     | defaultOption                        | Guid                         | 0..1        |  1.0.0  |
 | 4     | domainFileStore                      | Guid                         | 0..*        |  1.0.0  |
 | 5     | element                              | Guid                         | 0..*        |  1.0.0  |
 | 6     | externalIdentifierMap                | Guid                         | 0..*        |  1.0.0  |
 | 7     | iterationSetup                       | Guid                         | 1..1        |  1.0.0  |
 | 8     | option                               | Guid                         | 1..*        |  1.0.0  |
 | 9     | possibleFiniteStateList              | Guid                         | 0..*        |  1.0.0  |
 | 10    | publication                          | Guid                         | 0..*        |  1.0.0  |
 | 11    | relationship                         | Guid                         | 0..*        |  1.0.0  |
 | 12    | requirementsSpecification            | Guid                         | 0..*        |  1.0.0  |
 | 13    | ruleVerificationList                 | Guid                         | 0..*        |  1.0.0  |
 | 14    | sourceIterationIid                   | Guid                         | 0..1        |  1.0.0  |
 | 15    | topElement                           | Guid                         | 0..1        |  1.0.0  |
 | 16    | diagramCanvas                        | Guid                         | 0..*        |  1.1.0  |
 | 17    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 18    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 19    | goal                                 | Guid                         | 0..*        |  1.1.0  |
 | 20    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 21    | sharedDiagramStyle                   | Guid                         | 0..*        |  1.1.0  |
 | 22    | stakeholder                          | Guid                         | 0..*        |  1.1.0  |
 | 23    | stakeholderValue                     | Guid                         | 0..*        |  1.1.0  |
 | 24    | stakeholderValueMap                  | Guid                         | 0..*        |  1.1.0  |
 | 25    | valueGroup                           | Guid                         | 0..*        |  1.1.0  |
 | 26    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 27    | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="Iteration"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class IterationEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="Iteration"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="Iteration"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="Iteration"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="Iteration"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this Iteration me, Iteration other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.ActualFiniteStateList.OrderBy(x => x).SequenceEqual(other.ActualFiniteStateList.OrderBy(x => x))) return false;

            if (me.DefaultOption.HasValue != other.DefaultOption.HasValue) return false;
            if (!me.DefaultOption.Equals(other.DefaultOption)) return false;

            if (!me.DomainFileStore.OrderBy(x => x).SequenceEqual(other.DomainFileStore.OrderBy(x => x))) return false;

            if (!me.Element.OrderBy(x => x).SequenceEqual(other.Element.OrderBy(x => x))) return false;

            if (!me.ExternalIdentifierMap.OrderBy(x => x).SequenceEqual(other.ExternalIdentifierMap.OrderBy(x => x))) return false;

            if (!me.IterationSetup.Equals(other.IterationSetup)) return false;

            if (!me.Option.OrderBy(x => x.K).Select(x => x.K).SequenceEqual(other.Option.OrderBy(x => x.K).Select(x => x.K))) return false;
            if (!me.Option.OrderBy(x => x.K).Select(x => x.V).SequenceEqual(other.Option.OrderBy(x => x.K).Select(x => x.V))) return false;

            if (!me.PossibleFiniteStateList.OrderBy(x => x).SequenceEqual(other.PossibleFiniteStateList.OrderBy(x => x))) return false;

            if (!me.Publication.OrderBy(x => x).SequenceEqual(other.Publication.OrderBy(x => x))) return false;

            if (!me.Relationship.OrderBy(x => x).SequenceEqual(other.Relationship.OrderBy(x => x))) return false;

            if (!me.RequirementsSpecification.OrderBy(x => x).SequenceEqual(other.RequirementsSpecification.OrderBy(x => x))) return false;

            if (!me.RuleVerificationList.OrderBy(x => x).SequenceEqual(other.RuleVerificationList.OrderBy(x => x))) return false;

            if (me.SourceIterationIid.HasValue != other.SourceIterationIid.HasValue) return false;
            if (!me.SourceIterationIid.Equals(other.SourceIterationIid)) return false;

            if (me.TopElement.HasValue != other.TopElement.HasValue) return false;
            if (!me.TopElement.Equals(other.TopElement)) return false;

            if (!me.DiagramCanvas.OrderBy(x => x).SequenceEqual(other.DiagramCanvas.OrderBy(x => x))) return false;

            if (!me.ExcludedDomain.OrderBy(x => x).SequenceEqual(other.ExcludedDomain.OrderBy(x => x))) return false;

            if (!me.ExcludedPerson.OrderBy(x => x).SequenceEqual(other.ExcludedPerson.OrderBy(x => x))) return false;

            if (!me.Goal.OrderBy(x => x).SequenceEqual(other.Goal.OrderBy(x => x))) return false;

            if (!me.ModifiedOn.Equals(other.ModifiedOn)) return false;

            if (!me.SharedDiagramStyle.OrderBy(x => x).SequenceEqual(other.SharedDiagramStyle.OrderBy(x => x))) return false;

            if (!me.Stakeholder.OrderBy(x => x).SequenceEqual(other.Stakeholder.OrderBy(x => x))) return false;

            if (!me.StakeholderValue.OrderBy(x => x).SequenceEqual(other.StakeholderValue.OrderBy(x => x))) return false;

            if (!me.StakeholderValueMap.OrderBy(x => x).SequenceEqual(other.StakeholderValueMap.OrderBy(x => x))) return false;

            if (!me.ValueGroup.OrderBy(x => x).SequenceEqual(other.ValueGroup.OrderBy(x => x))) return false;

            if (me.ThingPreference == null && other.ThingPreference != null) return false;
            if (me.ThingPreference != null && !me.ThingPreference.Equals(other.ThingPreference)) return false;

            if (me.Actor.HasValue != other.Actor.HasValue) return false;
            if (!me.Actor.Equals(other.Actor)) return false;

            return true;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
