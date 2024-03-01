// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetupMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | activeDomain                         | Guid                         | 1..*        |  1.0.0  |
 | 3     | alias                                | Guid                         | 0..*        |  1.0.0  |
 | 4     | definition                           | Guid                         | 0..*        |  1.0.0  |
 | 5     | engineeringModelIid                  | Guid                         | 1..1        |  1.0.0  |
 | 6     | hyperLink                            | Guid                         | 0..*        |  1.0.0  |
 | 7     | iterationSetup                       | Guid                         | 1..*        |  1.0.0  |
 | 8     | kind                                 | EngineeringModelKind         | 1..1        |  1.0.0  |
 | 9     | name                                 | string                       | 1..1        |  1.0.0  |
 | 10    | participant                          | Guid                         | 1..*        |  1.0.0  |
 | 11    | requiredRdl                          | Guid                         | 1..1        |  1.0.0  |
 | 12    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 13    | sourceEngineeringModelSetupIid       | Guid                         | 0..1        |  1.0.0  |
 | 14    | studyPhase                           | StudyPhaseKind               | 1..1        |  1.0.0  |
 | 15    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 16    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 17    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 18    | defaultOrganizationalParticipant     | Guid                         | 0..1        |  1.2.0  |
 | 19    | organizationalParticipant            | Guid                         | 0..*        |  1.2.0  |
 | 20    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 21    | actor                                | Guid                         | 0..1        |  1.3.0  |
 | 22    | attachment                           | Guid                         | 0..*        |  1.4.0  |
 | 23    | autoPublish                          | bool                         | 1..1        |  1.4.0  |
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
    /// The purpose of the <see cref="EngineeringModelSetupMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="EngineeringModelSetup"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class EngineeringModelSetupMessagePackFormatter : IMessagePackFormatter<EngineeringModelSetup>
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
        /// Serializes an <see cref="EngineeringModelSetup"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="engineeringModelSetup">
        /// The <see cref="EngineeringModelSetup"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, EngineeringModelSetup engineeringModelSetup, MessagePackSerializerOptions options)
        {
            if (engineeringModelSetup == null)
            {
                throw new ArgumentNullException(nameof(engineeringModelSetup), "The EngineeringModelSetup may not be null");
            }

            writer.WriteArrayHeader(24);

            writer.Write(engineeringModelSetup.Iid.ToByteArray());
            writer.Write(engineeringModelSetup.RevisionNumber);

            writer.WriteArrayHeader(engineeringModelSetup.ActiveDomain.Count);
            foreach (var identifier in engineeringModelSetup.ActiveDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModelSetup.Alias.Count);
            foreach (var identifier in engineeringModelSetup.Alias.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModelSetup.Definition.Count);
            foreach (var identifier in engineeringModelSetup.Definition.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModelSetup.EngineeringModelIid.ToByteArray());
            writer.WriteArrayHeader(engineeringModelSetup.HyperLink.Count);
            foreach (var identifier in engineeringModelSetup.HyperLink.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModelSetup.IterationSetup.Count);
            foreach (var identifier in engineeringModelSetup.IterationSetup.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModelSetup.Kind.ToString());
            writer.Write(engineeringModelSetup.Name);
            writer.WriteArrayHeader(engineeringModelSetup.Participant.Count);
            foreach (var identifier in engineeringModelSetup.Participant.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModelSetup.RequiredRdl.Count);
            foreach (var identifier in engineeringModelSetup.RequiredRdl.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModelSetup.ShortName);
            if (engineeringModelSetup.SourceEngineeringModelSetupIid.HasValue)
            {
                writer.Write(engineeringModelSetup.SourceEngineeringModelSetupIid.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(engineeringModelSetup.StudyPhase.ToString());
            writer.WriteArrayHeader(engineeringModelSetup.ExcludedDomain.Count);
            foreach (var identifier in engineeringModelSetup.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(engineeringModelSetup.ExcludedPerson.Count);
            foreach (var identifier in engineeringModelSetup.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModelSetup.ModifiedOn);
            if (engineeringModelSetup.DefaultOrganizationalParticipant.HasValue)
            {
                writer.Write(engineeringModelSetup.DefaultOrganizationalParticipant.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(engineeringModelSetup.OrganizationalParticipant.Count);
            foreach (var identifier in engineeringModelSetup.OrganizationalParticipant.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModelSetup.ThingPreference);
            if (engineeringModelSetup.Actor.HasValue)
            {
                writer.Write(engineeringModelSetup.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(engineeringModelSetup.Attachment.Count);
            foreach (var identifier in engineeringModelSetup.Attachment.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(engineeringModelSetup.AutoPublish);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="EngineeringModelSetup"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="EngineeringModelSetup"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="EngineeringModelSetup"/>.
        /// </returns>
        public EngineeringModelSetup Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var engineeringModelSetup = new EngineeringModelSetup();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        engineeringModelSetup.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        engineeringModelSetup.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.ActiveDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.Alias.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.Definition.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        engineeringModelSetup.EngineeringModelIid = reader.ReadBytes().ToGuid();
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.HyperLink.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.IterationSetup.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 8:
                        engineeringModelSetup.Kind = (CDP4Common.SiteDirectoryData.EngineeringModelKind)Enum.Parse(typeof(CDP4Common.SiteDirectoryData.EngineeringModelKind), reader.ReadString(), true);
                        break;
                    case 9:
                        engineeringModelSetup.Name = reader.ReadString();
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.Participant.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.RequiredRdl.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        engineeringModelSetup.ShortName = reader.ReadString();
                        break;
                    case 13:
                        if (reader.TryReadNil())
                        {
                            engineeringModelSetup.SourceEngineeringModelSetupIid = null;
                        }
                        else
                        {
                            engineeringModelSetup.SourceEngineeringModelSetupIid = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 14:
                        engineeringModelSetup.StudyPhase = (CDP4Common.SiteDirectoryData.StudyPhaseKind)Enum.Parse(typeof(CDP4Common.SiteDirectoryData.StudyPhaseKind), reader.ReadString(), true);
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        engineeringModelSetup.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 18:
                        if (reader.TryReadNil())
                        {
                            engineeringModelSetup.DefaultOrganizationalParticipant = null;
                        }
                        else
                        {
                            engineeringModelSetup.DefaultOrganizationalParticipant = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.OrganizationalParticipant.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        engineeringModelSetup.ThingPreference = reader.ReadString();
                        break;
                    case 21:
                        if (reader.TryReadNil())
                        {
                            engineeringModelSetup.Actor = null;
                        }
                        else
                        {
                            engineeringModelSetup.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 22:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            engineeringModelSetup.Attachment.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 23:
                        engineeringModelSetup.AutoPublish = reader.ReadBoolean();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return engineeringModelSetup;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
