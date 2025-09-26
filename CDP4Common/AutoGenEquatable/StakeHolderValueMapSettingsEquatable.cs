// ------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapSettingsEquatable.cs" company="Starion Group S.A.">
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
 | 2     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 3     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 4     | goalToValueGroupRelationship         | Guid                         | 0..1        |  1.1.0  |
 | 5     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 6     | stakeholderValueToRequirementRelationship | Guid                         | 0..1        |  1.1.0  |
 | 7     | valueGroupToStakeholderValueRelationship | Guid                         | 0..1        |  1.1.0  |
 | 8     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 9     | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="StakeHolderValueMapSettings"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class StakeHolderValueMapSettingsEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="StakeHolderValueMapSettings"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="StakeHolderValueMapSettings"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="StakeHolderValueMapSettings"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="StakeHolderValueMapSettings"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this StakeHolderValueMapSettings me, StakeHolderValueMapSettings other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.ExcludedDomain.OrderBy(x => x).SequenceEqual(other.ExcludedDomain.OrderBy(x => x))) return false;

            if (!me.ExcludedPerson.OrderBy(x => x).SequenceEqual(other.ExcludedPerson.OrderBy(x => x))) return false;

            if (me.GoalToValueGroupRelationship.HasValue != other.GoalToValueGroupRelationship.HasValue) return false;
            if (!me.GoalToValueGroupRelationship.Equals(other.GoalToValueGroupRelationship)) return false;

            if (!me.ModifiedOn.Equals(other.ModifiedOn)) return false;

            if (me.StakeholderValueToRequirementRelationship.HasValue != other.StakeholderValueToRequirementRelationship.HasValue) return false;
            if (!me.StakeholderValueToRequirementRelationship.Equals(other.StakeholderValueToRequirementRelationship)) return false;

            if (me.ValueGroupToStakeholderValueRelationship.HasValue != other.ValueGroupToStakeholderValueRelationship.HasValue) return false;
            if (!me.ValueGroupToStakeholderValueRelationship.Equals(other.ValueGroupToStakeholderValueRelationship)) return false;

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
