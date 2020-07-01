// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModel"/>
    /// </summary>
    public static class EngineeringModelResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="EngineeringModel"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModel"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModel FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var engineeringModel = new CDP4Common.DTO.EngineeringModel(iid, revisionNumber);

            if (!jObject["book"].IsNullOrEmpty())
            {
                engineeringModel.Book.AddRange(jObject["book"].ToOrderedItemCollection());
            }

            if (!jObject["commonFileStore"].IsNullOrEmpty())
            {
                engineeringModel.CommonFileStore.AddRange(jObject["commonFileStore"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["engineeringModelSetup"].IsNullOrEmpty())
            {
                engineeringModel.EngineeringModelSetup = jObject["engineeringModelSetup"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                engineeringModel.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                engineeringModel.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["genericNote"].IsNullOrEmpty())
            {
                engineeringModel.GenericNote.AddRange(jObject["genericNote"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["iteration"].IsNullOrEmpty())
            {
                engineeringModel.Iteration.AddRange(jObject["iteration"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["lastModifiedOn"].IsNullOrEmpty())
            {
                engineeringModel.LastModifiedOn = jObject["lastModifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["logEntry"].IsNullOrEmpty())
            {
                engineeringModel.LogEntry.AddRange(jObject["logEntry"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modellingAnnotation"].IsNullOrEmpty())
            {
                engineeringModel.ModellingAnnotation.AddRange(jObject["modellingAnnotation"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                engineeringModel.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            return engineeringModel;
        }
    }
}
