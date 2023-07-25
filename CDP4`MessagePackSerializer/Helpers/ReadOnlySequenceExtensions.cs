// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReadOnlySequenceExtensions.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
//
//    This file is part of COMET-SDK Community Edition
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
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Buffers;
    
    /// <summary>
    /// Extension methods for the <see cref="ReadOnlySequenceExtensions"/> class
    /// </summary>
    public static class ReadOnlySequenceExtensions
    {
        /// <summary>
        /// Converts a nullable ReadOnlySequence of byte?to a Guid
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static Guid ToGuid(this ReadOnlySequence<byte>? sequence)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence),"the sequence may not be null");
            }

            if (!sequence.HasValue)
            {
                throw new ArgumentException("the sequence does not have a value");
            }

            return new Guid(sequence.Value.ToArray());
        }
    }
}
