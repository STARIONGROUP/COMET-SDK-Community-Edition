// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecompositionRuleMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | containedCategory                    | Guid                         | 1..*        |  1.0.0  |
 | 4     | containingCategory                   | Guid                         | 1..1        |  1.0.0  |
 | 5     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | maxContained                         | int                          | 0..1        |  1.0.0  |
 | 9     | minContained                         | int                          | 1..1        |  1.0.0  |
 | 10    | name                                 | string                       | 1..1        |  1.0.0  |
 | 11    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 12    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 13    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 15    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 16    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 17    | attachment                           | Guid                         | 0..*        |  1.4.0  |
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
    /// The purpose of the <see cref="DecompositionRuleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DecompositionRule"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class DecompositionRuleMessagePackFormatter : IMessagePackFormatter<DecompositionRule>
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
        /// Serializes an <see cref="DecompositionRule"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="decompositionRule">
        /// The <see cref="DecompositionRule"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DecompositionRule decompositionRule, MessagePackSerializerOptions options)
        {
            if (decompositionRule == null)
            {
                throw new ArgumentNullException(nameof(decompositionRule), "The DecompositionRule may not be null");
            }

            writer.WriteArrayHeader(18);

            writer.Write(decompositionRule.Iid.ToByteArray());
            writer.Write(decompositionRule.RevisionNumber);

            writer.WriteArrayHeader(decompositionRule.Alias.Count);
            foreach (var identifier in decompositionRule.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(decompositionRule.ContainedCategory.Count);
            foreach (var identifier in decompositionRule.ContainedCategory.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(decompositionRule.ContainingCategory.ToByteArray());
            writer.WriteArrayHeader(decompositionRule.Definition.Count);
            foreach (var identifier in decompositionRule.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(decompositionRule.HyperLink.Count);
            foreach (var identifier in decompositionRule.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(decompositionRule.IsDeprecated);
            if (decompositionRule.MaxContained.HasValue)
            {
                writer.Write(decompositionRule.MaxContained.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(decompositionRule.MinContained);
            writer.Write(decompositionRule.Name);
            writer.Write(decompositionRule.ShortName);
            writer.WriteArrayHeader(decompositionRule.ExcludedDomain.Count);
            foreach (var identifier in decompositionRule.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(decompositionRule.ExcludedPerson.Count);
            foreach (var identifier in decompositionRule.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(decompositionRule.ModifiedOn);
            writer.Write(decompositionRule.ThingPreference);
            if (decompositionRule.Actor.HasValue)
            {
                writer.Write(decompositionRule.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(decompositionRule.Attachment.Count);
            foreach (var identifier in decompositionRule.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DecompositionRule"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DecompositionRule"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DecompositionRule"/>.
        /// </returns>
        public DecompositionRule Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var decompositionRule = new DecompositionRule();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        decompositionRule.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        decompositionRule.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            decompositionRule.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            decompositionRule.ContainedCategory.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        decompositionRule.ContainingCategory = reader.ReadBytes().ToGuid();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            decompositionRule.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            decompositionRule.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        decompositionRule.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        if (reader.TryReadNil())
                        {
                            decompositionRule.MaxContained = null;
                        }
                        else
                        {
                            decompositionRule.MaxContained = reader.ReadInt32();
                        }
                        break;
                    case 9:
                        decompositionRule.MinContained = reader.ReadInt32();
                        break;
                    case 10:
                        decompositionRule.Name = reader.ReadString();
                        break;
                    case 11:
                        decompositionRule.ShortName = reader.ReadString();
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            decompositionRule.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            decompositionRule.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        decompositionRule.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 15:
                        decompositionRule.ThingPreference = reader.ReadString();
                        break;
                    case 16:
                        if (reader.TryReadNil())
                        {
                            decompositionRule.Actor = null;
                        }
                        else
                        {
                            decompositionRule.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            decompositionRule.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return decompositionRule;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
