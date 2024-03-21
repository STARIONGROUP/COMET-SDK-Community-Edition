// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidOperationKindException.cs" company="RHEA System S.A.">
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

namespace CDP4Dal.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using CDP4Dal.DAL;

    using CDP4DalCommon.Protocol.Operations;

    /// <summary>
    /// A InvalidOperationKindException is thrown whenever an <see cref="CDP4Dal.Operations.OperationContainer"/> contains
    /// <see cref="Operation"/> that are not supported by the implementation of an <see cref="IDal"/>
    /// </summary>
    [Serializable]
    public class InvalidOperationKindException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationKindException"/> class.
        /// </summary>
        public InvalidOperationKindException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationKindException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public InvalidOperationKindException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationKindException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public InvalidOperationKindException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidOperationKindException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization data
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>
        /// </param>
        protected InvalidOperationKindException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
