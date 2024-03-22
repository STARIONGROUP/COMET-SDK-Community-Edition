// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
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
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NLog;

    using Thing = CDP4Common.DTO.Thing;
    using Iteration = CDP4Common.DTO.Iteration;

    /// <summary>
    /// The purpose of the <see cref="IterationSerializer"/> class is to provide a <see cref="Iteration"/> specific serializer
    /// </summary>
    public class IterationSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// Serializes a <see cref="Thing" /> into an <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="thing">The <see cref="Thing" /> that have to be serialized</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="thing" /> is not an <see cref="Iteration" /></exception>
        /// <exception cref="NotSupportedException">If the provided <paramref name="requestedDataModelVersion" /> is not supported</exception>
        public void Serialize(Thing thing, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            if (thing is not Iteration iteration)
            {
                throw new ArgumentException("The thing shall be a Iteration", nameof(thing));
            }

            if (requestedDataModelVersion < Version.Parse("1.0.0"))
            {
                Logger.Log(LogLevel.Info, "Skipping serialization of Iteration since Version is below 1.0.0");
                return;
            }

            writer.WriteStartObject();

            switch(requestedDataModelVersion.ToString(3))
            {
                case "1.0.0":
                    Logger.Log(LogLevel.Trace, "Serializing Iteration for Version 1.0.0");
                    writer.WriteStartArray("actualFiniteStateList"u8);

                    foreach(var actualFiniteStateListItem in iteration.ActualFiniteStateList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(actualFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(iteration.ClassKind.ToString());
                    writer.WritePropertyName("defaultOption"u8);

                    if(iteration.DefaultOption.HasValue)
                    {
                        writer.WriteStringValue(iteration.DefaultOption.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("domainFileStore"u8);

                    foreach(var domainFileStoreItem in iteration.DomainFileStore.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainFileStoreItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("element"u8);

                    foreach(var elementItem in iteration.Element.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(elementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("externalIdentifierMap"u8);

                    foreach(var externalIdentifierMapItem in iteration.ExternalIdentifierMap.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(externalIdentifierMapItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(iteration.Iid);
                    writer.WritePropertyName("iterationSetup"u8);
                    writer.WriteStringValue(iteration.IterationSetup);
                    writer.WriteStartArray("option"u8);

                    foreach(var optionItem in iteration.Option.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(optionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    foreach(var possibleFiniteStateListItem in iteration.PossibleFiniteStateList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(possibleFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("publication"u8);

                    foreach(var publicationItem in iteration.Publication.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(publicationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("relationship"u8);

                    foreach(var relationshipItem in iteration.Relationship.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relationshipItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("requirementsSpecification"u8);

                    foreach(var requirementsSpecificationItem in iteration.RequirementsSpecification.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(requirementsSpecificationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(iteration.RevisionNumber);
                    writer.WriteStartArray("ruleVerificationList"u8);

                    foreach(var ruleVerificationListItem in iteration.RuleVerificationList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(ruleVerificationListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("sourceIterationIid"u8);

                    if(iteration.SourceIterationIid.HasValue)
                    {
                        writer.WriteStringValue(iteration.SourceIterationIid.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WritePropertyName("topElement"u8);

                    if(iteration.TopElement.HasValue)
                    {
                        writer.WriteStringValue(iteration.TopElement.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "1.1.0":
                    Logger.Log(LogLevel.Trace, "Serializing Iteration for Version 1.1.0");
                    writer.WriteStartArray("actualFiniteStateList"u8);

                    foreach(var actualFiniteStateListItem in iteration.ActualFiniteStateList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(actualFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(iteration.ClassKind.ToString());
                    writer.WritePropertyName("defaultOption"u8);

                    if(iteration.DefaultOption.HasValue)
                    {
                        writer.WriteStringValue(iteration.DefaultOption.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("diagramCanvas"u8);

                    foreach(var diagramCanvasItem in iteration.DiagramCanvas.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(diagramCanvasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("domainFileStore"u8);

                    foreach(var domainFileStoreItem in iteration.DomainFileStore.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainFileStoreItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("element"u8);

                    foreach(var elementItem in iteration.Element.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(elementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in iteration.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in iteration.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("externalIdentifierMap"u8);

                    foreach(var externalIdentifierMapItem in iteration.ExternalIdentifierMap.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(externalIdentifierMapItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("goal"u8);

                    foreach(var goalItem in iteration.Goal.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(goalItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(iteration.Iid);
                    writer.WritePropertyName("iterationSetup"u8);
                    writer.WriteStringValue(iteration.IterationSetup);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(iteration.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("option"u8);

                    foreach(var optionItem in iteration.Option.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(optionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    foreach(var possibleFiniteStateListItem in iteration.PossibleFiniteStateList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(possibleFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("publication"u8);

                    foreach(var publicationItem in iteration.Publication.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(publicationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("relationship"u8);

                    foreach(var relationshipItem in iteration.Relationship.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relationshipItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("requirementsSpecification"u8);

                    foreach(var requirementsSpecificationItem in iteration.RequirementsSpecification.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(requirementsSpecificationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(iteration.RevisionNumber);
                    writer.WriteStartArray("ruleVerificationList"u8);

                    foreach(var ruleVerificationListItem in iteration.RuleVerificationList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(ruleVerificationListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("sharedDiagramStyle"u8);

                    foreach(var sharedDiagramStyleItem in iteration.SharedDiagramStyle.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sharedDiagramStyleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("sourceIterationIid"u8);

                    if(iteration.SourceIterationIid.HasValue)
                    {
                        writer.WriteStringValue(iteration.SourceIterationIid.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("stakeholder"u8);

                    foreach(var stakeholderItem in iteration.Stakeholder.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("stakeholderValue"u8);

                    foreach(var stakeholderValueItem in iteration.StakeholderValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderValueItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("stakeholderValueMap"u8);

                    foreach(var stakeholderValueMapItem in iteration.StakeholderValueMap.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderValueMapItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("topElement"u8);

                    if(iteration.TopElement.HasValue)
                    {
                        writer.WriteStringValue(iteration.TopElement.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("valueGroup"u8);

                    foreach(var valueGroupItem in iteration.ValueGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.2.0":
                    Logger.Log(LogLevel.Trace, "Serializing Iteration for Version 1.2.0");
                    writer.WriteStartArray("actualFiniteStateList"u8);

                    foreach(var actualFiniteStateListItem in iteration.ActualFiniteStateList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(actualFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(iteration.ClassKind.ToString());
                    writer.WritePropertyName("defaultOption"u8);

                    if(iteration.DefaultOption.HasValue)
                    {
                        writer.WriteStringValue(iteration.DefaultOption.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("diagramCanvas"u8);

                    foreach(var diagramCanvasItem in iteration.DiagramCanvas.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(diagramCanvasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("domainFileStore"u8);

                    foreach(var domainFileStoreItem in iteration.DomainFileStore.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainFileStoreItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("element"u8);

                    foreach(var elementItem in iteration.Element.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(elementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in iteration.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in iteration.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("externalIdentifierMap"u8);

                    foreach(var externalIdentifierMapItem in iteration.ExternalIdentifierMap.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(externalIdentifierMapItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("goal"u8);

                    foreach(var goalItem in iteration.Goal.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(goalItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(iteration.Iid);
                    writer.WritePropertyName("iterationSetup"u8);
                    writer.WriteStringValue(iteration.IterationSetup);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(iteration.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("option"u8);

                    foreach(var optionItem in iteration.Option.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(optionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    foreach(var possibleFiniteStateListItem in iteration.PossibleFiniteStateList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(possibleFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("publication"u8);

                    foreach(var publicationItem in iteration.Publication.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(publicationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("relationship"u8);

                    foreach(var relationshipItem in iteration.Relationship.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relationshipItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("requirementsSpecification"u8);

                    foreach(var requirementsSpecificationItem in iteration.RequirementsSpecification.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(requirementsSpecificationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(iteration.RevisionNumber);
                    writer.WriteStartArray("ruleVerificationList"u8);

                    foreach(var ruleVerificationListItem in iteration.RuleVerificationList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(ruleVerificationListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("sharedDiagramStyle"u8);

                    foreach(var sharedDiagramStyleItem in iteration.SharedDiagramStyle.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sharedDiagramStyleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("sourceIterationIid"u8);

                    if(iteration.SourceIterationIid.HasValue)
                    {
                        writer.WriteStringValue(iteration.SourceIterationIid.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("stakeholder"u8);

                    foreach(var stakeholderItem in iteration.Stakeholder.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("stakeholderValue"u8);

                    foreach(var stakeholderValueItem in iteration.StakeholderValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderValueItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("stakeholderValueMap"u8);

                    foreach(var stakeholderValueMapItem in iteration.StakeholderValueMap.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderValueMapItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(iteration.ThingPreference);
                    writer.WritePropertyName("topElement"u8);

                    if(iteration.TopElement.HasValue)
                    {
                        writer.WriteStringValue(iteration.TopElement.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("valueGroup"u8);

                    foreach(var valueGroupItem in iteration.ValueGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                case "1.3.0":
                    Logger.Log(LogLevel.Trace, "Serializing Iteration for Version 1.3.0");
                    writer.WritePropertyName("actor"u8);

                    if(iteration.Actor.HasValue)
                    {
                        writer.WriteStringValue(iteration.Actor.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("actualFiniteStateList"u8);

                    foreach(var actualFiniteStateListItem in iteration.ActualFiniteStateList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(actualFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("classKind"u8);
                    writer.WriteStringValue(iteration.ClassKind.ToString());
                    writer.WritePropertyName("defaultOption"u8);

                    if(iteration.DefaultOption.HasValue)
                    {
                        writer.WriteStringValue(iteration.DefaultOption.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("diagramCanvas"u8);

                    foreach(var diagramCanvasItem in iteration.DiagramCanvas.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(diagramCanvasItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("domainFileStore"u8);

                    foreach(var domainFileStoreItem in iteration.DomainFileStore.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(domainFileStoreItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("element"u8);

                    foreach(var elementItem in iteration.Element.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(elementItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedDomain"u8);

                    foreach(var excludedDomainItem in iteration.ExcludedDomain.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedDomainItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("excludedPerson"u8);

                    foreach(var excludedPersonItem in iteration.ExcludedPerson.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(excludedPersonItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("externalIdentifierMap"u8);

                    foreach(var externalIdentifierMapItem in iteration.ExternalIdentifierMap.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(externalIdentifierMapItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("goal"u8);

                    foreach(var goalItem in iteration.Goal.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(goalItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("iid"u8);
                    writer.WriteStringValue(iteration.Iid);
                    writer.WritePropertyName("iterationSetup"u8);
                    writer.WriteStringValue(iteration.IterationSetup);
                    writer.WritePropertyName("modifiedOn"u8);
                    writer.WriteStringValue(iteration.ModifiedOn.ToString(SerializerHelper.DateTimeFormat));
                    writer.WriteStartArray("option"u8);

                    foreach(var optionItem in iteration.Option.OrderBy(x => x, this.OrderedItemComparer))
                    {
                        writer.WriteOrderedItem(optionItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    foreach(var possibleFiniteStateListItem in iteration.PossibleFiniteStateList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(possibleFiniteStateListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("publication"u8);

                    foreach(var publicationItem in iteration.Publication.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(publicationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("relationship"u8);

                    foreach(var relationshipItem in iteration.Relationship.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(relationshipItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("requirementsSpecification"u8);

                    foreach(var requirementsSpecificationItem in iteration.RequirementsSpecification.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(requirementsSpecificationItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("revisionNumber"u8);
                    writer.WriteNumberValue(iteration.RevisionNumber);
                    writer.WriteStartArray("ruleVerificationList"u8);

                    foreach(var ruleVerificationListItem in iteration.RuleVerificationList.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(ruleVerificationListItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("sharedDiagramStyle"u8);

                    foreach(var sharedDiagramStyleItem in iteration.SharedDiagramStyle.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(sharedDiagramStyleItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("sourceIterationIid"u8);

                    if(iteration.SourceIterationIid.HasValue)
                    {
                        writer.WriteStringValue(iteration.SourceIterationIid.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("stakeholder"u8);

                    foreach(var stakeholderItem in iteration.Stakeholder.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("stakeholderValue"u8);

                    foreach(var stakeholderValueItem in iteration.StakeholderValue.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderValueItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WriteStartArray("stakeholderValueMap"u8);

                    foreach(var stakeholderValueMapItem in iteration.StakeholderValueMap.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(stakeholderValueMapItem);
                    }

                    writer.WriteEndArray();
                    
                    writer.WritePropertyName("thingPreference"u8);
                    writer.WriteStringValue(iteration.ThingPreference);
                    writer.WritePropertyName("topElement"u8);

                    if(iteration.TopElement.HasValue)
                    {
                        writer.WriteStringValue(iteration.TopElement.Value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    writer.WriteStartArray("valueGroup"u8);

                    foreach(var valueGroupItem in iteration.ValueGroup.OrderBy(x => x, this.GuidComparer))
                    {
                        writer.WriteStringValue(valueGroupItem);
                    }

                    writer.WriteEndArray();
                    
                    break;
                default:
                    throw new NotSupportedException($"The provided version {requestedDataModelVersion.ToString(3)} is not supported");
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Serialize a value for a <see cref="Iteration"/> property into a <see cref="Utf8JsonWriter" />
        /// </summary>
        /// <param name="propertyName">The name of the property to serialize</param>
        /// <param name="value">The object value to serialize</param>
        /// <param name="writer">The <see cref="Utf8JsonWriter" /></param>
        /// <param name="requestedDataModelVersion">The <see cref="Version" /> that has been requested for the serialization</param>
        /// <remarks>This method should only be used in the scope of serializing a <see cref="ClasslessDTO" /></remarks>
        public void SerializeProperty(string propertyName, object value, Utf8JsonWriter writer, Version requestedDataModelVersion)
        {
            var requestedVersion = requestedDataModelVersion.ToString(3);

            switch(propertyName.ToLower())
            {
                case "actor":
                    if(!AllowedVersionsPerProperty["actor"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("actor"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "actualfinitestatelist":
                    if(!AllowedVersionsPerProperty["actualFiniteStateList"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("actualFiniteStateList"u8);

                    if(value is IEnumerable<object> objectListActualFiniteStateList)
                    {
                        foreach(var actualFiniteStateListItem in objectListActualFiniteStateList.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(actualFiniteStateListItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "classkind":
                    if(!AllowedVersionsPerProperty["classKind"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("classKind"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((ClassKind)value).ToString());
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "defaultoption":
                    if(!AllowedVersionsPerProperty["defaultOption"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("defaultOption"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "diagramcanvas":
                    if(!AllowedVersionsPerProperty["diagramCanvas"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("diagramCanvas"u8);

                    if(value is IEnumerable<object> objectListDiagramCanvas)
                    {
                        foreach(var diagramCanvasItem in objectListDiagramCanvas.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(diagramCanvasItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "domainfilestore":
                    if(!AllowedVersionsPerProperty["domainFileStore"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("domainFileStore"u8);

                    if(value is IEnumerable<object> objectListDomainFileStore)
                    {
                        foreach(var domainFileStoreItem in objectListDomainFileStore.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(domainFileStoreItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "element":
                    if(!AllowedVersionsPerProperty["element"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("element"u8);

                    if(value is IEnumerable<object> objectListElement)
                    {
                        foreach(var elementItem in objectListElement.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(elementItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "excludeddomain":
                    if(!AllowedVersionsPerProperty["excludedDomain"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("excludedDomain"u8);

                    if(value is IEnumerable<object> objectListExcludedDomain)
                    {
                        foreach(var excludedDomainItem in objectListExcludedDomain.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedDomainItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "excludedperson":
                    if(!AllowedVersionsPerProperty["excludedPerson"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("excludedPerson"u8);

                    if(value is IEnumerable<object> objectListExcludedPerson)
                    {
                        foreach(var excludedPersonItem in objectListExcludedPerson.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(excludedPersonItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "externalidentifiermap":
                    if(!AllowedVersionsPerProperty["externalIdentifierMap"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("externalIdentifierMap"u8);

                    if(value is IEnumerable<object> objectListExternalIdentifierMap)
                    {
                        foreach(var externalIdentifierMapItem in objectListExternalIdentifierMap.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(externalIdentifierMapItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "goal":
                    if(!AllowedVersionsPerProperty["goal"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("goal"u8);

                    if(value is IEnumerable<object> objectListGoal)
                    {
                        foreach(var goalItem in objectListGoal.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(goalItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "iid":
                    if(!AllowedVersionsPerProperty["iid"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("iid"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "iterationsetup":
                    if(!AllowedVersionsPerProperty["iterationSetup"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("iterationSetup"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "modifiedon":
                    if(!AllowedVersionsPerProperty["modifiedOn"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("modifiedOn"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue(((DateTime)value).ToString(SerializerHelper.DateTimeFormat));
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "option":
                    if(!AllowedVersionsPerProperty["option"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("option"u8);

                    if(value is IEnumerable<object> objectListOption)
                    {
                        foreach(var optionItem in objectListOption.OfType<OrderedItem>().OrderBy(x => x, this.OrderedItemComparer))
                        {
                            writer.WriteOrderedItem(optionItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "possiblefinitestatelist":
                    if(!AllowedVersionsPerProperty["possibleFiniteStateList"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("possibleFiniteStateList"u8);

                    if(value is IEnumerable<object> objectListPossibleFiniteStateList)
                    {
                        foreach(var possibleFiniteStateListItem in objectListPossibleFiniteStateList.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(possibleFiniteStateListItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "publication":
                    if(!AllowedVersionsPerProperty["publication"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("publication"u8);

                    if(value is IEnumerable<object> objectListPublication)
                    {
                        foreach(var publicationItem in objectListPublication.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(publicationItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "relationship":
                    if(!AllowedVersionsPerProperty["relationship"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("relationship"u8);

                    if(value is IEnumerable<object> objectListRelationship)
                    {
                        foreach(var relationshipItem in objectListRelationship.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(relationshipItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "requirementsspecification":
                    if(!AllowedVersionsPerProperty["requirementsSpecification"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("requirementsSpecification"u8);

                    if(value is IEnumerable<object> objectListRequirementsSpecification)
                    {
                        foreach(var requirementsSpecificationItem in objectListRequirementsSpecification.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(requirementsSpecificationItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "revisionnumber":
                    if(!AllowedVersionsPerProperty["revisionNumber"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("revisionNumber"u8);
                    
                    if(value != null)
                    {
                        writer.WriteNumberValue((int)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "ruleverificationlist":
                    if(!AllowedVersionsPerProperty["ruleVerificationList"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("ruleVerificationList"u8);

                    if(value is IEnumerable<object> objectListRuleVerificationList)
                    {
                        foreach(var ruleVerificationListItem in objectListRuleVerificationList.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(ruleVerificationListItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "shareddiagramstyle":
                    if(!AllowedVersionsPerProperty["sharedDiagramStyle"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("sharedDiagramStyle"u8);

                    if(value is IEnumerable<object> objectListSharedDiagramStyle)
                    {
                        foreach(var sharedDiagramStyleItem in objectListSharedDiagramStyle.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(sharedDiagramStyleItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "sourceiterationiid":
                    if(!AllowedVersionsPerProperty["sourceIterationIid"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("sourceIterationIid"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "stakeholder":
                    if(!AllowedVersionsPerProperty["stakeholder"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("stakeholder"u8);

                    if(value is IEnumerable<object> objectListStakeholder)
                    {
                        foreach(var stakeholderItem in objectListStakeholder.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(stakeholderItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "stakeholdervalue":
                    if(!AllowedVersionsPerProperty["stakeholderValue"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("stakeholderValue"u8);

                    if(value is IEnumerable<object> objectListStakeholderValue)
                    {
                        foreach(var stakeholderValueItem in objectListStakeholderValue.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(stakeholderValueItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "stakeholdervaluemap":
                    if(!AllowedVersionsPerProperty["stakeholderValueMap"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("stakeholderValueMap"u8);

                    if(value is IEnumerable<object> objectListStakeholderValueMap)
                    {
                        foreach(var stakeholderValueMapItem in objectListStakeholderValueMap.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(stakeholderValueMapItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                case "thingpreference":
                    if(!AllowedVersionsPerProperty["thingPreference"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("thingPreference"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((string)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "topelement":
                    if(!AllowedVersionsPerProperty["topElement"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WritePropertyName("topElement"u8);
                    
                    if(value != null)
                    {
                        writer.WriteStringValue((Guid)value);
                    }
                    else
                    {
                        writer.WriteNullValue();
                    }

                    break;
                case "valuegroup":
                    if(!AllowedVersionsPerProperty["valueGroup"].Contains(requestedVersion))
                    {
                        return;
                    }

                    writer.WriteStartArray("valueGroup"u8);

                    if(value is IEnumerable<object> objectListValueGroup)
                    {
                        foreach(var valueGroupItem in objectListValueGroup.OfType<Guid>().OrderBy(x => x, this.GuidComparer))
                        {
                            writer.WriteStringValue(valueGroupItem);
                        }
                    }
                    
                    writer.WriteEndArray();
                    break;
                default:
                    throw new ArgumentException($"The requested property {propertyName} does not exist on the Iteration");
            }
        }

        /// <summary>
        /// Gets the association between a name of a property and all versions where that property is defined
        /// </summary>
        private static readonly IReadOnlyDictionary<string, IReadOnlyCollection<string>> AllowedVersionsPerProperty = new Dictionary<string, IReadOnlyCollection<string>>()
        {
            { "actor", new []{ "1.3.0" }},
            { "actualFiniteStateList", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "classKind", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "defaultOption", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "diagramCanvas", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "domainFileStore", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "element", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedDomain", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "excludedPerson", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "externalIdentifierMap", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "goal", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "iid", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "iterationSetup", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "modifiedOn", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "option", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "possibleFiniteStateList", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "publication", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "relationship", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "requirementsSpecification", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "revisionNumber", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "ruleVerificationList", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "sharedDiagramStyle", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "sourceIterationIid", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "stakeholder", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "stakeholderValue", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "stakeholderValueMap", new []{ "1.1.0", "1.2.0", "1.3.0" }},
            { "thingPreference", new []{ "1.2.0", "1.3.0" }},
            { "topElement", new []{ "1.0.0", "1.1.0", "1.2.0", "1.3.0" }},
            { "valueGroup", new []{ "1.1.0", "1.2.0", "1.3.0" }},
        };
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
