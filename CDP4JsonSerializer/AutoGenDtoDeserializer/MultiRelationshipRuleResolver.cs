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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="MultiRelationshipRuleResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.MultiRelationshipRule"/>
    /// </summary>
    public static class MultiRelationshipRuleResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.MultiRelationshipRule"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.MultiRelationshipRule"/> to instantiate</returns>
        public static CDP4Common.DTO.MultiRelationshipRule FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the MultiRelationshipRuleResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the MultiRelationshipRuleResolver cannot be used to deserialize this JsonElement");
            }

            var multiRelationshipRule = new CDP4Common.DTO.MultiRelationshipRule(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    multiRelationshipRule.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    multiRelationshipRule.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    multiRelationshipRule.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    multiRelationshipRule.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    multiRelationshipRule.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isDeprecated property of the multiRelationshipRule {id} is null", multiRelationshipRule.Iid);
                }
                else
                {
                    multiRelationshipRule.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("maxRelated"u8, out var maxRelatedProperty))
            {
                if(maxRelatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale maxRelated property of the multiRelationshipRule {id} is null", multiRelationshipRule.Iid);
                }
                else
                {
                    multiRelationshipRule.MaxRelated = maxRelatedProperty.GetInt32();
                }
            }

            if (jsonElement.TryGetProperty("minRelated"u8, out var minRelatedProperty))
            {
                if(minRelatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale minRelated property of the multiRelationshipRule {id} is null", multiRelationshipRule.Iid);
                }
                else
                {
                    multiRelationshipRule.MinRelated = minRelatedProperty.GetInt32();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the multiRelationshipRule {id} is null", multiRelationshipRule.Iid);
                }
                else
                {
                    multiRelationshipRule.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the multiRelationshipRule {id} is null", multiRelationshipRule.Iid);
                }
                else
                {
                    multiRelationshipRule.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("relatedCategory"u8, out var relatedCategoryProperty) && relatedCategoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in relatedCategoryProperty.EnumerateArray())
                {
                    multiRelationshipRule.RelatedCategory.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("relationshipCategory"u8, out var relationshipCategoryProperty))
            {
                if(relationshipCategoryProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale relationshipCategory property of the multiRelationshipRule {id} is null", multiRelationshipRule.Iid);
                }
                else
                {
                    multiRelationshipRule.RelationshipCategory = relationshipCategoryProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the multiRelationshipRule {id} is null", multiRelationshipRule.Iid);
                }
                else
                {
                    multiRelationshipRule.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the multiRelationshipRule {id} is null", multiRelationshipRule.Iid);
                }
                else
                {
                    multiRelationshipRule.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return multiRelationshipRule;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
