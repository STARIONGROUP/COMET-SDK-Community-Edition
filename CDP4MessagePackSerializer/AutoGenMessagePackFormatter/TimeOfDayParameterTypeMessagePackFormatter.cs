// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeOfDayParameterTypeMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 6     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 9     | symbol                               | string                       | 1..1        |  1.0.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 14    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="TimeOfDayParameterTypeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="TimeOfDayParameterType"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class TimeOfDayParameterTypeMessagePackFormatter : IMessagePackFormatter<TimeOfDayParameterType>
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
        /// Serializes an <see cref="TimeOfDayParameterType"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="timeOfDayParameterType">
        /// The <see cref="TimeOfDayParameterType"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, TimeOfDayParameterType timeOfDayParameterType, MessagePackSerializerOptions options)
        {
            if (timeOfDayParameterType == null)
            {
                throw new ArgumentNullException(nameof(timeOfDayParameterType), "The TimeOfDayParameterType may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(timeOfDayParameterType.Iid.ToByteArray());
            writer.Write(timeOfDayParameterType.RevisionNumber);

            writer.WriteArrayHeader(timeOfDayParameterType.Alias.Count);
            foreach (var identifier in timeOfDayParameterType.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(timeOfDayParameterType.Category.Count);
            foreach (var identifier in timeOfDayParameterType.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(timeOfDayParameterType.Definition.Count);
            foreach (var identifier in timeOfDayParameterType.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(timeOfDayParameterType.HyperLink.Count);
            foreach (var identifier in timeOfDayParameterType.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(timeOfDayParameterType.IsDeprecated);
            writer.Write(timeOfDayParameterType.Name);
            writer.Write(timeOfDayParameterType.ShortName);
            writer.Write(timeOfDayParameterType.Symbol);
            writer.WriteArrayHeader(timeOfDayParameterType.ExcludedDomain.Count);
            foreach (var identifier in timeOfDayParameterType.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(timeOfDayParameterType.ExcludedPerson.Count);
            foreach (var identifier in timeOfDayParameterType.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(timeOfDayParameterType.ModifiedOn);
            writer.Write(timeOfDayParameterType.ThingPreference);
            if (timeOfDayParameterType.Actor.HasValue)
            {
                writer.Write(timeOfDayParameterType.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="TimeOfDayParameterType"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="TimeOfDayParameterType"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="TimeOfDayParameterType"/>.
        /// </returns>
        public TimeOfDayParameterType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var timeOfDayParameterType = new TimeOfDayParameterType();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        timeOfDayParameterType.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        timeOfDayParameterType.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            timeOfDayParameterType.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            timeOfDayParameterType.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            timeOfDayParameterType.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            timeOfDayParameterType.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        timeOfDayParameterType.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 7:
                        timeOfDayParameterType.Name = reader.ReadString();
                        break;
                    case 8:
                        timeOfDayParameterType.ShortName = reader.ReadString();
                        break;
                    case 9:
                        timeOfDayParameterType.Symbol = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            timeOfDayParameterType.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            timeOfDayParameterType.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        timeOfDayParameterType.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        timeOfDayParameterType.ThingPreference = reader.ReadString();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            timeOfDayParameterType.Actor = null;
                        }
                        else
                        {
                            timeOfDayParameterType.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return timeOfDayParameterType;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
