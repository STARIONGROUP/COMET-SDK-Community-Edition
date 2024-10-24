// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PostOperationJsonConverter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4JsonSerializer.JsonConverter
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using CDP4Common.Polyfills;
    using CDP4DalCommon.Protocol.Operations;

    using CDP4JsonSerializer.Extensions;

    using NLog;

    /// <summary>
    /// The <see cref="System.Text.Json.Serialization.JsonConverter" /> for <see cref="CDP4DalCommon.Protocol.Operations.PostOperation" />s
    /// </summary>
    public class PostOperationJsonConverter: JsonConverter<PostOperation>
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Asserts that the <see cref="CDP4DalCommon.Protocol.Operations.PostOperation.Copy"/> have to be ignored
        /// </summary>
        private readonly bool ignoreCopyProperty;

        /// <summary>
        /// Initializes a new <see cref="PostOperationJsonConverter" /> instance.
        /// </summary>
        /// <param name="ignoreCopyProperty">Asserts that the <see cref="CDP4DalCommon.Protocol.Operations.PostOperation.Copy"/> have to be ignored</param>
        public PostOperationJsonConverter(bool ignoreCopyProperty)
        {
            this.ignoreCopyProperty = ignoreCopyProperty;
        }

        /// <summary>
        /// Override of the can convert type check.
        /// </summary>
        /// <param name="typeToConvert">
        /// The object type.
        /// </param>
        /// <returns>
        /// true if this converter is to be used.
        /// </returns>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(PostOperation).QueryIsAssignableFrom(typeToConvert);
        }

        /// <summary>Reads and converts the JSON to type <see cref="CDP4DalCommon.Protocol.Operations.PostOperation"/>.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The converted value.</returns>
        public override PostOperation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (!JsonElement.TryParseValue(ref reader, out var jsonElement))
            {
                Logger.Error("The data object in the JSON array could not be cast to a JsonElement type.");
                throw new InvalidDataException("The data object in the JSON array could not be cast to a JObject type.");
            }

            if (!typeof(PostOperation).IsAssignableFrom(typeToConvert))         
            {
                Logger.Error($"The request Type {typeToConvert.Name} is not a PostOperation");
                throw new InvalidDataException($"The request Type {typeToConvert.Name} is not a PostOperation");
            }

            var postOperation = (PostOperation)FormatterServices.GetUninitializedObject(typeToConvert);

            jsonElement.Value.DeserializePostOperation(postOperation, options);
            return postOperation;
        }

        /// <summary>Writes a specified value as JSON.</summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, PostOperation value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteStartArray("_delete"u8);

            foreach (var toDelete in value.Delete)
            {
                JsonSerializer.Serialize(writer, toDelete, options);
            }

            writer.WriteEndArray();
            writer.WriteStartArray("_create"u8);

            foreach (var toCreate in value.Create)
            {
                JsonSerializer.Serialize(writer, toCreate, options);
            }

            writer.WriteEndArray();
            writer.WriteStartArray("_update"u8);

            foreach (var toUpdate in value.Update)
            {
                JsonSerializer.Serialize(writer, toUpdate, options);
            }

            writer.WriteEndArray();

            if (!this.ignoreCopyProperty)
            {
                writer.WriteStartArray("_copy"u8);
                
                foreach (var toCopy in value.Copy)
                {
                    JsonSerializer.Serialize(writer, toCopy, options);
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
    }
}
