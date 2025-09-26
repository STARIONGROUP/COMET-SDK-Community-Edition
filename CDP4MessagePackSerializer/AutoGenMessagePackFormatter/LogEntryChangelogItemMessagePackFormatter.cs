// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEntryChangelogItemMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 4     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 5     | affectedItemIid                      | Guid                         | 1..1        |  1.2.0  |
 | 6     | affectedReferenceIid                 | Guid                         | 0..*        |  1.2.0  |
 | 7     | changeDescription                    | string                       | 0..1        |  1.2.0  |
 | 8     | changelogKind                        | LogEntryChangelogItemKind    | 1..1        |  1.2.0  |
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
    /// The purpose of the <see cref="LogEntryChangelogItemMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="LogEntryChangelogItem"/> type
    /// </summary>
    [CDPVersion("1.2.0")]
    public class LogEntryChangelogItemMessagePackFormatter : IMessagePackFormatter<LogEntryChangelogItem>
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
        /// Serializes an <see cref="LogEntryChangelogItem"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="logEntryChangelogItem">
        /// The <see cref="LogEntryChangelogItem"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, LogEntryChangelogItem logEntryChangelogItem, MessagePackSerializerOptions options)
        {
            if (logEntryChangelogItem == null)
            {
                throw new ArgumentNullException(nameof(logEntryChangelogItem), "The LogEntryChangelogItem may not be null");
            }

            writer.WriteArrayHeader(11);

            writer.Write(logEntryChangelogItem.Iid.ToByteArray());
            writer.Write(logEntryChangelogItem.RevisionNumber);

            writer.WriteArrayHeader(logEntryChangelogItem.ExcludedDomain.Count);
            foreach (var identifier in logEntryChangelogItem.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(logEntryChangelogItem.ExcludedPerson.Count);
            foreach (var identifier in logEntryChangelogItem.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(logEntryChangelogItem.ModifiedOn);
            writer.Write(logEntryChangelogItem.AffectedItemIid.ToByteArray());
            writer.WriteArrayHeader(logEntryChangelogItem.AffectedReferenceIid.Count);
            foreach (var identifier in logEntryChangelogItem.AffectedReferenceIid)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(logEntryChangelogItem.ChangeDescription);
            writer.Write(logEntryChangelogItem.ChangelogKind.ToString());
            writer.Write(logEntryChangelogItem.ThingPreference);
            if (logEntryChangelogItem.Actor.HasValue)
            {
                writer.Write(logEntryChangelogItem.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="LogEntryChangelogItem"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="LogEntryChangelogItem"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="LogEntryChangelogItem"/>.
        /// </returns>
        public LogEntryChangelogItem Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var logEntryChangelogItem = new LogEntryChangelogItem();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        logEntryChangelogItem.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        logEntryChangelogItem.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logEntryChangelogItem.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logEntryChangelogItem.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        logEntryChangelogItem.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        logEntryChangelogItem.AffectedItemIid = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            logEntryChangelogItem.AffectedReferenceIid.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        logEntryChangelogItem.ChangeDescription = reader.ReadString();
                        break;
                    case 8:
                        logEntryChangelogItem.ChangelogKind = (CDP4Common.CommonData.LogEntryChangelogItemKind)Enum.Parse(typeof(CDP4Common.CommonData.LogEntryChangelogItemKind), reader.ReadString(), true);
                        break;
                    case 9:
                        logEntryChangelogItem.ThingPreference = reader.ReadString();
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            logEntryChangelogItem.Actor = null;
                        }
                        else
                        {
                            logEntryChangelogItem.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return logEntryChangelogItem;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
