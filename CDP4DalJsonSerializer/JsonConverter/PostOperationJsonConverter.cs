// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PostOperationJsonConverter.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

namespace CDP4DalJsonSerializer.JsonConverter
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using CDP4Common.Polyfills;

    using CDP4DalCommon.Protocol.Operations;

    using CDP4DalJsonSerializer.Extensions;

    using NLog;

    /// <summary>
    /// The <see cref="JsonConverter" /> for <see cref="PostOperation" />s
    /// </summary>
    public class PostOperationJsonConverter: JsonConverter<PostOperation>
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Asserts that the <see cref="PostOperation.Copy"/> have to be ignored
        /// </summary>
        private readonly bool ignoreCopyProperty;

        /// <summary>
        /// Initializes a new <see cref="PostOperationJsonConverter" /> instance.
        /// </summary>
        /// <param name="ignoreCopyProperty">Asserts that the <see cref="PostOperation.Copy"/> have to be ignored</param>
        public PostOperationJsonConverter(bool ignoreCopyProperty = false)
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

        /// <summary>Reads and converts the JSON to type <typeparamref name="T" />.</summary>
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

            var initializedPostOperation = Activator.CreateInstance(typeToConvert);

            if (initializedPostOperation is not PostOperation postOperation)
            {
                Logger.Error($"The request Type {typeToConvert.Name} is not a PostOperation");
                throw new InvalidDataException($"The request Type {typeToConvert.Name} is not a PostOperation");
            }

            jsonElement?.DeserializePostOperation(postOperation, options);
            return postOperation;
        }

        /// <summary>Writes a specified value as JSON.</summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, PostOperation value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteStartArray("_delete");

            foreach (var toDelete in value.Delete)
            {
                JsonSerializer.Serialize(writer, toDelete, options);
            }

            writer.WriteEndArray();
            writer.WriteStartArray("_create");

            foreach (var toCreate in value.Create)
            {
                JsonSerializer.Serialize(writer, toCreate, options);
            }

            writer.WriteEndArray();
            writer.WriteStartArray("_update");

            foreach (var toUpdate in value.Update)
            {
                JsonSerializer.Serialize(writer, toUpdate, options);
            }

            writer.WriteEndArray();

            if (!this.ignoreCopyProperty)
            {
                writer.WriteStartArray("_copy");
                
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
