// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4JsonSerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System  S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CDP4Common.MetaInfo;
    using CDP4JsonSerializer.JsonConverter;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
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
        /// Initializes a new instance of the <see cref="Cdp4JsonSerializer"/> class.
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
        /// Initializes a new instance of the <see cref="Cdp4JsonSerializer"/> class.
        /// </summary>
        public Cdp4JsonSerializer()
        {
        }

        /// <summary>
        /// Gets or sets the data model version for this request.
        /// </summary>
        public Version RequestDataModelVersion { get; private set; }

        /// <summary>
        /// Gets or sets the meta info provider.
        /// </summary>
        public IMetaDataProvider MetaInfoProvider { get; private set; }

        /// <summary>
        /// Initialize this instance with the required <see cref="IMetaDataProvider"/> and supported <see cref="Version"/>
        /// </summary>
        /// <param name="metaInfoProvider">The <see cref="IMetaDataProvider"/></param>
        /// <param name="supportedVersion">The supported <see cref="Version"/></param>
        public void Initialize(IMetaDataProvider metaInfoProvider, Version supportedVersion)
        {
            this.MetaInfoProvider = metaInfoProvider;
            this.RequestDataModelVersion = supportedVersion;
        }

        /// <summary>
        /// The serialize to stream.
        /// </summary>
        /// <param name="collectionSource">
        /// The collection source.
        /// </param>
        /// <param name="outputStream">
        /// The output stream.
        /// </param>
        public void SerializeToStream(object collectionSource, Stream outputStream)
        {
            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            var serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Include
            };

            // register converters
            serializer.Converters.Add(new ThingSerializer(this.MetaInfoProvider, this.RequestDataModelVersion));
            serializer.Converters.Add(new ClasslessDtoSerializer(this.MetaInfoProvider, this.RequestDataModelVersion));

            var jsonWriter = new JsonTextWriter(new StreamWriter(outputStream));

            serializer.Serialize(jsonWriter, collectionSource);
            jsonWriter.Flush();
        }

        /// <summary>
        /// Serialize the <see cref="CDP4Common.CommonData.Thing"/> to a JSON string
        /// </summary>
        /// <param name="source">The <see cref="CDP4Common.CommonData.Thing"/></param>
        /// <param name="extendDeep">A value indicating whether the contained <see cref="CDP4Common.CommonData.Thing"/> shall be processed</param>
        /// <returns>The JSON string</returns>
        public string SerializeToString(CDP4Common.CommonData.Thing source, bool extendDeep)
        {
            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            var dtoCollection = new List<Thing>();
            if (extendDeep)
            {
                dtoCollection.AddRange(this.GetThingsDeep(source));
            }
            else
            {
                dtoCollection.Add(source.ToDto());
            }

            string jsonString;
            using (var stream = new MemoryStream())
            {
                this.SerializeToStream(dtoCollection, stream);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    jsonString = reader.ReadToEnd();
                }
            }

            return jsonString;
        }

        /// <summary>
        /// Convenience method that deserializes the passed in JSON content stream
        /// </summary>
        /// <param name="contentStream">
        /// The content Stream.
        /// </param>
        /// <returns>
        /// The the deserialized collection of <see cref="CDP4Common.DTO.Thing"/>.
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
        /// The the deserialized instance of <see cref="T"/>.
        /// </returns>
        public T Deserialize<T>(Stream contentStream)
        {
            if (this.RequestDataModelVersion == null || this.MetaInfoProvider == null)
            {
                throw new InvalidOperationException("The supported version or the metainfo provider has not been set. Call the Initialize method to set them.");
            }

            var serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            // register converters
            serializer.Converters.Add(new ThingSerializer(this.MetaInfoProvider, this.RequestDataModelVersion));
            serializer.Converters.Add(new ClasslessDtoSerializer(this.MetaInfoProvider, this.RequestDataModelVersion));

            T data;
            using (var streamReader = new StreamReader(contentStream))
            using (var jsonTextReader = new JsonTextReader(streamReader))
            {
                data = serializer.Deserialize<T>(jsonTextReader);
            }

            return data;
        }

        /// <summary>
        /// Gets the <see cref="Thing"/> and all its contained <see cref="Thing"/>
        /// </summary>
        /// <param name="source">the <see cref="CDP4Common.CommonData.Thing"/></param>
        /// <returns>The collection of <see cref="Thing"/></returns>
        private IEnumerable<Thing> GetThingsDeep(CDP4Common.CommonData.Thing source)
        {
            var things = new List<Thing> { source.ToDto() };
            foreach (var containerList in source.ContainerLists)
            {
                var subThingsList = containerList.Cast<CDP4Common.CommonData.Thing>().ToList();
                foreach (var thing in subThingsList)
                {
                    things.AddRange(this.GetThingsDeep(thing));
                }
            }

            return things;
        }
    }
}