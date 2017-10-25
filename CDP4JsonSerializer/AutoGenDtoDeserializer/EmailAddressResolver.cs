// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddressResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EmailAddressResolver"/> is to deserialize a JSON object to a <see cref="EmailAddress"/>
    /// </summary>
    public static class EmailAddressResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="EmailAddress"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="EmailAddress"/> to instantiate</returns>
        public static CDP4Common.DTO.EmailAddress FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var emailAddress = new CDP4Common.DTO.EmailAddress(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                emailAddress.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                emailAddress.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                emailAddress.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                emailAddress.Value = jObject["value"].ToObject<string>();
            }

            if (!jObject["vcardType"].IsNullOrEmpty())
            {
                emailAddress.VcardType = jObject["vcardType"].ToObject<VcardEmailAddressKind>();
            }

            return emailAddress;
        }
    }
}
