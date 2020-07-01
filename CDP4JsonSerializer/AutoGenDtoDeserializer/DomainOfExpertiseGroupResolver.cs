// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainOfExpertiseGroupResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DomainOfExpertiseGroupResolver"/> is to deserialize a JSON object to a <see cref="DomainOfExpertiseGroup"/>
    /// </summary>
    public static class DomainOfExpertiseGroupResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="DomainOfExpertiseGroup"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="DomainOfExpertiseGroup"/> to instantiate</returns>
        public static CDP4Common.DTO.DomainOfExpertiseGroup FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var domainOfExpertiseGroup = new CDP4Common.DTO.DomainOfExpertiseGroup(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["domain"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.Domain.AddRange(jObject["domain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                domainOfExpertiseGroup.ShortName = jObject["shortName"].ToObject<string>();
            }

            return domainOfExpertiseGroup;
        }
    }
}
