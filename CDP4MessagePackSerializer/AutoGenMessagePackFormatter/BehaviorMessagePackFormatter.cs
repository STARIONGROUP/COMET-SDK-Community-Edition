// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BehaviorMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 7     | alias                                | Guid                         | 0..*        |  1.4.0  |
 | 8     | attachment                           | Guid                         | 0..*        |  1.4.0  |
 | 9     | behavioralModelKind                  | BehavioralModelKind          | 1..1        |  1.4.0  |
 | 10    | behavioralParameter                  | Guid                         | 0..*        |  1.4.0  |
 | 11    | definition                           | Guid                         | 0..*        |  1.4.0  |
 | 12    | hyperLink                            | Guid                         | 0..*        |  1.4.0  |
 | 13    | name                                 | string                       | 1..1        |  1.4.0  |
 | 14    | script                               | string                       | 0..1        |  1.4.0  |
 | 15    | shortName                            | string                       | 1..1        |  1.4.0  |
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
    /// The purpose of the <see cref="BehaviorMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Behavior"/> type
    /// </summary>
    [CDPVersion("1.4.0")]
    public class BehaviorMessagePackFormatter : IMessagePackFormatter<Behavior>
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
        /// Serializes an <see cref="Behavior"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="behavior">
        /// The <see cref="Behavior"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Behavior behavior, MessagePackSerializerOptions options)
        {
            if (behavior == null)
            {
                throw new ArgumentNullException(nameof(behavior), "The Behavior may not be null");
            }

            writer.WriteArrayHeader(16);

            writer.Write(behavior.Iid.ToByteArray());
            writer.Write(behavior.RevisionNumber);

            writer.WriteArrayHeader(behavior.ExcludedDomain.Count);
            foreach (var identifier in behavior.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(behavior.ExcludedPerson.Count);
            foreach (var identifier in behavior.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(behavior.ModifiedOn);
            writer.Write(behavior.ThingPreference);
            if (behavior.Actor.HasValue)
            {
                writer.Write(behavior.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(behavior.Alias.Count);
            foreach (var identifier in behavior.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(behavior.Attachment.Count);
            foreach (var identifier in behavior.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(behavior.BehavioralModelKind.ToString());
            writer.WriteArrayHeader(behavior.BehavioralParameter.Count);
            foreach (var identifier in behavior.BehavioralParameter.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(behavior.Definition.Count);
            foreach (var identifier in behavior.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(behavior.HyperLink.Count);
            foreach (var identifier in behavior.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(behavior.Name);
            writer.Write(behavior.Script);
            writer.Write(behavior.ShortName);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Behavior"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Behavior"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Behavior"/>.
        /// </returns>
        public Behavior Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var behavior = new Behavior();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        behavior.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        behavior.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavior.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavior.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        behavior.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        behavior.ThingPreference = reader.ReadString();
                        break;
                    case 6:
                        if (reader.TryReadNil())
                        {
                            behavior.Actor = null;
                        }
                        else
                        {
                            behavior.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavior.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavior.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        behavior.BehavioralModelKind = (CDP4Common.EngineeringModelData.BehavioralModelKind)Enum.Parse(typeof(CDP4Common.EngineeringModelData.BehavioralModelKind), reader.ReadString(), true);
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavior.BehavioralParameter.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavior.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            behavior.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        behavior.Name = reader.ReadString();
                        break;
                    case 14:
                        behavior.Script = reader.ReadString();
                        break;
                    case 15:
                        behavior.ShortName = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return behavior;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
