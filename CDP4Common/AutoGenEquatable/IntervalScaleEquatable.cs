// ------------------------------------------------------------------------------------------------
// <copyright file="IntervalScaleEquatable.cs" company="RHEA System S.A.">
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 5     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 6     | isMaximumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 7     | isMinimumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 8     | mappingToReferenceScale              | Guid                         | 0..*        |  1.0.0  |
 | 9     | maximumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 10    | minimumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 11    | name                                 | string                       | 1..1        |  1.0.0  |
 | 12    | negativeValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 13    | numberSet                            | NumberSetKind                | 1..1        |  1.0.0  |
 | 14    | positiveValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 15    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 16    | unit                                 | Guid                         | 1..1        |  1.0.0  |
 | 17    | valueDefinition                      | Guid                         | 0..*        |  1.0.0  |
 | 18    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 19    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 20    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 21    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 22    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 23    | attachment                           | Guid                         | 0..*        |  1.4.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="IntervalScale"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class IntervalScaleEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="IntervalScale"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="IntervalScale"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="IntervalScale"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="IntervalScale"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this IntervalScale me, IntervalScale other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.Alias.OrderBy(x => x).SequenceEqual(other.Alias.OrderBy(x => x))) return false;

            if (!me.Definition.OrderBy(x => x).SequenceEqual(other.Definition.OrderBy(x => x))) return false;

            if (!me.HyperLink.OrderBy(x => x).SequenceEqual(other.HyperLink.OrderBy(x => x))) return false;

            if (!me.IsDeprecated.Equals(other.IsDeprecated)) return false;

            if (!me.IsMaximumInclusive.Equals(other.IsMaximumInclusive)) return false;

            if (!me.IsMinimumInclusive.Equals(other.IsMinimumInclusive)) return false;

            if (!me.MappingToReferenceScale.OrderBy(x => x).SequenceEqual(other.MappingToReferenceScale.OrderBy(x => x))) return false;

            if (me.MaximumPermissibleValue == null && other.MaximumPermissibleValue != null) return false;
            if (me.MaximumPermissibleValue != null && !me.MaximumPermissibleValue.Equals(other.MaximumPermissibleValue)) return false;

            if (me.MinimumPermissibleValue == null && other.MinimumPermissibleValue != null) return false;
            if (me.MinimumPermissibleValue != null && !me.MinimumPermissibleValue.Equals(other.MinimumPermissibleValue)) return false;

            if (me.Name == null && other.Name != null) return false;
            if (me.Name != null && !me.Name.Equals(other.Name)) return false;

            if (me.NegativeValueConnotation == null && other.NegativeValueConnotation != null) return false;
            if (me.NegativeValueConnotation != null && !me.NegativeValueConnotation.Equals(other.NegativeValueConnotation)) return false;

            if (!me.NumberSet.Equals(other.NumberSet)) return false;

            if (me.PositiveValueConnotation == null && other.PositiveValueConnotation != null) return false;
            if (me.PositiveValueConnotation != null && !me.PositiveValueConnotation.Equals(other.PositiveValueConnotation)) return false;

            if (me.ShortName == null && other.ShortName != null) return false;
            if (me.ShortName != null && !me.ShortName.Equals(other.ShortName)) return false;

            if (!me.Unit.Equals(other.Unit)) return false;

            if (!me.ValueDefinition.OrderBy(x => x).SequenceEqual(other.ValueDefinition.OrderBy(x => x))) return false;

            if (!me.ExcludedDomain.OrderBy(x => x).SequenceEqual(other.ExcludedDomain.OrderBy(x => x))) return false;

            if (!me.ExcludedPerson.OrderBy(x => x).SequenceEqual(other.ExcludedPerson.OrderBy(x => x))) return false;

            if (!me.ModifiedOn.Equals(other.ModifiedOn)) return false;

            if (me.ThingPreference == null && other.ThingPreference != null) return false;
            if (me.ThingPreference != null && !me.ThingPreference.Equals(other.ThingPreference)) return false;

            if (me.Actor.HasValue != other.Actor.HasValue) return false;
            if (!me.Actor.Equals(other.Actor)) return false;

            if (!me.Attachment.OrderBy(x => x).SequenceEqual(other.Attachment.OrderBy(x => x))) return false;

            return true;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
