// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessagePackSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elabiary
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
    using System.Buffers;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.DTO;

    /// <summary>
    /// An interface for the CDP4 MessagePack Serializer
    /// </summary>
    public interface IMessagePackSerializer
    {
        /// <summary>
        /// Asynchronously serializes the <see cref="Thing"/>s to a <see cref="Stream"/>
        /// </summary>
        /// <param name="things">
        /// The <see cref="Thing"/>s that are to be serialized.
        /// </param>
        /// <param name="outputStream">
        /// The target output <see cref="Stream"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        Task SerializeToStreamAsync(IEnumerable<Thing> things, Stream outputStream, CancellationToken cancellationToken);

        /// <summary>
        /// Serializes the <see cref="Thing"/>s to a <see cref="IBufferWriter{Byte}"/>
        /// </summary>
        /// <param name="things">
        /// The <see cref="Thing"/>s that are to be serialized.
        /// </param>
        /// <param name="writer">
        /// The target <see cref="IBufferWriter{Byte}"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// an awaitable <see cref="Task"/>
        /// </returns>
        void SerializeToBufferWriter(IEnumerable<Thing> things, IBufferWriter<byte> writer, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously deserializes <see cref="IEnumerable{Thing}"/> from the <paramref name="contentStream"/>
        /// </summary>
        /// <param name="contentStream">
        /// A stream containing <see cref="Thing"/>s
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// The the deserialized collection of <see cref="Thing"/>.
        /// </returns>
        Task<IEnumerable<Thing>> DeserializeAsync(Stream contentStream, CancellationToken cancellationToken);
    }
}
