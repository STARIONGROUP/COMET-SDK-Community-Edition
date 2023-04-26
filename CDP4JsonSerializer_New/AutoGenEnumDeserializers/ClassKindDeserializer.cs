// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassKindDeserializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Jaime Bernar
//
//    This file is part of CDP4-SDK Community Edition
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
    using System.Collections.Generic;
    using System.Text.Json;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose of the <see cref="ClassKindDeserializer"/> is to deserialize a JSON object to a <see cref="ClassKind"/>
    /// </summary>
    internal static class ClassKindDeserializer
    {
        /// <summary>
        /// Deserializes the <see cref="JsonElement"/> into a <see cref="ClassKind"/>
        /// </summary>
        /// <param name="jsonElement">the element to deserialize</param>
        /// <returns>the <see cref="ClassKind"/></returns>
        /// <exception cref="ArgumentException">if the <see cref="JsonElement"/> can't be parsed into the <see cref="ClassKind"/></exception>
        internal static ClassKind Deserialize(JsonElement jsonElement)
        {
            var value = jsonElement.GetString();

            if(Enum.TryParse(value, out ClassKind result))
            {
                return result;
            }
            throw new ArgumentException($"{value} is not a valid ClassKind", nameof(value));
        }        
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
