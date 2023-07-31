// ------------------------------------------------------------------------------------------------
// <copyright file="SiteReferenceDataLibraryEquatable.cs" company="RHEA System S.A.">
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
 | 3     | baseQuantityKind                     | Guid                         | 0..*        |  1.0.0  |
 | 4     | baseUnit                             | Guid                         | 0..*        |  1.0.0  |
 | 5     | constant                             | Guid                         | 0..*        |  1.0.0  |
 | 6     | definedCategory                      | Guid                         | 0..*        |  1.0.0  |
 | 7     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 8     | fileType                             | Guid                         | 0..*        |  1.0.0  |
 | 9     | glossary                             | Guid                         | 0..*        |  1.0.0  |
 | 10    | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 11    | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 12    | name                                 | string                       | 1..1        |  1.0.0  |
 | 13    | parameterType                        | Guid                         | 0..*        |  1.0.0  |
 | 14    | referenceSource                      | Guid                         | 0..*        |  1.0.0  |
 | 15    | requiredRdl                          | Guid                         | 0..1        |  1.0.0  |
 | 16    | rule                                 | Guid                         | 0..*        |  1.0.0  |
 | 17    | scale                                | Guid                         | 0..*        |  1.0.0  |
 | 18    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 19    | unit                                 | Guid                         | 0..*        |  1.0.0  |
 | 20    | unitPrefix                           | Guid                         | 0..*        |  1.0.0  |
 | 21    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 22    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 23    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 24    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="SiteReferenceDataLibrary"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class SiteReferenceDataLibraryEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="SiteReferenceDataLibrary"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="SiteReferenceDataLibrary"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="SiteReferenceDataLibrary"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="SiteReferenceDataLibrary"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this SiteReferenceDataLibrary me, SiteReferenceDataLibrary other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.Alias.OrderBy(x => x).SequenceEqual(other.Alias.OrderBy(x => x))) return false;

            if (!me.BaseQuantityKind.OrderBy(x => x.K).Select(x => x.K).SequenceEqual(other.BaseQuantityKind.OrderBy(x => x.K).Select(x => x.K))) return false;
            if (!me.BaseQuantityKind.OrderBy(x => x.K).Select(x => x.V).SequenceEqual(other.BaseQuantityKind.OrderBy(x => x.K).Select(x => x.V))) return false;

            if (!me.BaseUnit.OrderBy(x => x).SequenceEqual(other.BaseUnit.OrderBy(x => x))) return false;

            if (!me.Constant.OrderBy(x => x).SequenceEqual(other.Constant.OrderBy(x => x))) return false;

            if (!me.DefinedCategory.OrderBy(x => x).SequenceEqual(other.DefinedCategory.OrderBy(x => x))) return false;

            if (!me.Definition.OrderBy(x => x).SequenceEqual(other.Definition.OrderBy(x => x))) return false;

            if (!me.FileType.OrderBy(x => x).SequenceEqual(other.FileType.OrderBy(x => x))) return false;

            if (!me.Glossary.OrderBy(x => x).SequenceEqual(other.Glossary.OrderBy(x => x))) return false;

            if (!me.HyperLink.OrderBy(x => x).SequenceEqual(other.HyperLink.OrderBy(x => x))) return false;

            if (!me.IsDeprecated.Equals(other.IsDeprecated)) return false;

            if (me.Name == null && other.Name != null) return false;
            if (me.Name != null && !me.Name.Equals(other.Name)) return false;

            if (!me.ParameterType.OrderBy(x => x).SequenceEqual(other.ParameterType.OrderBy(x => x))) return false;

            if (!me.ReferenceSource.OrderBy(x => x).SequenceEqual(other.ReferenceSource.OrderBy(x => x))) return false;

            if (!me.RequiredRdl.HasValue && other.RequiredRdl.HasValue) return false;
            if (!me.RequiredRdl.Equals(other.RequiredRdl)) return false;

            if (!me.Rule.OrderBy(x => x).SequenceEqual(other.Rule.OrderBy(x => x))) return false;

            if (!me.Scale.OrderBy(x => x).SequenceEqual(other.Scale.OrderBy(x => x))) return false;

            if (me.ShortName == null && other.ShortName != null) return false;
            if (me.ShortName != null && !me.ShortName.Equals(other.ShortName)) return false;

            if (!me.Unit.OrderBy(x => x).SequenceEqual(other.Unit.OrderBy(x => x))) return false;

            if (!me.UnitPrefix.OrderBy(x => x).SequenceEqual(other.UnitPrefix.OrderBy(x => x))) return false;

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
