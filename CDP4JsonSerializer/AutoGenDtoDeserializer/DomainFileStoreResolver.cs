// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainFileStoreResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DomainFileStoreResolver"/> is to deserialize a JSON object to a <see cref="DomainFileStore"/>
    /// </summary>
    public static class DomainFileStoreResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="DomainFileStore"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="DomainFileStore"/> to instantiate</returns>
        public static CDP4Common.DTO.DomainFileStore FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var domainFileStore = new CDP4Common.DTO.DomainFileStore(iid, revisionNumber);

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                domainFileStore.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                domainFileStore.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                domainFileStore.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["file"].IsNullOrEmpty())
            {
                domainFileStore.File.AddRange(jObject["file"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["folder"].IsNullOrEmpty())
            {
                domainFileStore.Folder.AddRange(jObject["folder"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isHidden"].IsNullOrEmpty())
            {
                domainFileStore.IsHidden = jObject["isHidden"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                domainFileStore.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                domainFileStore.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                domainFileStore.Owner = jObject["owner"].ToObject<Guid>();
            }

            return domainFileStore;
        }
    }
}
