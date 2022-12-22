// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ReferenceSourceSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski, Jaime Bernar
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Nodes;

    using CDP4Common.DTO;
    using CDP4Common.Types;
    
    /// <summary>
    /// The purpose of the <see cref="ReferenceSourceSerializer"/> class is to provide a <see cref="ReferenceSource"/> specific serializer
    /// </summary>
    public class ReferenceSourceSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "alias", alias => JsonValue.Create(alias) },
            { "author", author => JsonValue.Create(author) },
            { "category", category => JsonValue.Create(category) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "definition", definition => JsonValue.Create(definition) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            { "iid", iid => JsonValue.Create(iid) },
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            { "language", language => JsonValue.Create(language) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "publicationYear", publicationYear => JsonValue.Create(publicationYear) },
            { "publishedIn", publishedIn => JsonValue.Create(publishedIn) },
            { "publisher", publisher => JsonValue.Create(publisher) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "versionDate", versionDate => JsonValue.Create(versionDate != null ? ((DateTime)versionDate).ToString("yyyy-MM-ddTHH:mm:ss.fffZ") : null) },
            { "versionIdentifier", versionIdentifier => JsonValue.Create(versionIdentifier) },
        };

        /// <summary>
        /// Serialize the <see cref="ReferenceSource"/>
        /// </summary>
        /// <param name="referenceSource">The <see cref="ReferenceSource"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ReferenceSource referenceSource)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](referenceSource.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("author", this.PropertySerializerMap["author"](referenceSource.Author));
            jsonObject.Add("category", this.PropertySerializerMap["category"](referenceSource.Category.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), referenceSource.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](referenceSource.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](referenceSource.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](referenceSource.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](referenceSource.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](referenceSource.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](referenceSource.IsDeprecated));
            jsonObject.Add("language", this.PropertySerializerMap["language"](referenceSource.Language));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](referenceSource.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](referenceSource.Name));
            jsonObject.Add("publicationYear", this.PropertySerializerMap["publicationYear"](referenceSource.PublicationYear));
            jsonObject.Add("publishedIn", this.PropertySerializerMap["publishedIn"](referenceSource.PublishedIn));
            jsonObject.Add("publisher", this.PropertySerializerMap["publisher"](referenceSource.Publisher));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](referenceSource.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](referenceSource.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](referenceSource.ThingPreference));
            jsonObject.Add("versionDate", this.PropertySerializerMap["versionDate"](referenceSource.VersionDate));
            jsonObject.Add("versionIdentifier", this.PropertySerializerMap["versionIdentifier"](referenceSource.VersionIdentifier));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ReferenceSource"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JsonValue>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        public JsonObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
            }

            var referenceSource = thing as ReferenceSource;
            if (referenceSource == null)
            {
                throw new InvalidOperationException("The thing is not a ReferenceSource.");
            }

            return this.Serialize(referenceSource);
        }
    }
}
