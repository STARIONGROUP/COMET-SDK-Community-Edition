#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InstanceNotFoundException.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4Dal.Exceptions
{
    using System;

    /// <summary>
    /// A <see cref="InstanceNotFoundException"/> is thrown the when a <see cref="Thing"/> cannot be found.
    /// </summary>
    public class InstanceNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceNotFoundException"/> class.
        /// </summary>
        public InstanceNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        public InstanceNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceNotFoundException"/> class.
        /// </summary>
        /// <param name="message">
        /// The exception message
        /// </param>
        /// <param name="innerException">
        /// A reference to the inner <see cref="Exception"/>
        /// </param>
        public InstanceNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
