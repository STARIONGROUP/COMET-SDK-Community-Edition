// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevision.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Linq;

    /// <summary>
    /// Extended part for the auto-generated <see cref="File"/>
    /// </summary>
    public partial class File
    {
        /// <summary>
        /// Backing field for <see cref="CurrentContainingFolder"/>
        /// </summary>
        private Folder currentContainingFolder;

        /// <summary>
        /// Gets or sets the currently known ContainingFolder of the file
        /// </summary>
        public Folder CurrentContainingFolder {
            get { return this.FileRevision.Any() ? this.FileRevision.OrderByDescending(x => x.CreatedOn).First().ContainingFolder : this.currentContainingFolder; }
            set
            {
                if (this.FileRevision.Any())
                {
                    throw new InvalidOperationException($"Setting the {nameof(this.CurrentContainingFolder)} property is not allowed when the {this.FileRevision} property contains data");
                }

                this.currentContainingFolder = value;
            }
        }

        /// <summary>
        /// The current active <see cref="EngineeringModelData.FileRevision"/> which is the the last added FileRevision to the <see cref="FileRevision"/> property 
        /// </summary>
        public FileRevision CurrentFileRevision => 
            this.FileRevision
                .OrderByDescending(x => x.CreatedOn)
                .ThenByDescending(x => x.RevisionNumber)
                .ThenBy(x => x.Iid)
                .FirstOrDefault();
    }
}