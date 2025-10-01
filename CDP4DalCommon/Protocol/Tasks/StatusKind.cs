﻿// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusKind.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4DalCommon.Protocol.Tasks
{
    using System.Threading.Tasks;

    /// <summary>
    /// enumeration datatype that defines the possible states of a <see cref="Task"/>
    /// </summary>
    public enum StatusKind
    {
        /// <summary>
        /// Assertion that the Task is being processed
        /// </summary>
        PROCESSING,

        /// <summary>
        /// Assertion that the Task completed with success
        /// </summary>
        SUCCEEDED,

        /// <summary>
        /// Assertion that the Task failed
        /// </summary>
        FAILED,

        /// <summary>
        /// Assertion that the Task has been cancelled
        /// </summary>
        CANCELLED
    }
}
