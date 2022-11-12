// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelReferenceDataLibraryResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
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
    /// The purpose of the <see cref="ModelReferenceDataLibraryResolver"/> is to deserialize a JSON object to a <see cref="ModelReferenceDataLibrary"/>
    /// </summary>
    public static class ModelReferenceDataLibraryResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ModelReferenceDataLibrary"/> to instantiate</returns>
        public static CDP4Common.DTO.ModelReferenceDataLibrary FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var modelReferenceDataLibrary = new CDP4Common.DTO.ModelReferenceDataLibrary(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["baseQuantityKind"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.BaseQuantityKind.AddRange(jObject["baseQuantityKind"].ToOrderedItemCollection());
            }

            if (!jObject["baseUnit"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.BaseUnit.AddRange(jObject["baseUnit"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["constant"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.Constant.AddRange(jObject["constant"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definedCategory"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.DefinedCategory.AddRange(jObject["definedCategory"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fileType"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.FileType.AddRange(jObject["fileType"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["glossary"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.Glossary.AddRange(jObject["glossary"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.ParameterType.AddRange(jObject["parameterType"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["referenceSource"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.ReferenceSource.AddRange(jObject["referenceSource"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["requiredRdl"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.RequiredRdl = jObject["requiredRdl"].ToObject<Guid?>();
            }

            if (!jObject["rule"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.Rule.AddRange(jObject["rule"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.Scale.AddRange(jObject["scale"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["unit"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.Unit.AddRange(jObject["unit"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["unitPrefix"].IsNullOrEmpty())
            {
                modelReferenceDataLibrary.UnitPrefix.AddRange(jObject["unitPrefix"].ToObject<IEnumerable<Guid>>());
            }

            return modelReferenceDataLibrary;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
