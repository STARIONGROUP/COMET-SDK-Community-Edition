// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramEdgeMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | depictedThing                        | Guid                         | 0..1        |  1.1.0  |
 | 4     | diagramElement                       | Guid                         | 0..*        |  1.1.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | localStyle                           | Guid                         | 0..1        |  1.1.0  |
 | 8     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 9     | name                                 | string                       | 1..1        |  1.1.0  |
 | 10    | point                                | Guid                         | 0..*        |  1.1.0  |
 | 11    | sharedStyle                          | Guid                         | 0..1        |  1.1.0  |
 | 12    | source                               | Guid                         | 1..1        |  1.1.0  |
 | 13    | target                               | Guid                         | 1..1        |  1.1.0  |
 | 14    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 15    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="DiagramEdgeMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DiagramEdge"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class DiagramEdgeMessagePackFormatter : IMessagePackFormatter<DiagramEdge>
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
        /// Serializes an <see cref="DiagramEdge"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="diagramEdge">
        /// The <see cref="DiagramEdge"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DiagramEdge diagramEdge, MessagePackSerializerOptions options)
        {
            if (diagramEdge == null)
            {
                throw new ArgumentNullException(nameof(diagramEdge), "The DiagramEdge may not be null");
            }

            writer.WriteArrayHeader(16);

            writer.Write(diagramEdge.Iid.ToByteArray());
            writer.Write(diagramEdge.RevisionNumber);

            writer.WriteArrayHeader(diagramEdge.Bounds.Count);
            foreach (var identifier in diagramEdge.Bounds.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (diagramEdge.DepictedThing.HasValue)
            {
                writer.Write(diagramEdge.DepictedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(diagramEdge.DiagramElement.Count);
            foreach (var identifier in diagramEdge.DiagramElement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramEdge.ExcludedDomain.Count);
            foreach (var identifier in diagramEdge.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramEdge.ExcludedPerson.Count);
            foreach (var identifier in diagramEdge.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramEdge.LocalStyle.Count);
            foreach (var identifier in diagramEdge.LocalStyle.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(diagramEdge.ModifiedOn);
            writer.Write(diagramEdge.Name);
            writer.WriteArrayHeader(diagramEdge.Point.Count);
            foreach (var orderedItem in diagramEdge.Point.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            if (diagramEdge.SharedStyle.HasValue)
            {
                writer.Write(diagramEdge.SharedStyle.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(diagramEdge.Source.ToByteArray());
            writer.Write(diagramEdge.Target.ToByteArray());
            writer.Write(diagramEdge.ThingPreference);
            if (diagramEdge.Actor.HasValue)
            {
                writer.Write(diagramEdge.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DiagramEdge"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DiagramEdge"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DiagramEdge"/>.
        /// </returns>
        public DiagramEdge Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var diagramEdge = new DiagramEdge();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        diagramEdge.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        diagramEdge.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramEdge.Bounds.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            diagramEdge.DepictedThing = null;
                        }
                        else
                        {
                            diagramEdge.DepictedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramEdge.DiagramElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramEdge.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramEdge.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramEdge.LocalStyle.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        diagramEdge.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        diagramEdge.Name = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            diagramEdge.Point.Add(orderedItem);
                        }
                        break;
                    case 11:
                        if (reader.TryReadNil())
                        {
                            diagramEdge.SharedStyle = null;
                        }
                        else
                        {
                            diagramEdge.SharedStyle = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 12:
                        diagramEdge.Source = reader.ReadBytes().ToGuid();
                        break;
                    case 13:
                        diagramEdge.Target = reader.ReadBytes().ToGuid();
                        break;
                    case 14:
                        diagramEdge.ThingPreference = reader.ReadString();
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            diagramEdge.Actor = null;
                        }
                        else
                        {
                            diagramEdge.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return diagramEdge;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
