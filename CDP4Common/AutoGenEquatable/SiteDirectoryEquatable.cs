// ------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryEquatable.cs" company="RHEA System S.A.">
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
 | 2     | createdOn                            | DateTime                     | 1..1        |  1.0.0  |
 | 3     | defaultParticipantRole               | Guid                         | 0..1        |  1.0.0  |
 | 4     | defaultPersonRole                    | Guid                         | 0..1        |  1.0.0  |
 | 5     | domain                               | Guid                         | 0..*        |  1.0.0  |
 | 6     | domainGroup                          | Guid                         | 0..*        |  1.0.0  |
 | 7     | lastModifiedOn                       | DateTime                     | 1..1        |  1.0.0  |
 | 8     | logEntry                             | Guid                         | 0..*        |  1.0.0  |
 | 9     | model                                | Guid                         | 0..*        |  1.0.0  |
 | 10    | name                                 | string                       | 1..1        |  1.0.0  |
 | 11    | naturalLanguage                      | Guid                         | 0..*        |  1.0.0  |
 | 12    | organization                         | Guid                         | 0..*        |  1.0.0  |
 | 13    | participantRole                      | Guid                         | 0..*        |  1.0.0  |
 | 14    | person                               | Guid                         | 0..*        |  1.0.0  |
 | 15    | personRole                           | Guid                         | 0..*        |  1.0.0  |
 | 16    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 17    | siteReferenceDataLibrary             | Guid                         | 0..*        |  1.0.0  |
 | 18    | annotation                           | Guid                         | 0..*        |  1.1.0  |
 | 19    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 20    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 21    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 22    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="SiteDirectory"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class SiteDirectoryEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="SiteDirectory"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="SiteDirectory"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="SiteDirectory"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="SiteDirectory"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this SiteDirectory me, SiteDirectory other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.CreatedOn.Equals(other.CreatedOn)) return false;

            if (!me.DefaultParticipantRole.HasValue && other.DefaultParticipantRole.HasValue) return false;
            if (!me.DefaultParticipantRole.Equals(other.DefaultParticipantRole)) return false;

            if (!me.DefaultPersonRole.HasValue && other.DefaultPersonRole.HasValue) return false;
            if (!me.DefaultPersonRole.Equals(other.DefaultPersonRole)) return false;

            if (!me.Domain.OrderBy(x => x).SequenceEqual(other.Domain.OrderBy(x => x))) return false;

            if (!me.DomainGroup.OrderBy(x => x).SequenceEqual(other.DomainGroup.OrderBy(x => x))) return false;

            if (!me.LastModifiedOn.Equals(other.LastModifiedOn)) return false;

            if (!me.LogEntry.OrderBy(x => x).SequenceEqual(other.LogEntry.OrderBy(x => x))) return false;

            if (!me.Model.OrderBy(x => x).SequenceEqual(other.Model.OrderBy(x => x))) return false;

            if (me.Name == null && other.Name != null) return false;
            if (me.Name != null && !me.Name.Equals(other.Name)) return false;

            if (!me.NaturalLanguage.OrderBy(x => x).SequenceEqual(other.NaturalLanguage.OrderBy(x => x))) return false;

            if (!me.Organization.OrderBy(x => x).SequenceEqual(other.Organization.OrderBy(x => x))) return false;

            if (!me.ParticipantRole.OrderBy(x => x).SequenceEqual(other.ParticipantRole.OrderBy(x => x))) return false;

            if (!me.Person.OrderBy(x => x).SequenceEqual(other.Person.OrderBy(x => x))) return false;

            if (!me.PersonRole.OrderBy(x => x).SequenceEqual(other.PersonRole.OrderBy(x => x))) return false;

            if (me.ShortName == null && other.ShortName != null) return false;
            if (me.ShortName != null && !me.ShortName.Equals(other.ShortName)) return false;

            if (!me.SiteReferenceDataLibrary.OrderBy(x => x).SequenceEqual(other.SiteReferenceDataLibrary.OrderBy(x => x))) return false;

            if (!me.Annotation.OrderBy(x => x).SequenceEqual(other.Annotation.OrderBy(x => x))) return false;

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
