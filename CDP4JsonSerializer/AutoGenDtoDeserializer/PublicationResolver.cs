// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PublicationResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PublicationResolver"/> is to deserialize a JSON object to a <see cref="Publication"/>
    /// </summary>
    public static class PublicationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Publication"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Publication"/> to instantiate</returns>
        public static CDP4Common.DTO.Publication FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var publication = new CDP4Common.DTO.Publication(iid, revisionNumber);

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                publication.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["domain"].IsNullOrEmpty())
            {
                publication.Domain.AddRange(jObject["domain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                publication.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                publication.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                publication.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["publishedParameter"].IsNullOrEmpty())
            {
                publication.PublishedParameter.AddRange(jObject["publishedParameter"].ToObject<IEnumerable<Guid>>());
            }

            return publication;
        }
    }
}
