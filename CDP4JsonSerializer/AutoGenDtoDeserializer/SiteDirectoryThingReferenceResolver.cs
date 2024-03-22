// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryThingReferenceResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryThingReferenceResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.SiteDirectoryThingReference"/>
    /// </summary>
    public static class SiteDirectoryThingReferenceResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.SiteDirectoryThingReference"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.SiteDirectoryThingReference"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteDirectoryThingReference FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the SiteDirectoryThingReferenceResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var siteDirectoryThingReference = new CDP4Common.DTO.SiteDirectoryThingReference(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    siteDirectoryThingReference.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    siteDirectoryThingReference.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the siteDirectoryThingReference {id} is null", siteDirectoryThingReference.Iid);
                }
                else
                {
                    siteDirectoryThingReference.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("referencedRevisionNumber"u8, out var referencedRevisionNumberProperty))
            {
                if(referencedRevisionNumberProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale referencedRevisionNumber property of the siteDirectoryThingReference {id} is null", siteDirectoryThingReference.Iid);
                }
                else
                {
                    siteDirectoryThingReference.ReferencedRevisionNumber = referencedRevisionNumberProperty.GetInt32();
                }
            }

            if (jsonElement.TryGetProperty("referencedThing"u8, out var referencedThingProperty))
            {
                if(referencedThingProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale referencedThing property of the siteDirectoryThingReference {id} is null", siteDirectoryThingReference.Iid);
                }
                else
                {
                    siteDirectoryThingReference.ReferencedThing = referencedThingProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the siteDirectoryThingReference {id} is null", siteDirectoryThingReference.Iid);
                }
                else
                {
                    siteDirectoryThingReference.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return siteDirectoryThingReference;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
