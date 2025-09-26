// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueGroupSerializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

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
    /// The purpose of the <see cref="ValueGroupSerializer"/> class is to provide a <see cref="ValueGroup"/> specific serializer
    /// </summary>
    public class ValueGroupSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "alias", alias => new JArray(alias) },
            { "category", category => new JArray(category) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="ValueGroup"/>
        /// </summary>
        /// <param name="valueGroup">The <see cref="ValueGroup"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ValueGroup valueGroup)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](valueGroup.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("category", this.PropertySerializerMap["category"](valueGroup.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), valueGroup.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](valueGroup.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](valueGroup.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](valueGroup.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](valueGroup.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](valueGroup.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](valueGroup.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](valueGroup.Name));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](valueGroup.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](valueGroup.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](valueGroup.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ValueGroup"/> class.
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

            var valueGroup = thing as ValueGroup;
            if (valueGroup == null)
            {
                throw new InvalidOperationException("The thing is not a ValueGroup.");
            }

            return this.Serialize(valueGroup);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
