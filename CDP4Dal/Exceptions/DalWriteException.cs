// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DalWriteException.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexandervan Delft, Nathanael Smiechowski, Ahmed Abulwafa Ahmed
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
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

    using CDP4Common.Exceptions;

    /// <summary>
    /// A <see cref="DalWriteException"/> is thrown the when a during a Write operation the data-source
    /// returns an exception
    /// </summary>
    public class DalWriteException : Exception, IHaveCDPErrorTag
    {
        /// <summary>
        /// Gets or sets the CDPErrorTag (error code), typically found in the CDPErrorTag header of a CDP4-COMET Webservice http response
        /// </summary>
        public string CDPErrorTag { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="DalWriteException"/> class.
        /// </summary>
        public DalWriteException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalWriteException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public DalWriteException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DalWriteException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public DalWriteException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
