// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TelephoneNumberResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="TelephoneNumberResolver"/> is to deserialize a JSON object to a <see cref="TelephoneNumber"/>
    /// </summary>
    public static class TelephoneNumberResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="TelephoneNumber"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="TelephoneNumber"/> to instantiate</returns>
        public static CDP4Common.DTO.TelephoneNumber FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var telephoneNumber = new CDP4Common.DTO.TelephoneNumber(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                telephoneNumber.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                telephoneNumber.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                telephoneNumber.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                telephoneNumber.Value = jObject["value"].ToObject<string>();
            }

            if (!jObject["vcardType"].IsNullOrEmpty())
            {
                telephoneNumber.VcardType.AddRange(jObject["vcardType"].ToObject<IEnumerable<VcardTelephoneNumberKind>>());
            }

            return telephoneNumber;
        }
    }
}
