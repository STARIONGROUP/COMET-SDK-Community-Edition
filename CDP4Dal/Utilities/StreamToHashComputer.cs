// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StreamToHashComputer.cs" company="Starion Group S.A.">
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

namespace CDP4Dal
{
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    
    /// <summary>
    /// The purpose of the <see cref="StreamToHashComputer"/> class is to
    /// compute a hash of a stream.
    /// </summary>
    public static class StreamToHashComputer
    {
        /// <summary>
        /// Calculate the SHA1 hash from a stream.
        /// </summary>
        /// <param name="stream">
        /// The stream for which to calculate the hash.
        /// </param>
        /// <returns>
        /// The hexadecimal string representation of a SHA-1 hash code.
        /// </returns>
        public static string CalculateSha1HashFromStream(Stream stream)
        {
            using (var bufferedStream = new BufferedStream(stream))
            {
                using (var sha1 = new SHA1Managed())
                {
                    var hash = sha1.ComputeHash(bufferedStream);
                    var formatted = new StringBuilder(2 * hash.Length);
                    hash.ToList().ForEach(b => formatted.AppendFormat("{0:X2}", b));
                    return formatted.ToString();
                }
            }
        }
    }
}