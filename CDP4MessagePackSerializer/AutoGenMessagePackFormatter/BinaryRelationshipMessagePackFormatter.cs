// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 3     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 4     | source                               | Guid                         | 1..1        |  1.0.0  |
 | 5     | target                               | Guid                         | 1..1        |  1.0.0  |
 | 6     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 9     | parameterValue                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | name                                 | string                       | 0..1        |  1.2.0  |
 | 11    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 12    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="BinaryRelationshipMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="BinaryRelationship"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class BinaryRelationshipMessagePackFormatter : IMessagePackFormatter<BinaryRelationship>
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
        /// Serializes an <see cref="BinaryRelationship"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="binaryRelationship">
        /// The <see cref="BinaryRelationship"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, BinaryRelationship binaryRelationship, MessagePackSerializerOptions options)
        {
            if (binaryRelationship == null)
            {
                throw new ArgumentNullException(nameof(binaryRelationship), "The BinaryRelationship may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(binaryRelationship.Iid.ToByteArray());
            writer.Write(binaryRelationship.RevisionNumber);

            writer.WriteArrayHeader(binaryRelationship.Category.Count);
            foreach (var identifier in binaryRelationship.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(binaryRelationship.Owner.ToByteArray());
            writer.Write(binaryRelationship.Source.ToByteArray());
            writer.Write(binaryRelationship.Target.ToByteArray());
            writer.WriteArrayHeader(binaryRelationship.ExcludedDomain.Count);
            foreach (var identifier in binaryRelationship.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(binaryRelationship.ExcludedPerson.Count);
            foreach (var identifier in binaryRelationship.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(binaryRelationship.ModifiedOn);
            writer.WriteArrayHeader(binaryRelationship.ParameterValue.Count);
            foreach (var identifier in binaryRelationship.ParameterValue.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(binaryRelationship.Name);
            writer.Write(binaryRelationship.ThingPreference);
            if (binaryRelationship.Actor.HasValue)
            {
                writer.Write(binaryRelationship.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="BinaryRelationship"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="BinaryRelationship"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="BinaryRelationship"/>.
        /// </returns>
        public BinaryRelationship Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var binaryRelationship = new BinaryRelationship();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        binaryRelationship.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        binaryRelationship.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationship.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        binaryRelationship.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        binaryRelationship.Source = reader.ReadBytes().ToGuid();
                        break;
                    case 5:
                        binaryRelationship.Target = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationship.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationship.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        binaryRelationship.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationship.ParameterValue.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        binaryRelationship.Name = reader.ReadString();
                        break;
                    case 11:
                        binaryRelationship.ThingPreference = reader.ReadString();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            binaryRelationship.Actor = null;
                        }
                        else
                        {
                            binaryRelationship.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return binaryRelationship;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
