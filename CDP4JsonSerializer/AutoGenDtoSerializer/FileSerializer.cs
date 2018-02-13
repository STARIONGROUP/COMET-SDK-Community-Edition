#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FileSerializer"/> class is to provide a <see cref="File"/> specific serializer
    /// </summary>
    public class FileSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "fileRevision", fileRevision => new JArray(fileRevision) },
            { "iid", iid => new JValue(iid) },
            { "lockedBy", lockedBy => new JValue(lockedBy) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "owner", owner => new JValue(owner) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="File"/>
        /// </summary>
        /// <param name="file">The <see cref="File"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(File file)
        {
            var jsonObject = new JObject();
            jsonObject.Add("category", this.PropertySerializerMap["category"](file.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), file.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](file.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](file.ExcludedPerson));
            jsonObject.Add("fileRevision", this.PropertySerializerMap["fileRevision"](file.FileRevision));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](file.Iid));
            jsonObject.Add("lockedBy", this.PropertySerializerMap["lockedBy"](file.LockedBy));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](file.ModifiedOn));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](file.Owner));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](file.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="File"/> class.
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

            var file = thing as File;
            if (file == null)
            {
                throw new InvalidOperationException("The thing is not a File.");
            }

            return this.Serialize(file);
        }
    }
}
