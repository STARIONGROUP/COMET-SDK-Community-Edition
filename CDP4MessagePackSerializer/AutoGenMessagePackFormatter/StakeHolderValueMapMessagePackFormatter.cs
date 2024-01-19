// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | alias                                | Guid                         | 0..*        |  1.1.0  |
 | 3     | category                             | Guid                         | 0..*        |  1.1.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.1.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | goal                                 | Guid                         | 0..*        |  1.1.0  |
 | 8     | hyperLink                            | Guid                         | 0..*        |  1.1.0  |
 | 9     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 10    | name                                 | string                       | 1..1        |  1.1.0  |
 | 11    | requirement                          | Guid                         | 0..*        |  1.1.0  |
 | 12    | settings                             | Guid                         | 1..1        |  1.1.0  |
 | 13    | shortName                            | string                       | 1..1        |  1.1.0  |
 | 14    | stakeholderValue                     | Guid                         | 0..*        |  1.1.0  |
 | 15    | valueGroup                           | Guid                         | 0..*        |  1.1.0  |
 | 16    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 17    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 18    | attachment                           | Guid                         | 0..*        |  1.4.0  |
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
    /// The purpose of the <see cref="StakeHolderValueMapMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="StakeHolderValueMap"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class StakeHolderValueMapMessagePackFormatter : IMessagePackFormatter<StakeHolderValueMap>
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
        /// Serializes an <see cref="StakeHolderValueMap"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="stakeHolderValueMap">
        /// The <see cref="StakeHolderValueMap"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, StakeHolderValueMap stakeHolderValueMap, MessagePackSerializerOptions options)
        {
            if (stakeHolderValueMap == null)
            {
                throw new ArgumentNullException(nameof(stakeHolderValueMap), "The StakeHolderValueMap may not be null");
            }

            writer.WriteArrayHeader(19);

            writer.Write(stakeHolderValueMap.Iid.ToByteArray());
            writer.Write(stakeHolderValueMap.RevisionNumber);

            writer.WriteArrayHeader(stakeHolderValueMap.Alias.Count);
            foreach (var identifier in stakeHolderValueMap.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeHolderValueMap.Category.Count);
            foreach (var identifier in stakeHolderValueMap.Category.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeHolderValueMap.Definition.Count);
            foreach (var identifier in stakeHolderValueMap.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeHolderValueMap.ExcludedDomain.Count);
            foreach (var identifier in stakeHolderValueMap.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeHolderValueMap.ExcludedPerson.Count);
            foreach (var identifier in stakeHolderValueMap.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeHolderValueMap.Goal.Count);
            foreach (var identifier in stakeHolderValueMap.Goal.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeHolderValueMap.HyperLink.Count);
            foreach (var identifier in stakeHolderValueMap.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(stakeHolderValueMap.ModifiedOn);
            writer.Write(stakeHolderValueMap.Name);
            writer.WriteArrayHeader(stakeHolderValueMap.Requirement.Count);
            foreach (var identifier in stakeHolderValueMap.Requirement.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeHolderValueMap.Settings.Count);
            foreach (var identifier in stakeHolderValueMap.Settings.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(stakeHolderValueMap.ShortName);
            writer.WriteArrayHeader(stakeHolderValueMap.StakeholderValue.Count);
            foreach (var identifier in stakeHolderValueMap.StakeholderValue.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(stakeHolderValueMap.ValueGroup.Count);
            foreach (var identifier in stakeHolderValueMap.ValueGroup.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(stakeHolderValueMap.ThingPreference);
            if (stakeHolderValueMap.Actor.HasValue)
            {
                writer.Write(stakeHolderValueMap.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(stakeHolderValueMap.Attachment.Count);
            foreach (var identifier in stakeHolderValueMap.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="StakeHolderValueMap"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="StakeHolderValueMap"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="StakeHolderValueMap"/>.
        /// </returns>
        public StakeHolderValueMap Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var stakeHolderValueMap = new StakeHolderValueMap();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        stakeHolderValueMap.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        stakeHolderValueMap.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.Goal.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        stakeHolderValueMap.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 10:
                        stakeHolderValueMap.Name = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.Requirement.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.Settings.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        stakeHolderValueMap.ShortName = reader.ReadString();
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.StakeholderValue.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.ValueGroup.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        stakeHolderValueMap.ThingPreference = reader.ReadString();
                        break;
                    case 17:
                        if (reader.TryReadNil())
                        {
                            stakeHolderValueMap.Actor = null;
                        }
                        else
                        {
                            stakeHolderValueMap.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            stakeHolderValueMap.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return stakeHolderValueMap;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
