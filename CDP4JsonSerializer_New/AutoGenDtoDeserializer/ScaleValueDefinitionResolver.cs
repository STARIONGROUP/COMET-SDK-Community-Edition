// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaleValueDefinitionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ScaleValueDefinitionResolver"/> is to deserialize a JSON object to a <see cref="ScaleValueDefinition"/>
    /// </summary>
    public static class ScaleValueDefinitionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="ScaleValueDefinition"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="ScaleValueDefinition"/> to instantiate</returns>
        public static CDP4Common.DTO.ScaleValueDefinition FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var scaleValueDefinition = new CDP4Common.DTO.ScaleValueDefinition(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                scaleValueDefinition.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                scaleValueDefinition.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                scaleValueDefinition.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                scaleValueDefinition.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                scaleValueDefinition.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                scaleValueDefinition.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                scaleValueDefinition.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                scaleValueDefinition.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                scaleValueDefinition.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("value", out var valueProperty))
            {
                scaleValueDefinition.Value = valueProperty.Deserialize<string>();
            }

            return scaleValueDefinition;
        }
    }
}
