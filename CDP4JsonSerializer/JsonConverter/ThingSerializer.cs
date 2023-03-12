// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.JsonConverter
{
    using System;
    using System.Collections.Generic;
    
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;
    using CDP4Common.Polyfills;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

   using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    /// <summary>
    /// The <see cref="JsonConverter"/> that is responsible for (De)serialization on a <see cref="CDP4Common.DTO.Thing"/> 
    /// </summary>
    public class ThingSerializer : JsonConverter
    {
      /// <summary>
      /// The <see cref="ILogger"/> used to log
      /// </summary>
      private readonly ILogger<ThingSerializer> logger;

      /// <summary>
      /// The data model version for this request.
      /// </summary>
      private readonly Version dataModelVersion;

        /// <summary>
        /// The <see cref="ThingConverterExtensions"/> used to determine whether a class is to be serialized or not
        /// </summary>
        private readonly ThingConverterExtensions thingConverterExtensions;

      /// <summary>
      /// Initializes a new instance of the <see cref="ThingSerializer"/> class.
      /// </summary>
      /// <param name="metaInfoProvider">
      /// The meta Info Provider.
      /// </param>
      /// <param name="dataModelVersion">
      /// The data model version for this request.
      /// </param>
      /// <param name="loggerFactory">
      /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
      /// </param>
      public ThingSerializer(IMetaDataProvider metaInfoProvider, Version dataModelVersion, ILoggerFactory loggerFactory = null)
        {
         this.logger = loggerFactory == null ? NullLogger<ThingSerializer>.Instance : loggerFactory.CreateLogger<ThingSerializer>();

         this.MetaInfoProvider = metaInfoProvider;
            this.dataModelVersion = dataModelVersion;

            this.thingConverterExtensions = new ThingConverterExtensions();
        }

        /// <summary>
        /// Gets a value indicating whether this converter supports JSON read.
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Gets a value indicating whether this converter supports JSON write.
        /// </summary>
        public override bool CanWrite => true;

        /// <summary>
        /// Gets or sets the meta info provider.
        /// </summary>
        private IMetaDataProvider MetaInfoProvider { get; set; }

        /// <summary>
        /// Override of the can convert type check.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <returns>
        /// true if this converter is to be used.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Thing).QueryIsAssignableFrom(objectType);
        }

        /// <summary>
        /// Write JSON.
        /// </summary>
        /// <param name="writer">
        /// The JSON writer.
        /// </param>
        /// <param name="value">
        /// The value object.
        /// </param>
        /// <param name="serializer">
        /// The JSON serializer.
        /// </param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var typeName = value.GetType().Name;
            var classVersion = new Version(this.MetaInfoProvider.GetClassVersion(typeName));

            if (classVersion > this.dataModelVersion)
            {
                // skip type serialization if the data version is larger then the request data model version
                return;
            }

            if (!this.thingConverterExtensions.AssertSerialization(value, this.MetaInfoProvider, this.dataModelVersion))
            {
                // skip type serialization if the object is not to be included
                return;
            }

            this.thingConverterExtensions.CheckCategoryPermissibleClasses(value, this.MetaInfoProvider, this.dataModelVersion);

            var jsonObject = ((Thing)value).ToJsonObject();

            // remove versioned properties
            var nonSerializableProperties = new List<string>();

            foreach (var kvp in jsonObject)
            {
                var propertyVersion = new Version(this.MetaInfoProvider.GetPropertyVersion(typeName, Helper.Utils.CapitalizeFirstLetter(kvp.Key)));

                if (propertyVersion > this.dataModelVersion)
                {
                    nonSerializableProperties.Add(kvp.Key);
                }
            }

            foreach (var nonSerializableProperty in nonSerializableProperties)
            {
                jsonObject.Remove(nonSerializableProperty);
            }

            jsonObject.WriteTo(writer);
        }

        /// <summary>
        /// Override of the Read JSON method.
        /// </summary>
        /// <param name="reader">
        /// The JSON reader.
        /// </param>
        /// <param name="objectType">
        /// The type information of the object.
        /// </param>
        /// <param name="existingValue">
        /// The existing object value.
        /// </param>
        /// <param name="serializer">
        /// The JSON serializer.
        /// </param>
        /// <returns>
        /// A deserialized instance.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // load object from stream
            var jsonObject = JObject.Load(reader);

            if (jsonObject == null)
            {
                this.logger.LogError("The data object in the JSON array could not be cast to a JObject type.");
                throw new NullReferenceException("The data object in the JSON array could not be cast to a JObject type.");
            }

            var newThing = jsonObject.ToDto();

            return newThing;
        }
    }
}
