﻿// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4ModelValidationException.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.Exceptions
{
    using System;

    /// <summary>
    /// The CDP4 model validation exception.
    /// </summary>
    public class Cdp4ModelValidationException : ModelErrorException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4ModelValidationException"/> class.
        /// </summary>
        public Cdp4ModelValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4ModelValidationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public Cdp4ModelValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4ModelValidationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public Cdp4ModelValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
