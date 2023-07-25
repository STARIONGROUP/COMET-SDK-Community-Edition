// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoalMessagePackFormatter.cs" company="RHEA System S.A.">
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
 * -------------------------------------------- | ---------------------------- | ----------- | ------- */

namespace CDP4MessagePackSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common;
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// The purpose of the <see cref="GoalMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Goal"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class GoalMessagePackFormatter : IMessagePackFormatter<Goal>
    {
        /// <summary>
        /// Serializes an <see cref="Goal"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="goal">
        /// The <see cref="Goal"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Goal goal, MessagePackSerializerOptions options)
        {
            if (goal == null)
            {
                throw new ArgumentNullException(nameof(goal), "The Goal may not be null");
            }

            writer.WriteArrayHeader(12);

            writer.Write(goal.Iid.ToByteArray());
            writer.Write(goal.RevisionNumber);

            writer.WriteArrayHeader(goal.Alias.Count);
            foreach (var identifier in goal.Alias)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(goal.Category.Count);
            foreach (var identifier in goal.Category)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(goal.Definition.Count);
            foreach (var identifier in goal.Definition)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(goal.ExcludedDomain.Count);
            foreach (var identifier in goal.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(goal.ExcludedPerson.Count);
            foreach (var identifier in goal.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(goal.HyperLink.Count);
            foreach (var identifier in goal.HyperLink)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(goal.ModifiedOn);
            writer.Write(goal.Name);
            writer.Write(goal.ShortName);
            writer.Write(goal.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Goal"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Goal"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Goal"/>.
        /// </returns>
        public Goal Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var goal = new Goal();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        goal.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        goal.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            goal.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            goal.Category.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            goal.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            goal.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            goal.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            goal.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        goal.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        goal.Name = reader.ReadString();
                        break;
                    case 10:
                        goal.ShortName = reader.ReadString();
                        break;
                    case 11:
                        goal.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return goal;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
