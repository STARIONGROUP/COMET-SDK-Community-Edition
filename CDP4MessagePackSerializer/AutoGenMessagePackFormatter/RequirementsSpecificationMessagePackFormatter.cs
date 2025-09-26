// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsSpecificationMessagePackFormatter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | group                                | Guid                         | 0..*        |  1.0.0  |
 | 5     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 6     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 9     | requirement                          | Guid                         | 0..*        |  1.0.0  |
 | 10    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 11    | category                             | Guid                         | 0..*        |  1.1.0  |
 | 12    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 13    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 15    | parameterValue                       | Guid                         | 0..*        |  1.1.0  |
 | 16    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 17    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="RequirementsSpecificationMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="RequirementsSpecification"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class RequirementsSpecificationMessagePackFormatter : IMessagePackFormatter<RequirementsSpecification>
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
        /// Serializes an <see cref="RequirementsSpecification"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="requirementsSpecification">
        /// The <see cref="RequirementsSpecification"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, RequirementsSpecification requirementsSpecification, MessagePackSerializerOptions options)
        {
            if (requirementsSpecification == null)
            {
                throw new ArgumentNullException(nameof(requirementsSpecification), "The RequirementsSpecification may not be null");
            }

            writer.WriteArrayHeader(18);

            writer.Write(requirementsSpecification.Iid.ToByteArray());
            writer.Write(requirementsSpecification.RevisionNumber);

            writer.WriteArrayHeader(requirementsSpecification.Alias.Count);
            foreach (var identifier in requirementsSpecification.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsSpecification.Definition.Count);
            foreach (var identifier in requirementsSpecification.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsSpecification.Group.Count);
            foreach (var identifier in requirementsSpecification.Group.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsSpecification.HyperLink.Count);
            foreach (var identifier in requirementsSpecification.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirementsSpecification.IsDeprecated);
            writer.Write(requirementsSpecification.Name);
            writer.Write(requirementsSpecification.Owner.ToByteArray());
            writer.WriteArrayHeader(requirementsSpecification.Requirement.Count);
            foreach (var identifier in requirementsSpecification.Requirement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirementsSpecification.ShortName);
            writer.WriteArrayHeader(requirementsSpecification.Category.Count);
            foreach (var identifier in requirementsSpecification.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsSpecification.ExcludedDomain.Count);
            foreach (var identifier in requirementsSpecification.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirementsSpecification.ExcludedPerson.Count);
            foreach (var identifier in requirementsSpecification.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirementsSpecification.ModifiedOn);
            writer.WriteArrayHeader(requirementsSpecification.ParameterValue.Count);
            foreach (var identifier in requirementsSpecification.ParameterValue.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirementsSpecification.ThingPreference);
            if (requirementsSpecification.Actor.HasValue)
            {
                writer.Write(requirementsSpecification.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="RequirementsSpecification"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="RequirementsSpecification"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="RequirementsSpecification"/>.
        /// </returns>
        public RequirementsSpecification Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var requirementsSpecification = new RequirementsSpecification();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        requirementsSpecification.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        requirementsSpecification.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.Group.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        requirementsSpecification.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 7:
                        requirementsSpecification.Name = reader.ReadString();
                        break;
                    case 8:
                        requirementsSpecification.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.Requirement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        requirementsSpecification.ShortName = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        requirementsSpecification.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirementsSpecification.ParameterValue.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        requirementsSpecification.ThingPreference = reader.ReadString();
                        break;
                    case 17:
                        if (reader.TryReadNil())
                        {
                            requirementsSpecification.Actor = null;
                        }
                        else
                        {
                            requirementsSpecification.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return requirementsSpecification;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
