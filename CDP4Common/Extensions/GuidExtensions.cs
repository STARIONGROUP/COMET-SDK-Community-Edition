﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuidExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski, Antoine Théate
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension class for <see cref="Guid"/>
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Converts a <see cref="IEnumerable{Guid}" /> to an Array of ShortGuid
        /// </summary>
        /// <param name="guids">
        /// an <see cref="IEnumerable{Guid}" />
        /// </param>
        /// <returns>
        /// a <see cref="IEnumerable{String}" /> ShortGuid representation of the provided <see cref="Guid" />s
        /// </returns>
        /// <remarks>
        /// A ShortGuid is a base64 encoded guid-string representation where any "/" has been replaced with a "_"
        /// and any "+" has been replaced with a "-" (to make the string representation <see cref="Uri" /> friendly)
        /// A ShortGuid Array is a string that starts with "[", ends with "]" and contains a number of ShortGuid separated by a ";"
        /// </remarks>
        public static string ToShortGuidArray(this IEnumerable<Guid> guids)
        {
            var shortGuids = guids.Select(ToShortGuid).ToList();
            return "[" + string.Join(";", shortGuids) + "]";
        }

        /// <summary>
        /// converts a <see cref="Guid" /> to its base64 encoded short form
        /// </summary>
        /// <param name="guid">
        /// an instance of <see cref="Guid" />
        /// </param>
        /// <returns>
        /// a shortGuid representation of the provided <see cref="Guid" />
        /// </returns>
        /// <remarks>
        /// A ShortGuid is a base64 encoded guid-string representation where any "/" has been replaced with a "_"
        /// and any "+" has been replaced with a "-" (to make the string representation <see cref="Uri" /> friendly)
        /// </remarks>
        public static string ToShortGuid(this Guid guid)
        {
            var enc = Convert.ToBase64String(guid.ToByteArray());
            return enc.Replace("/", "_").Replace("+", "-").Substring(0, 22);
        }

        /// <summary>
        /// Creates a <see cref="Guid" /> based the ShortGuid representation
        /// </summary>
        /// <param name="shortGuid">
        /// a shortGuid string
        /// </param>
        /// <returns>
        /// an instance of <see cref="Guid" />
        /// </returns>
        /// <remarks>
        /// A ShortGuid is a base64 encoded guid-string representation where any "/" has been replaced with a "_"
        /// and any "+" has been replaced with a "-" (to make the string representation <see cref="Uri" /> friendly)
        /// </remarks>
        public static Guid FromShortGuid(this string shortGuid)
        {
            var buffer = Convert.FromBase64String(shortGuid.Replace("_", "/").Replace("-", "+") + "==");
            return new Guid(buffer);
        }

        /// <summary>
        /// Creates a <see cref="IEnumerable{Guid}" /> based the ShortGuid Array representation ->
        /// </summary>
        /// <param name="shortGuids">
        /// an <see cref="IEnumerable{String}" /> shortGuid
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{Guid}" />
        /// </returns>
        /// <remarks>
        /// A ShortGuid is a base64 encoded guid-string representation where any "/" has been replaced with a "_"
        /// and any "+" has been replaced with a "-" (to make the string representation <see cref="Uri" /> friendly)
        /// A ShortGuid Array is a string that starts with "[", ends with "]" and contains a number of ShortGuid separated by a ";"
        /// </remarks>
        /// <exception cref="ArgumentException">
        /// Thrown when the <paramref name="shortGuids" /> does not start with '[' or ends with ']'
        /// </exception>
        public static IEnumerable<Guid> FromShortGuidArray(this string shortGuids)
        {
            if (!shortGuids.StartsWith("["))
            {
                throw new ArgumentException("Invalid ShortGuid Array, must start with [", nameof(shortGuids));
            }

            if (!shortGuids.EndsWith("]"))
            {
                throw new ArgumentException("Invalid ShortGuid Array, must end with ]", nameof(shortGuids));
            }

            var listOfShortGuids = shortGuids.TrimStart('[').TrimEnd(']').Split(';');

            foreach (var shortGuid in listOfShortGuids)
            {
                yield return shortGuid.FromShortGuid();
            }
        }
    }
}
