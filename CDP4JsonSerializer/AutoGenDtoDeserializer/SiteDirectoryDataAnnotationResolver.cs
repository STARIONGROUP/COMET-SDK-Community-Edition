// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryDataAnnotationResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryDataAnnotationResolver"/> is to deserialize a JSON object to a <see cref="SiteDirectoryDataAnnotation"/>
    /// </summary>
    public static class SiteDirectoryDataAnnotationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SiteDirectoryDataAnnotation"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SiteDirectoryDataAnnotation"/> to instantiate</returns>
        public static CDP4Common.DTO.SiteDirectoryDataAnnotation FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var siteDirectoryDataAnnotation = new CDP4Common.DTO.SiteDirectoryDataAnnotation(iid, revisionNumber);

            if (!jObject["author"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["discussion"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.Discussion.AddRange(jObject["discussion"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["primaryAnnotatedThing"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.PrimaryAnnotatedThing = jObject["primaryAnnotatedThing"].ToObject<Guid>();
            }

            if (!jObject["relatedThing"].IsNullOrEmpty())
            {
                siteDirectoryDataAnnotation.RelatedThing.AddRange(jObject["relatedThing"].ToObject<IEnumerable<Guid>>());
            }

            return siteDirectoryDataAnnotation;
        }
    }
}
