// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILocalFile.cs" company="RHEA System S.A.">
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

namespace CDP4Common
{
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// An interface for classes containing data that's needed in a file upload scenario.
    /// Typically used for <see cref="FileRevision"/> objects.
    /// </summary>
    public interface ILocalFile
    {
        /// <summary>
        /// Contains the path of the file in the context of the User's PC
        /// </summary>
        string LocalPath { get; }

        /// <summary>
        /// Gets or sets the ContentHash.
        /// </summary>
        /// <remarks>
        /// SHA-1 hash code of the content (byte stream) of this object
        /// Note: The SHA-1 cryptographic hash is described in <a href="http://en.wikipedia.org/wiki/SHA-1">http://en.wikipedia.org/wiki/SHA-1</a>. It provides a unique hash to the file content of the file and was selected for future compatibility with a GIT (<a href="http://git-scm.com/">http://git-scm.com/</a>) version controlled file store. Implementations of E-TM-10-25 need to provide a way to associate a SHA-1 hash to the content of a file. Whether or not the content of two FileRevisions differs can then be determined by just comparing the SHA-1 hashes without the need for having access to the actual file content itself.
        /// </remarks>
        string ContentHash { get; }
    }
}
