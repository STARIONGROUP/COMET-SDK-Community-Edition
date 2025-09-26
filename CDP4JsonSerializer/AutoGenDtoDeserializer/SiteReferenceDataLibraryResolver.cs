// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteReferenceDataLibraryResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="SiteReferenceDataLibraryResolver"/> is to deserialize a JSON object to a <see cref="SiteReferenceDataLibrary"/>
    /// </summary>
    public static class SiteReferenceDataLibraryResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SiteReferenceDataLibrary"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SiteReferenceDataLibrary"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteReferenceDataLibrary FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var siteReferenceDataLibrary = new CDP4Common.DTO.SiteReferenceDataLibrary(iid, revisionNumber);

            if (!jObject["actor"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Actor = jObject["actor"].ToObject<Guid?>();
            }

            if (!jObject["alias"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["baseQuantityKind"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.BaseQuantityKind.AddRange(jObject["baseQuantityKind"].ToOrderedItemCollection());
            }

            if (!jObject["baseUnit"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.BaseUnit.AddRange(jObject["baseUnit"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["constant"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Constant.AddRange(jObject["constant"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definedCategory"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.DefinedCategory.AddRange(jObject["definedCategory"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fileType"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.FileType.AddRange(jObject["fileType"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["glossary"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Glossary.AddRange(jObject["glossary"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.ParameterType.AddRange(jObject["parameterType"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["referenceSource"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.ReferenceSource.AddRange(jObject["referenceSource"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["requiredRdl"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.RequiredRdl = jObject["requiredRdl"].ToObject<Guid?>();
            }

            if (!jObject["rule"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Rule.AddRange(jObject["rule"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Scale.AddRange(jObject["scale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["unit"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.Unit.AddRange(jObject["unit"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["unitPrefix"].IsNullOrEmpty())
            {
                siteReferenceDataLibrary.UnitPrefix.AddRange(jObject["unitPrefix"].ToObject<IEnumerable<Guid>>());
            }

            return siteReferenceDataLibrary;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
