// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CategoryResolver"/> is to deserialize a JSON object to a <see cref="Category"/>
    /// </summary>
    public static class CategoryResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Category"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Category"/> to instantiate</returns>
        public static CDP4Common.DTO.Category FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var category = new CDP4Common.DTO.Category(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                category.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                category.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                category.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                category.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                category.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isAbstract"].IsNullOrEmpty())
            {
                category.IsAbstract = jObject["isAbstract"].ToObject<bool>();
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                category.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                category.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                category.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["permissibleClass"].IsNullOrEmpty())
            {
                category.PermissibleClass.AddRange(jObject["permissibleClass"].ToObject<IEnumerable<ClassKind>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                category.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["superCategory"].IsNullOrEmpty())
            {
                category.SuperCategory.AddRange(jObject["superCategory"].ToObject<IEnumerable<Guid>>());
            }

            return category;
        }
    }
}
