// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeholderValueMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 2     | alias                                | Guid                         | 0..*        |  1.1.0  |
 | 3     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.1.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | hyperLink                            | Guid                         | 0..*        |  1.1.0  |
 | 8     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 9     | name                                 | string                       | 1..1        |  1.1.0  |
 | 10    | shortName                            | string                       | 1..1        |  1.1.0  |
 | 11    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 12    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="StakeholderValueMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="StakeholderValue"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class StakeholderValueMessagePackFormatter : IMessagePackFormatter<StakeholderValue>
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
        /// Serializes an <see cref="StakeholderValue"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="stakeholderValue">
        /// The <see cref="StakeholderValue"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, StakeholderValue stakeholderValue, MessagePackSerializerOptions options)
        {
            if (stakeholderValue == null)
            {
                throw new ArgumentNullException(nameof(stakeholderValue), "The StakeholderValue may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(stakeholderValue.Iid.ToByteArray());
            writer.Write(stakeholderValue.RevisionNumber);

            writer.WriteArrayHeader(stakeholderValue.Alias.Count);
            foreach (var identifier in stakeholderValue.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeholderValue.Category.Count);
            foreach (var identifier in stakeholderValue.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeholderValue.Definition.Count);
            foreach (var identifier in stakeholderValue.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeholderValue.ExcludedDomain.Count);
            foreach (var identifier in stakeholderValue.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeholderValue.ExcludedPerson.Count);
            foreach (var identifier in stakeholderValue.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeholderValue.HyperLink.Count);
            foreach (var identifier in stakeholderValue.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(stakeholderValue.ModifiedOn);
            writer.Write(stakeholderValue.Name);
            writer.Write(stakeholderValue.ShortName);
            writer.Write(stakeholderValue.ThingPreference);
            if (stakeholderValue.Actor.HasValue)
            {
                writer.Write(stakeholderValue.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="StakeholderValue"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="StakeholderValue"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="StakeholderValue"/>.
        /// </returns>
        public StakeholderValue Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var stakeholderValue = new StakeholderValue();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        stakeholderValue.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        stakeholderValue.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeholderValue.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeholderValue.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeholderValue.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeholderValue.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeholderValue.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeholderValue.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        stakeholderValue.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        stakeholderValue.Name = reader.ReadString();
                        break;
                    case 10:
                        stakeholderValue.ShortName = reader.ReadString();
                        break;
                    case 11:
                        stakeholderValue.ThingPreference = reader.ReadString();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            stakeholderValue.Actor = null;
                        }
                        else
                        {
                            stakeholderValue.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return stakeholderValue;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
