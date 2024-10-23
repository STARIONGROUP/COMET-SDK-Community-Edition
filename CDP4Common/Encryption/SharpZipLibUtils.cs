// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SharpZipLibHelper.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Common.Encryption
{
    using System.IO;
    
    using ICSharpCode.SharpZipLib.Zip;

    /// <summary>
    /// A class containing Helper Methods for working with SharpZipLib and creating AES 256 encrypted zip files
    /// </summary>
    public static class SharpZipLibUtils
    {
        /// <summary>
        /// Create a <see cref="ZipOutputStream"/> to create a AES 256 encrypted zip file
        /// </summary>
        /// <param name="inputStream">The input <see cref="Stream"/> to write to</param>
        /// <param name="password">The password to be used to protect the data</param>
        /// <returns>The created <see cref="ZipOutputStream"/></returns>
        public static ZipOutputStream CreateZipOutputStream(Stream inputStream, string password)
        {
            var zipStream = new ZipOutputStream(inputStream);
            zipStream.Password = password;
            zipStream.IsStreamOwner = true; // underlying streams will be forcibly closed

            return zipStream;
        }

        /// <summary>
        /// Add a <see cref="ZipEntry"/> and add it to a <see cref="ZipOutputStream"/>
        /// </summary>
        /// <param name="zipOutputStream">The <see cref="ZipOutputStream"/></param>
        /// <param name="stream">The input <see cref="Stream"/> from which to create the <see cref="ZipEntry"/></param>
        /// <param name="name">The name of the entry, including (sub)folder information</param>
        public static void AddEntryFromStream(ZipOutputStream zipOutputStream, Stream stream, string name)
        {
            if (stream.Length == 0)
            {
                return;
            }

            var entry = new ZipEntry(name)
            {
                AESKeySize = 256, // Set AES encryption to 256 bits for each individual entry
            };

            zipOutputStream.PutNextEntry(entry);
            stream.Flush();
            stream.Position = 0;
            stream.CopyTo(zipOutputStream);
            zipOutputStream.CloseEntry();
        }

        /// <summary>
        /// Add a file as a <see cref="ZipEntry"/> to an existing <see cref="ZipOutputStream"/>
        /// </summary>
        /// <param name="zipOutputStream">The <see cref="ZipOutputStream"/></param>
        /// <param name="extraFile">The location of the file to add</param>
        /// <param name="entryLocation">The location (fullname) of the file to create in the <see cref="ZipOutputStream"/>, including (sub)folder information</param>
        public static void AddEntryFromFile(ZipOutputStream zipOutputStream, string extraFile, string entryLocation)
        {
            var entry = new ZipEntry(entryLocation)
            {
                AESKeySize = 256, // Set AES encryption to 256 bits
            };

            zipOutputStream.PutNextEntry(entry);

            using (var fileStream = File.OpenRead(extraFile))
            {
                fileStream.CopyTo(zipOutputStream);
            }

            zipOutputStream.CloseEntry();
        }
    }
}
