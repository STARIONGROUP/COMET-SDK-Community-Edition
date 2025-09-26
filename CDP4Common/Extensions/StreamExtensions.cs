// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4Common.Extensions
{
    using System.IO;
    
    using ICSharpCode.SharpZipLib.Zip;

    /// <summary>
    /// A class containing extension methods for <see cref="Stream"/> objects
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Create a <see cref="ZipOutputStream"/> to create an encrypted zip file
        /// </summary>
        /// <param name="inputStream">The input <see cref="Stream"/> to write to</param>
        /// <param name="password">The password to be used to protect the data</param>
        /// <returns>The created <see cref="ZipOutputStream"/></returns>
        public static ZipOutputStream CreateEncryptableZipOutputStream(this Stream inputStream, string password)
        {
            var zipStream = new ZipOutputStream(inputStream);
            zipStream.Password = password;
            zipStream.IsStreamOwner = true; // underlying streams will be forcibly closed

            return zipStream;
        }
    }
}
