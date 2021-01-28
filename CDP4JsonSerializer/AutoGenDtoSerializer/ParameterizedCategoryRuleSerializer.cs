// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterizedCategoryRuleSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
//
//    This file is part of CDP4-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// --------------------------------------------------------------------------------------------------------------------

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
    /// The purpose of the <see cref="ParameterizedCategoryRuleSerializer"/> class is to provide a <see cref="ParameterizedCategoryRule"/> specific serializer
    /// </summary>
    public class ParameterizedCategoryRuleSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "category", category => new JValue(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "parameterType", parameterType => new JArray(parameterType) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterizedCategoryRule"/>
        /// </summary>
        /// <param name="parameterizedCategoryRule">The <see cref="ParameterizedCategoryRule"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterizedCategoryRule parameterizedCategoryRule)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](parameterizedCategoryRule.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](parameterizedCategoryRule.Category));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterizedCategoryRule.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](parameterizedCategoryRule.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterizedCategoryRule.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterizedCategoryRule.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](parameterizedCategoryRule.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterizedCategoryRule.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](parameterizedCategoryRule.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterizedCategoryRule.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](parameterizedCategoryRule.Name));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](parameterizedCategoryRule.ParameterType.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterizedCategoryRule.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](parameterizedCategoryRule.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](parameterizedCategoryRule.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterizedCategoryRule"/> class.
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
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
            }

            var parameterizedCategoryRule = thing as ParameterizedCategoryRule;
            if (parameterizedCategoryRule == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterizedCategoryRule.");
            }

            return this.Serialize(parameterizedCategoryRule);
        }
    }
}
