// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModellingThingReferenceResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ModellingThingReferenceResolver"/> is to deserialize a JSON object to a <see cref="ModellingThingReference"/>
    /// </summary>
    public static class ModellingThingReferenceResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="ModellingThingReference"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="ModellingThingReference"/> to instantiate</returns>
        public static CDP4Common.DTO.ModellingThingReference FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var modellingThingReference = new CDP4Common.DTO.ModellingThingReference(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                modellingThingReference.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                modellingThingReference.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                modellingThingReference.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("referencedRevisionNumber", out var referencedRevisionNumberProperty))
            {
                modellingThingReference.ReferencedRevisionNumber = referencedRevisionNumberProperty.Deserialize<int>();
            }

            if (jObject.TryGetProperty("referencedThing", out var referencedThingProperty))
            {
                modellingThingReference.ReferencedThing = referencedThingProperty.Deserialize<Guid>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                modellingThingReference.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            return modellingThingReference;
        }
    }
}
