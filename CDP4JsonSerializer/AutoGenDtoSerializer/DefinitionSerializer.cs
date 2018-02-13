#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinitionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DefinitionSerializer"/> class is to provide a <see cref="Definition"/> specific serializer
    /// </summary>
    public class DefinitionSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "citation", citation => new JArray(citation) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "example", example => new JArray(((IEnumerable)example).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "note", note => new JArray(((IEnumerable)note).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="Definition"/>
        /// </summary>
        /// <param name="definition">The <see cref="Definition"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Definition definition)
        {
            var jsonObject = new JObject();
            jsonObject.Add("citation", this.PropertySerializerMap["citation"](definition.Citation));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), definition.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](definition.Content));
            jsonObject.Add("example", this.PropertySerializerMap["example"](definition.Example));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](definition.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](definition.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](definition.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](definition.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](definition.ModifiedOn));
            jsonObject.Add("note", this.PropertySerializerMap["note"](definition.Note));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](definition.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Definition"/> class.
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

            var definition = thing as Definition;
            if (definition == null)
            {
                throw new InvalidOperationException("The thing is not a Definition.");
            }

            return this.Serialize(definition);
        }
    }
}
