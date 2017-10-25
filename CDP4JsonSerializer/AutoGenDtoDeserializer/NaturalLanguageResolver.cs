// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NaturalLanguageResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NaturalLanguageResolver"/> is to deserialize a JSON object to a <see cref="NaturalLanguage"/>
    /// </summary>
    public static class NaturalLanguageResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="NaturalLanguage"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="NaturalLanguage"/> to instantiate</returns>
        public static CDP4Common.DTO.NaturalLanguage FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var naturalLanguage = new CDP4Common.DTO.NaturalLanguage(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                naturalLanguage.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                naturalLanguage.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                naturalLanguage.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                naturalLanguage.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                naturalLanguage.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["nativeName"].IsNullOrEmpty())
            {
                naturalLanguage.NativeName = jObject["nativeName"].ToObject<string>();
            }

            return naturalLanguage;
        }
    }
}
