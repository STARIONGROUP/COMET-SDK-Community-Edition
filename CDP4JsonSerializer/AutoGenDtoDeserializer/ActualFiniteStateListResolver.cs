// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateListResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActualFiniteStateListResolver"/> is to deserialize a JSON object to a <see cref="ActualFiniteStateList"/>
    /// </summary>
    public static class ActualFiniteStateListResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ActualFiniteStateList"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ActualFiniteStateList"/> to instantiate</returns>
        public static CDP4Common.DTO.ActualFiniteStateList FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var actualFiniteStateList = new CDP4Common.DTO.ActualFiniteStateList(iid, revisionNumber);

            if (!jObject["actualState"].IsNullOrEmpty())
            {
                actualFiniteStateList.ActualState.AddRange(jObject["actualState"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                actualFiniteStateList.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                actualFiniteStateList.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludeOption"].IsNullOrEmpty())
            {
                actualFiniteStateList.ExcludeOption.AddRange(jObject["excludeOption"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                actualFiniteStateList.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                actualFiniteStateList.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["possibleFiniteStateList"].IsNullOrEmpty())
            {
                actualFiniteStateList.PossibleFiniteStateList.AddRange(jObject["possibleFiniteStateList"].ToOrderedItemCollection());
            }

            return actualFiniteStateList;
        }
    }
}
