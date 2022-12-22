// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteReferenceDataLibraryResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteReferenceDataLibraryResolver"/> is to deserialize a JSON object to a <see cref="SiteReferenceDataLibrary"/>
    /// </summary>
    public static class SiteReferenceDataLibraryResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="SiteReferenceDataLibrary"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="SiteReferenceDataLibrary"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteReferenceDataLibrary FromJsonObject(JsonElement jObject)
        {
            jObject.TryGetProperty("iid", out var iid);
            jObject.TryGetProperty("revisionNumber", out var revisionNumber);
            var siteReferenceDataLibrary = new CDP4Common.DTO.SiteReferenceDataLibrary(iid.GetGuid(), revisionNumber.GetInt32());

            if (jObject.TryGetProperty("alias", out var aliasProperty))
            {
                siteReferenceDataLibrary.Alias.AddRange(aliasProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("baseQuantityKind", out var baseQuantityKindProperty))
            {
                foreach(var arrayItem in baseQuantityKindProperty.EnumerateArray())
                {
                    var arrayItemValue = arrayItem.Deserialize<OrderedItem>();
                    if (arrayItemValue != null)
                    {
                        siteReferenceDataLibrary.BaseQuantityKind.Add(arrayItemValue);
                    }
                }
            }

            
            if (jObject.TryGetProperty("baseUnit", out var baseUnitProperty))
            {
                siteReferenceDataLibrary.BaseUnit.AddRange(baseUnitProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("constant", out var constantProperty))
            {
                siteReferenceDataLibrary.Constant.AddRange(constantProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("definedCategory", out var definedCategoryProperty))
            {
                siteReferenceDataLibrary.DefinedCategory.AddRange(definedCategoryProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("definition", out var definitionProperty))
            {
                siteReferenceDataLibrary.Definition.AddRange(definitionProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedDomain", out var excludedDomainProperty))
            {
                siteReferenceDataLibrary.ExcludedDomain.AddRange(excludedDomainProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("excludedPerson", out var excludedPersonProperty))
            {
                siteReferenceDataLibrary.ExcludedPerson.AddRange(excludedPersonProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("fileType", out var fileTypeProperty))
            {
                siteReferenceDataLibrary.FileType.AddRange(fileTypeProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("glossary", out var glossaryProperty))
            {
                siteReferenceDataLibrary.Glossary.AddRange(glossaryProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("hyperLink", out var hyperLinkProperty))
            {
                siteReferenceDataLibrary.HyperLink.AddRange(hyperLinkProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("isDeprecated", out var isDeprecatedProperty))
            {
                siteReferenceDataLibrary.IsDeprecated = isDeprecatedProperty.Deserialize<bool>();
            }

            if (jObject.TryGetProperty("modifiedOn", out var modifiedOnProperty))
            {
                siteReferenceDataLibrary.ModifiedOn = modifiedOnProperty.Deserialize<DateTime>();
            }

            if (jObject.TryGetProperty("name", out var nameProperty))
            {
                siteReferenceDataLibrary.Name = nameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("parameterType", out var parameterTypeProperty))
            {
                siteReferenceDataLibrary.ParameterType.AddRange(parameterTypeProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("referenceSource", out var referenceSourceProperty))
            {
                siteReferenceDataLibrary.ReferenceSource.AddRange(referenceSourceProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("requiredRdl", out var requiredRdlProperty))
            {
                siteReferenceDataLibrary.RequiredRdl = requiredRdlProperty.Deserialize<Guid?>();
            }

            if (jObject.TryGetProperty("rule", out var ruleProperty))
            {
                siteReferenceDataLibrary.Rule.AddRange(ruleProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("scale", out var scaleProperty))
            {
                siteReferenceDataLibrary.Scale.AddRange(scaleProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("shortName", out var shortNameProperty))
            {
                siteReferenceDataLibrary.ShortName = shortNameProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("thingPreference", out var thingPreferenceProperty))
            {
                siteReferenceDataLibrary.ThingPreference = thingPreferenceProperty.Deserialize<string>();
            }

            if (jObject.TryGetProperty("unit", out var unitProperty))
            {
                siteReferenceDataLibrary.Unit.AddRange(unitProperty.Deserialize<IEnumerable<Guid>>());
            }

            if (jObject.TryGetProperty("unitPrefix", out var unitPrefixProperty))
            {
                siteReferenceDataLibrary.UnitPrefix.AddRange(unitPrefixProperty.Deserialize<IEnumerable<Guid>>());
            }

            return siteReferenceDataLibrary;
        }
    }
}
