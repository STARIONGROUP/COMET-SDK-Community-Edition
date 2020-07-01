// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevisionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FileRevisionResolver"/> is to deserialize a JSON object to a <see cref="FileRevision"/>
    /// </summary>
    public static class FileRevisionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="FileRevision"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="FileRevision"/> to instantiate</returns>
        public static CDP4Common.DTO.FileRevision FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var fileRevision = new CDP4Common.DTO.FileRevision(iid, revisionNumber);

            if (!jObject["containingFolder"].IsNullOrEmpty())
            {
                fileRevision.ContainingFolder = jObject["containingFolder"].ToObject<Guid?>();
            }

            if (!jObject["contentHash"].IsNullOrEmpty())
            {
                fileRevision.ContentHash = jObject["contentHash"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                fileRevision.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["creator"].IsNullOrEmpty())
            {
                fileRevision.Creator = jObject["creator"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                fileRevision.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                fileRevision.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fileType"].IsNullOrEmpty())
            {
                fileRevision.FileType.AddRange(jObject["fileType"].ToOrderedItemCollection());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                fileRevision.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                fileRevision.Name = jObject["name"].ToObject<string>();
            }

            return fileRevision;
        }
    }
}
