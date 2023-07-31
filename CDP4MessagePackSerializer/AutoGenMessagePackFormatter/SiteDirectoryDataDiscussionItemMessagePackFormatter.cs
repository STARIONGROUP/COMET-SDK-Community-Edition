// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryDataDiscussionItemMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 3     | content                              | string                       | 1..1        |  1.1.0  |
 | 4     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 8     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 9     | replyTo                              | Guid                         | 0..1        |  1.1.0  |
 | 10    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="SiteDirectoryDataDiscussionItemMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SiteDirectoryDataDiscussionItem"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class SiteDirectoryDataDiscussionItemMessagePackFormatter : IMessagePackFormatter<SiteDirectoryDataDiscussionItem>
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
        /// Serializes an <see cref="SiteDirectoryDataDiscussionItem"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="siteDirectoryDataDiscussionItem">
        /// The <see cref="SiteDirectoryDataDiscussionItem"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SiteDirectoryDataDiscussionItem siteDirectoryDataDiscussionItem, MessagePackSerializerOptions options)
        {
            if (siteDirectoryDataDiscussionItem == null)
            {
                throw new ArgumentNullException(nameof(siteDirectoryDataDiscussionItem), "The SiteDirectoryDataDiscussionItem may not be null");
            }

            writer.WriteArrayHeader(11);

            writer.Write(siteDirectoryDataDiscussionItem.Iid.ToByteArray());
            writer.Write(siteDirectoryDataDiscussionItem.RevisionNumber);

            writer.Write(siteDirectoryDataDiscussionItem.Author.ToByteArray());
            writer.Write(siteDirectoryDataDiscussionItem.Content);
            writer.Write(siteDirectoryDataDiscussionItem.CreatedOn);
            writer.WriteArrayHeader(siteDirectoryDataDiscussionItem.ExcludedDomain.Count);
            foreach (var identifier in siteDirectoryDataDiscussionItem.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectoryDataDiscussionItem.ExcludedPerson.Count);
            foreach (var identifier in siteDirectoryDataDiscussionItem.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteDirectoryDataDiscussionItem.LanguageCode);
            writer.Write(siteDirectoryDataDiscussionItem.ModifiedOn);
            if (siteDirectoryDataDiscussionItem.ReplyTo.HasValue)
            {
                writer.Write(siteDirectoryDataDiscussionItem.ReplyTo.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(siteDirectoryDataDiscussionItem.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SiteDirectoryDataDiscussionItem"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SiteDirectoryDataDiscussionItem"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SiteDirectoryDataDiscussionItem"/>.
        /// </returns>
        public SiteDirectoryDataDiscussionItem Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var siteDirectoryDataDiscussionItem = new SiteDirectoryDataDiscussionItem();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        siteDirectoryDataDiscussionItem.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        siteDirectoryDataDiscussionItem.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        siteDirectoryDataDiscussionItem.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        siteDirectoryDataDiscussionItem.Content = reader.ReadString();
                        break;
                    case 4:
                        siteDirectoryDataDiscussionItem.CreatedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectoryDataDiscussionItem.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectoryDataDiscussionItem.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        siteDirectoryDataDiscussionItem.LanguageCode = reader.ReadString();
                        break;
                    case 8:
                        siteDirectoryDataDiscussionItem.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        if (reader.TryReadNil())
                        {
                            siteDirectoryDataDiscussionItem.ReplyTo = null;
                        }
                        else
                        {
                            siteDirectoryDataDiscussionItem.ReplyTo = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 10:
                        siteDirectoryDataDiscussionItem.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return siteDirectoryDataDiscussionItem;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
