// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICdp4JsonSerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    /// <summary>
    /// An interface for the CDP4 JSON Serializer
    /// </summary>
    public interface ICdp4JsonSerializer
    {
        /// <summary>
        /// Gets or sets the <see cref="IMetaDataProvider"/>
        /// </summary>
        IMetaDataProvider MetaInfoProvider { get; }

        /// <summary>
        /// Gets or sets the data model version for this request.
        /// </summary>
        Version RequestDataModelVersion { get; }

        /// <summary>
        /// Initialize this instance with the required <see cref="IMetaDataProvider"/> and supported <see cref="Version"/>
        /// </summary>
        /// <param name="metaInfoProvider">The <see cref="IMetaDataProvider"/></param>
        /// <param name="supportedVersion">The supported <see cref="Version"/></param>
        void Initialize(IMetaDataProvider metaInfoProvider, Version supportedVersion);

        /// <summary>
        /// The serialize to stream.
        /// </summary>
        /// <param name="collectionSource">
        /// The collection source.
        /// </param>
        /// <param name="outputStream">
        /// The output stream.
        /// </param>
        void SerializeToStream(object collectionSource, Stream outputStream);

        /// <summary>
        /// Serialize the <see cref="CDP4Common.CommonData.Thing"/> to a JSON stream
        /// </summary>
        /// <param name="source">
        /// The <see cref="CDP4Common.CommonData.Thing"/>
        /// </param>
        /// <param name="outputStream">
        /// The output stream to which the serialized JSON objects are written
        /// </param>
        /// <param name="isExtentDeep">
        /// A value indicating whether the contained <see cref="CDP4Common.CommonData.Thing"/> shall be included in the JSON stream
        /// </param>
        /// <returns>A JSON stream</returns>
        void SerializeToStream(CDP4Common.CommonData.Thing source, Stream outputStream, bool isExtentDeep);

        /// <summary>
        /// Serialize the <see cref="CDP4Common.CommonData.Thing"/> to a JSON string
        /// </summary>
        /// <param name="source">The <see cref="CDP4Common.CommonData.Thing"/></param>
        /// <param name="isExtentDeep">A value indicating whether the contained <see cref="CDP4Common.CommonData.Thing"/> shall be processed</param>
        /// <returns>The JSON string</returns>
        string SerializeToString(CDP4Common.CommonData.Thing source, bool isExtentDeep);

        /// <summary>
        /// Convenience method that deserializes the passed in JSON content stream
        /// </summary>
        /// <param name="contentStream">
        /// The content Stream.
        /// </param>
        /// <returns>
        /// The the deserialized collection of <see cref="CDP4Common.DTO.Thing"/>.
        /// </returns>
        IEnumerable<Thing> Deserialize(Stream contentStream);

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
        /// The the deserialized instance of <see cref="T"/>.
        /// </returns>
        T Deserialize<T>(Stream contentStream);
    }
}