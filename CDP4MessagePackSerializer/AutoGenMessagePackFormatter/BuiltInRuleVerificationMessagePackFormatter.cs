// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuiltInRuleVerificationMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | executedOn                           | DateTime                     | 0..1        |  1.0.0  |
 | 3     | isActive                             | bool                         | 1..1        |  1.0.0  |
 | 4     | name                                 | string                       | 1..1        |  1.0.0  |
 | 5     | status                               | RuleVerificationStatusKind   | 1..1        |  1.0.0  |
 | 6     | violation                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 8     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 9     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 10    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 11    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="BuiltInRuleVerificationMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="BuiltInRuleVerification"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class BuiltInRuleVerificationMessagePackFormatter : IMessagePackFormatter<BuiltInRuleVerification>
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
        /// Serializes an <see cref="BuiltInRuleVerification"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="builtInRuleVerification">
        /// The <see cref="BuiltInRuleVerification"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, BuiltInRuleVerification builtInRuleVerification, MessagePackSerializerOptions options)
        {
            if (builtInRuleVerification == null)
            {
                throw new ArgumentNullException(nameof(builtInRuleVerification), "The BuiltInRuleVerification may not be null");
            }

            writer.WriteArrayHeader(12);

            writer.Write(builtInRuleVerification.Iid.ToByteArray());
            writer.Write(builtInRuleVerification.RevisionNumber);

            if (builtInRuleVerification.ExecutedOn.HasValue)
            {
                writer.Write(builtInRuleVerification.ExecutedOn.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(builtInRuleVerification.IsActive);
            writer.Write(builtInRuleVerification.Name);
            writer.Write(builtInRuleVerification.Status.ToString());
            writer.WriteArrayHeader(builtInRuleVerification.Violation.Count);
            foreach (var identifier in builtInRuleVerification.Violation.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(builtInRuleVerification.ExcludedDomain.Count);
            foreach (var identifier in builtInRuleVerification.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(builtInRuleVerification.ExcludedPerson.Count);
            foreach (var identifier in builtInRuleVerification.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(builtInRuleVerification.ModifiedOn);
            writer.Write(builtInRuleVerification.ThingPreference);
            if (builtInRuleVerification.Actor.HasValue)
            {
                writer.Write(builtInRuleVerification.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="BuiltInRuleVerification"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="BuiltInRuleVerification"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="BuiltInRuleVerification"/>.
        /// </returns>
        public BuiltInRuleVerification Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var builtInRuleVerification = new BuiltInRuleVerification();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        builtInRuleVerification.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        builtInRuleVerification.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        if (reader.TryReadNil())
                        {
                            builtInRuleVerification.ExecutedOn = null;
                        }
                        else
                        {
                            builtInRuleVerification.ExecutedOn = reader.ReadDateTime();
                        }
                        break;
                    case 3:
                        builtInRuleVerification.IsActive = reader.ReadBoolean();
                        break;
                    case 4:
                        builtInRuleVerification.Name = reader.ReadString();
                        break;
                    case 5:
                        builtInRuleVerification.Status = (CDP4Common.EngineeringModelData.RuleVerificationStatusKind)Enum.Parse(typeof(CDP4Common.EngineeringModelData.RuleVerificationStatusKind), reader.ReadString(), true);
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            builtInRuleVerification.Violation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            builtInRuleVerification.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            builtInRuleVerification.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        builtInRuleVerification.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 10:
                        builtInRuleVerification.ThingPreference = reader.ReadString();
                        break;
                    case 11:
                        if (reader.TryReadNil())
                        {
                            builtInRuleVerification.Actor = null;
                        }
                        else
                        {
                            builtInRuleVerification.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return builtInRuleVerification;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
