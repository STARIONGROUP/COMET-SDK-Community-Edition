// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelMessagePackFormatter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
 | 2     | commonFileStore                      | Guid                         | 0..1        |  1.0.0  |
 | 3     | engineeringModelSetup                | Guid                         | 1..1        |  1.0.0  |
 | 4     | iteration                            | Guid                         | 1..*        |  1.0.0  |
 | 5     | lastModifiedOn                       | DateTime                     | 1..1        |  1.0.0  |
 | 6     | logEntry                             | Guid                         | 0..*        |  1.0.0  |
 | 7     | book                                 | Guid                         | 0..*        |  1.1.0  |
 | 8     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 9     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | genericNote                          | Guid                         | 0..*        |  1.1.0  |
 | 11    | modellingAnnotation                  | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 14    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="EngineeringModelMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="EngineeringModel"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class EngineeringModelMessagePackFormatter : IMessagePackFormatter<EngineeringModel>
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
        /// Serializes an <see cref="EngineeringModel"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="engineeringModel">
        /// The <see cref="EngineeringModel"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, EngineeringModel engineeringModel, MessagePackSerializerOptions options)
        {
            if (engineeringModel == null)
            {
                throw new ArgumentNullException(nameof(engineeringModel), "The EngineeringModel may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(engineeringModel.Iid.ToByteArray());
            writer.Write(engineeringModel.RevisionNumber);

            writer.WriteArrayHeader(engineeringModel.CommonFileStore.Count);
            foreach (var identifier in engineeringModel.CommonFileStore.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModel.EngineeringModelSetup.ToByteArray());
            writer.WriteArrayHeader(engineeringModel.Iteration.Count);
            foreach (var identifier in engineeringModel.Iteration.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModel.LastModifiedOn);
            writer.WriteArrayHeader(engineeringModel.LogEntry.Count);
            foreach (var identifier in engineeringModel.LogEntry.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModel.Book.Count);
            foreach (var orderedItem in engineeringModel.Book.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.WriteArrayHeader(engineeringModel.ExcludedDomain.Count);
            foreach (var identifier in engineeringModel.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModel.ExcludedPerson.Count);
            foreach (var identifier in engineeringModel.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModel.GenericNote.Count);
            foreach (var identifier in engineeringModel.GenericNote.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModel.ModellingAnnotation.Count);
            foreach (var identifier in engineeringModel.ModellingAnnotation.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModel.ModifiedOn);
            writer.Write(engineeringModel.ThingPreference);
            if (engineeringModel.Actor.HasValue)
            {
                writer.Write(engineeringModel.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="EngineeringModel"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="EngineeringModel"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="EngineeringModel"/>.
        /// </returns>
        public EngineeringModel Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var engineeringModel = new EngineeringModel();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        engineeringModel.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        engineeringModel.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModel.CommonFileStore.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        engineeringModel.EngineeringModelSetup = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModel.Iteration.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        engineeringModel.LastModifiedOn = reader.ReadDateTime();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModel.LogEntry.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            engineeringModel.Book.Add(orderedItem);
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModel.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModel.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModel.GenericNote.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModel.ModellingAnnotation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        engineeringModel.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        engineeringModel.ThingPreference = reader.ReadString();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            engineeringModel.Actor = null;
                        }
                        else
                        {
                            engineeringModel.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return engineeringModel;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
