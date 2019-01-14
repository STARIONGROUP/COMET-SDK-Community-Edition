// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTreeException.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

namespace CDP4Common.Exceptions
{
    using System;
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472
    using System.Runtime.Serialization;
#endif
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// A <see cref="NestedElementTreeException"/> is thrown when a problem occurs while
    /// generating the <see cref="NestedElement"/> Tree
    /// </summary>
    public class NestedElementTreeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElementTreeException"/> class.
        /// </summary>
        public NestedElementTreeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElementTreeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public NestedElementTreeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElementTreeException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public NestedElementTreeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472
        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElementTreeException"/> class.
        /// </summary>
        /// <param name="info">
        /// The serialization data
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>
        /// </param>
        protected NestedElementTreeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
