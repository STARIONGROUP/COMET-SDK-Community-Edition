// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticDefaultPermissionProvider.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Helpers
{
    using System;
    using CommonData;

    /// <summary>
    /// A static utility class to retrieve the default permission for a <see cref="Thing"/>
    /// </summary>
    public static class StaticDefaultPermissionProvider
    {
        /// <summary>
        /// The <see cref="DefaultPermissionProvider"/>
        /// </summary>
        private static DefaultPermissionProvider provider = new DefaultPermissionProvider();

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
        public static ParticipantAccessRightKind GetDefaultParticipantPermission(string typeName)
        {
            return provider.GetDefaultParticipantPermission(typeName);
        }

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
        public static PersonAccessRightKind GetDefaultPersonPermission(string typeName)
        {
            return provider.GetDefaultPersonPermission(typeName);
        }
    }
}