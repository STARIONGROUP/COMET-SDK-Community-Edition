// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizedCategoryRuleMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | category                             | Guid                         | 1..1        |  1.0.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 6     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 7     | name                                 | string                       | 1..1        |  1.0.0  |
 | 8     | parameterType                        | Guid                         | 1..*        |  1.0.0  |
 | 9     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 14    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 15    | attachment                           | Guid                         | 0..*        |  1.4.0  |
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
    /// The purpose of the <see cref="ParameterizedCategoryRuleMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="ParameterizedCategoryRule"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class ParameterizedCategoryRuleMessagePackFormatter : IMessagePackFormatter<ParameterizedCategoryRule>
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
        /// Serializes an <see cref="ParameterizedCategoryRule"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="parameterizedCategoryRule">
        /// The <see cref="ParameterizedCategoryRule"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, ParameterizedCategoryRule parameterizedCategoryRule, MessagePackSerializerOptions options)
        {
            if (parameterizedCategoryRule == null)
            {
                throw new ArgumentNullException(nameof(parameterizedCategoryRule), "The ParameterizedCategoryRule may not be null");
            }

            writer.WriteArrayHeader(16);

            writer.Write(parameterizedCategoryRule.Iid.ToByteArray());
            writer.Write(parameterizedCategoryRule.RevisionNumber);

            writer.WriteArrayHeader(parameterizedCategoryRule.Alias.Count);
            foreach (var identifier in parameterizedCategoryRule.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterizedCategoryRule.Category.ToByteArray());
            writer.WriteArrayHeader(parameterizedCategoryRule.Definition.Count);
            foreach (var identifier in parameterizedCategoryRule.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameterizedCategoryRule.HyperLink.Count);
            foreach (var identifier in parameterizedCategoryRule.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterizedCategoryRule.IsDeprecated);
            writer.Write(parameterizedCategoryRule.Name);
            writer.WriteArrayHeader(parameterizedCategoryRule.ParameterType.Count);
            foreach (var identifier in parameterizedCategoryRule.ParameterType.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterizedCategoryRule.ShortName);
            writer.WriteArrayHeader(parameterizedCategoryRule.ExcludedDomain.Count);
            foreach (var identifier in parameterizedCategoryRule.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(parameterizedCategoryRule.ExcludedPerson.Count);
            foreach (var identifier in parameterizedCategoryRule.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(parameterizedCategoryRule.ModifiedOn);
            writer.Write(parameterizedCategoryRule.ThingPreference);
            if (parameterizedCategoryRule.Actor.HasValue)
            {
                writer.Write(parameterizedCategoryRule.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(parameterizedCategoryRule.Attachment.Count);
            foreach (var identifier in parameterizedCategoryRule.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="ParameterizedCategoryRule"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="ParameterizedCategoryRule"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="ParameterizedCategoryRule"/>.
        /// </returns>
        public ParameterizedCategoryRule Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var parameterizedCategoryRule = new ParameterizedCategoryRule();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        parameterizedCategoryRule.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        parameterizedCategoryRule.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterizedCategoryRule.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        parameterizedCategoryRule.Category = reader.ReadBytes().ToGuid();
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterizedCategoryRule.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterizedCategoryRule.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        parameterizedCategoryRule.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 7:
                        parameterizedCategoryRule.Name = reader.ReadString();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterizedCategoryRule.ParameterType.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        parameterizedCategoryRule.ShortName = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterizedCategoryRule.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterizedCategoryRule.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        parameterizedCategoryRule.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        parameterizedCategoryRule.ThingPreference = reader.ReadString();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            parameterizedCategoryRule.Actor = null;
                        }
                        else
                        {
                            parameterizedCategoryRule.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            parameterizedCategoryRule.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return parameterizedCategoryRule;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
