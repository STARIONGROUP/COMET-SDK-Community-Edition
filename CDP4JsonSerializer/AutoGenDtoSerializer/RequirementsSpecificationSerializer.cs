// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RequirementsSpecificationSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
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
    /// The purpose of the <see cref="RequirementsSpecificationSerializer"/> class is to provide a <see cref="RequirementsSpecification"/> specific serializer
    /// </summary>
    public class RequirementsSpecificationSerializer : BaseThingSerializer, IThingSerializer
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
            { "group", group => new JArray(group) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "owner", owner => new JValue(owner) },
            { "parameterValue", parameterValue => new JArray(parameterValue) },
            { "requirement", requirement => new JArray(requirement) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="RequirementsSpecification"/>
        /// </summary>
        /// <param name="requirementsSpecification">The <see cref="RequirementsSpecification"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RequirementsSpecification requirementsSpecification)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](requirementsSpecification.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](requirementsSpecification.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), requirementsSpecification.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](requirementsSpecification.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](requirementsSpecification.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](requirementsSpecification.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("group", this.PropertySerializerMap["group"](requirementsSpecification.Group.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](requirementsSpecification.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](requirementsSpecification.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](requirementsSpecification.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](requirementsSpecification.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](requirementsSpecification.Name));
            jsonObject.Add("owner", this.PropertySerializerMap["owner"](requirementsSpecification.Owner));
            jsonObject.Add("parameterValue", this.PropertySerializerMap["parameterValue"](requirementsSpecification.ParameterValue.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("requirement", this.PropertySerializerMap["requirement"](requirementsSpecification.Requirement.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](requirementsSpecification.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](requirementsSpecification.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](requirementsSpecification.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RequirementsSpecification"/> class.
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

            var requirementsSpecification = thing as RequirementsSpecification;
            if (requirementsSpecification == null)
            {
                throw new InvalidOperationException("The thing is not a RequirementsSpecification.");
            }

            return this.Serialize(requirementsSpecification);
        }
    }
}
