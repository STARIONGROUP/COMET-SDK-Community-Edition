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

namespace CDP4JsonSerializer
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
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
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
            var jsonObject = new JsonObject
            {
                {"alias", this.PropertySerializerMap["alias"](referenceSource.Alias.OrderBy(x => x, this.guidComparer))},
                {"author", this.PropertySerializerMap["author"](referenceSource.Author)},
                {"category", this.PropertySerializerMap["category"](referenceSource.Category.OrderBy(x => x, this.guidComparer))},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), referenceSource.ClassKind))},
                {"definition", this.PropertySerializerMap["definition"](referenceSource.Definition.OrderBy(x => x, this.guidComparer))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](referenceSource.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](referenceSource.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"hyperLink", this.PropertySerializerMap["hyperLink"](referenceSource.HyperLink.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](referenceSource.Iid)},
                {"isDeprecated", this.PropertySerializerMap["isDeprecated"](referenceSource.IsDeprecated)},
                {"language", this.PropertySerializerMap["language"](referenceSource.Language)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](referenceSource.ModifiedOn)},
                {"name", this.PropertySerializerMap["name"](referenceSource.Name)},
                {"publicationYear", this.PropertySerializerMap["publicationYear"](referenceSource.PublicationYear)},
                {"publishedIn", this.PropertySerializerMap["publishedIn"](referenceSource.PublishedIn)},
                {"publisher", this.PropertySerializerMap["publisher"](referenceSource.Publisher)},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](referenceSource.RevisionNumber)},
                {"shortName", this.PropertySerializerMap["shortName"](referenceSource.ShortName)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](referenceSource.ThingPreference)},
                {"versionDate", this.PropertySerializerMap["versionDate"](referenceSource.VersionDate)},
                {"versionIdentifier", this.PropertySerializerMap["versionIdentifier"](referenceSource.VersionIdentifier)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ReferenceSource"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JsonValue>> PropertySerializerMap => this.propertySerializerMap;

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

            if (thing is not ReferenceSource referenceSource)
            {
                throw new InvalidOperationException("The thing is not a ReferenceSource.");
            }

            return this.Serialize(referenceSource);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
