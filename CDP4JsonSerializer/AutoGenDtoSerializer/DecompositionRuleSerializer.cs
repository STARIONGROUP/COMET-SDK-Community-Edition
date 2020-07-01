// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecompositionRuleSerializer.cs" company="RHEA System S.A.">
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
// </copyright>
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
    /// The purpose of the <see cref="DecompositionRuleSerializer"/> class is to provide a <see cref="DecompositionRule"/> specific serializer
    /// </summary>
    public class DecompositionRuleSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "containedCategory", containedCategory => new JArray(containedCategory) },
            { "containingCategory", containingCategory => new JValue(containingCategory) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "maxContained", maxContained => new JValue(maxContained) },
            { "minContained", minContained => new JValue(minContained) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
        };

        /// <summary>
        /// Serialize the <see cref="DecompositionRule"/>
        /// </summary>
        /// <param name="decompositionRule">The <see cref="DecompositionRule"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(DecompositionRule decompositionRule)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](decompositionRule.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), decompositionRule.ClassKind)));
            jsonObject.Add("containedCategory", this.PropertySerializerMap["containedCategory"](decompositionRule.ContainedCategory.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("containingCategory", this.PropertySerializerMap["containingCategory"](decompositionRule.ContainingCategory));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](decompositionRule.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](decompositionRule.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](decompositionRule.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](decompositionRule.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](decompositionRule.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](decompositionRule.IsDeprecated));
            jsonObject.Add("maxContained", this.PropertySerializerMap["maxContained"](decompositionRule.MaxContained));
            jsonObject.Add("minContained", this.PropertySerializerMap["minContained"](decompositionRule.MinContained));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](decompositionRule.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](decompositionRule.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](decompositionRule.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](decompositionRule.ShortName));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="DecompositionRule"/> class.
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

            var decompositionRule = thing as DecompositionRule;
            if (decompositionRule == null)
            {
                throw new InvalidOperationException("The thing is not a DecompositionRule.");
            }

            return this.Serialize(decompositionRule);
        }
    }
}
