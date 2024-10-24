// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="VcardTelephoneNumberKindDeserializer.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
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
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.IO;
    using System.Text.Json;

    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose of the <see cref="VcardTelephoneNumberKindDeserializer"/> is to deserialize a JSON object to a <see cref="VcardTelephoneNumberKind"/>
    /// </summary>
    internal static class VcardTelephoneNumberKindDeserializer
    {
        /// <summary>
        /// Deserializes the <see cref="JsonElement"/> into a <see cref="VcardTelephoneNumberKind"/>
        /// </summary>
        /// <param name="jsonElement">the element to deserialize</param>
        /// <returns>the <see cref="VcardTelephoneNumberKind"/></returns>
        /// <exception cref="ArgumentException">if the <see cref="JsonElement"/> can't be parsed into the <see cref="VcardTelephoneNumberKind"/></exception>
        internal static VcardTelephoneNumberKind Deserialize(JsonElement jsonElement)
        {
            var value = jsonElement.GetString();

            return value switch
            {
                "WORK" => VcardTelephoneNumberKind.WORK,
                "HOME" => VcardTelephoneNumberKind.HOME,
                "VOICE" => VcardTelephoneNumberKind.VOICE,
                "TEXT" => VcardTelephoneNumberKind.TEXT,
                "FAX" => VcardTelephoneNumberKind.FAX,
                "CELL" => VcardTelephoneNumberKind.CELL,
                "PAGER" => VcardTelephoneNumberKind.PAGER,
                "TEXTPHONE" => VcardTelephoneNumberKind.TEXTPHONE,
                "VIDEO" => VcardTelephoneNumberKind.VIDEO,
                _ => throw new InvalidDataException($"{value} is not a valid for VcardTelephoneNumberKind")
            };
        }        
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
