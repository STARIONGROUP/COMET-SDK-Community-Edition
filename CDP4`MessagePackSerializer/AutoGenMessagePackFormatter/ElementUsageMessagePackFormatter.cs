// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsageMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | elementDefinition                    | Guid                         | 1..1        |  1.0.0  |
 | 6     | excludeOption                        | Guid                         | 0..*        |  1.0.0  |
 | 7     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 8     | interfaceEnd                         | InterfaceEndKind             | 1..1        |  1.0.0  |
 | 9     | name                                 | string                       | 1..1        |  1.0.0  |
 | 10    | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 11    | parameterOverride                    | Guid                         | 0..*        |  1.0.0  |
 | 12    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 13    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 16    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="ElementUsageMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ElementUsage"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ElementUsageMessagePackFormatter : IMessagePackFormatter<ElementUsage>
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
        /// Serializes an <see cref="ElementUsage"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="elementUsage">
        /// The <see cref="ElementUsage"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ElementUsage elementUsage, MessagePackSerializerOptions options)
        {
            if (elementUsage == null)
            {
                throw new ArgumentNullException(nameof(elementUsage), "The ElementUsage may not be null");
            }

            writer.WriteArrayHeader(17);

            writer.Write(elementUsage.Iid.ToByteArray());
            writer.Write(elementUsage.RevisionNumber);

            writer.WriteArrayHeader(elementUsage.Alias.Count);
            foreach (var identifier in elementUsage.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementUsage.Category.Count);
            foreach (var identifier in elementUsage.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementUsage.Definition.Count);
            foreach (var identifier in elementUsage.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(elementUsage.ElementDefinition.ToByteArray());
            writer.WriteArrayHeader(elementUsage.ExcludeOption.Count);
            foreach (var identifier in elementUsage.ExcludeOption.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementUsage.HyperLink.Count);
            foreach (var identifier in elementUsage.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(elementUsage.InterfaceEnd.ToString());
            writer.Write(elementUsage.Name);
            writer.Write(elementUsage.Owner.ToByteArray());
            writer.WriteArrayHeader(elementUsage.ParameterOverride.Count);
            foreach (var identifier in elementUsage.ParameterOverride.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(elementUsage.ShortName);
            writer.WriteArrayHeader(elementUsage.ExcludedDomain.Count);
            foreach (var identifier in elementUsage.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(elementUsage.ExcludedPerson.Count);
            foreach (var identifier in elementUsage.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(elementUsage.ModifiedOn);
            writer.Write(elementUsage.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ElementUsage"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ElementUsage"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ElementUsage"/>.
        /// </returns>
        public ElementUsage Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var elementUsage = new ElementUsage();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        elementUsage.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        elementUsage.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementUsage.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementUsage.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementUsage.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        elementUsage.ElementDefinition = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementUsage.ExcludeOption.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementUsage.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        elementUsage.InterfaceEnd = (CDP4Common.EngineeringModelData.InterfaceEndKind)Enum.Parse(typeof(CDP4Common.EngineeringModelData.InterfaceEndKind), reader.ReadString(), true);
                        break;
                    case 9:
                        elementUsage.Name = reader.ReadString();
                        break;
                    case 10:
                        elementUsage.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementUsage.ParameterOverride.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        elementUsage.ShortName = reader.ReadString();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementUsage.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            elementUsage.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        elementUsage.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 16:
                        elementUsage.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return elementUsage;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
