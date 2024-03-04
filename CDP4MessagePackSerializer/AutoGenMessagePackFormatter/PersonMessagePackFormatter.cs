// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | defaultDomain                        | Guid                         | 0..1        |  1.0.0  |
 | 3     | defaultEmailAddress                  | Guid                         | 0..1        |  1.0.0  |
 | 4     | defaultTelephoneNumber               | Guid                         | 0..1        |  1.0.0  |
 | 5     | emailAddress                         | Guid                         | 0..*        |  1.0.0  |
 | 6     | givenName                            | string                       | 1..1        |  1.0.0  |
 | 7     | isActive                             | bool                         | 1..1        |  1.0.0  |
 | 8     | isDeprecated                         | bool                         | 1..1        |  1.0.0  |
 | 9     | organization                         | Guid                         | 0..1        |  1.0.0  |
 | 10    | organizationalUnit                   | string                       | 0..1        |  1.0.0  |
 | 11    | password                             | string                       | 0..1        |  1.0.0  |
 | 12    | role                                 | Guid                         | 0..1        |  1.0.0  |
 | 13    | shortName                            | string                       | 1..1        |  1.0.0  |
 | 14    | surname                              | string                       | 1..1        |  1.0.0  |
 | 15    | telephoneNumber                      | Guid                         | 0..*        |  1.0.0  |
 | 16    | userPreference                       | Guid                         | 0..*        |  1.0.0  |
 | 17    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 18    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 19    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 20    | thingPreference                      | string                       | 0..1        |  1.2.0  |
 | 21    | actor                                | Guid                         | 0..1        |  1.3.0  |
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
    /// The purpose of the <see cref="PersonMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Person"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class PersonMessagePackFormatter : IMessagePackFormatter<Person>
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
        /// Serializes an <see cref="Person"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="person">
        /// The <see cref="Person"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Person person, MessagePackSerializerOptions options)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person), "The Person may not be null");
            }

            writer.WriteArrayHeader(22);

            writer.Write(person.Iid.ToByteArray());
            writer.Write(person.RevisionNumber);

            if (person.DefaultDomain.HasValue)
            {
                writer.Write(person.DefaultDomain.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (person.DefaultEmailAddress.HasValue)
            {
                writer.Write(person.DefaultEmailAddress.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (person.DefaultTelephoneNumber.HasValue)
            {
                writer.Write(person.DefaultTelephoneNumber.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(person.EmailAddress.Count);
            foreach (var identifier in person.EmailAddress.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(person.GivenName);
            writer.Write(person.IsActive);
            writer.Write(person.IsDeprecated);
            if (person.Organization.HasValue)
            {
                writer.Write(person.Organization.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(person.OrganizationalUnit);
            writer.Write(person.Password);
            if (person.Role.HasValue)
            {
                writer.Write(person.Role.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.Write(person.ShortName);
            writer.Write(person.Surname);
            writer.WriteArrayHeader(person.TelephoneNumber.Count);
            foreach (var identifier in person.TelephoneNumber.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(person.UserPreference.Count);
            foreach (var identifier in person.UserPreference.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(person.ExcludedDomain.Count);
            foreach (var identifier in person.ExcludedDomain.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(person.ExcludedPerson.Count);
            foreach (var identifier in person.ExcludedPerson.OrderBy(x => x, guidComparer))
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(person.ModifiedOn);
            writer.Write(person.ThingPreference);
            if (person.Actor.HasValue)
            {
                writer.Write(person.Actor.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Person"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Person"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Person"/>.
        /// </returns>
        public Person Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var person = new Person();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        person.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        person.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        if (reader.TryReadNil())
                        {
                            person.DefaultDomain = null;
                        }
                        else
                        {
                            person.DefaultDomain = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            person.DefaultEmailAddress = null;
                        }
                        else
                        {
                            person.DefaultEmailAddress = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        if (reader.TryReadNil())
                        {
                            person.DefaultTelephoneNumber = null;
                        }
                        else
                        {
                            person.DefaultTelephoneNumber = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            person.EmailAddress.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        person.GivenName = reader.ReadString();
                        break;
                    case 7:
                        person.IsActive = reader.ReadBoolean();
                        break;
                    case 8:
                        person.IsDeprecated = reader.ReadBoolean();
                        break;
                    case 9:
                        if (reader.TryReadNil())
                        {
                            person.Organization = null;
                        }
                        else
                        {
                            person.Organization = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 10:
                        person.OrganizationalUnit = reader.ReadString();
                        break;
                    case 11:
                        person.Password = reader.ReadString();
                        break;
                    case 12:
                        if (reader.TryReadNil())
                        {
                            person.Role = null;
                        }
                        else
                        {
                            person.Role = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 13:
                        person.ShortName = reader.ReadString();
                        break;
                    case 14:
                        person.Surname = reader.ReadString();
                        break;
                    case 15:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            person.TelephoneNumber.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            person.UserPreference.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            person.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            person.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        person.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 20:
                        person.ThingPreference = reader.ReadString();
                        break;
                    case 21:
                        if (reader.TryReadNil())
                        {
                            person.Actor = null;
                        }
                        else
                        {
                            person.Actor = reader.ReadBytes().ToGuid();
                        }
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return person;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
