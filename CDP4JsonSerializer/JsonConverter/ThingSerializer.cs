// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Jaime Bernar
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
    using System.Text.Json;
    using System.Text.Json.Serialization;
    
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;
    using CDP4Common.Polyfills;
    
    using NLog;
    
    /// <summary>
    /// The <see cref="JsonConverter"/> that is responsible for (De)serialization on a <see cref="Thing"/> 
    /// </summary>
    public class ThingSerializer : JsonConverter<Thing>
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
        /// Override default null handling
        /// </summary>
        public override bool HandleNull => true;

        /// <summary>
        /// The <see cref="ThingConverterExtensions"/> used to determine whether a class is to be serialized or not
        /// </summary>
        private readonly ThingConverterExtensions thingConverterExtensions;

        /// <summary>
        /// Gets or sets the meta info provider.
        /// </summary>
        private IMetaDataProvider MetaInfoProvider { get; set; }

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
        /// Tries to deserialize a JSON into a <see cref="Thing"/>
        /// </summary>
        /// <param name="reader">the <see cref="Utf8JsonReader"/></param>
        /// <param name="typeToConvert">the <see cref="Type"/> to convert</param>
        /// <param name="options">the options of the serializer</param>
        /// <returns>the <see cref="Thing"/></returns>
        public override Thing Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {           
            // load object from stream
            if (!JsonElement.TryParseValue(ref reader, out var jsonElement))
            {
                Logger.Error("The data object in the JSON array could not be cast to a JObject type.");
                throw new NullReferenceException("The data object in the JSON array could not be cast to a JObject type.");
            }
                        
            var newThing = jsonElement?.ToDto();

            return newThing;
        }

        /// <summary>
        /// Write a JSON
        /// </summary>
        /// <param name="writer">the <see cref="Utf8JsonWriter"/></param>
        /// <param name="value">the <see cref="Thing"/> to serialize</param>
        /// <param name="options">the options of the serializer</param>
        public override void Write(Utf8JsonWriter writer, Thing value, JsonSerializerOptions options)
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

            var jsonObject = value.ToJsonObject();

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
    }
}
