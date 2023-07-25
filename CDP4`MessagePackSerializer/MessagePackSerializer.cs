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
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using global::MessagePack;
    using global::MessagePack.Resolvers;

    using CDP4Common.DTO;
    
    using NLog;

    /// <summary>
    /// The purpose of the <see cref="MessagePackSerializer"/> is to (de)serialize a <see cref="IEnumerable{T}"/>
    /// to a <see cref="Stream"/> using MessagePack serialization and deserialization 
    /// </summary>
    public class MessagePackSerializer : IMessagePackSerializer
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="MessagePackSerializer"/> class.
        /// </summary>
        public MessagePackSerializer()
        {
        }
        
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
        public async Task SerializeToStreamAsync(IEnumerable<Thing> things, Stream outputStream, CancellationToken cancellationToken)
        {
            if (things == null)
            {
                throw new ArgumentNullException(nameof(things), "things may not be null");
            }

            if (outputStream == null)
            {
                throw new ArgumentNullException(nameof(outputStream), "outputstream may not be null");
            }
            
            var formatterResolver = CompositeResolver.Create(
                ThingFormatterResolver.Instance,
                StandardResolver.Instance);

            var options = MessagePackSerializerOptions.Standard
                .WithResolver(formatterResolver)
                .WithOldSpec(false);

            var payload = things.ToPayload();

            var sw = Stopwatch.StartNew();

            await global::MessagePack.MessagePackSerializer.SerializeAsync(outputStream, payload, options, cancellationToken);

            sw.Stop();

            Logger.Debug("SerializeToStreamAsync finished in {0} [ms]", sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Asynchronously serializes the <see cref="Thing"/>s to a <see cref="IBufferWriter{Byte}"/>
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
        public void SerializeToBufferWriter(IEnumerable<Thing> things, IBufferWriter<byte> writer, CancellationToken cancellationToken)
        {
            if (things == null)
            {
                throw new ArgumentNullException(nameof(things), "things may not be null");
            }

            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer), "IBufferWriter may not be null");
            }
            
            var formatterResolver = CompositeResolver.Create(
                ThingFormatterResolver.Instance,
                StandardResolver.Instance);

            var options = MessagePackSerializerOptions.Standard
                .WithResolver(formatterResolver)
                .WithOldSpec(false);

            var payload = things.ToPayload();

            var sw = Stopwatch.StartNew();

            global::MessagePack.MessagePackSerializer.Serialize(writer, payload, options, cancellationToken);

            sw.Stop();

            Logger.Debug("SerializeToStreamAsync finished in {0} [ms]", sw.ElapsedMilliseconds);
        }

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
        public async Task<IEnumerable<Thing>> DeserializeAsync(Stream contentStream, CancellationToken cancellationToken)
        {
            var formatterResolver = CompositeResolver.Create(
                ThingFormatterResolver.Instance,
                StandardResolver.Instance);

            var options = MessagePackSerializerOptions.Standard
                .WithResolver(formatterResolver)
                .WithOldSpec(false);

            var sw = Stopwatch.StartNew();

            var payload = await global::MessagePack.MessagePackSerializer.DeserializeAsync<Payload>(contentStream, options, cancellationToken);

            sw.Stop();

            Logger.Debug("DeserializeAsync finished in {0} [ms]", sw.ElapsedMilliseconds);

            var result = payload.ToThings();

            return result;
        }
    }
}
