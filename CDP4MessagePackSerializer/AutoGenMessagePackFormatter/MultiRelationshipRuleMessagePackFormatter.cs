// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationshipRuleMessagePackFormatter.cs" company="Starion Group S.A.">
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
 | 4     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 5     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 6     | maxRelated                           | int                          | 1..1        |  1.0.0  |
 | 7     | minRelated                           | int                          | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | relatedCategory                      | Guid                         | 1..*        |  1.0.0  |
 | 10    | relationshipCategory                 | Guid                         | 1..1        |  1.0.0  |
 | 11    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 12    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 13    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 14    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 15    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 16    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="MultiRelationshipRuleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="MultiRelationshipRule"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class MultiRelationshipRuleMessagePackFormatter : IMessagePackFormatter<MultiRelationshipRule>
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
        /// Serializes an <see cref="MultiRelationshipRule"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="multiRelationshipRule">
        /// The <see cref="MultiRelationshipRule"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, MultiRelationshipRule multiRelationshipRule, MessagePackSerializerOptions options)
        {
            if (multiRelationshipRule == null)
            {
                throw new ArgumentNullException(nameof(multiRelationshipRule), "The MultiRelationshipRule may not be null");
            }

            writer.WriteArrayHeader(17);

            writer.Write(multiRelationshipRule.Iid.ToByteArray());
            writer.Write(multiRelationshipRule.RevisionNumber);

            writer.WriteArrayHeader(multiRelationshipRule.Alias.Count);
            foreach (var identifier in multiRelationshipRule.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(multiRelationshipRule.Definition.Count);
            foreach (var identifier in multiRelationshipRule.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(multiRelationshipRule.HyperLink.Count);
            foreach (var identifier in multiRelationshipRule.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(multiRelationshipRule.IsDeprecated);
            writer.Write(multiRelationshipRule.MaxRelated);
            writer.Write(multiRelationshipRule.MinRelated);
            writer.Write(multiRelationshipRule.Name);
            writer.WriteArrayHeader(multiRelationshipRule.RelatedCategory.Count);
            foreach (var identifier in multiRelationshipRule.RelatedCategory.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(multiRelationshipRule.RelationshipCategory.ToByteArray());
            writer.Write(multiRelationshipRule.ShortName);
            writer.WriteArrayHeader(multiRelationshipRule.ExcludedDomain.Count);
            foreach (var identifier in multiRelationshipRule.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(multiRelationshipRule.ExcludedPerson.Count);
            foreach (var identifier in multiRelationshipRule.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(multiRelationshipRule.ModifiedOn);
            writer.Write(multiRelationshipRule.ThingPreference);
            if (multiRelationshipRule.Actor.HasValue)
            {
                writer.Write(multiRelationshipRule.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="MultiRelationshipRule"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="MultiRelationshipRule"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="MultiRelationshipRule"/>.
        /// </returns>
        public MultiRelationshipRule Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var multiRelationshipRule = new MultiRelationshipRule();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        multiRelationshipRule.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        multiRelationshipRule.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            multiRelationshipRule.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            multiRelationshipRule.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            multiRelationshipRule.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        multiRelationshipRule.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 6:
                        multiRelationshipRule.MaxRelated = reader.ReadInt32();
                        break;
                    case 7:
                        multiRelationshipRule.MinRelated = reader.ReadInt32();
                        break;
                    case 8:
                        multiRelationshipRule.Name = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            multiRelationshipRule.RelatedCategory.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        multiRelationshipRule.RelationshipCategory = reader.ReadBytes().ToGuid();
                        break;
                    case 11:
                        multiRelationshipRule.ShortName = reader.ReadString();
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            multiRelationshipRule.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            multiRelationshipRule.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        multiRelationshipRule.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 15:
                        multiRelationshipRule.ThingPreference = reader.ReadString();
                        break;
                    case 16:
                        if (reader.TryReadNil())
                        {
                            multiRelationshipRule.Actor = null;
                        }
                        else
                        {
                            multiRelationshipRule.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return multiRelationshipRule;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
