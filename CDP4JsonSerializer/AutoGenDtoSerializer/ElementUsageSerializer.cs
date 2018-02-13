#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsageSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ElementUsageSerializer"/> class is to provide a <see cref="ElementUsage"/> specific serializer
    /// </summary>
    public class ElementUsageSerializer : IThingSerializer
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
            { "elementDefinition", elementDefinition => new JValue(elementDefinition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "excludeOption", excludeOption => new JArray(excludeOption) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "interfaceEnd", interfaceEnd => new JValue(interfaceEnd.ToString()) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "parameterOverride", parameterOverride => new JArray(parameterOverride) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="ElementUsage"/>
        /// </summary>
        /// <param name="elementUsage">The <see cref="ElementUsage"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ElementUsage elementUsage)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](elementUsage.Alias));
            jsonObject.Add("category", this.PropertySerializerMap["category"](elementUsage.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), elementUsage.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](elementUsage.Definition));
            jsonObject.Add("elementDefinition", this.PropertySerializerMap["elementDefinition"](elementUsage.ElementDefinition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](elementUsage.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](elementUsage.ExcludedPerson));
            jsonObject.Add("excludeOption", this.PropertySerializerMap["excludeOption"](elementUsage.ExcludeOption));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](elementUsage.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](elementUsage.Iid));
            jsonObject.Add("interfaceEnd", this.PropertySerializerMap["interfaceEnd"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.InterfaceEndKind), elementUsage.InterfaceEnd)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](elementUsage.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](elementUsage.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](elementUsage.Owner));
            jsonObject.Add("parameterOverride", this.PropertySerializerMap["parameterOverride"](elementUsage.ParameterOverride));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](elementUsage.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](elementUsage.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ElementUsage"/> class.
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

            var elementUsage = thing as ElementUsage;
            if (elementUsage == null)
            {
                throw new InvalidOperationException("The thing is not a ElementUsage.");
            }

            return this.Serialize(elementUsage);
        }
    }
}
