// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestForDeviationMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 17    | sourceAnnotation                     | Guid                         | 0..*        |  1.1.0  |
 | 18    | status                               | AnnotationStatusKind         | 1..1        |  1.1.0  |
 | 19    | title                                | string                       | 1..1        |  1.1.0  |
 | 20    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 21    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="RequestForDeviationMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="RequestForDeviation"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class RequestForDeviationMessagePackFormatter : IMessagePackFormatter<RequestForDeviation>
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
        /// Serializes an <see cref="RequestForDeviation"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="requestForDeviation">
        /// The <see cref="RequestForDeviation"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, RequestForDeviation requestForDeviation, MessagePackSerializerOptions options)
        {
            if (requestForDeviation == null)
            {
                throw new ArgumentNullException(nameof(requestForDeviation), "The RequestForDeviation may not be null");
            }

            writer.WriteArrayHeader(22);

            writer.Write(requestForDeviation.Iid.ToByteArray());
            writer.Write(requestForDeviation.RevisionNumber);

            writer.WriteArrayHeader(requestForDeviation.ApprovedBy.Count);
            foreach (var identifier in requestForDeviation.ApprovedBy.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requestForDeviation.Author.ToByteArray());
            writer.WriteArrayHeader(requestForDeviation.Category.Count);
            foreach (var identifier in requestForDeviation.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requestForDeviation.Classification.ToString());
            writer.Write(requestForDeviation.Content);
            writer.Write(requestForDeviation.CreatedOn);
            writer.WriteArrayHeader(requestForDeviation.Discussion.Count);
            foreach (var identifier in requestForDeviation.Discussion.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requestForDeviation.ExcludedDomain.Count);
            foreach (var identifier in requestForDeviation.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requestForDeviation.ExcludedPerson.Count);
            foreach (var identifier in requestForDeviation.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requestForDeviation.LanguageCode);
            writer.Write(requestForDeviation.ModifiedOn);
            writer.Write(requestForDeviation.Owner.ToByteArray());
            if (requestForDeviation.PrimaryAnnotatedThing.HasValue)
            {
                writer.Write(requestForDeviation.PrimaryAnnotatedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(requestForDeviation.RelatedThing.Count);
            foreach (var identifier in requestForDeviation.RelatedThing.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requestForDeviation.ShortName);
            writer.WriteArrayHeader(requestForDeviation.SourceAnnotation.Count);
            foreach (var identifier in requestForDeviation.SourceAnnotation.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requestForDeviation.Status.ToString());
            writer.Write(requestForDeviation.Title);
            writer.Write(requestForDeviation.ThingPreference);
            if (requestForDeviation.Actor.HasValue)
            {
                writer.Write(requestForDeviation.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="RequestForDeviation"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="RequestForDeviation"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="RequestForDeviation"/>.
        /// </returns>
        public RequestForDeviation Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var requestForDeviation = new RequestForDeviation();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        requestForDeviation.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        requestForDeviation.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requestForDeviation.ApprovedBy.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        requestForDeviation.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requestForDeviation.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        requestForDeviation.Classification = (CDP4Common.ReportingData.AnnotationClassificationKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), reader.ReadString(), true);
                        break;
                    case 6:
                        requestForDeviation.Content = reader.ReadString();
                        break;
                    case 7:
                        requestForDeviation.CreatedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requestForDeviation.Discussion.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requestForDeviation.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requestForDeviation.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        requestForDeviation.LanguageCode = reader.ReadString();
                        break;
                    case 12:
                        requestForDeviation.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        requestForDeviation.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            requestForDeviation.PrimaryAnnotatedThing = null;
                        }
                        else
                        {
                            requestForDeviation.PrimaryAnnotatedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requestForDeviation.RelatedThing.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        requestForDeviation.ShortName = reader.ReadString();
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requestForDeviation.SourceAnnotation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        requestForDeviation.Status = (CDP4Common.ReportingData.AnnotationStatusKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationStatusKind), reader.ReadString(), true);
                        break;
                    case 19:
                        requestForDeviation.Title = reader.ReadString();
                        break;
                    case 20:
                        requestForDeviation.ThingPreference = reader.ReadString();
                        break;
                    case 21:
                        if (reader.TryReadNil())
                        {
                            requestForDeviation.Actor = null;
                        }
                        else
                        {
                            requestForDeviation.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return requestForDeviation;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
