// ------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetupEquatable.cs" company="Starion Group S.A.">
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
 | 2     | activeDomain                         | Guid                         | 1..*        |  1.0.0  |
 | 3     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | engineeringModelIid                  | Guid                         | 1..1        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | iterationSetup                       | Guid                         | 1..*        |  1.0.0  |
 | 8     | kind                                 | EngineeringModelKind         | 1..1        |  1.0.0  |
 | 9     | name                                 | string                       | 1..1        |  1.0.0  |
 | 10    | participant                          | Guid                         | 1..*        |  1.0.0  |
 | 11    | requiredRdl                          | Guid                         | 1..1        |  1.0.0  |
 | 12    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 13    | sourceEngineeringModelSetupIid       | Guid                         | 0..1        |  1.0.0  |
 | 14    | studyPhase                           | StudyPhaseKind               | 1..1        |  1.0.0  |
 | 15    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 16    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 17    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 18    | defaultOrganizationalParticipant     | Guid                         | 0..1        |  1.2.0  |
 | 19    | organizationalParticipant            | Guid                         | 0..*        |  1.2.0  |
 | 20    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 21    | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4Common.DTO.Equatable
{
    using System.Linq;

    using CDP4Common.DTO;

    /// <summary>
    /// An extension class for the <see cref="EngineeringModelSetup"/> to support the computation
    /// of property based equality
    /// </summary>
    public static class EngineeringModelSetupEquatable
    {
        /// <summary>
        /// Determines whether 2 <see cref="EngineeringModelSetup"/> objects are the same
        /// by comparing all the properties
        /// </summary>
        /// <param name="me">
        /// The current <see cref="EngineeringModelSetup"/>
        /// </param>
        /// <param name="other">
        /// The <see cref="EngineeringModelSetup"/> that the <paramref name="me"/> is
        /// compared to
        /// </param>
        /// <returns>
        /// returns true when all the properties of the <see cref="EngineeringModelSetup"/> objects
        /// have the same value
        /// </returns>
        public static bool ArePropertiesEqual(this EngineeringModelSetup me, EngineeringModelSetup other)
        {
            if (me == null && other == null) return true;

            if (me == null || other == null) return false;

            if (!me.Iid.Equals(other.Iid)) return false;

            if (!me.RevisionNumber.Equals(other.RevisionNumber)) return false;

            if (!me.ActiveDomain.OrderBy(x => x).SequenceEqual(other.ActiveDomain.OrderBy(x => x))) return false;

            if (!me.Alias.OrderBy(x => x).SequenceEqual(other.Alias.OrderBy(x => x))) return false;

            if (!me.Definition.OrderBy(x => x).SequenceEqual(other.Definition.OrderBy(x => x))) return false;

            if (!me.EngineeringModelIid.Equals(other.EngineeringModelIid)) return false;

            if (!me.HyperLink.OrderBy(x => x).SequenceEqual(other.HyperLink.OrderBy(x => x))) return false;

            if (!me.IterationSetup.OrderBy(x => x).SequenceEqual(other.IterationSetup.OrderBy(x => x))) return false;

            if (!me.Kind.Equals(other.Kind)) return false;

            if (me.Name == null && other.Name != null) return false;
            if (me.Name != null && !me.Name.Equals(other.Name)) return false;

            if (!me.Participant.OrderBy(x => x).SequenceEqual(other.Participant.OrderBy(x => x))) return false;

            if (!me.RequiredRdl.OrderBy(x => x).SequenceEqual(other.RequiredRdl.OrderBy(x => x))) return false;

            if (me.ShortName == null && other.ShortName != null) return false;
            if (me.ShortName != null && !me.ShortName.Equals(other.ShortName)) return false;

            if (me.SourceEngineeringModelSetupIid.HasValue != other.SourceEngineeringModelSetupIid.HasValue) return false;
            if (!me.SourceEngineeringModelSetupIid.Equals(other.SourceEngineeringModelSetupIid)) return false;

            if (!me.StudyPhase.Equals(other.StudyPhase)) return false;

            if (!me.ExcludedDomain.OrderBy(x => x).SequenceEqual(other.ExcludedDomain.OrderBy(x => x))) return false;

            if (!me.ExcludedPerson.OrderBy(x => x).SequenceEqual(other.ExcludedPerson.OrderBy(x => x))) return false;

            if (!me.ModifiedOn.Equals(other.ModifiedOn)) return false;

            if (me.DefaultOrganizationalParticipant.HasValue != other.DefaultOrganizationalParticipant.HasValue) return false;
            if (!me.DefaultOrganizationalParticipant.Equals(other.DefaultOrganizationalParticipant)) return false;

            if (!me.OrganizationalParticipant.OrderBy(x => x).SequenceEqual(other.OrganizationalParticipant.OrderBy(x => x))) return false;

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
