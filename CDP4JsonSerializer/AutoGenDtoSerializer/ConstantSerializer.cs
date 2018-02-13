#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.DTO;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;
    
    /// <summary>
    /// The purpose of the <see cref="ConstantSerializer"/> class is to provide a <see cref="Constant"/> specific serializer
    /// </summary>
    public class ConstantSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "parameterType", parameterType => new JValue(parameterType) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "scale", scale => new JValue(scale) },
            { "shortName", shortName => new JValue(shortName) },
            { "value", value => new JValue(((ValueArray<string>)value).ToJsonString()) },
        };

        /// <summary>
        /// Serialize the <see cref="Constant"/>
        /// </summary>
        /// <param name="constant">The <see cref="Constant"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Constant constant)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](constant.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](constant.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), constant.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](constant.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](constant.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](constant.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](constant.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](constant.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](constant.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](constant.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](constant.Name));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](constant.ParameterType));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](constant.RevisionNumber));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](constant.Scale));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](constant.ShortName));
            jsonObject.Add("value", this.PropertySerializerMap["value"](constant.Value));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Constant"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JToken>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        public JObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException("thing");
            }

            var constant = thing as Constant;
            if (constant == null)
            {
                throw new InvalidOperationException("The thing is not a Constant.");
            }

            return this.Serialize(constant);
        }
    }
}
