// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArrayUtils.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
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

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.Types;

    /// <summary>
    /// The purpose of the <see cref="ValueArrayUtils"/> is to provide static helper methods for handling
    /// business logic related to <see cref="ValueArray{T}"/>
    /// </summary>
    public static class ValueArrayUtils
    {
        /// <summary>
        /// Creates a <see cref="ValueArray{String}"/> with as many slots containing "-" as the provided <paramref name="size"/>
        /// </summary>
        /// <param name="size">
        /// An integer denoting the number of slots, this may not be lower than one.
        /// </param>
        /// <returns>
        /// An instance of <see cref="ValueArray{String}"/>
        /// </returns>
        public static ValueArray<string> CreateDefaultValueArray(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(size), $"The {nameof(size)} may not be smaller than 1.");
            }
            
            var defaultValue = new List<string>(size);

            for (int i = 0; i < size; i++)
            {
                defaultValue.Add("-");
            }

            var result = new ValueArray<string>(defaultValue);

            return result;
        }

        /// <summary>
        /// Checks if two <see cref="ValueArray{T}"/> contains the same exact values 
        /// </summary>
        /// <typeparam name="T">the type of the parameter</typeparam>
        /// <param name="valueArray">the first value array to compare</param>
        /// <param name="comparison">the second value array to compare</param>
        /// <returns>True if the contained values are the same, false otherwise</returns>
        public static bool ContainsSameValues<T>(this ValueArray<T> valueArray, ValueArray<T> comparison) where T : class
        {
            if (comparison is null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            if (valueArray.Count != comparison.Count)
            {
                return false;
            }

            for (int i = 0; i < valueArray.Count; i++)
            {
                if (valueArray[i] != comparison[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}