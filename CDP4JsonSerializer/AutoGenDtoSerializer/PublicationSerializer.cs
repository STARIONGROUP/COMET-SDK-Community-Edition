// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PublicationSerializer.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="PublicationSerializer"/> class is to provide a <see cref="Publication"/> specific serializer
    /// </summary>
    public class PublicationSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "domain", domain => new JArray(domain) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "publishedParameter", publishedParameter => new JArray(publishedParameter) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="Publication"/>
        /// </summary>
        /// <param name="publication">The <see cref="Publication"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Publication publication)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), publication.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](publication.CreatedOn));
            jsonObject.Add("domain", this.PropertySerializerMap["domain"](publication.Domain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](publication.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](publication.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](publication.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](publication.ModifiedOn));
            jsonObject.Add("publishedParameter", this.PropertySerializerMap["publishedParameter"](publication.PublishedParameter.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](publication.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](publication.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Publication"/> class.
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

            var publication = thing as Publication;
            if (publication == null)
            {
                throw new InvalidOperationException("The thing is not a Publication.");
            }

            return this.Serialize(publication);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
