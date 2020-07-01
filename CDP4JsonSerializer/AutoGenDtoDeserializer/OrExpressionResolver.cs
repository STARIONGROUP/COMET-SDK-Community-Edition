// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrExpressionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="OrExpressionResolver"/> is to deserialize a JSON object to a <see cref="OrExpression"/>
    /// </summary>
    public static class OrExpressionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="OrExpression"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="OrExpression"/> to instantiate</returns>
        public static CDP4Common.DTO.OrExpression FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var orExpression = new CDP4Common.DTO.OrExpression(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                orExpression.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                orExpression.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                orExpression.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["term"].IsNullOrEmpty())
            {
                orExpression.Term.AddRange(jObject["term"].ToObject<IEnumerable<Guid>>());
            }

            return orExpression;
        }
    }
}
