// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NestedElementResolver"/> is to deserialize a JSON object to a <see cref="NestedElement"/>
    /// </summary>
    public static class NestedElementResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="NestedElement"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="NestedElement"/> to instantiate</returns>
        public static CDP4Common.DTO.NestedElement FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var nestedElement = new CDP4Common.DTO.NestedElement(iid, revisionNumber);

            if (!jObject["elementUsage"].IsNullOrEmpty())
            {
                nestedElement.ElementUsage.AddRange(jObject["elementUsage"].ToOrderedItemCollection());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                nestedElement.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                nestedElement.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isVolatile"].IsNullOrEmpty())
            {
                nestedElement.IsVolatile = jObject["isVolatile"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                nestedElement.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["nestedParameter"].IsNullOrEmpty())
            {
                nestedElement.NestedParameter.AddRange(jObject["nestedParameter"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["rootElement"].IsNullOrEmpty())
            {
                nestedElement.RootElement = jObject["rootElement"].ToObject<Guid>();
            }

            return nestedElement;
        }
    }
}
