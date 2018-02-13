#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitPrefixSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="UnitPrefixSerializer"/> class is to provide a <see cref="UnitPrefix"/> specific serializer
    /// </summary>
    public class UnitPrefixSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "conversionFactor", conversionFactor => new JValue(conversionFactor) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="UnitPrefix"/>
        /// </summary>
        /// <param name="unitPrefix">The <see cref="UnitPrefix"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(UnitPrefix unitPrefix)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](unitPrefix.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), unitPrefix.ClassKind)));
            jsonObject.Add("conversionFactor", this.PropertySerializerMap["conversionFactor"](unitPrefix.ConversionFactor));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](unitPrefix.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](unitPrefix.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](unitPrefix.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](unitPrefix.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](unitPrefix.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](unitPrefix.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](unitPrefix.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](unitPrefix.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](unitPrefix.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](unitPrefix.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="UnitPrefix"/> class.
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

            var unitPrefix = thing as UnitPrefix;
            if (unitPrefix == null)
            {
                throw new InvalidOperationException("The thing is not a UnitPrefix.");
            }

            return this.Serialize(unitPrefix);
        }
    }
}
