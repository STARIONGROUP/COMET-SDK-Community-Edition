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
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extended part for the auto-generated <see cref="FileRevision"/>
    /// </summary>
    public partial class FileRevision : ILocalFile
    {
        /// <summary>
        /// Returns the derived <see cref="Path"/> value
        /// </summary>
        /// <returns>The <see cref="Path"/> value</returns>
        private string GetDerivedPath()
        {
            var path = new StringBuilder();

            if (this.ContainingFolder != null)
            {
                path.Append(this.ContainingFolder.Path);
                path.Append("/");
                path.Append(this.ContainingFolder.Name);
                path.Append("/");
            }

            path.Append(this.Name);

            foreach (var fileType in this.FileType.Where(x => !string.IsNullOrWhiteSpace(x.Extension)))
            {
                path.Append(".");
                path.Append(fileType.Extension);
            }

            return path.ToString();
        }

        /// <summary>
        /// Gets or sets the (temporary) LocalPath of the file
        /// </summary>
        public string LocalPath { get; set; }
    }
}