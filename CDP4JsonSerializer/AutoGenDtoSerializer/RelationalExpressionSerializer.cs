// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RelationalExpressionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RelationalExpressionSerializer"/> class is to provide a <see cref="RelationalExpression"/> specific serializer
    /// </summary>
    public class RelationalExpressionSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new()
        {
            
            
            
            
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            
            
            
            
            
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            
            
            
            
            
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            
            
            
            
            
            { "iid", iid => JsonValue.Create(iid) },
            
            
            
            
            
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            
            
            
            
            
            { "parameterType", parameterType => JsonValue.Create(parameterType) },
            
            
            
            
            
            { "relationalOperator", relationalOperator => JsonValue.Create(relationalOperator.ToString()) },
            
            
            
            
            
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            
            
            
            
            
            { "scale", scale => JsonValue.Create(scale) },
            
            
            
            
            
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            
            
            
            
            
            { "value", value => JsonValue.Create(((ValueArray<string>)value).ToJsonString()) },
            
            
        };

        /// <summary>
        /// Serialize the <see cref="RelationalExpression"/>
        /// </summary>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(RelationalExpression relationalExpression)
        {
            var jsonObject = new JsonObject
            {
                {"classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), relationalExpression.ClassKind))},
                {"excludedDomain", this.PropertySerializerMap["excludedDomain"](relationalExpression.ExcludedDomain.OrderBy(x => x, this.guidComparer))},
                {"excludedPerson", this.PropertySerializerMap["excludedPerson"](relationalExpression.ExcludedPerson.OrderBy(x => x, this.guidComparer))},
                {"iid", this.PropertySerializerMap["iid"](relationalExpression.Iid)},
                {"modifiedOn", this.PropertySerializerMap["modifiedOn"](relationalExpression.ModifiedOn)},
                {"parameterType", this.PropertySerializerMap["parameterType"](relationalExpression.ParameterType)},
                {"relationalOperator", this.PropertySerializerMap["relationalOperator"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.RelationalOperatorKind), relationalExpression.RelationalOperator))},
                {"revisionNumber", this.PropertySerializerMap["revisionNumber"](relationalExpression.RevisionNumber)},
                {"scale", this.PropertySerializerMap["scale"](relationalExpression.Scale)},
                {"thingPreference", this.PropertySerializerMap["thingPreference"](relationalExpression.ThingPreference)},
                {"value", this.PropertySerializerMap["value"](relationalExpression.Value)},
            };

            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RelationalExpression"/> class.
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

            if (thing is not RelationalExpression relationalExpression)
            {
                throw new InvalidOperationException("The thing is not a RelationalExpression.");
            }

            return this.Serialize(relationalExpression);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
