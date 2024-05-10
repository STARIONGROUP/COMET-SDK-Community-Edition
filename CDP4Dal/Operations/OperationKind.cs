// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationKind.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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

namespace CDP4Dal.Operations
{
    using CDP4Common.DTO;

    /// <summary>
    /// The kind of <see cref="Operation"/> acting on the object.
    /// </summary>
    public enum OperationKind
    {
        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a Create operation
        /// </summary>
        Create,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is an Update operation
        /// </summary>
        Update,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a Delete operation
        /// </summary>
        Delete,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a Move operation
        /// </summary>
        Move,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a "shift" Copy operation
        /// </summary>
        /// <remarks>
        /// If <see cref="ParameterBase"/> are copied their value-sets shall contain default "-" values.
        /// A copy <see cref="IOwnedThing"/> shall keep its original owner
        /// </remarks>
        Copy,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a "ctrl" Copy operation
        /// </summary>
        /// <remarks>
        /// If <see cref="ParameterBase"/> are copied their value-sets shall contain original values.
        /// A copy <see cref="IOwnedThing"/> shall have its owner set to the active one in the target destination.
        /// </remarks>
        CopyKeepValuesChangeOwner,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a "dry" Copy operation
        /// </summary>
        /// <remarks>
        /// If <see cref="ParameterBase"/> are copied their value-sets shall contain default "-" values.
        /// A copy <see cref="IOwnedThing"/> shall have its owner set to the active one in the target destination.
        /// </remarks>
        CopyDefaultValuesChangeOwner,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a "ctrl + shift" Copy operation
        /// </summary>
        /// <remarks>
        /// If <see cref="ParameterBase"/> are copied their value-sets shall contain the original values.
        /// A copy <see cref="IOwnedThing"/> shall keep its original owner
        /// </remarks>
        CopyKeepValues
    }
}