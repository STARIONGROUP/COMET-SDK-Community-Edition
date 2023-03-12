// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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

namespace CDP4Dal.Operations
{
    using CDP4Common.DTO;

    /// <summary>
    /// The change that is to be supplied to the data source via a Data-Access-Layer implementation
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class. 
        /// </summary>
        /// <param name="originalThing">
        /// The original <see cref="Thing"/> fom the local domain store.
        /// </param>
        /// <param name="modifiedThing">
        /// The modified <see cref="Thing"/>
        /// </param>
        /// <param name="operationKind">
        /// the kind of operation that is to be executed
        /// </param>
        public Operation(Thing originalThing, Thing modifiedThing, OperationKind operationKind)
        {
            this.OriginalThing = originalThing;
            this.ModifiedThing = modifiedThing;
            this.OperationKind = operationKind;
        }

        /// <summary>
        /// Gets the kind of operation represented by this <see cref="Operation"/> object.
        /// </summary>
        public OperationKind OperationKind { get; internal set; }

        /// <summary>
        /// Gets the original <see cref="Thing"/> that is the subject of the <see cref="Operation"/>.
        /// </summary>
        public Thing OriginalThing { get; internal set; }

        /// <summary>
        /// Gets the modified <see cref="Thing"/> that is the subject of the <see cref="Operation"/>.
        /// </summary>
        public Thing ModifiedThing { get; internal set; }
    }
}
