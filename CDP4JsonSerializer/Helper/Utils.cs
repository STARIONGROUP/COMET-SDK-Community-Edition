// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

namespace CDP4JsonSerializer.Helper
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A utility class that supplies common functionalities to the Serializer.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// The capitalize first character.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If supplied input is null or empty
        /// </exception>
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("string can't be empty!");
            }

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48
            return $"{input.First().ToString(CultureInfo.InvariantCulture).ToUpper()}{input.Substring(1)}";
#else
            return $"{input.First().ToString().ToUpper()}{input.Substring(1)}";
#endif

        }

        /// <summary>
        /// Lowercase the first character of a string.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If supplied input is null or empty
        /// </exception>
        public static string LowercaseFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("string can't be empty!");
            }
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47 || NET471 || NET472 || NET48
            return $"{input.First().ToString(CultureInfo.InvariantCulture).ToLower()}{input.Substring(1)}";
#else
            return $"{input.First().ToString().ToLower()}{input.Substring(1)}";
#endif
        }
    }
}