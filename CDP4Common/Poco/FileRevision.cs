// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevision.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
    using System.Text;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="FileRevision"/>
    /// </summary>
    public partial class FileRevision
    {
        /// <summary>
        /// Returns the derived <see cref="Path"/> value
        /// </summary>
        /// <returns>The <see cref="Path"/> value</returns>
        protected string GetDerivedPath()
        {
            var path = new StringBuilder();
            var containingFolder = this.ContainingFolder;

            if (containingFolder != null)
            {
                path.Append(containingFolder.Path);
                path.Append("/");
                path.Append(this.ContainingFolder.Name);
                path.Append("/");
            }

            path.Append(this.Name);

            foreach (FileType fileType in this.FileType)
            {
                path.Append(".");
                path.Append(fileType.Extension);
            }

            return path.ToString();
        }
    }
}