// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SolutionMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | author                               | Guid                         | 1..1        |  1.1.0  |
 | 3     | content                              | string                       | 1..1        |  1.1.0  |
 | 4     | createdOn                            | DateTime                     | 1..1        |  1.1.0  |
 | 5     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 6     | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 7     | languageCode                         | string                       | 1..1        |  1.1.0  |
 | 8     | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 9     | owner                                | Guid                         | 1..1        |  1.1.0  |
 | 10    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="SolutionMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Solution"/> type
    /// </summary>
    [CDPVersion("1.1.0")]
    public class SolutionMessagePackFormatter : IMessagePackFormatter<Solution>
    {
        /// <summary>
        /// Serializes an <see cref="Solution"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="solution">
        /// The <see cref="Solution"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Solution solution, MessagePackSerializerOptions options)
        {
            if (solution == null)
            {
                throw new ArgumentNullException(nameof(solution), "The Solution may not be null");
            }

            writer.WriteArrayHeader(11);

            writer.Write(solution.Iid.ToByteArray());
            writer.Write(solution.RevisionNumber);

            writer.Write(solution.Author.ToByteArray());
            writer.Write(solution.Content);
            writer.Write(solution.CreatedOn);
            writer.WriteArrayHeader(solution.ExcludedDomain.Count);
            foreach (var identifier in solution.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(solution.ExcludedPerson.Count);
            foreach (var identifier in solution.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(solution.LanguageCode);
            writer.Write(solution.ModifiedOn);
            writer.Write(solution.Owner.ToByteArray());
            writer.Write(solution.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Solution"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Solution"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Solution"/>.
        /// </returns>
        public Solution Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var solution = new Solution();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        solution.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        solution.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        solution.Author = reader.ReadBytes().ToGuid();
                        break;
                    case 3:
                        solution.Content = reader.ReadString();
                        break;
                    case 4:
                        solution.CreatedOn = reader.ReadDateTime();
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            solution.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            solution.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        solution.LanguageCode = reader.ReadString();
                        break;
                    case 8:
                        solution.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 9:
                        solution.Owner = reader.ReadBytes().ToGuid();
                        break;
                    case 10:
                        solution.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return solution;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
