// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ClasslessDtoSerializer.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer.JsonConverter
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Text.Json.Serialization;

    using System.Collections.Generic;

    using CDP4Common;
    using CDP4Common.MetaInfo;
    using CDP4Common.Polyfills;

    using CDP4JsonSerializer.Helper;

    using NLog;

    using Dto = CDP4Common.DTO;

    /// <summary>
    /// The <see cref="JsonConverter" /> for <see cref="ClasslessDTO" />s
    /// </summary>
    public class ClasslessDtoSerializer : JsonConverter<ClasslessDTO>
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The data model version for this request.
        /// </summary>
        private readonly Version dataModelVersion;

        /// <summary>
        /// The <see cref="IMetaDataProvider" />
        /// </summary>
        private readonly IMetaDataProvider metaDataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClasslessDtoSerializer" /> class.
        /// </summary>
        /// <param name="metaDataProvider">
        /// The <see cref="IMetaDataProvider" />
        /// </param>
        /// <param name="dataModelVersion">The supported <see cref="Version" /></param>
        public ClasslessDtoSerializer(IMetaDataProvider metaDataProvider, Version dataModelVersion)
        {
            this.metaDataProvider = metaDataProvider;
            this.dataModelVersion = dataModelVersion;
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
            return typeof(ClasslessDTO).QueryIsAssignableFrom(typeToConvert);
        }

        /// <summary>
        /// Tries to deserialize a JSON into a <see cref="ClasslessDTO" />
        /// </summary>
        /// <param name="reader">the <see cref="Utf8JsonReader" /></param>
        /// <param name="typeToConvert">the <see cref="Type" /> to convert</param>
        /// <param name="options">the options of the serializer</param>
        /// <returns>the <see cref="ClasslessDTO" /></returns>
        public override ClasslessDTO Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (!JsonElement.TryParseValue(ref reader, out var jsonElement))
            {
                Logger.Error("The data object in the JSON array could not be cast to a JsonElement type.");
                throw new InvalidDataException("The data object in the JSON array could not be cast to a JsonElement type.");
            }

            var dto = jsonElement.Value.ToDto();
            var classlessDto = this.GenerateClasslessDto(jsonElement.Value, dto);

            return classlessDto;
        }

        /// <summary>
        /// Write a JSON
        /// </summary>
        /// <param name="writer">the <see cref="Utf8JsonWriter" /></param>
        /// <param name="value">the <see cref="ClasslessDTO" /> to serialize</param>
        /// <param name="options">the options of the serializer</param>
        public override void Write(Utf8JsonWriter writer, ClasslessDTO value, JsonSerializerOptions options)
        {
            var typeName = value["ClassKind"].ToString();
            var classVersion = new Version(this.metaDataProvider.GetClassVersion(typeName));

            if (classVersion > this.dataModelVersion)
            {
                // skip type serialization if the data version is larger then the request data model version
                return;
            }

            value.SerializeClasslessDto(writer, this.dataModelVersion);
        }

        /// <summary>
        /// Create a <see cref="ClasslessDTO" /> from a <see cref="JsonObject" /> and a partial <see cref="Dto.Thing" />
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject" /></param>
        /// <param name="dto">The <see cref="Dto.Thing" /></param>
        /// <returns>The generated <see cref="ClasslessDTO" /></returns>
        private ClasslessDTO GenerateClasslessDto(JsonElement jsonObject, Dto.Thing dto)
        {
            var metainfo = this.metaDataProvider.GetMetaInfo(dto.ClassKind.ToString());

            var classlessDto = new ClasslessDTO();

            foreach (var property in jsonObject.EnumerateObject())
            {
                var propertyName = Utils.CapitalizeFirstLetter(property.Name);
                classlessDto.Add(propertyName, metainfo.GetValue(propertyName, dto));
            }

            return classlessDto;
        }
    }
}
