// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationSetupResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IterationSetupResolver"/> is to deserialize a JSON object to a <see cref="IterationSetup"/>
    /// </summary>
    public static class IterationSetupResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="IterationSetup"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="IterationSetup"/> to instantiate</returns>
        public static CDP4Common.DTO.IterationSetup FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var iterationSetup = new CDP4Common.DTO.IterationSetup(iid, revisionNumber);

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                iterationSetup.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["description"].IsNullOrEmpty())
            {
                iterationSetup.Description = jObject["description"].ToObject<string>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                iterationSetup.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                iterationSetup.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["frozenOn"].IsNullOrEmpty())
            {
                iterationSetup.FrozenOn = jObject["frozenOn"].ToObject<DateTime?>();
            }

            if (!jObject["isDeleted"].IsNullOrEmpty())
            {
                iterationSetup.IsDeleted = jObject["isDeleted"].ToObject<bool>();
            }

            if (!jObject["iterationIid"].IsNullOrEmpty())
            {
                iterationSetup.IterationIid = jObject["iterationIid"].ToObject<Guid>();
            }

            if (!jObject["iterationNumber"].IsNullOrEmpty())
            {
                iterationSetup.IterationNumber = jObject["iterationNumber"].ToObject<int>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                iterationSetup.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["sourceIterationSetup"].IsNullOrEmpty())
            {
                iterationSetup.SourceIterationSetup = jObject["sourceIterationSetup"].ToObject<Guid?>();
            }

            return iterationSetup;
        }
    }
}
