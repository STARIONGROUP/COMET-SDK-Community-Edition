// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApprovalResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ApprovalResolver"/> is to deserialize a JSON object to a <see cref="Approval"/>
    /// </summary>
    public static class ApprovalResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Approval"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Approval"/> to instantiate</returns>
        public static CDP4Common.DTO.Approval FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var approval = new CDP4Common.DTO.Approval(iid, revisionNumber);

            if (!jObject["author"].IsNullOrEmpty())
            {
                approval.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["classification"].IsNullOrEmpty())
            {
                approval.Classification = jObject["classification"].ToObject<AnnotationApprovalKind>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                approval.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                approval.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                approval.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                approval.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                approval.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                approval.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                approval.Owner = jObject["owner"].ToObject<Guid>();
            }

            return approval;
        }
    }
}
