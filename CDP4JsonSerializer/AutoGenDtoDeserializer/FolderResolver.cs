// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Resolver class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
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

    /// <summary>
    /// The purpose of the <see cref="FolderResolver"/> is to deserialize a JSON object to a <see cref="Folder"/>
    /// </summary>
    public static class FolderResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Folder"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Folder"/> to instantiate</returns>
        public static CDP4Common.DTO.Folder FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var folder = new CDP4Common.DTO.Folder(iid, revisionNumber);

            if (!jObject["containingFolder"].IsNullOrEmpty())
            {
                folder.ContainingFolder = jObject["containingFolder"].ToObject<Guid?>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                folder.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["creator"].IsNullOrEmpty())
            {
                folder.Creator = jObject["creator"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                folder.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                folder.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                folder.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                folder.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                folder.Owner = jObject["owner"].ToObject<Guid>();
            }

            return folder;
        }
    }
}
