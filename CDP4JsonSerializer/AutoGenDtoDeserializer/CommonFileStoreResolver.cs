// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonFileStoreResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CommonFileStoreResolver"/> is to deserialize a JSON object to a <see cref="CommonFileStore"/>
    /// </summary>
    public static class CommonFileStoreResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="CommonFileStore"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="CommonFileStore"/> to instantiate</returns>
        public static CDP4Common.DTO.CommonFileStore FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var commonFileStore = new CDP4Common.DTO.CommonFileStore(iid, revisionNumber);

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                commonFileStore.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                commonFileStore.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                commonFileStore.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["file"].IsNullOrEmpty())
            {
                commonFileStore.File.AddRange(jObject["file"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["folder"].IsNullOrEmpty())
            {
                commonFileStore.Folder.AddRange(jObject["folder"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                commonFileStore.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                commonFileStore.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                commonFileStore.Owner = jObject["owner"].ToObject<Guid>();
            }

            return commonFileStore;
        }
    }
}
