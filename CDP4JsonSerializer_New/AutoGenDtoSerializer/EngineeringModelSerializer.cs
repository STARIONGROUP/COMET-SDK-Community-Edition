// --------------------------------------------------------------------------------------------------------------------
// <copyright file "EngineeringModelSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelSerializer"/> class is to provide a <see cref="EngineeringModel"/> specific serializer
    /// </summary>
    public class EngineeringModelSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "book", book => JsonValue.Create(((IEnumerable)book).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "commonFileStore", commonFileStore => JsonValue.Create(commonFileStore) },
            { "engineeringModelSetup", engineeringModelSetup => JsonValue.Create(engineeringModelSetup) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "genericNote", genericNote => JsonValue.Create(genericNote) },
            { "iid", iid => JsonValue.Create(iid) },
            { "iteration", iteration => JsonValue.Create(iteration) },
            { "lastModifiedOn", lastModifiedOn => JsonValue.Create(((DateTime)lastModifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "logEntry", logEntry => JsonValue.Create(logEntry) },
            { "modellingAnnotation", modellingAnnotation => JsonValue.Create(modellingAnnotation) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="EngineeringModel"/>
        /// </summary>
        /// <param name="engineeringModel">The <see cref="EngineeringModel"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(EngineeringModel engineeringModel)
        {
            var jsonObject = new JsonObject();
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

            var engineeringModel = thing as EngineeringModel;
            if (engineeringModel == null)
            {
                throw new InvalidOperationException("The thing is not a EngineeringModel.");
            }

            return this.Serialize(engineeringModel);
        }
    }
}
