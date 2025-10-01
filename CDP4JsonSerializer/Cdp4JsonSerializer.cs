﻿// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4JsonSerializer.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using CDP4Common.MetaInfo;

    using CDP4JsonSerializer.Helper;
    using CDP4JsonSerializer.JsonConverter;

    using NLog;

    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// The JSON de-serializer.
    /// </summary>
    public class Cdp4JsonSerializer : ICdp4JsonSerializer
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4JsonSerializer" /> class.
        /// </summary>
        /// <param name="metaInfoProvider">
        /// The meta Info Provider.
        /// </param>
        /// <param name="supportedVersion">
        /// The supported version of the data-model
        /// </param>
        public Cdp4JsonSerializer(IMetaDataProvider metaInfoProvider, Version supportedVersion)
        {
            this.Initialize(metaInfoProvider, supportedVersion);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4JsonSerializer" /> class.
        /// </summary>
        public Cdp4JsonSerializer()
        {
        }

        /// <summary>
        /// Gets or sets the options for the serializer
        /// </summary>
        public JsonSerializerOptions JsonSerializerOptions { get; private set; }

        /// <summary>
        /// Gets or sets the data model version for this request.
        /// </summary>
        public Version RequestDataModelVersion { get; private set; }

        /// <summary>
        /// Gets or sets the meta info provider.
        /// </summary>
        public IMetaDataProvider MetaInfoProvider { get; private set; }

        /// <summary>
        /// Initialize this instance with the required <see cref="IMetaDataProvider" /> and supported <see cref="Version" />
        /// </summary>
        /// <param name="metaInfoProvider">The <see cref="IMetaDataProvider" /></param>
        /// <param name="supportedVersion">The supported <see cref="Version" /></param>
        public void Initialize(IMetaDataProvider metaInfoProvider, Version supportedVersion)
        {
            this.MetaInfoProvider = metaInfoProvider;
            this.RequestDataModelVersion = supportedVersion;
            this.InitializeJsonSerializerOptions();
        }

        /// <summary>
        /// The serialize to stream.
        /// </summary>
        /// <param name="collectionSource">
        /// The collection source.
        /// </param>
        /// <param name="outputStream">
        /// The output stream to which the serialized JSON objects are written
        /// </param>
        public void SerializeToStream(object collectionSource, Stream outputStream)
        {
            if (outputStream == null)
            {
                throw new ArgumentNullException(nameof(outputStream), "outputstream may not be null");
            }

            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            var sw = Stopwatch.StartNew();

            Logger.Trace("initializing Serialization");
            JsonSerializer.Serialize(outputStream, collectionSource, this.JsonSerializerOptions);

            sw.Stop();
            Logger.Debug("SerializeToStream finished in {0} [ms]", sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Serialize the <see cref="CDP4Common.CommonData.Thing" /> to a JSON stream
        /// </summary>
        /// <param name="source">
        /// The <see cref="CDP4Common.CommonData.Thing" />
        /// </param>
        /// <param name="outputStream">
        /// The output stream to which the serialized JSON objects are written
        /// </param>
        /// <param name="isExtentDeep">
        /// A value indicating whether the contained <see cref="CDP4Common.CommonData.Thing" /> shall be included in the JSON stream
        /// </param>
        /// <returns>A JSON stream</returns>
        public void SerializeToStream(CDP4Common.CommonData.Thing source, Stream outputStream, bool isExtentDeep)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "the source Thing may not be null");
            }

            if (outputStream == null)
            {
                throw new ArgumentNullException(nameof(outputStream), "outputstream may not be null");
            }

            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            var dtos = new List<Thing>();

            if (isExtentDeep)
            {
                var pocos = source.QueryContainedThingsDeep();

                foreach (var poco in pocos)
                {
                    dtos.Add(poco.ToDto());
                }
            }
            else
            {
                dtos.Add(source.ToDto());
            }

            Logger.Debug("serializing {0} DTO's", dtos.Count);

            this.SerializeToStream(dtos, outputStream);
        }

        /// <summary>
        /// Serialize the <see cref="CDP4Common.CommonData.Thing" /> to a JSON string
        /// </summary>
        /// <param name="source">The <see cref="CDP4Common.CommonData.Thing" /></param>
        /// <param name="isExtentDeep">A value indicating whether the contained <see cref="CDP4Common.CommonData.Thing" /> shall be processed</param>
        /// <returns>The JSON string</returns>
        public string SerializeToString(CDP4Common.CommonData.Thing source, bool isExtentDeep)
        {
            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            Logger.Trace("initializing MemoryStream");

            using var stream = new MemoryStream();

            this.SerializeToStream(source, stream, isExtentDeep);

            Logger.Trace("rewind MemoryStream");
            stream.Position = 0;

            Logger.Trace("initializing StreamReader");
            using var reader = new StreamReader(stream);

            var sw = new Stopwatch();
            sw.Start();
            var jsonString = reader.ReadToEnd();
            sw.Stop();
            Logger.Trace("write json stream to json string in {0} [ms]", sw.ElapsedMilliseconds);

            return jsonString;
        }
        
        /// <summary>
        /// Serialize an object into a string
        /// </summary>
        /// <param name="toSerialize">The object to serialize</param>
        /// <returns>The serialized string</returns>
        /// <exception cref="InvalidOperationException">
        /// If the <see cref="RequestDataModelVersion" /> or
        /// <see cref="MetaInfoProvider" /> has not been initialized
        /// </exception>
        public string SerializeToString(object toSerialize)
        {
            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            Logger.Trace("initializing MemoryStream");

            using var stream = new MemoryStream();

            this.SerializeToStream(toSerialize, stream);

            Logger.Trace("rewind MemoryStream");
            stream.Position = 0;

            Logger.Trace("initializing StreamReader");
            using var reader = new StreamReader(stream);

            var sw = new Stopwatch();
            sw.Start();
            var jsonString = reader.ReadToEnd();
            sw.Stop();
            Logger.Trace("write json stream to json string in {0} [ms]", sw.ElapsedMilliseconds);

            return jsonString;
        }

        /// <summary>
        /// Convenience method that deserializes the passed in JSON content stream
        /// </summary>
        /// <param name="contentStream">
        /// The content Stream.
        /// </param>
        /// <returns>
        /// The the deserialized collection of <see cref="CDP4Common.DTO.Thing" />.
        /// </returns>
        public IEnumerable<Thing> Deserialize(Stream contentStream)
        {
            return this.Deserialize<IEnumerable<Thing>>(contentStream);
        }

        /// <summary>
        /// Convenience method that deserializes the passed in JSON content stream
        /// </summary>
        /// <typeparam name="T">
        /// The type info for which deserialization will be performed
        /// </typeparam>
        /// <param name="contentStream">
        /// The content Stream.
        /// </param>
        /// <returns>
        /// The the deserialized instance of the specified Type
        /// </returns>
        public T Deserialize<T>(Stream contentStream)
        {
            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            var sw = new Stopwatch();
            sw.Start();
            var data = JsonSerializer.Deserialize<T>(contentStream, this.JsonSerializerOptions);
            Logger.Trace("Deserialize from stream in {0} [ms]", sw.ElapsedMilliseconds);
            return data;
        }

        /// <summary>
        /// Convenience method that deserializes the passed in JSON content stream
        /// </summary>
        /// <typeparam name="T">
        /// The type info for which deserialization will be performed
        /// </typeparam>
        /// <param name="contentString">
        /// The content string.
        /// </param>
        /// <returns>
        /// The the deserialized instance of the specified Type
        /// </returns>
        public T Deserialize<T>(string contentString)
        {
            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            var sw = new Stopwatch();
            sw.Start();
            var data = JsonSerializer.Deserialize<T>(contentString, this.JsonSerializerOptions);
            Logger.Trace("Deserialize from stream in {0} [ms]", sw.ElapsedMilliseconds);
            return data;
        }

        /// <summary>
        /// Initialize the <see cref="JsonSerializerOptions" /> property
        /// </summary>
        public virtual void InitializeJsonSerializerOptions()
        {
            this.JsonSerializerOptions = JsonSerializerOptionsCreator.CreateNew();

            this.JsonSerializerOptions.Converters.Add(new ThingSerializer(this.MetaInfoProvider, this.RequestDataModelVersion));
            this.JsonSerializerOptions.Converters.Add(new ClasslessDtoSerializer(this.MetaInfoProvider, this.RequestDataModelVersion));
            this.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(null, false));
        }
    }
}
