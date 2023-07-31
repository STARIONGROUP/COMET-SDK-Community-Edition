// ------------------------------------------------------------------------------------------------
// <copyright file="CompoundParameterTypeEquatable.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
//
//    This file is part of CDP4-COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
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
 | 3     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 4     | component                            | Guid                         | 1..*        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | isFinalized                          | bool                         | 1..1        |  1.0.0  |
 | 9     | name                                 | string                       | 1..1        |  1.0.0  |
 | 10    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 11    | symbol                               | string                       | 1..1        |  1.0.0  |
 | 12    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 13    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 15    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="CompoundParameterType"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class CompoundParameterTypeEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="CompoundParameterType"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="CompoundParameterType"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="CompoundParameterType"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="CompoundParameterType"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this CompoundParameterType me, CompoundParameterType other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.Alias.OrderBy(x => x).SequenceEqual(other.Alias.OrderBy(x => x))) return false;

            if (!me.Category.OrderBy(x => x).SequenceEqual(other.Category.OrderBy(x => x))) return false;

            if (!me.Component.OrderBy(x => x.K).Select(x => x.K).SequenceEqual(other.Component.OrderBy(x => x.K).Select(x => x.K))) return false;
            if (!me.Component.OrderBy(x => x.K).Select(x => x.V).SequenceEqual(other.Component.OrderBy(x => x.K).Select(x => x.V))) return false;

            if (!me.Definition.OrderBy(x => x).SequenceEqual(other.Definition.OrderBy(x => x))) return false;

            if (!me.HyperLink.OrderBy(x => x).SequenceEqual(other.HyperLink.OrderBy(x => x))) return false;

            if (!me.IsDeprecated.Equals(other.IsDeprecated)) return false;

            if (!me.IsFinalized.Equals(other.IsFinalized)) return false;

            if (me.Name == null && other.Name != null) return false;
            if (me.Name != null && !me.Name.Equals(other.Name)) return false;

            if (me.ShortName == null && other.ShortName != null) return false;
            if (me.ShortName != null && !me.ShortName.Equals(other.ShortName)) return false;

            if (me.Symbol == null && other.Symbol != null) return false;
            if (me.Symbol != null && !me.Symbol.Equals(other.Symbol)) return false;

            if (!me.ExcludedDomain.OrderBy(x => x).SequenceEqual(other.ExcludedDomain.OrderBy(x => x))) return false;

            if (!me.ExcludedPerson.OrderBy(x => x).SequenceEqual(other.ExcludedPerson.OrderBy(x => x))) return false;

            if (!me.ModifiedOn.Equals(other.ModifiedOn)) return false;

            if (me.ThingPreference == null && other.ThingPreference != null) return false;
            if (me.ThingPreference != null && !me.ThingPreference.Equals(other.ThingPreference)) return false;

            return true;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
