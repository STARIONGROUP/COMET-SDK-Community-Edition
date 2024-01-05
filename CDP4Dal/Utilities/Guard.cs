// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Guard.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

namespace CDP4Dal.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using CDP4Common.CommonData;

    /// <summary>
    /// Utility static class that provide guard conditions
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Throws an exception when the value is null
        /// </summary>.
        /// <typeparam name="T">The type of the parameter</typeparam>
        /// <param name="value">The value to check</param>
        /// <param name="name">The name of the property</param>3
        /// <exception cref="ArgumentNullException">If the provided <paramref name="value"/> is null</exception>
        public static void ThrowIfNull<T>(T value, string name) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Throws an exception if the <see cref="Thing"/> is not a clone for a <see cref="Thing"/> that needs to be updated.
        /// Throws an exception if the <see cref="Thing"/> is not cached but is a clone.
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to check</param>
        /// <remarks>We expect that a <see cref="Thing"/> that have to be created is currently identified as </remarks>
        /// <exception cref="InvalidDataException">If the provided <paramref name="thing"/> is not a clone</exception>
        public static void ThrowIfNotValidForTransaction(Thing thing)
        {
            ThrowIfNull(thing, nameof(thing));

            if (thing.IsCached())
            {
                ThrowIfNotAClone(thing);
            }
            else
            {
                if (thing.Original != null)
                {
                    throw new InvalidDataException("The provided thing is a clone but is not cached");
                }
            }
        }

        /// <summary>
        /// Throws an exception if the <see cref="Thing"/> is not a clone
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to check</param>
        /// <exception cref="InvalidDataException">If the provided <paramref name="thing"/> is not a clone</exception>
        public static void ThrowIfNotAClone(Thing thing)
        {
            ThrowIfNull(thing, nameof(thing));

            if (thing.Original == null)
            {
                throw new InvalidDataException("The provided thing is not cloned");
            }
        }

        /// <summary>
        /// Throws an exception whenever a <see cref="IEnumerable{T}"/> is null or do not contains any value
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="value">The <see cref="IEnumerable{T}"/></param>
        /// <param name="name">The name of the parameter</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="value"/> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">When the <paramref name="value"/> is empty</exception>
        public static void ThrowIfNullOrEmpty<T>(IEnumerable<T> value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }

            if (!value.Any())
            {
                throw new ArgumentOutOfRangeException($"The provided {name} is empty");
            }
        }
    }
}
