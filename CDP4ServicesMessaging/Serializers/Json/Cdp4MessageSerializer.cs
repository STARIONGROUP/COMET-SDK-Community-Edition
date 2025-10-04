// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4MessageSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4ServicesMessaging.Serializers.Json
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;

    using CDP4Common.MetaInfo;

    using CDP4JsonSerializer;

    using NLog;

    /// <summary>
    /// The <see cref="Cdp4MessageSerializer"/> extends the <see cref="CDP4JsonSerializer"/> to add capability to handle serialization/deserialization of messages
    /// </summary>
    public class Cdp4MessageSerializer : Cdp4JsonSerializer, ICdp4MessageSerializer
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new <see cref="Cdp4JsonSerializer"/>
        /// </summary>
        public Cdp4MessageSerializer()
        {
        }

        /// <summary>
        /// Initializes a new <see cref="Cdp4JsonSerializer"/>
        /// </summary>
        /// <param name="metaInfoProvider">The <see cref="IMetaDataProvider"/></param>
        public Cdp4MessageSerializer(IMetaDataProvider metaInfoProvider) : base(metaInfoProvider, metaInfoProvider.GetMaxSupportedModelVersion())
        {
        }

        /// <summary>
        /// Serializes the specified message of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the message to be serialized.</typeparam>
        /// <param name="message">The message to be serialized.</param>
        /// <returns>A <see cref="ReadOnlyMemory{T}"/> containing the serialized message.</returns>
        public ReadOnlyMemory<byte> Serialize<T>(T message)
        {
            var sw = Stopwatch.StartNew();

            // Use a MemoryStream to store the serialized data
            using var memoryStream = new MemoryStream();

            Logger.Trace("Serialize to JsonTextWriter");
            JsonSerializer.Serialize(memoryStream, message, this.JsonSerializerOptions);

            // Get the ReadOnlyMemory<byte> from the MemoryStream
            var serializedMessage = new ReadOnlyMemory<byte>(memoryStream.ToArray());

            sw.Stop();
            Logger.Debug("SerializeThingsChangedMessage finished in {0} [ms]", sw.ElapsedMilliseconds);

            return serializedMessage;
        }

        /// <summary>
        /// Deserializes a message of type <typeparamref name="T"/> from the specified <see cref="ReadOnlyMemory{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the message to be deserialized.</typeparam>
        /// <param name="message">The serialized message to be deserialized.</param>
        /// <returns>The deserialized message of type <typeparamref name="T"/>.</returns>
        public T Deserialize<T>(ReadOnlyMemory<byte> message)
        {
            using var stream = new MemoryStream(message.ToArray());
            return this.Deserialize<T>(stream);
        }
    }
}
