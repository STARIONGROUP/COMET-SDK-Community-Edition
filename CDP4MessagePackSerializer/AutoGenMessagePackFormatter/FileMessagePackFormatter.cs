// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 3     | fileRevision                         | Guid                         | 1..*        |  1.0.0  |
 | 4     | lockedBy                             | Guid                         | 0..1        |  1.0.0  |
 | 5     | owner                                | Guid                         | 1..1        |  1.0.0  |
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
    /// The purpose of the <see cref="FileMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="File"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class FileMessagePackFormatter : IMessagePackFormatter<File>
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
        /// Serializes an <see cref="File"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="file">
        /// The <see cref="File"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, File file, MessagePackSerializerOptions options)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "The File may not be null");
            }

            writer.WriteArrayHeader(11);

            writer.Write(file.Iid.ToByteArray());
            writer.Write(file.RevisionNumber);

            writer.WriteArrayHeader(file.Category.Count);
            foreach (var identifier in file.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(file.FileRevision.Count);
            foreach (var identifier in file.FileRevision.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (file.LockedBy.HasValue)
            {
                writer.Write(file.LockedBy.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(file.Owner.ToByteArray());
            writer.WriteArrayHeader(file.ExcludedDomain.Count);
            foreach (var identifier in file.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(file.ExcludedPerson.Count);
            foreach (var identifier in file.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(file.ModifiedOn);
            writer.Write(file.ThingPreference);
            if (file.Actor.HasValue)
            {
                writer.Write(file.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="File"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="File"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="File"/>.
        /// </returns>
        public File Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var file = new File();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        file.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        file.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            file.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            file.FileRevision.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            file.LockedBy = null;
                        }
                        else
                        {
                            file.LockedBy = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        file.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            file.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            file.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        file.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        file.ThingPreference = reader.ReadString();
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            file.Actor = null;
                        }
                        else
                        {
                            file.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return file;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
