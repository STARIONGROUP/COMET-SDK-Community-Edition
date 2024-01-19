// ------------------------------------------------------------------------------------------------
// <copyright file="LogarithmicScaleEquatable.cs" company="RHEA System S.A.">
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
 | 4     | exponent                             | string                       | 1..1        |  1.0.0  |
 | 5     | factor                               | string                       | 1..1        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | isMaximumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 9     | isMinimumInclusive                   | bool                         | 1..1        |  1.0.0  |
 | 10    | logarithmBase                        | LogarithmBaseKind            | 1..1        |  1.0.0  |
 | 11    | mappingToReferenceScale              | Guid                         | 0..*        |  1.0.0  |
 | 12    | maximumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 13    | minimumPermissibleValue              | string                       | 0..1        |  1.0.0  |
 | 14    | name                                 | string                       | 1..1        |  1.0.0  |
 | 15    | negativeValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 16    | numberSet                            | NumberSetKind                | 1..1        |  1.0.0  |
 | 17    | positiveValueConnotation             | string                       | 0..1        |  1.0.0  |
 | 18    | referenceQuantityKind                | Guid                         | 1..1        |  1.0.0  |
 | 19    | referenceQuantityValue               | Guid                         | 0..1        |  1.0.0  |
 | 20    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 21    | unit                                 | Guid                         | 1..1        |  1.0.0  |
 | 22    | valueDefinition                      | Guid                         | 0..*        |  1.0.0  |
 | 23    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 24    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 25    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 26    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 27    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 28    | attachment                           | Guid                         | 0..*        |  1.4.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="LogarithmicScale"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class LogarithmicScaleEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="LogarithmicScale"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="LogarithmicScale"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="LogarithmicScale"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="LogarithmicScale"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this LogarithmicScale me, LogarithmicScale other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.Alias.OrderBy(x => x).SequenceEqual(other.Alias.OrderBy(x => x))) return false;

            if (!me.Definition.OrderBy(x => x).SequenceEqual(other.Definition.OrderBy(x => x))) return false;

            if (me.Exponent == null && other.Exponent != null) return false;
            if (me.Exponent != null && !me.Exponent.Equals(other.Exponent)) return false;

            if (me.Factor == null && other.Factor != null) return false;
            if (me.Factor != null && !me.Factor.Equals(other.Factor)) return false;

            if (!me.HyperLink.OrderBy(x => x).SequenceEqual(other.HyperLink.OrderBy(x => x))) return false;

            if (!me.IsDeprecated.Equals(other.IsDeprecated)) return false;

            if (!me.IsMaximumInclusive.Equals(other.IsMaximumInclusive)) return false;

            if (!me.IsMinimumInclusive.Equals(other.IsMinimumInclusive)) return false;

            if (!me.LogarithmBase.Equals(other.LogarithmBase)) return false;

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

            if (!me.ReferenceQuantityKind.Equals(other.ReferenceQuantityKind)) return false;

            if (!me.ReferenceQuantityValue.OrderBy(x => x).SequenceEqual(other.ReferenceQuantityValue.OrderBy(x => x))) return false;

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
