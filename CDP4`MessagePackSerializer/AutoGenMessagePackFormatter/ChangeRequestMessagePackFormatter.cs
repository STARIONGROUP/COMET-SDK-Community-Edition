// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeRequestMessagePackFormatter.cs" company="RHEA System S.A.">
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
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common;
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// The purpose of the <see cref="ChangeRequestMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ChangeRequest"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class ChangeRequestMessagePackFormatter : IMessagePackFormatter<ChangeRequest>
    {
        /// <summary>
        /// Serializes an <see cref="ChangeRequest"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="changeRequest">
        /// The <see cref="ChangeRequest"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ChangeRequest changeRequest, MessagePackSerializerOptions options)
        {
            if (changeRequest == null)
            {
                throw new ArgumentNullException(nameof(changeRequest), "The ChangeRequest may not be null");
            }

            writer.WriteArrayHeader(21);

            writer.Write(changeRequest.Iid.ToByteArray());
            writer.Write(changeRequest.RevisionNumber);

            writer.WriteArrayHeader(changeRequest.ApprovedBy.Count);
            foreach (var identifier in changeRequest.ApprovedBy)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeRequest.Author.ToByteArray());
            writer.WriteArrayHeader(changeRequest.Category.Count);
            foreach (var identifier in changeRequest.Category)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeRequest.Classification.ToString());
            writer.Write(changeRequest.Content);
            writer.Write(changeRequest.CreatedOn);
            writer.WriteArrayHeader(changeRequest.Discussion.Count);
            foreach (var identifier in changeRequest.Discussion)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(changeRequest.ExcludedDomain.Count);
            foreach (var identifier in changeRequest.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(changeRequest.ExcludedPerson.Count);
            foreach (var identifier in changeRequest.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeRequest.LanguageCode);
            writer.Write(changeRequest.ModifiedOn);
            writer.Write(changeRequest.Owner.ToByteArray());
            if (changeRequest.PrimaryAnnotatedThing.HasValue)
            {
                writer.Write(changeRequest.PrimaryAnnotatedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(changeRequest.RelatedThing.Count);
            foreach (var identifier in changeRequest.RelatedThing)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeRequest.ShortName);
            writer.WriteArrayHeader(changeRequest.SourceAnnotation.Count);
            foreach (var identifier in changeRequest.SourceAnnotation)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(changeRequest.Status.ToString());
            writer.Write(changeRequest.Title);
            writer.Write(changeRequest.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ChangeRequest"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ChangeRequest"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ChangeRequest"/>.
        /// </returns>
        public ChangeRequest Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var changeRequest = new ChangeRequest();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        changeRequest.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        changeRequest.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeRequest.ApprovedBy.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        changeRequest.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeRequest.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        changeRequest.Classification = (CDP4Common.ReportingData.AnnotationClassificationKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationClassificationKind), reader.ReadString(), true);
                        break;
                    case 6:
                        changeRequest.Content = reader.ReadString();
                        break;
                    case 7:
                        changeRequest.CreatedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeRequest.Discussion.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeRequest.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeRequest.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        changeRequest.LanguageCode = reader.ReadString();
                        break;
                    case 12:
                        changeRequest.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        changeRequest.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            changeRequest.PrimaryAnnotatedThing = null;
                        }
                        else
                        {
                            changeRequest.PrimaryAnnotatedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeRequest.RelatedThing.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        changeRequest.ShortName = reader.ReadString();
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            changeRequest.SourceAnnotation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        changeRequest.Status = (CDP4Common.ReportingData.AnnotationStatusKind)Enum.Parse(typeof(CDP4Common.ReportingData.AnnotationStatusKind), reader.ReadString(), true);
                        break;
                    case 19:
                        changeRequest.Title = reader.ReadString();
                        break;
                    case 20:
                        changeRequest.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return changeRequest;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
