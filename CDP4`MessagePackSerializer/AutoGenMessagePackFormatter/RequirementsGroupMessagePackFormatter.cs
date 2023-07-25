// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsGroupMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | group                                | Guid                         | 0..*        |  1.0.0  |
 | 5     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 6     | name                                 | string                       | 1..1        |  1.0.0  |
 | 7     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 8     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 9     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | parameterValue                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="RequirementsGroupMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="RequirementsGroup"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class RequirementsGroupMessagePackFormatter : IMessagePackFormatter<RequirementsGroup>
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
        /// Serializes an <see cref="RequirementsGroup"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="requirementsGroup">
        /// The <see cref="RequirementsGroup"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, RequirementsGroup requirementsGroup, MessagePackSerializerOptions options)
        {
            if (requirementsGroup == null)
            {
                throw new ArgumentNullException(nameof(requirementsGroup), "The RequirementsGroup may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(requirementsGroup.Iid.ToByteArray());
            writer.Write(requirementsGroup.RevisionNumber);

            writer.WriteArrayHeader(requirementsGroup.Alias.Count);
            foreach (var identifier in requirementsGroup.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsGroup.Definition.Count);
            foreach (var identifier in requirementsGroup.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsGroup.Group.Count);
            foreach (var identifier in requirementsGroup.Group.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsGroup.HyperLink.Count);
            foreach (var identifier in requirementsGroup.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirementsGroup.Name);
            writer.Write(requirementsGroup.Owner.ToByteArray());
            writer.Write(requirementsGroup.ShortName);
            writer.WriteArrayHeader(requirementsGroup.Category.Count);
            foreach (var identifier in requirementsGroup.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsGroup.ExcludedDomain.Count);
            foreach (var identifier in requirementsGroup.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsGroup.ExcludedPerson.Count);
            foreach (var identifier in requirementsGroup.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirementsGroup.ModifiedOn);
            writer.WriteArrayHeader(requirementsGroup.ParameterValue.Count);
            foreach (var identifier in requirementsGroup.ParameterValue.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirementsGroup.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="RequirementsGroup"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="RequirementsGroup"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="RequirementsGroup"/>.
        /// </returns>
        public RequirementsGroup Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var requirementsGroup = new RequirementsGroup();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        requirementsGroup.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        requirementsGroup.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsGroup.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsGroup.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsGroup.Group.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsGroup.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        requirementsGroup.Name = reader.ReadString();
                        break;
                    case 7:
                        requirementsGroup.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 8:
                        requirementsGroup.ShortName = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsGroup.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsGroup.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsGroup.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        requirementsGroup.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsGroup.ParameterValue.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        requirementsGroup.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return requirementsGroup;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
