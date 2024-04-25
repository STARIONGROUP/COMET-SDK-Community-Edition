// ------------------------------------------------------------------------------------------------
// <copyright file="PersonEquatable.cs" company="Starion Group S.A.">
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

/* -------------------------------------------- | ---------------------------- | ----------- | ------- *
 | index | name                                 | Type                         | Cardinality | version |
 | -------------------------------------------- | ---------------------------- | ----------- | ------- |
 | 0     | iid                                  | Guid                         |  1..1       |  1.0.0  |
 | 1     | revisionNumber                       | int                          |  1..1       |  1.0.0  |
 | -------------------------------------------- | ---------------------------- | ----------- | ------- |
 | 2     | defaultDomain                        | Guid                         | 0..1        |  1.0.0  |
 | 3     | defaultEmailAddress                  | Guid                         | 0..1        |  1.0.0  |
 | 4     | defaultTelephoneNumber               | Guid                         | 0..1        |  1.0.0  |
 | 5     | emailAddress                         | Guid                         | 0..*        |  1.0.0  |
 | 6     | givenName                            | string                       | 1..1        |  1.0.0  |
 | 7     | isActive                             | bool                         | 1..1        |  1.0.0  |
 | 8     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 9     | organization                         | Guid                         | 0..1        |  1.0.0  |
 | 10    | organizationalUnit                   | string                       | 0..1        |  1.0.0  |
 | 11    | password                             | string                       | 0..1        |  1.0.0  |
 | 12    | role                                 | Guid                         | 0..1        |  1.0.0  |
 | 13    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 14    | surname                              | string                       | 1..1        |  1.0.0  |
 | 15    | telephoneNumber                      | Guid                         | 0..*        |  1.0.0  |
 | 16    | userPreference                       | Guid                         | 0..*        |  1.0.0  |
 | 17    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 18    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 19    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 20    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 21    | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="Person"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class PersonEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="Person"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="Person"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="Person"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="Person"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this Person me, Person other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (me.DefaultDomain.HasValue != other.DefaultDomain.HasValue) return false;
            if (!me.DefaultDomain.Equals(other.DefaultDomain)) return false;

            if (me.DefaultEmailAddress.HasValue != other.DefaultEmailAddress.HasValue) return false;
            if (!me.DefaultEmailAddress.Equals(other.DefaultEmailAddress)) return false;

            if (me.DefaultTelephoneNumber.HasValue != other.DefaultTelephoneNumber.HasValue) return false;
            if (!me.DefaultTelephoneNumber.Equals(other.DefaultTelephoneNumber)) return false;

            if (!me.EmailAddress.OrderBy(x => x).SequenceEqual(other.EmailAddress.OrderBy(x => x))) return false;

            if (me.GivenName == null && other.GivenName != null) return false;
            if (me.GivenName != null && !me.GivenName.Equals(other.GivenName)) return false;

            if (!me.IsActive.Equals(other.IsActive)) return false;

            if (!me.IsDeprecated.Equals(other.IsDeprecated)) return false;

            if (me.Organization.HasValue != other.Organization.HasValue) return false;
            if (!me.Organization.Equals(other.Organization)) return false;

            if (me.OrganizationalUnit == null && other.OrganizationalUnit != null) return false;
            if (me.OrganizationalUnit != null && !me.OrganizationalUnit.Equals(other.OrganizationalUnit)) return false;

            if (me.Password == null && other.Password != null) return false;
            if (me.Password != null && !me.Password.Equals(other.Password)) return false;

            if (me.Role.HasValue != other.Role.HasValue) return false;
            if (!me.Role.Equals(other.Role)) return false;

            if (me.ShortName == null && other.ShortName != null) return false;
            if (me.ShortName != null && !me.ShortName.Equals(other.ShortName)) return false;

            if (me.Surname == null && other.Surname != null) return false;
            if (me.Surname != null && !me.Surname.Equals(other.Surname)) return false;

            if (!me.TelephoneNumber.OrderBy(x => x).SequenceEqual(other.TelephoneNumber.OrderBy(x => x))) return false;

            if (!me.UserPreference.OrderBy(x => x).SequenceEqual(other.UserPreference.OrderBy(x => x))) return false;

            if (!me.ExcludedDomain.OrderBy(x => x).SequenceEqual(other.ExcludedDomain.OrderBy(x => x))) return false;

            if (!me.ExcludedPerson.OrderBy(x => x).SequenceEqual(other.ExcludedPerson.OrderBy(x => x))) return false;

            if (!me.ModifiedOn.Equals(other.ModifiedOn)) return false;

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
