// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewItemDiscrepancyResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ReviewItemDiscrepancyResolver"/> is to deserialize a JSON object to a <see cref="ReviewItemDiscrepancy"/>
    /// </summary>
    public static class ReviewItemDiscrepancyResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ReviewItemDiscrepancy"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ReviewItemDiscrepancy"/> to instantiate</returns>
        public static CDP4Common.DTO.ReviewItemDiscrepancy FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var reviewItemDiscrepancy = new CDP4Common.DTO.ReviewItemDiscrepancy(iid, revisionNumber);

            if (!jObject["approvedBy"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.ApprovedBy.AddRange(jObject["approvedBy"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["author"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["classification"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Classification = jObject["classification"].ToObject<AnnotationClassificationKind>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["discussion"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Discussion.AddRange(jObject["discussion"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["primaryAnnotatedThing"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.PrimaryAnnotatedThing = jObject["primaryAnnotatedThing"].ToObject<Guid?>();
            }

            if (!jObject["relatedThing"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.RelatedThing.AddRange(jObject["relatedThing"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["solution"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Solution.AddRange(jObject["solution"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["sourceAnnotation"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.SourceAnnotation.AddRange(jObject["sourceAnnotation"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["status"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Status = jObject["status"].ToObject<AnnotationStatusKind>();
            }

            if (!jObject["title"].IsNullOrEmpty())
            {
                reviewItemDiscrepancy.Title = jObject["title"].ToObject<string>();
            }

            return reviewItemDiscrepancy;
        }
    }
}
