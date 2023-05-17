// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteDirectoryDataAnnotationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryDataAnnotationSerializer"/> class is to provide a <see cref="SiteDirectoryDataAnnotation"/> specific serializer
    /// </summary>
    public class SiteDirectoryDataAnnotationSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            
            
            
            
            { "author", author => JsonValue.Create(author) },
            
            
            
            
            
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            
            
            
            
            
            { "content", content => JsonValue.Create(content) },
            
            
            
            
            
            { "createdOn", createdOn => JsonValue.Create(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            
            
            
            
            
            { "discussion", discussion => JsonValue.Create(discussion) },
            
            
            
            
            
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            
            
            
            
            
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            
            
            
            
            
            { "iid", iid => JsonValue.Create(iid) },
            
            
            
            
            
            { "languageCode", languageCode => JsonValue.Create(languageCode) },
            
            
            
            
            
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            
            
            
            
            
            { "primaryAnnotatedThing", primaryAnnotatedThing => JsonValue.Create(primaryAnnotatedThing) },
            
            
            
            
            
            { "relatedThing", relatedThing => JsonValue.Create(relatedThing) },
            
            
            
            
            
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            
            
            
            
            
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            
            
        };

        /// <summary>
        /// Serialize the <see cref="SiteDirectoryDataAnnotation"/>
        /// </summary>
        /// <param name="siteDirectoryDataAnnotation">The <see cref="SiteDirectoryDataAnnotation"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(SiteDirectoryDataAnnotation siteDirectoryDataAnnotation)
        {
            var jsonObject = new JsonObject
            {
                {"author", this.PropertySerializerMap["author"](siteDirectoryDataAnnotation.Author)},
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteDirectoryDataAnnotation.ClassKind))},
                {"content", this.PropertySerializerMap["content"](siteDirectoryDataAnnotation.Content)},
                {"createdOn", this.PropertySerializerMap["createdOn"](siteDirectoryDataAnnotation.CreatedOn)},
                {"discussion", this.PropertySerializerMap["discussion"](siteDirectoryDataAnnotation.Discussion.OrderBy(x => x, this.guidComparer))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](siteDirectoryDataAnnotation.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](siteDirectoryDataAnnotation.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](siteDirectoryDataAnnotation.Iid)},
                {"languageCode", this.PropertySerializerMap["languageCode"](siteDirectoryDataAnnotation.LanguageCode)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](siteDirectoryDataAnnotation.ModifiedOn)},
                {"primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](siteDirectoryDataAnnotation.PrimaryAnnotatedThing)},
                {"relatedThing", this.PropertySerializerMap["relatedThing"](siteDirectoryDataAnnotation.RelatedThing.OrderBy(x => x, this.guidComparer))},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](siteDirectoryDataAnnotation.RevisionNumber)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](siteDirectoryDataAnnotation.ThingPreference)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteDirectoryDataAnnotation"/> class.
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

            if (thing is not SiteDirectoryDataAnnotation siteDirectoryDataAnnotation)
            {
                throw new InvalidOperationException("The thing is not a SiteDirectoryDataAnnotation.");
            }

            return this.Serialize(siteDirectoryDataAnnotation);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
