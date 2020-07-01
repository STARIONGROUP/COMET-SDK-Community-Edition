// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="FileResolver"/> is to deserialize a JSON object to a <see cref="File"/>
    /// </summary>
    public static class FileResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="File"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="File"/> to instantiate</returns>
        public static CDP4Common.DTO.File FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var file = new CDP4Common.DTO.File(iid, revisionNumber);

            if (!jObject["category"].IsNullOrEmpty())
            {
                file.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                file.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                file.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fileRevision"].IsNullOrEmpty())
            {
                file.FileRevision.AddRange(jObject["fileRevision"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["lockedBy"].IsNullOrEmpty())
            {
                file.LockedBy = jObject["lockedBy"].ToObject<Guid?>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                file.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                file.Owner = jObject["owner"].ToObject<Guid>();
            }

            return file;
        }
    }
}
