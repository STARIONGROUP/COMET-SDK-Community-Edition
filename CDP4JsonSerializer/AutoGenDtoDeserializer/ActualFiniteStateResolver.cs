// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ActualFiniteStateResolver"/> is to deserialize a JSON object to a <see cref="ActualFiniteState"/>
    /// </summary>
    public static class ActualFiniteStateResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ActualFiniteState"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ActualFiniteState"/> to instantiate</returns>
        public static CDP4Common.DTO.ActualFiniteState FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var actualFiniteState = new CDP4Common.DTO.ActualFiniteState(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                actualFiniteState.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                actualFiniteState.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["kind"].IsNullOrEmpty())
            {
                actualFiniteState.Kind = jObject["kind"].ToObject<ActualFiniteStateKind>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                actualFiniteState.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["possibleState"].IsNullOrEmpty())
            {
                actualFiniteState.PossibleState.AddRange(jObject["possibleState"].ToObject<IEnumerable<Guid>>());
            }

            return actualFiniteState;
        }
    }
}
