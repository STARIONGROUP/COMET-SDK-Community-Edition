// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationSetupMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | createdOn                            | DateTime                     | 1..1        |  1.0.0  |
 | 3     | description                          | string                       | 1..1        |  1.0.0  |
 | 4     | frozenOn                             | DateTime                     | 0..1        |  1.0.0  |
 | 5     | isDeleted                            | bool                         | 1..1        |  1.0.0  |
 | 6     | iterationIid                         | Guid                         | 1..1        |  1.0.0  |
 | 7     | iterationNumber                      | int                          | 1..1        |  1.0.0  |
 | 8     | sourceIterationSetup                 | Guid                         | 0..1        |  1.0.0  |
 | 9     | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 10    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 12    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="IterationSetupMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="IterationSetup"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class IterationSetupMessagePackFormatter : IMessagePackFormatter<IterationSetup>
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
        /// Serializes an <see cref="IterationSetup"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="iterationSetup">
        /// The <see cref="IterationSetup"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, IterationSetup iterationSetup, MessagePackSerializerOptions options)
        {
            if (iterationSetup == null)
            {
                throw new ArgumentNullException(nameof(iterationSetup), "The IterationSetup may not be null");
            }

            writer.WriteArrayHeader(13);

            writer.Write(iterationSetup.Iid.ToByteArray());
            writer.Write(iterationSetup.RevisionNumber);

            writer.Write(iterationSetup.CreatedOn);
            writer.Write(iterationSetup.Description);
            if (iterationSetup.FrozenOn.HasValue)
            {
                writer.Write(iterationSetup.FrozenOn.Value);
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(iterationSetup.IsDeleted);
            writer.Write(iterationSetup.IterationIid.ToByteArray());
            writer.Write(iterationSetup.IterationNumber);
            if (iterationSetup.SourceIterationSetup.HasValue)
            {
                writer.Write(iterationSetup.SourceIterationSetup.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(iterationSetup.ExcludedDomain.Count);
            foreach (var identifier in iterationSetup.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iterationSetup.ExcludedPerson.Count);
            foreach (var identifier in iterationSetup.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(iterationSetup.ModifiedOn);
            writer.Write(iterationSetup.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="IterationSetup"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="IterationSetup"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="IterationSetup"/>.
        /// </returns>
        public IterationSetup Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var iterationSetup = new IterationSetup();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        iterationSetup.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        iterationSetup.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        iterationSetup.CreatedOn = reader.ReadDateTime();
                        break;
                    case 3:
                        iterationSetup.Description = reader.ReadString();
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            iterationSetup.FrozenOn = null;
                        }
                        else
                        {
                            iterationSetup.FrozenOn = reader.ReadDateTime();
                        }
                        break;
                    case 5:
                        iterationSetup.IsDeleted = reader.ReadBoolean();
                        break;
                    case 6:
                        iterationSetup.IterationIid = reader.ReadBytes().ToGuid();
                        break;
                    case 7:
                        iterationSetup.IterationNumber = reader.ReadInt32();
                        break;
                    case 8:
                        if (reader.TryReadNil())
                        {
                            iterationSetup.SourceIterationSetup = null;
                        }
                        else
                        {
                            iterationSetup.SourceIterationSetup = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iterationSetup.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iterationSetup.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        iterationSetup.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 12:
                        iterationSetup.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return iterationSetup;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
