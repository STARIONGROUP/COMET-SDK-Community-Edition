// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileIO.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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

namespace CDP4JsonFileDal.Json
{
    using System.IO;

    /// <summary>
    /// The purpose of this class is to perform the writing and reading of local database exports of a SiteDirectory and EngineeringModel/Iteration combinations.
    /// </summary>
    public static class FileIO
    {
        /// <summary>
        /// Generates a <see cref="MemoryStream"/> from a string.
        /// </summary>
        /// <param name="s">
        /// The string to convert.
        /// </param>
        /// <returns>
        /// The <see cref="MemoryStream"/> generated from the string.
        /// </returns>
        public static MemoryStream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
