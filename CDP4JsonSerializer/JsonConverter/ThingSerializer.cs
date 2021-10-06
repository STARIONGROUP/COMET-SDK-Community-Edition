// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using NLog;

    /// <summary>
    /// The <see cref="JsonConverter"/> that is responsible for (De)serialization on a <see cref="Thing"/> 
    /// </summary>
    public class ThingSerializer : JsonConverter
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
        public ThingSerializer(IMetaDataProvider metaInfoProvider, Version dataModelVersion)
        {
            this.MetaInfoProvider = metaInfoProvider;
            this.dataModelVersion = dataModelVersion;

            this.thingConverterExtensions = new ThingConverterExtensions();
        }

        /// <summary>
        /// Gets a value indicating whether this converter supports JSON read.
        /// </summary>
        public override bool CanRead
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this converter supports JSON write.
        /// </summary>
        public override bool CanWrite
        {
            get { return true; }
        }

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

            var jsonObject = ((Thing)value).ToJsonObject();

            // remove versioned properties
            var nonSerializablePropeties = new List<string>();
            foreach (var kvp in jsonObject)
            {
                var propertyVersion = new Version(this.MetaInfoProvider.GetPropertyVersion(typeName, Helper.Utils.CapitalizeFirstLetter(kvp.Key)));
                if (propertyVersion > this.dataModelVersion)
                {
                    nonSerializablePropeties.Add(kvp.Key);
                }
            }

            foreach (var nonSerializablePropety in nonSerializablePropeties)
            {
                jsonObject.Remove(nonSerializablePropety);
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
                Logger.Error("The data object in the JSON array could not be cast to a JObject type.");
                throw new NullReferenceException("The data object in the JSON array could not be cast to a JObject type.");
            }

            var newThing = jsonObject.ToDto();

            return newThing;
        }
    }
}