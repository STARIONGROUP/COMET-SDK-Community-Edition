#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CitationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CitationSerializer"/> class is to provide a <see cref="Citation"/> specific serializer
    /// </summary>
    public class CitationSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "isAdaptation", isAdaptation => new JValue(isAdaptation) },
            { "location", location => new JValue(location) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "remark", remark => new JValue(remark) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "source", source => new JValue(source) },
        };

        /// <summary>
        /// Serialize the <see cref="Citation"/>
        /// </summary>
        /// <param name="citation">The <see cref="Citation"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Citation citation)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), citation.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](citation.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](citation.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](citation.Iid));
            jsonObject.Add("isAdaptation", this.PropertySerializerMap["isAdaptation"](citation.IsAdaptation));
            jsonObject.Add("location", this.PropertySerializerMap["location"](citation.Location));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](citation.ModifiedOn));
            jsonObject.Add("remark", this.PropertySerializerMap["remark"](citation.Remark));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](citation.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](citation.ShortName));
            jsonObject.Add("source", this.PropertySerializerMap["source"](citation.Source));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Citation"/> class.
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

            var citation = thing as Citation;
            if (citation == null)
            {
                throw new InvalidOperationException("The thing is not a Citation.");
            }

            return this.Serialize(citation);
        }
    }
}
