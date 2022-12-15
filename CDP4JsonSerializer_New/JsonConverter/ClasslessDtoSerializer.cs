#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClasslessDtoSerializer.cs" company="RHEA System S.A.">
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
#endregion

namespace CDP4JsonSerializer_New.JsonConverter
{
    using System;
    using System.Collections.Generic;
    using CDP4Common;
    using CDP4Common.MetaInfo;
    using CDP4Common.Polyfills;
    using CDP4JsonSerializer_New.Helper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NLog;

    using Dto = CDP4Common.DTO;

    /// <summary>
    /// The <see cref="JsonConverter"/> for <see cref="ClasslessDTO"/>s 
    /// </summary>
    public class ClasslessDtoSerializer : JsonConverter
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The <see cref="IMetaDataProvider"/>
        /// </summary>
        private readonly IMetaDataProvider metaDataProvider;

        /// <summary>
        /// The data model version for this request.
        /// </summary>
        private readonly Version dataModelVersion;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClasslessDtoSerializer"/> class.
        /// </summary>
        /// <param name="metaDataProvider">
        /// The <see cref="IMetaDataProvider"/>
        /// </param>
        /// <param name="dataModelVersion">The supported <see cref="Version"/></param>
        public ClasslessDtoSerializer(IMetaDataProvider metaDataProvider, Version dataModelVersion)
        {
            this.metaDataProvider = metaDataProvider;
            this.dataModelVersion = dataModelVersion;
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
            return typeof(ClasslessDTO).QueryIsAssignableFrom(objectType);
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
            var classlessDto = (ClasslessDTO)value;

            var typeName = classlessDto["ClassKind"].ToString();
            var classVersion = new Version(this.metaDataProvider.GetClassVersion(typeName));
            if (classVersion > this.dataModelVersion)
            {
                // skip type serialization if the data version is larger then the request data model version
                return;
            }

            var jsonObject = ((ClasslessDTO)value).ToJsonObject();

            var nonSerializablePropeties = new List<string>();
            foreach (var kvp in jsonObject)
            {
                var propertyVersion = new Version(this.metaDataProvider.GetPropertyVersion(typeName, Helper.Utils.CapitalizeFirstLetter(kvp.Key)));
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

            var dto = jsonObject.ToDto();
            var classlessDto = this.GenerateClasslessDto(jsonObject, dto);

            return classlessDto;
        }

        /// <summary>
        /// Create a <see cref="ClasslessDTO"/> from a <see cref="JObject"/> and a partial <see cref="Dto.Thing"/>
        /// </summary>
        /// <param name="jsonObject">The <see cref="JObject"/></param>
        /// <param name="dto">The <see cref="Dto.Thing"/></param>
        /// <returns>The generated <see cref="ClasslessDTO"/></returns>
        private ClasslessDTO GenerateClasslessDto(JObject jsonObject, Dto.Thing dto)
        {
            var metainfo = this.metaDataProvider.GetMetaInfo(dto.ClassKind.ToString());

            var classlessDto = new ClasslessDTO();
            foreach (var property in jsonObject.Properties())
            {
                var propertyName = Utils.CapitalizeFirstLetter(property.Name);
                classlessDto.Add(propertyName, metainfo.GetValue(propertyName, dto));
            }

            return classlessDto;
        }
    }
}