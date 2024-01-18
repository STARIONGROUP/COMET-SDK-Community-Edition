// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | elementUsage                         | Guid                         | 1..*        |  1.0.0  |
 | 3     | isVolatile                           | bool                         | 1..1        |  1.0.0  |
 | 4     | nestedParameter                      | Guid                         | 0..*        |  1.0.0  |
 | 5     | rootElement                          | Guid                         | 1..1        |  1.0.0  |
 | 6     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 9     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 10    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="NestedElementMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="NestedElement"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class NestedElementMessagePackFormatter : IMessagePackFormatter<NestedElement>
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
        /// Serializes an <see cref="NestedElement"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="nestedElement">
        /// The <see cref="NestedElement"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, NestedElement nestedElement, MessagePackSerializerOptions options)
        {
            if (nestedElement == null)
            {
                throw new ArgumentNullException(nameof(nestedElement), "The NestedElement may not be null");
            }

            writer.WriteArrayHeader(11);

            writer.Write(nestedElement.Iid.ToByteArray());
            writer.Write(nestedElement.RevisionNumber);

            writer.WriteArrayHeader(nestedElement.ElementUsage.Count);
            foreach (var orderedItem in nestedElement.ElementUsage.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.Write(nestedElement.IsVolatile);
            writer.WriteArrayHeader(nestedElement.NestedParameter.Count);
            foreach (var identifier in nestedElement.NestedParameter.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(nestedElement.RootElement.ToByteArray());
            writer.WriteArrayHeader(nestedElement.ExcludedDomain.Count);
            foreach (var identifier in nestedElement.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(nestedElement.ExcludedPerson.Count);
            foreach (var identifier in nestedElement.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(nestedElement.ModifiedOn);
            writer.Write(nestedElement.ThingPreference);
            if (nestedElement.Actor.HasValue)
            {
                writer.Write(nestedElement.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="NestedElement"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="NestedElement"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="NestedElement"/>.
        /// </returns>
        public NestedElement Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var nestedElement = new NestedElement();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        nestedElement.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        nestedElement.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            nestedElement.ElementUsage.Add(orderedItem);
                        }
                        break;
                    case 3:
                        nestedElement.IsVolatile = reader.ReadBoolean();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            nestedElement.NestedParameter.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        nestedElement.RootElement = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            nestedElement.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            nestedElement.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        nestedElement.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        nestedElement.ThingPreference = reader.ReadString();
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            nestedElement.Actor = null;
                        }
                        else
                        {
                            nestedElement.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return nestedElement;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
