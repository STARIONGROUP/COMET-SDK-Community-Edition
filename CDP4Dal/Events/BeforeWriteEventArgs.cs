// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BeforeWriteEventArgs.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Dal.Events
{
    using System;
    using System.Collections.Generic;

    using CDP4Dal.Operations;

    /// <summary>
    /// Holds <see cref="EventArgs"/> data for a BeforeWrite event.
    /// </summary>
    public class BeforeWriteEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the <see cref="Operations.OperationContainer"/> that contains all operations to be performed on the <see cref="ISession"/>'s write method.
        /// </summary>
        public OperationContainer OperationContainer { get; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> of the <see cref="string"/> type that contains filenames to be upload to the data store
        /// </summary>
        public IEnumerable<string> Files { get; }

        /// <summary>
        /// Gets or sets an indication if the event was cancelled. If so, then also the <see cref="ISession"/>'s write method should be cancelled.
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="BeforeWriteEventArgs"/> class.
        /// </summary>
        /// <param name="operationContainer">
        /// The <see cref="OperationContainer"/> that contains all operations to be performed on the <see cref="ISession"/>'s write method.
        /// </param>
        /// <param name="files">
        /// An <see cref="IEnumerable{T}"/> of the <see cref="string"/> type that contains filenames to be upload to the data store
        /// </param>
        public BeforeWriteEventArgs(OperationContainer operationContainer, IEnumerable<string> files)
        {
            this.OperationContainer = operationContainer;
            this.Files = files;
        }
    }
}
