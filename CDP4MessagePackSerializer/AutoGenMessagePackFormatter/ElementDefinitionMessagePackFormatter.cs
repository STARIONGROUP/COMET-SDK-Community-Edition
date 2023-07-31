// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | category                             | Guid                         | 0..*        |  1.0.0  |
 | 4     | containedElement                     | Guid                         | 0..*        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 9     | parameter                            | Guid                         | 0..*        |  1.0.0  |
 | 10    | parameterGroup                       | Guid                         | 0..*        |  1.0.0  |
 | 11    | referencedElement                    | Guid                         | 0..*        |  1.0.0  |
 | 12    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 13    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 16    | organizationalParticipant            | Guid                         | 0..*        |  1.2.0  |
 | 17    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="ElementDefinitionMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ElementDefinition"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ElementDefinitionMessagePackFormatter : IMessagePackFormatter<ElementDefinition>
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
        /// Serializes an <see cref="ElementDefinition"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="elementDefinition">
        /// The <see cref="ElementDefinition"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ElementDefinition elementDefinition, MessagePackSerializerOptions options)
        {
            if (elementDefinition == null)
            {
                throw new ArgumentNullException(nameof(elementDefinition), "The ElementDefinition may not be null");
            }

            writer.WriteArrayHeader(18);

            writer.Write(elementDefinition.Iid.ToByteArray());
            writer.Write(elementDefinition.RevisionNumber);

            writer.WriteArrayHeader(elementDefinition.Alias.Count);
            foreach (var identifier in elementDefinition.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementDefinition.Category.Count);
            foreach (var identifier in elementDefinition.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementDefinition.ContainedElement.Count);
            foreach (var identifier in elementDefinition.ContainedElement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementDefinition.Definition.Count);
            foreach (var identifier in elementDefinition.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementDefinition.HyperLink.Count);
            foreach (var identifier in elementDefinition.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(elementDefinition.Name);
            writer.Write(elementDefinition.Owner.ToByteArray());
            writer.WriteArrayHeader(elementDefinition.Parameter.Count);
            foreach (var identifier in elementDefinition.Parameter.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementDefinition.ParameterGroup.Count);
            foreach (var identifier in elementDefinition.ParameterGroup.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementDefinition.ReferencedElement.Count);
            foreach (var identifier in elementDefinition.ReferencedElement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(elementDefinition.ShortName);
            writer.WriteArrayHeader(elementDefinition.ExcludedDomain.Count);
            foreach (var identifier in elementDefinition.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementDefinition.ExcludedPerson.Count);
            foreach (var identifier in elementDefinition.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(elementDefinition.ModifiedOn);
            writer.WriteArrayHeader(elementDefinition.OrganizationalParticipant.Count);
            foreach (var identifier in elementDefinition.OrganizationalParticipant.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(elementDefinition.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ElementDefinition"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ElementDefinition"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ElementDefinition"/>.
        /// </returns>
        public ElementDefinition Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var elementDefinition = new ElementDefinition();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        elementDefinition.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        elementDefinition.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.ContainedElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        elementDefinition.Name = reader.ReadString();
                        break;
                    case 8:
                        elementDefinition.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.Parameter.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.ParameterGroup.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.ReferencedElement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        elementDefinition.ShortName = reader.ReadString();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        elementDefinition.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementDefinition.OrganizationalParticipant.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        elementDefinition.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return elementDefinition;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
