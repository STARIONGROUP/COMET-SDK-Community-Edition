// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeParameterTypeMessagePackFormatter.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | attachment                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 10    | symbol                               | string                       | 1..1        |  1.0.0  |
 | 11    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 13    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 14    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 15    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="DateTimeParameterTypeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DateTimeParameterType"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class DateTimeParameterTypeMessagePackFormatter : IMessagePackFormatter<DateTimeParameterType>
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
        /// Serializes an <see cref="DateTimeParameterType"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="dateTimeParameterType">
        /// The <see cref="DateTimeParameterType"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DateTimeParameterType dateTimeParameterType, MessagePackSerializerOptions options)
        {
            if (dateTimeParameterType == null)
            {
                throw new ArgumentNullException(nameof(dateTimeParameterType), "The DateTimeParameterType may not be null");
            }

            writer.WriteArrayHeader(16);

            writer.Write(dateTimeParameterType.Iid.ToByteArray());
            writer.Write(dateTimeParameterType.RevisionNumber);

            writer.WriteArrayHeader(dateTimeParameterType.Alias.Count);
            foreach (var identifier in dateTimeParameterType.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(dateTimeParameterType.Attachment.Count);
            foreach (var identifier in dateTimeParameterType.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(dateTimeParameterType.Category.Count);
            foreach (var identifier in dateTimeParameterType.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(dateTimeParameterType.Definition.Count);
            foreach (var identifier in dateTimeParameterType.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(dateTimeParameterType.HyperLink.Count);
            foreach (var identifier in dateTimeParameterType.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(dateTimeParameterType.IsDeprecated);
            writer.Write(dateTimeParameterType.Name);
            writer.Write(dateTimeParameterType.ShortName);
            writer.Write(dateTimeParameterType.Symbol);
            writer.WriteArrayHeader(dateTimeParameterType.ExcludedDomain.Count);
            foreach (var identifier in dateTimeParameterType.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(dateTimeParameterType.ExcludedPerson.Count);
            foreach (var identifier in dateTimeParameterType.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(dateTimeParameterType.ModifiedOn);
            writer.Write(dateTimeParameterType.ThingPreference);
            if (dateTimeParameterType.Actor.HasValue)
            {
                writer.Write(dateTimeParameterType.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DateTimeParameterType"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DateTimeParameterType"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DateTimeParameterType"/>.
        /// </returns>
        public DateTimeParameterType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var dateTimeParameterType = new DateTimeParameterType();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        dateTimeParameterType.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        dateTimeParameterType.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dateTimeParameterType.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dateTimeParameterType.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dateTimeParameterType.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dateTimeParameterType.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dateTimeParameterType.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        dateTimeParameterType.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        dateTimeParameterType.Name = reader.ReadString();
                        break;
                    case 9:
                        dateTimeParameterType.ShortName = reader.ReadString();
                        break;
                    case 10:
                        dateTimeParameterType.Symbol = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dateTimeParameterType.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            dateTimeParameterType.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        dateTimeParameterType.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 14:
                        dateTimeParameterType.ThingPreference = reader.ReadString();
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            dateTimeParameterType.Actor = null;
                        }
                        else
                        {
                            dateTimeParameterType.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return dateTimeParameterType;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
