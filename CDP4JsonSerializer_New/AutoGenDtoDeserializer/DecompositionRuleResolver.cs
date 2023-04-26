// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecompositionRuleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DecompositionRuleResolver"/> is to deserialize a JSON object to a <see cref="DecompositionRule"/>
    /// </summary>
    public static class DecompositionRuleResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="DecompositionRule"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="DecompositionRule"/> to instantiate</returns>
        public static CDP4Common.DTO.DecompositionRule FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the PersonResolver cannot be used to deserialize this JsonElement");
            }

            var decompositionRule = new CDP4Common.DTO.DecompositionRule(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty))
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    decompositionRule.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("containedCategory"u8, out var containedCategoryProperty))
            {
                foreach(var element in containedCategoryProperty.EnumerateArray())
                {
                    decompositionRule.ContainedCategory.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("containingCategory"u8, out var containingCategoryProperty))
            {
                if(containingCategoryProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale containingCategory property of the decompositionRule {id} is null", decompositionRule.Iid);
                }
                else
                {
                    decompositionRule.ContainingCategory = containingCategoryProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty))
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    decompositionRule.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty))
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    decompositionRule.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty))
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    decompositionRule.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty))
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    decompositionRule.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isDeprecated property of the decompositionRule {id} is null", decompositionRule.Iid);
                }
                else
                {
                    decompositionRule.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("maxContained"u8, out var maxContainedProperty))
            {
                if(maxContainedProperty.ValueKind == JsonValueKind.Null)
                {
                    decompositionRule.MaxContained = null;
                }
                else
                {
                    decompositionRule.MaxContained = maxContainedProperty.GetInt32();
                }
            }

            if (jsonElement.TryGetProperty("minContained"u8, out var minContainedProperty))
            {
                if(minContainedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale minContained property of the decompositionRule {id} is null", decompositionRule.Iid);
                }
                else
                {
                    decompositionRule.MinContained = minContainedProperty.GetInt32();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the decompositionRule {id} is null", decompositionRule.Iid);
                }
                else
                {
                    decompositionRule.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the decompositionRule {id} is null", decompositionRule.Iid);
                }
                else
                {
                    decompositionRule.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the decompositionRule {id} is null", decompositionRule.Iid);
                }
                else
                {
                    decompositionRule.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the decompositionRule {id} is null", decompositionRule.Iid);
                }
                else
                {
                    decompositionRule.ThingPreference = thingPreferenceProperty.GetString();
                }
            }
            return decompositionRule;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
