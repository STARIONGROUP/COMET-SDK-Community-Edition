// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Antoine Théate, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesMessaging.Serializers
{
    using System;

    /// <summary>
    /// The <see cref="IMessageSerializer"/> defines methods to serialize and deserialize messages used by this CDP4ServicesMessaging library
    /// </summary>
    public interface IMessageSerializer
    {
        /// <summary>
        /// Serializes the specified message of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the message to be serialized.</typeparam>
        /// <param name="message">The message to be serialized.</param>
        /// <returns>A <see cref="ReadOnlyMemory{T}"/> containing the serialized message.</returns>
        ReadOnlyMemory<byte> Serialize<T>(T message);
        
        /// <summary>
        /// Deserializes a message of type <typeparamref name="T"/> from the specified <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the message to be deserialized.</typeparam>
        /// <param name="message">The serialized message to be deserialized.</param>
        /// <returns>The deserialized message of type <typeparamref name="T"/>.</returns>
        T Deserialize<T>(ReadOnlyMemory<byte> message);
    }
}
