// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSerializer.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="EngineeringModelSerializer"/> class is to provide a <see cref="EngineeringModel"/> specific serializer
    /// </summary>
    public class EngineeringModelSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "book", book => new JArray(((IEnumerable)book).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "commonFileStore", commonFileStore => new JArray(commonFileStore) },
            { "engineeringModelSetup", engineeringModelSetup => new JValue(engineeringModelSetup) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "genericNote", genericNote => new JArray(genericNote) },
            { "iid", iid => new JValue(iid) },
            { "iteration", iteration => new JArray(iteration) },
            { "lastModifiedOn", lastModifiedOn => new JValue(((DateTime)lastModifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "logEntry", logEntry => new JArray(logEntry) },
            { "modellingAnnotation", modellingAnnotation => new JArray(modellingAnnotation) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="EngineeringModel"/>
        /// </summary>
        /// <param name="engineeringModel">The <see cref="EngineeringModel"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(EngineeringModel engineeringModel)
        {
            var jsonObject = new JObject();
            jsonObject.Add("book", this.PropertySerializerMap["book"](engineeringModel.Book.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), engineeringModel.ClassKind)));
            jsonObject.Add("commonFileStore", this.PropertySerializerMap["commonFileStore"](engineeringModel.CommonFileStore));
            jsonObject.Add("engineeringModelSetup", this.PropertySerializerMap["engineeringModelSetup"](engineeringModel.EngineeringModelSetup));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](engineeringModel.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](engineeringModel.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("genericNote", this.PropertySerializerMap["genericNote"](engineeringModel.GenericNote.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](engineeringModel.Iid));
            jsonObject.Add("iteration", this.PropertySerializerMap["iteration"](engineeringModel.Iteration.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("lastModifiedOn", this.PropertySerializerMap["lastModifiedOn"](engineeringModel.LastModifiedOn));
            jsonObject.Add("logEntry", this.PropertySerializerMap["logEntry"](engineeringModel.LogEntry.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("modellingAnnotation", this.PropertySerializerMap["modellingAnnotation"](engineeringModel.ModellingAnnotation.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](engineeringModel.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](engineeringModel.RevisionNumber));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](engineeringModel.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="EngineeringModel"/> class.
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

            var engineeringModel = thing as EngineeringModel;
            if (engineeringModel == null)
            {
                throw new InvalidOperationException("The thing is not a EngineeringModel.");
            }

            return this.Serialize(engineeringModel);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
