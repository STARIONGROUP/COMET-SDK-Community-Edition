// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArrayParameterTypeMessagePackFormatter.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
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
 | 4     | component                            | Guid                         | 1..*        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | dimension                            | int                          | 1..*        |  1.0.0  |
 | 7     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 8     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 9     | isFinalized                          | bool                         | 1..1        |  1.0.0  |
 | 10    | isTensor                             | bool                         | 1..1        |  1.0.0  |
 | 11    | name                                 | string                       | 1..1        |  1.0.0  |
 | 12    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 13    | symbol                               | string                       | 1..1        |  1.0.0  |
 | 14    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 16    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 17    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 18    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="ArrayParameterTypeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ArrayParameterType"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ArrayParameterTypeMessagePackFormatter : IMessagePackFormatter<ArrayParameterType>
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
        /// Serializes an <see cref="ArrayParameterType"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="arrayParameterType">
        /// The <see cref="ArrayParameterType"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ArrayParameterType arrayParameterType, MessagePackSerializerOptions options)
        {
            if (arrayParameterType == null)
            {
                throw new ArgumentNullException(nameof(arrayParameterType), "The ArrayParameterType may not be null");
            }

            writer.WriteArrayHeader(19);

            writer.Write(arrayParameterType.Iid.ToByteArray());
            writer.Write(arrayParameterType.RevisionNumber);

            writer.WriteArrayHeader(arrayParameterType.Alias.Count);
            foreach (var identifier in arrayParameterType.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(arrayParameterType.Category.Count);
            foreach (var identifier in arrayParameterType.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(arrayParameterType.Component.Count);
            foreach (var orderedItem in arrayParameterType.Component.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.WriteArrayHeader(arrayParameterType.Definition.Count);
            foreach (var identifier in arrayParameterType.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(arrayParameterType.Dimension.Count);
            foreach (var orderedItem in arrayParameterType.Dimension.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.WriteArrayHeader(arrayParameterType.HyperLink.Count);
            foreach (var identifier in arrayParameterType.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(arrayParameterType.IsDeprecated);
            writer.Write(arrayParameterType.IsFinalized);
            writer.Write(arrayParameterType.IsTensor);
            writer.Write(arrayParameterType.Name);
            writer.Write(arrayParameterType.ShortName);
            writer.Write(arrayParameterType.Symbol);
            writer.WriteArrayHeader(arrayParameterType.ExcludedDomain.Count);
            foreach (var identifier in arrayParameterType.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(arrayParameterType.ExcludedPerson.Count);
            foreach (var identifier in arrayParameterType.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(arrayParameterType.ModifiedOn);
            writer.Write(arrayParameterType.ThingPreference);
            if (arrayParameterType.Actor.HasValue)
            {
                writer.Write(arrayParameterType.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ArrayParameterType"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ArrayParameterType"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ArrayParameterType"/>.
        /// </returns>
        public ArrayParameterType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var arrayParameterType = new ArrayParameterType();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        arrayParameterType.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        arrayParameterType.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            arrayParameterType.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            arrayParameterType.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            arrayParameterType.Component.Add(orderedItem);
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            arrayParameterType.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            arrayParameterType.Dimension.Add(orderedItem);
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            arrayParameterType.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        arrayParameterType.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 9:
                        arrayParameterType.IsFinalized = reader.ReadBoolean();
                        break;
                    case 10:
                        arrayParameterType.IsTensor = reader.ReadBoolean();
                        break;
                    case 11:
                        arrayParameterType.Name = reader.ReadString();
                        break;
                    case 12:
                        arrayParameterType.ShortName = reader.ReadString();
                        break;
                    case 13:
                        arrayParameterType.Symbol = reader.ReadString();
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            arrayParameterType.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            arrayParameterType.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        arrayParameterType.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 17:
                        arrayParameterType.ThingPreference = reader.ReadString();
                        break;
                    case 18:
                        if (reader.TryReadNil())
                        {
                            arrayParameterType.Actor = null;
                        }
                        else
                        {
                            arrayParameterType.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return arrayParameterType;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
