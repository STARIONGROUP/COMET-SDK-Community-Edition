// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Jaime Bernar
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4JsonSerializer_SystemTextJson.EnumDeserializers;
    
    /// <summary>
    /// The purpose of the <see cref="IterationResolver"/> is to deserialize a JSON object to a <see cref="Iteration"/>
    /// </summary>
    public static class IterationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="Iteration"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="Iteration"/> to instantiate</returns>
        public static CDP4Common.DTO.Iteration FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var iteration = new CDP4Common.DTO.Iteration(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("actualFiniteStateList", out var actualFiniteStateListProperty))
            {
                iteration.ActualFiniteStateList.AddRange(actualFiniteStateListProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("defaultOption", out var defaultOptionProperty))
            {
                iteration.DefaultOption = defaultOptionProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("diagramCanvas", out var diagramCanvasProperty))
            {
                iteration.DiagramCanvas.AddRange(diagramCanvasProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("domainFileStore", out var domainFileStoreProperty))
            {
                iteration.DomainFileStore.AddRange(domainFileStoreProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("element", out var elementProperty))
            {
                iteration.Element.AddRange(elementProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                iteration.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                iteration.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("externalIdentifierMap", out var externalIdentifierMapProperty))
            {
                iteration.ExternalIdentifierMap.AddRange(externalIdentifierMapProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("goal", out var goalProperty))
            {
                iteration.Goal.AddRange(goalProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("iterationSetup", out var iterationSetupProperty))
            {
                iteration.IterationSetup = iterationSetupProperty.Deserialize<Guid>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                iteration.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("option", out var optionProperty))
            {
                foreach(var arrayItem in optionProperty.EnumerateArray())
                {
                    var arrayItemValue = arrayItem.Deserialize<OrderedItem>(SerializerOptions.Options);
                    if (arrayItemValue != null)
                    {
                        iteration.Option.Add(arrayItemValue);
                    }
                }
            }
            
            if (jObject.TryGetProperty("possibleFiniteStateList", out var possibleFiniteStateListProperty))
            {
                iteration.PossibleFiniteStateList.AddRange(possibleFiniteStateListProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("publication", out var publicationProperty))
            {
                iteration.Publication.AddRange(publicationProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("relationship", out var relationshipProperty))
            {
                iteration.Relationship.AddRange(relationshipProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("requirementsSpecification", out var requirementsSpecificationProperty))
            {
                iteration.RequirementsSpecification.AddRange(requirementsSpecificationProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("ruleVerificationList", out var ruleVerificationListProperty))
            {
                iteration.RuleVerificationList.AddRange(ruleVerificationListProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("sharedDiagramStyle", out var sharedDiagramStyleProperty))
            {
                iteration.SharedDiagramStyle.AddRange(sharedDiagramStyleProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("sourceIterationIid", out var sourceIterationIidProperty))
            {
                iteration.SourceIterationIid = sourceIterationIidProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("stakeholder", out var stakeholderProperty))
            {
                iteration.Stakeholder.AddRange(stakeholderProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("stakeholderValue", out var stakeholderValueProperty))
            {
                iteration.StakeholderValue.AddRange(stakeholderValueProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("stakeholderValueMap", out var stakeholderValueMapProperty))
            {
                iteration.StakeholderValueMap.AddRange(stakeholderValueMapProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                iteration.ThingPreference = thingPreferenceProperty.Deserialize<string>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("topElement", out var topElementProperty))
            {
                iteration.TopElement = topElementProperty.Deserialize<Guid?>(SerializerOptions.Options);
            }

            if (jObject.TryGetProperty("valueGroup", out var valueGroupProperty))
            {
                iteration.ValueGroup.AddRange(valueGroupProperty.Deserialize<IEnumerable<Guid>>(SerializerOptions.Options));
            }

            return iteration;
        }
    }
}
