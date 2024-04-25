// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramObjectMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | bounds                               | Guid                         | 0..1        |  1.1.0  |
 | 3     | depictedThing                        | Guid                         | 0..1        |  1.1.0  |
 | 4     | diagramElement                       | Guid                         | 0..*        |  1.1.0  |
 | 5     | documentation                        | string                       | 1..1        |  1.1.0  |
 | 6     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | localStyle                           | Guid                         | 0..1        |  1.1.0  |
 | 9     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 10    | name                                 | string                       | 1..1        |  1.1.0  |
 | 11    | resolution                           | float                        | 1..1        |  1.1.0  |
 | 12    | sharedStyle                          | Guid                         | 0..1        |  1.1.0  |
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
    /// The purpose of the <see cref="DiagramObjectMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DiagramObject"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class DiagramObjectMessagePackFormatter : IMessagePackFormatter<DiagramObject>
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
        /// Serializes an <see cref="DiagramObject"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="diagramObject">
        /// The <see cref="DiagramObject"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DiagramObject diagramObject, MessagePackSerializerOptions options)
        {
            if (diagramObject == null)
            {
                throw new ArgumentNullException(nameof(diagramObject), "The DiagramObject may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(diagramObject.Iid.ToByteArray());
            writer.Write(diagramObject.RevisionNumber);

            writer.WriteArrayHeader(diagramObject.Bounds.Count);
            foreach (var identifier in diagramObject.Bounds.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (diagramObject.DepictedThing.HasValue)
            {
                writer.Write(diagramObject.DepictedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(diagramObject.DiagramElement.Count);
            foreach (var identifier in diagramObject.DiagramElement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(diagramObject.Documentation);
            writer.WriteArrayHeader(diagramObject.ExcludedDomain.Count);
            foreach (var identifier in diagramObject.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramObject.ExcludedPerson.Count);
            foreach (var identifier in diagramObject.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(diagramObject.LocalStyle.Count);
            foreach (var identifier in diagramObject.LocalStyle.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(diagramObject.ModifiedOn);
            writer.Write(diagramObject.Name);
            writer.Write(diagramObject.Resolution);
            if (diagramObject.SharedStyle.HasValue)
            {
                writer.Write(diagramObject.SharedStyle.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(diagramObject.ThingPreference);
            if (diagramObject.Actor.HasValue)
            {
                writer.Write(diagramObject.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DiagramObject"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DiagramObject"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DiagramObject"/>.
        /// </returns>
        public DiagramObject Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var diagramObject = new DiagramObject();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        diagramObject.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        diagramObject.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramObject.Bounds.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            diagramObject.DepictedThing = null;
                        }
                        else
                        {
                            diagramObject.DepictedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramObject.DiagramElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        diagramObject.Documentation = reader.ReadString();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramObject.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramObject.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            diagramObject.LocalStyle.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        diagramObject.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 10:
                        diagramObject.Name = reader.ReadString();
                        break;
                    case 11:
                        diagramObject.Resolution = reader.ReadSingle();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            diagramObject.SharedStyle = null;
                        }
                        else
                        {
                            diagramObject.SharedStyle = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 13:
                        diagramObject.ThingPreference = reader.ReadString();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            diagramObject.Actor = null;
                        }
                        else
                        {
                            diagramObject.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return diagramObject;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
