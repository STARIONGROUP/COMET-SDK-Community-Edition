#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryNoteSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="BinaryNoteSerializer"/> class is to provide a <see cref="BinaryNote"/> specific serializer
    /// </summary>
    public class BinaryNoteSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "caption", caption => new JValue(caption) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "fileType", fileType => new JValue(fileType) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="BinaryNote"/>
        /// </summary>
        /// <param name="binaryNote">The <see cref="BinaryNote"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(BinaryNote binaryNote)
        {
            var jsonObject = new JObject();
            jsonObject.Add("caption", this.PropertySerializerMap["caption"](binaryNote.Caption));
            jsonObject.Add("category", this.PropertySerializerMap["category"](binaryNote.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), binaryNote.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](binaryNote.CreatedOn));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](binaryNote.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](binaryNote.ExcludedPerson));
            jsonObject.Add("fileType", this.PropertySerializerMap["fileType"](binaryNote.FileType));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](binaryNote.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](binaryNote.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](binaryNote.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](binaryNote.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](binaryNote.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](binaryNote.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="BinaryNote"/> class.
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

            var binaryNote = thing as BinaryNote;
            if (binaryNote == null)
            {
                throw new InvalidOperationException("The thing is not a BinaryNote.");
            }

            return this.Serialize(binaryNote);
        }
    }
}
