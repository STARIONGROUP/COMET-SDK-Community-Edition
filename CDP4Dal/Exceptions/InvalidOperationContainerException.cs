﻿// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidOperationContainerException.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Dal.Exceptions
{
    using System;

    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Operations;

    /// <summary>
    /// A <see cref="InvalidOperationContainerException"/> is thrown when an <see cref="OperationContainer"/> is invalid or incomplete,
    /// or one of the contained <see cref="Operation"/>s is invalid or incomplete.
    /// </summary>
    public class InvalidOperationContainerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationContainerException"/> class.
        /// </summary>
        public InvalidOperationContainerException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationContainerException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public InvalidOperationContainerException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationContainerException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public InvalidOperationContainerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
