// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PartitionDependentContainmentClassType.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Mihail Militaru,
//            Nathanael Smiechowski, Kamil Wojnowski
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using CDP4Common.CommonData;
    using CDP4Common.DTO;

    /// <summary>
    /// Class representing the Array of <see cref="ClassKind"/>'s that can be contained by <see cref= "EngineeringModel"/> and <see cref= "Iteration" />
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
        public static readonly ClassKind[] ClassKindArray = new[] {
            ClassKind.File,
            ClassKind.FileRevision,
            ClassKind.Folder,
        };
    }
}
