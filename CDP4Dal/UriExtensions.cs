// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UriExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Nathanael Smiechowski
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
    using System;

    /// <summary>
    /// Utils class to provide UriExtensions to CDP4Dal
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Asserts that the uri is following the http or https schema.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <exception cref="ArgumentException">
        /// If the <see cref="Uri"/> is not either a HTTP or a HTTPS schema, this exception is thrown.
        /// </exception>
        public static void AssertUriIsHttpOrHttpsSchema(this Uri uri)
        {
            if (!(uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                throw new ArgumentException($"Invalid URI scheme for: {uri}");
            }
        }

        /// <summary>
        /// Asserts that the uri is following the file schema.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <exception cref="ArgumentException">
        /// If the <see cref="Uri"/> is not File schema, this exception is thrown.
        /// </exception>
        public static void AssertUriIsFileSchema(this Uri uri)
        {
            if (uri.Scheme != Uri.UriSchemeFile)
            {
                throw new ArgumentException($"Invalid URI scheme for: {uri}");
            }
        }
    }
}
