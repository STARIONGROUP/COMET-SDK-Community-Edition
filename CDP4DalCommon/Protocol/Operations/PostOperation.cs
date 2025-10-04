// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PostOperation.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4DalCommon.Protocol.Operations
{
    using System;
    using System.Collections.Generic;

    using CDP4Common;
    using CDP4Common.Dto;
    using CDP4Common.DTO;

    /// <summary>
    /// The abstract super class from which all POST operations derive.
    /// </summary>
    public class PostOperation
    {
        private List<ClasslessDTO> delete = [];
        private List<Thing> create = [];
        private List<ClasslessDTO> update = [];
        private List<CopyInfo> copy = [];

        /// <summary>
        /// Gets or sets the collection of DTOs to delete.
        /// </summary>
        public List<ClasslessDTO> Delete
        {
            get => this.delete ?? [];
            set => this.delete = value ?? [];
        }

        /// <summary>
        /// Gets or sets the collection of DTOs to create.
        /// </summary>
        public List<Thing> Create
        {
            get => this.create ?? [];
            set => this.create = value ?? [];
        }

        /// <summary>
        /// Gets or sets the collection of DTOs to update.
        /// </summary>
        public List<ClasslessDTO> Update
        {
            get => this.update ?? [];
            set => this.update = value ?? [];
        }

        /// <summary>
        /// Gets or sets the collection of DTOs to copy.
        /// </summary>
        public List<CopyInfo> Copy
        {
            get => this.copy ?? [];
            set => this.copy = value ?? [];
        }

        /// <summary>
        /// Populate the current <see cref="PostOperation"/> with the content based on the 
        /// provided <see cref="Operation"/>
        /// </summary>
        /// <param name="operation">
        ///     The <see cref="Operation"/> that contains all the <see cref="Thing"/>s that need to be
        ///     updated to the data-source
        /// </param>
        public virtual void ConstructFromOperation(Operation operation)
        {
            throw new NotSupportedException("Cannot construct a PostOperation based on Operation");
        }
    }
}
