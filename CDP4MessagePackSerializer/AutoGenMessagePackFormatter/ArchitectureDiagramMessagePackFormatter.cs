// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArchitectureDiagramMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 8     | createdOn                            | DateTime                     | 1..1        |  1.4.0  |
 | 9     | description                          | string                       | 1..1        |  1.4.0  |
 | 10    | diagramElement                       | Guid                         | 0..*        |  1.4.0  |
 | 11    | isHidden                             | bool                         | 1..1        |  1.4.0  |
 | 12    | lockedBy                             | Guid                         | 0..1        |  1.4.0  |
 | 13    | name                                 | string                       | 1..1        |  1.4.0  |
 | 14    | owner                                | Guid                         | 1..1        |  1.4.0  |
 | 15    | topArchitectureElement               | Guid                         | 0..1        |  1.4.0  |
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
    /// The purpose of the <see cref="ArchitectureDiagramMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ArchitectureDiagram"/> type
    /// </summary>
    [CDPVersion("1.4.0")]
    public class ArchitectureDiagramMessagePackFormatter : IMessagePackFormatter<ArchitectureDiagram>
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
        /// Serializes an <see cref="ArchitectureDiagram"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="architectureDiagram">
        /// The <see cref="ArchitectureDiagram"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ArchitectureDiagram architectureDiagram, MessagePackSerializerOptions options)
        {
            if (architectureDiagram == null)
            {
                throw new ArgumentNullException(nameof(architectureDiagram), "The ArchitectureDiagram may not be null");
            }

            writer.WriteArrayHeader(16);

            writer.Write(architectureDiagram.Iid.ToByteArray());
            writer.Write(architectureDiagram.RevisionNumber);

            writer.WriteArrayHeader(architectureDiagram.ExcludedDomain.Count);
            foreach (var identifier in architectureDiagram.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(architectureDiagram.ExcludedPerson.Count);
            foreach (var identifier in architectureDiagram.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(architectureDiagram.ModifiedOn);
            writer.Write(architectureDiagram.ThingPreference);
            if (architectureDiagram.Actor.HasValue)
            {
                writer.Write(architectureDiagram.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(architectureDiagram.Bounds.Count);
            foreach (var identifier in architectureDiagram.Bounds.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(architectureDiagram.CreatedOn);
            writer.Write(architectureDiagram.Description);
            writer.WriteArrayHeader(architectureDiagram.DiagramElement.Count);
            foreach (var identifier in architectureDiagram.DiagramElement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(architectureDiagram.IsHidden);
            if (architectureDiagram.LockedBy.HasValue)
            {
                writer.Write(architectureDiagram.LockedBy.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(architectureDiagram.Name);
            writer.Write(architectureDiagram.Owner.ToByteArray());
            if (architectureDiagram.TopArchitectureElement.HasValue)
            {
                writer.Write(architectureDiagram.TopArchitectureElement.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ArchitectureDiagram"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ArchitectureDiagram"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ArchitectureDiagram"/>.
        /// </returns>
        public ArchitectureDiagram Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var architectureDiagram = new ArchitectureDiagram();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        architectureDiagram.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        architectureDiagram.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureDiagram.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureDiagram.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        architectureDiagram.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        architectureDiagram.ThingPreference = reader.ReadString();
                        break;
                    case 6:
                        if (reader.TryReadNil())
                        {
                            architectureDiagram.Actor = null;
                        }
                        else
                        {
                            architectureDiagram.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureDiagram.Bounds.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        architectureDiagram.CreatedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        architectureDiagram.Description = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureDiagram.DiagramElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        architectureDiagram.IsHidden = reader.ReadBoolean();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            architectureDiagram.LockedBy = null;
                        }
                        else
                        {
                            architectureDiagram.LockedBy = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 13:
                        architectureDiagram.Name = reader.ReadString();
                        break;
                    case 14:
                        architectureDiagram.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            architectureDiagram.TopArchitectureElement = null;
                        }
                        else
                        {
                            architectureDiagram.TopArchitectureElement = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return architectureDiagram;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
