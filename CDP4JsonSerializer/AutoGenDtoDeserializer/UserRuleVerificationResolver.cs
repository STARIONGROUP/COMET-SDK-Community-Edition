// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRuleVerificationResolver.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="UserRuleVerificationResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.UserRuleVerification"/>
    /// </summary>
    public static class UserRuleVerificationResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.UserRuleVerification"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.UserRuleVerification"/> to instantiate</returns>
        public static CDP4Common.DTO.UserRuleVerification FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the UserRuleVerificationResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var userRuleVerification = new CDP4Common.DTO.UserRuleVerification(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    userRuleVerification.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    userRuleVerification.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("executedOn"u8, out var executedOnProperty))
            {
                if(executedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    userRuleVerification.ExecutedOn = null;
                }
                else
                {
                    userRuleVerification.ExecutedOn = executedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("isActive"u8, out var isActiveProperty))
            {
                if(isActiveProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale isActive property of the userRuleVerification {id} is null", userRuleVerification.Iid);
                }
                else
                {
                    userRuleVerification.IsActive = isActiveProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the userRuleVerification {id} is null", userRuleVerification.Iid);
                }
                else
                {
                    userRuleVerification.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("rule"u8, out var ruleProperty))
            {
                if(ruleProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale rule property of the userRuleVerification {id} is null", userRuleVerification.Iid);
                }
                else
                {
                    userRuleVerification.Rule = ruleProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("status"u8, out var statusProperty))
            {
                if(statusProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale status property of the userRuleVerification {id} is null", userRuleVerification.Iid);
                }
                else
                {
                    userRuleVerification.Status = RuleVerificationStatusKindDeserializer.Deserialize(statusProperty);
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the userRuleVerification {id} is null", userRuleVerification.Iid);
                }
                else
                {
                    userRuleVerification.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return userRuleVerification;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
