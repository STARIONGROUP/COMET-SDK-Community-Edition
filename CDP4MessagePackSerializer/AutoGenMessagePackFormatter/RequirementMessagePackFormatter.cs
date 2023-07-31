// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 5     | group                                | Guid                         | 0..1        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | owner                                | Guid                         | 1..1        |  1.0.0  |
 | 10    | parameterValue                       | Guid                         | 0..*        |  1.0.0  |
 | 11    | parametricConstraint                 | Guid                         | 0..*        |  1.0.0  |
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
    /// The purpose of the <see cref="RequirementMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Requirement"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class RequirementMessagePackFormatter : IMessagePackFormatter<Requirement>
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
        /// Serializes an <see cref="Requirement"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="requirement">
        /// The <see cref="Requirement"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Requirement requirement, MessagePackSerializerOptions options)
        {
            if (requirement == null)
            {
                throw new ArgumentNullException(nameof(requirement), "The Requirement may not be null");
            }

            writer.WriteArrayHeader(17);

            writer.Write(requirement.Iid.ToByteArray());
            writer.Write(requirement.RevisionNumber);

            writer.WriteArrayHeader(requirement.Alias.Count);
            foreach (var identifier in requirement.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirement.Category.Count);
            foreach (var identifier in requirement.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirement.Definition.Count);
            foreach (var identifier in requirement.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            if (requirement.Group.HasValue)
            {
                writer.Write(requirement.Group.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(requirement.HyperLink.Count);
            foreach (var identifier in requirement.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirement.IsDeprecated);
            writer.Write(requirement.Name);
            writer.Write(requirement.Owner.ToByteArray());
            writer.WriteArrayHeader(requirement.ParameterValue.Count);
            foreach (var identifier in requirement.ParameterValue.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirement.ParametricConstraint.Count);
            foreach (var orderedItem in requirement.ParametricConstraint.OrderBy(x => x, orderedItemComparer))
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(orderedItem.V.ToString());
            }
            writer.Write(requirement.ShortName);
            writer.WriteArrayHeader(requirement.ExcludedDomain.Count);
            foreach (var identifier in requirement.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(requirement.ExcludedPerson.Count);
            foreach (var identifier in requirement.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(requirement.ModifiedOn);
            writer.Write(requirement.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Requirement"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Requirement"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Requirement"/>.
        /// </returns>
        public Requirement Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var requirement = new Requirement();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        requirement.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        requirement.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirement.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirement.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirement.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        if (reader.TryReadNil())
                        {
                            requirement.Group = null;
                        }
                        else
                        {
                            requirement.Group = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirement.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        requirement.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        requirement.Name = reader.ReadString();
                        break;
                    case 9:
                        requirement.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirement.ParameterValue.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadString();
                            requirement.ParametricConstraint.Add(orderedItem);
                        }
                        break;
                    case 12:
                        requirement.ShortName = reader.ReadString();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirement.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            requirement.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        requirement.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 16:
                        requirement.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return requirement;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
