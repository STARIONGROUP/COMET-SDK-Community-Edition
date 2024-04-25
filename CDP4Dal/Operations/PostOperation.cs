// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostOperation.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
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
    using System.Collections.Generic;
    using CDP4Common;
    using CDP4Common.Dto;
    using CDP4Common.DTO;

    /// <summary>
    /// The abstract super class from which all POST operations derive.
    /// </summary>
    public abstract class PostOperation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostOperation"/> class
        /// </summary>
        protected PostOperation()
        {
            this.Delete = new List<ClasslessDTO>();
            this.Create = new List<Thing>();
            this.Update = new List<ClasslessDTO>();
            this.Copy = new List<CopyInfo>();
        }

        /// <summary>
        /// Gets or sets the collection of DTOs to delete.
        /// </summary>
        public abstract List<ClasslessDTO> Delete { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to create.
        /// </summary>
        public abstract List<Thing> Create { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to update.
        /// </summary>
        public abstract List<ClasslessDTO> Update { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to copy.
        /// </summary>
        public abstract List<CopyInfo> Copy { get; set; }

        /// <summary>
        /// Populate the current <see cref="PostOperation"/> with the content based on the 
        /// provided <see cref="Operation"/>
        /// </summary>
        /// <param name="operation">
        ///     The <see cref="Operation"/> that contains all the <see cref="Thing"/>s that need to be
        ///     updated to the data-source
        /// </param>
        public abstract void ConstructFromOperation(Operation operation);
    }
}
