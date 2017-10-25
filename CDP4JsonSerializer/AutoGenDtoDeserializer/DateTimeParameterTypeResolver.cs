// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeParameterTypeResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DateTimeParameterTypeResolver"/> is to deserialize a JSON object to a <see cref="DateTimeParameterType"/>
    /// </summary>
    public static class DateTimeParameterTypeResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="DateTimeParameterType"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="DateTimeParameterType"/> to instantiate</returns>
        public static CDP4Common.DTO.DateTimeParameterType FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var dateTimeParameterType = new CDP4Common.DTO.DateTimeParameterType(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                dateTimeParameterType.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                dateTimeParameterType.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                dateTimeParameterType.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                dateTimeParameterType.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                dateTimeParameterType.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                dateTimeParameterType.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                dateTimeParameterType.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                dateTimeParameterType.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                dateTimeParameterType.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                dateTimeParameterType.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["symbol"].IsNullOrEmpty())
            {
                dateTimeParameterType.Symbol = jObject["symbol"].ToObject<string>();
            }

            return dateTimeParameterType;
        }
    }
}
