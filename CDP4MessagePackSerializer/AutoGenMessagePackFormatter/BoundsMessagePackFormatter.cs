// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BoundsMessagePackFormatter.cs" company="Starion Group S.A.">
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

/* -------------------------------------------- | ---------------------------- | ----------- | ------- *
 | index | name                                 | Type                         | Cardinality | version |
 | -------------------------------------------- | ---------------------------- | ----------- | ------- |
 | 0     | iid                                  | Guid                         |  1..1       |  1.0.0  |
 | 1     | revisionNumber                       | int                          |  1..1       |  1.0.0  |
 | -------------------------------------------- | ---------------------------- | ----------- | ------- |
 | 2     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 3     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 4     | height                               | float                        | 1..1        |  1.1.0  |
 | 5     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 6     | name                                 | string                       | 1..1        |  1.1.0  |
 | 7     | width                                | float                        | 1..1        |  1.1.0  |
 | 8     | x                                    | float                        | 1..1        |  1.1.0  |
 | 9     | y                                    | float                        | 1..1        |  1.1.0  |
 | 10    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 11    | actor                                | Guid                         | 0..1        |  1.3.0  |
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common;
    using CDP4Common.Comparers;
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// The purpose of the <see cref="BoundsMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Bounds"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class BoundsMessagePackFormatter : IMessagePackFormatter<Bounds>
    {
        /// <summary>
        /// The <see cref="GuidComparer"/> used to compare 2 <see cref="Guid"/>s
        /// </summary>
        private static readonly GuidComparer guidComparer = new GuidComparer();

        /// <summary>
        /// The <see cref="OrderedItemComparer"/> used to compare 2 <see cref="OrderedItem"/>s
        /// </summary>
        private static readonly OrderedItemComparer orderedItemComparer = new OrderedItemComparer();

        /// <summary>
        /// Serializes an <see cref="Bounds"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="bounds">
        /// The <see cref="Bounds"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Bounds bounds, MessagePackSerializerOptions options)
        {
            if (bounds == null)
            {
                throw new ArgumentNullException(nameof(bounds), "The Bounds may not be null");
            }

            writer.WriteArrayHeader(12);

            writer.Write(bounds.Iid.ToByteArray());
            writer.Write(bounds.RevisionNumber);

            writer.WriteArrayHeader(bounds.ExcludedDomain.Count);
            foreach (var identifier in bounds.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(bounds.ExcludedPerson.Count);
            foreach (var identifier in bounds.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(bounds.Height);
            writer.Write(bounds.ModifiedOn);
            writer.Write(bounds.Name);
            writer.Write(bounds.Width);
            writer.Write(bounds.X);
            writer.Write(bounds.Y);
            writer.Write(bounds.ThingPreference);
            if (bounds.Actor.HasValue)
            {
                writer.Write(bounds.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Bounds"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Bounds"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Bounds"/>.
        /// </returns>
        public Bounds Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var bounds = new Bounds();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        bounds.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        bounds.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            bounds.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            bounds.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        bounds.Height = reader.ReadSingle();
                        break;
                    case 5:
                        bounds.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 6:
                        bounds.Name = reader.ReadString();
                        break;
                    case 7:
                        bounds.Width = reader.ReadSingle();
                        break;
                    case 8:
                        bounds.X = reader.ReadSingle();
                        break;
                    case 9:
                        bounds.Y = reader.ReadSingle();
                        break;
                    case 10:
                        bounds.ThingPreference = reader.ReadString();
                        break;
                    case 11:
                        if (reader.TryReadNil())
                        {
                            bounds.Actor = null;
                        }
                        else
                        {
                            bounds.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return bounds;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
