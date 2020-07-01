// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametricConstraintResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParametricConstraintResolver"/> is to deserialize a JSON object to a <see cref="ParametricConstraint"/>
    /// </summary>
    public static class ParametricConstraintResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParametricConstraint"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParametricConstraint"/> to instantiate</returns>
        public static CDP4Common.DTO.ParametricConstraint FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parametricConstraint = new CDP4Common.DTO.ParametricConstraint(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parametricConstraint.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parametricConstraint.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["expression"].IsNullOrEmpty())
            {
                parametricConstraint.Expression.AddRange(jObject["expression"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parametricConstraint.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["topExpression"].IsNullOrEmpty())
            {
                parametricConstraint.TopExpression = jObject["topExpression"].ToObject<Guid?>();
            }

            return parametricConstraint;
        }
    }
}
