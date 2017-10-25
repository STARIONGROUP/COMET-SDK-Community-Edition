// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExclusiveOrExpressionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ExclusiveOrExpressionResolver"/> is to deserialize a JSON object to a <see cref="ExclusiveOrExpression"/>
    /// </summary>
    public static class ExclusiveOrExpressionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ExclusiveOrExpression"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ExclusiveOrExpression"/> to instantiate</returns>
        public static CDP4Common.DTO.ExclusiveOrExpression FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var exclusiveOrExpression = new CDP4Common.DTO.ExclusiveOrExpression(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                exclusiveOrExpression.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                exclusiveOrExpression.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                exclusiveOrExpression.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["term"].IsNullOrEmpty())
            {
                exclusiveOrExpression.Term.AddRange(jObject["term"].ToObject<IEnumerable<Guid>>());
            }

            return exclusiveOrExpression;
        }
    }
}
