// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SectionResolver"/> is to deserialize a JSON object to a <see cref="Section"/>
    /// </summary>
    public static class SectionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Section"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Section"/> to instantiate</returns>
        public static CDP4Common.DTO.Section FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var section = new CDP4Common.DTO.Section(iid, revisionNumber);

            if (!jObject["category"].IsNullOrEmpty())
            {
                section.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                section.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                section.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                section.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                section.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                section.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                section.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["page"].IsNullOrEmpty())
            {
                section.Page.AddRange(jObject["page"].ToOrderedItemCollection());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                section.ShortName = jObject["shortName"].ToObject<string>();
            }

            return section;
        }
    }
}
