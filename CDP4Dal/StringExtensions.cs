﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    /// Utils class to provide StringExtensions to CDP4Dal
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the first character of the string to an upper case letter.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> with the transformed first letter.
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("The input string may not be null or empty.");
            }

            // Return char and concat substring.
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        /// <summary>
        /// Converts the first character of the string to a lower case letter.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> with the transformed first letter.
        /// </returns>
        public static string LowerCaseFirstLetter(this string input)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("The input string may not be null or empty.");
            }

            // Return char and concat substring.
            return char.ToLower(input[0]) + input.Substring(1);
        }
    }
}
