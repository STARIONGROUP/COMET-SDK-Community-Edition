// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartitionDependentContainmentClassType.cs" company="Starion Group S.A.">
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
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using CDP4Common.CommonData;
    using CDP4Common.DTO;

    /// <summary>
    /// Class representing arrays of <see cref="ClassKind"/>'s that can be contained by through a composite aggregation of more that one (TopContainer) class and its subtree.
    /// </summary>
    public static class PartitionDependentContainmentClassType
    {
        /// <summary>
        /// Array consisting of <see cref="ClassKind"/>'s which are contained through a composite aggregation by <see cref= "EngineeringModel"/> and 
        /// it's subtree, excluding the subtree of the <see cref="Iteration"/> class, but can ALSO be contained by through a composite aggregation
        /// by <see cref= "Iteration"/> and it's subtree.
        /// </summary>
        /// <remarks>
        /// The array does not contain any ClassKinds of abstract classes
        /// </remarks>
        public static readonly ClassKind[] EngineeringModelAndIterationClassKindArray = new[] {

            ClassKind.File,

            ClassKind.FileRevision,

            ClassKind.Folder,

        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
