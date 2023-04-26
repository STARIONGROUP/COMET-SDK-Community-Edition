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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

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

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="IterationResolver"/> is to deserialize a JSON object to a <see cref="Iteration"/>
    /// </summary>
    public static class IterationResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="Iteration"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="Iteration"/> to instantiate</returns>
        public static CDP4Common.DTO.Iteration FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            var iteration = new CDP4Common.DTO.Iteration(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("actualFiniteStateList"u8, out var actualFiniteStateListProperty))
            {
                foreach(var element in actualFiniteStateListProperty.EnumerateArray())
                {
                    iteration.ActualFiniteStateList.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("defaultOption"u8, out var defaultOptionProperty))
            {
                if(defaultOptionProperty.ValueKind == JsonValueKind.Null)
                {
                    iteration.DefaultOption = null;
                }
                else
                {
                    iteration.DefaultOption = defaultOptionProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("diagramCanvas"u8, out var diagramCanvasProperty))
            {
                foreach(var element in diagramCanvasProperty.EnumerateArray())
                {
                    iteration.DiagramCanvas.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("domainFileStore"u8, out var domainFileStoreProperty))
            {
                foreach(var element in domainFileStoreProperty.EnumerateArray())
                {
                    iteration.DomainFileStore.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("element"u8, out var elementProperty))
            {
                foreach(var element in elementProperty.EnumerateArray())
                {
                    iteration.Element.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    iteration.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    iteration.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("externalIdentifierMap"u8, out var externalIdentifierMapProperty))
            {
                foreach(var element in externalIdentifierMapProperty.EnumerateArray())
                {
                    iteration.ExternalIdentifierMap.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("goal"u8, out var goalProperty))
            {
                foreach(var element in goalProperty.EnumerateArray())
                {
                    iteration.Goal.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("iterationSetup"u8, out var iterationSetupProperty))
            {
                if(iterationSetupProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale iterationSetup property of the iteration {id} is null", iteration.Iid);
                }
                else
                {
                    iteration.IterationSetup = iterationSetupProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the iteration {id} is null", iteration.Iid);
                }
                else
                {
                    iteration.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("option"u8, out var optionProperty))
            {
                iteration.Option.AddRange(optionProperty.ToOrderedItemCollection());
            }

            if (jsonElement.TryGetProperty("possibleFiniteStateList"u8, out var possibleFiniteStateListProperty))
            {
                foreach(var element in possibleFiniteStateListProperty.EnumerateArray())
                {
                    iteration.PossibleFiniteStateList.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("publication"u8, out var publicationProperty))
            {
                foreach(var element in publicationProperty.EnumerateArray())
                {
                    iteration.Publication.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("relationship"u8, out var relationshipProperty))
            {
                foreach(var element in relationshipProperty.EnumerateArray())
                {
                    iteration.Relationship.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("requirementsSpecification"u8, out var requirementsSpecificationProperty))
            {
                foreach(var element in requirementsSpecificationProperty.EnumerateArray())
                {
                    iteration.RequirementsSpecification.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("ruleVerificationList"u8, out var ruleVerificationListProperty))
            {
                foreach(var element in ruleVerificationListProperty.EnumerateArray())
                {
                    iteration.RuleVerificationList.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("sharedDiagramStyle"u8, out var sharedDiagramStyleProperty))
            {
                foreach(var element in sharedDiagramStyleProperty.EnumerateArray())
                {
                    iteration.SharedDiagramStyle.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("sourceIterationIid"u8, out var sourceIterationIidProperty))
            {
                if(sourceIterationIidProperty.ValueKind == JsonValueKind.Null)
                {
                    iteration.SourceIterationIid = null;
                }
                else
                {
                    iteration.SourceIterationIid = sourceIterationIidProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("stakeholder"u8, out var stakeholderProperty))
            {
                foreach(var element in stakeholderProperty.EnumerateArray())
                {
                    iteration.Stakeholder.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("stakeholderValue"u8, out var stakeholderValueProperty))
            {
                foreach(var element in stakeholderValueProperty.EnumerateArray())
                {
                    iteration.StakeholderValue.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("stakeholderValueMap"u8, out var stakeholderValueMapProperty))
            {
                foreach(var element in stakeholderValueMapProperty.EnumerateArray())
                {
                    iteration.StakeholderValueMap.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the iteration {id} is null", iteration.Iid);
                }
                else
                {
                    iteration.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("topElement"u8, out var topElementProperty))
            {
                if(topElementProperty.ValueKind == JsonValueKind.Null)
                {
                    iteration.TopElement = null;
                }
                else
                {
                    iteration.TopElement = topElementProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("valueGroup"u8, out var valueGroupProperty))
            {
                foreach(var element in valueGroupProperty.EnumerateArray())
                {
                    iteration.ValueGroup.Add(element.GetGuid());
                }
            }
            return iteration;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
