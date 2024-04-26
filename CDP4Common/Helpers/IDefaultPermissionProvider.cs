// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDefaultPermissionProvider.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
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

namespace CDP4Common.Helpers
{
    using System;
    using CDP4Common.CommonData;

    /// <summary>
    /// Default permission Utils interface.
    /// </summary>
    public interface IDefaultPermissionProvider
    {
        /// <summary>
        /// Return the default <see cref="ParticipantAccessRightKind"/> for the supplied <see cref="ClassKind"/>.
        /// </summary>
        /// <param name="classKind">
        /// The <see cref="ClassKind"/> for which the <see cref="ParticipantAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="ParticipantAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the <see cref="ClassKind"/> is not found, this should never happen
        /// </exception>
        ParticipantAccessRightKind GetDefaultParticipantPermission(ClassKind classKind);

        /// <summary>
        /// Return the default <see cref="ParticipantAccessRightKind"/> for the supplied type.
        /// </summary>
        /// <param name="typeName">
        /// The type name for which the <see cref="ParticipantAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="ParticipantAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If type not found, this should never happen
        /// </exception>
        ParticipantAccessRightKind GetDefaultParticipantPermission(string typeName);
        
        /// <summary>
        /// Return the default <see cref="PersonAccessRightKind"/> for the supplied ClassKind.
        /// </summary>
        /// <param name="classKind">
        /// The <see cref="ClassKind"/> for which the <see cref="PersonAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="PersonAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the <see cref="ClassKind"/> is not found, this should never happen
        /// </exception>
        PersonAccessRightKind GetDefaultPersonPermission(ClassKind classKind);

        /// <summary>
        /// Return the default <see cref="PersonAccessRightKind"/> for the supplied type.
        /// </summary>
        /// <param name="typeName">
        /// The type name for which the <see cref="PersonAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="PersonAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If type not found, this should never happen
        /// </exception>
        PersonAccessRightKind GetDefaultPersonPermission(string typeName);
    }
}
