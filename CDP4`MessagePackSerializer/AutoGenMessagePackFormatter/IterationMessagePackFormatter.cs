// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationMessagePackFormatter.cs" company="RHEA System S.A.">
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
 | 2     | actualFiniteStateList                | Guid                         | 0..*        |  1.0.0  |
 | 3     | defaultOption                        | Guid                         | 0..1        |  1.0.0  |
 | 4     | domainFileStore                      | Guid                         | 0..*        |  1.0.0  |
 | 5     | element                              | Guid                         | 0..*        |  1.0.0  |
 | 6     | externalIdentifierMap                | Guid                         | 0..*        |  1.0.0  |
 | 7     | iterationSetup                       | Guid                         | 1..1        |  1.0.0  |
 | 8     | option                               | Guid                         | 1..*        |  1.0.0  |
 | 9     | possibleFiniteStateList              | Guid                         | 0..*        |  1.0.0  |
 | 10    | publication                          | Guid                         | 0..*        |  1.0.0  |
 | 11    | relationship                         | Guid                         | 0..*        |  1.0.0  |
 | 12    | requirementsSpecification            | Guid                         | 0..*        |  1.0.0  |
 | 13    | ruleVerificationList                 | Guid                         | 0..*        |  1.0.0  |
 | 14    | sourceIterationIid                   | Guid                         | 0..1        |  1.0.0  |
 | 15    | topElement                           | Guid                         | 0..1        |  1.0.0  |
 | 16    | diagramCanvas                        | Guid                         | 0..*        |  1.1.0  |
 | 17    | excludedDomain                       | Guid                         | 0..*        |  1.1.0  |
 | 18    | excludedPerson                       | Guid                         | 0..*        |  1.1.0  |
 | 19    | goal                                 | Guid                         | 0..*        |  1.1.0  |
 | 20    | modifiedOn                           | DateTime                     | 1..1        |  1.1.0  |
 | 21    | sharedDiagramStyle                   | Guid                         | 0..*        |  1.1.0  |
 | 22    | stakeholder                          | Guid                         | 0..*        |  1.1.0  |
 | 23    | stakeholderValue                     | Guid                         | 0..*        |  1.1.0  |
 | 24    | stakeholderValueMap                  | Guid                         | 0..*        |  1.1.0  |
 | 25    | valueGroup                           | Guid                         | 0..*        |  1.1.0  |
 | 26    | thingPreference                      | string                       | 0..1        |  1.2.0  |
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
    /// The purpose of the <see cref="IterationMessagePackFormatter"/> is to provide
    /// the contract for MessagePack (de)serialization of the <see cref="Iteration"/> type
    /// </summary>
    [CDPVersion("1.0.0")]
    public class IterationMessagePackFormatter : IMessagePackFormatter<Iteration>
    {
        /// <summary>
        /// Serializes an <see cref="Iteration"/> DTO.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="MessagePackWriter"/> to use when serializing the value.
        /// </param>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> that is to be serialized.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        public void Serialize(ref MessagePackWriter writer, Iteration iteration, MessagePackSerializerOptions options)
        {
            if (iteration == null)
            {
                throw new ArgumentNullException(nameof(iteration), "The Iteration may not be null");
            }

            writer.WriteArrayHeader(27);

            writer.Write(iteration.Iid.ToByteArray());
            writer.Write(iteration.RevisionNumber);

            writer.WriteArrayHeader(iteration.ActualFiniteStateList.Count);
            foreach (var identifier in iteration.ActualFiniteStateList)
            {
                writer.Write(identifier.ToByteArray());
            }
            if (iteration.DefaultOption.HasValue)
            {
                writer.Write(iteration.DefaultOption.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(iteration.DomainFileStore.Count);
            foreach (var identifier in iteration.DomainFileStore)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.Element.Count);
            foreach (var identifier in iteration.Element)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.ExternalIdentifierMap.Count);
            foreach (var identifier in iteration.ExternalIdentifierMap)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(iteration.IterationSetup.ToByteArray());
            writer.WriteArrayHeader(iteration.Option.Count);
            foreach (var orderedItem in iteration.Option)
            {
                writer.WriteArrayHeader(2);
                writer.Write(orderedItem.K);
                writer.Write(((Guid)orderedItem.V).ToByteArray());
            }
            writer.WriteArrayHeader(iteration.PossibleFiniteStateList.Count);
            foreach (var identifier in iteration.PossibleFiniteStateList)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.Publication.Count);
            foreach (var identifier in iteration.Publication)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.Relationship.Count);
            foreach (var identifier in iteration.Relationship)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.RequirementsSpecification.Count);
            foreach (var identifier in iteration.RequirementsSpecification)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.RuleVerificationList.Count);
            foreach (var identifier in iteration.RuleVerificationList)
            {
                writer.Write(identifier.ToByteArray());
            }
            if (iteration.SourceIterationIid.HasValue)
            {
                writer.Write(iteration.SourceIterationIid.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            if (iteration.TopElement.HasValue)
            {
                writer.Write(iteration.TopElement.Value.ToByteArray());
            }
            else
            {
                writer.WriteNil();
            }
            writer.WriteArrayHeader(iteration.DiagramCanvas.Count);
            foreach (var identifier in iteration.DiagramCanvas)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.ExcludedDomain.Count);
            foreach (var identifier in iteration.ExcludedDomain)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.ExcludedPerson.Count);
            foreach (var identifier in iteration.ExcludedPerson)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.Goal.Count);
            foreach (var identifier in iteration.Goal)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(iteration.ModifiedOn);
            writer.WriteArrayHeader(iteration.SharedDiagramStyle.Count);
            foreach (var identifier in iteration.SharedDiagramStyle)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.Stakeholder.Count);
            foreach (var identifier in iteration.Stakeholder)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.StakeholderValue.Count);
            foreach (var identifier in iteration.StakeholderValue)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.StakeholderValueMap.Count);
            foreach (var identifier in iteration.StakeholderValueMap)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.WriteArrayHeader(iteration.ValueGroup.Count);
            foreach (var identifier in iteration.ValueGroup)
            {
                writer.Write(identifier.ToByteArray());
            }
            writer.Write(iteration.ThingPreference);

            writer.Flush();
        }

        /// <summary>
        /// Deserializes an <see cref="Iteration"/>.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="MessagePackWriter"/> to deserialize the <see cref="Iteration"/> from.
        /// </param>
        /// <param name="options">
        /// The serialization settings to use.
        /// </param>
        /// <returns>
        /// The deserialized <see cref="Iteration"/>.
        /// </returns>
        public Iteration Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                return null;
            }

            options.Security.DepthStep(ref reader);

            var iteration = new Iteration();

            var propertyCounter = reader.ReadArrayHeader();

            for (var i = 0; i < propertyCounter; i++)
            {
                int valueLength;
                int valueCounter;
                OrderedItem orderedItem = null;

                switch (i)
                {
                    case 0:
                        iteration.Iid = reader.ReadBytes().ToGuid();
                        break;
                    case 1:
                        iteration.RevisionNumber = reader.ReadInt32();
                        break;
                    case 2:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.ActualFiniteStateList.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 3:
                        if (reader.TryReadNil())
                        {
                            iteration.DefaultOption = null;
                        }
                        else
                        {
                            iteration.DefaultOption = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 4:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.DomainFileStore.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 5:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.Element.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 6:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.ExternalIdentifierMap.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 7:
                        iteration.IterationSetup = reader.ReadBytes().ToGuid();
                        break;
                    case 8:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            reader.ReadArrayHeader();
                            orderedItem = new OrderedItem();
                            orderedItem.K = reader.ReadInt64();
                            orderedItem.V = reader.ReadBytes().ToGuid();
                            iteration.Option.Add(orderedItem);
                        }
                        break;
                    case 9:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.PossibleFiniteStateList.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 10:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.Publication.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 11:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.Relationship.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 12:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.RequirementsSpecification.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 13:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.RuleVerificationList.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 14:
                        if (reader.TryReadNil())
                        {
                            iteration.SourceIterationIid = null;
                        }
                        else
                        {
                            iteration.SourceIterationIid = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 15:
                        if (reader.TryReadNil())
                        {
                            iteration.TopElement = null;
                        }
                        else
                        {
                            iteration.TopElement = reader.ReadBytes().ToGuid();
                        }
                        break;
                    case 16:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.DiagramCanvas.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 17:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.ExcludedDomain.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 18:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.ExcludedPerson.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 19:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.Goal.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 20:
                        iteration.ModifiedOn = reader.ReadDateTime();
                        break;
                    case 21:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.SharedDiagramStyle.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 22:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.Stakeholder.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 23:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.StakeholderValue.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 24:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.StakeholderValueMap.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 25:
                        valueLength = reader.ReadArrayHeader();
                        for (valueCounter = 0; valueCounter < valueLength; valueCounter++)
                        {
                            iteration.ValueGroup.Add(reader.ReadBytes().ToGuid());
                        }
                        break;
                    case 26:
                        iteration.ThingPreference = reader.ReadString();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            reader.Depth--;

            return iteration;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
