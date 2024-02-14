// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramCanvasMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | bounds                               | Guid                         | 0..1        |  1.1.0  |
 | 3     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 4     | diagramElement                       | Guid                         | 0..*        |  1.1.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 8     | name                                 | string                       | 1..1        |  1.1.0  |
 | 9     | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 10    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 11    | description                          | string                       | 1..1        |  1.4.0  |
 | 12    | isHidden                             | bool                         | 1..1        |  1.4.0  |
 | 13    | lockedBy                             | Guid                         | 0..1        |  1.4.0  |
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
    /// The purpose of the <see cref="DiagramCanvasMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DiagramCanvas"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class DiagramCanvasMessagePackFormatter : IMessagePackFormatter<DiagramCanvas>
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
        /// Serializes an <see cref="DiagramCanvas"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="diagramCanvas">
        /// The <see cref="DiagramCanvas"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DiagramCanvas diagramCanvas, MessagePackSerializerOptions options)
        {
            if (diagramCanvas == null)
            {
                throw new ArgumentNullException(nameof(diagramCanvas), "The DiagramCanvas may not be null");
            }

            writer.WriteArrayHeader(14);

            writer.Write(diagramCanvas.Iid.ToByteArray());
            writer.Write(diagramCanvas.RevisionNumber);

            writer.WriteArrayHeader(diagramCanvas.Bounds.Count);
            foreach (var identifier in diagramCanvas.Bounds.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(diagramCanvas.CreatedOn);
            writer.WriteArrayHeader(diagramCanvas.DiagramElement.Count);
            foreach (var identifier in diagramCanvas.DiagramElement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramCanvas.ExcludedDomain.Count);
            foreach (var identifier in diagramCanvas.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramCanvas.ExcludedPerson.Count);
            foreach (var identifier in diagramCanvas.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(diagramCanvas.ModifiedOn);
            writer.Write(diagramCanvas.Name);
            writer.Write(diagramCanvas.ThingPreference);
            if (diagramCanvas.Actor.HasValue)
            {
                writer.Write(diagramCanvas.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(diagramCanvas.Description);
            writer.Write(diagramCanvas.IsHidden);
            if (diagramCanvas.LockedBy.HasValue)
            {
                writer.Write(diagramCanvas.LockedBy.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DiagramCanvas"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DiagramCanvas"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DiagramCanvas"/>.
        /// </returns>
        public DiagramCanvas Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var diagramCanvas = new DiagramCanvas();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        diagramCanvas.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        diagramCanvas.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramCanvas.Bounds.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        diagramCanvas.CreatedOn = reader.ReadDateTime();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramCanvas.DiagramElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramCanvas.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramCanvas.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        diagramCanvas.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        diagramCanvas.Name = reader.ReadString();
                        break;
                    case 9:
                        diagramCanvas.ThingPreference = reader.ReadString();
                        break;
                    case 10:
                        if (reader.TryReadNil())
                        {
                            diagramCanvas.Actor = null;
                        }
                        else
                        {
                            diagramCanvas.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 11:
                        diagramCanvas.Description = reader.ReadString();
                        break;
                    case 12:
                        diagramCanvas.IsHidden = reader.ReadBoolean();
                        break;
                    case 13:
                        if (reader.TryReadNil())
                        {
                            diagramCanvas.LockedBy = null;
                        }
                        else
                        {
                            diagramCanvas.LockedBy = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return diagramCanvas;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
