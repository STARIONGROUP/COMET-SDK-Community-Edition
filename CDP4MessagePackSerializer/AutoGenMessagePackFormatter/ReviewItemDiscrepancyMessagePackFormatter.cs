// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewItemDiscrepancyMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 5     | classification                       | AnnotationClassificationKind | 1..1        |  1.1.0  |
 | 6     | content                              | string                       | 1..1        |  1.1.0  |
 | 7     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 8     | discussion                           | Guid                         | 0..*        |  1.1.0  |
 | 9     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | owner                                | Guid                         | 1..1        |  1.1.0  |
 | 14    | primaryAnnotatedThing                | Guid                         | 0..1        |  1.1.0  |
 | 15    | relatedThing                         | Guid                         | 0..*        |  1.1.0  |
 | 16    | shortName                            | string                       | 1..1        |  1.1.0  |
 | 17    | solution                             | Guid                         | 0..1        |  1.1.0  |
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
    /// The purpose of the <see cref="ReviewItemDiscrepancyMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ReviewItemDiscrepancy"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class ReviewItemDiscrepancyMessagePackFormatter : IMessagePackFormatter<ReviewItemDiscrepancy>
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
        /// Serializes an <see cref="ReviewItemDiscrepancy"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="reviewItemDiscrepancy">
        /// The <see cref="ReviewItemDiscrepancy"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ReviewItemDiscrepancy reviewItemDiscrepancy, MessagePackSerializerOptions options)
        {
            if (reviewItemDiscrepancy == null)
            {
                throw new ArgumentNullException(nameof(reviewItemDiscrepancy), "The ReviewItemDiscrepancy may not be null");
            }

            writer.WriteArrayHeader(23);

            writer.Write(reviewItemDiscrepancy.Iid.ToByteArray());
            writer.Write(reviewItemDiscrepancy.RevisionNumber);

            writer.WriteArrayHeader(reviewItemDiscrepancy.ApprovedBy.Count);
            foreach (var identifier in reviewItemDiscrepancy.ApprovedBy.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(reviewItemDiscrepancy.Author.ToByteArray());
            writer.WriteArrayHeader(reviewItemDiscrepancy.Category.Count);
            foreach (var identifier in reviewItemDiscrepancy.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(reviewItemDiscrepancy.Classification.ToString());
            writer.Write(reviewItemDiscrepancy.Content);
            writer.Write(reviewItemDiscrepancy.CreatedOn);
            writer.WriteArrayHeader(reviewItemDiscrepancy.Discussion.Count);
            foreach (var identifier in reviewItemDiscrepancy.Discussion.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(reviewItemDiscrepancy.ExcludedDomain.Count);
            foreach (var identifier in reviewItemDiscrepancy.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(reviewItemDiscrepancy.ExcludedPerson.Count);
            foreach (var identifier in reviewItemDiscrepancy.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(reviewItemDiscrepancy.LanguageCode);
            writer.Write(reviewItemDiscrepancy.ModifiedOn);
            writer.Write(reviewItemDiscrepancy.Owner.ToByteArray());
            if (reviewItemDiscrepancy.PrimaryAnnotatedThing.HasValue)
            {
                writer.Write(reviewItemDiscrepancy.PrimaryAnnotatedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(reviewItemDiscrepancy.RelatedThing.Count);
            foreach (var identifier in reviewItemDiscrepancy.RelatedThing.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(reviewItemDiscrepancy.ShortName);
            writer.WriteArrayHeader(reviewItemDiscrepancy.Solution.Count);
            foreach (var identifier in reviewItemDiscrepancy.Solution.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(reviewItemDiscrepancy.SourceAnnotation.Count);
            foreach (var identifier in reviewItemDiscrepancy.SourceAnnotation.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(reviewItemDiscrepancy.Status.ToString());
            writer.Write(reviewItemDiscrepancy.Title);
            writer.Write(reviewItemDiscrepancy.ThingPreference);
            if (reviewItemDiscrepancy.Actor.HasValue)
            {
                writer.Write(reviewItemDiscrepancy.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ReviewItemDiscrepancy"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ReviewItemDiscrepancy"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ReviewItemDiscrepancy"/>.
        /// </returns>
        public ReviewItemDiscrepancy Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var reviewItemDiscrepancy = new ReviewItemDiscrepancy();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        reviewItemDiscrepancy.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        reviewItemDiscrepancy.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reviewItemDiscrepancy.ApprovedBy.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        reviewItemDiscrepancy.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reviewItemDiscrepancy.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        reviewItemDiscrepancy.Classification = (CDP4Common.ReportingData.AnnotationClassificationKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), reader.ReadString(), true);
                        break;
                    case 6:
                        reviewItemDiscrepancy.Content = reader.ReadString();
                        break;
                    case 7:
                        reviewItemDiscrepancy.CreatedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reviewItemDiscrepancy.Discussion.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reviewItemDiscrepancy.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reviewItemDiscrepancy.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        reviewItemDiscrepancy.LanguageCode = reader.ReadString();
                        break;
                    case 12:
                        reviewItemDiscrepancy.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        reviewItemDiscrepancy.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            reviewItemDiscrepancy.PrimaryAnnotatedThing = null;
                        }
                        else
                        {
                            reviewItemDiscrepancy.PrimaryAnnotatedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reviewItemDiscrepancy.RelatedThing.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        reviewItemDiscrepancy.ShortName = reader.ReadString();
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reviewItemDiscrepancy.Solution.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reviewItemDiscrepancy.SourceAnnotation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        reviewItemDiscrepancy.Status = (CDP4Common.ReportingData.AnnotationStatusKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationStatusKind), reader.ReadString(), true);
                        break;
                    case 20:
                        reviewItemDiscrepancy.Title = reader.ReadString();
                        break;
                    case 21:
                        reviewItemDiscrepancy.ThingPreference = reader.ReadString();
                        break;
                    case 22:
                        if (reader.TryReadNil())
                        {
                            reviewItemDiscrepancy.Actor = null;
                        }
                        else
                        {
                            reviewItemDiscrepancy.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return reviewItemDiscrepancy;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
