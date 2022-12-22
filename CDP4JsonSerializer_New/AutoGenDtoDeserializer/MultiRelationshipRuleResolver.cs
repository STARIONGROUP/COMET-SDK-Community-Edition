// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationshipRuleResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="MultiRelationshipRuleResolver"/> is to deserialize a JSON object to a <see cref="MultiRelationshipRule"/>
    /// </summary>
    public static class MultiRelationshipRuleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="MultiRelationshipRule"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="MultiRelationshipRule"/> to instantiate</returns>
        public static CDP4Common.DTO.MultiRelationshipRule FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var multiRelationshipRule = new CDP4Common.DTO.MultiRelationshipRule(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                multiRelationshipRule.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                multiRelationshipRule.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                multiRelationshipRule.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                multiRelationshipRule.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                multiRelationshipRule.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                multiRelationshipRule.IsDeprecated = isDeprecatedProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("maxRelated", out var maxRelatedProperty))
            {
                multiRelationshipRule.MaxRelated = maxRelatedProperty.Deserialize<int>();
            }

            if (jObject.TryGetProperty("minRelated", out var minRelatedProperty))
            {
                multiRelationshipRule.MinRelated = minRelatedProperty.Deserialize<int>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                multiRelationshipRule.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                multiRelationshipRule.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("relatedCategory", out var relatedCategoryProperty))
            {
                multiRelationshipRule.RelatedCategory.AddRange(relatedCategoryProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("relationshipCategory", out var relationshipCategoryProperty))
            {
                multiRelationshipRule.RelationshipCategory = relationshipCategoryProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                multiRelationshipRule.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                multiRelationshipRule.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            return multiRelationshipRule;
        }
    }
}
