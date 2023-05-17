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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="ReferenceSourceResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ReferenceSource"/>
    /// </summary>
    public static class ReferenceSourceResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ReferenceSource"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ReferenceSource"/> to instantiate</returns>
        public static CDP4Common.DTO.ReferenceSource FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ReferenceSourceResolver cannot be used to deserialize this JsonElement");
            }

            if (!jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                throw new DeSerializationException("the mandatory revisionNumber property is not available, the ReferenceSourceResolver cannot be used to deserialize this JsonElement");
            }

            var referenceSource = new CDP4Common.DTO.ReferenceSource(iid.GetGuid(), revisionNumber.GetInt32());

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    referenceSource.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("author"u8, out var authorProperty))
            {
                if(authorProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale author property of the referenceSource {id} is null", referenceSource.Iid);
                }
                else
                {
                    referenceSource.Author = authorProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    referenceSource.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    referenceSource.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    referenceSource.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    referenceSource.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    referenceSource.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("isDeprecated"u8, out var isDeprecatedProperty))
            {
                if(isDeprecatedProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale isDeprecated property of the referenceSource {id} is null", referenceSource.Iid);
                }
                else
                {
                    referenceSource.IsDeprecated = isDeprecatedProperty.GetBoolean();
                }
            }

            if (jsonElement.TryGetProperty("language"u8, out var languageProperty))
            {
                if(languageProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale language property of the referenceSource {id} is null", referenceSource.Iid);
                }
                else
                {
                    referenceSource.Language = languageProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the referenceSource {id} is null", referenceSource.Iid);
                }
                else
                {
                    referenceSource.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the referenceSource {id} is null", referenceSource.Iid);
                }
                else
                {
                    referenceSource.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("publicationYear"u8, out var publicationYearProperty))
            {
                if(publicationYearProperty.ValueKind == JsonValueKind.Null)
                {
                    referenceSource.PublicationYear = null;
                }
                else
                {
                    referenceSource.PublicationYear = publicationYearProperty.GetInt32();
                }
            }

            if (jsonElement.TryGetProperty("publishedIn"u8, out var publishedInProperty))
            {
                if(publishedInProperty.ValueKind == JsonValueKind.Null)
                {
                    referenceSource.PublishedIn = null;
                }
                else
                {
                    referenceSource.PublishedIn = publishedInProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("publisher"u8, out var publisherProperty))
            {
                if(publisherProperty.ValueKind == JsonValueKind.Null)
                {
                    referenceSource.Publisher = null;
                }
                else
                {
                    referenceSource.Publisher = publisherProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the referenceSource {id} is null", referenceSource.Iid);
                }
                else
                {
                    referenceSource.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the referenceSource {id} is null", referenceSource.Iid);
                }
                else
                {
                    referenceSource.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("versionDate"u8, out var versionDateProperty))
            {
                if(versionDateProperty.ValueKind == JsonValueKind.Null)
                {
                    referenceSource.VersionDate = null;
                }
                else
                {
                    referenceSource.VersionDate = versionDateProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("versionIdentifier"u8, out var versionIdentifierProperty))
            {
                if(versionIdentifierProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale versionIdentifier property of the referenceSource {id} is null", referenceSource.Iid);
                }
                else
                {
                    referenceSource.VersionIdentifier = versionIdentifierProperty.GetString();
                }
            }

            return referenceSource;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
