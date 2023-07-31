// ------------------------------------------------------------------------------------------------
// <copyright file="RequestForWaiverEquatable.cs" company="RHEA System S.A.">
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
 | 2     | approvedBy                           | Guid                         | 0..*        |  1.1.0  |
 | 3     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 4     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 5     | classification                       | AnnotationClassificationKind | 1..1        |  1.1.0  |
 | 6     | content                              | string                       | 1..1        |  1.1.0  |
 | 7     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 8     | discussion                           | Guid                         | 0..*        |  1.1.0  |
 | 9     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | owner                                | Guid                         | 1..1        |  1.1.0  |
 | 14    | primaryAnnotatedThing                | Guid                         | 0..1        |  1.1.0  |
 | 15    | relatedThing                         | Guid                         | 0..*        |  1.1.0  |
 | 16    | shortName                            | string                       | 1..1        |  1.1.0  |
 | 17    | sourceAnnotation                     | Guid                         | 0..*        |  1.1.0  |
 | 18    | status                               | AnnotationStatusKind         | 1..1        |  1.1.0  |
 | 19    | title                                | string                       | 1..1        |  1.1.0  |
 | 20    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="RequestForWaiver"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class RequestForWaiverEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="RequestForWaiver"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="RequestForWaiver"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="RequestForWaiver"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="RequestForWaiver"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this RequestForWaiver me, RequestForWaiver other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.ApprovedBy.OrderBy(x => x).SequenceEqual(other.ApprovedBy.OrderBy(x => x))) return false;

            if (!me.Author.Equals(other.Author)) return false;

            if (!me.Category.OrderBy(x => x).SequenceEqual(other.Category.OrderBy(x => x))) return false;

            if (!me.Classification.Equals(other.Classification)) return false;

            if (me.Content == null && other.Content != null) return false;
            if (me.Content != null && !me.Content.Equals(other.Content)) return false;

            if (!me.CreatedOn.Equals(other.CreatedOn)) return false;

            if (!me.Discussion.OrderBy(x => x).SequenceEqual(other.Discussion.OrderBy(x => x))) return false;

            if (!me.ExcludedDomain.OrderBy(x => x).SequenceEqual(other.ExcludedDomain.OrderBy(x => x))) return false;

            if (!me.ExcludedPerson.OrderBy(x => x).SequenceEqual(other.ExcludedPerson.OrderBy(x => x))) return false;

            if (me.LanguageCode == null && other.LanguageCode != null) return false;
            if (me.LanguageCode != null && !me.LanguageCode.Equals(other.LanguageCode)) return false;

            if (!me.ModifiedOn.Equals(other.ModifiedOn)) return false;

            if (!me.Owner.Equals(other.Owner)) return false;

            if (me.PrimaryAnnotatedThing.HasValue != other.PrimaryAnnotatedThing.HasValue) return false;
            if (!me.PrimaryAnnotatedThing.Equals(other.PrimaryAnnotatedThing)) return false;

            if (!me.RelatedThing.OrderBy(x => x).SequenceEqual(other.RelatedThing.OrderBy(x => x))) return false;

            if (me.ShortName == null && other.ShortName != null) return false;
            if (me.ShortName != null && !me.ShortName.Equals(other.ShortName)) return false;

            if (!me.SourceAnnotation.OrderBy(x => x).SequenceEqual(other.SourceAnnotation.OrderBy(x => x))) return false;

            if (!me.Status.Equals(other.Status)) return false;

            if (me.Title == null && other.Title != null) return false;
            if (me.Title != null && !me.Title.Equals(other.Title)) return false;

            if (me.ThingPreference == null && other.ThingPreference != null) return false;
            if (me.ThingPreference != null && !me.ThingPreference.Equals(other.ThingPreference)) return false;

            return true;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
