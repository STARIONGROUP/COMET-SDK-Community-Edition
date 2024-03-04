// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipRuleMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 3     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | forwardRelationshipName              | string                       | 1..1        |  1.0.0  |
 | 5     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 6     | inverseRelationshipName              | string                       | 1..1        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | relationshipCategory                 | Guid                         | 1..1        |  1.0.0  |
 | 10    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 11    | sourceCategory                       | Guid                         | 1..1        |  1.0.0  |
 | 12    | targetCategory                       | Guid                         | 1..1        |  1.0.0  |
 | 13    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 15    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
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
    /// The purpose of the <see cref="BinaryRelationshipRuleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="BinaryRelationshipRule"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class BinaryRelationshipRuleMessagePackFormatter : IMessagePackFormatter<BinaryRelationshipRule>
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
        /// Serializes an <see cref="BinaryRelationshipRule"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="binaryRelationshipRule">
        /// The <see cref="BinaryRelationshipRule"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, BinaryRelationshipRule binaryRelationshipRule, MessagePackSerializerOptions options)
        {
            if (binaryRelationshipRule == null)
            {
                throw new ArgumentNullException(nameof(binaryRelationshipRule), "The BinaryRelationshipRule may not be null");
            }

            writer.WriteArrayHeader(19);

            writer.Write(binaryRelationshipRule.Iid.ToByteArray());
            writer.Write(binaryRelationshipRule.RevisionNumber);

            writer.WriteArrayHeader(binaryRelationshipRule.Alias.Count);
            foreach (var identifier in binaryRelationshipRule.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(binaryRelationshipRule.Definition.Count);
            foreach (var identifier in binaryRelationshipRule.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(binaryRelationshipRule.ForwardRelationshipName);
            writer.WriteArrayHeader(binaryRelationshipRule.HyperLink.Count);
            foreach (var identifier in binaryRelationshipRule.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(binaryRelationshipRule.InverseRelationshipName);
            writer.Write(binaryRelationshipRule.IsDeprecated);
            writer.Write(binaryRelationshipRule.Name);
            writer.Write(binaryRelationshipRule.RelationshipCategory.ToByteArray());
            writer.Write(binaryRelationshipRule.ShortName);
            writer.Write(binaryRelationshipRule.SourceCategory.ToByteArray());
            writer.Write(binaryRelationshipRule.TargetCategory.ToByteArray());
            writer.WriteArrayHeader(binaryRelationshipRule.ExcludedDomain.Count);
            foreach (var identifier in binaryRelationshipRule.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(binaryRelationshipRule.ExcludedPerson.Count);
            foreach (var identifier in binaryRelationshipRule.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(binaryRelationshipRule.ModifiedOn);
            writer.Write(binaryRelationshipRule.ThingPreference);
            if (binaryRelationshipRule.Actor.HasValue)
            {
                writer.Write(binaryRelationshipRule.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(binaryRelationshipRule.Attachment.Count);
            foreach (var identifier in binaryRelationshipRule.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="BinaryRelationshipRule"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="BinaryRelationshipRule"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="BinaryRelationshipRule"/>.
        /// </returns>
        public BinaryRelationshipRule Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var binaryRelationshipRule = new BinaryRelationshipRule();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        binaryRelationshipRule.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        binaryRelationshipRule.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationshipRule.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationshipRule.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        binaryRelationshipRule.ForwardRelationshipName = reader.ReadString();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationshipRule.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        binaryRelationshipRule.InverseRelationshipName = reader.ReadString();
                        break;
                    case 7:
                        binaryRelationshipRule.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        binaryRelationshipRule.Name = reader.ReadString();
                        break;
                    case 9:
                        binaryRelationshipRule.RelationshipCategory = reader.ReadBytes().ToGuid();
                        break;
                    case 10:
                        binaryRelationshipRule.ShortName = reader.ReadString();
                        break;
                    case 11:
                        binaryRelationshipRule.SourceCategory = reader.ReadBytes().ToGuid();
                        break;
                    case 12:
                        binaryRelationshipRule.TargetCategory = reader.ReadBytes().ToGuid();
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationshipRule.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationshipRule.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        binaryRelationshipRule.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 16:
                        binaryRelationshipRule.ThingPreference = reader.ReadString();
                        break;
                    case 17:
                        if (reader.TryReadNil())
                        {
                            binaryRelationshipRule.Actor = null;
                        }
                        else
                        {
                            binaryRelationshipRule.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            binaryRelationshipRule.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return binaryRelationshipRule;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
