// ------------------------------------------------------------------------------------------------
// <copyright file="ActionItemEquatable.cs" company="RHEA System S.A.">
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
 | 2     | actionee                             | Guid                         | 1..1        |  1.1.0  |
 | 3     | approvedBy                           | Guid                         | 0..*        |  1.1.0  |
 | 4     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 5     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 6     | classification                       | AnnotationClassificationKind | 1..1        |  1.1.0  |
 | 7     | closeOutDate                         | DateTime                     | 0..1        |  1.1.0  |
 | 8     | closeOutStatement                    | string                       | 0..1        |  1.1.0  |
 | 9     | content                              | string                       | 1..1        |  1.1.0  |
 | 10    | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 11    | discussion                           | Guid                         | 0..*        |  1.1.0  |
 | 12    | dueDate                              | DateTime                     | 1..1        |  1.1.0  |
 | 13    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 16    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 17    | owner                                | Guid                         | 1..1        |  1.1.0  |
 | 18    | primaryAnnotatedThing                | Guid                         | 0..1        |  1.1.0  |
 | 19    | relatedThing                         | Guid                         | 0..*        |  1.1.0  |
 | 20    | shortName                            | string                       | 1..1        |  1.1.0  |
 | 21    | sourceAnnotation                     | Guid                         | 0..*        |  1.1.0  |
 | 22    | status                               | AnnotationStatusKind         | 1..1        |  1.1.0  |
 | 23    | title                                | string                       | 1..1        |  1.1.0  |
 | 24    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 25    | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="ActionItem"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class ActionItemEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="ActionItem"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="ActionItem"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="ActionItem"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="ActionItem"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this ActionItem me, ActionItem other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.Actionee.Equals(other.Actionee)) return false;

            if (!me.ApprovedBy.OrderBy(x => x).SequenceEqual(other.ApprovedBy.OrderBy(x => x))) return false;

            if (!me.Author.Equals(other.Author)) return false;

            if (!me.Category.OrderBy(x => x).SequenceEqual(other.Category.OrderBy(x => x))) return false;

            if (!me.Classification.Equals(other.Classification)) return false;

            if (me.CloseOutDate.HasValue != other.CloseOutDate.HasValue) return false;
            if (!me.CloseOutDate.Equals(other.CloseOutDate)) return false;

            if (me.CloseOutStatement == null && other.CloseOutStatement != null) return false;
            if (me.CloseOutStatement != null && !me.CloseOutStatement.Equals(other.CloseOutStatement)) return false;

            if (me.Content == null && other.Content != null) return false;
            if (me.Content != null && !me.Content.Equals(other.Content)) return false;

            if (!me.CreatedOn.Equals(other.CreatedOn)) return false;

            if (!me.Discussion.OrderBy(x => x).SequenceEqual(other.Discussion.OrderBy(x => x))) return false;

            if (!me.DueDate.Equals(other.DueDate)) return false;

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

            if (me.Actor.HasValue != other.Actor.HasValue) return false;
            if (!me.Actor.Equals(other.Actor)) return false;

            return true;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
