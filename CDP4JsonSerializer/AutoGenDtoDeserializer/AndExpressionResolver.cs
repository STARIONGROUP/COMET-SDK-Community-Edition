// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AndExpressionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="AndExpressionResolver"/> is to deserialize a JSON object to a <see cref="AndExpression"/>
    /// </summary>
    public static class AndExpressionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="AndExpression"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="AndExpression"/> to instantiate</returns>
        public static CDP4Common.DTO.AndExpression FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var andExpression = new CDP4Common.DTO.AndExpression(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                andExpression.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                andExpression.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                andExpression.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["term"].IsNullOrEmpty())
            {
                andExpression.Term.AddRange(jObject["term"].ToObject<IEnumerable<Guid>>());
            }

            return andExpression;
        }
    }
}
