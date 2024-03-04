// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractChangeNoticeMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | approvedBy                           | Guid                         | 0..*        |  1.1.0  |
 | 3     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 4     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 5     | changeProposal                       | Guid                         | 1..1        |  1.1.0  |
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
    /// The purpose of the <see cref="ContractChangeNoticeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ContractChangeNotice"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class ContractChangeNoticeMessagePackFormatter : IMessagePackFormatter<ContractChangeNotice>
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
        /// Serializes an <see cref="ContractChangeNotice"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="contractChangeNotice">
        /// The <see cref="ContractChangeNotice"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ContractChangeNotice contractChangeNotice, MessagePackSerializerOptions options)
        {
            if (contractChangeNotice == null)
            {
                throw new ArgumentNullException(nameof(contractChangeNotice), "The ContractChangeNotice may not be null");
            }

            writer.WriteArrayHeader(23);

            writer.Write(contractChangeNotice.Iid.ToByteArray());
            writer.Write(contractChangeNotice.RevisionNumber);

            writer.WriteArrayHeader(contractChangeNotice.ApprovedBy.Count);
            foreach (var identifier in contractChangeNotice.ApprovedBy.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(contractChangeNotice.Author.ToByteArray());
            writer.WriteArrayHeader(contractChangeNotice.Category.Count);
            foreach (var identifier in contractChangeNotice.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(contractChangeNotice.ChangeProposal.ToByteArray());
            writer.Write(contractChangeNotice.Classification.ToString());
            writer.Write(contractChangeNotice.Content);
            writer.Write(contractChangeNotice.CreatedOn);
            writer.WriteArrayHeader(contractChangeNotice.Discussion.Count);
            foreach (var identifier in contractChangeNotice.Discussion.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(contractChangeNotice.ExcludedDomain.Count);
            foreach (var identifier in contractChangeNotice.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(contractChangeNotice.ExcludedPerson.Count);
            foreach (var identifier in contractChangeNotice.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(contractChangeNotice.LanguageCode);
            writer.Write(contractChangeNotice.ModifiedOn);
            writer.Write(contractChangeNotice.Owner.ToByteArray());
            if (contractChangeNotice.PrimaryAnnotatedThing.HasValue)
            {
                writer.Write(contractChangeNotice.PrimaryAnnotatedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(contractChangeNotice.RelatedThing.Count);
            foreach (var identifier in contractChangeNotice.RelatedThing.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(contractChangeNotice.ShortName);
            writer.WriteArrayHeader(contractChangeNotice.SourceAnnotation.Count);
            foreach (var identifier in contractChangeNotice.SourceAnnotation.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(contractChangeNotice.Status.ToString());
            writer.Write(contractChangeNotice.Title);
            writer.Write(contractChangeNotice.ThingPreference);
            if (contractChangeNotice.Actor.HasValue)
            {
                writer.Write(contractChangeNotice.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ContractChangeNotice"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ContractChangeNotice"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ContractChangeNotice"/>.
        /// </returns>
        public ContractChangeNotice Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var contractChangeNotice = new ContractChangeNotice();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        contractChangeNotice.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        contractChangeNotice.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            contractChangeNotice.ApprovedBy.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        contractChangeNotice.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            contractChangeNotice.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        contractChangeNotice.ChangeProposal = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        contractChangeNotice.Classification = (CDP4Common.ReportingData.AnnotationClassificationKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), reader.ReadString(), true);
                        break;
                    case 7:
                        contractChangeNotice.Content = reader.ReadString();
                        break;
                    case 8:
                        contractChangeNotice.CreatedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            contractChangeNotice.Discussion.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            contractChangeNotice.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            contractChangeNotice.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        contractChangeNotice.LanguageCode = reader.ReadString();
                        break;
                    case 13:
                        contractChangeNotice.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 14:
                        contractChangeNotice.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            contractChangeNotice.PrimaryAnnotatedThing = null;
                        }
                        else
                        {
                            contractChangeNotice.PrimaryAnnotatedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            contractChangeNotice.RelatedThing.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        contractChangeNotice.ShortName = reader.ReadString();
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            contractChangeNotice.SourceAnnotation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        contractChangeNotice.Status = (CDP4Common.ReportingData.AnnotationStatusKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationStatusKind), reader.ReadString(), true);
                        break;
                    case 20:
                        contractChangeNotice.Title = reader.ReadString();
                        break;
                    case 21:
                        contractChangeNotice.ThingPreference = reader.ReadString();
                        break;
                    case 22:
                        if (reader.TryReadNil())
                        {
                            contractChangeNotice.Actor = null;
                        }
                        else
                        {
                            contractChangeNotice.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return contractChangeNotice;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
