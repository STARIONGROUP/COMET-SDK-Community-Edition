// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArchitectureElementMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 10    | documentation                        | string                       | 1..1        |  1.4.0  |
 | 11    | localStyle                           | Guid                         | 0..1        |  1.4.0  |
 | 12    | name                                 | string                       | 1..1        |  1.4.0  |
 | 13    | resolution                           | float                        | 1..1        |  1.4.0  |
 | 14    | sharedStyle                          | Guid                         | 0..1        |  1.4.0  |
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
    /// The purpose of the <see cref="ArchitectureElementMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ArchitectureElement"/> type
    /// </summary>
    [CDPVersion("1.4.0")]
    public class ArchitectureElementMessagePackFormatter : IMessagePackFormatter<ArchitectureElement>
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
        /// Serializes an <see cref="ArchitectureElement"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="architectureElement">
        /// The <see cref="ArchitectureElement"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ArchitectureElement architectureElement, MessagePackSerializerOptions options)
        {
            if (architectureElement == null)
            {
                throw new ArgumentNullException(nameof(architectureElement), "The ArchitectureElement may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(architectureElement.Iid.ToByteArray());
            writer.Write(architectureElement.RevisionNumber);

            writer.WriteArrayHeader(architectureElement.ExcludedDomain.Count);
            foreach (var identifier in architectureElement.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(architectureElement.ExcludedPerson.Count);
            foreach (var identifier in architectureElement.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(architectureElement.ModifiedOn);
            writer.Write(architectureElement.ThingPreference);
            if (architectureElement.Actor.HasValue)
            {
                writer.Write(architectureElement.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(architectureElement.Bounds.Count);
            foreach (var identifier in architectureElement.Bounds.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (architectureElement.DepictedThing.HasValue)
            {
                writer.Write(architectureElement.DepictedThing.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(architectureElement.DiagramElement.Count);
            foreach (var identifier in architectureElement.DiagramElement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(architectureElement.Documentation);
            writer.WriteArrayHeader(architectureElement.LocalStyle.Count);
            foreach (var identifier in architectureElement.LocalStyle.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(architectureElement.Name);
            writer.Write(architectureElement.Resolution);
            if (architectureElement.SharedStyle.HasValue)
            {
                writer.Write(architectureElement.SharedStyle.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ArchitectureElement"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ArchitectureElement"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ArchitectureElement"/>.
        /// </returns>
        public ArchitectureElement Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var architectureElement = new ArchitectureElement();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        architectureElement.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        architectureElement.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureElement.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureElement.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        architectureElement.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        architectureElement.ThingPreference = reader.ReadString();
                        break;
                    case 6:
                        if (reader.TryReadNil())
                        {
                            architectureElement.Actor = null;
                        }
                        else
                        {
                            architectureElement.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureElement.Bounds.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        if (reader.TryReadNil())
                        {
                            architectureElement.DepictedThing = null;
                        }
                        else
                        {
                            architectureElement.DepictedThing = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureElement.DiagramElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        architectureElement.Documentation = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            architectureElement.LocalStyle.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        architectureElement.Name = reader.ReadString();
                        break;
                    case 13:
                        architectureElement.Resolution = reader.ReadSingle();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            architectureElement.SharedStyle = null;
                        }
                        else
                        {
                            architectureElement.SharedStyle = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return architectureElement;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
