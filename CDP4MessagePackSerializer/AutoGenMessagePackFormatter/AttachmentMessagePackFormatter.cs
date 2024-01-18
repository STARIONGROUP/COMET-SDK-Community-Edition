// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 3     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 4     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 5     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 6     | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 7     | contentHash                          | string                       | 1..1        |  1.4.0  |
 | 8     | fileName                             | string                       | 1..1        |  1.4.0  |
 | 9     | fileType                             | Guid                         | 1..*        |  1.4.0  |
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
    /// The purpose of the <see cref="AttachmentMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Attachment"/> type
    /// </summary>
    [CDPVersion("1.4.0")]
    public class AttachmentMessagePackFormatter : IMessagePackFormatter<Attachment>
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
        /// Serializes an <see cref="Attachment"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="attachment">
        /// The <see cref="Attachment"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Attachment attachment, MessagePackSerializerOptions options)
        {
            if (attachment == null)
            {
                throw new ArgumentNullException(nameof(attachment), "The Attachment may not be null");
            }

            writer.WriteArrayHeader(10);

            writer.Write(attachment.Iid.ToByteArray());
            writer.Write(attachment.RevisionNumber);

            writer.WriteArrayHeader(attachment.ExcludedDomain.Count);
            foreach (var identifier in attachment.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(attachment.ExcludedPerson.Count);
            foreach (var identifier in attachment.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(attachment.ModifiedOn);
            writer.Write(attachment.ThingPreference);
            if (attachment.Actor.HasValue)
            {
                writer.Write(attachment.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(attachment.ContentHash);
            writer.Write(attachment.FileName);
            writer.WriteArrayHeader(attachment.FileType.Count);
            foreach (var identifier in attachment.FileType.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Attachment"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Attachment"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Attachment"/>.
        /// </returns>
        public Attachment Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var attachment = new Attachment();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        attachment.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        attachment.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            attachment.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            attachment.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        attachment.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        attachment.ThingPreference = reader.ReadString();
                        break;
                    case 6:
                        if (reader.TryReadNil())
                        {
                            attachment.Actor = null;
                        }
                        else
                        {
                            attachment.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 7:
                        attachment.ContentHash = reader.ReadString();
                        break;
                    case 8:
                        attachment.FileName = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            attachment.FileType.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return attachment;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
