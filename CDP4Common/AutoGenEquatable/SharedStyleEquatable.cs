// ------------------------------------------------------------------------------------------------
// <copyright file="SharedStyleEquatable.cs" company="Starion Group S.A.">
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
 | 4     | fillColor                            | Guid                         | 0..1        |  1.1.0  |
 | 5     | fillOpacity                          | float                        | 0..1        |  1.1.0  |
 | 6     | fontBold                             | bool                         | 0..1        |  1.1.0  |
 | 7     | fontColor                            | Guid                         | 0..1        |  1.1.0  |
 | 8     | fontItalic                           | bool                         | 0..1        |  1.1.0  |
 | 9     | fontName                             | string                       | 0..1        |  1.1.0  |
 | 10    | fontSize                             | float                        | 0..1        |  1.1.0  |
 | 11    | fontStrokeThrough                    | bool                         | 0..1        |  1.1.0  |
 | 12    | fontUnderline                        | bool                         | 0..1        |  1.1.0  |
 | 13    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 14    | name                                 | string                       | 1..1        |  1.1.0  |
 | 15    | strokeColor                          | Guid                         | 0..1        |  1.1.0  |
 | 16    | strokeOpacity                        | float                        | 0..1        |  1.1.0  |
 | 17    | strokeWidth                          | float                        | 0..1        |  1.1.0  |
 | 18    | usedColor                            | Guid                         | 0..*        |  1.1.0  |
 | 19    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 20    | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="SharedStyle"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class SharedStyleEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="SharedStyle"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="SharedStyle"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="SharedStyle"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="SharedStyle"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this SharedStyle me, SharedStyle other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.ExcludedDomain.OrderBy(x => x).SequenceEqual(other.ExcludedDomain.OrderBy(x => x))) return false;

            if (!me.ExcludedPerson.OrderBy(x => x).SequenceEqual(other.ExcludedPerson.OrderBy(x => x))) return false;

            if (me.FillColor.HasValue != other.FillColor.HasValue) return false;
            if (!me.FillColor.Equals(other.FillColor)) return false;

            if (me.FillOpacity.HasValue != other.FillOpacity.HasValue) return false;
            if (!me.FillOpacity.Equals(other.FillOpacity)) return false;

            if (me.FontBold.HasValue != other.FontBold.HasValue) return false;
            if (!me.FontBold.Equals(other.FontBold)) return false;

            if (me.FontColor.HasValue != other.FontColor.HasValue) return false;
            if (!me.FontColor.Equals(other.FontColor)) return false;

            if (me.FontItalic.HasValue != other.FontItalic.HasValue) return false;
            if (!me.FontItalic.Equals(other.FontItalic)) return false;

            if (me.FontName == null && other.FontName != null) return false;
            if (me.FontName != null && !me.FontName.Equals(other.FontName)) return false;

            if (me.FontSize.HasValue != other.FontSize.HasValue) return false;
            if (!me.FontSize.Equals(other.FontSize)) return false;

            if (me.FontStrokeThrough.HasValue != other.FontStrokeThrough.HasValue) return false;
            if (!me.FontStrokeThrough.Equals(other.FontStrokeThrough)) return false;

            if (me.FontUnderline.HasValue != other.FontUnderline.HasValue) return false;
            if (!me.FontUnderline.Equals(other.FontUnderline)) return false;

            if (!me.ModifiedOn.Equals(other.ModifiedOn)) return false;

            if (me.Name == null && other.Name != null) return false;
            if (me.Name != null && !me.Name.Equals(other.Name)) return false;

            if (me.StrokeColor.HasValue != other.StrokeColor.HasValue) return false;
            if (!me.StrokeColor.Equals(other.StrokeColor)) return false;

            if (me.StrokeOpacity.HasValue != other.StrokeOpacity.HasValue) return false;
            if (!me.StrokeOpacity.Equals(other.StrokeOpacity)) return false;

            if (me.StrokeWidth.HasValue != other.StrokeWidth.HasValue) return false;
            if (!me.StrokeWidth.Equals(other.StrokeWidth)) return false;

            if (!me.UsedColor.OrderBy(x => x).SequenceEqual(other.UsedColor.OrderBy(x => x))) return false;

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
