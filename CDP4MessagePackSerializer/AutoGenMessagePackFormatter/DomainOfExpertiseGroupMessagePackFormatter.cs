// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainOfExpertiseGroupMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | attachment                           | Guid                         | 0..*        |  1.0.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | domain                               | Guid                         | 0..*        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 8     | name                                 | string                       | 1..1        |  1.0.0  |
 | 9     | shortName                            | string                       | 1..1        |  1.0.0  |
 | 10    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 11    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 12    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 13    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 14    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="DomainOfExpertiseGroupMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="DomainOfExpertiseGroup"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class DomainOfExpertiseGroupMessagePackFormatter : IMessagePackFormatter<DomainOfExpertiseGroup>
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
        /// Serializes an <see cref="DomainOfExpertiseGroup"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="domainOfExpertiseGroup">
        /// The <see cref="DomainOfExpertiseGroup"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, DomainOfExpertiseGroup domainOfExpertiseGroup, MessagePackSerializerOptions options)
        {
            if (domainOfExpertiseGroup == null)
            {
                throw new ArgumentNullException(nameof(domainOfExpertiseGroup), "The DomainOfExpertiseGroup may not be null");
            }

            writer.WriteArrayHeader(15);

            writer.Write(domainOfExpertiseGroup.Iid.ToByteArray());
            writer.Write(domainOfExpertiseGroup.RevisionNumber);

            writer.WriteArrayHeader(domainOfExpertiseGroup.Alias.Count);
            foreach (var identifier in domainOfExpertiseGroup.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(domainOfExpertiseGroup.Attachment.Count);
            foreach (var identifier in domainOfExpertiseGroup.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(domainOfExpertiseGroup.Definition.Count);
            foreach (var identifier in domainOfExpertiseGroup.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(domainOfExpertiseGroup.Domain.Count);
            foreach (var identifier in domainOfExpertiseGroup.Domain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(domainOfExpertiseGroup.HyperLink.Count);
            foreach (var identifier in domainOfExpertiseGroup.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(domainOfExpertiseGroup.IsDeprecated);
            writer.Write(domainOfExpertiseGroup.Name);
            writer.Write(domainOfExpertiseGroup.ShortName);
            writer.WriteArrayHeader(domainOfExpertiseGroup.ExcludedDomain.Count);
            foreach (var identifier in domainOfExpertiseGroup.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(domainOfExpertiseGroup.ExcludedPerson.Count);
            foreach (var identifier in domainOfExpertiseGroup.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(domainOfExpertiseGroup.ModifiedOn);
            writer.Write(domainOfExpertiseGroup.ThingPreference);
            if (domainOfExpertiseGroup.Actor.HasValue)
            {
                writer.Write(domainOfExpertiseGroup.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="DomainOfExpertiseGroup"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="DomainOfExpertiseGroup"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="DomainOfExpertiseGroup"/>.
        /// </returns>
        public DomainOfExpertiseGroup Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var domainOfExpertiseGroup = new DomainOfExpertiseGroup();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        domainOfExpertiseGroup.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        domainOfExpertiseGroup.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            domainOfExpertiseGroup.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            domainOfExpertiseGroup.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            domainOfExpertiseGroup.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            domainOfExpertiseGroup.Domain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            domainOfExpertiseGroup.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        domainOfExpertiseGroup.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 8:
                        domainOfExpertiseGroup.Name = reader.ReadString();
                        break;
                    case 9:
                        domainOfExpertiseGroup.ShortName = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            domainOfExpertiseGroup.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            domainOfExpertiseGroup.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        domainOfExpertiseGroup.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 13:
                        domainOfExpertiseGroup.ThingPreference = reader.ReadString();
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            domainOfExpertiseGroup.Actor = null;
                        }
                        else
                        {
                            domainOfExpertiseGroup.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return domainOfExpertiseGroup;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
