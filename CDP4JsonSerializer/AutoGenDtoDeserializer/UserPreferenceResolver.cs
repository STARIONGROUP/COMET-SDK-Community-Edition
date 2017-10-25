// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPreferenceResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="UserPreferenceResolver"/> is to deserialize a JSON object to a <see cref="UserPreference"/>
    /// </summary>
    public static class UserPreferenceResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="UserPreference"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="UserPreference"/> to instantiate</returns>
        public static CDP4Common.DTO.UserPreference FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var userPreference = new CDP4Common.DTO.UserPreference(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                userPreference.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                userPreference.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                userPreference.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                userPreference.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                userPreference.Value = jObject["value"].ToObject<string>();
            }

            return userPreference;
        }
    }
}
