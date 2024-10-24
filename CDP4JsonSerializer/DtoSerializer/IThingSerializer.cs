// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IThingSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Nodes;

    using CDP4Common.DTO;

    /// <summary>
    /// Definition of the <see cref="IThingSerializer" /> used to serialize instances of <see cref="Thing" /> to a
    /// <see cref="JsonObject" />
    /// </summary>
    public interface IThingSerializer
    {
        /// <summary>
        /// Serialize a value for a <see cref="ActionItem"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer);

        /// <summary>
        /// Serialize a value for a <see cref="ActionItem"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer, Version requestedDataModelVersion);

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/></param>
        void Serialize(Thing thing, Utf8JsonWriter writer);

        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version"/> that has been requested for the serialization</param>
        void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion);
    }
}
