// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestForDeviationResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RequestForDeviationResolver"/> is to deserialize a JSON object to a <see cref="RequestForDeviation"/>
    /// </summary>
    public static class RequestForDeviationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="RequestForDeviation"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="RequestForDeviation"/> to instantiate</returns>
        public static CDP4Common.DTO.RequestForDeviation FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var requestForDeviation = new CDP4Common.DTO.RequestForDeviation(iid, revisionNumber);

            if (!jObject["approvedBy"].IsNullOrEmpty())
            {
                requestForDeviation.ApprovedBy.AddRange(jObject["approvedBy"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["author"].IsNullOrEmpty())
            {
                requestForDeviation.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                requestForDeviation.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["classification"].IsNullOrEmpty())
            {
                requestForDeviation.Classification = jObject["classification"].ToObject<AnnotationClassificationKind>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                requestForDeviation.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                requestForDeviation.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["discussion"].IsNullOrEmpty())
            {
                requestForDeviation.Discussion.AddRange(jObject["discussion"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                requestForDeviation.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                requestForDeviation.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                requestForDeviation.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                requestForDeviation.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                requestForDeviation.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["primaryAnnotatedThing"].IsNullOrEmpty())
            {
                requestForDeviation.PrimaryAnnotatedThing = jObject["primaryAnnotatedThing"].ToObject<Guid?>();
            }

            if (!jObject["relatedThing"].IsNullOrEmpty())
            {
                requestForDeviation.RelatedThing.AddRange(jObject["relatedThing"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                requestForDeviation.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["sourceAnnotation"].IsNullOrEmpty())
            {
                requestForDeviation.SourceAnnotation.AddRange(jObject["sourceAnnotation"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["status"].IsNullOrEmpty())
            {
                requestForDeviation.Status = jObject["status"].ToObject<AnnotationStatusKind>();
            }

            if (!jObject["title"].IsNullOrEmpty())
            {
                requestForDeviation.Title = jObject["title"].ToObject<string>();
            }

            return requestForDeviation;
        }
    }
}
