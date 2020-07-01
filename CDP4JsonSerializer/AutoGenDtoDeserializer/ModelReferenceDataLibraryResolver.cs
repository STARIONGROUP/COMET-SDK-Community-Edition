// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelReferenceDataLibraryResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Resolver class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    #pragma warning disable S1128
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;
    #pragma warning restore S1128

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
