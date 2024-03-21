// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationshipResolver.cs" company="RHEA System S.A.">
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
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="MultiRelationshipResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.MultiRelationship"/>
    /// </summary>
    public static class MultiRelationshipResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.MultiRelationship"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.MultiRelationship"/> to instantiate</returns>
        public static CDP4Common.DTO.MultiRelationship FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the MultiRelationshipResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var multiRelationship = new CDP4Common.DTO.MultiRelationship(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    multiRelationship.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    multiRelationship.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    multiRelationship.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the multiRelationship {id} is null", multiRelationship.Iid);
                }
                else
                {
                    multiRelationship.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the multiRelationship {id} is null", multiRelationship.Iid);
                }
                else
                {
                    multiRelationship.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the multiRelationship {id} is null", multiRelationship.Iid);
                }
                else
                {
                    multiRelationship.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("parameterValue"u8, out var parameterValueProperty) && parameterValueProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in parameterValueProperty.EnumerateArray())
                {
                    multiRelationship.ParameterValue.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("relatedThing"u8, out var relatedThingProperty) && relatedThingProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in relatedThingProperty.EnumerateArray())
                {
                    multiRelationship.RelatedThing.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the multiRelationship {id} is null", multiRelationship.Iid);
                }
                else
                {
                    multiRelationship.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return multiRelationship;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
