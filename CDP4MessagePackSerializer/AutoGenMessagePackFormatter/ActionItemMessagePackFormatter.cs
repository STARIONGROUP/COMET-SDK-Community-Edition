// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActionItemMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | actionee                             | Guid                         | 1..1        |  1.1.0  |
 | 3     | approvedBy                           | Guid                         | 0..*        |  1.1.0  |
 | 4     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 5     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 6     | classification                       | AnnotationClassificationKind | 1..1        |  1.1.0  |
 | 7     | closeOutDate                         | DateTime                     | 0..1        |  1.1.0  |
 | 8     | closeOutStatement                    | string                       | 0..1        |  1.1.0  |
 | 9     | content                              | string                       | 1..1        |  1.1.0  |
 | 10    | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 11    | discussion                           | Guid                         | 0..*        |  1.1.0  |
 | 12    | dueDate                              | DateTime                     | 1..1        |  1.1.0  |
 | 13    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 16    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 17    | owner                                | Guid                         | 1..1        |  1.1.0  |
 | 18    | primaryAnnotatedThing                | Guid                         | 0..1        |  1.1.0  |
 | 19    | relatedThing                         | Guid                         | 0..*        |  1.1.0  |
 | 20    | shortName                            | string                       | 1..1        |  1.1.0  |
 | 21    | sourceAnnotation                     | Guid                         | 0..*        |  1.1.0  |
 | 22    | status                               | AnnotationStatusKind         | 1..1        |  1.1.0  |
 | 23    | title                                | string                       | 1..1        |  1.1.0  |
 | 24    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 25    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="ActionItemMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ActionItem"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class ActionItemMessagePackFormatter : IMessagePackFormatter<ActionItem>
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
        /// Serializes an <see cref="ActionItem"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="actionItem">
        /// The <see cref="ActionItem"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ActionItem actionItem, MessagePackSerializerOptions options)
        {
            if (actionItem == null)
            {
                throw new ArgumentNullException(nameof(actionItem), "The ActionItem may not be null");
            }

            writer.WriteArrayHeader(26);

            writer.Write(actionItem.Iid.ToByteArray());
            writer.Write(actionItem.RevisionNumber);

            writer.Write(actionItem.Actionee.ToByteArray());
            writer.WriteArrayHeader(actionItem.ApprovedBy.Count);
            foreach (var identifier in actionItem.ApprovedBy.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(actionItem.Author.ToByteArray());
            writer.WriteArrayHeader(actionItem.Category.Count);
            foreach (var identifier in actionItem.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(actionItem.Classification.ToString());
            if (actionItem.CloseOutDate.HasValue)
            {
                writer.Write(actionItem.CloseOutDate.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(actionItem.CloseOutStatement);
            writer.Write(actionItem.Content);
            writer.Write(actionItem.CreatedOn);
            writer.WriteArrayHeader(actionItem.Discussion.Count);
            foreach (var identifier in actionItem.Discussion.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(actionItem.DueDate);
            writer.WriteArrayHeader(actionItem.ExcludedDomain.Count);
            foreach (var identifier in actionItem.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(actionItem.ExcludedPerson.Count);
            foreach (var identifier in actionItem.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(actionItem.LanguageCode);
            writer.Write(actionItem.ModifiedOn);
            writer.Write(actionItem.Owner.ToByteArray());
            if (actionItem.PrimaryAnnotatedThing.HasValue)
            {
                writer.Write(actionItem.PrimaryAnnotatedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(actionItem.RelatedThing.Count);
            foreach (var identifier in actionItem.RelatedThing.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(actionItem.ShortName);
            writer.WriteArrayHeader(actionItem.SourceAnnotation.Count);
            foreach (var identifier in actionItem.SourceAnnotation.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(actionItem.Status.ToString());
            writer.Write(actionItem.Title);
            writer.Write(actionItem.ThingPreference);
            if (actionItem.Actor.HasValue)
            {
                writer.Write(actionItem.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ActionItem"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ActionItem"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ActionItem"/>.
        /// </returns>
        public ActionItem Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var actionItem = new ActionItem();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        actionItem.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        actionItem.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        actionItem.Actionee = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            actionItem.ApprovedBy.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        actionItem.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            actionItem.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        actionItem.Classification = (CDP4Common.ReportingData.AnnotationClassificationKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), reader.ReadString(), true);
                        break;
                    case 7:
                        if (reader.TryReadNil())
                        {
                            actionItem.CloseOutDate = null;
                        }
                        else
                        {
                            actionItem.CloseOutDate = reader.ReadDateTime();
                        }
                        break;
                    case 8:
                        actionItem.CloseOutStatement = reader.ReadString();
                        break;
                    case 9:
                        actionItem.Content = reader.ReadString();
                        break;
                    case 10:
                        actionItem.CreatedOn = reader.ReadDateTime();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            actionItem.Discussion.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        actionItem.DueDate = reader.ReadDateTime();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            actionItem.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            actionItem.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        actionItem.LanguageCode = reader.ReadString();
                        break;
                    case 16:
                        actionItem.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 17:
                        actionItem.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 18:
                        if (reader.TryReadNil())
                        {
                            actionItem.PrimaryAnnotatedThing = null;
                        }
                        else
                        {
                            actionItem.PrimaryAnnotatedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            actionItem.RelatedThing.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        actionItem.ShortName = reader.ReadString();
                        break;
                    case 21:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            actionItem.SourceAnnotation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 22:
                        actionItem.Status = (CDP4Common.ReportingData.AnnotationStatusKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationStatusKind), reader.ReadString(), true);
                        break;
                    case 23:
                        actionItem.Title = reader.ReadString();
                        break;
                    case 24:
                        actionItem.ThingPreference = reader.ReadString();
                        break;
                    case 25:
                        if (reader.TryReadNil())
                        {
                            actionItem.Actor = null;
                        }
                        else
                        {
                            actionItem.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return actionItem;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
