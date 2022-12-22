// --------------------------------------------------------------------------------------------------------------------
// <copyright file "UserRuleVerificationSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="UserRuleVerificationSerializer"/> class is to provide a <see cref="UserRuleVerification"/> specific serializer
    /// </summary>
    public class UserRuleVerificationSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "executedOn", executedOn => JsonValue.Create(executedOn != null ? ((DateTime)executedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ") : null) },
            { "iid", iid => JsonValue.Create(iid) },
            { "isActive", isActive => JsonValue.Create(isActive) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "rule", rule => JsonValue.Create(rule) },
            { "status", status => JsonValue.Create(status.ToString()) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="UserRuleVerification"/>
        /// </summary>
        /// <param name="userRuleVerification">The <see cref="UserRuleVerification"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(UserRuleVerification userRuleVerification)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), userRuleVerification.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](userRuleVerification.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](userRuleVerification.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("executedOn", this.PropertySerializerMap["executedOn"](userRuleVerification.ExecutedOn));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](userRuleVerification.Iid));
            jsonObject.Add("isActive", this.PropertySerializerMap["isActive"](userRuleVerification.IsActive));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](userRuleVerification.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](userRuleVerification.RevisionNumber));
            jsonObject.Add("rule", this.PropertySerializerMap["rule"](userRuleVerification.Rule));
            jsonObject.Add("status", this.PropertySerializerMap["status"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.RuleVerificationStatusKind), userRuleVerification.Status)));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](userRuleVerification.ThingPreference));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="UserRuleVerification"/> class.
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

            var userRuleVerification = thing as UserRuleVerification;
            if (userRuleVerification == null)
            {
                throw new InvalidOperationException("The thing is not a UserRuleVerification.");
            }

            return this.Serialize(userRuleVerification);
        }
    }
}
