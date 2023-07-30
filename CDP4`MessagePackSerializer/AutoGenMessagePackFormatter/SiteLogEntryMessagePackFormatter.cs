// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteLogEntryMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | affectedDomainIid                    | Guid                         | 0..*        |  1.0.0  |
 | 3     | affectedItemIid                      | Guid                         | 0..*        |  1.0.0  |
 | 4     | author                               | Guid                         | 0..1        |  1.0.0  |
 | 5     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 6     | content                              | string                       | 1..1        |  1.0.0  |
 | 7     | createdOn                            | DateTime                     | 1..1        |  1.0.0  |
 | 8     | languageCode                         | string                       | 1..1        |  1.0.0  |
 | 9     | level                                | LogLevelKind                 | 1..1        |  1.0.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | logEntryChangelogItem                | Guid                         | 0..*        |  1.2.0  |
 | 14    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="SiteLogEntryMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SiteLogEntry"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class SiteLogEntryMessagePackFormatter : IMessagePackFormatter<SiteLogEntry>
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
        /// Serializes an <see cref="SiteLogEntry"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="siteLogEntry">
        /// The <see cref="SiteLogEntry"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SiteLogEntry siteLogEntry, MessagePackSerializerOptions options)
        {
            if (siteLogEntry == null)
            {
                throw new ArgumentNullException(nameof(siteLogEntry), "The SiteLogEntry may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(siteLogEntry.Iid.ToByteArray());
            writer.Write(siteLogEntry.RevisionNumber);

            writer.WriteArrayHeader(siteLogEntry.AffectedDomainIid.Count);
            foreach (var identifier in siteLogEntry.AffectedDomainIid)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteLogEntry.AffectedItemIid.Count);
            foreach (var identifier in siteLogEntry.AffectedItemIid)
            {
                writer.Write(identifier.ToByteArray());
            }
            if (siteLogEntry.Author.HasValue)
            {
                writer.Write(siteLogEntry.Author.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(siteLogEntry.Category.Count);
            foreach (var identifier in siteLogEntry.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteLogEntry.Content);
            writer.Write(siteLogEntry.CreatedOn);
            writer.Write(siteLogEntry.LanguageCode);
            writer.Write(siteLogEntry.Level.ToString());
            writer.WriteArrayHeader(siteLogEntry.ExcludedDomain.Count);
            foreach (var identifier in siteLogEntry.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteLogEntry.ExcludedPerson.Count);
            foreach (var identifier in siteLogEntry.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteLogEntry.ModifiedOn);
            writer.WriteArrayHeader(siteLogEntry.LogEntryChangelogItem.Count);
            foreach (var identifier in siteLogEntry.LogEntryChangelogItem.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteLogEntry.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SiteLogEntry"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SiteLogEntry"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SiteLogEntry"/>.
        /// </returns>
        public SiteLogEntry Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var siteLogEntry = new SiteLogEntry();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        siteLogEntry.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        siteLogEntry.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteLogEntry.AffectedDomainIid.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteLogEntry.AffectedItemIid.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            siteLogEntry.Author = null;
                        }
                        else
                        {
                            siteLogEntry.Author = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteLogEntry.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        siteLogEntry.Content = reader.ReadString();
                        break;
                    case 7:
                        siteLogEntry.CreatedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        siteLogEntry.LanguageCode = reader.ReadString();
                        break;
                    case 9:
                        siteLogEntry.Level = (CDP4Common.CommonData.LogLevelKind)Enum.Parse(typeof(CDP4Common.CommonData.LogLevelKind), reader.ReadString(), true);
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteLogEntry.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteLogEntry.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        siteLogEntry.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteLogEntry.LogEntryChangelogItem.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        siteLogEntry.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return siteLogEntry;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
