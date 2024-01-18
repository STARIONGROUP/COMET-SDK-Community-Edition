// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramPortMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 3     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 4     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 5     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 6     | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 7     | bounds                               | Guid                         | 0..1        |  1.4.0  |
 | 8     | depictedThing                        | Guid                         | 0..1        |  1.4.0  |
 | 9     | diagramElement                       | Guid                         | 0..*        |  1.4.0  |
 | 10    | localStyle                           | Guid                         | 0..1        |  1.4.0  |
 | 11    | name                                 | string                       | 1..1        |  1.4.0  |
 | 12    | sharedStyle                          | Guid                         | 0..1        |  1.4.0  |
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
    /// The purpose of the <see cref="DiagramPortMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DiagramPort"/> type
    /// </summary>
    [CDPVersion("1.4.0")]
    public class DiagramPortMessagePackFormatter : IMessagePackFormatter<DiagramPort>
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
        /// Serializes an <see cref="DiagramPort"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="diagramPort">
        /// The <see cref="DiagramPort"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DiagramPort diagramPort, MessagePackSerializerOptions options)
        {
            if (diagramPort == null)
            {
                throw new ArgumentNullException(nameof(diagramPort), "The DiagramPort may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(diagramPort.Iid.ToByteArray());
            writer.Write(diagramPort.RevisionNumber);

            writer.WriteArrayHeader(diagramPort.ExcludedDomain.Count);
            foreach (var identifier in diagramPort.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramPort.ExcludedPerson.Count);
            foreach (var identifier in diagramPort.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(diagramPort.ModifiedOn);
            writer.Write(diagramPort.ThingPreference);
            if (diagramPort.Actor.HasValue)
            {
                writer.Write(diagramPort.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(diagramPort.Bounds.Count);
            foreach (var identifier in diagramPort.Bounds.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (diagramPort.DepictedThing.HasValue)
            {
                writer.Write(diagramPort.DepictedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(diagramPort.DiagramElement.Count);
            foreach (var identifier in diagramPort.DiagramElement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramPort.LocalStyle.Count);
            foreach (var identifier in diagramPort.LocalStyle.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(diagramPort.Name);
            if (diagramPort.SharedStyle.HasValue)
            {
                writer.Write(diagramPort.SharedStyle.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DiagramPort"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DiagramPort"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DiagramPort"/>.
        /// </returns>
        public DiagramPort Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var diagramPort = new DiagramPort();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        diagramPort.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        diagramPort.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramPort.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramPort.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        diagramPort.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        diagramPort.ThingPreference = reader.ReadString();
                        break;
                    case 6:
                        if (reader.TryReadNil())
                        {
                            diagramPort.Actor = null;
                        }
                        else
                        {
                            diagramPort.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramPort.Bounds.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        if (reader.TryReadNil())
                        {
                            diagramPort.DepictedThing = null;
                        }
                        else
                        {
                            diagramPort.DepictedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramPort.DiagramElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramPort.LocalStyle.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        diagramPort.Name = reader.ReadString();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            diagramPort.SharedStyle = null;
                        }
                        else
                        {
                            diagramPort.SharedStyle = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return diagramPort;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
