// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeProposalMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | approvedBy                           | Guid                         | 0..*        |  1.1.0  |
 | 3     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 4     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 5     | changeRequest                        | Guid                         | 1..1        |  1.1.0  |
 | 6     | classification                       | AnnotationClassificationKind | 1..1        |  1.1.0  |
 | 7     | content                              | string                       | 1..1        |  1.1.0  |
 | 8     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 9     | discussion                           | Guid                         | 0..*        |  1.1.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 13    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 14    | owner                                | Guid                         | 1..1        |  1.1.0  |
 | 15    | primaryAnnotatedThing                | Guid                         | 0..1        |  1.1.0  |
 | 16    | relatedThing                         | Guid                         | 0..*        |  1.1.0  |
 | 17    | shortName                            | string                       | 1..1        |  1.1.0  |
 | 18    | sourceAnnotation                     | Guid                         | 0..*        |  1.1.0  |
 | 19    | status                               | AnnotationStatusKind         | 1..1        |  1.1.0  |
 | 20    | title                                | string                       | 1..1        |  1.1.0  |
 | 21    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 22    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="ChangeProposalMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ChangeProposal"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class ChangeProposalMessagePackFormatter : IMessagePackFormatter<ChangeProposal>
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
        /// Serializes an <see cref="ChangeProposal"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="changeProposal">
        /// The <see cref="ChangeProposal"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ChangeProposal changeProposal, MessagePackSerializerOptions options)
        {
            if (changeProposal == null)
            {
                throw new ArgumentNullException(nameof(changeProposal), "The ChangeProposal may not be null");
            }

            writer.WriteArrayHeader(23);

            writer.Write(changeProposal.Iid.ToByteArray());
            writer.Write(changeProposal.RevisionNumber);

            writer.WriteArrayHeader(changeProposal.ApprovedBy.Count);
            foreach (var identifier in changeProposal.ApprovedBy.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeProposal.Author.ToByteArray());
            writer.WriteArrayHeader(changeProposal.Category.Count);
            foreach (var identifier in changeProposal.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeProposal.ChangeRequest.ToByteArray());
            writer.Write(changeProposal.Classification.ToString());
            writer.Write(changeProposal.Content);
            writer.Write(changeProposal.CreatedOn);
            writer.WriteArrayHeader(changeProposal.Discussion.Count);
            foreach (var identifier in changeProposal.Discussion.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(changeProposal.ExcludedDomain.Count);
            foreach (var identifier in changeProposal.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(changeProposal.ExcludedPerson.Count);
            foreach (var identifier in changeProposal.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeProposal.LanguageCode);
            writer.Write(changeProposal.ModifiedOn);
            writer.Write(changeProposal.Owner.ToByteArray());
            if (changeProposal.PrimaryAnnotatedThing.HasValue)
            {
                writer.Write(changeProposal.PrimaryAnnotatedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(changeProposal.RelatedThing.Count);
            foreach (var identifier in changeProposal.RelatedThing.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeProposal.ShortName);
            writer.WriteArrayHeader(changeProposal.SourceAnnotation.Count);
            foreach (var identifier in changeProposal.SourceAnnotation.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeProposal.Status.ToString());
            writer.Write(changeProposal.Title);
            writer.Write(changeProposal.ThingPreference);
            if (changeProposal.Actor.HasValue)
            {
                writer.Write(changeProposal.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ChangeProposal"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ChangeProposal"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ChangeProposal"/>.
        /// </returns>
        public ChangeProposal Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var changeProposal = new ChangeProposal();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        changeProposal.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        changeProposal.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeProposal.ApprovedBy.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        changeProposal.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeProposal.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        changeProposal.ChangeRequest = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        changeProposal.Classification = (CDP4Common.ReportingData.AnnotationClassificationKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), reader.ReadString(), true);
                        break;
                    case 7:
                        changeProposal.Content = reader.ReadString();
                        break;
                    case 8:
                        changeProposal.CreatedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeProposal.Discussion.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeProposal.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeProposal.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        changeProposal.LanguageCode = reader.ReadString();
                        break;
                    case 13:
                        changeProposal.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 14:
                        changeProposal.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            changeProposal.PrimaryAnnotatedThing = null;
                        }
                        else
                        {
                            changeProposal.PrimaryAnnotatedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeProposal.RelatedThing.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        changeProposal.ShortName = reader.ReadString();
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeProposal.SourceAnnotation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        changeProposal.Status = (CDP4Common.ReportingData.AnnotationStatusKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationStatusKind), reader.ReadString(), true);
                        break;
                    case 20:
                        changeProposal.Title = reader.ReadString();
                        break;
                    case 21:
                        changeProposal.ThingPreference = reader.ReadString();
                        break;
                    case 22:
                        if (reader.TryReadNil())
                        {
                            changeProposal.Actor = null;
                        }
                        else
                        {
                            changeProposal.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return changeProposal;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
