// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Text.Json;

    using CDP4Common.Types;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="IterationResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.Iteration"/>
    /// </summary>
    public static class IterationResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.Iteration"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.Iteration"/> to instantiate</returns>
        public static CDP4Common.DTO.Iteration FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the IterationResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var iteration = new CDP4Common.DTO.Iteration(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("actualFiniteStateList"u8, out var actualFiniteStateListProperty) && actualFiniteStateListProperty.ValueKind != JsonValueKind.Null)
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

            if (jsonElement.TryGetProperty("diagramCanvas"u8, out var diagramCanvasProperty) && diagramCanvasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in diagramCanvasProperty.EnumerateArray())
                {
                    iteration.DiagramCanvas.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("domainFileStore"u8, out var domainFileStoreProperty) && domainFileStoreProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in domainFileStoreProperty.EnumerateArray())
                {
                    iteration.DomainFileStore.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("element"u8, out var elementProperty) && elementProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in elementProperty.EnumerateArray())
                {
                    iteration.Element.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    iteration.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    iteration.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("externalIdentifierMap"u8, out var externalIdentifierMapProperty) && externalIdentifierMapProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in externalIdentifierMapProperty.EnumerateArray())
                {
                    iteration.ExternalIdentifierMap.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("goal"u8, out var goalProperty) && goalProperty.ValueKind != JsonValueKind.Null)
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
                    Logger.Trace("The non-nullabale iterationSetup property of the iteration {id} is null", iteration.Iid);
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
                    Logger.Trace("The non-nullabale modifiedOn property of the iteration {id} is null", iteration.Iid);
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

            if (jsonElement.TryGetProperty("possibleFiniteStateList"u8, out var possibleFiniteStateListProperty) && possibleFiniteStateListProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in possibleFiniteStateListProperty.EnumerateArray())
                {
                    iteration.PossibleFiniteStateList.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("publication"u8, out var publicationProperty) && publicationProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in publicationProperty.EnumerateArray())
                {
                    iteration.Publication.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("relationship"u8, out var relationshipProperty) && relationshipProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in relationshipProperty.EnumerateArray())
                {
                    iteration.Relationship.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("requirementsSpecification"u8, out var requirementsSpecificationProperty) && requirementsSpecificationProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in requirementsSpecificationProperty.EnumerateArray())
                {
                    iteration.RequirementsSpecification.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("ruleVerificationList"u8, out var ruleVerificationListProperty) && ruleVerificationListProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in ruleVerificationListProperty.EnumerateArray())
                {
                    iteration.RuleVerificationList.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("sharedDiagramStyle"u8, out var sharedDiagramStyleProperty) && sharedDiagramStyleProperty.ValueKind != JsonValueKind.Null)
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

            if (jsonElement.TryGetProperty("stakeholder"u8, out var stakeholderProperty) && stakeholderProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in stakeholderProperty.EnumerateArray())
                {
                    iteration.Stakeholder.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("stakeholderValue"u8, out var stakeholderValueProperty) && stakeholderValueProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in stakeholderValueProperty.EnumerateArray())
                {
                    iteration.StakeholderValue.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("stakeholderValueMap"u8, out var stakeholderValueMapProperty) && stakeholderValueMapProperty.ValueKind != JsonValueKind.Null)
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
                    Logger.Trace("The non-nullabale thingPreference property of the iteration {id} is null", iteration.Iid);
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

            if (jsonElement.TryGetProperty("valueGroup"u8, out var valueGroupProperty) && valueGroupProperty.ValueKind != JsonValueKind.Null)
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
