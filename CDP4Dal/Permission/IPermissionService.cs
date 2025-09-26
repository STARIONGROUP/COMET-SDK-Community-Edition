﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPermissionService.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET SDK Community Edition
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
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Permission
{
    using System.ComponentModel;

    using CDP4Common.CommonData;

    /// <summary>
    /// The interface for services that handle permissions
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// Gets the <see cref="ISession"/> that these permission service are responsible for.
        /// </summary>
        ISession Session { get; }

        /// <summary>
        /// Returns whether a Read operation can be performed by the active user on the current <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read</param>
        /// <returns>True if a Read operation can be performed, false if not</returns>
        bool CanRead(Thing thing);

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to write</param>
        /// <returns>True if a Write operation can be performed, false it not</returns>
        bool CanWrite(Thing thing);

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="ClassKind"/>
        /// based on the supplied <see cref="Container"/>. The <see cref="ClassKind"/> ultimately determines the access. This method is primarily used for
        /// creation of a certain <see cref="Thing"/>.
        /// </summary>
        /// <param name="classKind">The <see cref="ClassKind"/> that ultimately determines the permissions.</param>
        /// <param name="containerThing">The <see cref="Thing"/> to write to</param>
        /// <returns>True if Write operation can be performed.</returns>
        bool CanWrite(ClassKind classKind, Thing containerThing);

        /// <summary>
        /// Normally permission to Create, Update or Delete is handled by the CanWrite methods.
        /// In some cases Create is allowed to be performed based on <see cref="PersonAccessRightKind"/>, but Update and Delete are not.
        /// This method is an extra method that can be performed to check if Create is allowed, based on the TopContainer <see cref="ClassKind"/>
        /// and the <see cref="ClassKind"/> of the <see cref="Thing"/> to create.
        /// </summary>
        /// <param name="classKind">The <see cref="ClassKind"/> that ultimately determines the permissions.</param>
        /// <param name="containerClassKind">The <see cref="ClassKind"/> of the top container class where to create the classKind</param>
        /// <returns>True if Create operation can be performed.</returns>
        bool CanCreateOverride(ClassKind classKind, ClassKind containerClassKind);
    }
}