// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PossibleRelationshipClassKind.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski, Omar Elebiary
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using CDP4Common.CommonData;
    using CDP4Common.DTO;

    /// <summary>
    /// Class representing the Array of <see cref="ClassKind"/>'s contained by <see cref= "Iteration"/> which can be used in
    /// a <see cref="Relationship"/>
    /// </summary>
    public static class PossibleRelationshipClassKind
    {
        /// <summary>
        /// Array consisting of <see cref="ClassKind"/>'s of <see cref="Thing"/>s that can be used in <see cref="Relationship"/>s.
        /// </summary>
        /// <remarks>
        /// The array does not contain any ClassKinds of abstract classes
        /// </remarks>
        public static readonly ClassKind[] ClassKindArray =
        {
            ClassKind.File,
            ClassKind.ElementDefinition,
            ClassKind.ElementUsage,
            ClassKind.Parameter,
            ClassKind.Requirement,
            ClassKind.SimpleParameterValue
        };
    }
}
