// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceSourceResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ReferenceSourceResolver"/> is to deserialize a JSON object to a <see cref="ReferenceSource"/>
    /// </summary>
    public static class ReferenceSourceResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="ReferenceSource"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="ReferenceSource"/> to instantiate</returns>
        public static CDP4Common.DTO.ReferenceSource FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var referenceSource = new CDP4Common.DTO.ReferenceSource(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                referenceSource.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("author", out var authorProperty))
            {
                referenceSource.Author = authorProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("category", out var categoryProperty))
            {
                referenceSource.Category.AddRange(categoryProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                referenceSource.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                referenceSource.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                referenceSource.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                referenceSource.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                referenceSource.IsDeprecated = isDeprecatedProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("language", out var languageProperty))
            {
                referenceSource.Language = languageProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                referenceSource.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                referenceSource.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("publicationYear", out var publicationYearProperty))
            {
                referenceSource.PublicationYear = publicationYearProperty.Deserialize<int?>();
            }

            if (jObject.TryGetProperty("publishedIn", out var publishedInProperty))
            {
                referenceSource.PublishedIn = publishedInProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("publisher", out var publisherProperty))
            {
                referenceSource.Publisher = publisherProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                referenceSource.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                referenceSource.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("versionDate", out var versionDateProperty))
            {
                referenceSource.VersionDate = versionDateProperty.Deserialize<DateTime?>();
            }

            if (jObject.TryGetProperty("versionIdentifier", out var versionIdentifierProperty))
            {
                referenceSource.VersionIdentifier = versionIdentifierProperty.Deserialize<string>();
            }

            return referenceSource;
        }
    }
}
