// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferencerRuleMessagePackFormatter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
 | 6     | maxReferenced                        | int                          | 1..1        |  1.0.0  |
 | 7     | minReferenced                        | int                          | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | referencedCategory                   | Guid                         | 1..*        |  1.0.0  |
 | 10    | referencingCategory                  | Guid                         | 1..1        |  1.0.0  |
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
    /// The purpose of the <see cref="ReferencerRuleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ReferencerRule"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ReferencerRuleMessagePackFormatter : IMessagePackFormatter<ReferencerRule>
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
        /// Serializes an <see cref="ReferencerRule"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="referencerRule">
        /// The <see cref="ReferencerRule"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ReferencerRule referencerRule, MessagePackSerializerOptions options)
        {
            if (referencerRule == null)
            {
                throw new ArgumentNullException(nameof(referencerRule), "The ReferencerRule may not be null");
            }

            writer.WriteArrayHeader(17);

            writer.Write(referencerRule.Iid.ToByteArray());
            writer.Write(referencerRule.RevisionNumber);

            writer.WriteArrayHeader(referencerRule.Alias.Count);
            foreach (var identifier in referencerRule.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(referencerRule.Definition.Count);
            foreach (var identifier in referencerRule.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(referencerRule.HyperLink.Count);
            foreach (var identifier in referencerRule.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(referencerRule.IsDeprecated);
            writer.Write(referencerRule.MaxReferenced);
            writer.Write(referencerRule.MinReferenced);
            writer.Write(referencerRule.Name);
            writer.WriteArrayHeader(referencerRule.ReferencedCategory.Count);
            foreach (var identifier in referencerRule.ReferencedCategory.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(referencerRule.ReferencingCategory.ToByteArray());
            writer.Write(referencerRule.ShortName);
            writer.WriteArrayHeader(referencerRule.ExcludedDomain.Count);
            foreach (var identifier in referencerRule.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(referencerRule.ExcludedPerson.Count);
            foreach (var identifier in referencerRule.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(referencerRule.ModifiedOn);
            writer.Write(referencerRule.ThingPreference);
            if (referencerRule.Actor.HasValue)
            {
                writer.Write(referencerRule.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ReferencerRule"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ReferencerRule"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ReferencerRule"/>.
        /// </returns>
        public ReferencerRule Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var referencerRule = new ReferencerRule();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        referencerRule.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        referencerRule.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referencerRule.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referencerRule.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referencerRule.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        referencerRule.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 6:
                        referencerRule.MaxReferenced = reader.ReadInt32();
                        break;
                    case 7:
                        referencerRule.MinReferenced = reader.ReadInt32();
                        break;
                    case 8:
                        referencerRule.Name = reader.ReadString();
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referencerRule.ReferencedCategory.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        referencerRule.ReferencingCategory = reader.ReadBytes().ToGuid();
                        break;
                    case 11:
                        referencerRule.ShortName = reader.ReadString();
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referencerRule.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            referencerRule.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        referencerRule.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 15:
                        referencerRule.ThingPreference = reader.ReadString();
                        break;
                    case 16:
                        if (reader.TryReadNil())
                        {
                            referencerRule.Actor = null;
                        }
                        else
                        {
                            referencerRule.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return referencerRule;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
