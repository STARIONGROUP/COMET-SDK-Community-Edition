// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationSetupResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IterationSetupResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.IterationSetup"/>
    /// </summary>
    public static class IterationSetupResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.IterationSetup"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.IterationSetup"/> to instantiate</returns>
        public static CDP4Common.DTO.IterationSetup FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the IterationSetupResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var iterationSetup = new CDP4Common.DTO.IterationSetup(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("createdOn"u8, out var createdOnProperty))
            {
                if(createdOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale createdOn property of the iterationSetup {id} is null", iterationSetup.Iid);
                }
                else
                {
                    iterationSetup.CreatedOn = createdOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("description"u8, out var descriptionProperty))
            {
                if(descriptionProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale description property of the iterationSetup {id} is null", iterationSetup.Iid);
                }
                else
                {
                    iterationSetup.Description = descriptionProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    iterationSetup.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    iterationSetup.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("frozenOn"u8, out var frozenOnProperty))
            {
                if(frozenOnProperty.ValueKind == JsonValueKind.Null)
                {
                    iterationSetup.FrozenOn = null;
                }
                else
                {
                    iterationSetup.FrozenOn = frozenOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("isDeleted"u8, out var isDeletedProperty))
            {
                if(isDeletedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale isDeleted property of the iterationSetup {id} is null", iterationSetup.Iid);
                }
                else
                {
                    iterationSetup.IsDeleted = isDeletedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("iterationIid"u8, out var iterationIidProperty))
            {
                if(iterationIidProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale iterationIid property of the iterationSetup {id} is null", iterationSetup.Iid);
                }
                else
                {
                    iterationSetup.IterationIid = iterationIidProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("iterationNumber"u8, out var iterationNumberProperty))
            {
                if(iterationNumberProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale iterationNumber property of the iterationSetup {id} is null", iterationSetup.Iid);
                }
                else
                {
                    iterationSetup.IterationNumber = iterationNumberProperty.GetInt32();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the iterationSetup {id} is null", iterationSetup.Iid);
                }
                else
                {
                    iterationSetup.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("sourceIterationSetup"u8, out var sourceIterationSetupProperty))
            {
                if(sourceIterationSetupProperty.ValueKind == JsonValueKind.Null)
                {
                    iterationSetup.SourceIterationSetup = null;
                }
                else
                {
                    iterationSetup.SourceIterationSetup = sourceIterationSetupProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the iterationSetup {id} is null", iterationSetup.Iid);
                }
                else
                {
                    iterationSetup.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return iterationSetup;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
