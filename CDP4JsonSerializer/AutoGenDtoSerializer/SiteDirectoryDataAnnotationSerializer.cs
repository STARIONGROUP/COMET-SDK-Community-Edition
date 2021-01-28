// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteDirectoryDataAnnotationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryDataAnnotationSerializer"/> class is to provide a <see cref="SiteDirectoryDataAnnotation"/> specific serializer
    /// </summary>
    public class SiteDirectoryDataAnnotationSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "author", author => new JValue(author) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "content", content => new JValue(content) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "discussion", discussion => new JArray(discussion) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "languageCode", languageCode => new JValue(languageCode) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "primaryAnnotatedThing", primaryAnnotatedThing => new JValue(primaryAnnotatedThing) },
            { "relatedThing", relatedThing => new JArray(relatedThing) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="SiteDirectoryDataAnnotation"/>
        /// </summary>
        /// <param name="siteDirectoryDataAnnotation">The <see cref="SiteDirectoryDataAnnotation"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SiteDirectoryDataAnnotation siteDirectoryDataAnnotation)
        {
            var jsonObject = new JObject();
            jsonObject.Add("author", this.PropertySerializerMap["author"](siteDirectoryDataAnnotation.Author));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteDirectoryDataAnnotation.ClassKind)));
            jsonObject.Add("content", this.PropertySerializerMap["content"](siteDirectoryDataAnnotation.Content));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](siteDirectoryDataAnnotation.CreatedOn));
            jsonObject.Add("discussion", this.PropertySerializerMap["discussion"](siteDirectoryDataAnnotation.Discussion.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteDirectoryDataAnnotation.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteDirectoryDataAnnotation.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteDirectoryDataAnnotation.Iid));
            jsonObject.Add("languageCode", this.PropertySerializerMap["languageCode"](siteDirectoryDataAnnotation.LanguageCode));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteDirectoryDataAnnotation.ModifiedOn));
            jsonObject.Add("primaryAnnotatedThing", this.PropertySerializerMap["primaryAnnotatedThing"](siteDirectoryDataAnnotation.PrimaryAnnotatedThing));
            jsonObject.Add("relatedThing", this.PropertySerializerMap["relatedThing"](siteDirectoryDataAnnotation.RelatedThing.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteDirectoryDataAnnotation.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](siteDirectoryDataAnnotation.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteDirectoryDataAnnotation"/> class.
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

            var siteDirectoryDataAnnotation = thing as SiteDirectoryDataAnnotation;
            if (siteDirectoryDataAnnotation == null)
            {
                throw new InvalidOperationException("The thing is not a SiteDirectoryDataAnnotation.");
            }

            return this.Serialize(siteDirectoryDataAnnotation);
        }
    }
}
