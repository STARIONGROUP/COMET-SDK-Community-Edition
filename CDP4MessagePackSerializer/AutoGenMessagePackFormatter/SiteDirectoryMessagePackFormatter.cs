// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 3     | defaultParticipantRole               | Guid                         | 0..1        |  1.0.0  |
 | 4     | defaultPersonRole                    | Guid                         | 0..1        |  1.0.0  |
 | 5     | domain                               | Guid                         | 0..*        |  1.0.0  |
 | 6     | domainGroup                          | Guid                         | 0..*        |  1.0.0  |
 | 7     | lastModifiedOn                       | DateTime                     | 1..1        |  1.0.0  |
 | 8     | logEntry                             | Guid                         | 0..*        |  1.0.0  |
 | 9     | model                                | Guid                         | 0..*        |  1.0.0  |
 | 10    | name                                 | string                       | 1..1        |  1.0.0  |
 | 11    | naturalLanguage                      | Guid                         | 0..*        |  1.0.0  |
 | 12    | organization                         | Guid                         | 0..*        |  1.0.0  |
 | 13    | participantRole                      | Guid                         | 0..*        |  1.0.0  |
 | 14    | person                               | Guid                         | 0..*        |  1.0.0  |
 | 15    | personRole                           | Guid                         | 0..*        |  1.0.0  |
 | 16    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 17    | siteReferenceDataLibrary             | Guid                         | 0..*        |  1.0.0  |
 | 18    | annotation                           | Guid                         | 0..*        |  1.1.0  |
 | 19    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 20    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 21    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 22    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 23    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="SiteDirectoryMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="SiteDirectory"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class SiteDirectoryMessagePackFormatter : IMessagePackFormatter<SiteDirectory>
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
        /// Serializes an <see cref="SiteDirectory"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="siteDirectory">
        /// The <see cref="SiteDirectory"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, SiteDirectory siteDirectory, MessagePackSerializerOptions options)
        {
            if (siteDirectory == null)
            {
                throw new ArgumentNullException(nameof(siteDirectory), "The SiteDirectory may not be null");
            }

            writer.WriteArrayHeader(24);

            writer.Write(siteDirectory.Iid.ToByteArray());
            writer.Write(siteDirectory.RevisionNumber);

            writer.Write(siteDirectory.CreatedOn);
            if (siteDirectory.DefaultParticipantRole.HasValue)
            {
                writer.Write(siteDirectory.DefaultParticipantRole.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (siteDirectory.DefaultPersonRole.HasValue)
            {
                writer.Write(siteDirectory.DefaultPersonRole.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(siteDirectory.Domain.Count);
            foreach (var identifier in siteDirectory.Domain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.DomainGroup.Count);
            foreach (var identifier in siteDirectory.DomainGroup.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteDirectory.LastModifiedOn);
            writer.WriteArrayHeader(siteDirectory.LogEntry.Count);
            foreach (var identifier in siteDirectory.LogEntry.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.Model.Count);
            foreach (var identifier in siteDirectory.Model.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteDirectory.Name);
            writer.WriteArrayHeader(siteDirectory.NaturalLanguage.Count);
            foreach (var identifier in siteDirectory.NaturalLanguage.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.Organization.Count);
            foreach (var identifier in siteDirectory.Organization.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.ParticipantRole.Count);
            foreach (var identifier in siteDirectory.ParticipantRole.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.Person.Count);
            foreach (var identifier in siteDirectory.Person.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.PersonRole.Count);
            foreach (var identifier in siteDirectory.PersonRole.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteDirectory.ShortName);
            writer.WriteArrayHeader(siteDirectory.SiteReferenceDataLibrary.Count);
            foreach (var identifier in siteDirectory.SiteReferenceDataLibrary.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.Annotation.Count);
            foreach (var identifier in siteDirectory.Annotation.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.ExcludedDomain.Count);
            foreach (var identifier in siteDirectory.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(siteDirectory.ExcludedPerson.Count);
            foreach (var identifier in siteDirectory.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(siteDirectory.ModifiedOn);
            writer.Write(siteDirectory.ThingPreference);
            if (siteDirectory.Actor.HasValue)
            {
                writer.Write(siteDirectory.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="SiteDirectory"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="SiteDirectory"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="SiteDirectory"/>.
        /// </returns>
        public SiteDirectory Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var siteDirectory = new SiteDirectory();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        siteDirectory.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        siteDirectory.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        siteDirectory.CreatedOn = reader.ReadDateTime();
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            siteDirectory.DefaultParticipantRole = null;
                        }
                        else
                        {
                            siteDirectory.DefaultParticipantRole = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            siteDirectory.DefaultPersonRole = null;
                        }
                        else
                        {
                            siteDirectory.DefaultPersonRole = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.Domain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.DomainGroup.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        siteDirectory.LastModifiedOn = reader.ReadDateTime();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.LogEntry.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.Model.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        siteDirectory.Name = reader.ReadString();
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.NaturalLanguage.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.Organization.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.ParticipantRole.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.Person.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.PersonRole.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        siteDirectory.ShortName = reader.ReadString();
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.SiteReferenceDataLibrary.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.Annotation.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            siteDirectory.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 21:
                        siteDirectory.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 22:
                        siteDirectory.ThingPreference = reader.ReadString();
                        break;
                    case 23:
                        if (reader.TryReadNil())
                        {
                            siteDirectory.Actor = null;
                        }
                        else
                        {
                            siteDirectory.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return siteDirectory;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
